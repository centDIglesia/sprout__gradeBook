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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace sprout__gradeBook
{
    public partial class studentsCARD : UserControl
    {
        private readonly teacher__studentsDashboard _parent;
        private readonly string _currentUser;

        public studentsCARD(teacher__studentsDashboard parent)
        {
            InitializeComponent();

            // Initialize parent and current user
            _parent = parent;
            _currentUser = parent.currentUSer; // Assuming currentUSer is a property in teacher__studentsDashboard
        }

        // Properties to get/set student information
        public string StudentName
        {
            get => studentcard__studentName.Text;
            set => studentcard__studentName.Text = value;
        }

        public string StudentID
        {
            get => studentcard__studentID.Text;
            set => studentcard__studentID.Text = value;
        }

        public Image StudentGender
        {
            get => studentGender.Image;
            set => studentGender.Image = value;
        }

        // Form load event handler
        private void studentsCARD_Load(object sender, EventArgs e)
        {
            // Hide initial elements
            clickedBG.Hide();
            feedback_btn.Hide();
            attendanceReport.Hide();

            removeStudent_btn.Hide();
        }

        // Click event handler for student name
        private void studentcard__studentName_Click(object sender, EventArgs e)
        {
            // Show background and feedback button on name click
            clickedBG.Show();
            feedback_btn.Show();
            attendanceReport.Show();
            removeStudent_btn.Show();
        }

        // Mouse hover event handler for student gender
        private void studentGender_MouseHover(object sender, EventArgs e)
        {
            // Change text color on hover
            studentcard__studentName.StateCommon.Content.Color1 = CustomColor.activeColor;
        }

        // Mouse leave event handler for student ID
        private void studentcard__studentID_MouseLeave(object sender, EventArgs e)
        {
            // Restore text color on mouse leave
            studentcard__studentName.StateCommon.Content.Color1 = CustomColor.mainColor;
        }

        // Click event handler for background when clicked
        private void clickedBG_Click(object sender, EventArgs e)
        {
            // Hide background and feedback button
            clickedBG.Hide();
            feedback_btn.Hide();
            attendanceReport.Hide();
            removeStudent_btn.Hide();
        }

        // Click event handler for feedback button
        private void feedback_btn_Click(object sender, EventArgs e)
        {
            // Open feedback form
            using (Form formbackground = new Form())
            {
                using (Teacher__Feedback teacher__Feedback = new Teacher__Feedback(this))
                {
                    // Configure background form properties
                    formbackground.StartPosition = FormStartPosition.CenterScreen;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .90d;
                    formbackground.BackColor = CustomColor.mainColor;
                    formbackground.Size = new Size(1147, 711);
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    // Pass student name to feedback form
                    teacher__Feedback.StudentName = this.StudentName;

                    // Set owner and show feedback form
                    teacher__Feedback.Owner = formbackground;
                    teacher__Feedback.ShowDialog();
                }
            }
        }

        // Method to save feedback to file
        public void saveFeedback(string title, string description)
        {
            // Create directory if it doesn't exist
            string baseDirectory = $"StudentFeedbacks/{_currentUser}";
            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }

            // Define file path for feedback
            string fullPath = Path.Combine(baseDirectory, $"Feedbacks.txt");

            // Write feedback to file
            using (StreamWriter write = new StreamWriter(fullPath, true))
            {
                write.WriteLine($"Receiver : {StudentID} | {StudentName}");
                write.WriteLine($"Title : {title}");
                write.WriteLine($"Sender : {GetFirstName()}");
                write.WriteLine($"Description : {description}");
                write.WriteLine("------------------------------");
            };
        }

        // Method to retrieve first name from teacher credentials
        public string GetFirstName()
        {
            // Define file path for teacher credentials
            string filePath = $"TeacherCredentials/{_currentUser}.txt";

            // Check if file exists
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The credential file could not be found.");
            }

            // Read all lines from file
            string[] lines = File.ReadAllLines(filePath);

            // Search for first name in file
            foreach (var line in lines)
            {
                if (line.StartsWith("First Name:", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract first name from line
                    string[] parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        return parts[1].Trim();
                    }
                }
            }

            // Throw exception if first name not found
            throw new InvalidOperationException("The first name could not be found in the credential file.");
        }

        private void attendanceReport_Click(object sender, EventArgs e)
        {

            // Get the student ID
            string studentId = StudentID;

            // Read attendance files and generate report
            var attendanceReport = ReadAttendanceFiles(studentId);

            // Open feedback form
            using (Form formbackground = new Form())
            {
                using (Student__AttendanceReport student__AttendanceReport = new Student__AttendanceReport(this))
                {
                    // Configure background form properties
                    formbackground.StartPosition = FormStartPosition.CenterScreen;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .90d;
                    formbackground.BackColor = CustomColor.mainColor;
                    formbackground.Size = new Size(1147, 711);
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    // Pass student name and attendance report to the form
                    student__AttendanceReport.StudentName = this.StudentName;
                    student__AttendanceReport.DisplayAttendanceReport(attendanceReport);

                    // Set owner and show feedback form
                    student__AttendanceReport.Owner = formbackground;
                    student__AttendanceReport.ShowDialog();
                }
            }
        }

        private Dictionary<string, (int presentCount, int totalClasses)> ReadAttendanceFiles(string studentId)
        {
            string directoryPath = $"Attendance Reports/{_currentUser}";
            Dictionary<string, (int presentCount, int totalClasses)> attendanceReport = new Dictionary<string, (int presentCount, int totalClasses)>();

            if (Directory.Exists(directoryPath))
            {
                var attendanceFiles = Directory.GetFiles(directoryPath, "*.txt");

                foreach (var filePath in attendanceFiles)
                {
                    ProcessAttendanceFile(filePath, studentId, attendanceReport);
                }
            }

            return attendanceReport;
        }

        private void ProcessAttendanceFile(string filePath, string studentId, Dictionary<string, (int presentCount, int totalClasses)> attendanceReport)
        {
            var lines = File.ReadAllLines(filePath);
            string currentCourse = string.Empty;
            bool studentPresent = false;

            foreach (var line in lines)
            {
                if (line.StartsWith("Course:"))
                {
                    // Extract the part after the colon
                    string courseLine = line.Split(':')[1].Trim();
                    // Extract the part before the first underscore
                    currentCourse = courseLine.Split('_')[0].Trim();

                    if (!attendanceReport.ContainsKey(currentCourse))
                    {
                        attendanceReport[currentCourse] = (0, 0);
                    }
                }
                else if (line.StartsWith("Student ID:") && line.Contains(studentId))
                {
                    studentPresent = true;
                }
                else if (line.StartsWith("Status:") && studentPresent)
                {
                    var status = line.Split(':')[1].Trim();
                    var (presentCount, totalClasses) = attendanceReport[currentCourse];
                    if (status == "Present")
                    {
                        presentCount++;
                    }
                    totalClasses++;
                    attendanceReport[currentCourse] = (presentCount, totalClasses);
                    studentPresent = false; // Reset for the next student entry
                }
            }
        }

        private void removeStudent_btn_Click(object sender, EventArgs e)
        {

            // Define the path to the student's file
            string studentFilePath = $"StudentCredentials/{_currentUser}/{StudentID}.txt";

            // Check if the student's file exists
            if (File.Exists(studentFilePath))
            {
                // Delete the student's file
                File.Delete(studentFilePath);
            }

            // Define the path to the DepartmentandSections directory
            string departmentDirectoryPath = $"StudentCredentials/{_currentUser}/DepartmentandSections";

            // Check if the DepartmentandSections directory exists
            if (Directory.Exists(departmentDirectoryPath))
            {
                // Get all .txt files in the directory
                string[] departmentFiles = Directory.GetFiles(departmentDirectoryPath, "*.txt");

                // Initialize a variable to store the file path where the student ID is found
                string fileWithStudentID = null;

                // Iterate over the files
                foreach (string departmentFilePath in departmentFiles)
                {
                    // Read all lines from the file
                    string[] lines = File.ReadAllLines(departmentFilePath);

                    // Check if the student's ID is in the file
                    if (lines.Any(line => line.Contains($"Student ID: {StudentID}")))
                    {
                        // Store the file path without extension in the variable
                        fileWithStudentID = Path.GetFileNameWithoutExtension(departmentFilePath);
                        break;
                    }
                }

                // If the student ID was found in a file
                if (fileWithStudentID != null)
                {
                    // Get the full path of the file again
                    string fullPath = Path.Combine(departmentDirectoryPath, fileWithStudentID + ".txt");

                    // Read all lines from the file
                    string[] lines = File.ReadAllLines(fullPath);

                    // Create a new list to hold the updated lines
                    List<string> updatedLines = new List<string>();

                    // Iterate over the lines
                    for (int i = 0; i < lines.Length; i++)
                    {
                        // If the current line contains the student's ID, skip lines until "--------"
                        if (lines[i].Contains($"Student ID: {StudentID}"))
                        {
                            while (i < lines.Length && !lines[i].Contains("----------------------------------------"))
                            {
                                i++;
                            }
                            // Skip the line with "--------"
                            if (i < lines.Length && lines[i].Contains("----------------------------------------"))
                            {
                                i++;
                            }
                        }
                        else
                        {
                            // Otherwise, add the line to the updated lines
                            updatedLines.Add(lines[i]);
                        }
                    }

                    // Write the updated lines back to the file
                    File.WriteAllLines(fullPath, updatedLines);
                }

                _parent.FilterAndLoadStudents(_parent.currentSearchbarInput, _parent.currentCourse, _parent.currentSection);

                MessageBox.Show("Student information has been successfully deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }





    }
}

