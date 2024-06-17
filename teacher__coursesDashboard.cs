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

        // Method to populate courses from stored files
        public void populateCourses()
        {
            string folderPath = "CourseInformations"; // Folder where course files are stored

            courseSectionPanel.Controls.Clear(); // Clear existing course cards

            // Check if the directory exists
            if (Directory.Exists(folderPath))
            {
                // Get all files related to the current user
                string[] filePaths = Directory.GetFiles(folderPath, $"{CurrentUser}.txt");

                // Process each file
                foreach (string filePath in filePaths)
                {
                    string fileContent = File.ReadAllText(filePath); // Read file content

                    // Split content into course blocks
                    string[] courseBlocks = fileContent.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string block in courseBlocks)
                    {
                        string[] lines = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None); // Split block into lines

                        // Variables to hold course information
                        string courseName = "";
                        string courseCode = "";
                        string department = "";
                        string section = "";
                        string schedule = "";
                        int studentCount = 0;

                        // Extract course details from lines
                        foreach (var line in lines)
                        {
                            if (line.StartsWith("Course Name:"))
                            {
                                courseName = line.Substring("Course Name:".Length).Trim();
                            }
                            else if (line.StartsWith("Course Code:"))
                            {
                                courseCode = line.Substring("Course Code:".Length).Trim();
                            }
                            else if (line.StartsWith("Student Department:"))
                            {
                                department = line.Substring("Student Department:".Length).Trim();
                            }
                            else if (line.StartsWith("Student year and section:"))
                            {
                                section = line.Substring("Student year and section:".Length).Trim();
                            }
                            else if (line.StartsWith("Course Schedule:"))
                            {
                                schedule = line.Substring("Course Schedule:".Length).Trim();
                            }
                            else if (line.StartsWith("Student Count:"))
                            {
                                studentCount = int.Parse(line.Substring("Student Count:".Length).Trim());
                            }
                        }

                        // Check if all required information is available
                        if (!string.IsNullOrEmpty(courseName) && !string.IsNullOrEmpty(courseCode) &&
                            !string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(section))
                        {
                            // Create a CoursesCARD control with course information
                            CoursesCARD card = new CoursesCARD(this)
                            {
                                SubjectName = courseName,
                                SubjectCode = courseCode,
                                SubjectCount = studentCount.ToString(),
                                SubjectSchedule = schedule,
                                SubjectCourseSection = $"{department} {section}"
                            };

                            // Add the card to the course section panel
                            courseSectionPanel.Controls.Add(card);
                        }
                    }
                }
            }
            else
            {
                // Display an error message if the directory does not exist
                MessageBox.Show($"Directory not found: {folderPath}");
            }
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


            formBackground.Dispose(); // Dispose of the background form
        }
    }
}
