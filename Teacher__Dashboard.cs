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
using System.IO;

namespace sprout__gradeBook
{
    public partial class Teacher_Dashboard : KryptonForm
    {
        private readonly string currentUser; // Store current user's username

        // Constructor to initialize the dashboard
        public Teacher_Dashboard(string currentUserName)
        {
            InitializeComponent();
            currentUser = currentUserName;

            // Display greeting with the teacher's first name
            teachers__firstName.Text = $"Hi, {Account__Manager.LoadUserData("teacherCredentials", currentUserName, "First Name")}";
        }

        // Method to load a form into the dashboard view panel
        public void loadForm(Form form)
        {
            // Remove any existing controls in the view panel
            if (this.viewPanel.Controls.Count > 0)
                this.viewPanel.Controls.RemoveAt(0);

            // Configure the form to be displayed
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.viewPanel.Controls.Add(form);
            this.viewPanel.Tag = form;
            form.Show();
        }

        // Event handler for dashboard button
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__mainDashboard(currentUser));
        }

        // Event handler for courses button
        private void btn_courses_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__courses_lvl1(currentUser));
        }

        // Event handler for students button
        private void btn_students_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__studentsDashboard(currentUser));
        }

        // Event handler for grade book button
        private void btn_gradeBook_Click(object sender, EventArgs e)
        {
            // Construct path to the grading system directory for the current user
            string gradingSystemDirectoryPath = $"CourseGradingSystem/{currentUser}";

            loadForm(new teacher__GradeBook(currentUser));
        }
        private void btn_attendance_Click(object sender, EventArgs e)
        {
            loadForm(new Teacher__Attendance(currentUser));
        }
        // Event handler for close button
        private void close_btn_Click(object sender, EventArgs e)
        {
            // Create utility button instance and call exit method
            utilityButton b = new utilityButton();
            b.Exitform();
        }


    }
}
