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
    public partial class Student__Dashboard : KryptonForm
    {

        private readonly string currentstudentDepartment;
        private readonly studentLoginForm _studentLoginForm;
        private int notifCount = 0;


        public Student__Dashboard(studentLoginForm studentLoginForm)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            currentstudentDepartment = studentLoginForm.GetCurrentStudentDepartmentYearSection();
            GetNotificationCount(); // Call method to initialize notifCount
        }


        public void SetUsernameLabel(string username)
        {
            student_Name.Text = $"Hi, {username}";
        }


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
        private void notifCount_Click(object sender, EventArgs e)
        {
            students__NoticationUi students__NoticationFORM = new students__NoticationUi(_studentLoginForm, _studentLoginForm.currentStudentID, currentstudentDepartment);
            students__NoticationFORM.Show();
        }

        private void Student__Dashboard_Load(object sender, EventArgs e)
        {
            notificationCount.Text = notifCount.ToString();
            notificationCount.Hide();
            notificationBg.Hide();


            if (notifCount > 0)
            {
                notificationCount.Show();
                notificationCount.Show();
            }
        }

        private void GetNotificationCount()
        {
            List<string> teachers = _studentLoginForm.GetTeachersForStudent();

            foreach (string teacher in teachers)
            {
                string teacherAnnouncementFile = $"CourseAnnoucement/{teacher}/Anouncement.txt";

                if (File.Exists(teacherAnnouncementFile))
                {
                    var announcementLines = File.ReadAllLines(teacherAnnouncementFile);
                    var announcements = string.Join("\n", announcementLines)
                        .Split(new[] { "------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var announcement in announcements)
                    {
                        var lines = announcement.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        var announcementDict = new Dictionary<string, string>();

                        foreach (var line in lines)
                        {
                            var parts = line.Split(new[] { ':' }, 2);
                            if (parts.Length == 2)
                            {
                                announcementDict[parts[0].Trim()] = parts[1].Trim();
                            }
                        }

                        if (announcementDict.TryGetValue("Receiver", out var receiver) &&
                            receiver.Equals(currentstudentDepartment, StringComparison.OrdinalIgnoreCase))
                        {
                            notifCount++;
                        }
                    }
                }

            }
        }
    }
}
