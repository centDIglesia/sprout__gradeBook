using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
        public Student__Dashboard()
        {
            InitializeComponent();
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
        public void SetUsernameLabel(string username)
        {
            student_Name.Text = $"Hi, {username}";
        }
        public void SetStudentIDLabel(string studentID)
        {
            student_ID.Text = studentID;
        }
        public void SetStudentIcon(string studentID)
        {
            if (studentID == "Male")
            {
                student_Icon.Image = Properties.Resources.maleee;
            }
            else
            {
                student_Icon.Image = Properties.Resources.femaleee;

            }
        }

        private void Student__Dashboard_Load(object sender, EventArgs e)
        {

        }
    }
}

