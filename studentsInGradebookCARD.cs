using ComponentFactory.Krypton.Toolkit;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    public partial class studentsInGradebookCARD : UserControl
    {


        private readonly teacher__GradeBook _teacherForm;
        public PictureBox MarkAsGraded { get; set; }
        private Panel _subcomponentsPanel;
        private Panel _ComponentsButtonPanel;
        private PictureBox _addSubcomponents;
        private KryptonLabel _CurrentGradePeriod;

        public studentsInGradebookCARD(teacher__GradeBook teacherForm, Panel subcom, Panel compsbutton, PictureBox addSubcomponents, KryptonLabel CurrentGradePeriod)
        {
            InitializeComponent();
            _subcomponentsPanel = subcom;

            _ComponentsButtonPanel = compsbutton;

            _teacherForm = teacherForm;

            _CurrentGradePeriod = CurrentGradePeriod;


            MarkAsGraded = markAsGraded;
            MarkAsGraded.Hide();
            _addSubcomponents = addSubcomponents;
        }


        public string currentStudentName
        {
            get => nameofStudent.Text;
            set => nameofStudent.Text = value;
        }


        public string currentStudentID
        {
            get => idOfStudent.Text;
            set => idOfStudent.Text = value;
        }




        private void studentsInGradebookCARD_Click(object sender, EventArgs e)
        {
            _CurrentGradePeriod.Text = "Pease select a component first.";
            HandleStudentClick();
        }

        private void HandleStudentClick()
        {
            if (!_teacherForm.isFirstStudentClicked)
            {
                _teacherForm.isFirstStudentClicked = true;
            }
            else
            {
                if (_teacherForm.isStudentGraded)
                {
                    _teacherForm.ResetComponentsForNewStudent();
                    _teacherForm.isStudentGraded = false;
                }
                else if (!MarkAsGraded.Visible)
                {
                    var result = MessageBox.Show("You have not saved the grades for the current student. Do you want to proceed and discard unsaved changes?", "Unsaved Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No)
                    {
                        return;
                    }
                    else
                    {
                        _teacherForm.ResetComponentsForNewStudent();
                    }
                }
            }

            if (_teacherForm.IsTermAlreadyGraded(currentStudentID, _teacherForm.selectedGradePeriod))
            {
                MessageBox.Show($"The student '{currentStudentName}' has already been graded for the term '{_teacherForm.selectedGradePeriod}'.", "Already Graded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MarkAsGraded.Show();
                return;
            }

            _teacherForm.StudenttnameText = currentStudentName;
            _teacherForm.StudentIDText = currentStudentID;


            MarkAsGraded.Visible = _teacherForm.IsStudentGraded(currentStudentID);

            // Check if all students are graded
            _teacherForm.CheckIfAllStudentsGraded();
        }


        private void InitializeStudentGradedState()
        {
            bool isGraded = _teacherForm.IsTermAlreadyGraded(currentStudentID, _teacherForm.selectedGradePeriod);
            MarkAsGraded.Visible = isGraded;
            _subcomponentsPanel.Visible = !isGraded;
            _ComponentsButtonPanel.Visible = !isGraded;
            _addSubcomponents.Enabled = !isGraded;
            _teacherForm.isStudentGraded = isGraded;

        }



        private void studentsInGradebookCARD_Load(object sender, EventArgs e)
        {
            InitializeStudentGradedState();

        }

        private void MarkAsGraded_Click(object sender, EventArgs e)
        {

        }
    }

}
