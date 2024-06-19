using System;
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

        private void compMaxGrade_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(compMaxGrade, "0");
        }

        private void compMaxGrade_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(compMaxGrade, "0");
        }

        private void compGrade_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(compGrade, "0");
        }
    }
}
