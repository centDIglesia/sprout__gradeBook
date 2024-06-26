using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class Role__form : CustomForm
    {
        private bool teacherClicked = false;
        private bool studentClicked = false;
        public static string selectedRole = "";

        public Role__form()
        {
            InitializeComponent();
            role__btn.Hide();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Role__form_KeyDown);
        }
        private void Role__form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                role__btn_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                teacher__role_Click(sender, e);
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                student__role_Click(sender, e);
                e.Handled = true;
            }
        }
        private void role__btn_Click(object sender, EventArgs e)
        {
            role__btn.Image = Properties.Resources.nekstBTNNMM;
            if (selectedRole == "student")
            {
                this.Hide();
                studentLoginForm stdForm = new studentLoginForm();
                stdForm.Show();
            }
            else if (selectedRole == "teacher")
            {
                this.Hide();
                logInForm SignUp_Form = new logInForm();
                SignUp_Form.Show();
            }
        }

        private void teacher__role_Click(object sender, EventArgs e)
        {
            role__btn.Show();
            if (!teacherClicked)
            {
                teacher__role.Image = Properties.Resources.TeacherRole_Clicked;
                teacherClicked = true;
                selectedRole = "teacher";

                if (studentClicked)
                {
                    student__role.Image = Properties.Resources.StudentRole_Common;
                    studentClicked = false;
                }
            }
        }

        private void student__role_Click(object sender, EventArgs e)
        {
            role__btn.Show();
            if (!studentClicked)
            {
                student__role.Image = Properties.Resources.StudentRole_Clicked;
                studentClicked = true;
                selectedRole = "student";

                if (teacherClicked)
                {
                    teacher__role.Image = Properties.Resources.TeacherRole_Common;
                    teacherClicked = false;
                }
            }
        }

        private void teacher__role_MouseHover(object sender, EventArgs e)
        {
            if (!teacherClicked)
                teacher__role.Image = Properties.Resources.TeacherRole_Hover;
        }

        private void student__role_MouseHover(object sender, EventArgs e)
        {
            if (!studentClicked)
                student__role.Image = Properties.Resources.StudentRole_Hover;
        }

        private void teacher__role_MouseLeave(object sender, EventArgs e)
        {
            if (teacherClicked)
                teacher__role.Image = Properties.Resources.TeacherRole_Clicked;
                
            else
                teacher__role.Image = Properties.Resources.TeacherRole_Common;
        }

        private void student__role_MouseLeave(object sender, EventArgs e)
        {
            if (studentClicked)
                student__role.Image = Properties.Resources.StudentRole_Clicked;
            else
                student__role.Image = Properties.Resources.StudentRole_Common;
        }

        private void role__btn_MouseHover(object sender, EventArgs e)
        {
            role__btn.Image = Properties.Resources.nekstBTN;
        }

        private void role__btn_MouseLeave(object sender, EventArgs e)
        {
            role__btn.Image = Properties.Resources.nekstBTNN;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            utilityButton ui = new utilityButton();

            ui.Exitform();

        }
    }
}
