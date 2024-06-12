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

            parent.LoadStudentCourses();
        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void studentIDTXT_Leave(object sender, EventArgs e)
        {
            //implement here if student id already exist
            UserInput_Manager.RestoreDefaultText(studentIDTXT, "Student ID");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();

            b.Cancelform(this);
        }

        private void studentFnameTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentIDTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentIDTXT, "Student ID");
        }

        private void studentEmailTXT_Enter(object sender, EventArgs e)
        {

            UserInput_Manager.ResetInputField(studentEmailTXT, "Email");
        }

        private void studentEmailTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentEmailTXT, "Email");
        }

        private void studentYearLevelTXT_Enter(object sender, EventArgs e)
        {

            UserInput_Manager.ResetInputField(studentYearLevelTXT, "Year Level");
        }

        private void studentYearLevelTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentYearLevelTXT, "Year Level");
        }

        private void studentSectionTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentSectionTXT, "Section");
        }

        private void studentSectionTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentSectionTXT, "Section");
        }

        private void studentFnameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentFnameTXT, "First Name");
        }

        private void studentFnameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentFnameTXT, "First Name");
        }

        private void studentMnameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentMnameTXT, "Middle Name");
        }

        private void studentMnameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentMnameTXT, "Middle Name");
        }

        private void studentLnameTXT_Enter(object sender, EventArgs e)
        {
            UserInput_Manager.ResetInputField(studentLnameTXT, "Last Name");
        }

        private void studentLnameTXT_Leave(object sender, EventArgs e)
        {
            UserInput_Manager.RestoreDefaultText(studentLnameTXT, "Last Name");
        }
    }
}
