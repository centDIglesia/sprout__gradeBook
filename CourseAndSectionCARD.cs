using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;

namespace sprout__gradeBook
{
    public partial class CourseAndSectionCARD : UserControl
    {
        private readonly string _CurrentUser;
        private readonly teacher__studentsDashboard _parentForm;
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

        public CourseAndSectionCARD(string currentUser, teacher__studentsDashboard parentForm)
        {
            InitializeComponent();
            _CurrentUser = currentUser;
            _parentForm = parentForm;
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
            string searchInput = _parentForm.currentSearchbarInput;

            _parentForm.ShowSearchBar();
            _parentForm.ShowCourseDetails(currentCourse, currentSection);
            _parentForm.FilterAndLoadStudents(searchInput, currentCourse, currentSection);

            /* string directoryPath = $"StudentCredentials/{_parentForm.currentUSer}";
            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Directory not found.");
                return;
            }

            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string file in files)
            {
                FilterAndPopulateStudents(currentCourse, currentSection, file, searchInput);
            }
            */


        }

        public void FilterAndPopulateStudents(string currentCourse, string currentSection, string filePath, string searchInput)
        {

            string[] lines = File.ReadAllLines(filePath);
            string studentName = "";
            string studentID = "";
            string studentGender = "";
            string department = "";

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
                else if (line.StartsWith("Department:"))
                {
                    department = line.Substring("Department:".Length).Trim();
                }
            }

            // Check if the student belongs to the current course and section
            if (department.EndsWith(currentCourse) && lines.Any(l => l.StartsWith("Year and Section:") && l.Contains(currentSection)))
            {
                // Set the image based on gender
                Image genderImage = null;
                if (studentGender.ToLower() == "male")
                {
                    genderImage = Properties.Resources.Male_Icon;
                }
                else if (studentGender.ToLower() == "female")
                {
                    genderImage = Properties.Resources.Female_Icon;
                }

                studentsCARD studentCard = new studentsCARD(_parentForm)
                {
                    StudentName = studentName,
                    StudentID = studentID,
                    StudentGender = genderImage
                };

                _parentForm.CourseSectionPanel.Controls.Add(studentCard);
            }
        }


    }
}

