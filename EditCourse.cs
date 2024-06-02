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
    public partial class EditCourse : KryptonForm
    {


        private string subjectName;
        private string subjectCode;
        private string subjectCount;
        private string subjectSchedule;
        private string subjectCourseSection;

        public EditCourse(string name, string code, string count, string schedule, string section)
        {
            InitializeComponent();

            subjectName = name;
            subjectCode = code;
            subjectCount = count;
            subjectSchedule = schedule;
            subjectCourseSection = section;

            CourseCode.Text = subjectCode;
            SubjectNameLbl.Text = subjectName;
            subjectScheduleLBL.Text = subjectSchedule;
            studentCountLBL.Text = subjectCount;
            subjectCourseandSectionlbl.Text = subjectCourseSection;

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void EditCourse_Load(object sender, EventArgs e)
        {

        }

        private void editInfoBTN_Click(object sender, EventArgs e)
        {
            CourseCode.ReadOnly = false;
            CourseCode.Focus();

        }
    }
}
