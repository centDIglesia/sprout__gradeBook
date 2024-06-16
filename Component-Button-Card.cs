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

        private displayGradeBookPanelDelegate _displayGradeBookPanelDelegate;
        private readonly Label _currentComponentlbl;
        public Component_Button_Card(Label currentComponentlbl, displayGradeBookPanelDelegate displayGradeBookPanelDelegate)
        {
            InitializeComponent();
            _currentComponentlbl = currentComponentlbl;
            _displayGradeBookPanelDelegate = displayGradeBookPanelDelegate;
        }

        public string compName { get => compoentName.Text; set => compoentName.Text = value; }


        private void Component_Button_Card_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

            _currentComponentlbl.Text = compName;
            _displayGradeBookPanelDelegate();
        }


    }
}
