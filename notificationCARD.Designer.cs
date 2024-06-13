namespace sprout__gradeBook
{
    partial class notificationCARD
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(notificationCARD));
            this.titleTXTBX = new System.Windows.Forms.Label();
            this.descriptionTXTBX = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.notifTimesent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleTXTBX
            // 
            this.titleTXTBX.AutoSize = true;
            this.titleTXTBX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.titleTXTBX.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTXTBX.ForeColor = System.Drawing.Color.White;
            this.titleTXTBX.Location = new System.Drawing.Point(8, 5);
            this.titleTXTBX.Name = "titleTXTBX";
            this.titleTXTBX.Size = new System.Drawing.Size(31, 22);
            this.titleTXTBX.TabIndex = 0;
            this.titleTXTBX.Text = "title";
            // 
            // descriptionTXTBX
            // 
            this.descriptionTXTBX.Enabled = false;
            this.descriptionTXTBX.Location = new System.Drawing.Point(11, 32);
            this.descriptionTXTBX.Multiline = true;
            this.descriptionTXTBX.Name = "descriptionTXTBX";
            this.descriptionTXTBX.ReadOnly = true;
            this.descriptionTXTBX.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.descriptionTXTBX.Size = new System.Drawing.Size(280, 80);
            this.descriptionTXTBX.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.descriptionTXTBX.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.descriptionTXTBX.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.descriptionTXTBX.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.descriptionTXTBX.StateCommon.Border.Rounding = 0;
            this.descriptionTXTBX.StateCommon.Border.Width = 0;
            this.descriptionTXTBX.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.descriptionTXTBX.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptionTXTBX.TabIndex = 1;
            // 
            // notifTimesent
            // 
            this.notifTimesent.AutoSize = true;
            this.notifTimesent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.notifTimesent.Font = new System.Drawing.Font("Poppins", 8F);
            this.notifTimesent.ForeColor = System.Drawing.Color.Gray;
            this.notifTimesent.Location = new System.Drawing.Point(85, 7);
            this.notifTimesent.Name = "notifTimesent";
            this.notifTimesent.Size = new System.Drawing.Size(30, 19);
            this.notifTimesent.TabIndex = 2;
            this.notifTimesent.Text = "title";
            // 
            // notificationCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.notifTimesent);
            this.Controls.Add(this.descriptionTXTBX);
            this.Controls.Add(this.titleTXTBX);
            this.DoubleBuffered = true;
            this.Name = "notificationCARD";
            this.Size = new System.Drawing.Size(304, 126);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleTXTBX;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox descriptionTXTBX;
        private System.Windows.Forms.Label notifTimesent;
    }
}
