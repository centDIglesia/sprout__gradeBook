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
        private string currentUser;

        public teacher__dashboard(string username)
        {
            InitializeComponent();
            currentUser = username;


            LoadUserDetails();
        }


        //ito yung way para maload yung current user,kukuhain natin yung username tas iacsess na natin yung laman ng file 
        //lagay ko to mamaya sa account__manager para call nalang
        private void LoadUserDetails()
        {
            string folderPath = "teacherCredentials";
            string fullPath = Path.Combine(folderPath, currentUser + ".txt");

            if (File.Exists(fullPath))
            {
                string[] lines = File.ReadAllLines(fullPath);

                foreach (var line in lines)
                {
                    
                    if (line.StartsWith("First Name:"))
                    {
                        string firstName = line.Substring("First Name:".Length).Trim();
                        teachers__firstName.Text = $"Hi, {firstName}";
                        break;
                    }
                }
            }
            else
            {
                teachers__firstName.Text = "First Name: Not Available";
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

        private void teachers__firstName_Click(object sender, EventArgs e)
        {

        }

        private void teacher__dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}
