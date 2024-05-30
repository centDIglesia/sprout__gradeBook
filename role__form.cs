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
    public partial class role__form : KryptonForm
    {
        public role__form()
        {
            InitializeComponent();
        }

        bool teacherClicked = false;//true
        bool studentClicked = false;
        public static string selectedRole = "";

        private void teacher__role_Click(object sender, EventArgs e)
        {
            role__btn.Show();
            if (!teacherClicked)
            {
                teacher__role.Image = Properties.Resources.teacher__role_clicked;
                teacherClicked = true;
                selectedRole = "teacher";

                // Reset student button if it was clicked
                if (studentClicked)
                {
                    student__role.Image = Properties.Resources.student__role;
                    studentClicked = false;
                }
            }
        }

        private void student__role_Click(object sender, EventArgs e)
        {
            role__btn.Show();
            if (!studentClicked)
            {
                student__role.Image = Properties.Resources.student__role_clicked;
                studentClicked = true;
                selectedRole = "student";

                // Reset teacher button if it was clicked
                if (teacherClicked)
                {
                    teacher__role.Image = Properties.Resources.teacher__role;
                    teacherClicked = false;
                }
            }
        }

        private void role__btn_Click(object sender, EventArgs e)
        {


            if (selectedRole == "student")
            {
                this.Hide();
                studentLoginForm stdForm = new studentLoginForm();
                stdForm.Show();
            }

            if (selectedRole == "teacher")
            {
                this.Hide();
                logInForm SignUp_Form = new logInForm();
                SignUp_Form.Show();
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

        private void back__btn_Click(object sender, EventArgs e)
        {

        }

        private void role__form_Load(object sender, EventArgs e)
        {
            role__btn.Hide();
        }

        private void teacher__role_MouseHover(object sender, EventArgs e)
        {
            teacher__role.Image = Properties.Resources.Roles_Card_hover;
        }

        private void student__role_MouseHover(object sender, EventArgs e)
        {
            student__role.Image = Properties.Resources.Roles_Card_student_hover;
        }

        private void teacher__role_MouseLeave(object sender, EventArgs e)
        {
            if (teacherClicked)
            {
                teacher__role.Image = Properties.Resources.teacher__role_clicked;
            }
            else
            {
                teacher__role.Image = Properties.Resources.teacher__role;
            }
        }

        private void student__role_MouseLeave(object sender, EventArgs e)
        {
            if (studentClicked)
            {
                student__role.Image = Properties.Resources.student__role_clicked;
            }
            else
            {
                student__role.Image = Properties.Resources.student__role;
            }
        }
    }
}
