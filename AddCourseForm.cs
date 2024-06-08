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
            string startTime = courseStartTXT.Text;
            string endTime = courseEndTXT.Text;


            string trimmedCourse = studentCourse.Split(',')[1].Trim();


            Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount, studentYearLvl);


            string folderPath = $"CourseInformations/{currentUserName}";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            string fileName = $"{currentUserName}.txt";
            string filePath = Path.Combine(folderPath, fileName);


            if (DoesCourseExist(filePath, newCourse))
            {
                MessageBox.Show("The course you are trying to add already exists!");
                return;
            }


            newCourse.SaveCourse(currentUserName);
            MessageBox.Show("Course added and saved successfully!");


            this.Close();
            parentForm.Enabled = true;
            parentForm.populateCourses();


            using (StreamWriter writer = new StreamWriter(filePath, true)) { }

            FilterStudents(trimmedCourse, $"{studentYearLvl}-{studentSection}", filePath);
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
        private void FilterStudents(string currentCourse, string currentSection, string filePath)
        {

            string[] fileInfo = Path.GetFileNameWithoutExtension(filePath).Split('_');
            if (fileInfo.Length < 3)
            {
                MessageBox.Show("Invalid file name format for course details.");
                return;
            }

            string courseDepartmentInitials = fileInfo[1];
            string courseYearSection = fileInfo[2];


            string directoryPath = $"StudentCredentials/{currentUserName}/";
            if (!Directory.Exists(directoryPath))
            {
                return;
            }


            string[] studentCredentialFiles = Directory.GetFiles(directoryPath, "*.txt");


            foreach (string studentCredentialFile in studentCredentialFiles)
            {

                string[] studentInfo = File.ReadAllLines(studentCredentialFile);


                Dictionary<string, string> studentDetails = new Dictionary<string, string>();
                foreach (string line in studentInfo)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length >= 2)
                    {
                        string key = parts[0].Trim();
                        string value = string.Join(":", parts.Skip(1)).Trim();
                        studentDetails[key] = value;
                    }
                }


                if (studentDetails.ContainsKey("Department") && studentDetails["Department"].Contains(courseDepartmentInitials) &&
                    studentDetails.ContainsKey("Year and Section") && studentDetails["Year and Section"].Contains(courseYearSection))
                {

                    if (studentDetails.TryGetValue("Student ID", out string studentID) &&
                        studentDetails.TryGetValue("Student Name", out string studentName))
                    {

                        using (StreamWriter writer = File.AppendText(filePath))
                        {
                            writer.WriteLine($"Student ID: {studentID}");
                            writer.WriteLine($"Student Name: {studentName}");
                        }
                    }
                }
            }
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
    }

}