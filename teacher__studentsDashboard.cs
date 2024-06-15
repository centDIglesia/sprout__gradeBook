using System;
using System.IO;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class teacher__studentsDashboard : KryptonForm
    {
        public string currentUSer { get; set; }
        private readonly string teacherSchool;
        public FlowLayoutPanel CourseSectionPanel { get { return courseSectionPanel; } }

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
                MessageBox.Show("Teacher details file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty; // Return an empty string or handle this case as needed
            }

            string[] lines = File.ReadAllLines(teacherDetailsFile);
            foreach (var line in lines)
            {
                if (line.StartsWith("School:"))
                {
                    return line.Split(':')[1].Trim();
                }
            }

            MessageBox.Show("School information not found in teacher details file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return string.Empty; // Return an empty string or handle this case as needed
        }

        /*public void LoadStudentCourses()
        {
            string folderPath = $"StudentCredentials/{currentUSer}";
            courseSectionPanel.Controls.Clear();
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.txt");

                if (filePaths.Length == 0)
                {
                    DialogResult result = MessageBox.Show("No student files found. Do you want to add a student?", "Add Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
                        addStudentForm.Show();
                    }
                    return; // Exit the method since there are no files to process
                }

                foreach (string filePath in filePaths)
                {
                    string fileContent = File.ReadAllText(filePath);
                    string[] courseBlocks = fileContent.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string block in courseBlocks)
                    {
                        string[] lines = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
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
                        }

                        if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                        {
                            string[] courseCode = department.Split(',');
                            string lastPart = courseCode.Last().Trim();

                            // Create a new instance of CourseAndSectionCARD
                            CourseAndSectionCARD card = new CourseAndSectionCARD(this)
                            {
                                Course = lastPart,
                                SectionName = section,
                                CourseF = department
                            };

                            // Add the card to the courseSectionPanel
                            courseSectionPanel.Controls.Add(card);
                        }
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("No student yet. Do you want to add a student?", "Add Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
                    addStudentForm.Show();
                }
                return;
            }
        }
        */
        public void LoadStudentCourses()
        {
            string folderPath = $"StudentCredentials/{currentUSer}";
            courseSectionPanel.Controls.Clear();

            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.txt");

                if (filePaths.Length == 0)
                {
                    DialogResult result = MessageBox.Show("No student files found. Do you want to add a student?", "Add Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
                        addStudentForm.Show();
                    }
                    return;
                }

                foreach (string filePath in filePaths)
                {
                    string fileContent = File.ReadAllText(filePath);
                    string[] courseBlocks = fileContent.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string block in courseBlocks)
                    {
                        string[] lines = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
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
                        }

                        if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                        {
                            string[] courseCode = department.Split(',');
                            string lastPart = courseCode.Last().Trim();

                            // Check if a card with the same Course, Section, and CourseF already exists
                            bool cardExists = courseSectionPanel.Controls
                                .OfType<CourseAndSectionCARD>()
                                .Any(card => card.Course == lastPart && card.SectionName == section && card.CourseF == department);

                            if (!cardExists)
                            {
                                // Create a new instance of CourseAndSectionCARD
                                CourseAndSectionCARD card = new CourseAndSectionCARD(this)
                                {
                                    Course = lastPart,
                                    SectionName = section,
                                    CourseF = department
                                };

                                // Add the card to the courseSectionPanel
                                courseSectionPanel.Controls.Add(card);
                            }
                        }
                    }
                }
            }
            else
            {
                DialogResult result = MessageBox.Show("No student yet. Do you want to add a student?", "Add Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
                    addStudentForm.Show();
                }
                return;
            }
        }


        private void StudentPanel_Paint(object sender, PaintEventArgs e)
        {
            // Handle painting if necessary
        }

        private void addStudentsBTN_Click(object sender, EventArgs e)
        {
            Form formbackground = new Form();

            using (AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool))
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = StateCommon.Back.Color1 = CustomColor.mainColor;
                formbackground.Size = new Size(1147, 711);

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                addStudentForm.Owner = formbackground;
                addStudentForm.ShowDialog();
            }
            formbackground.Dispose();
        }


    }

}