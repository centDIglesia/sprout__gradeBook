using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void Courses_Load(object sender, EventArgs e)
        {
            studentCountTooltip.Hide();
        }

        public TimeSpan SubjectSchedule
        {
            get
            {
                DateTime schedule;
                if (DateTime.TryParse(subjectScheduleLBL.Text, out schedule))
                {
                    // Check if the time is within the range of 10:00 to 12:00
                    if (schedule.TimeOfDay >= TimeSpan.FromHours(10) && schedule.TimeOfDay <= TimeSpan.FromHours(12))
                    {
                        return schedule.TimeOfDay;
                    }
                }
                return TimeSpan.MinValue; // Default value if the input is invalid
            }
            set
            {
                // Only set the value if it falls within the specified range
                if (value >= TimeSpan.FromHours(10) && value <= TimeSpan.FromHours(12))
                {
                    subjectScheduleLBL.Text = value.ToString();
                }
            }
        }


        public string subjectName
        {
            get
            {
                return subjectNameLBL.Text;
            }
            set
            {
                subjectNameLBL.Text = value;
            }
        }
        public string subjectCode
        {
            get
            {
                return subjectCodeLBL.Text;
            }
            set
            {
                subjectCodeLBL.Text = value;
            }
        }
        public string subjectStudentsCount
        {
            get
            {
                return subjectStudentCountLBL.Text;
            }
            set
            {
                subjectStudentCountLBL.Text = value;
            }
        }
        public string subjectStudentCourseandSection
        {
            get
            {
                return subjectCourseSectionLBL.Text;
            }
            set
            {
                subjectCourseSectionLBL.Text = value;
            }
        }

        private void subjectStudentCountLBL_MouseHover(object sender, EventArgs e)
        {
            studentCountTooltip.Show();
        }

        private void v(object sender, PaintEventArgs e)
        {

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

        private void subjectCourseSectionLBL_Click(object sender, EventArgs e)
        {

        }

        private void subjectNameLBL_Click(object sender, EventArgs e)
        {

        }

        private void subjectCodeLBL_Paint(object sender, PaintEventArgs e)
        {

        }

        private void subjectScheduleLBL_Click(object sender, EventArgs e)
        {

        }
    }
}
