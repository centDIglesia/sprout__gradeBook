using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class logInForm : KryptonForm
    {
        public logInForm()
        {
            InitializeComponent();
        }

        private void teacher__signUp_form_Load(object sender, EventArgs e)
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
            ResetInputField(signupFNAME__txtbox, "First Name");
            fname__tooltip.Show();
        }

        private void signupFNAME__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signupFNAME__txtbox, "First Name");
            ToggleTooltip(signupFNAME__txtbox, fname__tooltip, "First Name");
        }

        //last name
    
        private void signupLNAME__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signupLNAME__txtbox, "Last Name");
            lname__tooltip.Show();
        }

        private void signupLNAME__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signupLNAME__txtbox, "Last Name");
            ToggleTooltip(signupLNAME__txtbox, lname__tooltip, "Last Name");
        }


        //email
        private void signupEMAIL__txtbox_Leave(object sender, EventArgs e)
        {
            ResetInputField(signupEMAIL__txtbox, "Email");
            email__tooltip.Show();
        }

        private void signupEMAIL__txtbox_Enter(object sender, EventArgs e)
        {
            RestoreDefaultText(signupEMAIL__txtbox, "Email");
            ToggleTooltip(signupEMAIL__txtbox, email__tooltip, "Email");
        }

        //user name
        private void signupUNAME__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signupUNAME__txtbox, "Username");
            uname__tooltip.Show();
        }
        private void signupUNAME__txtbox_Leave(object sender, EventArgs e)
        {
            string folderPath = role__form.selectedRole == "student" ? "studentCredentials" : "teacherCredentials";

            RestoreDefaultText(signupUNAME__txtbox, "Username");
            ToggleTooltip(signupUNAME__txtbox, uname__tooltip, "Username");

            if (!string.IsNullOrWhiteSpace(signupUNAME__txtbox.Text) && signupUNAME__txtbox.Text != "Username")
            {
                bool usernameExists = AccountManager.UsernameExists(signupUNAME__txtbox.Text, folderPath);
                if (usernameExists)
                {
                    MessageBox.Show("Username already exists. Please choose a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    signupUNAME__txtbox.Focus();
                }
            }
        }


        //school
        private void signupSCHOOL__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signupSCHOOL__txtbox, "School");
            school__tooltip.Show();
        }

        private void signupSCHOOL__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signupSCHOOL__txtbox, "School");
            ToggleTooltip(signupSCHOOL__txtbox, school__tooltip, "School");
        }

        //password
        private void signupPASS__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signupPASS__txtbox, "Password");
            pass__tooltip.Show();
        }

        private void signupPASS__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signupPASS__txtbox, "Password");
            ToggleTooltip(signupPASS__txtbox, pass__tooltip, "Password");
        }

        //confirm password
        private void signupCPASS__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signupCPASS__txtbox, "Confirm Password");
            cpass__tooltip.Show();
        }

        private void signupCPASS__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signupCPASS__txtbox, "Confirm Password");
            ToggleTooltip(signupCPASS__txtbox, cpass__tooltip, "Confirm Password");
        }



        //hovering eefcts in forget password
        private void forgetPass__btn_MouseHover(object sender, EventArgs e)
        {
            forgetPass__btn.Image = Properties.Resources.Forgot_Your_Password_HOVER;
        }

        private void forgetPass__btn_MouseLeave(object sender, EventArgs e)
        {
            forgetPass__btn.Image = Properties.Resources.Forgot_Your_Password_;


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
            ResetInputField(signinEMAIL__txtbox, "Email");
           signIn__EmailTooltip.Show();
        }

        private void signInEmail__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signinEMAIL__txtbox, "Email");
            ToggleTooltip(signinEMAIL__txtbox, signIn__EmailTooltip, "Email");
        }

        //password
        private void signInPass__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signinPASS__txtbox, "Password");
            signIn__PassTooltip.Show();
            signinPASS__txtbox.UseSystemPasswordChar = true;
        }

        private void signInPass__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signinPASS__txtbox, "Password");
            ToggleTooltip(signinPASS__txtbox, signIn__EmailTooltip, "Password");

            if(signinPASS__txtbox.Text  == "Password")
            {
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }
           
        }

        //sign up show password icon fuction
        bool isPassVisible = false;

        private void showPass__icon_Click(object sender, EventArgs e)
        {


            if (!isPassVisible)
            {
                isPassVisible = true;
                showPass__icon.Image = Properties.Resources.closed__eye; 
                signupPASS__txtbox.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                isPassVisible = false;
                showPass__icon.Image = Properties.Resources.open__eye; // Assuming open__eye means the password is hidden
                signupPASS__txtbox.UseSystemPasswordChar = true; // Hide the password
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
                signinPASS__txtbox.UseSystemPasswordChar = true; 
            }
        }


        //placeholder 
        private void ResetInputField(KryptonTextBox textBox, string defaultText)
        {
            if (textBox.Text == defaultText)
            {
                textBox.Text = "";
                textBox.StateCommon.Content.Color1 = CustomColor.mainColor;
            }
        }

        private void RestoreDefaultText(KryptonTextBox textBox, string defaultText)
        {
            if (textBox.Text == "")
            {
                textBox.Text = defaultText;
                textBox.StateCommon.Content.Color1 = CustomColor.lightColor;
            }
        }

        //Tooltip
        private void ToggleTooltip(KryptonTextBox textBox, Label tooltip, string defaultText)
        {
            if (textBox.Text != defaultText)
            {
                tooltip.Show();
            }
            else
            {
                tooltip.Hide();
            }
        }




        private void signIn__btn_Click(object sender, EventArgs e)
        {

        }

        private void signUp__btn_Click(object sender, EventArgs e)
        {
            string firstName = signupFNAME__txtbox.Text;
            string lastName = signupLNAME__txtbox.Text;
            string email = signupEMAIL__txtbox.Text;
            string username = signupUNAME__txtbox.Text;
            string password = signupPASS__txtbox.Text;
            string confirmPassword = signupCPASS__txtbox.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Users user;

            if (role__form.selectedRole == "student")
            {
                user = new Student(firstName, lastName, email, username, password);
            }
            else if (role__form.selectedRole == "teacher")
            {
                user = new Teacher(firstName, lastName, email, username, password);
            }
            else
            {
                MessageBox.Show("Please select a role before signing up.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                AccountManager.SaveUser(user);
                MessageBox.Show("Sign up successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Optionally, clear the textboxes or redirect to another form
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
