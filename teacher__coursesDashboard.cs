using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class teacher__courses_lvl1 : KryptonForm
    {
        public static teacher__courses_lvl1 lvl1Instance;
        private string currentUser;

        public teacher__courses_lvl1(string currentUsername)
        {
            currentUser = currentUsername;
            InitializeComponent();
            lvl1Instance = this;
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


        private void teacher__courses_lvl1_Load(object sender, EventArgs e)
        {
            populateCourses();
            RefreshTooltip.Hide();
        }

        private void kryptonMaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        public void populateCourses()
        {
            string folderPath = "CourseInformations";
            string filePath = Path.Combine(folderPath, $"{currentUser}.txt");

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Course information directory not found.");
                return;
            }

            string[] fileContents = File.ReadAllText(filePath)
                .Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

            Course__flowLayoutPanel.Controls.Clear();

            foreach (string courseData in fileContents)
            {
                string[] lines = courseData.Trim().Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                Dictionary<string, string> courseDetails = new Dictionary<string, string>();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new char[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        courseDetails[parts[0].Trim()] = parts[1].Trim();
                    }
                }


                if (courseDetails.ContainsKey("Course Name") &&
                    courseDetails.ContainsKey("Course Code") &&
                    courseDetails.ContainsKey("Student Course and Section") &&
                    courseDetails.ContainsKey("Course Schedule") &&
                    courseDetails.ContainsKey("Student Count"))
                {
                    Courses courseControl = new Courses();
                    courseControl.SubjectName = courseDetails["Course Name"];
                    courseControl.SubjectCode = courseDetails["Course Code"];
                    courseControl.SubjectCourseSection = courseDetails["Student Course and Section"];
                    courseControl.SubjectSchedule = courseDetails["Course Schedule"];
                    courseControl.SubjectCount = courseDetails["Student Count"];

                    Course__flowLayoutPanel.Controls.Add(courseControl);
                }
            }
        }


        private void courses1_Load(object sender, EventArgs e)
        {

        }

        private void addcourseBTN_Click(object sender, EventArgs e)
        {

            AddCourseForm adf = new AddCourseForm(currentUser, this);
            adf.Show();

            this.Enabled = false;


        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshBTN_Click(object sender, EventArgs e)
        {
            populateCourses();
        }

        private void RefreshTooltip_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RefreshTooltip_MouseHover(object sender, EventArgs e)
        {

        }

        private void RefreshTooltip_MouseLeave(object sender, EventArgs e)
        {

        }

        private void refreshBTN_MouseHover(object sender, EventArgs e)
        {
            RefreshTooltip.Show();
        }

        private void refreshBTN_MouseLeave(object sender, EventArgs e)
        {
            RefreshTooltip.Hide();
        }
    }
}
