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
    public partial class Course_Information__Manager : KryptonForm
    {
        private FlowLayoutPanel _courseViewPanel;

        public Course_Information__Manager(FlowLayoutPanel courseViewPanel)
        {
            InitializeComponent();
            _courseViewPanel = courseViewPanel; // Store the reference to the FlowLayoutPanel
        }

        private void add_course_btn_Click(object sender, EventArgs e)
        {
            Course_Card form3 = new Course_Card();
            form3.TopLevel = false; // Set it as a non-top-level control
            form3.FormBorderStyle = FormBorderStyle.None; // Remove border
            form3.Dock = DockStyle.Top; // Optional: Adjust as needed
            _courseViewPanel.Controls.Add(form3); // Add Form3 to the FlowLayoutPanel
            form3.Show(); // Display the Form3
        }
    }
}
