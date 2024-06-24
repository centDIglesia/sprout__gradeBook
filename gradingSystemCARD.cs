using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            componentsWeightTXT.KeyPress += new KeyPressEventHandler(componentsWeightTXT_KeyPress);
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

                    return weight.ToString();
                }
                else
                {

                    MessageBox.Show("Invalid input. Please enter a valid integer value for the weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


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

            // Store the component name before removing the card
            string componentName = ComponentTXT;

            parent.Controls.Remove(this);

            _parentForm.UpdateTotalWeight();
            this.Dispose();

            string filePath = $"CourseInformations/{_parentForm.CurrentUser}/gradingSystem.txt";
            if (File.Exists(filePath))
            {
                _parentForm.UpdateTextFile(componentName);
            }

        }

        private void componentsWeightTXT_Leave(object sender, EventArgs e)
        {
            _parentForm.UpdateTotalWeight();
        }

        private void componentsWeightTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void componentsTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void componentsTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(componentsTXT, "Component");
        }


        private void componentsWeightTXT_Enter_1(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(componentsWeightTXT, "0");
        }

        private void componentsWeightTXT_Leave_1(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(componentsWeightTXT, "0");
        }

        private void componentsTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(componentsTXT, "Component");
        }

        private void componentsWeightTXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                // If not, suppress the key press
                e.Handled = true;
            }
        }

        private void componentsWeightTXT_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(componentsWeightTXT.Text))
            {
                if (int.TryParse(componentsWeightTXT.Text, out int weight))
                {

                    _parentForm.UpdateTotalWeight();
                }
                else
                {

                    MessageBox.Show("Invalid input. Please enter a valid integer value for the weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    componentsWeightTXT.Text = "";
                }
            }
        }
    }
}
