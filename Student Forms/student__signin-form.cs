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

namespace sprout__gradeBook
{
    public partial class studentLoginForm : KryptonForm
    {

        public studentLoginForm()
        {
            InitializeComponent();
        }

        private void studentLoginForm_Load(object sender, EventArgs e)
        {
            signIn__StIdTooltip.Hide();
            signIn__PassTooltip.Hide();
        }

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

            if (signinPASS__txtbox.Text == "Password")
            {
                signinPASS__txtbox.UseSystemPasswordChar = false;

            }
        }
        bool isPassVisible3 = false;
        private void signIn__showPassicon_Click(object sender, EventArgs e)
        {


            if (!isPassVisible3)
            {
                isPassVisible3 = true;
                signIn__showPassicon.Image = Properties.Resources.closed__eye;
                signinPASS__txtbox.UseSystemPasswordChar = false;
            }
            else
            {
                isPassVisible3 = false;
                signIn__showPassicon.Image = Properties.Resources.open__eye;
                signinPASS__txtbox.UseSystemPasswordChar = true;
            }

        }

        private void showGuide_Click(object sender, EventArgs e)
        {
            StudentDefultPasswordGuide studentDefultPasswordGuide = new StudentDefultPasswordGuide();
            studentDefultPasswordGuide.ShowDialog();


        }

        private void signIn__btn_Click(object sender, EventArgs e)
        {
            string usernameOrId = signinSTID__txtbox.Text;
            string password = signinPASS__txtbox.Text;

            if (usernameOrId == "Student Number" || password == "Password")
            {
                MessageBox.Show("Please fill out all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (usernameOrId == "Student Number")
                {
                    signinSTID__txtbox.Focus();
                }
                else if (password == "Password")
                {
                    signinPASS__txtbox.Focus();
                }

                return;
            }

            bool userFound = false;

            string baseFolderPath = "StudentCredentials";
            string[] teacherDirectories = Directory.GetDirectories(baseFolderPath);

            foreach (string teacherDir in teacherDirectories)
            {
                string studentFilePath = Path.Combine(teacherDir, usernameOrId + ".txt");

                if (File.Exists(studentFilePath))
                {
                    userFound = true;
                    bool isAuthenticated = Account__Manager.AuthenticateStudentLogIn(usernameOrId, password, teacherDir);
                    if (isAuthenticated)
                    {
                        // Read all lines from the file
                        string[] lines = File.ReadAllLines(studentFilePath);

                        // Extract relevant data
                        string username = lines.FirstOrDefault(line => line.StartsWith("Username: "))?.Replace("Username: ", "") ?? "Unknown";
                        string studentID = lines.FirstOrDefault(line => line.StartsWith("Student ID: "))?.Replace("Student ID: ", "") ?? "Unknown";
                        string studentGender = lines.FirstOrDefault(line => line.StartsWith("Gender: "))?.Replace("Gender: ", "") ?? "Unknown";
                        string department = lines.FirstOrDefault(line => line.StartsWith("Department: "))?.Replace("Department: ", "") ?? "Unknown";
                        string yearSection = lines.FirstOrDefault(line => line.StartsWith("Year and Section: "))?.Replace("Year and Section: ", "") ?? "Unknown";

                        MessageBox.Show("Sign in successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        // Pass the username to the next form
                        Student__Dashboard STD_DSH = new Student__Dashboard();
                        STD_DSH.SetUsernameLabel(username); // Set the username label
                        STD_DSH.SetStudentIDLabel(studentID);
                        STD_DSH.SetStudentIcon(studentGender);

                        // Get the path of the CourseInformations folder
                        string courseFolderPath = "CourseInformations";

                        // Get all text files in the CourseInformations folder
                        string[] courseFiles = Directory.GetFiles(courseFolderPath, "*.txt");

                        // Iterate through each file
                        foreach (string courseFile in courseFiles)
                        {
                            // Read all lines from the file
                            string[] courseLines = File.ReadAllLines(courseFile);

                            // Check each block of course information
                            foreach (var courseBlock in GetCourseBlocks(courseLines))
                            {
                                string courseDepartment = courseBlock.FirstOrDefault(line => line.StartsWith("Student Department: "))?.Replace("Student Department: ", "");
                                string courseYearSection = courseBlock.FirstOrDefault(line => line.StartsWith("Student year and section: "))?.Replace("Student year and section: ", "");

                                // Check if the block contains the student's department and year/section
                                if (department == courseDepartment && yearSection == courseYearSection)
                                {
                                    // Extract the course information
                                    string courseName = courseBlock.FirstOrDefault(line => line.StartsWith("Course Name: "))?.Replace("Course Name: ", "");
                                    string courseCode = courseBlock.FirstOrDefault(line => line.StartsWith("Course Code: "))?.Replace("Course Code: ", "");
                                    string schedule = courseBlock.FirstOrDefault(line => line.StartsWith("Course Schedule: "))?.Replace("Course Schedule: ", "");

                                    // Get the name of the course file
                                    string courseFileName = Path.GetFileName(courseFile);

                                    // Search for the corresponding teacher's file in the TeacherCredentials directory
                                    string teacherCredentialsDir = "TeacherCredentials";
                                    string teacherFilePath = Path.Combine(teacherCredentialsDir, courseFileName);

                                    string teacherFirstName = "Unknown";
                                    string teacherLastName = "Unknown";

                                    if (File.Exists(teacherFilePath))
                                    {
                                        string[] teacherLines = File.ReadAllLines(teacherFilePath);
                                        teacherFirstName = teacherLines.FirstOrDefault(line => line.StartsWith("First Name: "))?.Replace("First Name: ", "") ?? "Unknown";
                                        teacherLastName = teacherLines.FirstOrDefault(line => line.StartsWith("Last Name: "))?.Replace("Last Name: ", "") ?? "Unknown";
                                    }

                                    // Create a new StudentScheduleCard and set the labels
                                    StudentScheduleCard card = new StudentScheduleCard();
                                    card.subjectCodeLBL.Text = courseCode;
                                    card.subjectNameLBL.Text = courseName;
                                    card.subjectScheduleLBL.Text = schedule;

                                    // Set the teacher's name on the card
                                    card.teacherNameLBL.Text = $"{teacherFirstName} {teacherLastName}";

                                    // Add the card to the student_CoursePanel
                                    STD_DSH.student_CoursePanel.Controls.Add(card);
                                }
                            }
                        }

                        STD_DSH.Show();
                    }
                    else
                    {
                        MessageBox.Show("Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                }
            }

            if (!userFound)
            {
                MessageBox.Show("The student account you entered does not exist.\n" +
                                "Please check your username or ID and try again. \n\n" +
                                "If you do not have an account, please contact your teacher for assistance.",
                                "Account Not Found",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }


        private void close_btn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (result == DialogResult.No)
            {
                return;
            }
            else Application.Exit();
        }

        // Helper method to split course information blocks
        private IEnumerable<List<string>> GetCourseBlocks(string[] lines)
        {
            var blocks = new List<List<string>>();
            var currentBlock = new List<string>();

            foreach (var line in lines)
            {
                if (line.Trim() == "----------------------------------------")
                {
                    if (currentBlock.Count > 0)
                    {
                        blocks.Add(new List<string>(currentBlock));
                        currentBlock.Clear();
                    }
                }
                else
                {
                    currentBlock.Add(line);
                }
            }

            if (currentBlock.Count > 0)
            {
                blocks.Add(currentBlock);
            }

            return blocks;
        }

        private void studentSIGNINform_Panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

