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
        // Method to populate courses from stored files
        public void populateCourses()
        {
            string folderPath = "CourseInformations"; // Root folder where course files are stored

            courseSectionPanel.Controls.Clear(); // Clear existing course cards

            // Check if the directory exists
            if (Directory.Exists(folderPath))
            {
                // Get all folders (each folder corresponds to a user)
                string[] userDirectories = Directory.GetDirectories(folderPath);

                // Iterate through each user directory
                foreach (string userDirectory in userDirectories)
                {
                    string currentUser = Path.GetFileName(userDirectory); // Get the current user from directory name

                    // Get all files related to the current user
                    string[] filePaths = Directory.GetFiles(userDirectory);

                    // Process each file
                    foreach (string filePath in filePaths)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(filePath); // Get filename without extension
                        string[] fileNameParts = fileName.Split('_'); // Split filename to get course details

                        if (fileNameParts.Length >= 2)
                        {
                            string courseCode = fileNameParts[0].Trim();
                            string courseName = fileNameParts[1].Trim();

                            // Read file content to get student count
                            string[] fileContent = File.ReadAllLines(filePath);

                            int studentCount = 0;

                            // Count the number of students based on the format
                            for (int i = 0; i < fileContent.Length; i++)
                            {
                                if (fileContent[i].StartsWith("Student ID:"))
                                {
                                    studentCount++;
                                }
                            }

                            // Create a CoursesCARD control with course information
                            CoursesCARD card = new CoursesCARD(this)
                            {
                                SubjectName = courseName,
                                SubjectCode = courseCode,
                                SubjectCount = studentCount.ToString(),
                                SubjectCourseSection = courseName // Assuming the course section is the same as course name
                                                                  // Add additional properties as needed (e.g., SubjectSchedule)
                            };

                            // Add the card to the course section panel
                            courseSectionPanel.Controls.Add(card);
                        }
                        else
                        {
                            // Handle cases where filename format is incorrect
                            MessageBox.Show($"Invalid filename format: {fileName}. Skipping file.");
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


            //formBackground.Dispose(); // Dispose of the background form
        }
    }
}
