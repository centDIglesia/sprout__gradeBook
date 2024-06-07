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
namespace sprout__gradeBook
{
    public partial class studentLoginForm : KryptonForm
    {
        
        public studentLoginForm()
        {
            InitializeComponent();
        }

        private void studentLoginForm_Load(object sender, EventArgs e)
        {
            signIn__StIdTooltip.Hide();
            signIn__PassTooltip.Hide();            
        }

        private void signinSTID__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signinSTID__txtbox, "Student Number");
            signIn__StIdTooltip.Show();
        }

        private void signinSTID__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signinSTID__txtbox, "Student Number");
            UserInput_Manager.ToggleTooltip(signinSTID__txtbox, signIn__StIdTooltip, "Student Number");
        }

        private void signinPASS__txtbox_Enter(object sender, EventArgs e)
        {
            signinPASS__txtbox.UseSystemPasswordChar = true;
            UserInput_Manager.ResetInputField(signinPASS__txtbox, "Password");
            signIn__PassTooltip.Show();
        }

        private void signinPASS__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signinPASS__txtbox, "Password");
            UserInput_Manager.ToggleTooltip(signinPASS__txtbox, signIn__PassTooltip, "Password");

            if (signinPASS__txtbox.Text == "Password")
            {
                signinPASS__txtbox.UseSystemPasswordChar = false;

            }
        }
        bool isPassVisible3 = false;
        private void signIn__showPassicon_Click(object sender, EventArgs e)
        {


            if (!isPassVisible3)
            {
                isPassVisible3 = true;
                signIn__showPassicon.Image = Properties.Resources.closed__eye;
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }
            else
            {
                isPassVisible3 = false;
                signIn__showPassicon.Image = Properties.Resources.open__eye;
                signinPASS__txtbox.UseSystemPasswordChar = true;
            }

        }

        private void showGuide_Click(object sender, EventArgs e)
        {
            StudentDefultPasswordGuide studentDefultPasswordGuide = new StudentDefultPasswordGuide();
            studentDefultPasswordGuide.ShowDialog();


        }

        private void signIn__btn_Click(object sender, EventArgs e)
        {
            string usernameOrId = signinSTID__txtbox.Text;
            string password = signinPASS__txtbox.Text;


            if (usernameOrId == "Student Number" || password == "Password")
            {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (usernameOrId == "Student Number")
                {
                    signinSTID__txtbox.Focus();
                }
                else if (password == "Password")
                {
                    signinPASS__txtbox.Focus();
                }

                return;

            }




            string folderPath = "studentCredentials";
            string fullPath = Path.Combine(folderPath, usernameOrId + ".txt");
            bool isExist = File.Exists(fullPath);



            if (isExist)
            {
                bool isValid = Account__Manager.AuthenticateStudentLogIn(usernameOrId, password, folderPath);

                if (isValid)
                {
                    this.Hide();
                    Student__Dashboard STD_DSH = new Student__Dashboard(usernameOrId);
                    STD_DSH.Show();

                    MessageBox.Show("Sign in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The student account you entered does not exist.\n" +
                                "Please check your username or ID and try again. \n\n" +
                                "If you do not have an account, please contact your teacher for assistance.",
                                "Account Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }




        private void close_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.No)
            {
                return;
            }
            else Application.Exit();
        }

        private void studentSIGNINform_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

