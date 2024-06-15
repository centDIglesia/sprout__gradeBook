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

namespace sprout__gradeBook
{
    public partial class Teacher__Feedback : KryptonForm
    {
        private string studentName;
        private readonly studentsCARD _parentCard;
        public Teacher__Feedback(studentsCARD ParentCard)
        {
            _parentCard = ParentCard;
            InitializeComponent();
        }      
        public string StudentName
        {
            get => studentName;
            set
            {
                studentName = value;
                string firstName = studentName.Split(' ')[0]; // Get the first word of the student's name
                feedback_studentname_lbl.Text = $"Give {firstName} some feedback";
            }
        }

        private void sendFeedback_btn_Click(object sender, EventArgs e)
        {
            string title = feedbackTitle_txt.Text;
            string description = feedbackDescription_txt.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title for your feedback.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a description for your feedback.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _parentCard.saveFeedback(title,description);
            MessageBox.Show("Feedback sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            utilityButton cancel = new utilityButton();
            cancel.Cancelform(this); 
        }

        private void feedbackTitle_txt_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(feedbackTitle_txt, "Title");
        }

        private void feedbackTitle_txt_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(feedbackTitle_txt, "Title");
        }

        private void feedbackDescription_txt_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(feedbackDescription_txt, "Description");
        }

        private void feedbackDescription_txt_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(feedbackDescription_txt, "Description");
        }
    }
}
