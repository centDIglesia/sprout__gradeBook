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

        public string NotifTitle { get => announcementTitle_txt.Text; set => announcementTitle_txt.Text = value; }

        public string NotifDescription { get => description_txt.Text; set => description_txt.Text = value; }

        public string NotifTimesent { get => timeStamp_txt.Text; set => timeStamp_txt.Text = value; }
        
    }
}
