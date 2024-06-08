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

        public Image StudentGender
        {
            get => studentGender.Image;
            set => studentGender.Image = value;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void studentsCARD_Load(object sender, EventArgs e)
        {

        }

        private void studentcard__studentName_Click(object sender, EventArgs e)
        {

        }

        private void studentcard__studentName_TextChanged(object sender, EventArgs e)
        {

        }

        private void studentGender_MouseHover(object sender, EventArgs e)
        {
            studentcard__studentName.StateCommon.Content.Color1 = CustomColor.activeColor;
        }

        private void studentcard__studentID_MouseLeave(object sender, EventArgs e)
        {
            studentcard__studentName.StateCommon.Content.Color1 = CustomColor.mainColor;
        }
    }
}
