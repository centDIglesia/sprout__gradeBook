using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using sprout__gradeBook;

namespace sprout__gradeBook
{
    public partial class Student__Dashboard : KryptonForm
    {
        // Reference to the login form
        private readonly studentLoginForm _studentLoginForm;

        // Constructor to initialize the dashboard with a reference to the login form
        public Student__Dashboard(studentLoginForm studentLoginForm)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
        }

        // Method to set the student's username label
        public void SetUsernameLabel(string username)
        {
            student_Name.Text = $"Hi, {username}";
        }

        // Method to set the student's ID label
        public void SetStudentIDLabel(string studentID)
        {
            student_ID.Text = studentID;
        }

        // Method to set the student's icon based on their gender
        public void SetStudentIcon(string studentID)
        {
            if (studentID == "Male")
            {
                student_Icon.Image = Properties.Resources.Male_Icon;
            }
            else
            {
                student_Icon.Image = Properties.Resources.Female_Icon;
            }
        }

        // Event handler for the close button click event
        private void close_btn_Click(object sender, EventArgs e)
        {
            // Prompt the user with an exit confirmation dialog
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user clicks 'No', do nothing
            if (result == DialogResult.No)
            {
                return;
            }
            // If the user clicks 'Yes', exit the application
            else
            {
                Application.Exit();
            }
        }
    }
}

