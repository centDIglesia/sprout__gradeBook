using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class ComponentGradesCARD : UserControl
    {

        private CalculateAndDisplayFinalGradeDelegate _methodCalculateAndDisplayFinalGrade;

        public ComponentGradesCARD(CalculateAndDisplayFinalGradeDelegate CalculateAndDisplayFinalGrade)
        {
            InitializeComponent();
            _methodCalculateAndDisplayFinalGrade = CalculateAndDisplayFinalGrade;


            compGrade.KeyPress += TextBox_KeyPress;
            compMaxGrade.KeyPress += TextBox_KeyPress;


            compGrade.Validating += CompGrade_Validating;
            compMaxGrade.Validating += CompMaxGrade_Validating;

        }


        public string ComponentNumber
        {
            get => compNumber.Text;
            set => compNumber.Text = value;
        }

        public double ComponentGrade
        {
            get
            {
                double grade;
                if (double.TryParse(compGrade.Text, out grade))
                {
                    return grade;
                }
                return 0;
            }
            set => compGrade.Text = value.ToString();
        }

        public double ComponentMaximumGrade
        {
            get
            {
                double maxGrade;
                if (double.TryParse(compMaxGrade.Text, out maxGrade))
                {
                    return maxGrade;
                }
                return 100;
            }
            set => compMaxGrade.Text = value.ToString();
        }

        public double ComponentPercentageGrade
        {
            get
            {
                double grade = ComponentGrade;
                double maxGrade = ComponentMaximumGrade;

                if (maxGrade == 0)
                {
                    return 0;
                }

                return (grade / maxGrade) * 100;
            }
            set => compPercentage.Text = value.ToString("0.00") + "%";
        }



        private void CalculateAndDisplayPercentage()
        {


            if (double.TryParse(compGrade.Text, out double grade) && double.TryParse(compMaxGrade.Text, out double maxGrade) && maxGrade > 0)
            {

                double percentage = (grade / maxGrade) * 100;

                compPercentage.Text = percentage.ToString("0.00") + "%";
            }
            else
            {

                compPercentage.Text = "0.00" + "%";
            }
            _methodCalculateAndDisplayFinalGrade();

        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allowing only numeric input and one decimal point
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains('.'))
            {
                e.Handled = true;
            }
        }


        private void CompGrade_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(compGrade.Text, out double grade) || grade < 0 || grade > 1000)
            {
                MessageBox.Show($"Student Grade must be a valid number between 0 and 1000.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                compGrade.Clear();
                compGrade.Focus();
            }
        }

        private void CompMaxGrade_Validating(object sender, CancelEventArgs e)
        {
            double studentScore = ComponentGrade;

            if (!double.TryParse(compMaxGrade.Text, out double maxGrade) || maxGrade < 0 || maxGrade < studentScore)
            {
                MessageBox.Show("Maximum Grade must be higher or equal to Student Grade.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                compMaxGrade.Clear();
                compMaxGrade.Focus();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void compGrade_TextChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayPercentage();

        }

        private void compMaxGrade_TextChanged(object sender, EventArgs e)
        {
            CalculateAndDisplayPercentage();
        }

        private void compPercentage_TextChanged(object sender, EventArgs e)
        {

        }

        private void compNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void compGrade_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(compGrade, "0");
        }

        private void compGrade_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(compGrade, "0");

        }

        private void compMaxGrade_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(compMaxGrade, "99.9");
        }
        private void compMaxGrade_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(compMaxGrade, "99.9");

        }


    }
}
