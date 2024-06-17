using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class teacher__mainDashboard : KryptonForm
    {
        // Constructor for the teacher main dashboard form
        public teacher__mainDashboard(string currentUser)
        {
            InitializeComponent();

            // Update counts on initialization
            UpdateCourseCount(currentUser);
            UpdateStudentCount(currentUser);
            UpdateSectionCount(currentUser);
        }
        // Update the displayed count of courses
        private void UpdateCourseCount(string currentUser)
        {
            int count = Course.GetCourseCount(currentUser);
            course__quantity.Text = count.ToString();
        }

        // Update the displayed count of students
        private void UpdateStudentCount(string currentUser)
        {
            int count = StudentManager.GetStudentCount(currentUser);
            student__quantity.Text = count.ToString();
        }

        // Update the displayed count of sections
        private void UpdateSectionCount(string currentUser)
        {
            int count = Course.GetSectionsCount(currentUser);
            sections__quantity.Text = count.ToString();
        }
    }
}
