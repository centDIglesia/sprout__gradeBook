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
        private string currentUser;

        public teacher__globalNav(string username)
        {
            InitializeComponent();
            currentUser = username;
        }

        public void loadForm(Form form)
        {
            if (this.viewPanel.Controls.Count > 0) this.viewPanel.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.viewPanel.Controls.Add(form);
            this.viewPanel.Tag = form;
            form.Show();
        }

        private void teacher__globalNav_Load(object sender, EventArgs e)
        {
            loadForm(new teacher__dashboard(currentUser));
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__dashboard(currentUser));
        }

        private void btn_courses_Click(object sender, EventArgs e)
        {
            loadForm(new teacher__courses_lvl1());
        }
    }
}
