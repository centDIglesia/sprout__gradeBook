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
    public partial class teacher__dashboard : KryptonForm
    {
     

        public teacher__dashboard(string currentUserName)
        {
            InitializeComponent();
         

            teachers__firstName.Text = $"Hi, {Account__Manager.loadUserData("teacherCredentials", currentUserName, "First Name")}";
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
    }
}
