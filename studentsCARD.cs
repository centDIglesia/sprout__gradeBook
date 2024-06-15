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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace sprout__gradeBook
{
    public partial class studentsCARD : UserControl
    {
        private readonly teacher__studentsDashboard _parent;
        private readonly string _currentUser;
     
        public studentsCARD(teacher__studentsDashboard parent)
        {
            InitializeComponent();
            _currentUser = parent.currentUSer;
             _parent = parent;
           
        }

        public string StudentName
        {
            get => studentcard__studentName.Text;
            set => studentcard__studentName.Text = value;
        }


        public string StudentID
        {
            get => studentcard__studentID.Text;
            set => studentcard__studentID.Text = value;
        }

        public Image StudentGender
        {
            get => studentGender.Image;
            set => studentGender.Image = value;
        }

        private void studentsCARD_Load(object sender, EventArgs e)
        {
            clickedBG.Hide();
            feedback_btn.Hide();
        }

        private void studentcard__studentName_Click(object sender, EventArgs e)
        {
            clickedBG.Show();
            feedback_btn.Show();
        }

        private void studentGender_MouseHover(object sender, EventArgs e)
        {
            studentcard__studentName.StateCommon.Content.Color1 = CustomColor.activeColor;
        }

        private void studentcard__studentID_MouseLeave(object sender, EventArgs e)
        {
            studentcard__studentName.StateCommon.Content.Color1 = CustomColor.mainColor;
        }

        private void clickedBG_Click(object sender, EventArgs e)
        {
            clickedBG.Hide();
            feedback_btn.Hide();
        }

        private void feedback_btn_Click(object sender, EventArgs e)
        {
            Form formbackground = new Form();

            using (Teacher__Feedback teacher__Feedback = new Teacher__Feedback(this))
            {
                formbackground.StartPosition = FormStartPosition.CenterScreen;
                formbackground.FormBorderStyle = FormBorderStyle.None;
                formbackground.Opacity = .90d;
                formbackground.BackColor = CustomColor.mainColor;
                formbackground.Size = new Size(1147, 711);

                teacher__Feedback.StudentName = this.StudentName;

                formbackground.Location = this.Location;

                formbackground.ShowInTaskbar = false;
                formbackground.Show();

                teacher__Feedback.Owner = formbackground;
                teacher__Feedback.ShowDialog();
            }
            formbackground.Dispose();

        }
        public void saveFeedback(string title, string description)
        {
            string baseDirectory = $"StudentFeedbacks/{_currentUser}";

            if (!Directory.Exists(baseDirectory))
            {
                Directory.CreateDirectory(baseDirectory);
            }
            string fullPath = Path.Combine(baseDirectory, $"Feedbacks.txt");

            using (StreamWriter write = new StreamWriter(fullPath, true))
            {
                write.WriteLine($"Receiver : {StudentID} | {StudentName}");
                write.WriteLine($"Title : {title}");
                write.WriteLine($"Sender : {GetFirstName()}");
                write.WriteLine($"Description :{description}");
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

    }
}
