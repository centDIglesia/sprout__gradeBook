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
        }

        private void kryptonMaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void populateCourses()
        {
            string folderPath = "CourseInformations";
            string filePath = Path.Combine(folderPath, $"{currentUser}.txt");



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
            AddCourseForm adf = new AddCourseForm(currentUser);
            adf.Show();
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
