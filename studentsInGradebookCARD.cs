using System;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class studentsInGradebookCARD : UserControl
    {

        private teacher__GradeBook _teacherForm;

        public studentsInGradebookCARD(teacher__GradeBook teacherForm)
        {
            InitializeComponent();
            _teacherForm = teacherForm;
        }



        public string currentStudentName
        {
            get => nameofStudent.Text;
            set => nameofStudent.Text = value;
        }

        public string currentStudentID
        {
            get => idOfStudent.Text;
            set => idOfStudent.Text = value;
        }

        private void idOfStudent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nameofStudent_Paint(object sender, PaintEventArgs e)
        {

        }

        private void studentsInGradebookCARD_Click(object sender, EventArgs e)
        {
          
            _teacherForm.StudenttnameText = currentStudentName;
            _teacherForm.StudentIDText = currentStudentID;
        }

        private void studentsInGradebookCARD_Load(object sender, EventArgs e)
        {

        }
    }
}
