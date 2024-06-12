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
        public static teacher__courses_lvl1 lvl1Instance;
        public string CurrentUser { get; private set; }

        public teacher__courses_lvl1(string currentUsername)
        {
            CurrentUser = currentUsername;
            InitializeComponent();
            lvl1Instance = this;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void teacher__courses_lvl1_Load(object sender, EventArgs e)
        {
            populateCourses();
        }

        public void Hidebuttons()
        {
            addcourseBTN.Hide();
            deleteBTN.Hide();
        }

        public void populateCourses()
        {
            // Define the folder path where course information files are stored
            string folderPath = "CourseInformations";

            // Clear existing controls from the course section panel
            courseSectionPanel.Controls.Clear();

            // Check if the folder exists
            if (Directory.Exists(folderPath))
            {
                // Get all file paths in the folder with the name of the current user
                string[] filePaths = Directory.GetFiles(folderPath, $"{CurrentUser}.txt");

                // Iterate through each file path
                foreach (string filePath in filePaths)
                {
                    // Read the content of the file
                    string fileContent = File.ReadAllText(filePath);

                    // Split the file content into blocks using a separator
                    string[] courseBlocks = fileContent.Split(new string[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    // Iterate through each block
                    foreach (string block in courseBlocks)
                    {
                        // Split the block into lines
                        string[] lines = block.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                        // Initialize variables to store course information
                        string courseName = "";
                        string courseCode = "";
                        string department = "";
                        string section = "";
                        string schedule = "";
                        int studentCount = 0;

                        // Iterate through each line
                        foreach (var line in lines)
                        {
                            // Extract course information based on the line content
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
                            // Create a CoursesCARD control with the extracted course information
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
                // Display a message if the directory is not found
                MessageBox.Show($"Directory not found: {folderPath}");
            }
        }

        public void LoadFormIntoPanel(Form form)
        {
            courseSectionPanel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            courseSectionPanel.Controls.Add(form);
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
        public void RemoveCourse(CoursesCARD card)
        {
            string folderPath = "CourseInformations";
            string filePath = Path.Combine(folderPath, $"{CurrentUser}.txt");

            if (File.Exists(filePath))
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath).ToList();
                var updatedLines = new List<string>();

                // Variables to track block status
                bool isInTargetBlock = false;
                bool blockSkipped = false;

                // Define the start and end indicators for a course block
                string blockStartIndicator = $"Course Name: {card.SubjectName}";
                string blockEndIndicator = "----------------------------------------";

                foreach (var line in lines)
                {
                    // Check if the current line is the start of a course block
                    if (line.StartsWith("Course Name:"))
                    {
                        // Reset block status for a new block
                        isInTargetBlock = false;
                        blockSkipped = false;
                    }

                    // Determine if we are inside the target block
                    if (line.Contains(blockStartIndicator))
                    {
                        isInTargetBlock = true;
                    }

                    // Skip lines if we are inside the target block and haven't skipped it yet
                    if (isInTargetBlock && !blockSkipped)
                    {
                        // Skip lines in the target block
                        if (line.StartsWith(blockEndIndicator))
                        {
                            // We have reached the end of the block, set blockSkipped to true
                            blockSkipped = true;
                            isInTargetBlock = false;
                        }
                        continue; // Skip adding this line to updatedLines
                    }

                    // Add lines that are not part of the target block to updatedLines
                    updatedLines.Add(line);
                }

                // Write the updated lines back to the file
                File.WriteAllLines(filePath, updatedLines);

                // Remove the card from the UI
                courseSectionPanel.Controls.Remove(card);

                // Refresh the UI
                populateCourses();
            }
            else
            {
                MessageBox.Show($"File not found: {filePath}");
            }

            string specificFilePath = Path.Combine(folderPath, CurrentUser,
           $"{card.SubjectName}_{card.SubjectCourseSection.Replace(", ", "_")}.txt");

            if (File.Exists(specificFilePath))
            {
                File.Delete(specificFilePath);
            }
        }


        private void addcourseBTN_Click(object sender, EventArgs e)
        {
            AddCourseForm adf = new AddCourseForm(CurrentUser, this);
            adf.Show();
            Enabled = false;
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void refreshBTN_Click_1(object sender, EventArgs e)
        {
            populateCourses();
        }

        //get the teacher firstname

    }
}
