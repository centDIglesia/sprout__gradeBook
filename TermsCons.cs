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
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(TermsandConditions_KeyDown);
        }
        private void TermsandConditions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                acceptBtn_Click(sender, e);
                e.Handled = true;
            }
        }
        private void acceptBtn_Click(object sender, EventArgs e)
        {
            utilityButton b = new utilityButton();
            b.Closeform(this);
        }
        private void declineBtn_Click(object sender, EventArgs e)
        {         
            MessageBox.Show("You must accept the Terms and Conditions to use the system. Please accept the terms to proceed.", "Decline Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }
}
