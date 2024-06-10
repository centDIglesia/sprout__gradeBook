using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class gradingSystemCARD : UserControl
    {
        private readonly createGradingSystemFORM _parentForm;

        public gradingSystemCARD(createGradingSystemFORM parent)
        {
            _parentForm = parent;
            InitializeComponent();
        }

        public string ComponentTXT
        {
            get => componentsTXT.Text;
            set => componentsTXT.Text = value;
        }

        public string ComponentWeightTXT
        {
            get
            {
                if (int.TryParse(componentsWeightTXT.Text, out int weight))
                {
                    // Successful parsing, return the parsed value as a string
                    return weight.ToString();
                }
                else
                {
                    // Parsing failed, handle the error as needed
                    // For example, you can display an error message
                    MessageBox.Show("Invalid input. Please enter a valid integer value for the weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Return an empty string or any default value
                    return "";
                }
            }
            set => componentsWeightTXT.Text = value;
        }






        private void gradingSystemCARD_Load(object sender, EventArgs e)
        {

        }

        private void detethisCardbtn_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;

            // Remove this card from the parent control
            parent.Controls.Remove(this);

            // Dispose of this card to release resources
            _parentForm.UpdateTotalWeight();
            this.Dispose();

            // Update the text file
            _parentForm.UpdateTextFile(ComponentTXT);
        }

        private void componentsWeightTXT_Leave(object sender, EventArgs e)
        {
            _parentForm.UpdateTotalWeight();
        }

        private void componentsWeightTXT_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(componentsWeightTXT.Text))
            {
                if (int.TryParse(componentsWeightTXT.Text, out int weight))
                {

                    _parentForm.UpdateTotalWeight();
                }
                else
                {
                    // If parsing fails, handle the error here (e.g., display a message)
                    MessageBox.Show("Invalid input. Please enter a valid integer value for the weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Optionally, you can clear the text box or revert to the previous value
                    componentsWeightTXT.Text = ""; // Clear the text box
                }
            }
        }

    }
}
