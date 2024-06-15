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
           utilityButton b = new utilityButton();
            b.Exitform();
        }
        private void notifCount_Click(object sender, EventArgs e)
        {
            Form formbackgroud = new Form();

            using (students__NoticationUi students__NoticationFORM = new students__NoticationUi(_studentLoginForm, _studentLoginForm.currentStudentID, currentstudentDepartment))
            {
                formbackgroud.StartPosition = FormStartPosition.Manual;
                formbackgroud.FormBorderStyle = FormBorderStyle.None;
                formbackgroud.Opacity = .70d;
                formbackgroud.BackColor = Color.Black;
                formbackgroud.Size = this.Size;
                formbackgroud.Location = this.Location;
                formbackgroud.ShowInTaskbar = false;
                formbackgroud.Show();

                students__NoticationFORM.Owner = formbackgroud;
                students__NoticationFORM.ShowDialog();
            } 
            formbackgroud.Dispose();
           
        }




        private void Student__Dashboard_Load(object sender, EventArgs e)
        {
            kryptonTextBox1.Text = notifCount.ToString();
            kryptonTextBox1.Hide();
            if (notifCount > 0)
            {
                kryptonTextBox1.Show();

            }
        }

        private void GetNotificationCount()
        {
            List<string> teachers = _studentLoginForm.GetTeachersForStudent();

            foreach (string teacher in teachers)
            {
                string teacherAnnouncementFile = $"CourseAnnouncement/{teacher}/Anouncement.txt";

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

        private void feedback_btn_Click(object sender, EventArgs e)
        {
            Student__FeedbackUI feedbackUI = new Student__FeedbackUI(_studentLoginForm, _studentLoginForm.currentStudentID);
            feedbackUI.Show();
        }

    }
}
