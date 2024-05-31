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
    public partial class teacher__globalNav : KryptonForm
    {
        public teacher__globalNav()
        {
            InitializeComponent();
        }
        public void loadForm (object Form)
        {
            if (this.viewPanel.Controls.Count > 0) this.viewPanel.Controls.RemoveAt(0);

            Form f = Form as Form;
            f.TopLevel = false; 
            f.Dock = DockStyle.Fill;
            this.viewPanel.Controls.Add(f);
            this.viewPanel.Tag = f;
            f.Show();
        }
        private void teacher__globalNav_Load(object sender, EventArgs e)
        {
            loadForm(new teacher__dashboard());
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__dashboard());
        }

        private void btn_courses_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__courses_lvl1());
        }
    }
}
