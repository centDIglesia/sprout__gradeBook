using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using sprout__gradeBook.Student_Forms;

namespace sprout__gradeBook
{
    public partial class Student__Dashboard : KryptonForm
    {
        private readonly string currentstudentDepartment;
        private readonly studentLoginForm _studentLoginForm;
        private int notifCount = 0;

        public Student__Dashboard(studentLoginForm studentLoginForm)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            currentstudentDepartment = studentLoginForm.GetCurrentStudentDepartmentYearSection();
            GetNotificationCount(); // Call method to initialize notifCount
        }

        public void SetUsernameLabel(string username)
        {
            student_Name.Text = $"Hi, {username}";
        }

        public void SetStudentIDLabel(string studentID)
        {
            student_ID.Text = studentID;
        }

        // Method to set the student's icon based on their gender
        public void SetStudentIcon(string gender)
        {
            if (string.Equals(gender, "Male", StringComparison.OrdinalIgnoreCase))
            {
                student_Icon.Image = Properties.Resources.Male_Icon;
            }
            else
            {
                student_Icon.Image = Properties.Resources.Female_Icon;
            }
        }

        // Event handler for the close button click event
        private void close_btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();
            b.Exitform();
        }

        private void notifCount_Click(object sender, EventArgs e)
        {
            Form formbackgroud = new Form();

            using (students__NoticationUi students__NoticationFORM = new students__NoticationUi(_studentLoginForm, _studentLoginForm.currentStudentID, currentstudentDepartment))
            {
                formbackgroud.StartPosition = FormStartPosition.Manual;
                formbackgroud.FormBorderStyle = FormBorderStyle.None;
                formbackgroud.Opacity = .70d;
                formbackgroud.BackColor = StateCommon.Back.Color1 = CustomColor.mainColor;
                formbackgroud.Size = this.Size;
                formbackgroud.Location = this.Location;
                formbackgroud.ShowInTaskbar = false;
                formbackgroud.Show();

                students__NoticationFORM.Owner = formbackgroud;
                students__NoticationFORM.ShowDialog();
            }
            formbackgroud.Dispose();
        }

        private void Student__Dashboard_Load(object sender, EventArgs e)
        {
            displayGPA.Hide();

            notificationCount.Text = notifCount.ToString();
            notificationCount.Hide();
            notificationCount_bg.Hide();
            if (notifCount > 0)
            {
                notificationCount.Show();
                notificationCount_bg.Show();
            }

            CalculateAndDisplayFinalGrades(); // Call the new method to calculate and display grades
        }

        private void GetNotificationCount()
        {
            List<string> teachers = _studentLoginForm.GetTeachersForStudent();

            foreach (string teacher in teachers)
            {
                string teacherAnnouncementFile = $"CourseAnnouncement/{teacher}/Anouncement.txt";

                if (File.Exists(teacherAnnouncementFile))
                {
                    var announcementLines = File.ReadAllLines(teacherAnnouncementFile);
                    var announcements = string.Join("\n", announcementLines)
                        .Split(new[] { "------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var announcement in announcements)
                    {
                        var lines = announcement.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        var announcementDict = new Dictionary<string, string>();

                        foreach (var line in lines)
                        {
                            var parts = line.Split(new[] { ':' }, 2);
                            if (parts.Length == 2)
                            {
                                announcementDict[parts[0].Trim()] = parts[1].Trim();
                            }
                        }

                        if (announcementDict.TryGetValue("Receiver", out var receiver) &&
                            receiver.Equals(currentstudentDepartment, StringComparison.OrdinalIgnoreCase))
                        {
                            notifCount++;
                        }
                    }
                }
            }
        }

        private void feedback_btn_Click(object sender, EventArgs e)
        {
            Form formbackgroud = new Form();

            using (Student__FeedbackUI feedbackUI = new Student__FeedbackUI(_studentLoginForm, _studentLoginForm.currentStudentID))
            {
                formbackgroud.StartPosition = FormStartPosition.Manual;
                formbackgroud.FormBorderStyle = FormBorderStyle.None;
                formbackgroud.Opacity = .70d;
                formbackgroud.BackColor = CustomColor.mainColor;
                formbackgroud.Size = this.Size;
                formbackgroud.Location = this.Location;
                formbackgroud.ShowInTaskbar = false;
                formbackgroud.Show();

                feedbackUI.Owner = formbackgroud;
                feedbackUI.ShowDialog();
            }
            formbackgroud.Dispose();
        }

        private string GetTeacherNameByUsername(string username)
        {
            string teacherCredentialsFile = Path.Combine("TeacherCredentials", $"{username}.txt");
            if (File.Exists(teacherCredentialsFile))
            {
                var lines = File.ReadAllLines(teacherCredentialsFile);
                string firstName = string.Empty;
                string lastName = string.Empty;

                foreach (var line in lines)
                {
                    if (line.StartsWith("First Name"))
                    {
                        firstName = line.Split(':')[1].Trim();
                    }
                    else if (line.StartsWith("Last Name"))
                    {
                        lastName = line.Split(':')[1].Trim();
                    }
                }

                if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
                {
                    return $"{firstName} {lastName}";
                }
            }

            return string.Empty;
        }

        private string GetCourseNameByCourseCode(string courseCode, string teacherUsername)
        {
            string courseInfoFile = Path.Combine("CourseInformations", $"{teacherUsername}.txt");
            if (File.Exists(courseInfoFile))
            {
                var courseInfoData = File.ReadAllText(courseInfoFile);
                var courseInfoSections = courseInfoData.Split(new[] { "----------------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var section in courseInfoSections)
                {
                    if (section.Contains($"Course Code: {courseCode}"))
                    {
                        var lines = section.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var line in lines)
                        {
                            if (line.StartsWith("Course Name"))
                            {
                                return line.Split(':')[1].Trim();
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }

        private void AddGradeRowToPanel(string courseCode, string finalGrade, string courseName, string teacherName, string remark)
        {
            var gradeRow = new sprout__gradeBook.Student_Forms.Student__GradeRow
            {
                finalGradelbl = { Text = finalGrade },
                studentCodelbl = { Text = courseCode },
                courseDescriptionlbl = { Text = courseName },
                facultyNamelbl = { Text = teacherName },
                gradeRemarkslbl = { Text = remark }
            };

            student_gradesPanel.Controls.Add(gradeRow);
        }

        private void CalculateAndDisplayFinalGrades()
        {
            string studentID = _studentLoginForm.currentStudentID;
            string studentGradesPath = $"studentFinalGrades";
            List<double> validGrades = new List<double>();
            bool allGradesComplete = true;

            if (Directory.Exists(studentGradesPath))
            {
                var teacherDirectories = Directory.GetDirectories(studentGradesPath);

                foreach (var teacherDir in teacherDirectories)
                {
                    var courseDirectories = Directory.GetDirectories(teacherDir);

                    foreach (var courseDir in courseDirectories)
                    {
                        string finalGradeFile = Path.Combine(courseDir, $"{studentID}.txt");

                        if (File.Exists(finalGradeFile))
                        {
                            var lines = File.ReadAllLines(finalGradeFile);
                            double midtermGrade = -1;
                            double finalTermGrade = -1;

                            for (int i = 0; i < lines.Length; i++)
                            {
                                if (lines[i].Contains("Midterm Grade"))
                                {
                                    midtermGrade = ExtractFinalGrade(lines, ref i);
                                }
                                else if (lines[i].Contains("Final Grade"))
                                {
                                    finalTermGrade = ExtractFinalGrade(lines, ref i);
                                }
                            }

                            string courseCode = GetCourseCode(lines);
                            string teacherName = GetTeacherNameByUsername(Path.GetFileName(teacherDir));
                            string courseName = GetCourseNameByCourseCode(courseCode, Path.GetFileName(teacherDir));

                            if (midtermGrade >= 0 && finalTermGrade >= 0)
                            {
                                double averageGrade = Math.Round((midtermGrade + finalTermGrade) / 2, 2);
                                validGrades.Add(averageGrade);
                                string remark = GetRemarkFromPercentage(averageGrade);
                                AddGradeRowToPanel(courseCode, averageGrade.ToString("F2"), courseName, teacherName, remark);
                            }
                            else
                            {
                                // If one of the term grades is missing, add the row without the final grade and remark
                                AddGradeRowToPanel(courseCode, "", courseName, teacherName, "");
                                allGradesComplete = false; // Mark that not all grades are complete
                            }
                        }
                        else
                        {
                            // If no final grade file exists, it means grades are incomplete
                            string courseCode = Path.GetFileName(courseDir);
                            string teacherName = GetTeacherNameByUsername(Path.GetFileName(teacherDir));
                            string courseName = GetCourseNameByCourseCode(courseCode, Path.GetFileName(teacherDir));
                            AddGradeRowToPanel(courseCode, "", courseName, teacherName, "");
                            allGradesComplete = false; // Mark that not all grades are complete
                        }
                    }
                }
            }

            if (allGradesComplete && validGrades.Count > 0)
            {
                double gpa = Math.Round(validGrades.Average(), 2);
                displayGPA.Text = $"GPA: {gpa:F2}";
            }
            else
            {
                displayGPA.Text = "Grades Not Complete";
            }

            displayGPA.Show();
        }

        private double ExtractFinalGrade(string[] lines, ref int index)
        {
            while (index < lines.Length && !lines[index].Contains("Total Final Grade"))
            {
                index++;
            }

            if (index < lines.Length)
            {
                string finalGradeLine = lines[index];
                string finalGradeStr = finalGradeLine.Split('|')[1].Trim().Replace("%", "");
                if (double.TryParse(finalGradeStr, out double finalGrade))
                {
                    return Math.Round(finalGrade, 2);
                }
            }

            return -1;
        }

        private string GetCourseCode(string[] lines)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("Course Code"))
                {
                    return line.Split('|')[1].Trim();
                }
            }

            return string.Empty;
        }

        private string GetRemarkFromPercentage(double percentage)
        {
            if (percentage >= 75) return "P";
            if (percentage >= 65) return "Failure";
            return "INC"; // For percentages below 65
        }

    }
}
