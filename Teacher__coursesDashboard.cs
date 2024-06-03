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
        public string CurrentUser { get; private set; }

        public teacher__courses_lvl1(string currentUsername)
        {
            CurrentUser = currentUsername;
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

        public void hidebuttons()
        {
            addcourseBTN.Hide();
            deleteBTN.Hide();
        }

        public void populateCourses()
        {
            string folderPath = "CourseInformations";
            string filePath = Path.Combine(folderPath, $"{CurrentUser}.txt");

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
                    Courses courseControl = new Courses
                    {
                        SubjectName = courseDetails["Course Name"],
                        SubjectCode = courseDetails["Course Code"],
                        SubjectCourseSection = courseDetails["Student Course and Section"],
                        SubjectSchedule = courseDetails["Course Schedule"],
                        SubjectCount = courseDetails["Student Count"],
                        ParentForm = this // Set the reference to the parent form
                    };

                    Course__flowLayoutPanel.Controls.Add(courseControl);
                }
            }
        }

        public void LoadFormIntoPanel(Form form)
        {
            if (this.kryptonPanel1.Controls.Count > 0)
            {
                this.kryptonPanel1.Controls.RemoveAt(0);
            }

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.kryptonPanel1.Controls.Add(form);
            this.kryptonPanel1.Tag = form;
            form.Show();
        }

        public void hidePanel()
        {
            Course__flowLayoutPanel.Hide();
        }

        public void ShowPanel()
        {
            Course__flowLayoutPanel.Show();
        }

        private void addcourseBTN_Click(object sender, EventArgs e)
        {
            AddCourseForm adf = new AddCourseForm(CurrentUser, this);
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

        private void editCoursePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
