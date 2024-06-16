using System;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class studentsInGradebookCARD : UserControl
    {

        // Private field to hold reference to the teacher's grade book form
        private readonly teacher__GradeBook _teacherForm;

        // Constructor for the studentsInGradebookCARD class
        public studentsInGradebookCARD(teacher__GradeBook teacherForm)
        {
            InitializeComponent();

            // Initialize _teacherForm with the provided teacherForm instance
            _teacherForm = teacherForm;
        }

        // Property to get/set the current student's name
        public string currentStudentName
        {
            get => nameofStudent.Text;   // Return the text of nameofStudent control
            set => nameofStudent.Text = value;   // Set the text of nameofStudent control
        }

        // Property to get/set the current student's ID
        public string currentStudentID
        {
            get => idOfStudent.Text;   // Return the text of idOfStudent control
            set => idOfStudent.Text = value;   // Set the text of idOfStudent control
        }

        // Event handler for the click event of the form
        private void studentsInGradebookCARD_Click(object sender, EventArgs e)
        {
            // When the form is clicked, update the teacher's grade book form
            _teacherForm.StudenttnameText = currentStudentName;   // Update student name in teacher form
            _teacherForm.StudentIDText = currentStudentID;   // Update student ID in teacher form
        }

    }

}
