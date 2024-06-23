using System;
using System.Collections.Generic;
using System.Globalization;
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
        private int previousSelectedIndex;

        public AddCourseForm(string currentUser, teacher__courses_lvl1 parent)
        {
            currentUserName = currentUser;
            parentForm = parent;
            InitializeComponent();

            // Set up validation for time fields
            courseStartTXT.ValidatingType = typeof(DateTime);
            courseEndTXT.ValidatingType = typeof(DateTime);

            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(SaveCourse_KeyDown);

            // Set the initial selected item
            WeekDayTxt.SelectedIndex = 0;
            courseCourseTXT.SelectedIndex = 0;

            // Store the initial selected index
            previousSelectedIndex = 0;
        }

        private void SaveCourse_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveNewCourseBTN_Click(sender, e);
                e.Handled = true;
            }
        }
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

            // Validate inputs
            if (!UserInput__Validator.ValidateNotEmpty(courseName, "Course Name"))
            {
                MessageBox.Show("Course Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseNameTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(courseCode, "Course Code"))
            {
                MessageBox.Show("Course Code cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseCodeTXT.Focus();
                return;
            }

            // Validate Year Level input
            if (!int.TryParse(courseYearlvlTXT.Text, out int studentYearLvl))
            {
                MessageBox.Show("Invalid Year Level. Please enter a valid number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(courseYearlvlTXT.Text, "Designated Year Level"))
            {
                MessageBox.Show("Dewsignated Year level cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseYearlvlTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentCourse, "Select Designated Department"))
            {
                MessageBox.Show("Student's Department cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseCourseTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentSection, "Designated Section"))
            {
                MessageBox.Show("Student's Designated Section cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseSectionTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(whatDay, "Please Select the Day(s) When the Course Will Take Place"))
            {
                MessageBox.Show("Day of the week cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WeekDayTxt.Focus();
                return;
            }

            // Validate start time is not empty
            if (!UserInput__Validator.ValidateNotEmpty(startTime, "00:00 PM"))
            {
                MessageBox.Show("Start Time cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseStartTXT.Focus();
                return;
            }

            // Validate end time is not empty
            if (!UserInput__Validator.ValidateNotEmpty(endTime, "00:00 PM"))
            {
                MessageBox.Show("End Time cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseEndTXT.Focus();
                return;
            }

            // Validate start time format
            if (!UserInput__Validator.ValidateTimeFormat(startTime))
            {
                MessageBox.Show("Invalid start time. Please enter a valid time in the format HH:MM AM/PM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseStartTXT.Focus();
                return;
            }

            // Validate end time format
            if (!UserInput__Validator.ValidateTimeFormat(endTime))
            {
                MessageBox.Show("Invalid end time. Please enter a valid time in the format HH:MM AM/PM.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseEndTXT.Focus();
                return;
            }

            // Validate end time is after start time
            if (!UserInput__Validator.ValidateEndTimeAfterStartTime(startTime, endTime))
            {
                MessageBox.Show("End time must be after start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                courseEndTXT.Focus();
                return;
            }

            int studentCount = Course.GetStudentCountinCourses(currentUserName, studentCourse, studentSection); // Initialize student count

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
            UserInput_Manager.ResetInputField(courseYearlvlTXT, "Designated Year Level");
        }
        private void courseYearlvlTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(courseYearlvlTXT, "Designated Year Level");
        }
        private void courseSectionTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseSectionTXT, "Designated Section");
        }

        private void courseSectionTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(courseSectionTXT, "Designated Section");
        }

        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();
            b.Cancelform(this);
        }


        private void WeekDayTxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "Select the Day When the Course Will Take Place" is selected, revert to the previous selection
            if (WeekDayTxt.SelectedIndex == 0)
            {
                WeekDayTxt.SelectedIndex = previousSelectedIndex;
            }
            else
            {
                previousSelectedIndex = WeekDayTxt.SelectedIndex;
            }
        }

        private void courseCourseTXT_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "Select the Day When the Course Will Take Place" is selected, revert to the previous selection
            if (courseCourseTXT.SelectedIndex == 0)
            {
                courseCourseTXT.SelectedIndex = previousSelectedIndex;
            }
            else
            {
                previousSelectedIndex = courseCourseTXT.SelectedIndex;
            }
        }

        private void courseStartTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Convert the key pressed to uppercase
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void courseEndTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Convert the key pressed to uppercase
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
