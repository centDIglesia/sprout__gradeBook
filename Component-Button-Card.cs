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
        public Component_Button_Card()
        {
            InitializeComponent();
        }

        private void compoentName_Click(object sender, EventArgs e)
        {

        }

        public string compName { get=> compoentName.Text; set=> compoentName.Text = value; }
    }
}
