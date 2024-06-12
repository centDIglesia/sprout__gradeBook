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
using System.IO;

namespace sprout__gradeBook
{
    public partial class students__NoticationUi : KryptonForm
    {
        private readonly studentLoginForm _studentLoginForm;
        private readonly string _CurrentStudentId;
        public students__NoticationUi(studentLoginForm studentLoginForm, string studentID)
        {
            InitializeComponent();
            _studentLoginForm = studentLoginForm;
            _CurrentStudentId = studentID;
        }

        private void students__NoticationFORM_Load(object sender, EventArgs e)
        {

            LoadNotificationCards();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private List<string> GetAllTextFilesInDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    return Directory.GetFiles(directoryPath, "*.txt").ToList();
                }
                else
                {
                    MessageBox.Show($"Directory {directoryPath} does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return new List<string>();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while accessing directory {directoryPath}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<string>();
            }
        }

        private void LoadNotificationCards()
        {

            List<string> teachers = _studentLoginForm.GetTeachersForStudent();

            foreach (string teacher in teachers)
            {

                string teacherAnnouncementDir = $"CourseAnnoucement/{teacher}/Announcemnt.txt";



            }
        }



        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void notificationPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
