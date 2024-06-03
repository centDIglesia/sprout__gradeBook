using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            PopulateCourseSectionPanel();
        }

        private void PopulateCourseSectionPanel()
        {
            string folderPath = "CourseInformations";
            string filePath = Path.Combine(folderPath, $"{currentUSer}.txt");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Course information file not found.");
                return;
            }

            string[] fileContents = File.ReadAllText(filePath)
                .Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

            courseSectionPanel.Controls.Clear();

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

                if (courseDetails.ContainsKey("Course Name") && courseDetails.ContainsKey("Student Course and Section"))
                {
                    CourseAndSectionCARD courseCard = new CourseAndSectionCARD(this)
                    {
                        CourseName = courseDetails["Course Name"],
                        SectionName = courseDetails["Student Course and Section"]
                    };

                    courseSectionPanel.Controls.Add(courseCard);
                }
            }
        }

        public void LoadFormIntoPanel(Form form)
        {
            if (this.StudentPanel.Controls.Count > 0)
            {
                this.StudentPanel.Controls.RemoveAt(0);
            }

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.StudentPanel.Controls.Add(form);
            this.StudentPanel.Tag = form;
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


        private void StudentPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
