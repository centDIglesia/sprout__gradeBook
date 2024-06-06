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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace sprout__gradeBook
{
    public partial class Student__mainDashboard : KryptonForm
    {
        public Student__mainDashboard(string currentUser)
        {
            InitializeComponent();
            UpdateCurrentDateLabel();            
        }


        //===Update Date Label===\\
        private void UpdateCurrentDateLabel()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MMMM dd, yyyy");
            currentDate_lbl.Text = formattedDate;
        }


    }
}
