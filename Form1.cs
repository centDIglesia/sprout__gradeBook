﻿using System;
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
    public partial class introductionPage : KryptonForm
    {
        public Color mainColor = Color.FromArgb(0x0A, 0x67, 0x38);

        public introductionPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = mainColor;
            timer1.Start();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop(); 
            role__form roleForm = new role__form();
           
            roleForm.Show();
           
        }
    }
}
