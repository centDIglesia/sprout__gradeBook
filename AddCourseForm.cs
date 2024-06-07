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
            int studentCount = 0; // To be updated based on student count
            string startTime = courseStartTXT.Text;
            string endTime = courseEndTXT.Text;

            string trimmedCourse = studentCourse.Split(',')[1].Trim();

            Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount, studentYearLvl);
            newCourse.SaveCourse(currentUserName);

            MessageBox.Show("Course added and saved successfully!");
            this.Close();

            parentForm.Enabled = true;
            parentForm.populateCourses();

            string folderPath = $"CourseInformations/{currentUserName}";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"{courseCode}_{studentCourse}_{studentYearLvl}-{studentSection}.txt";
            string filePath = Path.Combine(folderPath, fileName);


            using (StreamWriter writer = new StreamWriter(filePath))
            {

            }


            FilterStudents(trimmedCourse, $"{studentYearLvl}-{studentSection}", filePath);
        }

        private void FilterStudents(string currentCourse, string currentSection, string filePath)
        {

            string[] fileInfo = Path.GetFileNameWithoutExtension(filePath).Split('_');
            string courseDepartmentInitials = fileInfo[1];
            string courseYearSection = fileInfo[2];


            string[] studentCredentialFiles = Directory.GetFiles($"StudentCredentials/{currentUserName}/", "*.txt");


            foreach (string studentCredentialFile in studentCredentialFiles)
            {
                MessageBox.Show($"Checking student credentials file: {studentCredentialFile}");
                MessageBox.Show($"{courseDepartmentInitials},{courseYearSection}");

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

                    if (studentDetails.TryGetValue("Student ID", out string studentID))
                    {
                        MessageBox.Show($"Student ID found: {studentID}");


                        using (StreamWriter writer = File.AppendText(filePath))
                        {
                            writer.WriteLine(studentID);
                            MessageBox.Show($"Student ID {studentID} appended to {filePath}");
                        }
                    }
                }
            }

            MessageBox.Show("Finished checking all student credential files.");
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

        private void courseStartTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }

        private void courseSectionTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }

        private void courseEndTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }

        private void courseStudentCountTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }
    }
}
