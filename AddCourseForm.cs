using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class AddCourseForm : KryptonForm
    {
        private string currentUserName;
        private teacher__courses_lvl1 parentForm;

        public AddCourseForm(string currentUser, teacher__courses_lvl1 parent)
        {
            currentUserName = currentUser;
            parentForm = parent;
            InitializeComponent();
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {

        }
        /* private void saveNewCourseBTN_Click(object sender, EventArgs e)
         {
             parentForm.populateCourses();

             string courseName = courseNameTXT.Text;
             string courseCode = courseCodeTXT.Text;
             string studentCourse = courseCourseTXT.Text;
             string studentSection = courseSectionTXT.Text;
             int studentYearLvl = Int32.Parse(courseYearlvlTXT.Text);
             int studentCount = 0;
             string whatDay = WeekDayTxt.Text;
             string startTime = courseStartTXT.Text;
             string endTime = courseEndTXT.Text;

             Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount, studentYearLvl, whatDay);

             newCourse.SaveCourse(currentUserName);

             if (!int.TryParse(courseYearlvlTXT.Text, out int studentYearLvl1))
             {
                 MessageBox.Show("Invalid Year Level. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
             }


             string folderPath = Path.Combine("CourseInformations", currentUserName);
             if (Directory.Exists(folderPath))
             {
                 MessageBox.Show("hi");
                 string fileName = $"{courseCode}_{studentCourse}_{studentYearLvl}-{studentSection}.txt";
                 string filePath = Path.Combine(folderPath, fileName);


                 List<StudentInfo> matchingStudents = StudentManager.GetStudentsByDepartmentAndSection(currentUserName, studentCourse, $"{studentYearLvl}-{studentSection}");

                 foreach (var student in matchingStudents)
                 {
                     using (StreamWriter writer = File.AppendText(filePath))
                     {
                         writer.WriteLine($"Student ID: {student.StudentID}");
                         writer.WriteLine($"Student Name: {student.StudentName}");
                         writer.WriteLine($"----------------------------");
                     }
                 }
             }




             this.Close();
             parentForm.Enabled = true;
             parentForm.populateCourses();
         }
        */

        private void saveNewCourseBTN_Click(object sender, EventArgs e)
        {
            // Populate courses in the parent form
            parentForm.populateCourses();

            // Get course details from text boxes
            string courseName = courseNameTXT.Text.Trim();
            string courseCode = courseCodeTXT.Text.Trim();
            string studentCourse = courseCourseTXT.Text.Trim();
            string studentSection = courseSectionTXT.Text.Trim();
            string whatDay = WeekDayTxt.Text.Trim();
            string startTime = courseStartTXT.Text.Trim();
            string endTime = courseEndTXT.Text.Trim();

            // Validate Year Level input
            if (!int.TryParse(courseYearlvlTXT.Text, out int studentYearLvl))
            {
                MessageBox.Show("Invalid Year Level. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int studentCount = 0; // Initialize student count

            // Create a new Course object
            Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount, studentYearLvl, whatDay);

            // Save course details to file
            newCourse.SaveCourse(currentUserName);

            // Construct the folder path
            string folderPath = Path.Combine("CourseInformations", currentUserName);

            // Ensure the directory exists
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Construct the file path
            string fileName = $"{courseCode}_{studentCourse} {studentYearLvl}-{studentSection}.txt";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                // Check if the course file already exists
                if (File.Exists(filePath))
                {
                    // Append student information to the existing file
                    List<StudentInfo> matchingStudents = StudentManager.GetStudentsByDepartmentAndSection(currentUserName, studentCourse, $"{studentYearLvl}-{studentSection}");

                    using (StreamWriter writer = new StreamWriter(filePath, true)) // true for append mode
                    {
                        foreach (var student in matchingStudents)
                        {
                            // Append student details
                            writer.WriteLine($"Student ID: {student.StudentID}");
                            writer.WriteLine($"Student Name: {student.StudentName}");
                            writer.WriteLine(new string('-', 30));
                        }
                    }
                }
                else
                {
                    // Create a new file and write student details
                    List<StudentInfo> matchingStudents = StudentManager.GetStudentsByDepartmentAndSection(currentUserName, studentCourse, $"{studentYearLvl}-{studentSection}");

                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (var student in matchingStudents)
                        {
                            // Write student details to the new file
                            writer.WriteLine($"Student ID: {student.StudentID}");
                            writer.WriteLine($"Student Name: {student.StudentName}");
                            writer.WriteLine(new string('-', 30));
                        }
                    }
                }

                // Success message
                MessageBox.Show("Course and student details saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Error handling
                MessageBox.Show($"An error occurred while saving the course details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Close the current form and re-enable the parent form
            this.Close();
            parentForm.Enabled = true;
            parentForm.populateCourses();
        }


        private bool DoesCourseExist(string filePath, Course newCourse)
        {
            if (!File.Exists(filePath))
            {
                return false;
            }

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains($"Course Name: {newCourse.CourseName}") &&
                        line.Contains($"Course Code: {newCourse.CourseCode}") &&
                        line.Contains($"Student Department: {newCourse.Department}") &&
                        line.Contains($"Student year and section: {newCourse.GetYearAndSection()}"))
                    {
                        return true;
                    }
                }
            }

            return false;
        }



        private void courseStartTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseStartTXT, "00:00 PM");
        }

        private void courseStartTXT_Leave(object sender, EventArgs e)
        {
            if (!IsValid12HourTimeFormat(courseStartTXT.Text))
            {
                MessageBox.Show("Please enter a valid time in 12-hour format (e.g., 01:00 PM).");
                courseStartTXT.Focus();
            }
            else
            {
                UserInput_Manager.RestoreDefaultText(courseStartTXT, "00:00 PM");
            }
        }

        private void courseEndTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseEndTXT, "00:00 PM");
        }

        private void courseEndTXT_Leave(object sender, EventArgs e)
        {
            if (!IsValid12HourTimeFormat(courseEndTXT.Text))
            {
                MessageBox.Show("Please enter a valid time in 12-hour format (e.g., 01:00 PM).");
                courseEndTXT.Focus();
            }
            else
            {
                UserInput_Manager.RestoreDefaultText(courseEndTXT, "00:00 PM");
            }
        }

        public static bool IsValid12HourTimeFormat(string input)
        {
            string pattern = @"^(0[1-9]|1[0-2]):([0-5][0-9])\s?(AM|PM)$";
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Cancelform(this);
        }

        private void courseNameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseNameTXT, "Course Name");
        }

        private void courseNameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(courseNameTXT, "Course Name");
        }

        private void courseCodeTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseCodeTXT, "Course Code");
        }

        private void courseCodeTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(courseCodeTXT, "Course Code");

        }

        private void courseYearlvlTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseYearlvlTXT, "Year Level");
        }

        private void courseYearlvlTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(courseYearlvlTXT, "Year Level");
        }

        private void courseSectionTXT_Enter(object sender, EventArgs e)
        {

            UserInput_Manager.ResetInputField(courseSectionTXT, "Designated Section");
        }

        private void courseSectionTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(courseSectionTXT, "Designated Section");
        }
    }

}