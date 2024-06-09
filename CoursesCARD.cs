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



        public string SubjectName
        {
            get => subjectNameLBL.Text;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    subjectNameLBL.Text = value.Length > 24 ? value.Substring(0, 24) + "..." : value;
                }
            }
        }

        public string SubjectCode
        {
            get => subjectCodeLBL.Text;
            set => subjectCodeLBL.Text = value;
        }

        public string SubjectCount
        {
            get => subjectStudentCountLBL.Text;
            set => subjectStudentCountLBL.Text = value;
        }

        public string SubjectSchedule
        {
            get => subjectScheduleLBL.Text;
            set => subjectScheduleLBL.Text = value;
        }

        public string SubjectCourseSection
        {
            get => subjectCourseSectionLBL.Text;
            set => subjectCourseSectionLBL.Text = value;
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


        private void CoursesCARD_Load_1(object sender, EventArgs e)
        {
            studentCountTooltip.Hide();

        }

        private void subjectCourseSectionLBL_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Group_66dd;
        }

        private void subjectCourseSectionLBL_TextChanged(object sender, EventArgs e)
        {

        }

        private void subjectNameLBL_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.Group_66d;
        }
    }
}
