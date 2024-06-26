using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

namespace sprout__gradeBook
{
    public partial class createGradingSystemFORM : KryptonForm
    {
        int totalWeight = 0;
        public readonly string CurrentUser;
        public readonly string CurrentsubjCode;
        public readonly string CurrentsubjDeptYearAndSection;
        public createGradingSystemFORM(string currentUser, string subjCode, string subjDeptYearAndSection)
        {
            CurrentUser = currentUser;
            InitializeComponent();
            CurrentsubjCode = subjCode;
            CurrentsubjDeptYearAndSection = subjDeptYearAndSection;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Create_GradingSystem_KeyDown);
        }
        private void Create_GradingSystem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveGradingsytemBTN_Click(sender, e);
                e.Handled = true;
            }

        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            // Check if total weight is less than 100
            if (totalWeight < 100)
            {
                // Create a new grading system card
                gradingSystemCARD newCard = new gradingSystemCARD(this)
                {
                    ComponentTXT = "Component",
                    ComponentWeightTXT = "0"
                };

                // Add the card to the flow layout panel
                flowLayoutPanel1.Controls.Add(newCard);

                // Update the total weight label
                UpdateTotalWeight();

                // Check if total weight is now equal to 100
                if (totalWeight == 100)
                {
                    // Hide the "Add Row" button
                    pictureBox3.Visible = false;
                }
            }
            else
            {
                // Inform the user that the total weight is already 100 or greater
                MessageBox.Show("Total weight is already 100% or greater. Cannot add more components.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void UpdateTotalWeight()
        {
            // Reset total weight
            totalWeight = 0;

            // Iterate through each control in the flow layout panel
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is gradingSystemCARD)
                {
                    // Cast the control to gradingSystemCARD
                    gradingSystemCARD card = (gradingSystemCARD)control;

                    // Extract component weight
                    string componentWeight = card.ComponentWeightTXT.ToString();

                    // Try to parse the component weight
                    int weight;
                    if (int.TryParse(componentWeight, out weight))
                    {
                        // Update total weight
                        totalWeight += weight;
                    }


                }
            }

            // Update the total weight label
            totallWeightLLBL.Text = $"Total Weight: {totalWeight}%";

            // Check if total weight is now equal to 100
            if (totalWeight == 100)
            {
                // Hide the "Add Row" button
                pictureBox3.Visible = false;
            }
            else
            {
                // Show the "Add Row" button
                pictureBox3.Visible = true;
            }
        }


        private void saveGradingsytemBTN_Click(object sender, EventArgs e)
        {

            // Check each gradingSystemCARD first
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is gradingSystemCARD card)
                {
                    string componentName = card.ComponentTXT.Trim();
                    string componentWeight = card.ComponentWeightTXT;

                    if (string.IsNullOrWhiteSpace(componentName) || componentName == "Component")
                    {
                        MessageBox.Show("Invalid input. Please enter a valid component name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        card.ComponentTextBox.Focus();
                        return; // Do not save and exit the method
                    }

                    if (string.IsNullOrEmpty(componentWeight) || componentWeight == "0")
                    {
                        MessageBox.Show("Invalid input. Please enter a valid component weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        card.ComponentWeightTextBox.Focus(); // Set focus to the textbox with error
                        return; // Do not save and exit the method
                    }
                }
            }

            // Then check totalWeight
            UpdateTotalWeight();

            if (totalWeight != 100)
            {
                MessageBox.Show($"Total weight must be equal to 100%. Current total weight is {totalWeight}%.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If all checks pass, proceed to save
            string baseDirectoryPath = $"CourseGradingSystem/{CurrentUser}/{CurrentsubjCode}_{CurrentsubjDeptYearAndSection}";
            string filePath = Path.Combine(baseDirectoryPath, "gradingSystem.txt");

            // Create the base directory if it doesn't exist
            Directory.CreateDirectory(baseDirectoryPath);

            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is gradingSystemCARD card)
                {
                    string componentName = card.ComponentTXT.Trim();
                    string componentWeight = card.ComponentWeightTXT;

                    using (StreamWriter file = new StreamWriter(filePath, true))
                    {
                        file.WriteLine($"{componentName},{componentWeight}%");
                        file.WriteLine(new string('-', 40));
                    }
                }
            }

            MessageBox.Show("Grading system saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        public void UpdateTextFile(string deletedComponentName)
        {
            // Define the file path
            string filePath = $"CourseInformations/{CurrentUser}/gradingSystem.txt";

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);

            // Find and remove the entry corresponding to the deleted card
            List<string> updatedLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                // Check if the line contains component information of the deleted card
                if (lines[i].Contains($"Component: {deletedComponentName}"))
                {
                    // Skip this line and the next line (which contains the dashes)
                    i++;
                }
                else
                {
                    updatedLines.Add(lines[i]);
                }
            }

            // Write the updated lines back to the file
            File.WriteAllLines(filePath, updatedLines);
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {
            utilityButton Close = new utilityButton();
            Close.Cancelform(this);
        }

        private void createGradingSystemFORM_Load(object sender, EventArgs e)
        {

        }
    }
}
