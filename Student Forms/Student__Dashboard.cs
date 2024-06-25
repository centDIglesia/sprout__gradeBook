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
        // Holds the current student's department
        private readonly string currentstudentDepartment;

        // Reference to the login form
        private readonly studentLoginForm _studentLoginForm;

        // Notification count for the student
        private int notifCount = 0;

        // Constants for grade thresholds
        private const double PassPercentage = 75;
        private const double FailPercentage = 65;

        public Student__Dashboard(studentLoginForm studentLoginForm)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            currentstudentDepartment = studentLoginForm.GetCurrentStudentDepartmentYearSection();
            GetNotificationCount(); // Initialize notifCount
        }

        private void Student__Dashboard_Load(object sender, EventArgs e)
        {
            displayGPA.Hide();

            // Update and hide notification count if zero
            notificationCount.Text = notifCount.ToString();
            notificationCount.Hide();
            notificationCount_bg.Hide();

            // Show notification count if greater than zero
            if (notifCount > 0)
            {
                notificationCount.Show();
                notificationCount_bg.Show();
            }

            CalculateAndDisplayFinalGrades(); // Calculate and display grades
        }

        // Set the username label with the provided username
        public void SetUsernameLabel(string username) => student_Name.Text = $"Hi, {username}";

        // Set the student ID label with the provided student ID
        public void SetStudentIDLabel(string studentID) => student_ID.Text = studentID;

        // Set the student's icon based on their gender
        public void SetStudentIcon(string gender)
        {
            student_Icon.Image = string.Equals(gender, "Male", StringComparison.OrdinalIgnoreCase)
                ? Properties.Resources.Male_Icon
                : Properties.Resources.Female_Icon;
        }

        // Event handler for the close button click event
        private void close_btn_Click(object sender, EventArgs e) => new utilityButton().Exitform();

        // Show a form as a dialog with a background
        private void ShowFormInDialog(Form form)
        {
            using (Form formbackground = new Form())
            {
                formbackground.StartPosition = FormStartPosition.Manual;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = StateCommon.Back.Color1 = CustomColor.mainColor;
                formbackground.Size = this.Size;
                formbackground.Location = this.Location;
                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                form.Owner = formbackground;
                form.ShowDialog();
            }
        }

        // Event handler for notification count click event
        private void notifCount_Click(object sender, EventArgs e)
        {
            ShowFormInDialog(new students__NoticationUi(_studentLoginForm, _studentLoginForm.currentStudentID, currentstudentDepartment));
        }

        // Event handler for feedback button click event
        private void feedback_btn_Click(object sender, EventArgs e)
        {
            ShowFormInDialog(new Student__FeedbackUI(_studentLoginForm, _studentLoginForm.currentStudentID));
        }

        // Get notification count for the current student
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

        // Get the teacher's name by their username
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

        // Get the course name by its course code and the teacher's username
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

        // Add a grade row to the panel
        private void AddGradeRowToPanel(string courseCode, string finalGrade, string courseName, string teacherName, string remark)
        {
            var gradeRow = new Student__GradeRow
            {
                finalGradelbl = { Text = finalGrade },
                courseCodelbl = { Text = courseCode },
                courseDescriptionlbl = { Text = courseName },
                facultyNamelbl = { Text = teacherName },
                gradeRemarkslbl = { Text = remark }
            };

            student_gradesPanel.Controls.Add(gradeRow);
        }

        // Calculate and display the final grades
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
                                // Add row without final grade and remark if grades are incomplete
                                AddGradeRowToPanel(courseCode, "", courseName, teacherName, "");
                                allGradesComplete = false;
                            }
                        }
                        else
                        {
                            // Add row without final grade and remark if no grade file exists
                            string courseCode = Path.GetFileName(courseDir);
                            string teacherName = GetTeacherNameByUsername(Path.GetFileName(teacherDir));
                            string courseName = GetCourseNameByCourseCode(courseCode, Path.GetFileName(teacherDir));
                            AddGradeRowToPanel(courseCode, "", courseName, teacherName, "");
                            allGradesComplete = false;
                        }
                    }
                }
            }

            // Calculate and display GPA if all grades are complete
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

        // Extract the final grade from the lines array
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

        // Get the course code from the lines array
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

        // Get the remark based on the percentage
        private string GetRemarkFromPercentage(double percentage)
        {
            if (percentage >= PassPercentage) return "P";
            if (percentage >= FailPercentage) return "Failure";
            return "INC"; // For percentages below FailPercentage
        }
    }
}

