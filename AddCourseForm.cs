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
                string courseAndSection = studentCourse + studentSection;
                int studentCount = int.Parse(courseStudentCountTXT.Text);
                string startTime = courseStartTXT.Text;
                string endTime = courseEndTXT.Text;

                Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount);
                newCourse.StartTime = startTime;
                newCourse.EndTime = endTime;
                newCourse.SaveCourse(currentUserName);
                MessageBox.Show("Course added and saved successfully!");
                this.Close();

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


        private void courseStartTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseStartTXT, "00:00");
        }

        private void courseStartTXT_Leave(object sender, EventArgs e)
        {
            if (IsValid12HourTimeFormat(courseStartTXT.Text))
            {
                UserInput_Manager.RestoreDefaultText(courseStartTXT, "00:00");
            }
            else
            {
                MessageBox.Show("Please enter a valid time in 12-hour format (e.g., 01:00 PM).");
                courseStartTXT.Focus(); // Bring focus back to the TextBox for correction
            }
        }




        private void courseEndTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseEndTXT, "00:00");
        }




        private void courseEndTXT_Leave(object sender, EventArgs e)
        {
            if (IsValid12HourTimeFormat(courseEndTXT.Text))
            {
                UserInput_Manager.RestoreDefaultText(courseEndTXT, "00:00");
            }
            else
            {
                MessageBox.Show("Please enter a valid time in 12-hour format (e.g., 01:00 PM).");
                courseEndTXT.Focus(); // Bring focus back to the TextBox for correction
            }
        }

        public static bool IsValid12HourTimeFormat(string input)
        {
            // Regular expression for 12-hour time format with optional AM/PM
            string pattern = @"^((0[1-9])|(1[0-2])):([0-5][0-9])\s?(AM|PM)$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }
    }
}
