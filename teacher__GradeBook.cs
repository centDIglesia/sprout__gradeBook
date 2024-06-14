using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;

namespace sprout__gradeBook
{

    public partial class teacher__GradeBook : KryptonForm
    {
        public static teacher__GradeBook _gradeBook;
        public string currentUSer { get; set; }
        public string StudenttnameText
        {
            get { return StudenttnameTXT.Text; }
            set { StudenttnameTXT.Text = value; }
        }

        public string StudentIDText
        {
            get { return StudentIDTXT.Text; }
            set { StudentIDTXT.Text = value; }
        }
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
                MessageBox.Show(
      "Please ensure you have added the course details and set up the grading system before proceeding. To add a course, navigate to the 'Courses' section and click on 'Add New Course'. Then, click on the course and add a 'Grading System' by selecting the 'Grading System' button and setting up the required components.",
      "Incomplete Setup",
      MessageBoxButtons.OK,
      MessageBoxIcon.Warning
  );

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


            string fileContent = File.ReadAllText(filePath);


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


                if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                {
                    AddStudentCard(studentID, studentName);
                }
            }
        }

        private void AddStudentCard(string studentID, string studentName)
        {
            studentsInGradebookCARD studentCard = new studentsInGradebookCARD(this)
            {
                currentStudentID = studentID,
                currentStudentName = studentName
            };

            studentListPanel.Controls.Add(studentCard);
        }
        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionTXT.Text = RemoveSubstring(courseComboBox.Text, "_", ",");




            // Define the directory path based on the selected grading system path
            string selectedGradingSystemPath = courseComboBox.Text;

            string baseDirectoryPath = $"CourseGradingSystem/{currentUSer}/{selectedGradingSystemPath}";
            string filePath = Path.Combine(baseDirectoryPath, "gradingSystem.txt");

            // Clear existing controls in the ComponentsButtonPanel
            ComponentsButtonPanel.Controls.Clear();


            if (File.Exists(filePath))
            {

                string[] lines = File.ReadAllLines(filePath);


                foreach (string line in lines)
                {

                    if (line.StartsWith("-") || string.IsNullOrWhiteSpace(line)) continue;


                    string[] parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        string componentName = parts[0];
                        string componentWeight = parts[1];


                        Component_Button_Card componentCard = new Component_Button_Card
                        {
                            compName = $"{componentName} ({componentWeight})"
                        };

                        // Add the new control to the ComponentsButtonPanel
                        ComponentsButtonPanel.Controls.Add(componentCard);
                    }
                }
            }
            else
            {
                MessageBox.Show($"Grading system file not found.{filePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }
        public static string RemoveSubstring(string input, string startPattern, string endPattern)
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
        public void populateComponentButtonInComponentButtonPanel()
        {
            string currentSection = sectionTXT.Text;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void addSubcomponents_Click(object sender, EventArgs e)
        {
            AddComponentGradeCard();
        }

        private void subcomponentsPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddComponentGradeCard()
        {

            ComponentGradesCARD componentCard = new ComponentGradesCARD
            {
                ComponentNumber = "Component 1",
                ComponentGrade = 85.1,
                ComponentMaximumGrade = 100,
                ComponentPercentageGrade = 100,
            };
            subcomponentsPane.Controls.Add(componentCard);

            // Refresh the layout
            subcomponentsPane.Refresh();
        }
    }
}