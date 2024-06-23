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
        private PictureBox _pict3;

        public studentsInGradebookCARD(teacher__GradeBook teacherForm, Panel subcom, Panel compsbutton, PictureBox addSubcomponents, KryptonLabel CurrentGradePeriod, PictureBox pict3)
        {
            InitializeComponent();
            _subcomponentsPanel = subcom;
            _pict3 = pict3;
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
            bool isGraded = _teacherForm.IsTermAlreadyGraded(currentStudentID, _teacherForm.selectedGradePeriod);

            if (!_teacherForm.isFirstStudentClicked)
            {
                _teacherForm.isFirstStudentClicked = true;
            }
            else
            {
                if (_teacherForm.isStudentGraded && !isGraded)
                {
                    _teacherForm.ResetComponentsForNewStudent();
                }
                else if (!MarkAsGraded.Visible && !isGraded)
                {

                    return;

                }
            }

            // Update the isStudentGraded flag in the teacher form
            _teacherForm.isStudentGraded = isGraded;

            if (isGraded)
            {
                MessageBox.Show($"The student '{currentStudentName}' has already been graded for the term '{_teacherForm.selectedGradePeriod}'.", "Already Graded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MarkAsGraded.Show();
                return;
            }
            else
            {
                // Show the components button and other components
                _subcomponentsPanel.Visible = true;
                _ComponentsButtonPanel.Visible = true;
                _addSubcomponents.Enabled = true;
                _pict3.Visible = true;
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


            this.Enabled = !isGraded;

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
