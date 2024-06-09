using System;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class studentsInGradebookCARD : UserControl
    {


        public studentsInGradebookCARD()
        {
            InitializeComponent();
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

        private void idOfStudent_Click(object sender, EventArgs e)
        {

        }

        private void studentsInGradebookCARD_Load(object sender, EventArgs e)
        {

        }

        private void nameofStudent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
