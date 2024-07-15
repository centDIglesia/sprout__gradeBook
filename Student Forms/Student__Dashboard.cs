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
        private readonly string currentStudentDepartment;
        private readonly studentLoginForm _studentLoginForm;
        private int notifCount = 0;
        private const double PassPercentage = 75;
        private const double FailPercentage = 65;

        public Student__Dashboard(studentLoginForm studentLoginForm)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            currentStudentDepartment = studentLoginForm.GetCurrentStudentDepartmentYearSection();
            GetNotificationCount(); // Initialize notifCount
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

            DisplayStudentCourses();
            CalculateAndDisplayFinalGrades();
        }

        public void SetUsernameLabel(string username) => student_Name.Text = $"Hi, {username}";

        public void SetStudentIDLabel(string studentID) => student_ID.Text = studentID;

        public void SetStudentIcon(string gender)
        {
            student_Icon.Image = string.Equals(gender, "Male", StringComparison.OrdinalIgnoreCase)
                ? Properties.Resources.Male_Icon
                : Properties.Resources.Female_Icon;
        }

        private void close_btn_Click(object sender, EventArgs e) => new utilityButton().Exitform();

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

        private void notifCount_Click(object sender, EventArgs e)
        {
            ShowFormInDialog(new students__NoticationUi(_studentLoginForm, _studentLoginForm.currentStudentID, currentStudentDepartment));
        }

        private void feedback_btn_Click(object sender, EventArgs e)
        {
            ShowFormInDialog(new Student__FeedbackUI(_studentLoginForm, _studentLoginForm.currentStudentID));
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
                            receiver.Equals(currentStudentDepartment, StringComparison.OrdinalIgnoreCase))
                        {
                            notifCount++;
                        }
                    }
                }
            }
        }
        

        private void AddCourseToPanel(string courseCode, string courseName, string createdBy)
        {
            var gradeRow = new Student__GradeRow
            {
                courseCodelbl = { Text = courseCode },
                courseDescriptionlbl = { Text = courseName },
                facultyNamelbl = { Text = createdBy }
            };
            // Set default values as empty strings
            gradeRow.finalGradelbl.Text = "";
            gradeRow.gradeRemarkslbl.Text = "";

            student_gradesPanel.Controls.Add(gradeRow);
        }
        private void DisplayStudentCourses()
        {
            string studentID = _studentLoginForm.currentStudentID;
            string baseDirectory = "CourseInformations";

            if (Directory.Exists(baseDirectory))
            {
                var teacherDirectories = Directory.GetDirectories(baseDirectory);

                foreach (var teacherDir in teacherDirectories)
                {
                    var courseFiles = Directory.GetFiles(teacherDir, "*.txt");

                    foreach (var courseFile in courseFiles)
                    {
                        var lines = File.ReadAllLines(courseFile);
                        bool studentFound = false;
                        string courseCode = string.Empty;
                        string courseName = string.Empty;
                        string createdBy = string.Empty;

                        foreach (var line in lines)
                        {
                            if (line.StartsWith("Course Code:"))
                            {
                                courseCode = line.Substring("Course Code:".Length).Trim();
                            }
                            else if (line.StartsWith("Course Name:"))
                            {
                                courseName = line.Substring("Course Name:".Length).Trim();
                            }
                            else if (line.StartsWith("Created By:"))
                            {
                                createdBy = line.Substring("Created By:".Length).Trim();
                            }
                            else if (line.StartsWith("Student ID:") && line.Substring("Student ID:".Length).Trim() == studentID)
                            {
                                studentFound = true;
                                break;
                            }
                        }

                        if (studentFound)
                        {
                            AddCourseToPanel(courseCode, courseName, createdBy);
                        }
                    }
                }
            }
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

                            if (midtermGrade >= 0 && finalTermGrade >= 0)
                            {
                                double averageGrade = Math.Round((midtermGrade + finalTermGrade) / 2, 2);
                                validGrades.Add(averageGrade);
                                string remark = GetRemarkFromPercentage(averageGrade);
                                UpdateGradeRow(courseCode, averageGrade.ToString("F2"), remark);
                            }
                            else
                            {
                                UpdateGradeRow(courseCode, "", "");
                                allGradesComplete = false; // Mark as incomplete if any grade is missing
                            }
                        }
                        else
                        {
                            string courseCode = Path.GetFileName(courseDir);
                            UpdateGradeRow(courseCode, "", "");
                            allGradesComplete = false; // Mark as incomplete if any grade is missing
                        }
                    }
                }
            }
            else
            {
                // Handle case where studentFinalGrades folder does not exist or is empty
                // Clear all grade rows
                foreach (Control control in student_gradesPanel.Controls)
                {
                    if (control is Student__GradeRow gradeRow)
                    {
                        gradeRow.finalGradelbl.Text = ""; // Set to empty string
                        gradeRow.gradeRemarkslbl.Text = ""; // Set to empty string
                    }
                }

                allGradesComplete = false; // Mark as incomplete
            }

            if (allGradesComplete && validGrades.Count > 1)
            {
                double gpa = Math.Round(validGrades.Average(), 2);
                displayGPA.Text = $"GPA: {gpa:F2}";
                displayGPA.Show(); // Show GPA only when all grades are complete
            }
            else
            {
                displayGPA.Text = "Grades Not Complete";
                displayGPA.Show(); // Hide GPA when grades are not complete
            }
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
            if (percentage >= PassPercentage) return "P";
            if (percentage >= FailPercentage) return "Failure";
            return "INC"; // For percentages below FailPercentage
        }

        private void UpdateGradeRow(string courseCode, string finalGrade, string remark)
        {
            foreach (Control control in student_gradesPanel.Controls)
            {
                if (control is Student__GradeRow gradeRow && gradeRow.courseCodelbl.Text == courseCode)
                {
                    gradeRow.finalGradelbl.Text = string.IsNullOrWhiteSpace(finalGrade) ? " " : finalGrade;
                    gradeRow.gradeRemarkslbl.Text = string.IsNullOrWhiteSpace(remark) ? " " : remark;
                    break;
                }
            }
        }

        private void StudentLogOut_Click(object sender, EventArgs e)
        {
            utilityButton ut = new utilityButton();
            if (ut.ConfirmLogout() == true)
            {
                this.Close();
                studentLoginForm studentLogin = new studentLoginForm();
                studentLogin.Show();
            }

        }
        private void StudentLogOut_MouseLeave(object sender, EventArgs e)
        {
            StudentLogOut.Image = Properties.Resources.LogOut__Common;
        }

        private void StudentLogOut_MouseHover(object sender, EventArgs e)
        {
            StudentLogOut.Image = Properties.Resources.LogOut__Hover;
        }
    }
}
