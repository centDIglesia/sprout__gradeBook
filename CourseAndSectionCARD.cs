using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;

namespace sprout__gradeBook
{
    public partial class CourseAndSectionCARD : UserControl
    {
        public new teacher__studentsDashboard ParentForm { get; set; } // Reference to the parent form

        public string SectionName
        {
            get => CoursecSectionOfStudent.Text;
            set => CoursecSectionOfStudent.Text = value;
        }

        public string CourseF
        {
            get => CourseFull.Text;
            set => CourseFull.Text = value;
        }

        public string Course
        {
            get => CoursecOfStudent.Text;
            set => CoursecOfStudent.Text = value;
        }

        public CourseAndSectionCARD(teacher__studentsDashboard parentForm)
        {
            InitializeComponent();
            ParentForm = parentForm;
        }

        private void CoursecSectionOfStudent_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.subsubhover;
            CoursecSectionOfStudent.BackColor = CustomColor.activeColor;
            CoursecOfStudent.ForeColor = CustomColor.activeColor;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.susushoverleave;
            CoursecSectionOfStudent.BackColor = CustomColor.mainColor;
            CoursecOfStudent.ForeColor = CustomColor.mainColor;
        }

        private void CoursecSectionOfStudent_Click(object sender, EventArgs e)
        {
            string currentSection = SectionName;
            string currentCourse = CourseF;

            string directoryPath = $"StudentCredentials/{ParentForm.currentUSer}";
            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Directory not found.");
                return;
            }

            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string file in files)
            {
                FilterAndPopulateStudents(currentCourse, currentSection, file);
            }
        }

        private void FilterAndPopulateStudents(string currentCourse, string currentSection, string filePath)
        {
            ParentForm.CourseSectionPanel.Controls.Clear();

            string[] files = Directory.GetFiles(Path.GetDirectoryName(filePath), "*.txt");

            // Filter files by course and year level
            var matchingFiles = files.Where(file =>
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    if (line.StartsWith("Department:") && line.Contains(currentCourse))
                    {
                        string yearAndSection = lines.FirstOrDefault(l => l.StartsWith("Year and Section:"));
                        if (yearAndSection != null && yearAndSection.Contains(currentSection))
                        {
                            return true;
                        }
                    }
                }
                return false;
            });

            // Iterate through matching files
            foreach (string file in matchingFiles)
            {
                string[] lines = File.ReadAllLines(file);
                string studentName = "";
                string studentID = "";
                string studentGender = "";
                foreach (string line in lines)
                {
                    if (line.StartsWith("Student Name:"))
                    {
                        studentName = line.Substring("Student Name:".Length).Trim();
                    }
                    else if (line.StartsWith("Student ID:"))
                    {
                        studentID = line.Substring("Student ID:".Length).Trim();
                    }
                    else if (line.StartsWith("Gender:"))
                    {
                        studentGender = line.Substring("Gender:".Length).Trim();
                    }
                }

                // Set the image based on gender
                Image genderImage = null;
                if (studentGender.ToLower() == "male")
                {
                    genderImage = Properties.Resources.maleee;
                }
                else if (studentGender.ToLower() == "female")
                {
                    genderImage = Properties.Resources.femaleee;
                }

                studentsCARD studentCard = new studentsCARD()
                {
                    StudentName = studentName,
                    StudentID = studentID,
                    StudentGender = genderImage
                };

                ParentForm.CourseSectionPanel.Controls.Add(studentCard);
            }
        }

        private void CourseFull_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
