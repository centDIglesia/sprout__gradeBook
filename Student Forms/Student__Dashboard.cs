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
using sprout__gradeBook;

namespace sprout__gradeBook
{
    public partial class Student__Dashboard : KryptonForm
    {
        private string currentUser;
        public Student__Dashboard(string currentUserName)
        {
            InitializeComponent();
            currentUser = currentUserName;

            student_Name.Text = $"{Account__Manager.loadUserData("StudentCredentials", currentUserName, "Student Name")}";
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

        private void Student__Dashboard_Load(object sender, EventArgs e)
        {
            
        }
    }
}

    