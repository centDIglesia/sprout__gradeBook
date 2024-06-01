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
    public partial class teacher__courses_lvl1 : KryptonForm
    {
        public static teacher__courses_lvl1 lvl1Instance;
        private string currrentUser;
        public teacher__courses_lvl1(string currentUsername)
        {
            currrentUser = currentUsername;
            InitializeComponent();
            lvl1Instance = this;
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

        private void add_course_btn_Click(object sender, EventArgs e)
        {
            Course_Information__Manager Form2 = new Course_Information__Manager();
            Form2.Show();
        }

        private void teacher__courses_lvl1_Load(object sender, EventArgs e)
        {

        }

        private void kryptonMaskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void courses1_Load(object sender, EventArgs e)
        {

        }

        private void addcourseBTN_Click(object sender, EventArgs e)
        {
            AddCourseForm adf = new AddCourseForm(currrentUser);
            adf.Show();
        }

        private void deleteBTN_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
