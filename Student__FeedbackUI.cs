using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{

    public partial class Student__FeedbackUI : KryptonForm
    {
        private readonly studentLoginForm _studentLoginForm;
        private readonly string _CurrentStudentId;

        public Student__FeedbackUI(studentLoginForm studentLoginForm, string studentID)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            _CurrentStudentId = studentID;
        }
    
         private void Student__FeedbackUI_Load(object sender, EventArgs e)
        {
            LoadFeedbackCards();
        }
        private void LoadFeedbackCards()
        {
            List<string> teachers = _studentLoginForm.GetTeachersForStudent();
            feedbackPanel.Controls.Clear();  // Clear any existing notifications

            foreach (string teacher in teachers)
            {
                string teacherFeedbackFile = $"StudentFeedbacks/{teacher}/Feedbacks.txt";

                if (File.Exists(teacherFeedbackFile))
                {
                    var announcementLines = File.ReadAllLines(teacherFeedbackFile);

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
                            receiver.Equals(_CurrentStudentId, StringComparison.OrdinalIgnoreCase))
                        {
                            string title = announcementDict.TryGetValue("Title", out var t) ? t : "No Title";
                            string description = announcementDict.TryGetValue("Description", out var d) ? d : "No Description";
                            string sender = announcementDict.TryGetValue("Sender", out var ts) ? ts : "Unknown Time";

                            AddFeedbackCard(title, description, sender);
                        }
                    }
                }
            }
        }
        private void AddFeedbackCard(string title, string description, string sender)
        {
            var feedback__Card = new Feedback__Card
            {
                Feedback_Title = title,
                Feedback_Description = description,
                Feedback_Sender = sender
            };


            feedbackPanel.Controls.Add(feedback__Card);
        }

    }
}
