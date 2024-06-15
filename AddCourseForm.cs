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
        /*
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

            // Check if the course file already exists
            if (DoesCourseExist(filePath, newCourse))
            {
                MessageBox.Show("This course already exists. Please enter a new course.", "Course Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save course details to file
            newCourse.SaveCourse(currentUserName);

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