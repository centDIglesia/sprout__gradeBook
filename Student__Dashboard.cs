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
    public partial class Student__Dashboard : KryptonForm
    {
        private string currentUser;
        private KryptonButton Button;
        public Student__Dashboard(string currentUserName)
        {
            InitializeComponent();
            currentUser = currentUserName;
        }
        public void loadForm(Form form)
        {
            if (this.Student_viewPanel.Controls.Count > 0) this.Student_viewPanel.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.Student_viewPanel.Controls.Add(form);
            this.Student_viewPanel.Tag = form;
            form.Show();
        }

        private void btn_dashboard_student_Click(object sender, EventArgs e)
        {
            loadForm(new Student__mainDashboard(currentUser));
        }

        private void btn_courses_student_Click(object sender, EventArgs e)
        {
            loadForm(new Student__coursesDashboard(currentUser));
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
    }
}
