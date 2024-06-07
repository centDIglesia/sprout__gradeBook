using System;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace sprout__gradeBook
{
    public partial class AddStudentForm : KryptonForm
    {
        teacher__studentsDashboard parent;
        private string teacherSchool; 
        
        public AddStudentForm(teacher__studentsDashboard parentDashboard, string school)
        {
            InitializeComponent();
            parent = parentDashboard;
            teacherSchool = school;
        }

        private void saveNewStudentBTN_Click(object sender, EventArgs e)
        {
            string studentFname = studentFnameTXT.Text;
            string studentMname = studentMnameTXT.Text;
            string studentLname = studentLnameTXT.Text;
            string studentID = studentIDTXT.Text;
            string studentEmail = studentEmailTXT.Text;
            DateTime studentBirthday = studentBirthdayPicker.Value;
            string studentGender = "";
            string studentUsername = studentFname + " " + studentLname;

            if (studentMaleRADIOBUTTON.Checked)
            {
                studentGender = "Male";
            }
            else if (studentFemaleRADIOBUTTON.Checked)
            {
                studentGender = "Female";
            }
            else
            {
                MessageBox.Show("Please select a gender.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string studentDepartment = studentDepartmentTXT.Text;
            string studentYearLevel = studentYearLevelTXT.Text;
            string studentSection = studentSectionTXT.Text;
            string studentSchool = teacherSchool;

            Users newStudent = new Student(studentID, studentFname, studentMname, studentLname, studentEmail, studentUsername, studentBirthday, studentGender, studentYearLevel, studentSection, studentDepartment, studentSchool);

            Account__Manager.SaveStudentUser(newStudent, parent.currentUSer);
            MessageBox.Show("Save successfully");
            this.Close();


        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
