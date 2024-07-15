using System;
using System.Collections.Generic;
using System.Drawing;
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
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(SaveStudent_KeyDown);
        }
        private void SaveStudent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveNewStudentBTN_Click(sender, e);
                e.Handled = true;
            }
        }
        private void saveNewStudentBTN_Click(object sender, EventArgs e)
        {
            // Retrieve student information from form controls
            string studentFname = studentFnameTXT.Text;
            string studentMname = studentMnameTXT.Text;
            string studentLname = studentLnameTXT.Text;
            string studentID = studentIDTXT.Text;
            string studentEmail = studentEmailTXT.Text;
            DateTime studentBirthday = studentBirthdayPickerf.Value;
            string studentGender = studentMaleRADIOBUTTON.Checked ? "Male" : (studentFemaleRADIOBUTTON.Checked ? "Female" : "");
            string studentUsername = $"{studentFname} {studentLname}";
            string studentDepartment = studentDepartmentTXT.Text;
            string studentYearLevel = studentYearLevelTXT.Text;
            string studentSection = studentSectionTXT.Text;


            // Validate inputs
            if (!UserInput__Validator.ValidateNotEmpty(studentFname, "First Name"))
            {
                MessageBox.Show("Student's First Name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentFnameTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentMname, "Middle Name"))
            {
                MessageBox.Show("Student's Middle name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentMnameTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentMname, "Last Name"))
            {
                MessageBox.Show("Student's Last name cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentLnameTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentID, "Student ID"))
            {
                MessageBox.Show("Student's Department cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentIDTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentEmail, "Email"))
            {
                MessageBox.Show("Student's Email cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentEmailTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateEmail(studentEmailTXT.Text))
            {
                MessageBox.Show("Student's Email is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentEmailTXT.Focus();
                return;
            }

            // Validate gender selection
            if (string.IsNullOrEmpty(studentGender))
            {
                MessageBox.Show("Please select a gender.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentSection, "Section"))
            {
                MessageBox.Show("Student's Designated Section cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentSectionTXT.Focus();
                return;
            }

            if (!UserInput__Validator.ValidateNotEmpty(studentDepartment, "Select Department"))
            {
                MessageBox.Show("Student's Department cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentDepartmentTXT.Focus();
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

            parent.LoadStudentCourses();
        }

        private void studentIDTXT_Leave(object sender, EventArgs e)
        {
            //implement here if student id already exist
            UserInput_Manager.RestoreDefaultText(studentIDTXT, "Student ID");

            string folderPath = $"StudentCredentials/{parent.currentUSer}";
            if (studentIDTXT.Text != "Student ID")
            {
                bool usernameExists = Account__Manager.UserExists(studentIDTXT.Text, folderPath);
                if (usernameExists)
                {


                    logInForm.setInputState(studentIDTXT, stidtootip, Color.Red);
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    studentIDTXT.Clear();
                    studentIDTXT.Focus();
                }
                else
                {
                    logInForm.setInputState(studentIDTXT, stidtootip, CustomColor.mainColor);

                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Cancelform(this);
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
            // Define a simple email regex pattern
            string emailPattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";

            if (Regex.IsMatch(studentEmailTXT.Text, emailPattern))
            {
                // If the email is valid, restore the default text
                UserInput_Manager.RestoreDefaultText(studentEmailTXT, "Email");
            }
            else
            {
                // If the email is invalid, show an error message and clear the text box
                MessageBox.Show("Invalid email address. Please enter a valid email.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                studentEmailTXT.Text = "";
                studentEmailTXT.Focus();
            }


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

        private void studentYearLevelTXT_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(studentYearLevelTXT.Text, out int number))
            {
                if (number < 1 || number > 4)
                {
                    MessageBox.Show("Please enter a number from 1 to 4.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    studentYearLevelTXT.Text = "";
                }
            }
        }

        private void studentYearLevelTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) || e.KeyChar < '1' || e.KeyChar > '4')
            {
                // Check if the pressed key is Backspace or Delete
                if (e.KeyChar != (char)8 && e.KeyChar != (char)127)
                {
                    // If not, suppress the key press
                    e.Handled = true;
                }
            }
        }

    }

}

