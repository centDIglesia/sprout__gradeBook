using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class AddCourseForm : KryptonForm
    {
        private string currentUserName;

        public AddCourseForm(string currentUser)
        {
            currentUserName = currentUser;
            InitializeComponent();
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
           
        }

        

        private void saveNewCourseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string courseName = courseNameTXT.Text;
                string courseCode = courseCodeTXT.Text;
                string studentCourse = courseCourseTXT.Text;
                string studentSection = courseSectionTXT.Text;
                int studentCount = int.Parse(courseStudentCountTXT.Text);
                TimeSpan startTime = TimeSpan.Parse(courseStartTXT.Text);
                TimeSpan endTime = TimeSpan.Parse(courseEndTXT.Text);

                if (Course.ValidateSchedule(startTime, endTime))
                {
                    Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount);
                    newCourse.SaveCourse(currentUserName);
                    MessageBox.Show("Course added and saved successfully!");
                }
                else
                {
                    MessageBox.Show("Invalid course schedule. EndTime must be greater than StartTime.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid input values.");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
