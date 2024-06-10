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
        public addCourseComponentsFORM(string currentUser)
        {
            InitializeComponent();

            CurrentUser = currentUser;
            LoadComponents();
        }

        private void LoadComponents()
        {
            // Define the file path
            string filePath = $"CourseInformations/{CurrentUser}/gradingSystem.txt";

            // Check if the file exists
            if (File.Exists(filePath))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Add each component to the combo box
                foreach (string line in lines)
                {
                    if (line.StartsWith("Component:"))
                    {
                        // Extract the component name
                        string componentName = line.Substring(line.IndexOf(":") + 2);

                        // Add the component to the combo box
                        componentComboBox.Items.Add(componentName);
                    }
                }
            }
            else
            {
                MessageBox.Show("Grading system file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
    }
}
