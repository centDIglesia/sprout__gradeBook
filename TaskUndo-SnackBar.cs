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
    public partial class TaskUndo_SnackBar : UserControl
    {
        private Label messageLabel;
        private Button undoButton;
        private Timer timer;
        public TaskUndo_SnackBar(string message, EventHandler undoHandler)
        {
            InitializeComponent();

            messageLabel = new Label
            {
                Text = message,
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10)
            };

            undoButton = new Button
            {
                Text = "Undo",
                AutoSize = true,
                Location = new System.Drawing.Point(200, 10)
            };
            undoButton.Click += undoHandler;

            this.Controls.Add(messageLabel);
            this.Controls.Add(undoButton);
            this.AutoSize = true;


            timer = new Timer();
            timer.Interval = 3000; // Show snackbar for 3 seconds
            timer.Tick += (s, e) => this.Hide();
            timer.Start();
        }
    }
}
