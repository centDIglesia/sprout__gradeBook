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
    public partial class introductionPage : CustomForm
    {


        public introductionPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = CustomColor.mainColor;
            timer1.Start();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();


            Role__form roleForm = new Role__form();

            roleForm.Show();

            this.Hide();

        }




        private void logoImage_Click(object sender, EventArgs e)
        {

        }

        private void round_Click(object sender, EventArgs e)
        {

        }
    }
}
