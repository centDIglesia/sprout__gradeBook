using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class Teacher__Attendance : KryptonForm
    {
        public string currentUSer { get; set; }

        public Teacher__Attendance(string currentuser)
        {
            currentUSer = currentuser;
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Save_Attendance_KeyDown);
        }
        private void Save_Attendance_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                generateReportButton_Click(sender, e);
                e.Handled = true;
            }

        }
        private void LoadTxtFilesIntoComboBox(string currentUser)
        {
            string directoryPath = $"CourseInformations/{currentUser}/";

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show(
                    "Please ensure you have added the course details and set up the grading system before proceeding. To add a course, navigate to the 'Courses' section and click on 'Add New Course'. Then, click on the course and add a 'Grading System' by selecting the 'Grading System' button and setting up the required components.",
                    "Incomplete Setup",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string filePath in txtFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                courseComboBox.Items.Add(fileName);
            }
        }

        private void Teacher__Attendance_Load(object sender, EventArgs e)
        {
            LoadTxtFilesIntoComboBox(currentUSer);

            // Set the date label to the current date
            attendance_Datelbl.Text = DateTime.Now.ToString("MMMM dd, yyyy");
        }

        private void LoadStudentCards(string filePath)
        {
            // Clear existing student cards
            attendance_Panel.Controls.Clear();

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                string studentID = null;
                string studentName = null;

                List<(string studentID, string studentName, string lastName)> students = new List<(string, string, string)>();

                foreach (string line in lines)
                {
                    // Look for the "Student ID:" prefix
                    if (line.StartsWith("Student ID:"))
                    {
                        studentID = line.Substring("Student ID:".Length).Trim();
                    }
                    // Look for the "Student Name:" prefix
                    else if (line.StartsWith("Student Name:"))
                    {
                        studentName = line.Substring("Student Name:".Length).Trim();

                        // Get the last name from the student's credentials file
                        string studentFilePath = $"StudentCredentials/{currentUSer}/{studentID}.txt";
                        string lastName = GetLastNameFromFile(studentFilePath);

                        students.Add((studentID, studentName, lastName));

                        studentID = null; // Reset for the next student
                        studentName = null; // Reset for the next student
                    }
                }

                // Sort students by last name
                var sortedStudents = students.OrderBy(s => s.lastName);

                foreach (var student in sortedStudents)
                {
                    AddStudentCard(student.studentID, student.studentName);
                }
            }
            catch 
            {
               
                MessageBox.Show("No student added yet. Please add a student first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetLastNameFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    // Look for the "Last Name:" prefix
                    if (line.StartsWith("Last Name:"))
                    {
                        return line.Substring("Last Name:".Length).Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, read errors)
                MessageBox.Show($"Error reading last name from file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return string.Empty;
        }

        private void AddStudentCard(string studentID, string studentName)
        {
            Attendance__Row studentCard = new Attendance__Row(this)
            {
                currentStudentID = studentID,
                currentStudentName = studentName
            };

            attendance_Panel.Controls.Add(studentCard);
        }

        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = courseComboBox.SelectedItem.ToString();
            string[] trimmedCourseParts = selectedCourse.Split('_');

            if (trimmedCourseParts.Length == 2)
            {
                string trimmedCourseName = trimmedCourseParts[1].Trim();
                string studentFilePath = $"StudentCredentials/{currentUSer}/DepartmentandSections/{trimmedCourseName}.txt";
                LoadStudentCards(studentFilePath);
            }
            else
            {
                MessageBox.Show("Selected course format is incorrect. Please select a valid course.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void generateReportButton_Click(object sender, EventArgs e)
        {
            SaveAttendanceReport();
        }

        private void SaveAttendanceReport()
        {
            if (courseComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a course before generating the report.", "No Course Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (Attendance__Row row in attendance_Panel.Controls.OfType<Attendance__Row>())
            {
                if (row.CurrentStatus == "Unknown")
                {
                    MessageBox.Show("All students must have a status selected before generating the report.", "Incomplete Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string date = attendance_Datelbl.Text;
            string course = courseComboBox.SelectedItem?.ToString() ?? "Unknown Course";
            string userName = currentUSer; // Assuming currentUSer is the username

            // Create folder structure if it doesn't exist
            string reportsFolder = Path.Combine("Attendance Reports", userName);
            Directory.CreateDirectory(reportsFolder);

            string fileName = $"{date}_{course.Replace(" ", "-")}.txt";
            string filePath = Path.Combine(reportsFolder, fileName);

            // Check if the file already exists
            if (File.Exists(filePath))
            {
                MessageBox.Show("A report for this date and course already exists.", "Duplicate Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Date: {date}");
                writer.WriteLine($"Course: {course}");
                writer.WriteLine();

                foreach (Attendance__Row row in attendance_Panel.Controls.OfType<Attendance__Row>())
                {
                    writer.WriteLine($"Student ID: {row.currentStudentID}");
                    writer.WriteLine($"Student Name: {row.currentStudentName}");
                    writer.WriteLine($"Status: {row.CurrentStatus}");
                    writer.WriteLine();
                }
            }

            MessageBox.Show("Attendance report generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}