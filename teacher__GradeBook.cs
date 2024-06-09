using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class teacher__GradeBook : KryptonForm
    {
        public string currentUSer { get; set; }

        public teacher__GradeBook(string currentuser)
        {
            currentUSer = currentuser;
            InitializeComponent();



        }

        private void teacher__GradeBook_Load(object sender, EventArgs e)
        {

            LoadTxtFilesIntoComboBox(currentUSer);
            courseComboBox.SelectedIndexChanged += CourseComboBox_SelectedIndexChanged;
        }

        private void LoadTxtFilesIntoComboBox(string currentUser)
        {
            string directoryPath = $"CourseInformations/{currentUser}/";

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show("Directory does not exist.");
                return;
            }

            string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt");

            foreach (string filePath in txtFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                courseComboBox.Items.Add(fileName);
            }
        }

        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCourse = courseComboBox.SelectedItem.ToString();
            string filePath = $"CourseInformations/{currentUSer}/{selectedCourse}.txt";

            LoadStudentCards(filePath);
        }

        private void LoadStudentCards(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist.");
                return;
            }

            studentListPanel.Controls.Clear();

            // Read all content from the file
            string fileContent = File.ReadAllText(filePath);

            // Split the content by the separator
            string[] studentEntries = fileContent.Split(new[] { "----------------------------" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string entry in studentEntries)
            {
                string[] lines = entry.Trim().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                string studentID = string.Empty;
                string studentName = string.Empty;

                foreach (string line in lines)
                {
                    if (line.StartsWith("Student ID:"))
                    {
                        studentID = line.Substring("Student ID:".Length).Trim();
                    }
                    else if (line.StartsWith("Student Name:"))
                    {
                        studentName = line.Substring("Student Name:".Length).Trim();
                    }
                }

                // Add the student card if both ID and Name are present
                if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                {
                    AddStudentCard(studentID, studentName);
                }
            }
        }

        private void AddStudentCard(string studentID, string studentName)
        {
            studentsInGradebookCARD studentCard = new studentsInGradebookCARD
            {
                currentStudentID = studentID,
                currentStudentName = studentName
            };

            studentListPanel.Controls.Add(studentCard);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionTXT.Text = RemoveSubstring(courseComboBox.Text, "_", ",");
        }

        private void studentListPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private string RemoveSubstring(string input, string startPattern, string endPattern)
        {
            int startIndex = input.IndexOf(startPattern);
            int endIndex = input.IndexOf(endPattern);

            if (startIndex != -1 && endIndex != -1)
            {
                return input.Remove(startIndex, endIndex - startIndex);
            }
            else
            {
                return input;
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void sectionTXT_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
