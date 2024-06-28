using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class Attendance__Row : UserControl
    {
        private readonly Teacher__Attendance _AttendanceForm;
        private KryptonCheckButton[] statusButtons;

        public Attendance__Row(Teacher__Attendance AttendanceForm)
        {
            InitializeComponent();

            _AttendanceForm = AttendanceForm;

            // Initialize status buttons
            statusButtons = new KryptonCheckButton[] { presentButton, absentButton, lateButton, excusedButton };

            foreach (var button in statusButtons)
            {
                button.CheckedChanged += StatusButton_CheckedChanged;
            }
        }

        private void StatusButton_CheckedChanged(object sender, EventArgs e)
        {
            var currentButton = sender as KryptonCheckButton;

            if (currentButton.Checked)
            {
                foreach (var button in statusButtons)
                {
                    if (button != currentButton)
                    {
                        button.Checked = false;
                    }
                }
            }
        }

        // Property to get/set the current student's name
        public string currentStudentName
        {
            get => attendance_studentName.Text;   // Return the text of nameofStudent control
            set => attendance_studentName.Text = value;   // Set the text of nameofStudent control
        }

        // Property to get/set the current student's ID
        public string currentStudentID
        {
            get => attendance_studentID.Text;   // Return the text of idOfStudent control
            set => attendance_studentID.Text = value;   // Set the text of idOfStudent control
        }

        // Property to get the selected status
        public string CurrentStatus
        {
            get
            {
                if (presentButton.Checked) return "Present";
                if (absentButton.Checked) return "Absent";
                if (lateButton.Checked) return "Late";
                if (excusedButton.Checked) return "Excused";
                return "Unknown";
            }
        }

        // Method to set the status based on the given status string
        public void SetCurrentStatus(string status)
        {
            presentButton.Checked = status == "Present";
            absentButton.Checked = status == "Absent";
            lateButton.Checked = status == "Late";
            excusedButton.Checked = status == "Excused";
        }
    }
}
