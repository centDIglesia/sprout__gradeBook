using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class AddStudentForm : KryptonForm
    {
        private readonly teacher__studentsDashboard parent;
        private readonly string teacherSchool;

        public AddStudentForm(teacher__studentsDashboard parentDashboard, string school)
        {
            InitializeComponent();
            parent = parentDashboard;
            teacherSchool = school;
        }
        private void saveNewStudentBTN_Click(object sender, EventArgs e)
        {
            // Retrieve student information from form controls
            string studentFname = studentFnameTXT.Text;
            string studentMname = studentMnameTXT.Text;
            string studentLname = studentLnameTXT.Text;
            string studentID = studentIDTXT.Text; // Ensure studentID is initialized here
            string studentEmail = studentEmailTXT.Text;
            DateTime studentBirthday = studentBirthdayPicker.Value;
            string studentGender = studentMaleRADIOBUTTON.Checked ? "Male" : (studentFemaleRADIOBUTTON.Checked ? "Female" : "");
            string studentUsername = $"{studentFname} {studentLname}";
            string studentDepartment = studentDepartmentTXT.Text;
            string studentYearLevel = studentYearLevelTXT.Text;
            string studentSection = studentSectionTXT.Text;

            // Validate gender selection
            if (string.IsNullOrEmpty(studentGender))
            {
                MessageBox.Show("Please select a gender.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new student object
            Student newStudent = new Student(studentID, studentFname, studentMname, studentLname, studentEmail, studentUsername, studentBirthday, studentGender, studentYearLevel, studentSection, studentDepartment, teacherSchool);

            // Save the student information
            Account__Manager.SaveStudentUser(newStudent, parent.currentUSer);
            MessageBox.Show("Student saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Append student details to course files

            UpdateStudentInfo();
            // Close the form and update parent form
            this.Close();
            parent.LoadStudentCourses(); // Ensure this method exists and refreshes student courses

        }
        private void UpdateStudentInfo()
        {
            string courseInfoPath = $"CourseInformations/{parent.currentUSer}";
            string studentCredentialsPath = $"StudentCredentials/{parent.currentUSer}";

            // Ensure directories exist
            if (!Directory.Exists(courseInfoPath) || !Directory.Exists(studentCredentialsPath))
            {
                MessageBox.Show("Course information directory or student credentials directory does not exist.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 1: Parse course information files and create a dictionary for quick lookup
            Dictionary<string, string> courseInfoDictionary = new Dictionary<string, string>();
            foreach (string filename in Directory.GetFiles(courseInfoPath, "*.txt"))
            {
                // Extract course department and section from filename
                string[] parts = Path.GetFileNameWithoutExtension(filename).Split('_');
                if (parts.Length >= 2)
                {
                    string courseInfoKey = parts[1].Trim(); // Assuming the format is oop_Bachelor of Science in Accountancy , BSA 1-1
                    courseInfoDictionary[courseInfoKey] = filename;
                }
            }

            // Step 2: Loop through each student's file in StudentCredentials/{currentUser}/
            foreach (string filename in Directory.GetFiles(studentCredentialsPath, "*.txt"))
            {
                string studentInfo = File.ReadAllText(filename);

                // Extract student department, year, and section from studentInfo
                Match match = Regex.Match(studentInfo, @"Department: (.+)\r?\nYear and Section: (.+)");
                if (match.Success)
                {
                    string studentDepartment = match.Groups[1].Value.Trim();
                    string studentSection = match.Groups[2].Value.Trim();
                    string studentCourseKey = $"{studentDepartment} {studentSection}";

                    // Step 3: Check if there is a matching course information file and append student info
                    if (courseInfoDictionary.ContainsKey(studentCourseKey))
                    {
                        string courseInfoFilename = courseInfoDictionary[studentCourseKey];

                        // Check if the student info already exists in the course file
                        AppendStudentInfoToCourseFile(courseInfoFilename, studentInfo);
                    }

                }
            }
        }


        private void AppendStudentInfoToCourseFile(string courseInfoFilename, string studentInfo)
        {
            // Extract student ID and name from studentInfo
            Match matchStudentId = Regex.Match(studentInfo, @"Student ID: (.+?)\r?\n");
            Match matchStudentName = Regex.Match(studentInfo, @"Student Name: (.+)\r?\n");
            if (matchStudentId.Success && matchStudentName.Success)
            {
                string studentId = matchStudentId.Groups[1].Value.Trim();
                string studentName = matchStudentName.Groups[1].Value.Trim();

                // Read existing content of the course file to prevent duplication
                string existingContent = File.ReadAllText(courseInfoFilename);

                // Check if the student ID already exists in the file
                if (existingContent.Contains($"Student ID: {studentId}"))
                {

                    return;
                }

                // Append student information to the course file
                using (StreamWriter writer = File.AppendText(courseInfoFilename))
                {
                    writer.WriteLine("-------------------------------");
                    writer.WriteLine($"Student ID: {studentId}");
                    writer.WriteLine($"Student Name: {studentName}");
                    writer.WriteLine("-------------------------------");
                }
            }
        }



        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void studentIDTXT_Leave(object sender, EventArgs e)
        {
            //implement here if student id already exist
            UserInput_Manager.RestoreDefaultText(studentIDTXT, "Student ID");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Cancelform(this);
        }

        private void studentFnameTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentIDTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentIDTXT, "Student ID");
        }

        private void studentEmailTXT_Enter(object sender, EventArgs e)
        {

            UserInput_Manager.ResetInputField(studentEmailTXT, "Email");
        }

        private void studentEmailTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentEmailTXT, "Email");
        }

        private void studentYearLevelTXT_Enter(object sender, EventArgs e)
        {

            UserInput_Manager.ResetInputField(studentYearLevelTXT, "Year Level");
        }

        private void studentYearLevelTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentYearLevelTXT, "Year Level");
        }

        private void studentSectionTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentSectionTXT, "Section");
        }

        private void studentSectionTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentSectionTXT, "Section");
        }

        private void studentFnameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentFnameTXT, "First Name");
        }

        private void studentFnameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentFnameTXT, "First Name");
        }

        private void studentMnameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentMnameTXT, "Middle Name");
        }

        private void studentMnameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentMnameTXT, "Middle Name");
        }

        private void studentLnameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentLnameTXT, "Last Name");
        }

        private void studentLnameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentLnameTXT, "Last Name");
        }




    }

}

