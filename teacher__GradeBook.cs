using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;
using System.Text;
using System.Collections.Generic;

namespace sprout__gradeBook
{
    public delegate void CalculateAndDisplayFinalGradeDelegate();
    public delegate void displayGradeBookPanelDelegate();

    public partial class teacher__GradeBook : KryptonForm
    {
        public Component_Button_Card _currentActiveComponentButton;
        public static teacher__GradeBook _gradeBook;
        List<double> _FinalGradesInEachComponents = new List<double>();


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

            genderPict.Hide();
            StudentIDTXT.Hide();
            StudenttnameTXT.Hide();
            sectionTXT.Hide();
            ComponentsButtonPanel.Hide();



            pictureBox4.Hide();
            addSubcomponents.Hide();
            saveGradeBtn.Visible = false;
            pictureBox5.Hide();
            doneBtn.Hide();

            courseComboBox.Hide();
            kryptonTextBox1.Hide();
            pictureBox2.Hide();

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


            string[] trimmedCourseParts = selectedCourse.Split('_');


            if (trimmedCourseParts.Length == 2)
            {
                string trimmedCourseName = trimmedCourseParts[1].Trim();
                string studentFilePath = $"StudentCredentials/{currentUSer}/DepartmentandSections/{trimmedCourseName}.txt";


                LoadStudentCards(studentFilePath);
            }
            else
            {

                MessageBox.Show("Selected course format is incorrect. Please select a valid course.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            DisplayIfCourseSelected();

        }


        private void DisplayIfCourseSelected()
        {
            genderPict.Show();
            StudentIDTXT.Show();
            StudenttnameTXT.Show();
            sectionTXT.Show();
            ComponentsButtonPanel.Show();
        }
        public void DisplayIfCompButtonIsclicked()
        {
            pictureBox4.Show();
            addSubcomponents.Show();

            doneBtn.Show();
            pictureBox5.Show();
        }



        private void LoadStudentCards(string filePath)
        {
            // Clear existing student cards
            studentListPanel.Controls.Clear();

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                string studentID = null;
                string studentName = null;

                foreach (string line in lines)
                {
                    // Look for the "Student ID:" prefix
                    if (line.StartsWith("Student ID:"))
                    {
                        studentID = line.Substring("Student ID:".Length).Trim();
                    }
                    // Look for the "Student Name:" prefix
                    else if (line.StartsWith("Student Name:"))
                    {
                        studentName = line.Substring("Student Name:".Length).Trim();
                    }
                    // If both ID and Name are found, add the student card
                    if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                    {
                        AddStudentCard(studentID, studentName);
                        studentID = null; // Reset for the next student
                        studentName = null; // Reset for the next student
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file not found, read errors)
                MessageBox.Show($"Error loading student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


                        Component_Button_Card componentCard = new Component_Button_Card(currentComponent, DisplayIfCompButtonIsclicked)
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



        public int componentCount = 0;
        private void addSubcomponents_Click(object sender, EventArgs e)
        {
            componentCount++;
            AddComponentGradeCard();
        }



        private void AddComponentGradeCard()
        {
            int startIndex = currentComponent.Text.IndexOf("(");

            if (startIndex != -1)
            {
                string compName = (currentComponent.Text).Substring(0, startIndex).Trim();

                ComponentGradesCARD componentCard = new ComponentGradesCARD(CalculateAndDisplayFinalGrade)
                {
                    ComponentNumber = $"{compName} #{componentCount}",
                    ComponentGrade = 00.0,
                    ComponentMaximumGrade = 00.0,

                };
                subcomponentsPanel.Controls.Add(componentCard);



                CalculateAndDisplayFinalGrade();
            }

        }

        public void clearSubcomponentsPanel()
        {
            subcomponentsPanel.Controls.Clear();
        }


        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void CalculateAndDisplayFinalGrade()
        {
            double totalPercentage = 0.0;
            int componentCardCount = 0;

            string text = currentComponent.Text;

            // Extract weight from currentComponent.Text
            int startIndex = text.IndexOf("(");
            int endIndex = text.IndexOf(")");

            if (startIndex != -1 && endIndex != -1)
            {
                string weightText = text.Substring(startIndex + 1, endIndex - startIndex - 1).Trim('%', ' ');

                if (double.TryParse(weightText, out double weight))
                {
                    finalGradelbl.Text = text;

                    // Calculate average percentage based on component cards
                    foreach (Control control in subcomponentsPanel.Controls)
                    {
                        if (control is ComponentGradesCARD componentCard)
                        {
                            totalPercentage += componentCard.ComponentPercentageGrade;
                            componentCardCount++;
                        }
                    }

                    if (componentCardCount > 0)
                    {
                        double averagePercentage = (totalPercentage / componentCardCount) * (weight / 100.0);


                        finalGradelbl.Text += " in Final Grade : " + averagePercentage.ToString("0.00") + "%";


                    }
                    else
                    {
                        finalGradelbl.Text += "Average Grade: 0.00%";
                    }
                }
                else
                {
                    finalGradelbl.Text = "Invalid weight format in currentComponent.Text";
                }
            }
            else
            {
                finalGradelbl.Text = "Invalid format in currentComponent.Text";
            }



        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            courseComboBox.Show();
            kryptonTextBox1.Show();
            pictureBox2.Show();
        }
        public void SetComponentButtonsEnabled(bool enabled)
        {
            foreach (Control control in ComponentsButtonPanel.Controls)
            {
                if (control is Component_Button_Card compButton)
                {
                    // Enable the button only if it is not graded
                    compButton.Enabled = enabled && !compButton.IsCurrentComponentButtonGraded;
                }
            }
        }
        private string grades = "";
        private void doneBtn_Click(object sender, EventArgs e)
        {
            if (_currentActiveComponentButton != null)
            {
                _currentActiveComponentButton.IsCurrentComponentButtonGraded = true;
                MessageBox.Show($"{_currentActiveComponentButton.compName} is marked as graded.");
                _currentActiveComponentButton = null;


                CheckAllComponentsGraded();


                SetComponentButtonsEnabled(true);
            }

            grades += $"{finalGradelbl.Text}\n";


            string input = finalGradelbl.Text;


            string[] parts = input.Split(':');

            if (parts.Length > 1)
            {

                string afterColon = parts[1].Trim();
                string percentageValue = afterColon.Replace("%", "");


                if (double.TryParse(percentageValue, out double result))
                {
                    _FinalGradesInEachComponents.Add(result);
                }

            }
        }
        private void CheckAllComponentsGraded()
        {
            bool allGraded = true;
            foreach (Control control in ComponentsButtonPanel.Controls)
            {
                if (control is Component_Button_Card componentCard)
                {
                    if (!componentCard.IsCurrentComponentButtonGraded)
                    {
                        allGraded = false;
                        break;
                    }
                }
            }


            saveGradeBtn.Visible = allGraded;

        }

        private void saveGradeBtn_Click(object sender, EventArgs e)
        {
            bool allGraded = true;
            foreach (Control control in ComponentsButtonPanel.Controls)
            {
                if (control is Component_Button_Card componentCard)
                {
                    if (!componentCard.IsCurrentComponentButtonGraded)
                    {
                        allGraded = false;
                        break;
                    }
                }
            }

            if (allGraded)
            {

                SaveGradesToFile();
            }
            else
            {
                MessageBox.Show("Please grade all components before saving.", "Incomplete Grading", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SaveGradesToFile()
        {
            try
            {

                string directoryPath = $"studentFinalGrades/{currentUSer}/";
                Directory.CreateDirectory(directoryPath);


                string selectedCourse = courseComboBox.SelectedItem.ToString();
                string courseCode = selectedCourse.Split('_')[0].Trim();


                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Term | {GradePeriodComboBox.Text}");
                sb.AppendLine($"Course Code | {courseCode}");
                sb.AppendLine($"Grade | {grades}");
                double totalFinalGrade = _FinalGradesInEachComponents.Sum();
                sb.AppendLine($"Total Final Grade | {totalFinalGrade.ToString("0.00")}%");
                sb.AppendLine($"-------------------");


                string filePath = Path.Combine(directoryPath, $"{StudentIDTXT.Text}.txt");

                // Write grades to file
                File.AppendAllText(filePath, sb.ToString());

                MessageBox.Show("Grades have been saved successfully.", "Save Grades", MessageBoxButtons.OK, MessageBoxIcon.Information);

                grades = "";
                _FinalGradesInEachComponents.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}