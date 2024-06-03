using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class EditCourse : KryptonForm
    {
        private string currentUser;
        private string originalSubjectName;
        private string originalSubjectCode;
        private string subjectName;
        private string subjectCode;
        private string subjectCount;
        private string subjectSchedule;
        private string subjectCourseSection;

        public EditCourse(string currentUsername, string name, string code, string count, string schedule, string section)
        {
            InitializeComponent();
            currentUser = currentUsername;
            originalSubjectName = name; // Store original values for comparison
            originalSubjectCode = code; // Store original values for comparison
            subjectName = name;
            subjectCode = code;
            subjectCount = count;
            subjectSchedule = schedule;
            subjectCourseSection = section;

            CourseCode.Text = subjectCode;
            SubjectNameLbl.Text = subjectName;
            subjectScheduleLBL.Text = subjectSchedule;
            studentCountLBL.Text = subjectCount;
            subjectCourseandSectionlbl.Text = subjectCourseSection;
        }

        private void editInfoBTN_Click(object sender, EventArgs e)
        {
            CourseCode.ReadOnly = false;
            SubjectNameLbl.ReadOnly = false;
            subjectScheduleLBL.ReadOnly = false;
            studentCountLBL.ReadOnly = false;
            subjectCourseandSectionlbl.ReadOnly = false;
            CourseCode.Focus();
        }

        private void EditCourseSaveBTN_Click(object sender, EventArgs e)
        {
            // Update the properties with the edited values
            subjectCode = CourseCode.Text;
            subjectName = SubjectNameLbl.Text;
            subjectSchedule = subjectScheduleLBL.Text;
            subjectCount = studentCountLBL.Text;
            subjectCourseSection = subjectCourseandSectionlbl.Text;

            // Save the updated information to the text file
            string folderPath = "CourseInformations";
            string filePath = Path.Combine(folderPath, $"{currentUser}.txt");

            if (File.Exists(filePath))
            {
                string[] fileContents = File.ReadAllLines(filePath).ToArray();
                bool isUpdated = false;

                for (int i = 0; i < fileContents.Length; i++)
                {
                    if (fileContents[i].Contains($"Course Name: {originalSubjectName}") && fileContents[i + 1].Contains($"Course Code: {originalSubjectCode}"))
                    {
                        fileContents[i] = $"Course Name: {subjectName}";
                        fileContents[i + 1] = $"Course Code: {subjectCode}";
                        fileContents[i + 2] = $"Student Course and Section: {subjectCourseSection}";
                        fileContents[i + 3] = $"Course Schedule: {subjectSchedule}";
                        fileContents[i + 4] = $"Student Count: {subjectCount}";
                        isUpdated = true;
                        break;
                    }
                }

                if (isUpdated)
                {
                    File.WriteAllLines(filePath, fileContents);
                }
                else
                {
                    MessageBox.Show("Course information not found for updating.");
                }
            }

            // Notify the parent form to refresh the displayed courses
            if (teacher__courses_lvl1.lvl1Instance != null)
            {
                teacher__courses_lvl1.lvl1Instance.populateCourses();
                teacher__courses_lvl1.lvl1Instance.ShowPanel();
            }

            this.Close();
        }

        private void EditCourse_Load(object sender, EventArgs e)
        {

        }
    }
}
