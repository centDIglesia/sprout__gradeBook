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
    public partial class Courses : UserControl
    {
        public Courses()
        {
            InitializeComponent();

        }

        private void Courses_Load(object sender, EventArgs e)
        {

        }

        public DateTime subjectSchedule { get; set; }
        public string subjectName { get; set; }
        public string subjectCode { get; set; }

        public string subjectCount { get; set; }


    }
}
