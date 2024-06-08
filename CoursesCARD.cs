﻿using System;
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

        private void Courses_Load(object sender, EventArgs e)
        {

        }

        public string SubjectName
        {
            get => subjectNameLBL.Text;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    subjectNameLBL.Text = value.Length > 29 ? value.Substring(0, 29) + "...." : value;
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
            set => subjectCourseSectionLBL.Text = value.Length > 7 ? value.Substring(0, 6) + ".." : value.ToUpper();
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

        private void CoursesCARD_MouseHover(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.subhover;
        }


        private void CoursesCARD_MouseLeave(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.sub;
        }
    }
}
