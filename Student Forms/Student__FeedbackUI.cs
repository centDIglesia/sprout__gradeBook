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
            // Attach KeyDown event handler
            this.KeyPreview = true; // Ensure form receives key events
            this.KeyDown += Student__FeedbackUI_KeyDown;
        }

        private void Student__FeedbackUI_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Escape key is pressed
            if (e.KeyCode == Keys.Escape)
            {
                Close_btn_Click(sender, e); // Call the existing Close_btn_Click method
            }
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
                    var feedbackLines = File.ReadAllLines(teacherFeedbackFile);

                    // Split the file into individual announcements
                    var feedbacks = string.Join("\n", feedbackLines)
                        .Split(new[] { "------------------------------" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var feedback in feedbacks)
                    {
                        var lines = feedback.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        var feedbackDict = new Dictionary<string, string>();

                        string currentKey = null;
                        StringBuilder currentValue = new StringBuilder();

                        foreach (var line in lines)
                        {
                            var parts = line.Split(new[] { ':' }, 2);
                            if (parts.Length == 2)
                            {
                                if (currentKey != null)
                                {
                                    feedbackDict[currentKey] = currentValue.ToString().Trim();
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
                            feedbackDict[currentKey] = currentValue.ToString().Trim();
                        }

                        // Check if the receiver's ID matches the current student's ID
                        if (feedbackDict.TryGetValue("Receiver", out var receiver))
                        {
                            var receiverParts = receiver.Split('|');
                            if (receiverParts.Length > 0)
                            {
                                var receiverID = receiverParts[0].Trim();
                                if (receiverID.Equals(_CurrentStudentId, StringComparison.OrdinalIgnoreCase))
                                {
                                    string title = feedbackDict.TryGetValue("Title", out var t) ? t : "No Title";
                                    string description = feedbackDict.TryGetValue("Description", out var d) ? d : "No Description";
                                    string sender = feedbackDict.TryGetValue("Sender", out var ts) ? ts : "Unknown Sender";

                                    AddFeedbackCard(title, description, sender);
                                }
                            }
                        }
                    }
                }
            }
        }
        private void AddFeedbackCard(string title, string description, string sender)
        {
            Feedback__Card feedback__Card = new Feedback__Card
            {
                Feedback_Title = title,
                Feedback_Description = description,
                Feedback_Sender = sender
            };

            feedbackPanel.Controls.Add(feedback__Card);
        }
        private void Close_btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();
            b.Closeform(this);
        }

    }
}
