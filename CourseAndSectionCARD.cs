using System;
using System.Windows.Forms;
using System.Drawing;
namespace sprout__gradeBook
{
    public partial class CourseAndSectionCARD : UserControl
    {
        public new teacher__studentsDashboard ParentForm { get; set; } // Reference to the parent form




        public string CourseCode
        {
            get => CourseOfStudent.Text;
            set => CourseOfStudent.Text = value;
        }

        public string SectionName
        {
            get => CoursecSectionOfStudent.Text;
            set => CoursecSectionOfStudent.Text = value;
        }

        public CourseAndSectionCARD(teacher__studentsDashboard parentForm)
        {
            InitializeComponent();
            ParentForm = parentForm;
        }



        private void CoursecSectionOfStudent_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.subsubhover;
            CourseOfStudent.BackColor = CustomColor.activeColor;
            CoursecSectionOfStudent.ForeColor = CustomColor.activeColor;
        }


        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.susushoverleave;
            CourseOfStudent.BackColor = CustomColor.mainColor;
            CoursecSectionOfStudent.ForeColor = CustomColor.mainColor;
        }

        private void CoursecSectionOfStudent_Click(object sender, EventArgs e)
        {

            addStudentDashboard addStudentForm = new addStudentDashboard(ParentForm.currentUSer, CourseCode, SectionName);


            ParentForm.LoadFormIntoPanel(addStudentForm);
            ParentForm.hidePanel();
        }

    }


}
