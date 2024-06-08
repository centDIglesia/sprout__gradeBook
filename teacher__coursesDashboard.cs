using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
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

            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, $"{CurrentUser}.txt");

                foreach (string filePath in filePaths)
                {
                    string fileContent = File.ReadAllText(filePath);
                    string[] courseBlocks = fileContent.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string block in courseBlocks)
                    {
                        string[] lines = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        string courseName = "";
                        string courseCode = "";
                        string department = "";
                        string section = "";
                        string schedule = "";
                        int studentCount = 0;

                        foreach (var line in lines)
                        {
                            if (line.StartsWith("Course Name:"))
                            {
                                courseName = line.Substring("Course Name:".Length).Trim();
                            }
                            else if (line.StartsWith("Course Code:"))
                            {
                                courseCode = line.Substring("Course Code:".Length).Trim();
                            }
                            else if (line.StartsWith("Student Department:"))
                            {
                                department = line.Substring("Student Department:".Length).Trim();
                            }
                            else if (line.StartsWith("Student year and section:"))
                            {
                                section = line.Substring("Student year and section:".Length).Trim();
                            }
                            else if (line.StartsWith("Course Schedule:"))
                            {
                                schedule = line.Substring("Course Schedule:".Length).Trim();
                            }
                            else if (line.StartsWith("Student Count:"))
                            {
                                studentCount = int.Parse(line.Substring("Student Count:".Length).Trim());
                            }
                        }

                        if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(courseCode) &&
                            !string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                        {
                            CoursesCARD card = new CoursesCARD()
                            {
                                SubjectName = courseName,
                                SubjectCode = courseCode,
                                SubjectCount = studentCount.ToString(),
                                SubjectSchedule = schedule,
                                SubjectCourseSection = section
                            };

                            courseSectionPanel.Controls.Add(card);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show($"Directory not found: {folderPath}");
            }
        }


        public void LoadFormIntoPanel(Form form)
        {
            courseSectionPanel.Controls.Clear();

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            courseSectionPanel.Controls.Add(form);
            form.Show();
        }

        public void hidePanel()
        {
            courseSectionPanel.Hide();
        }

        public void ShowPanel()
        {
            courseSectionPanel.Show();
        }

        private void addcourseBTN_Click(object sender, EventArgs e)
        {
            AddCourseForm adf = new AddCourseForm(CurrentUser, this);
            adf.Show();
            Enabled = false;
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshBTN_Click_1(object sender, EventArgs e)
        {
            populateCourses();
        }
    }
}
