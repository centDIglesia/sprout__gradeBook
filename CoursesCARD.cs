﻿using System;
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

            addSubComponentBTN.Hide();

        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            announcementBTN.Hide();

            COSEbtn.Hide();
            removeBTN.Hide();
            addSubComponentBTN.Hide();
        }

        private void subjectCourseSectionLBL_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            announcementBTN.Show();

            COSEbtn.Show();
            removeBTN.Show();
            addSubComponentBTN.Show();
        }

        private void COSEbtn_Click(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            announcementBTN.Hide();

            COSEbtn.Hide();
            removeBTN.Hide();

            addSubComponentBTN.Hide();
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
            Form formbackground = new Form();

            using (AddAnnouncementFORM addNewAnnouncement = new AddAnnouncementFORM(this))
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = CustomColor.mainColor;
                formbackground.Size = new System.Drawing.Size(1147, 711);

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                addNewAnnouncement.Owner = formbackground;
                addNewAnnouncement.ShowDialog();
            }
            formbackground.Dispose();

        }
        public void saveAnnouncement(string title, string description)
        {
            string baseDirectory = $"CourseAnnouncement/{_currentUser}";

            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            string fullPath = Path.Combine(baseDirectory, $"Anouncement.txt");

            using (StreamWriter write = new StreamWriter(fullPath, true))
            {
                write.WriteLine($"Receiver : {SubjectCourseSection}");
                write.WriteLine($"Title : {title}");
                write.WriteLine($"Description : From | {GetFirstName()} | {SubjectCode}{Environment.NewLine}{description}");
                write.WriteLine($"Time sent : {DateTime.Now.ToString("MMMM d, yyyy, dddd, h:mm tt")}");
                write.WriteLine("------------------------------");
            };
        }

        public string GetFirstName()
        {
            string filePath = $"TeacherCredentials/{_currentUser}.txt";


            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The credential file could not be found.");
            }

            // Read all lines from the file
            string[] lines = File.ReadAllLines(filePath);


            foreach (var line in lines)
            {

                if (line.StartsWith("First Name:", StringComparison.OrdinalIgnoreCase))
                {
                    // Extract the first name by splitting the line
                    string[] parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        return parts[1].Trim();
                    }
                }
            }


            throw new InvalidOperationException("The first name could not be found in the credential file.");
        }

        private void addSubComponentBTN_Click(object sender, EventArgs e)
        {
            string baseDirectoryPath = Path.Combine("CourseGradingSystem", _currentUser, $"{SubjectCode}_{SubjectCourseSection}");
            string filePath = Path.Combine(baseDirectoryPath, "gradingSystem.txt");

            // Check if the grading system file exists
            if (File.Exists(filePath))
            {
                // If grading system already exists, inform the user
                MessageBox.Show(
                    "A grading system already exists for this course. Thank you!.",
                    "Grading System Already Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                Form formbackground = new Form();

                using (createGradingSystemFORM gsForm = new createGradingSystemFORM(_currentUser, SubjectCode, SubjectCourseSection))
                {
                    formbackground.StartPosition = FormStartPosition.CenterScreen;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .70d;
                    formbackground.BackColor = CustomColor.mainColor;
                    formbackground.Size = new System.Drawing.Size(1147, 711);

                    formbackground.Location = this.Location;

                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    gsForm.Owner = formbackground;
                    gsForm.ShowDialog();
                }
                formbackground.Dispose();

            }
        }




    }
}