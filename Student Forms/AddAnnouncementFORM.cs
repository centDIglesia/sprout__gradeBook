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
    public partial class AddAnnouncementFORM : KryptonForm
    {
        private readonly CoursesCARD _parentCard;
        public AddAnnouncementFORM(CoursesCARD parentCard)
        {
            _parentCard = parentCard;
            InitializeComponent();
        }
        private void AddAnnouncementFORM_Load(object sender, EventArgs e)
        {

        }
        private void postBtn_Click_1(object sender, EventArgs e)
        {
            string title = TitleTXTBOX.Text;
            string description = descriprtionTXTBOX.Text;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Please enter a title for the announcement.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please enter a description for the announcement.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _parentCard.saveAnnouncement(title, description);
            MessageBox.Show("Announcement saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Cancelform(this);
        }

        private void TitleTXTBOX_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(TitleTXTBOX, "Title");
        }

        private void TitleTXTBOX_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(TitleTXTBOX, "Title");
        }

        private void descriprtionTXTBOX_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(descriprtionTXTBOX, "Description");
        }

        private void descriprtionTXTBOX_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(descriprtionTXTBOX, "Description");
        }
    }
}

