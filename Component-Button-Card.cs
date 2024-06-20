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
    public partial class Component_Button_Card : UserControl
    {
        public bool IsCurrentComponentButtonGraded { get; set; } = false;

        private readonly displayGradeBookPanelDelegate _displayGradeBookPanelDelegate;
        private readonly Label _currentComponentlbl;
        private readonly KryptonLabel _CurrentGradePeriod;
        public Component_Button_Card(Label currentComponentlbl, displayGradeBookPanelDelegate displayGradeBookPanelDelegate, KryptonLabel currentGradePeriod)
        {
            InitializeComponent();
            _currentComponentlbl = currentComponentlbl;
            _displayGradeBookPanelDelegate = displayGradeBookPanelDelegate;
            _CurrentGradePeriod = currentGradePeriod;
        }

        public string compName { get => compoentName.Text; set => compoentName.Text = value; }


        private void Component_Button_Card_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            _CurrentGradePeriod.Text = "Click 'Add Subcomponents +' to add details.";

            var parentForm = this.FindForm() as teacher__GradeBook;

            if (parentForm == null)
                return;

            if (parentForm._currentActiveComponentButton != null &&
                parentForm._currentActiveComponentButton != this)
            {
                MessageBox.Show("Please complete the current component action before proceeding to another.", "Action Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            parentForm.ResetSubcomponentsPanel();
            parentForm.ShowSubcomponentsAndDoneBtn();

            parentForm._currentActiveComponentButton = this;
            parentForm.SetComponentButtonsEnabled(false);

            parentForm.clearSubcomponentsPanel();

            parentForm.componentCount = 0;

            _currentComponentlbl.Text = compName;
            _displayGradeBookPanelDelegate();



        }


    }
}
