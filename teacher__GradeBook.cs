using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace sprout__gradeBook
{
    public delegate void CalculateAndDisplayFinalGradeDelegate();
    public delegate void displayGradeBookPanelDelegate();

    public partial class teacher__GradeBook : KryptonForm
    {

        public Component_Button_Card _currentActiveComponentButton;
        public static teacher__GradeBook _gradeBook;
        List<double> _FinalGradesInEachComponents = new List<double>();
        bool allGraded;
        public string selectedGradePeriod;
        public string selectedCourse;

        public bool isFirstStudentClicked { get; set; } = false;

        public bool isStudentGraded { get; set; } = false;


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
        public Dictionary<string, bool> StudentGradedStatus { get; set; } = new Dictionary<string, bool>();

        public bool IsStudentGraded(string studentID)
        {
            return StudentGradedStatus.ContainsKey(studentID) && StudentGradedStatus[studentID];
        }

        private void teacher__GradeBook_Load(object sender, EventArgs e)
        {
            LoadTxtFilesIntoComboBox(currentUSer);
            courseComboBox.SelectedIndexChanged += CourseComboBox_SelectedIndexChanged;
            GradePeriodComboBox.SelectedIndexChanged += GradePeriodComboBox_SelectedIndexChanged_1;
            HideInitialElements();
        }


        private void HideInitialElements()
        {
            genderPict.Hide();
            StudentIDTXT.Hide();
            StudenttnameTXT.Hide();
            sectionTXT.Hide();
            ComponentsButtonPanel.Hide();



            pictureBox4.Hide();
            addSubcomponents.Hide();
            saveGradeBtn.Visible = false;

            doneBtn.Hide();

            courseComboBox.Hide();
            kryptonTextBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();

        }


        private void LoadTxtFilesIntoComboBox(string currentUser)
        {
            string directoryPath = $"CourseInformations/{currentUser}/";

            if (!Directory.Exists(directoryPath))
            {
                MessageBox.Show(
      "Please ensure you have added the course details and set up the grading system before proceeding.\n\n To add a course, navigate to the 'Courses' section and click on 'Add New Course'.\n\n Then, click on the course and add a 'Grading System' by selecting the 'Grading System' button and setting up the required components.",
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

            // Disable courseComboBox immediately after a value is selected

            this.selectedCourse = courseComboBox.SelectedItem.ToString();
            string[] trimmedCourseParts = selectedCourse.Split('_');

            if (trimmedCourseParts.Length == 2)
            {
                string trimmedCourseName = trimmedCourseParts[1].Trim();
                string studentFilePath = $"StudentCredentials/{currentUSer}/DepartmentandSections/{trimmedCourseName}.txt";

                if (!File.Exists(studentFilePath))
                {
                    MessageBox.Show("No students found for the selected course. Please add students before proceeding.", "No Students Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
            pictureBox3.Show();
        }
        public void DisplayIfCompButtonIsclicked()
        {
            pictureBox4.Show();
            addSubcomponents.Show();

            doneBtn.Show();

        }

        private void LoadStudentCards(string filePath)
        {

            studentListPanel.Controls.Clear();

            try
            {

                string[] lines = File.ReadAllLines(filePath);

                string studentID = null;
                string studentName = null;

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

                    if (!string.IsNullOrEmpty(studentID) && !string.IsNullOrEmpty(studentName))
                    {
                        AddStudentCard(studentID, studentName);
                        studentID = null;
                        studentName = null;
                    }
                }

                if (studentListPanel.Controls.Count == 0)
                {
                    MessageBox.Show("No students found in the selected course. Please add students before proceeding.", "No Students Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error loading student data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddStudentCard(string studentID, string studentName)
        {
            studentsInGradebookCARD studentCard = new studentsInGradebookCARD(this, subcomponentsPanel, ComponentsButtonPanel, addSubcomponents, CurrentGradePeriod, pictureBox3)
            {
                currentStudentID = studentID,
                currentStudentName = studentName
            };

            studentListPanel.Controls.Add(studentCard);
        }



        private void kryptonComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sectionTXT.Text = RemoveSubstring(courseComboBox.Text, "_", ",");
            CurrentGradePeriod.Text = "Please select a Student First";

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


                        Component_Button_Card componentCard = new Component_Button_Card(currentComponent, DisplayIfCompButtonIsclicked, CurrentGradePeriod)
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
                MessageBox.Show(
             "No grading system for the selected course yet. Please create it first. Thank you!",
             "Error",
             MessageBoxButtons.OK,
             MessageBoxIcon.Error

         );
                return;

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
        private void addSubcomponents_Click_1(object sender, EventArgs e)
        {
            CurrentGradePeriod.Text = "Click 'Done' after grading all subcomponents.";


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
                    ComponentGrade = 0,
                    ComponentMaximumGrade = 0,

                };
                subcomponentsPanel.Controls.Add(componentCard);



                CalculateAndDisplayFinalGrade();
            }

        }

        public void clearSubcomponentsPanel()
        {
            subcomponentsPanel.Controls.Clear();
        }

        //finalGradelbl
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
                            if (componentCard.ComponentMaximumGrade != 0)
                            {
                                totalPercentage += componentCard.ComponentPercentageGrade;
                                componentCardCount++;
                            }

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

        public void SetComponentButtonsEnabled(bool enabled)
        {
            foreach (Control control in ComponentsButtonPanel.Controls)
            {
                if (control is Component_Button_Card compButton)
                {

                    compButton.Enabled = enabled && !compButton.IsCurrentComponentButtonGraded;
                }
            }
        }



        private string grades = "";

        private void doneBtn_Click_1(object sender, EventArgs e)
        {
            if (allGraded)
            {
                CurrentGradePeriod.Text = "Please click 'Save' button to record.";
            }
            else
            {
                CurrentGradePeriod.Text = "Please select another component to grade.";
            }

            if (subcomponentsPanel.Controls.Count == 0)
            {
                MessageBox.Show("No grades have been entered yet. Please ensure to add subcomponents for each student and input their respective grades before attempting to save. \n\nThis helps to maintain accurate and comprehensive grading records.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (Control control in subcomponentsPanel.Controls)
            {
                if (control is ComponentGradesCARD componentCard)
                {
                    double componentGrade = componentCard.ComponentGrade;
                    double componentMaximumGrade;

                    // Ensure the componentMaximumGrade is a valid number and not empty
                    if (string.IsNullOrWhiteSpace(componentCard.ComponentMaximumGradeText) ||
                        !double.TryParse(componentCard.ComponentMaximumGradeText, out componentMaximumGrade) ||
                        componentMaximumGrade == 0)
                    {
                        MessageBox.Show($"Component Maximum Grade cannot be empty, zero, or invalid.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        componentCard.Focus();
                        return;
                    }

                    if (componentGrade > componentMaximumGrade)
                    {
                        MessageBox.Show($"Component Grade {componentGrade} cannot be higher than Component Maximum Grade {componentMaximumGrade}.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        componentCard.Focus();
                        return;
                    }
                }
            }

            if (_currentActiveComponentButton != null)
            {
                _currentActiveComponentButton.IsCurrentComponentButtonGraded = true;
                MessageBox.Show($"{_currentActiveComponentButton.compName} is marked as graded.");
                _currentActiveComponentButton = null;

                CheckAllComponentsGraded();
                SetComponentButtonsEnabled(true);
                CheckIfAllStudentsGraded();
                HideSubcomponentsAndDoneBtn();
                ResetSubcomponentsPanel();
                UpdateComponentPanelVisibility();
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
            allGraded = true;
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

        private void saveGradeBtn_Click_1(object sender, EventArgs e)
        {

            IsTermAlreadyGraded(StudentIDText, GradePeriodComboBox.SelectedItem?.ToString());

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
                isStudentGraded = true;
                SaveGradesToFile();


                // Mark the current student as graded
                if (!StudentGradedStatus.ContainsKey(StudentIDText))
                {
                    StudentGradedStatus.Add(StudentIDText, true);
                }
                else
                {
                    StudentGradedStatus[StudentIDText] = true;
                }


                var currentCard = studentListPanel.Controls
                    .OfType<studentsInGradebookCARD>()
                    .FirstOrDefault(c => c.currentStudentID == StudentIDText);

                if (currentCard != null)
                {
                    currentCard.MarkAsGraded.Visible = true;
                }

                // Check if all students are graded
                CheckIfAllStudentsGraded(true); // Pass true to show the message now

            }
            else
            {
                MessageBox.Show("Please grade all components before saving.", "Incomplete Grading", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            HideGradingElements();
        }

        private void HideGradingElements()
        {
            saveGradeBtn.Visible = false;
            ComponentsButtonPanel.Visible = false;
            pictureBox4.Visible = false;
            subcomponentsPanel.Visible = false;
            addSubcomponents.Visible = false;
            doneBtn.Visible = false;
            currentComponent.Visible = false;
            pictureBox3.Visible = false;


        }
        private void ShowGradingElements()
        {
            saveGradeBtn.Visible = true;
            ComponentsButtonPanel.Visible = true;
            pictureBox4.Visible = true;
            subcomponentsPanel.Visible = true;
            addSubcomponents.Visible = true;
            doneBtn.Visible = true;
            pictureBox3.Visible = true;
        }

        private void SaveGradesToFile()
        {
            try
            {

                string directoryPath = $"studentFinalGrades/{currentUSer}/{this.selectedCourse}/";
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

                MessageBox.Show(
             $"Grades for {StudenttnameTXT.Text} have been successfully recorded for the course '{courseCode}'.",
             "Grades Recorded Successfully",
             MessageBoxButtons.OK,
             MessageBoxIcon.Information
         );

                grades = "";
                _FinalGradesInEachComponents.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ResetComponentsForNewStudent()
        {
            // Clear subcomponentsPanel
            subcomponentsPanel.Controls.Clear();

            // Reset each component button and enable it
            foreach (Control control in ComponentsButtonPanel.Controls)
            {
                if (control is Component_Button_Card componentButton)
                {
                    componentButton.IsCurrentComponentButtonGraded = false;
                    componentButton.Enabled = true; // Re-enable the button
                }
            }

            // Reset other necessary fields and states
            saveGradeBtn.Hide();
            _currentActiveComponentButton = null;
            componentCount = 0;
            finalGradelbl.Text = string.Empty;
            grades = string.Empty;
            _FinalGradesInEachComponents.Clear();
            isStudentGraded = false; // Reset the flag
        }


        public bool IsTermAlreadyGraded(string studentID, string term)
        {
            string directoryPath = $"studentFinalGrades/{currentUSer}/{this.selectedCourse}/";
            string filePath = Path.Combine(directoryPath, $"{studentID}.txt");

            if (!File.Exists(filePath))
            {
                return false;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.StartsWith("Term |") && line.Contains(term))
                {
                    return true;
                }
            }

            return false;
        }


        public void CheckIfAllStudentsGraded(bool showMessageIfAllGraded = false)
        {
            bool allGraded = true;

            foreach (Control control in studentListPanel.Controls)
            {
                if (control is studentsInGradebookCARD studentCard)
                {
                    if (!IsStudentGraded(studentCard.currentStudentID))
                    {
                        allGraded = false;
                        break;
                    }
                }
            }

            if (allGraded)
            {
                if (showMessageIfAllGraded)
                {
                    MessageBox.Show("All students have been graded.", "All Students Graded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }

        private void GradePeriodComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            studentListPanel.Controls.Clear();
            ComponentsButtonPanel.Controls.Clear();
            selectedGradePeriod = GradePeriodComboBox.SelectedItem?.ToString();
            courseComboBox.Show();
            kryptonTextBox1.Show();
            pictureBox2.Show();


        }

        private void UpdateComponentPanelVisibility()
        {
            // Get the current student ID and check if graded
            string studentID = StudentIDText;
            bool isGraded = IsTermAlreadyGraded(studentID, GradePeriodComboBox.SelectedItem?.ToString());

            // Hide the panels if the student is graded
            subcomponentsPanel.Visible = !isGraded;
            ComponentsButtonPanel.Visible = !isGraded;
        }

        public void ShowSubcomponentsAndDoneBtn()
        {
            addSubcomponents.Show();
            doneBtn.Show();
        }

        public void HideSubcomponentsAndDoneBtn()
        {
            addSubcomponents.Hide();
            doneBtn.Hide();
        }

        public void ResetSubcomponentsPanel()
        {
            subcomponentsPanel.Controls.Clear();
            componentCount = 0;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
