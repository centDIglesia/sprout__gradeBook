using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

namespace sprout__gradeBook
{
    public partial class addCourseComponentsFORM : KryptonForm
    {
        private readonly string CurrentUser;
        private readonly string subjectcode;
        private readonly string subjectsection;

        public addCourseComponentsFORM(string currentUser, string subCode, string subSection)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            subjectcode = subCode;
            subjectsection = subSection;
            LoadComponents();
        }

        private void LoadComponents()
        {
            // Define the directory path
            string directoryPath = $"CourseGradingSystem/{CurrentUser}";

            // Check if the directory exists
            if (Directory.Exists(directoryPath))
            {
                // Get all text files in the directory
                string[] filePaths = Directory.GetFiles(directoryPath, "gradingSystem.txt");

                // Loop through each file path
                foreach (string filePath in filePaths)
                {
                    // Read all lines from the file
                    string[] lines = File.ReadAllLines(filePath);

                    // Loop through each line in the file
                    foreach (string line in lines)
                    {
                        if (line.StartsWith("Component:"))
                        {
                            // Extract the component name
                            string componentName = line.Substring(line.IndexOf(":") + 2).Trim();

                            // Add the component to the combo box
                            componentComboBox.Items.Add(componentName);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Grading system directory not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddSubComponent_BTN_Click(object sender, EventArgs e)
        {            
            if (componentComboBox.SelectedItem != null)
            {             
                string selectedComponent = componentComboBox.SelectedItem.ToString();
                
                int endIndex = selectedComponent.IndexOf(","); 
                if (endIndex > 0)
                {
                    string componentName = selectedComponent.Substring(0, endIndex).Trim();

                    string modifiedSection = RemoveStringBetweenCharacters(subjectsection, ',');
                    string directoryPath = $"CourseGradingSystem/{CurrentUser}/gradingSystem/{componentName}/{subjectcode},{modifiedSection}.txt";

                    MessageBox.Show($"Adding subcomponent to: {directoryPath}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    using (StreamWriter file = new StreamWriter(directoryPath, true))
                    {
                        file.WriteLine($"{componentName} # : {componentNumber.Text}");
                        file.WriteLine($"{componentName} {componentNumber.Text} items : {numberOfItems.Text}");
                        file.WriteLine($"{componentName} {componentNumber.Text} max grade : {maximunGrade.Text}");
                        file.WriteLine(new string('-', 40));
                    }
                }
                else
                {
                    MessageBox.Show("Invalid component format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a component first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static string RemoveStringBetweenCharacters(string input, char delimiter)
        {
            int firstCommaIndex = input.IndexOf(delimiter);
            int secondCommaIndex = input.IndexOf(delimiter, firstCommaIndex + 1);

            if (firstCommaIndex == -1 || secondCommaIndex == -1 || firstCommaIndex >= secondCommaIndex)
            {
                return input; // If commas are not found or in an invalid state, return the input as is
            }

            // Construct the result by removing the string between the first and second commas
            string result = input.Substring(0, firstCommaIndex) + input.Substring(secondCommaIndex);
            return result;
        }


        private void kryptonTextBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
