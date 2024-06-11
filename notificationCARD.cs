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
    public partial class notificationCARD : UserControl
    {
        public notificationCARD()
        {
            InitializeComponent();
        }

        public string notifTitle { get => titleTXTBX.Text; set => titleTXTBX.Text = value; }

        public string notifDescription { get => descriptionTXTBX.Text; set => descriptionTXTBX.Text = value; }
        private void notificationCARD_Load(object sender, EventArgs e)
        {

        }
    }
}
