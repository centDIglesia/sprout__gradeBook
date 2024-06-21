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
    public partial class todaysScheduleCARD : UserControl
    {
        private bool _isMarkedAsDone = false;
        public event EventHandler MarkAsDoneClicked;
        public todaysScheduleCARD()
        {
            InitializeComponent();
         
            markasdoneBTN.Hide();
            markasdoneBTN.Click += markasdoneBTN_Click;
            donemark.Hide();
        }

        public string _schedSubectName { get => scheduleSubjectName.Text; set => scheduleSubjectName.Text = value; }
        public string _schedSection { get => scheduleSection.Text; set => scheduleSection.Text = value; }
        public string _schedRoomNumber { get => scheduleRoom.Text; set => scheduleRoom.Text = value; }

        public bool IsMarkedAsDone
        {
            get => _isMarkedAsDone;
            set
            {
                _isMarkedAsDone = value;
                UpdateMarkAsDoneState();
            }
        }

        private void markasdoneBTN_Click(object sender, EventArgs e)
        {
            _isMarkedAsDone = true;
            donemark.Show();
          
            markasdoneBTN.Hide();
            MarkAsDoneClicked?.Invoke(this, EventArgs.Empty);
        }

        private void scheduleRoom_Click(object sender, EventArgs e)
        {
            if (!_isMarkedAsDone)
            {
                markasdoneBTN.Show();
              
            }

        }

      

        private void UpdateMarkAsDoneState()
        {
            if (_isMarkedAsDone)
            {
                donemark.Show();
            
                markasdoneBTN.Hide();
            }
            else
            {
                donemark.Hide();
               
                markasdoneBTN.Show();
            }
        }

        private void todaysScheduleCARD_Load(object sender, EventArgs e)
        {
         
            markasdoneBTN.Hide();
            donemark.Hide();
        }
    }
}
