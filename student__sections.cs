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
    public partial class Student__sections : UserControl
    {
        public Student__sections()
        {
            InitializeComponent();

        }

        private void student__sections_Load(object sender, EventArgs e)
        {

        }

        public string subjectCode
        {
            get
            {
                return subjectCodeTXT.Text;
            }
            set
            {
                subjectCodeTXT.Text = value;
            }
        }

        public string subjectSchedule
        {
            get
            {
                return subjectScheduleTXT.Text;
            }
            set
            {
                subjectScheduleTXT.Text = value;
            }
        }
        public string subjectName
        {
            get
            {
                return subjectNameTXT.Text;
            }
            set
            {
                subjectNameTXT.Text = value;
            }
        }

        public string studentCount
        {
            get
            {
                return studentCountTXT.Text;
            }
            set
            {
                studentCountTXT.Text = value;
            }
        }

        private void student__sections_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = CustomColor.activeColor;
        }

        private void student__sections_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = CustomColor.mainColor;
        }

        private void subjectCodeTXT_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = CustomColor.activeColor;
        }
    }
}
