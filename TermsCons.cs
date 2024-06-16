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
    public partial class TermsCons: Form
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
    }
}
