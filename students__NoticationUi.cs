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
using System.IO;

namespace sprout__gradeBook
{
    public partial class students__NoticationUi : KryptonForm
    {
        private readonly studentLoginForm _studentLoginForm;
        private readonly string _CurrentStudentId;
        private readonly string _CurrentStudentIdDepandSection;

        public students__NoticationUi(studentLoginForm studentLoginForm, string studentID, string currentStudentDepartment)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            _CurrentStudentId = studentID;
            _CurrentStudentIdDepandSection = currentStudentDepartment;
            // Attach KeyDown event handler
            this.KeyPreview = true; // Ensure form receives key events
            this.KeyDown += Student__NotificationUI_KeyDown;
        }

        private void Student__NotificationUI_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Escape key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                Close_btn_Click(sender, e); // Call the existing Close_btn_Click method
            }
        }

        private void students__NoticationFORM_Load(object sender, EventArgs e)
        {

            LoadNotificationCards();

        }
        private void LoadNotificationCards()
        {
            List<string> teachers = _studentLoginForm.GetTeachersForStudent();
            notificationPanel.Controls.Clear();  // Clear any existing notifications

            foreach (string teacher in teachers)
            {
                string teacherAnnouncementFile = $"CourseAnnouncement/{teacher}/Anouncement.txt";

                if (File.Exists(teacherAnnouncementFile))
                {
                    var announcementLines = File.ReadAllLines(teacherAnnouncementFile);

                    // Split the file into individual announcements
                    var announcements = string.Join("\n", announcementLines)
                        .Split(new[] { "------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var announcement in announcements)
                    {
                        var lines = announcement.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        var announcementDict = new Dictionary<string, string>();

                        string currentKey = null;
                        StringBuilder currentValue = new StringBuilder();

                        foreach (var line in lines)
                        {
                            var parts = line.Split(new[] { ':' }, 2);
                            if (parts.Length == 2)
                            {
                                if (currentKey != null)
                                {
                                    announcementDict[currentKey] = currentValue.ToString().Trim();
                                }

                                currentKey = parts[0].Trim();
                                currentValue = new StringBuilder(parts[1].Trim());
                            }
                            else if (currentKey != null)
                            {
                                // Append the line with a newline character to preserve the format
                                currentValue.AppendLine(line.Trim());
                            }
                        }

                        if (currentKey != null)
                        {
                            announcementDict[currentKey] = currentValue.ToString().Trim();
                        }

                        if (announcementDict.TryGetValue("Receiver", out var receiver) &&
                            receiver.Equals(_CurrentStudentIdDepandSection, StringComparison.OrdinalIgnoreCase))
                        {
                            string title = announcementDict.TryGetValue("Title", out var t) ? t : "No Title";
                            string description = announcementDict.TryGetValue("Description", out var d) ? d : "No Description";
                            string timeSent = announcementDict.TryGetValue("Time sent", out var ts) ? ts : "Unknown Time";

                            AddNotificationCard(title, description, timeSent);
                        }
                    }
                }
            }
        }
        private void AddNotificationCard(string title, string description, string timeSent)
        {
            var notifCard = new notificationCARD
            {
                NotifTitle = title,
                NotifDescription = description,
                NotifTimesent = timeSent
            };


            notificationPanel.Controls.Add(notifCard);
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {            
            utilityButton b = new utilityButton();

            b.Closeform(this);
        }
    }
}


/*
private List<string> GetAllTextFilesInDirectory(string directoryPath)
{
    try
    {
        if (Directory.Exists(directoryPath))
        {
            return Directory.GetFiles(directoryPath, "*.txt").ToList();
        }
        else
        {
            MessageBox.Show($"Directory {directoryPath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return new List<string>();
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while accessing directory {directoryPath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return new List<string>();
    }
}
*/