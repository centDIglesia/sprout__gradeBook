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


            parent.Controls.Remove(this);


            _parentForm.UpdateTotalWeight();
            this.Dispose();


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

                    MessageBox.Show("Invalid input. Please enter a valid integer value for the weight.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    componentsWeightTXT.Text = "";
                }
            }
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
    }
}
