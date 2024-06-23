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
    public partial class Student__AttendanceReport : KryptonForm
    {
        private string studentName;
        private readonly studentsCARD _parentCard;
        public Student__AttendanceReport(studentsCARD ParentCard)
        {
            InitializeComponent();
            _parentCard = ParentCard;
        }
        public string StudentName
        {
            get => studentName;
            set
            {
                studentName = value;
                string firstName = studentName.Split(' ')[0]; // Get the first word of the student's name
                attendanceReport_studentname_lbl.Text = $"{firstName}'s Attendance Report";
            }
        }

        private void Close_btn_Click(object sender, EventArgs e)
        {            
            utilityButton b = new utilityButton();
            b.Closeform(this);            
        }
        public void DisplayAttendanceReport(Dictionary<string, (int presentCount, int totalClasses)> attendanceReport)
        {
            attendanceReport_Panel.Controls.Clear();

            foreach (var entry in attendanceReport)
            {
                var course = entry.Key;
                var (presentCount, totalClasses) = entry.Value;

                var attendanceCard = new AttendanceReport__Card
                {
                    CourseCodelbl = { Text = course },
                    Attendedlbl = { Text = $"{presentCount}" },
                    ClassNumlbl = { Text = $"{totalClasses}" }
                };

                attendanceReport_Panel.Controls.Add(attendanceCard);
            }
        }
    }
}
