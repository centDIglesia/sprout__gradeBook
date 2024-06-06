using System;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class AddCourseForm : KryptonForm
    {
        private string currentUserName;
        private teacher__courses_lvl1 parentForm;

        public AddCourseForm(string currentUser, teacher__courses_lvl1 parent)
        {
            currentUserName = currentUser;
            parentForm = parent;
            InitializeComponent();
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
        }

        private void saveNewCourseBTN_Click(object sender, EventArgs e)
        {

            string courseName = courseNameTXT.Text;
            string courseCode = courseCodeTXT.Text;
            string studentCourse = courseCourseTXT.Text;
            string studentSection = courseSectionTXT.Text;
            int studentCount = int.Parse(courseStudentCountTXT.Text);
            string startTime = courseStartTXT.Text;
            string endTime = courseEndTXT.Text;

            Course newCourse = new Course(courseName, courseCode, studentCourse, studentSection, startTime, endTime, studentCount);
            newCourse.SaveCourse(currentUserName);

            MessageBox.Show("Course added and saved successfully!");
            this.Close();

            parentForm.Enabled = true;
            parentForm.populateCourses();


            string folderPath = "StudentInMyCourse";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string fileName = $"{currentUserName}_{studentCourse}_{studentSection}.txt";
            string filePath = Path.Combine(folderPath, fileName);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
            }


        }

        private void courseStartTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseStartTXT, "00:00 PM");
        }

        private void courseStartTXT_Leave(object sender, EventArgs e)
        {
            if (!IsValid12HourTimeFormat(courseStartTXT.Text))
            {
                MessageBox.Show("Please enter a valid time in 12-hour format (e.g., 01:00 PM).");
                courseStartTXT.Focus();
            }
            else
            {
                UserInput_Manager.RestoreDefaultText(courseStartTXT, "00:00 PM");
            }
        }

        private void courseEndTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(courseEndTXT, "00:00 PM");
        }

        private void courseEndTXT_Leave(object sender, EventArgs e)
        {
            if (!IsValid12HourTimeFormat(courseEndTXT.Text))
            {
                MessageBox.Show("Please enter a valid time in 12-hour format (e.g., 01:00 PM).");
                courseEndTXT.Focus();
            }
            else
            {
                UserInput_Manager.RestoreDefaultText(courseEndTXT, "00:00 PM");
            }
        }

        public static bool IsValid12HourTimeFormat(string input)
        {
            string pattern = @"^(0[1-9]|1[0-2]):([0-5][0-9])\s?(AM|PM)$";
            return System.Text.RegularExpressions.Regex.IsMatch(input, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        }

        private void courseStartTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }

        private void courseSectionTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }

        private void courseEndTXT_TextChanged(object sender, EventArgs e)
        {
            // Add any logic needed on text change
        }

        private void courseStudentCountTXT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
