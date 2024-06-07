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
    public partial class studentsCARD : UserControl
    {
        public studentsCARD()
        {
            InitializeComponent();
        }



        public string StudentName
        {
            get => studentcard__studentName.Text;
            set => studentcard__studentName.Text = value;
        }


        public string StudentID
        {
            get => studentcard__studentID.Text;
            set => studentcard__studentID.Text = value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void studentsCARD_Load(object sender, EventArgs e)
        {

        }
    }
}
