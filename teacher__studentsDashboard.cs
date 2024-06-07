using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static System.Collections.Specialized.BitVector32;

namespace sprout__gradeBook
{
    public partial class teacher__studentsDashboard : KryptonForm
    {
        public string currentUSer { get; set; }
        private string teacherSchool;

        public teacher__studentsDashboard(string currentuser)
        {
            InitializeComponent();
            currentUSer = currentuser;
            teacherSchool = LoadTeacherSchool(currentuser);
        }

        private void teacher__studentsDashboard_Load(object sender, EventArgs e)
        {

        }

        private string LoadTeacherSchool(string currentUser)
        {
            // This is a simplified example. In a real application, this might query a database or configuration file.
            string teacherDetailsFile = $"teacherCredentials/{currentUser}.txt";
            if (!File.Exists(teacherDetailsFile))
            {
                throw new FileNotFoundException("Teacher details file not found.");
            }

            string[] lines = File.ReadAllLines(teacherDetailsFile);
            foreach (var line in lines)
            {
                if (line.StartsWith("School:"))
                {
                    return line.Split(':')[1].Trim();
                }
            }

            throw new Exception("School information not found in teacher details file.");
        }

        public void loadForm(Form form)
        {
            if (this.Controls.Count > 0) this.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.Controls.Add(form);
            this.Tag = form;
            form.Show();
        }


        private void StudentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addStudentsBTN_Click(object sender, EventArgs e)
        {
            // Replace this with the actual school information
            AddStudentForm addStudentForm = new AddStudentForm(this, teacherSchool);
            addStudentForm.Show();
        }
    }
}
