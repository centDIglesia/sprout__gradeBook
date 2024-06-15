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
        bool compCardisClicked = false;

        private readonly Label _currentComponentlbl;
        public Component_Button_Card(Label currentComponentlbl)
        {
            InitializeComponent();
            _currentComponentlbl = currentComponentlbl;

        }

        public string compName { get => compoentName.Text; set => compoentName.Text = value; }


        private void Component_Button_Card_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
             compCardisClicked = true;
            _currentComponentlbl.Text = compName;
        }

        public bool IsCardClicked()
        {
            return compCardisClicked;
        }
    }
}
