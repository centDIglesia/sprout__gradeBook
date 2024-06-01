using System;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class teacher__mainDashboard : KryptonForm
    {
        public teacher__mainDashboard(string currentUser)
        {
            InitializeComponent();
            UpdateCourseCount(currentUser);
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

        private void teacher__dashboard_Load(object sender, EventArgs e)
        {

        }

        private void UpdateCourseCount(string currentUser)
        {
            int count = Course.GetCourseCount(currentUser);
            courseCount.Text = count.ToString();
        }
    }
}
