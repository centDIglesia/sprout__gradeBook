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
    public partial class NewTask : UserControl
    {
        public NewTask()
        {
            InitializeComponent();
        }
        public string TaskText
        {
            get { return newTask__chkbx.Text; }
            set { newTask__chkbx.Text = value; }
        }
                public event EventHandler<TaskDeletedEventArgs> TaskDeleted;
        private void newTask__chkbx_CheckedChanged(object sender, EventArgs e)
        {
            deleteTask_Tooltip.Show();
        }

        private void NewTask_Load(object sender, EventArgs e)
        {
            deleteTask_Tooltip.Hide();
        }

        private void deleteTask_Tooltip_Click(object sender, EventArgs e)
        {
            TaskDeleted?.Invoke(this, new TaskDeletedEventArgs { TaskText = TaskText });
            
        }
        public class TaskDeletedEventArgs : EventArgs
        {
            public string TaskText { get; set; }
        }
    }
}
