using System;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class ComponentGradesCARD : UserControl
    {
        public ComponentGradesCARD()
        {
            InitializeComponent();
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
            set => compPercentage.Text = value.ToString("0.00");
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
