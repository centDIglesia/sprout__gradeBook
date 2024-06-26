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
        public FlowLayoutPanel CourseSectionPanel { get { return courseSectionPanel; } }
        public string currentSearchbarInput;
        public string currentCourse;
        public string currentSection;
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
            LoadStudentCourses();
            ClickedCourse.Hide();
            searchBar_input.Hide();
            searchBar_pb.Hide();
        }
        public void ShowSearchBar()
        {
            searchBar_input.Show();
            searchBar_pb.Show();
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
                                CourseAndSectionCARD card = new CourseAndSectionCARD(currentUSer, this)
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

                DialogResult result = MessageBox.Show("No student yet. Do you want to add a student?", "Add Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    object sender = new object();
                    EventArgs e = new EventArgs();
                    addStudentsBTN_Click(sender, e);

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

        // Event handler for BacktoStudentDashboard label click
        private void BacktoStudentDashboard_Click(object sender, EventArgs e)
        {
            // Clear ClickedCourse label text and hide it
            ClickedCourse.Text = "";
            ClickedCourse.Hide();
            searchBar_input.Hide();
            searchBar_pb.Hide();

            LoadStudentCourses();
        }
        public void ShowCourseDetails(string courseName, string yearSection)
        {
            currentCourse = courseName; // Store the current course
            currentSection = yearSection; // Store the current section

            ClickedCourse.Text = $"/ {courseName} {yearSection}";
            ClickedCourse.Show();
        }

        private void searchBar_input_TextChanged(object sender, EventArgs e)
        {
            currentSearchbarInput = searchBar_input.Text; // Update the current search input
            FilterAndLoadStudents(currentSearchbarInput, currentCourse, currentSection); // Call method to filter and load students
        }

        private void searchBar_input_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(searchBar_input, "Search for a student");
            searchBar_pb.Image = Properties.Resources.SearchBar_Active;
        }

        private void searchBar_input_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(searchBar_input, "Search for a student");

            searchBar_input.StateCommon.Content.Color1 = Color.DarkGray;
            searchBar_pb.Image = Properties.Resources.SearchBar_Common;
        }
        public void FilterAndLoadStudents(string searchInput, string currentCourse, string currentSection)
        {
            CourseSectionPanel.Controls.Clear(); // Clear existing student cards

            string directoryPath = $"StudentCredentials/{currentUSer}";
            if (!Directory.Exists(directoryPath))
            {

                return;
            }

            string[] files = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string file in files)
            {
                LoadFilteredStudentsFromFile(file, searchInput, currentCourse, currentSection);
            }
        }



        private void LoadFilteredStudentsFromFile(string filePath, string searchInput, string currentCourse, string currentSection)
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

            // Check if searchInput is null or empty and if the student belongs to the current course and section
            if ((string.IsNullOrEmpty(searchInput) || studentName.ToLower().Contains(searchInput.ToLower()) || searchInput.Trim().Equals("Search for a student", StringComparison.OrdinalIgnoreCase))
                && department.EndsWith(currentCourse) && lines.Any(l => l.StartsWith("Year and Section:") && l.Contains(currentSection)))
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

                studentsCARD studentCard = new studentsCARD(this)
                {
                    StudentName = studentName,
                    StudentID = studentID,
                    StudentGender = genderImage
                };

                CourseSectionPanel.Controls.Add(studentCard);
            }
        }



    }
}