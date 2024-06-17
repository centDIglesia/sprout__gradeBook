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
        }

        private void studentLoginForm_Load(object sender, EventArgs e)
        {
            // Hide tooltips on form load
            signIn__StIdTooltip.Hide();
            signIn__PassTooltip.Hide();
        }

        private void signinSTID__txtbox_Enter(object sender, EventArgs e)
        {
            // Clear default text and show tooltip
            UserInput_Manager.ResetInputField(signinSTID__txtbox, "Student Number");
            signIn__StIdTooltip.Show();
        }

        private void signinSTID__txtbox_Leave(object sender, EventArgs e)
        {
            // Restore default text and manage tooltip visibility
            UserInput_Manager.RestoreDefaultText(signinSTID__txtbox, "Student Number");
            UserInput_Manager.ToggleTooltip(signinSTID__txtbox, signIn__StIdTooltip, "Student Number");
        }

        private void signinPASS__txtbox_Enter(object sender, EventArgs e)
        {
            // Hide password characters and show tooltip
            signinPASS__txtbox.UseSystemPasswordChar = true;
            UserInput_Manager.ResetInputField(signinPASS__txtbox, "Password");
            signIn__PassTooltip.Show();
        }

        private void signinPASS__txtbox_Leave(object sender, EventArgs e)
        {
            // Restore default text and manage tooltip visibility
            UserInput_Manager.RestoreDefaultText(signinPASS__txtbox, "Password");
            UserInput_Manager.ToggleTooltip(signinPASS__txtbox, signIn__PassTooltip, "Password");

            // Disable password masking if default text is shown
            if (signinPASS__txtbox.Text == "Password")
            {
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }
        }

        private void signIn__showPassicon_Click(object sender, EventArgs e)
        {
            // Toggle password visibility
            isPasswordVisible = !isPasswordVisible;
            signIn__showPassicon.Image = isPasswordVisible
                ? Properties.Resources.closed__eye
                : Properties.Resources.open__eye;
            signinPASS__txtbox.UseSystemPasswordChar = !isPasswordVisible;
        }

        private void showGuide_Click(object sender, EventArgs e)
        {
            Form formbackgroud = new Form();
            // Show student default password guide
            using (var studentDefaultPasswordGuide = new StudentDefultPasswordGuide())
            {
                formbackgroud.StartPosition = FormStartPosition.Manual;
                formbackgroud.FormBorderStyle = FormBorderStyle.None;
                formbackgroud.Opacity = .70d;
                formbackgroud.BackColor = CustomColor.mainColor;
                formbackgroud.Size = this.Size;
                formbackgroud.Location = this.Location;
                formbackgroud.ShowInTaskbar = false;
                formbackgroud.Show();

                studentDefaultPasswordGuide.Owner = formbackgroud;
                studentDefaultPasswordGuide.ShowDialog();
            }
            formbackgroud.Dispose();
        }
    
 

        private void signIn__btn_Click(object sender, EventArgs e)
        {
            // Get user inputs
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


        private void close_btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Exitform();
        }


        private bool TryFindUser(string usernameOrId, out string studentFilePath, out string teacherDir)
        {
            studentFilePath = null;
            teacherDir = null;

            // Search for user file in the directories
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

        private void HandleSuccessfulLogin(string studentFilePath)
        {
            // Read and parse student info
            var studentInfo = File.ReadAllLines(studentFilePath)
                .ToDictionary(
                    line => line.Substring(0, line.IndexOf(':')),
                    line => line.Substring(line.IndexOf(':') + 1).Trim()
                );

            // Extract student details
            string username = TryGetValueOrDefault(studentInfo, "Username", "Unknown");
            string studentID = TryGetValueOrDefault(studentInfo, "Student ID", "Unknown");
            string studentGender = TryGetValueOrDefault(studentInfo, "Gender", "Unknown");
            string department = TryGetValueOrDefault(studentInfo, "Department", "Unknown");
            string yearSection = TryGetValueOrDefault(studentInfo, "Year and Section", "Unknown");

            // Notify user of successful login
            MessageBox.Show("Sign in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();

            // Show dashboard and set student details
            var dashboard = new Student__Dashboard(this);
            dashboard.SetUsernameLabel(username);
            dashboard.SetStudentIDLabel(studentID);
            dashboard.SetStudentIcon(studentGender);

            // Populate dashboard with student courses
            PopulateStudentCourses(dashboard, department, yearSection);

            dashboard.Show();
        }

        private void PopulateStudentCourses(Student__Dashboard dashboard, string department, string yearSection)
        {
            string courseFolderPath = "CourseInformations";
            var courseCards = new List<StudentScheduleCard>();

            // Read course files and populate schedule cards
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

            // Sort the course cards based on the day of the week
            courseCards.Sort((x, y) => CompareDaysOfWeek(x.DayOfTheWeek_lbl.Text, y.DayOfTheWeek_lbl.Text));

            // Add the sorted course cards to the dashboard
            foreach (var card in courseCards)
            {
                dashboard.student_CoursePanel.Controls.Add(card);
            }
        }

        private string GetTeacherName(string courseFileName)
        {
            string teacherFilePath = Path.Combine("TeacherCredentials", courseFileName);

            if (!File.Exists(teacherFilePath)) return "Unknown";

            // Read and parse teacher info
            var teacherInfo = File.ReadAllLines(teacherFilePath)
                .ToDictionary(
                    line => line.Substring(0, line.IndexOf(':')),
                    line => line.Substring(line.IndexOf(':') + 1).Trim()
                );

            var firstName = TryGetValueOrDefault(teacherInfo, "First Name", "Unknown");
            var lastName = TryGetValueOrDefault(teacherInfo, "Last Name", "Unknown");

            return $"{firstName} {lastName}";
        }

        private Dictionary<string, string> GetCourseBlock(IEnumerable<string> lines)
        {
            var block = new Dictionary<string, string>();

            // Parse lines into key-value pairs
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

        private IEnumerable<Dictionary<string, string>> GetCourseBlocks(string[] lines)
        {
            var blocks = new List<Dictionary<string, string>>();
            var currentBlock = new List<string>();

            // Split lines into course blocks
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

        private static TValue TryGetValueOrDefault<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default)
        {
            // Return value if key exists, otherwise return default value
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        private void ShowAccountNotFoundError()
        {
            // Show account not found error message
            MessageBox.Show("The student account you entered does not exist.\n" +
                            "Please check your username or ID and try again.\n\n" +
                            "If you do not have an account, please contact your teacher for assistance.",
                            "Account Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private int CompareDaysOfWeek(string day1, string day2)
        {
            // Define order of days for sorting
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

        private void back__btn_Click(object sender, EventArgs e)
        {
            Role__form role = new Role__form();

            role.Show();
            this.Hide();
        }
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

        }

        private void pictureBox12_Click_1(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
