using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sprout__gradeBook
{
    internal class utilityButton
    {

        public void Exitform()
        {
            DialogResult result = MessageBox.Show(
                  "Are you sure you want to exit?",
                  "Exit Confirmation",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question
              );

            // Check the result of the message box
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        public void Closeform(Form form)
        {
            form.Close();
        }

        public void Cancelform(Form form)
        {
            DialogResult result = MessageBox.Show(
                 "Do you want to cancel adding this information?",
                 "Cancellation Confirmation",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question
             );

            // Check the result of the message box
            if (result == DialogResult.Yes)
            {
                form.Close();
            }
        }

        public void ConfirmLogout(Form form)
        {
            string message = "Are you sure you want to log out?";
            string title = "Logout Confirmation";


            DialogResult result = MessageBox.Show(
                message,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            // Check if the user clicked Yes
            if (result == DialogResult.Yes)
            {
                form.Close();  // Close the form upon confirmation
            }
        }


    }
}
