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
        // Static instance to maintain a single instance of the form
        public static teacher__courses_lvl1 lvl1Instance;
        public string CurrentUser { get; private set; } // Holds the current username

        public teacher__courses_lvl1(string currentUsername)
        {
            CurrentUser = currentUsername;
            InitializeComponent();
            lvl1Instance = this;
        }

        // Event handler when the form is loaded
        private void teacher__courses_lvl1_Load(object sender, EventArgs e)
        {
            populateCourses(); // Populate courses on form load
        }


        public void populateCourses()
        {
            // Construct the file path
            string filePath = $"CourseInformations/{CurrentUser}.txt";

            // Clear the existing controls from the course section panel.
            courseSectionPanel.Controls.Clear();

            if (File.Exists(filePath))
            {
                try
                {
                    // Read all lines from the file.
                    string[] fileLines = File.ReadAllLines(filePath);

                    // Variables to hold course details.
                    string courseCode = string.Empty;
                    string courseName = string.Empty;
                    string studentDepartment = string.Empty;
                    string studentYearAndSection = string.Empty;
                    string courseSchedule = string.Empty; // Variable to hold course schedule
                    string studentCount = "0";
                    bool inCourseSection = false;

                    // Loop through the lines to parse course details.
                    foreach (string line in fileLines)
                    {
                        if (line.StartsWith("Course Code:"))
                        {
                            courseCode = line.Split(':')[1].Trim();
                        }
                        else if (line.StartsWith("Course Name:"))
                        {
                            courseName = line.Split(':')[1].Trim();
                        }
                        else if (line.StartsWith("Student Department:"))
                        {
                            studentDepartment = line.Split(':')[1].Trim();
                        }
                        else if (line.StartsWith("Student year and section:"))
                        {
                            studentYearAndSection = line.Split(':')[1].Trim();
                            inCourseSection = true; // Indicates we are processing a valid course section.
                        }
                        else if (line.StartsWith("Course Schedule:"))
                        {
                            courseSchedule = line.Split(new[] { ':' }, 2)[1].Trim(); // Properly capture the entire schedule line
                        }
                        else if (line.StartsWith("----------------------------------------"))
                        {
                            // Check if we are in a valid course section and create the course card.
                            if (inCourseSection)
                            {
                                string courseSection = $"{studentDepartment} {studentYearAndSection}";

                                // Create a new CoursesCARD object and populate its properties.
                                CoursesCARD card = new CoursesCARD(this)
                                {
                                    SubjectName = courseName,
                                    SubjectCode = courseCode,
                                    SubjectSchedule = courseSchedule, // Add the course schedule to the card
                                    SubjectCount = studentCount,
                                    SubjectCourseSection = courseSection
                                };

                                // Add the created card to the panel.
                                courseSectionPanel.Controls.Add(card);

                                // Reset variables for the next course section.
                                inCourseSection = false;
                                courseCode = string.Empty;
                                courseName = string.Empty;
                                studentDepartment = string.Empty;
                                studentYearAndSection = string.Empty;

                                courseSchedule = string.Empty; // Reset course schedule
                                studentCount = "0";

                            }
                        }
                    }

                    // Handle the last course if file doesn't end with a delimiter.
                    if (inCourseSection)
                    {
                        string courseSection = $"{studentDepartment}, {studentYearAndSection}";

                        // Create and add the last CoursesCARD.
                        CoursesCARD card = new CoursesCARD(this)
                        {
                            SubjectName = courseName,
                            SubjectCode = courseCode,

                            SubjectSchedule = courseSchedule, // Add the course schedule to the card
                            SubjectCount = studentCount,

                            SubjectCourseSection = courseSection
                        };
                        courseSectionPanel.Controls.Add(card);
                    }
                }
                catch (Exception ex)
                {
                    // Show an error message if there is an exception during file reading.
                    MessageBox.Show($"Error reading file: {ex.Message}");
                }
            }
            else
            {
                // Show a message if the specified file is not found.
                MessageBox.Show($"File not found: {filePath}");
            }
        }
        private string getStudentCount(string studentFilePath)
        {
            // string filepath = $"CourseInformations/{CurrentUser}";



            return "";
        }
        // Method to show the course section panel
        public void ShowPanel()
        {
            courseSectionPanel.Show();
        }

        // Method to remove a course card from the UI and data files
        public void RemoveCourse(CoursesCARD card)
        {
            string folderPath = "CourseInformations";
            string mainFilePath = Path.Combine(folderPath, $"{CurrentUser}.txt");

            bool specificFileDeleted = false; // Flag to track specific file deletion

            // Check if the main file exists
            if (File.Exists(mainFilePath))
            {
                var lines = File.ReadAllLines(mainFilePath).ToList();
                var updatedLines = new List<string>();

                bool isInTargetBlock = false;
                bool blockSkipped = false;

                // Define start and end markers for course block
                string blockStartIndicator = $"Course Name: {card.SubjectName}";
                string blockEndIndicator = "----------------------------------------";

                // Iterate through lines to update the file
                foreach (var line in lines)
                {
                    if (line.StartsWith("Course Name:"))
                    {
                        isInTargetBlock = false;
                        blockSkipped = false;
                    }

                    if (line.Contains(blockStartIndicator))
                    {
                        isInTargetBlock = true;
                    }

                    if (isInTargetBlock && !blockSkipped)
                    {
                        if (line.StartsWith(blockEndIndicator))
                        {
                            blockSkipped = true;
                            isInTargetBlock = false;
                        }
                        continue; // Skip lines within the target block
                    }

                    updatedLines.Add(line);
                }

                // Write updated lines back to the file
                File.WriteAllLines(mainFilePath, updatedLines);

                // Remove the card from UI
                courseSectionPanel.Controls.Remove(card);

                // Refresh courses after removal
                populateCourses();
            }
            else
            {
                // Display an error message if the file does not exist
                MessageBox.Show($"File not found: {mainFilePath}");
            }

            // Construct path for specific course file
            string specificFileName = $"{card.SubjectCode}_{card.SubjectCourseSection}.txt";
            string specificFilePath = Path.Combine(folderPath, CurrentUser, specificFileName);

            // Delete specific course file if exists
            if (File.Exists(specificFilePath))
            {
                File.Delete(specificFilePath);
                specificFileDeleted = true;
            }

            // Show confirmation if specific file was deleted
            if (specificFileDeleted)
            {
                MessageBox.Show($"Course file deleted successfully", "File Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Event handler for adding a new course
        private void addcourseBTN_Click(object sender, EventArgs e)
        {
            // Open AddCourseForm as a modal dialog
            Form formBackground = new Form();
            using (AddCourseForm courseForm = new AddCourseForm(CurrentUser, this))
            {
                Enabled = false;

                // Configure background form appearance
                formBackground.StartPosition = FormStartPosition.CenterScreen;
                formBackground.FormBorderStyle = FormBorderStyle.None;
                formBackground.Opacity = .70d;
                formBackground.BackColor = StateCommon.Back.Color1 = CustomColor.mainColor;
                formBackground.Size = new System.Drawing.Size(1147, 711);
                formBackground.Location = this.Location;
                formBackground.ShowInTaskbar = false;
                formBackground.Show();

                // Set ownership of courseForm to formBackground
                courseForm.Owner = formBackground;
                courseForm.ShowDialog();
            }


            formBackground.Dispose(); // Dispose of the background form
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {


            //formBackground.Dispose(); // Dispose of the background form
        }
    }
}
