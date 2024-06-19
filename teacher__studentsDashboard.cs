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
        // Properties
        public string currentUSer { get; set; }
        public FlowLayoutPanel CourseSectionPanel { get { return courseSectionPanel; } }

        // Private fields
        private readonly string teacherSchool;

        // Constructor
        public teacher__studentsDashboard(string currentuser)
        {
            InitializeComponent();
            currentUSer = currentuser;
            teacherSchool = LoadTeacherSchool(currentuser); // Load teacher's school from credentials
        }

        // Load event handler for form load
        private void teacher__studentsDashboard_Load(object sender, EventArgs e)
        {
            LoadStudentCourses(); // Load student courses on form load
        }

        // Method to load teacher's school from credentials file
        private string LoadTeacherSchool(string currentUser)
        {
            string teacherDetailsFile = $"TeacherCredentials/{currentUser}.txt";

            // Check if the teacher details file exists
            if (!File.Exists(teacherDetailsFile))
            {
                MessageBox.Show("Teacher details file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty; // Handle this case as needed
            }

            // Read lines from teacher details file
            string[] lines = File.ReadAllLines(teacherDetailsFile);
            foreach (var line in lines)
            {
                // Find and return school information
                if (line.StartsWith("School:"))
                {
                    return line.Split(':')[1].Trim();
                }
            }

            // Display error if school information is not found
            MessageBox.Show("School information not found in teacher details file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return string.Empty; // Handle this case as needed
        }

        // Method to load student courses into the UI
        public void LoadStudentCourses()
        {
            string folderPath = $"StudentCredentials/{currentUSer}";
            courseSectionPanel.Controls.Clear(); // Clear existing course cards

            // Check if the folder for student credentials exists
            if (Directory.Exists(folderPath))
            {
                string[] filePaths = Directory.GetFiles(folderPath, "*.txt");

                // If no student files found, prompt to add a student
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

                // Process each student file
                foreach (string filePath in filePaths)
                {
                    string fileContent = File.ReadAllText(filePath);
                    string[] courseBlocks = fileContent.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string block in courseBlocks)
                    {
                        string[] lines = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                        string department = "";
                        string section = "";

                        // Extract department and section information
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

                        // Ensure department and section are not empty
                        if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                        {
                            string[] courseCode = department.Split(',');
                            string lastPart = courseCode.Last().Trim();

                            // Check if a card with the same Course, Section, and CourseF already exists
                            bool cardExists = courseSectionPanel.Controls
                                .OfType<CourseAndSectionCARD>()
                                .Any(card => card.Course == lastPart && card.SectionName == section && card.CourseF == department);

                            // If card does not exist, create and add a new one
                            if (!cardExists)
                            {
                                CourseAndSectionCARD card = new CourseAndSectionCARD(currentUSer,this)
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
            }
            else
            {
                // If student folder does not exist, prompt to add a student
                DialogResult result = MessageBox.Show("No student yet. Do you want to add a student?", "Add Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
                    addStudentForm.Show();
                }
                return;
            }
        }

        // Event handler for adding students
        private void addStudentsBTN_Click(object sender, EventArgs e)
        {
            Form formbackground = new Form();

            using (AddStudentForm terms = new AddStudentForm(this, teacherSchool))
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = StateCommon.Back.Color1 = CustomColor.mainColor;
                formbackground.Size = new Size(1147, 711);

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                terms.Owner = formbackground;
                terms.ShowDialog();
            }
            formbackground.Dispose();


            
        }
    }
}