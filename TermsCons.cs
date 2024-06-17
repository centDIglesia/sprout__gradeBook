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
    public partial class TermsCons: KryptonForm
    {
        public TermsCons()
        {
            InitializeComponent();
        }

        private void TermsCons_Load(object sender, EventArgs e)
        {

        }

        private void signIn__btn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();
            b.Closeform(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.Group_85sd;
        }
    }
}
