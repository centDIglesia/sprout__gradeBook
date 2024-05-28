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
    public partial class SSSSSSS : KryptonForm
    {
        public SSSSSSS()
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


        private void teacherFNAME__txtbox_Enter_1(object sender, EventArgs e)
        {
            ResetInputField(teacherFNAME__txtbox, "First Name");
            fname__tooltip.Show();
        }

        private void teacherFNAME__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherFNAME__txtbox, "First Name");
            ToggleTooltip(teacherFNAME__txtbox,fname__tooltip, "First Name");
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

        private void teacherLNAME__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(teacherLNAME__txtbox, "Last Name");
            lname__tooltip.Show();
        }

        private void teacherLNAME__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherLNAME__txtbox, "Last Name");
            ToggleTooltip(teacherLNAME__txtbox,lname__tooltip, "Last Name");
        }

        private void teacherEMAIL__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(teacherEMAIL__txtbox, "Email");
            email__tooltip.Show();
        }
        private void teacherEMAIL__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherEMAIL__txtbox, "Email");
            ToggleTooltip(teacherEMAIL__txtbox, email__tooltip, "Email");
        }

        private void teacherUNAME__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(teacherUNAME__txtbox, "Username");
            uname__tooltip.Show();
        }

        private void teacherUNAME__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherUNAME__txtbox, "Username");
            ToggleTooltip(teacherUNAME__txtbox, uname__tooltip, "Username");
        }

        private void teacherSCHOOL__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(teacherSCHOOL__txtbox, "School");
            school__tooltip.Show();
        }

        private void teacherSCHOOL__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherSCHOOL__txtbox, "School");
            ToggleTooltip(teacherSCHOOL__txtbox,school__tooltip, "School");
        }

        private void teacherPASS__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(teacherPASS__txtbox, "Password");
            pass__tooltip.Show();

            teacherPASS__txtbox.UseSystemPasswordChar = true;
        }

        private void teacherPASS__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherPASS__txtbox, "Password");
            ToggleTooltip(teacherPASS__txtbox, pass__tooltip, "Password");

            if(teacherPASS__txtbox.Text == "Password")
            {
                teacherPASS__txtbox.UseSystemPasswordChar = false;
            }
        }

        private void teacherCPASS__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(teacherCPASS__txtbox, "Confirm Password");
            cpass__tooltip.Show();
            teacherCPASS__txtbox.UseSystemPasswordChar = true;
        }

        private void teacherCPASS__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(teacherCPASS__txtbox, "Confirm Password");
            ToggleTooltip(teacherCPASS__txtbox, cpass__tooltip, "Confirm Password");

            if (teacherCPASS__txtbox.Text == "Confirm Password")
            {
                teacherCPASS__txtbox.UseSystemPasswordChar = false;
            }
        }

        private void kryptonGroup1_Panel_Paint(object sender, PaintEventArgs e)
        {

        }

        bool isPassVisible = false;

        private void showPass__icon_Click(object sender, EventArgs e)
        {
   

            if (!isPassVisible)
            {
                isPassVisible = true;
                showPass__icon.Image = Properties.Resources.closed__eye; // Assuming closed__eye means the password is visible
                teacherPASS__txtbox.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                isPassVisible = false;
                showPass__icon.Image = Properties.Resources.open__eye; // Assuming open__eye means the password is hidden
                teacherPASS__txtbox.UseSystemPasswordChar = true; // Hide the password
            }
        }

        private void forgetPass__btn_MouseHover(object sender, EventArgs e)
        {
            forgetPass__btn.Image = Properties.Resources.Forgot_Your_Password_HOVER;
        }

        private void forgetPass__btn_MouseLeave(object sender, EventArgs e)
        {
            forgetPass__btn.Image = Properties.Resources.Forgot_Your_Password_;


        }

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

        private void signInEmail__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signInEmail__txtbox, "Email");
           signIn__EmailTooltip.Show();
        }

        private void signInEmail__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signInEmail__txtbox, "Email");
            ToggleTooltip(signInEmail__txtbox, signIn__EmailTooltip, "Email");
        }

        private void signInPass__txtbox_Enter(object sender, EventArgs e)
        {
            ResetInputField(signInPass__txtbox, "Password");
            signIn__PassTooltip.Show();
            signInPass__txtbox.UseSystemPasswordChar = true;
        }

        private void signInPass__txtbox_Leave(object sender, EventArgs e)
        {
            RestoreDefaultText(signInPass__txtbox, "Password");
            ToggleTooltip(signInPass__txtbox, signIn__EmailTooltip, "Password");

            if(signInPass__txtbox.Text  == "Password")
            {
                signInPass__txtbox.UseSystemPasswordChar = false;
            }
           
        }
        bool isPassVisible2 = false;
        private void signIn__showPassicon_Click(object sender, EventArgs e)
        {
            if (!isPassVisible2)
            {
                isPassVisible2 = true;
                signIn__showPassicon.Image = Properties.Resources.closed__eye; // Assuming closed__eye means the password is visible
                signInPass__txtbox.UseSystemPasswordChar = false; // Show the password
            }
            else
            {
                isPassVisible2 = false;
                signIn__showPassicon.Image = Properties.Resources.open__eye; // Assuming open__eye means the password is hidden
                signInPass__txtbox.UseSystemPasswordChar = true; // Hide the password
            }
        }
    }
}
