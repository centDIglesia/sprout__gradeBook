using System;
using System.Windows.Forms;
using System.Drawing;
namespace sprout__gradeBook
{
    public partial class CourseAndSectionCARD : UserControl
    {
        public new teacher__studentsDashboard ParentForm { get; set; } // Reference to the parent form




        public string SectionName
        {
            get => CoursecSectionOfStudent.Text;
            set => CoursecSectionOfStudent.Text = value;
        }

        public string Course
        {
            get => CoursecOfStudent.Text;
            set => CoursecOfStudent.Text = value;
        }

        public CourseAndSectionCARD(teacher__studentsDashboard parentForm)
        {
            InitializeComponent();
            ParentForm = parentForm;
        }



        private void CoursecSectionOfStudent_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.subsubhover;
            CoursecSectionOfStudent.BackColor = CustomColor.activeColor;
            CoursecOfStudent.ForeColor = CustomColor.activeColor;
        }


        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.susushoverleave;
            CoursecSectionOfStudent.BackColor = CustomColor.mainColor;
            CoursecOfStudent.ForeColor = CustomColor.mainColor;
        }

        private void CoursecSectionOfStudent_Click(object sender, EventArgs e)
        {




        }

    }


}
