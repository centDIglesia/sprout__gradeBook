using System;
using System.IO;
using System.Windows.Forms;



namespace sprout__gradeBook
{
    public partial class CoursesCARD : UserControl
    {
        private readonly teacher__courses_lvl1 _parent;
        private readonly string _currentUser;
        public CoursesCARD(teacher__courses_lvl1 parent)
        {
            InitializeComponent();
            _parent = parent;
            _currentUser = parent.CurrentUser;
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


        private void CoursesCARD_Load_1(object sender, EventArgs e)
        {
            studentCountTooltip.Hide();
            pictureBox1.Hide();
            announcementBTN.Hide();

            COSEbtn.Hide();

            removeBTN.Hide();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            announcementBTN.Hide();

            COSEbtn.Hide();
            removeBTN.Hide();
        }

        private void subjectCourseSectionLBL_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            announcementBTN.Show();

            COSEbtn.Show();
            removeBTN.Show();
        }

        private void COSEbtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            announcementBTN.Hide();

            COSEbtn.Hide();
            removeBTN.Hide();
        }


        private void removeBTN_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to remove this course?",
                                                "Confirm Remove",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                _parent.RemoveCourse(this);
            }

        }

        private void announcementBTN_Click(object sender, EventArgs e)
        {
             AddAnnouncementFORM addNewAnnouncement = new AddAnnouncementFORM(this);
              addNewAnnouncement.Show();


        }

        public void saveAnnouncement(string title, string description)
        {
            string baseDirectory = $"CourseAnnoucement/{_currentUser}";


            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            string fullPath = Path.Combine(baseDirectory, $"{SubjectName}_{SubjectCode}_{SubjectCourseSection}.txt");

            using (StreamWriter write = new StreamWriter(fullPath, true))
            {
                write.WriteLine($"From : {_currentUser}");
                write.WriteLine($"Title : {title}");
                write.WriteLine($"Description : {description}");
                write.WriteLine($"time sent : {DateTime.Now.ToString("MMMM d, yyyy, dddd, h:mm tt")}");
                write.WriteLine("------------------------------");
            };

            MessageBox.Show("Announcement posted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
