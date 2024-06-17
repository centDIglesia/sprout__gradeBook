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

            // Save student information in the department and section folder
            string departmentAndSectionsFolder = $"StudentCredentials/{parent.currentUSer}/DepartmentandSections";
            if (!Directory.Exists(departmentAndSectionsFolder))
            {
                Directory.CreateDirectory(departmentAndSectionsFolder);
            }
            string departmentSectionFileName = $"{studentDepartment} {studentYearLevel}-{studentSection}.txt";
            string departmentSectionFilePath = Path.Combine(departmentAndSectionsFolder, departmentSectionFileName);

            string studentInfo = $"Student ID: {studentID}\nStudent Name: {studentFname} {studentLname}\n";
            if (File.Exists(departmentSectionFilePath))
            {
                File.AppendAllText(departmentSectionFilePath, studentInfo + "----------------------------------------\n");
            }
            else
            {
                File.WriteAllText(departmentSectionFilePath, "----------------------------------------\n" + studentInfo + "----------------------------------------\n");
            }

            this.Close();

            parent.LoadStudentCourses(); // Ensure this method exists and refreshes student courses
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

