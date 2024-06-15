﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.IO;

namespace sprout__gradeBook
{
    public partial class Teacher_Dashboard : KryptonForm
    {
        private readonly string currentUser;

        public Teacher_Dashboard(string currentUserName)
        {
            InitializeComponent();
            currentUser = currentUserName;


            teachers__firstName.Text = $"Hi, {Account__Manager.LoadUserData("teacherCredentials", currentUserName, "First Name")}";
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

        private void btn_gradeBook_Click(object sender, EventArgs e)
        {
            string gradingSystemDirectoryPath = $"CourseGradingSystem/{currentUser}";

            loadForm(new teacher__GradeBook(currentUser));

            /*
             if (Directory.Exists(gradingSystemDirectoryPath))
             {
                 loadForm(new teacher__GradeBook(currentUser));
             }
             else
             {
                 MessageBox.Show("Please create the grading system first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 createGradingSystemFORM crf = new createGradingSystemFORM(currentUser);
                 crf.Show();
             }*/
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Exitform();
        }

        private void back__btn_Click(object sender, EventArgs e)
        {

        }
    }
}
