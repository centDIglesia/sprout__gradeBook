using System;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class studentsInGradebookCARD : UserControl
    {


        private readonly teacher__GradeBook _teacherForm;
        public PictureBox MarkAsGraded { get; set; }

        public studentsInGradebookCARD(teacher__GradeBook teacherForm)
        {
            InitializeComponent();


            _teacherForm = teacherForm;

            MarkAsGraded = markAsGraded;
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




        private void studentsInGradebookCARD_Click(object sender, EventArgs e)
        {
            if (!_teacherForm.isFirstStudentClicked)
            {
                // For the first student, set the flag and proceed without checks
                _teacherForm.isFirstStudentClicked = true;
            }
            else
            {
                // For subsequent students, check if the current student is graded
                if (_teacherForm.isStudentGraded)
                {
                    _teacherForm.ResetComponentsForNewStudent();
                    _teacherForm.isStudentGraded = false; // Reset the flag for the next student
                }
                else
                {
                    var result = MessageBox.Show("You have not saved the grades for the current student. Do you want to proceed and discard unsaved changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                }
            }

            // Update student name and ID
            _teacherForm.StudenttnameText = currentStudentName;
            _teacherForm.StudentIDText = currentStudentID;

            MarkAsGraded.Visible = _teacherForm.IsStudentGraded(currentStudentID);
        }


        private void studentsInGradebookCARD_Load(object sender, EventArgs e)
        {
            markAsGraded.Hide();
        }

        private void MarkAsGraded_Click(object sender, EventArgs e)
        {

        }
    }

}
