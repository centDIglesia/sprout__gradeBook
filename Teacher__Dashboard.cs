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
    public partial class Teacher_Dashboard : KryptonForm
    {
        private string currentUser;

        public Teacher_Dashboard(string currentUserName)
        {
            InitializeComponent();
            currentUser = currentUserName;


            teachers__firstName.Text = $"Hi, {Account__Manager.loadUserData("teacherCredentials", currentUserName, "First Name")}";
        }

        public void loadForm(Form form)
        {
            if (this.viewPanel.Controls.Count > 0) this.viewPanel.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.viewPanel.Controls.Add(form);
            this.viewPanel.Tag = form;
            form.Show();
        }



        private void btn_dashboard_Click(object sender, EventArgs e)
        {

            loadForm(new teacher__mainDashboard(currentUser));
        }

        private void btn_courses_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__courses_lvl1(currentUser));
        }

        private void btn_students_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__studentsDashboard(currentUser));
        }

        private void v_Load(object sender, EventArgs e)
        {

        }

        private void viewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_gradeBook_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__GradeBook(currentUser));
        }
    }
}
