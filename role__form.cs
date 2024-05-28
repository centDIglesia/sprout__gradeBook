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

        bool teacherClicked = false;
        bool studentClicked = false;
        public static string selectedRole = "";

        private void teacher__role_Click(object sender, EventArgs e)
        {
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

            if (selectedRole != "")
            {
               
                    this.Hide();
                    logInForm SignUp_Form = new logInForm();
                    SignUp_Form.Show();


            }
            else MessageBox.Show("Please choose a role before proceeding.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
