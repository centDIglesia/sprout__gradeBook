using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class CoursesCARD : UserControl
    {
        public CoursesCARD()
        {
            InitializeComponent();
        }

        public teacher__courses_lvl1 ParentForm { get; set; } // Reference to the parent form

        private void Courses_Load(object sender, EventArgs e)
        {
            studentCountTooltip.Hide();
        }

        private string subjectName;
        private string subjectCode;
        private string subjectCount;
        private string subjectSchedule;
        private string subjectCourseSection;

        public string SubjectName
        {
            get { return subjectName; }
            set
            {
                if (value.Length > 7)
                {
                    subjectName = value.Substring(0, 29) + "....";
                }
                else
                {
                    subjectName = value;
                }
                subjectNameLBL.Text = subjectName;
            }
        }

        public string SubjectCode
        {
            get { return subjectCode; }
            set { subjectCode = value; subjectCodeLBL.Text = value; }
        }

        public string SubjectCount
        {
            get { return subjectCount; }
            set { subjectCount = value; subjectStudentCountLBL.Text = value; }
        }

        public string SubjectSchedule
        {
            get { return subjectSchedule; }
            set { subjectSchedule = value; subjectScheduleLBL.Text = value; }
        }

        public string SubjectCourseSection
        {
            get { return subjectCourseSection; }
            set
            {
                if (value.Length > 7)
                {
                    subjectCourseSection = value.Substring(0, 6) + "..";
                }
                else
                {
                    subjectCourseSection = value.ToUpper();
                }
                subjectCourseSectionLBL.Text = subjectCourseSection;
            }
        }

        private void subjectStudentCountLBL_MouseHover(object sender, EventArgs e)
        {
            studentCountTooltip.Show();
        }

        private void subjectStudentCountLBL_MouseLeave(object sender, EventArgs e)
        {
            studentCountTooltip.Hide();
        }

        private void Courses_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.subhover;
        }

        private void Courses_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.sub;
        }

        private void subjectScheduleLBL_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.subhover;
        }

        private void subjectScheduleLBL_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.sub;
        }

        private void subjectCodeLBL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Courses_Click_1(object sender, EventArgs e)
        {

        }

        private void subjectStudentCountLBL_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
