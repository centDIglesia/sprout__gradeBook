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
    public partial class Feedback__Card : UserControl
    {
        public Feedback__Card()
        {
            InitializeComponent();
        }

        public string Feedback_Title { get => feedback_Title.Text; set => feedback_Title.Text = value; }

        public string Feedback_Description { get => feedback_Description.Text; set => feedback_Description.Text = value; }

        public string Feedback_Sender { get => teacher__Name.Text; set => teacher__Name.Text = value; }
    }
}
