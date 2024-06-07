using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Collections.Specialized.BitVector32;

namespace sprout__gradeBook
{
    public partial class teacher__studentsDashboard : KryptonForm
    {
        public string currentUSer { get; set; }
        private string teacherSchool;

        public teacher__studentsDashboard(string currentuser)
        {
            InitializeComponent();
            currentUSer = currentuser;
            teacherSchool = LoadTeacherSchool(currentuser);
        }

        private void teacher__studentsDashboard_Load(object sender, EventArgs e)
        {
            LoadStudentCourses();
        }
        private string LoadTeacherSchool(string currentUser)
        {
           
            string teacherDetailsFile = $"teacherCredentials/{currentUser}.txt";
            if (!File.Exists(teacherDetailsFile))
            {
                throw new FileNotFoundException("Teacher details file not found.");
            }

            string[] lines = File.ReadAllLines(teacherDetailsFile);
            foreach (var line in lines)
            {
                if (line.StartsWith("School:"))
                {
                    return line.Split(':')[1].Trim();
                }
            }

            throw new Exception("School information not found in teacher details file.");
        }

        private void LoadStudentCourses()
        {
            string folderPath = $"StudentCredentials/{currentUSer}";
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.txt");
                foreach (string filePath in filePaths)
                {
                    string[] lines = File.ReadAllLines(filePath);
                    string department = "";
                    string section = "";
                    foreach (var line in lines)
                    {
                        if (line.StartsWith("Year and Section:"))
                        {
                            section = line.Substring("Year and Section:".Length).Trim();
                        }
                        else if (line.StartsWith("Department:"))
                        {
                            department = line.Substring("Department:".Length).Trim();

                        }

                        if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                        {
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                    {
                        string[] courseCode = department.Split(',');
                        string lastPart = courseCode.Last().Trim();



                        CourseAndSectionCARD card = new CourseAndSectionCARD(this)
                        {
                            Course = lastPart,
                            SectionName = section,
                            CourseF = department
                        };
                        courseSectionPanel.Controls.Add(card);
                    }
                }
            }
        }



        private void StudentPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void addStudentsBTN_Click(object sender, EventArgs e)
        {
          
            AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
            addStudentForm.Show();
        }
    }
}
