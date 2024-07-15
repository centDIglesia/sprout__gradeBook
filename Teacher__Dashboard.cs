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
    public partial class Teacher_Dashboard : CustomForm
    {
        private readonly string currentUser; // Store current user's username
        private static readonly string[] qoutations = new[]
       {
            ".",
            "Don't stop until you are proud.",
            "As long as you do what needs to be done, the result will always come your way.",
            "Work in silent, let your success be the noise.",
            "Donut worry, be happy.",
            "Bad days, build better days.",
            "When nothing goes right, go left.",
            "Dear stress, let's break up.",
            "Hey warrior! keep going. .",
            "Live in the moment."
        };

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

        // Event handler for close button
        private void close_btn_Click(object sender, EventArgs e)
        {
            // Create utility button instance and call exit method
            utilityButton b = new utilityButton();
            b.Exitform();
        }

        private bool isDashboardButtonClicked = false;
        private bool isGradebookButtonClicked = false;
        private bool isStudentsButtonClicked = false;
        private bool isCourseButtonClicked = false;
        private bool isAttendanceButtonClicked = false;

        private void btn_dashboard_MouseHover(object sender, EventArgs e)
        {
            if (!isDashboardButtonClicked)
            {
                // btn_dashboard.Image = Properties.Resources.Frame_83;
            }
        }

        private void btn_dashboard_MouseLeave(object sender, EventArgs e)
        {
            if (!isDashboardButtonClicked)
            {
                // btn_dashboard.Image = Properties.Resources.Frame_87;
            }
        }



        private void btn_attendance_feedback_Click(object sender, EventArgs e)
        {
            ResetButtonStates();
            btn_attendance.Image = Properties.Resources.Frame_93;

            isAttendanceButtonClicked = true;
        }


        // Event handler for close button


        private void ResetButtonStates()
        {

            isDashboardButtonClicked = false;
            isGradebookButtonClicked = false;
            isStudentsButtonClicked = false;
            isCourseButtonClicked = false;
            isAttendanceButtonClicked = false;


            btn_dashboard.Image = Properties.Resources.Frame_87;
            btn_students.Image = Properties.Resources.Frame_89;
            btn_courses.Image = Properties.Resources.Frame_86;
            btn_gradeBook.Image = Properties.Resources.Frame_90;
            btn_attendance.Image = Properties.Resources.Frame_88;

        }

        /*
        private void btn_students_MouseHover(object sender, EventArgs e)
        {
            if (!isStudentsButtonClicked)
            {
                //  btn_students.Image = Properties.Resources.Frame_85;
            }

        }

        private void btn_students_MouseLeave(object sender, EventArgs e)
        {
            if (!isStudentsButtonClicked)
            {// btn_students.Image = Properties.Resources.Frame_89; 
            }
        }

        private void btn_courses_MouseHover(object sender, EventArgs e)
        {
            if (!isCourseButtonClicked)
            {// btn_courses.Image = Properties.Resources.Frame_80;
            }
        }

        private void btn_courses_MouseLeave(object sender, EventArgs e)
        {
            if (!isCourseButtonClicked)
            { //btn_courses.Image = Properties.Resources.Frame_86; 
            }
        }

        private void btn_gradeBook_MouseHover(object sender, EventArgs e)
        {
            if (!isGradebookButtonClicked)
            { //btn_gradeBook.Image = Properties.Resources.Frame_84;
            }
        }

        private void btn_gradeBook_MouseLeave(object sender, EventArgs e)
        {
            if (!isGradebookButtonClicked)
            {// btn_gradeBook.Image = Properties.Resources.Frame_90;
            }
        }

      

        
        */
        private void logoutBtn_Click(object sender, EventArgs e)
        {
            utilityButton ut = new utilityButton();
            if ( ut.ConfirmLogout() == true)
            {
                this.Close();
                Role__form role__Form = new Role__form();
                role__Form.Show();
            }  

        }

        private void logoutBtn_MouseLeave(object sender, EventArgs e)
        {
            logoutBtn.Image = Properties.Resources.llogut;
        }

        private void logoutBtn_MouseHover_1(object sender, EventArgs e)
        {
            logoutBtn.Image = Properties.Resources.logutt;
        }


        private void btn_courses_Click(object sender, EventArgs e)
        {
            if (Directory.Exists($"StudentCredentials/{currentUser}/DepartmentandSections/"))
            {
                ResetButtonStates();
                loadForm(new teacher__courses_lvl1(currentUser));
                btn_courses.Image = Properties.Resources.Frame_91;
                isCourseButtonClicked = true;
            }
            else
            {
                MessageBox.Show("Before proceeding, please ensure at least one student has been added. Thank you for your understanding!", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btn_attendance_Click_1(object sender, EventArgs e)
        {

            if (Directory.Exists($"CourseInformations/{currentUser}/"))
            {
                ResetButtonStates();

                loadForm(new Teacher__Attendance(currentUser));
                btn_attendance.Image = Properties.Resources.Frame_93;
                isAttendanceButtonClicked = true;
            }
            else
            {
                MessageBox.Show(
      "Please ensure you have added the course details and set up the grading system before proceeding.\n\n To add a course, navigate to the 'Courses' section and click on 'Add New Course'.\n\n Then, click on the course and add a 'Grading System' by selecting the 'Grading System' button and setting up the required components.",
      "Incomplete Setup",
      MessageBoxButtons.OK,
      MessageBoxIcon.Warning);
            }
        }

        private void btn_students_Click(object sender, EventArgs e)
        {
            ResetButtonStates();
            loadForm(new teacher__studentsDashboard(currentUser));
            btn_students.Image = Properties.Resources.Frame_94;
            isStudentsButtonClicked = true;
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            ResetButtonStates();
            loadForm(new teacher__mainDashboard(currentUser));
            btn_dashboard.Image = Properties.Resources.Frame_92;
            isDashboardButtonClicked = true;
        }

        private void btn_gradeBook_Click(object sender, EventArgs e)
        {

            if (Directory.Exists($"CourseInformations/{currentUser}/"))
            {
                ResetButtonStates();
                loadForm(new teacher__GradeBook(currentUser));
                btn_gradeBook.Image = Properties.Resources.Frame_95;
                isGradebookButtonClicked = true;
            }
            else
            {
                MessageBox.Show(
      "Please ensure you have added the course details and set up the grading system before proceeding.\n\n To add a course, navigate to the 'Courses' section and click on 'Add New Course'.\n\n Then, click on the course and add a 'Grading System' by selecting the 'Grading System' button and setting up the required components.",
      "Incomplete Setup",
      MessageBoxButtons.OK,
      MessageBoxIcon.Warning);
            }

        }

        private void btn_courses_MouseHover_1(object sender, EventArgs e)
        {
            if (!isCourseButtonClicked)
            {
                btn_courses.Image = Properties.Resources.Frame_80;
            }
        }

        private void btn_courses_MouseLeave_1(object sender, EventArgs e)
        {
            if (!isCourseButtonClicked)
            {
                btn_courses.Image = Properties.Resources.Frame_86;
            }
        }

        private void btn_attendance_MouseHover(object sender, EventArgs e)
        {

            if (!isAttendanceButtonClicked)
            {
                btn_attendance.Image = Properties.Resources.Frame_81;
            }
        }

        private void btn_attendance_MouseLeave(object sender, EventArgs e)
        {
            if (!isAttendanceButtonClicked)
            {
                btn_attendance.Image = Properties.Resources.Frame_88;
            }
        }

        private void btn_gradeBook_MouseHover(object sender, EventArgs e)
        {
            if (!isGradebookButtonClicked)
            {
                btn_gradeBook.Image = Properties.Resources.Frame_84;
            }
        }

        private void btn_gradeBook_MouseLeave(object sender, EventArgs e)
        {
            if (!isGradebookButtonClicked)
            {
                btn_gradeBook.Image = Properties.Resources.Frame_90;
            }
        }

        private void btn_students_MouseHover(object sender, EventArgs e)
        {
            if (!isStudentsButtonClicked)
            {
                btn_students.Image = Properties.Resources.Frame_85;
            }
        }

        private void btn_students_MouseLeave(object sender, EventArgs e)
        {
            if (!isStudentsButtonClicked)
            {
                btn_students.Image = Properties.Resources.Frame_89;
            }
        }

        private void btn_dashboard_MouseHover_1(object sender, EventArgs e)
        {
            if (!isDashboardButtonClicked)
            {
                btn_dashboard.Image = Properties.Resources.Frame_83;
            }
        }

        private void btn_dashboard_MouseLeave_1(object sender, EventArgs e)
        {
            if (!isDashboardButtonClicked)
            {
                btn_dashboard.Image = Properties.Resources.Frame_87;
            }
        }

        private void close_btn_Click_1(object sender, EventArgs e)
        {
            utilityButton uti = new utilityButton();
            uti.Exitform();
        }

        private void Teacher_Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void notification__icon_Click(object sender, EventArgs e)
        {
            ShowRandomAffirmation();
        }

        private void ShowRandomAffirmation()
        {
            Random rand = new Random();
            int index = rand.Next(qoutations.Length);
            string randomQoutes = qoutations[index];
            MessageBox.Show(randomQoutes, "Daily Quotes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
