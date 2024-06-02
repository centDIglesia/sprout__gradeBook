using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class Courses : UserControl
    {
        public Courses()
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
            set { subjectName = value; subjectNameLBL.Text = value; }
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
            set { subjectCourseSection = value; subjectCourseSectionLBL.Text = value; }
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
            EditCourse editCourse = new EditCourse(SubjectName, SubjectCode, SubjectCount, SubjectSchedule, SubjectCourseSection);


            if (ParentForm != null)
            {
                ParentForm.LoadFormIntoPanel(editCourse);
                ParentForm.hidePanel();
                ParentForm.hidebuttons();
            }
            else
            {
                MessageBox.Show("ParentForm is not set.");
            }
        }

        private void subjectStudentCountLBL_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
