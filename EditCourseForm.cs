using System;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class EditCourseForm : KryptonForm
    {
        private readonly teacher__courses_lvl1 _parent;

        private readonly string currentUser;
        private readonly string originalSubjectName;
        private readonly string originalSubjectCode;
        private string subjectName;
        private string subjectCode;
        private string subjectCount;
        private string subjectSchedule;
        private string subjectCourseSection;

        public EditCourseForm(teacher__courses_lvl1 parent, string currentUsername, string name, string code, string count, string schedule, string section)
        {
            InitializeComponent();
            currentUser = currentUsername;
            _parent = parent;
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

            // Save the updated information to the text file in the "CourseInformations" folder
            string courseInfoFolderPath = "CourseInformations";
            string courseInfoFilePath = Path.Combine(courseInfoFolderPath, $"{currentUser}.txt");

            if (File.Exists(courseInfoFilePath))
            {
                string[] courseInfoFileContents = File.ReadAllLines(courseInfoFilePath);
                bool isUpdated = false;

                for (int i = 0; i < courseInfoFileContents.Length; i++)
                {
                    if (courseInfoFileContents[i].Contains($"Course Name: {originalSubjectName}") && courseInfoFileContents[i + 1].Contains($"Course Code: {originalSubjectCode}"))
                    {
                        courseInfoFileContents[i] = $"Course Name: {subjectName}";
                        courseInfoFileContents[i + 1] = $"Course Code: {subjectCode}";
                        courseInfoFileContents[i + 2] = $"Student Course and Section: {subjectCourseSection}";
                        courseInfoFileContents[i + 3] = $"Course Schedule: {subjectSchedule}";
                        courseInfoFileContents[i + 4] = $"Student Count: {subjectCount}";
                        isUpdated = true;
                        break;
                    }
                }

                if (isUpdated)
                {
                    File.WriteAllLines(courseInfoFilePath, courseInfoFileContents);
                }
                else
                {
                    MessageBox.Show("Course information not found for updating in the CourseInformations folder.");
                }
            }
            else
            {
                MessageBox.Show("Course file not found for updating in the CourseInformations folder.");
            }





            this.Close();


            // Notify the parent form to refresh the displayed courses
            if (_parent != null)
            {
                _parent.populateCourses();
                _parent.ShowPanel();



            }



        }

        private void EditCourseForm_Load(object sender, EventArgs e)
        {

        }

        private void EditCourseForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
