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
    public partial class studentDefultPasswordGuide : KryptonForm
    {
        public studentDefultPasswordGuide()
        {
            InitializeComponent();
        }

        private void studentDefultPasswordGuide_Load(object sender, EventArgs e)
        {

        }

        private void role__btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
