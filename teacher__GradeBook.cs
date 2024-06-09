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
    public partial class teacher__GradeBook : KryptonForm
    {
        public string currentUSer { get; set; }
        public teacher__GradeBook(string currentuser)
        {
            currentUSer=currentuser;
            InitializeComponent();
        }

        private void teacher__GradeBook_Load(object sender, EventArgs e)
        {

        }
    }
}
