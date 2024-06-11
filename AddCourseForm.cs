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
        private void saveNewCourseBTN_Click(object sender, EventArgs e)
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

            string folderPath = $"CourseInformations/{currentUserName}";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"{courseCode}_{studentCourse}_{studentYearLvl}-{studentSection}.txt";
            string filePath = Path.Combine(folderPath, fileName);

            if (DoesCourseExist(filePath, newCourse))
            {
                MessageBox.Show("The course you are trying to add already exists!");
                return;
            }

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"----------------------------");
            }

            newCourse.SaveCourse(currentUserName);

            // Get students matching the department and section
            List<StudentInfo> matchingStudents = StudentManager.GetStudentsByDepartmentAndSection(currentUserName, studentCourse, $"{studentYearLvl}-{studentSection}");

            // Append student information to the course file if found
            foreach (var student in matchingStudents)
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine($"Student ID: {student.StudentID}");
                    writer.WriteLine($"Student Name: {student.StudentName}");
                    writer.WriteLine($"----------------------------");
                }
            }

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
                        line.Contains($"Student Department: {newCourse.department}") &&
                        line.Contains($"Student year and section: {newCourse.GetYearAndSection()}") &&
                        line.Contains($"Course Schedule: {newCourse.GetCourseSchedule()}"))
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
            this.Close();
        }
    }

}