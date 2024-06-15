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
    public static class UserInput_Manager
    {
        //placeholder 
        public static void ResetInputField(KryptonTextBox textBox, string defaultText)
        {
            if (textBox.Text == defaultText)
            {
                textBox.Text = "";
                textBox.StateCommon.Content.Color1 = CustomColor.mainColor;
            }
        }

        public static void RestoreDefaultText(KryptonTextBox textBox, string defaultText)
        {
            if (textBox.Text == "")
            {
                textBox.Text = defaultText;
                textBox.StateCommon.Content.Color1 = CustomColor.lightColor;
            }
        }

        //Tooltip
        public static void ToggleTooltip(KryptonTextBox textBox, Label tooltip, string defaultText)
        {
            if (textBox.Text != defaultText)
            {
                tooltip.Show();
            }
            else
            {
                tooltip.Hide();
            }
        }

        internal static void ResetInputField(KryptonMaskedTextBox courseStartTXT, string v)
        {
            throw new NotImplementedException();
        }

        internal static void RestoreDefaultText(KryptonMaskedTextBox courseStartTXT, string v)
        {
            throw new NotImplementedException();
        }
    }
}
