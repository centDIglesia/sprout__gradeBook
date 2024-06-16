﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;

namespace sprout__gradeBook
{
    public delegate void CalculateAndDisplayFinalGradeDelegate();
    public delegate void displayGradeBookPanelDelegate();

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

            genderPict.Hide();
            StudentIDTXT.Hide();
            StudenttnameTXT.Hide();
            sectionTXT.Hide();
            ComponentsButtonPanel.Hide();


            //display this if the componentsButton is clicked
            pictureBox4.Hide();
            addSubcomponents.Hide();
            saveGradeBtn.Hide();
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
            saveGradeBtn.Show();
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



        int componentCount = 0;
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
                subcomponentsPane.Controls.Add(componentCard);

                subcomponentsPane.Refresh();

                CalculateAndDisplayFinalGrade();
            }

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
                    foreach (Control control in subcomponentsPane.Controls)
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
    }
}