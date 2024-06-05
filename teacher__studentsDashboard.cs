using System;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class teacher__studentsDashboard : KryptonForm
    {
        public string currentUSer { get; set; }

        public teacher__studentsDashboard(string currentuser)
        {
            InitializeComponent();
            currentUSer = currentuser;
        }

        private void teacher__studentsDashboard_Load(object sender, EventArgs e)
        {
            LoadStudentCourses();
        }

        private void LoadStudentCourses()
        {
            string folderPath = "StudentCredentials";
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Student credentials directory not found.");
                return;
            }

            var studentFiles = Directory.GetFiles(folderPath, "*.txt");
            if (studentFiles.Length == 0)
            {
                DialogResult result = MessageBox.Show("No student files found. Do you want to add a student now?", "No Student Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    AddStudentForm addStudentForm = new AddStudentForm(this);
                    addStudentForm.ShowDialog();
                }
                else
                {

                }
            }

            foreach (var file in studentFiles)
            {
                // Read the student file and extract necessary information
                string[] lines = File.ReadAllLines(file);
                string courseCode = "";
                string sectionName = "";

                foreach (var line in lines)
                {
                    if (line.StartsWith("Course Code:"))
                    {
                        courseCode = line.Split(':')[1].Trim();
                    }
                    else if (line.StartsWith("Section Name:"))
                    {
                        sectionName = line.Split(':')[1].Trim();
                    }
                }

                if (!string.IsNullOrEmpty(courseCode) && !string.IsNullOrEmpty(sectionName))
                {
                    CourseAndSectionCARD card = new CourseAndSectionCARD(this)
                    {
                        Course = courseCode,
                        SectionName = sectionName
                    };
                    courseSectionPanel.Controls.Add(card);
                }
            }
        }

        private void StudentPanel_Paint(object sender, PaintEventArgs e)
        {
            // Optional: Custom painting logic
        }

        private void addStudentsBTN_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm(this);
            addStudentForm.ShowDialog();// Logic to add students
        }
    }
}
