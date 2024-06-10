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
        private readonly string CurrentUSer;
        public createGradingSystemFORM(string currentUser)
        {
            CurrentUSer = currentUser;
            InitializeComponent();
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

                    // Update total weight
                    totalWeight += int.Parse(componentWeight);
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


        private void createGradingSystemFORM_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void saveGradingsytemBTN_Click(object sender, EventArgs e)
        {
            // Define the file path
            string directoryPath = $"CourseGradingSystem/{CurrentUSer}";
            string filePath = $"{directoryPath}/gradingSystem.txt";

            // Create the directory if it doesn't exist
            Directory.CreateDirectory(directoryPath);

            // Write the grading system information to the file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
            {
                foreach (Control control in flowLayoutPanel1.Controls)
                {
                    if (control is gradingSystemCARD)
                    {
                        gradingSystemCARD card = (gradingSystemCARD)control;

                        string componentName = card.ComponentTXT.Trim(); // Trim to remove leading and trailing whitespaces
                        string componentWeight = card.ComponentWeightTXT;

                        // Check if the component text is empty or equal to "Component" and the weight is 0
                        if (string.IsNullOrEmpty(componentName) || componentName == "Component")
                        {
                            // Skip saving this component
                            continue;
                        }

                        // Write to file only if the component text is not empty or equal to "Component" and the weight is not 0
                        file.WriteLine($"Component: {componentName}, Weight: {componentWeight}%");
                        file.WriteLine(new string('-', 40));
                    }
                }

                // Calculate total weight after writing to file
                UpdateTotalWeight();

                if (totalWeight != 100)
                {
                    MessageBox.Show($"Total weight must be equal to 100%. Current total weight is {totalWeight}%.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            MessageBox.Show("Grading system saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }




        private void totallWeightLLBL_Click(object sender, EventArgs e)
        {

        }
        public void UpdateTextFile(string deletedComponentName)
        {
            // Define the file path
            string filePath = $"CourseInformations/{CurrentUSer}/gradingSystem.txt";

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


    }
}
