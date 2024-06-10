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
    public partial class studentSectionLIST : KryptonForm
    {
        teacher__studentsDashboard studentsDashboard;
        public studentSectionLIST(teacher__studentsDashboard StudentsDashboard)
        {
            studentsDashboard = StudentsDashboard;
            InitializeComponent();
        }

        private void studentSectionLIST_Load(object sender, EventArgs e)
        {
            LoadStudentCourses();
        }

        private void LoadStudentCourses()
        {
            string folderPath = $"StudentCredentials/{studentsDashboard.currentUSer}";
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



                        CourseAndSectionCARD card = new CourseAndSectionCARD(studentsDashboard)
                        {
                            Course = lastPart,
                            SectionName = section,
                            CourseF = department
                        };
                        studentCourseSectionFlow.Controls.Add(card);
                    }
                }
            }
        }

        private void studentCourseSectionFlow_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
