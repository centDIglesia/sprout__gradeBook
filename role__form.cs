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
    public partial class Role__form : KryptonForm
    {
        // Fields to track role selection and selected role
        private bool teacherClicked = false;
        private bool studentClicked = false;
        public static string selectedRole = "";

        public Role__form()
        {
            InitializeComponent();
            this.AcceptButton = role__btn;
        }

        // Event handler for teacher role button click
        private void teacher__role_Click(object sender, EventArgs e)
        {
            role__btn.Show();
            if (!teacherClicked)
            {
                // Change button appearance
                teacher__role.Image = Properties.Resources.Roles_Card_hover;
                teacherClicked = true;
                selectedRole = "teacher";

                // Reset student button if clicked
                if (studentClicked)
                {
                    student__role.Image = Properties.Resources.student__role;
                    studentClicked = false;
                }
            }
        }

        // Event handler for student role button click
        private void student__role_Click(object sender, EventArgs e)
        {
            role__btn.Show();
            if (!studentClicked)
            {
                // Change button appearance
                student__role.Image = Properties.Resources.Roles_Card_student_hover;
                studentClicked = true;
                selectedRole = "student";

                // Reset teacher button if clicked
                if (teacherClicked)
                {
                    teacher__role.Image = Properties.Resources.teacher__role;
                    teacherClicked = false;
                }
            }
        }

        // Event handler for role button click
        private void role__btn_Click(object sender, EventArgs e)
        {
            // Show appropriate login form based on selected role
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

        // Event handler for form load
        private void role__form_Load(object sender, EventArgs e)
        {
            // Hide role button initially
            role__btn.Hide();
        }

        // Event handler for close button click
        private void close_btn_Click(object sender, EventArgs e)
        {
            // Close the form using utility method
            utilityButton b = new utilityButton();
            b.Exitform();
        }

        // Event handler for teacher role mouse hover
        private void teacher__role_MouseHover(object sender, EventArgs e)
        {
            // Change image on hover
            teacher__role.Image = Properties.Resources.teacher__role_clicked;
        }

        // Event handler for student role mouse hover
        private void student__role_MouseHover(object sender, EventArgs e)
        {
            // Change image on hover
            student__role.Image = Properties.Resources.student__role_clicked;
        }

        // Event handler for teacher role mouse leave
        private void teacher__role_MouseLeave(object sender, EventArgs e)
        {
            // Restore image on leave
            if (teacherClicked)
                teacher__role.Image = Properties.Resources.Roles_Card_hover;
            else
                teacher__role.Image = Properties.Resources.teacher__role;
        }

        // Event handler for student role mouse leave
        private void student__role_MouseLeave(object sender, EventArgs e)
        {
            // Restore image on leave
            if (studentClicked)
                student__role.Image = Properties.Resources.Roles_Card_student_hover;
            else
                student__role.Image = Properties.Resources.student__role;
        }
    }
}
