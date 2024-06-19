using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class studentLoginForm : KryptonForm
    {
        private bool isPasswordVisible = false;
        public string currentStudentID;

        public studentLoginForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Student_LogIn_KeyDown);
        }
        private void Student_LogIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signIn__btn_Click(sender, e);
                e.Handled = true;
            }
        }
        private void studentLoginForm_Load(object sender, EventArgs e)
        {
            // Hide tooltips on form load
            signIn__StIdTooltip.Hide();
            signIn__PassTooltip.Hide();
        }

        // Event handlers for entering and leaving student ID text box
        private void signinSTID__txtbox_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(signinSTID__txtbox, "Student Number");
            signIn__StIdTooltip.Show();
        }

        private void signinSTID__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signinSTID__txtbox, "Student Number");
            UserInput_Manager.ToggleTooltip(signinSTID__txtbox, signIn__StIdTooltip, "Student Number");
        }

        // Event handlers for entering and leaving password text box
        private void signinPASS__txtbox_Enter(object sender, EventArgs e)
        {
            signinPASS__txtbox.UseSystemPasswordChar = true;
            UserInput_Manager.ResetInputField(signinPASS__txtbox, "Password");
            signIn__PassTooltip.Show();
        }

        private void signinPASS__txtbox_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(signinPASS__txtbox, "Password");
            UserInput_Manager.ToggleTooltip(signinPASS__txtbox, signIn__PassTooltip, "Password");

            // Disable password masking if default text is shown
            if (signinPASS__txtbox.Text == "Password")
            {
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }
        }

        // Toggle password visibility
        private void signIn__showPassicon_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            signIn__showPassicon.Image = isPasswordVisible
                ? Properties.Resources.closed__eye
                : Properties.Resources.open__eye;
            signinPASS__txtbox.UseSystemPasswordChar = !isPasswordVisible;
        }

        // Show student default password guide
        private void showGuide_Click(object sender, EventArgs e)
        {
            using (var formbackground = new Form())
            {
                using (var studentDefaultPasswordGuide = new StudentDefultPasswordGuide())
                {
                    formbackground.StartPosition = FormStartPosition.Manual;
                    formbackground.FormBorderStyle = FormBorderStyle.None;
                    formbackground.Opacity = .70d;
                    formbackground.BackColor = CustomColor.mainColor;
                    formbackground.Size = this.Size;
                    formbackground.Location = this.Location;
                    formbackground.ShowInTaskbar = false;
                    formbackground.Show();

                    studentDefaultPasswordGuide.Owner = formbackground;
                    studentDefaultPasswordGuide.ShowDialog();
                }
            }
        }

        private void signIn__btn_Click(object sender, EventArgs e)
        {
            currentStudentID = signinSTID__txtbox.Text;
            string password = signinPASS__txtbox.Text;

            // Validate inputs
            if (currentStudentID == "Student Number" || password == "Password")
            {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                (currentStudentID == "Student Number" ? signinSTID__txtbox : signinPASS__txtbox).Focus();
                return;
            }

            // Authenticate user
            if (!TryFindUser(currentStudentID, out var studentFilePath, out var teacherDir))
            {
                ShowAccountNotFoundError();
                return;
            }

            if (Account__Manager.AuthenticateStudentLogIn(currentStudentID, password, teacherDir))
            {
                HandleSuccessfulLogin(studentFilePath);
            }
            else
            {
                MessageBox.Show("Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Close button click event handler
        private void close_btn_Click(object sender, EventArgs e)
        {
            new utilityButton().Exitform();
        }

        // Attempt to find user in directories
        private bool TryFindUser(string usernameOrId, out string studentFilePath, out string teacherDir)
        {
            studentFilePath = null;
            teacherDir = null;

            string baseFolderPath = "StudentCredentials";
            foreach (var dir in Directory.GetDirectories(baseFolderPath))
            {
                studentFilePath = Path.Combine(dir, $"{usernameOrId}.txt");
                if (File.Exists(studentFilePath))
                {
                    teacherDir = dir;
                    return true;
                }
            }
            return false;
        }

        // Handle successful login, retrieve student info, display dashboard
        private void HandleSuccessfulLogin(string studentFilePath)
        {
            var studentInfo = File.ReadAllLines(studentFilePath)
                .ToDictionary(
                    line => line.Substring(0, line.IndexOf(':')),
                    line => line.Substring(line.IndexOf(':') + 1).Trim()
                );

            string username = TryGetValueOrDefault(studentInfo, "Username", "Unknown");
            string studentID = TryGetValueOrDefault(studentInfo, "Student ID", "Unknown");
            string studentGender = TryGetValueOrDefault(studentInfo, "Gender", "Unknown");
            string department = TryGetValueOrDefault(studentInfo, "Department", "Unknown");
            string yearSection = TryGetValueOrDefault(studentInfo, "Year and Section", "Unknown");

            MessageBox.Show("Sign in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

            var dashboard = new Student__Dashboard(this);
            dashboard.SetUsernameLabel(username);
            dashboard.SetStudentIDLabel(studentID);
            dashboard.SetStudentIcon(studentGender);

            PopulateStudentCourses(dashboard, department, yearSection);

            dashboard.Show();
        }

        // Populate student courses on dashboard
        private void PopulateStudentCourses(Student__Dashboard dashboard, string department, string yearSection)
        {
            string courseFolderPath = "CourseInformations";
            var courseCards = new List<StudentScheduleCard>();

            foreach (var courseFile in Directory.GetFiles(courseFolderPath, "*.txt"))
            {
                foreach (var courseBlock in GetCourseBlocks(File.ReadAllLines(courseFile)))
                {
                    if (TryGetValueOrDefault(courseBlock, "Student Department", null) == department &&
                        TryGetValueOrDefault(courseBlock, "Student year and section", null) == yearSection)
                    {
                        var courseName = TryGetValueOrDefault(courseBlock, "Course Name", null);
                        var courseCode = TryGetValueOrDefault(courseBlock, "Course Code", null);
                        var schedule = TryGetValueOrDefault(courseBlock, "Course Schedule", null);
                        var weekDay = TryGetValueOrDefault(courseBlock, "Day of the Week", null);
                        var teacherName = GetTeacherName(Path.GetFileName(courseFile));

                        var card = new StudentScheduleCard
                        {
                            subjectCodeLBL = { Text = courseCode },
                            subjectNameLBL = { Text = courseName },
                            subjectScheduleLBL = { Text = schedule },
                            DayOfTheWeek_lbl = { Text = weekDay },
                            teacherNameLBL = { Text = teacherName }
                        };

                        courseCards.Add(card);
                    }
                }
            }

            courseCards.Sort((x, y) => CompareDaysOfWeek(x.DayOfTheWeek_lbl.Text, y.DayOfTheWeek_lbl.Text));

            foreach (var card in courseCards)
            {
                dashboard.student_CoursePanel.Controls.Add(card);
            }
        }

        // Get teacher usernames for student
        public List<string> GetTeachersForStudent()
        {
            List<string> teacherUsernames = new List<string>();

            string baseFolderPath = "StudentCredentials";
            foreach (var dir in Directory.GetDirectories(baseFolderPath))
            {
                string studentFilePath = Path.Combine(dir, $"{currentStudentID}.txt");
                if (File.Exists(studentFilePath))
                {
                    string teacherUsername = Path.GetFileName(dir);
                    teacherUsernames.Add(teacherUsername);
                }
            }

            return teacherUsernames;
        }

        // Get current student's department and year/section
        public string GetCurrentStudentDepartmentYearSection()
        {
            var teachers = GetTeachersForStudent();
            string folderPath = "StudentCredentials";
            foreach (var teacher in teachers)
            {
                string studentFilePath = Path.Combine(folderPath, teacher, $"{currentStudentID}.txt");
                if (File.Exists(studentFilePath))
                {
                    var studentDetails = File.ReadAllLines(studentFilePath);

                    string department = studentDetails
                        .FirstOrDefault(line => line.StartsWith("Department:"))
                        ?.Split(new[] { ':' }, 2)[1].Trim();

                    string yearAndSection = studentDetails
                        .FirstOrDefault(line => line.StartsWith("Year and Section:"))
                        ?.Split(new[] { ':' }, 2)[1].Trim();

                    if (!string.IsNullOrEmpty(department) && !string.IsNullOrEmpty(yearAndSection))
                    {
                        return $"{department} {yearAndSection}";
                    }
                }
            }

            return "Department and Year/Section not found.";
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Form formbackground = new Form();

            using (TermsCons terms = new TermsCons())
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .70d;
                formbackground.BackColor = StateCommon.Back.Color1 = CustomColor.mainColor;
                formbackground.Size = this.Size;

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                terms.Owner = formbackground;
                terms.ShowDialog();
            }
            formbackground.Dispose();
        }

        // Helper method to show account not found error
        private void ShowAccountNotFoundError()
        {
            MessageBox.Show("The student account you entered does not exist.\n" +
                            "Please check your username or ID and try again.\n\n" +
                            "If you do not have an account, please contact your teacher for assistance.",
                            "Account Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        // Helper method to compare days of the week
        private int CompareDaysOfWeek(string day1, string day2)
        {
            var daysOfWeek = new List<string>
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            return daysOfWeek.IndexOf(day1).CompareTo(daysOfWeek.IndexOf(day2));
        }

        // Method to retrieve teacher name from file
        private string GetTeacherName(string courseFileName)
        {
            string teacherFilePath = Path.Combine("TeacherCredentials", courseFileName);

            if (!File.Exists(teacherFilePath)) return "Unknown";

            var teacherInfo = File.ReadAllLines(teacherFilePath)
                .ToDictionary(
                    line => line.Substring(0, line.IndexOf(':')),
                    line => line.Substring(line.IndexOf(':') + 1).Trim()
                );

            var firstName = TryGetValueOrDefault(teacherInfo, "First Name", "Unknown");
            var lastName = TryGetValueOrDefault(teacherInfo, "Last Name", "Unknown");

            return $"{firstName} {lastName}";
        }

        // Helper method to parse course blocks
        private Dictionary<string, string> GetCourseBlock(IEnumerable<string> lines)
        {
            var block = new Dictionary<string, string>();

            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);
                if (!block.ContainsKey(parts[0]))
                {
                    block.Add(parts[0], parts.Length > 1 ? parts[1] : null);
                }
            }

            return block;
        }

        // Helper method to get course blocks from lines
        private IEnumerable<Dictionary<string, string>> GetCourseBlocks(string[] lines)
        {
            var blocks = new List<Dictionary<string, string>>();
            var currentBlock = new List<string>();

            foreach (var line in lines)
            {
                if (line.Trim() == "----------------------------------------")
                {
                    if (currentBlock.Any())
                    {
                        blocks.Add(GetCourseBlock(currentBlock));
                        currentBlock.Clear();
                    }
                }
                else
                {
                    currentBlock.Add(line);
                }
            }

            if (currentBlock.Any())
            {
                blocks.Add(GetCourseBlock(currentBlock));
            }

            return blocks;
        }

        // Helper method to safely retrieve value from dictionary
        private static TValue TryGetValueOrDefault<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        // Button click event to go back to role form
        private void back__btn_Click(object sender, EventArgs e)
        {
            Role__form role = new Role__form();
            role.Show();
            this.Hide();
        }


        private void signIn__btn_MouseHover(object sender, EventArgs e)
        {
            signIn__btn.Image = Properties.Resources.Frame_101_hover;
        }

        private void signIn__btn_MouseLeave(object sender, EventArgs e)
        {

            signIn__btn.Image = Properties.Resources.Frame_101_ddefault;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
