using System;
using System.Windows.Forms;
using System.Drawing;
namespace sprout__gradeBook
{
    public partial class CourseAndSectionCARD : UserControl
    {
        public string CourseName
        {
            get => CourseOfStudent.Text;
            set => CourseOfStudent.Text = value;
        }

        public string SectionName
        {
            get => CoursecSectionOfStudent.Text;
            set => CoursecSectionOfStudent.Text = value;
        }

        public CourseAndSectionCARD()
        {
            InitializeComponent();
        }

        private void CourseOfStudent_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void CoursecSectionOfStudent_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.subsubhover;
            CourseOfStudent.BackColor = CustomColor.activeColor;
            CoursecSectionOfStudent.ForeColor = CustomColor.activeColor;
        }

        private void CoursecSectionOfStudent_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.susushoverleave;
            CourseOfStudent.BackColor = CustomColor.mainColor;
            CoursecSectionOfStudent.ForeColor = CustomColor.mainColor;
        }
    }
}
