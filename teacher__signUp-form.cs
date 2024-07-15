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
using ComponentFactory.Krypton.Toolkit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace sprout__gradeBook
{
    public partial class logInForm : CustomForm
    {
        public logInForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(logInForm_KeyDown);
        }

        private void teacher__signUp_form_Load(object sender, EventArgs e)
        {
            // Hide all tooltips initially
            HideTooltips();

        }
        private void logInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (teacherSIGNINform.Visible)
                {
                    signIn__btn_Click(sender, e);
                }
                else if (teacherSIGNUP__form.Visible)
                {
                    signUp__btn_Click(sender, e);
                }
            }
        }
        // Hide all tooltips
        private void HideTooltips()
        {
            fname__tooltip.Hide();
            lname__tooltip.Hide();
            email__tooltip.Hide();
            school__tooltip.Hide();
            uname__tooltip.Hide();
            pass__tooltip.Hide();
            cpass__tooltip.Hide();
            teacherSIGNUP__form.Hide();
            signIn__EmailTooltip.Hide();
            signIn__PassTooltip.Hide();
        }
        //sign up form
        //first name
        private void signupFNAME__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupFNAME__txtbox, "First Name");
            fname__tooltip.Show();
        }

        private void signupFNAME__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signupFNAME__txtbox, "First Name");
            UserInput_Manager.ToggleTooltip(signupFNAME__txtbox, fname__tooltip, "First Name");
            string firstName = signupFNAME__txtbox.Text;

            if (signupFNAME__txtbox.Text != "First Name")
            {
                if (!UserInput__Validator.ValidateAlphabetic(firstName))
                {
                    MessageBox.Show("Numbers are not allowed in this field. Please enter only letters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupFNAME__txtbox, fname__tooltip, Color.Red);
                    signupFNAME__txtbox.Focus();
                    signupFNAME__txtbox.Clear();

                }

                else if (!UserInput__Validator.ValidateLength(firstName, 1, 20))
                {
                    MessageBox.Show("The input length must be between 1 and 20 characters.", "Invalid Length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupFNAME__txtbox, fname__tooltip, Color.Red);
                    signupFNAME__txtbox.Focus();
                    signupFNAME__txtbox.Clear();
                }
                else
                    setInputState(signupFNAME__txtbox, fname__tooltip, CustomColor.mainColor);
            }
        }

        //last name

        private void signupLNAME__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupLNAME__txtbox, "Last Name");
            lname__tooltip.Show();
        }

        private void signupLNAME__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signupLNAME__txtbox, "Last Name");
            UserInput_Manager.ToggleTooltip(signupLNAME__txtbox, lname__tooltip, "Last Name");
            string lastName = signupLNAME__txtbox.Text;
            if (signupLNAME__txtbox.Text != "Last Name")
            {
                if (!UserInput__Validator.ValidateAlphabetic(lastName))
                {
                    MessageBox.Show("Numbers are not allowed in this field. Please enter only letters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupLNAME__txtbox, fname__tooltip, Color.Red);
                    signupLNAME__txtbox.Focus();
                    signupLNAME__txtbox.Clear();
                }

                else if (!UserInput__Validator.ValidateLength(lastName, 1, 20))
                {
                    MessageBox.Show("The input length must be between 1 and 20 characters.", "Invalid Length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupLNAME__txtbox, lname__tooltip, Color.Red);
                    signupLNAME__txtbox.Focus();
                    signupLNAME__txtbox.Clear();
                }
                else
                    setInputState(signupLNAME__txtbox, lname__tooltip, CustomColor.mainColor);

            }

        }

        //email
        private void signupEMAIL__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signupEMAIL__txtbox, "Email");
            UserInput_Manager.ToggleTooltip(signupEMAIL__txtbox, email__tooltip, "Email");

            if (signupEMAIL__txtbox.Text != "Email")
            {

                if (!UserInput__Validator.ValidateEmail(signupEMAIL__txtbox.Text))
                {
                    signupEMAIL__txtbox.StateCommon.Border.Color1 = Color.Red;
                    signupEMAIL__txtbox.StateCommon.Content.Color1 = Color.Red;
                    email__tooltip.ForeColor = Color.Red;

                    MessageBox.Show("Please enter a valid email address in the format: example@gmail.com.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    signupEMAIL__txtbox.Focus();


                }

                else if (!UserInput__Validator.ValidateLength(signupEMAIL__txtbox.Text, 12, 35))
                {
                    MessageBox.Show("The input length must be between 11 and 35 characters.", "Invalid Length", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupEMAIL__txtbox, email__tooltip, Color.Red);
                    signupEMAIL__txtbox.Focus();
                }

                else
                    setInputState(signupEMAIL__txtbox, email__tooltip, CustomColor.mainColor);


            }

        }
        private void signupEMAIL__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupEMAIL__txtbox, "Email");
            email__tooltip.Show();
        }

        //user name
        private void signupUNAME__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupUNAME__txtbox, "Username");
            uname__tooltip.Show();
        }
        private void signupUNAME__txtbox_Leave(object sender, EventArgs e)
        {
            string folderPath = Role__form.selectedRole == "student" ? "studentCredentials" : "teacherCredentials";

            UserInput_Manager.RestoreDefaultText(signupUNAME__txtbox, "Username");
            UserInput_Manager.ToggleTooltip(signupUNAME__txtbox, uname__tooltip, "Username");

            if (signupUNAME__txtbox.Text != "Username")
            {
                bool usernameExists = Account__Manager.UserExists(signupUNAME__txtbox.Text, folderPath);
                if (usernameExists)
                {


                    setInputState(signupUNAME__txtbox, uname__tooltip, Color.Red);
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    signupUNAME__txtbox.Clear();
                    signupUNAME__txtbox.Focus();
                }
                else
                {
                    setInputState(signupUNAME__txtbox, uname__tooltip, CustomColor.mainColor);

                }
            }

        }


        //school
        private void signupSCHOOL__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupSCHOOL__txtbox, "School");
            school__tooltip.Show();
        }

        private void signupSCHOOL__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signupSCHOOL__txtbox, "School");
            UserInput_Manager.ToggleTooltip(signupSCHOOL__txtbox, school__tooltip, "School");

            if (signupSCHOOL__txtbox.Text != "School")
            {
                if (!UserInput__Validator.ValidateLength(signupSCHOOL__txtbox.Text, 10, 80))
                {
                    setInputState(signupSCHOOL__txtbox, school__tooltip, Color.Red);

                    signupSCHOOL__txtbox.Focus();
                    MessageBox.Show("The school name must be between 10 and 80 characters long only. Please enter a valid school name.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    setInputState(signupSCHOOL__txtbox, school__tooltip, CustomColor.mainColor);

                }
            }

        }

        //password
        private void signupPASS__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupPASS__txtbox, "Password");
            pass__tooltip.Show();
        }

        private void signupPASS__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signupPASS__txtbox, "Password");
            UserInput_Manager.ToggleTooltip(signupPASS__txtbox, pass__tooltip, "Password");


            string password = signupPASS__txtbox.Text;

            if (signupPASS__txtbox.Text != "Password")
            {
                if (!UserInput__Validator.ValidateLength(password, 8, 20))
                {
                    MessageBox.Show("Password must be between 8 and 20 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupPASS__txtbox, pass__tooltip, CustomColor.errorColor);
                    signupPASS__txtbox.Focus();
                    return;
                }

                if (!UserInput__Validator.ContainsUppercase(password))
                {
                    MessageBox.Show("Password must contain at least one uppercase letter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupPASS__txtbox, pass__tooltip, CustomColor.errorColor);
                    signupPASS__txtbox.Focus();
                    return;
                }

                if (!UserInput__Validator.ContainsDigit(password))
                {
                    MessageBox.Show("Password must contain at least one digit.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupPASS__txtbox, pass__tooltip, CustomColor.errorColor);
                    signupPASS__txtbox.Focus();
                    return;
                }

                if (!UserInput__Validator.ContainsLowercase(password))
                {
                    MessageBox.Show("Password must contain at least one lowercase letter.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    setInputState(signupPASS__txtbox, pass__tooltip, CustomColor.errorColor);
                    signupPASS__txtbox.Focus();
                    return;
                }

                setInputState(signupPASS__txtbox, pass__tooltip, CustomColor.mainColor);

            }



        }

        //confirm password
        private void signupCPASS__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signupCPASS__txtbox, "Confirm Password");
            cpass__tooltip.Show();

            signupCPASS__txtbox.UseSystemPasswordChar = true;
        }

        private void signupCPASS__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signupCPASS__txtbox, "Confirm Password");
            UserInput_Manager.ToggleTooltip(signupCPASS__txtbox, cpass__tooltip, "Confirm Password");

            if (signupCPASS__txtbox.Text != "Confirm Password")
            {
                signupCPASS__txtbox.UseSystemPasswordChar = true;

                if (signupPASS__txtbox.Text != signupCPASS__txtbox.Text)
                {
                    signupCPASS__txtbox.StateCommon.Border.Color1 = Color.Red;
                    cpass__tooltip.ForeColor = Color.Red;
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    signupCPASS__txtbox.StateCommon.Border.Color1 = CustomColor.mainColor;
                    cpass__tooltip.ForeColor = CustomColor.mainColor;
                }
            }
            else
            {
                signupCPASS__txtbox.UseSystemPasswordChar = false;

            }


        }





        //buttons for switching from sign in to sin up and vice versa
        private void signup__switchBTN_Click(object sender, EventArgs e)
        {
            teacherSIGNINform.Hide();
            teacherSIGNUP__form.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            teacherSIGNINform.Show();
            teacherSIGNUP__form.Hide();


        }

        //sign in form
        //email
        private void signInEmail__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signinEMAIL__txtbox, "Username");
            signIn__EmailTooltip.Show();
        }

        private void signInEmail__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signinEMAIL__txtbox, "Username");
            UserInput_Manager.ToggleTooltip(signinEMAIL__txtbox, signIn__EmailTooltip, "Username");

            string username = signinEMAIL__txtbox.Text;

            if (username != "Username")
            {
                if (!UserInput__Validator.ValidateLength(username, 1, 20))
                {
                    MessageBox.Show("Username must be between 1 and 20 characters long only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        //password
        private void signInPass__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signinPASS__txtbox, "Password");
            signIn__PassTooltip.Show();
            signinPASS__txtbox.UseSystemPasswordChar = true;
        }

        private void signInPass__txtbox_Leave(object sender, EventArgs e)
        {

            UserInput_Manager.RestoreDefaultText(signinPASS__txtbox, "Password");
            UserInput_Manager.ToggleTooltip(signinPASS__txtbox, signIn__PassTooltip, "Password");
            string password = signinPASS__txtbox.Text;

            if (signinPASS__txtbox.Text == "Password")
            {
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }

            if (password != "Password")
            {
                if (!UserInput__Validator.ValidateLength(password, 1, 30))
                {
                    MessageBox.Show("Password must be between 1 and 30 characters long only.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }




        private void close_btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Exitform();
        }
        //sign up show password icon fuction

        bool isPassVisible = false;

        private void showPass__icon_Click(object sender, EventArgs e)
        {
            if (!isPassVisible)
            {
                isPassVisible = true;
                showPass__icon.Image = Properties.Resources.closed__eye;
                signupPASS__txtbox.UseSystemPasswordChar = false;
            }
            else
            {
                isPassVisible = false;
                showPass__icon.Image = Properties.Resources.open__eye;
                if (signupPASS__txtbox.Text != "Password")
                {
                    signupPASS__txtbox.UseSystemPasswordChar = true;
                }
            }
        }

        //sign in show password icon fuction
        bool isPassVisible2 = false;
        private void signIn__showPassicon_Click(object sender, EventArgs e)
        {
            if (!isPassVisible2)
            {
                isPassVisible2 = true;
                signIn__showPassicon.Image = Properties.Resources.closed__eye;
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }
            else
            {
                isPassVisible2 = false;
                signIn__showPassicon.Image = Properties.Resources.open__eye;
                if (signinPASS__txtbox.Text != "Password")
                {
                    signinPASS__txtbox.UseSystemPasswordChar = true;
                }
            }
        }

        public static void setInputState(KryptonTextBox textBox, PictureBox tooltipLabel, Color color)
        {
            textBox.StateCommon.Border.Color1 = color;
            textBox.StateCommon.Content.Color1 = color;
            tooltipLabel.ForeColor = color;
        }
        private void back__btn_Click(object sender, EventArgs e)
        {
            Role__form r = new Role__form();

            r.Show();
            this.Hide();
        }


        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void back__btn_Click_1(object sender, EventArgs e)
        {
            Role__form r = new Role__form();
            r.Show();
            this.Hide();
        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
        {
            Form formbackground = new Form();

            using (TermsCons terms = new TermsCons())
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = CustomColor.mainColor;
                formbackground.Size = this.Size;

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                terms.Owner = formbackground;
                terms.ShowDialog();
            }
            formbackground.Dispose();

        }

        private void signIn__btn_Click(object sender, EventArgs e)
        {
            string username = signinEMAIL__txtbox.Text;
            string password = signinPASS__txtbox.Text;

            if (username == "Username" || password == "Password")
            {
                MessageBox.Show("Please make sure to fill out all required fields before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (username == "Username")
                {
                    signinEMAIL__txtbox.Focus();
                }
                else if (password == "Password")
                {
                    signinPASS__txtbox.Focus();
                }

                return;
            }

            string folderPath = "TeacherCredentials";
            string fullPath = Path.Combine(folderPath, username + ".txt");
            bool isExist = File.Exists(fullPath);

            if (isExist)
            {
                bool isValid = Account__Manager.AuthenticateTeacherLogIn(username, password, folderPath);
                if (isValid)
                {
                    MessageBox.Show("Sign in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); // Display message box here

                    this.Hide();

                    Teacher_Dashboard tdas = new Teacher_Dashboard(username);
                    tdas.Show();
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The teacher account you entered does not exist.\n\n" +
                    "Please check your username and password or sign up if you don't have an account yet.",
                    "Account Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void signIn__btn_MouseHover(object sender, EventArgs e)
        {
            signIn__btn.Image = Properties.Resources.Frame_101_hover;
        }

        private void teacherSIGNINform_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void signIn__btn_MouseLeave(object sender, EventArgs e)
        {
            signIn__btn.Image = Properties.Resources.Frame_101_ddefault;
        }

        private void signUp__btn_Click(object sender, EventArgs e)
        {

            string firstName = UserInput__Validator.trimInput(signupFNAME__txtbox.Text);
            string lastName = UserInput__Validator.trimInput(signupLNAME__txtbox.Text);
            string email = UserInput__Validator.trimInput(signupEMAIL__txtbox.Text);
            string username = UserInput__Validator.trimInput(signupUNAME__txtbox.Text);
            string password = UserInput__Validator.trimInput(signupPASS__txtbox.Text);
            string confirmPassword = UserInput__Validator.trimInput(signupCPASS__txtbox.Text);
            string school = UserInput__Validator.trimInput(signupSCHOOL__txtbox.Text);



            if (firstName == "First Name" || lastName == "Last Name" || email == "Email" || username == "Username" || password == "Password" || confirmPassword == "Confirm Password" || school == "School")
            {
                MessageBox.Show("Please make sure to fill out all required fields before proceeding.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Set focus to the first unfilled field
                if (firstName == "First Name")
                {
                    signupFNAME__txtbox.Focus();
                }
                else if (lastName == "Last Name")
                {
                    signupLNAME__txtbox.Focus();
                }
                else if (email == "Email")
                {
                    signupEMAIL__txtbox.Focus();
                }
                else if (username == "Username")
                {
                    signupUNAME__txtbox.Focus();
                }
                else if (password == "Password")
                {
                    signupPASS__txtbox.Focus();
                }
                else if (confirmPassword == "Confirm Password")
                {
                    signupCPASS__txtbox.Focus();
                }
                else if (confirmPassword == "Confirm Password")
                {
                    signupSCHOOL__txtbox.Focus();
                }

                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please enter matching passwords.", "Password Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                signupCPASS__txtbox.Focus();
                return;
            }

            Users newTeacher = new Teacher(firstName, lastName, email, username, password, school);


            Account__Manager.SaveUser(newTeacher);
            MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            teacherSIGNINform.Show();
            teacherSIGNUP__form.Hide();




            string sectionsFolderPath = "CourseInformations";
            if (!Directory.Exists(sectionsFolderPath))
            {
                Directory.CreateDirectory(sectionsFolderPath);
            }

            // Automatically create a text file for sections handled by this teacher
            string sectionFilePath = Path.Combine(sectionsFolderPath, $"{username}.txt");
            if (!File.Exists(sectionFilePath))
            {
                using (StreamWriter sectionWriter = File.CreateText(sectionFilePath))
                {

                }
            }


            string studentRecordsFolderPath = "StudentCredentials";
            if (!Directory.Exists(studentRecordsFolderPath))
            {
                Directory.CreateDirectory(studentRecordsFolderPath);
            }

        }

        private void signUp__btn_MouseHover(object sender, EventArgs e)
        {
            signUp__btn.Image = Properties.Resources.Frame_10hover;
        }

        private void signUp__btn_MouseLeave(object sender, EventArgs e)
        {
            signUp__btn.Image = Properties.Resources.Frame_10def;
        }

        private void signupSCHOOL__txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form formbackground = new Form();

            using (TermsCons terms = new TermsCons())
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = CustomColor.mainColor;
                formbackground.Size = this.Size;

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                terms.Owner = formbackground;
                terms.ShowDialog();
            }
            formbackground.Dispose();
        }
    }
}
