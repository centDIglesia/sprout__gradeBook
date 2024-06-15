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
            this.announcementTitle_txt = new System.Windows.Forms.Label();
            this.description_txt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.timeStamp_txt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // announcementTitle_txt
            // 
            this.announcementTitle_txt.AutoSize = true;
            this.announcementTitle_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.announcementTitle_txt.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold);
            this.announcementTitle_txt.ForeColor = System.Drawing.Color.White;
            this.announcementTitle_txt.Location = new System.Drawing.Point(7, 6);
            this.announcementTitle_txt.Name = "announcementTitle_txt";
            this.announcementTitle_txt.Size = new System.Drawing.Size(144, 23);
            this.announcementTitle_txt.TabIndex = 0;
            this.announcementTitle_txt.Text = "announcementTitle";
            // 
            // description_txt
            // 
            this.description_txt.Enabled = false;
            this.description_txt.Location = new System.Drawing.Point(11, 33);
            this.description_txt.Multiline = true;
            this.description_txt.Name = "description_txt";
            this.description_txt.ReadOnly = true;
            this.description_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.description_txt.Size = new System.Drawing.Size(280, 80);
            this.description_txt.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.description_txt.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.description_txt.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.description_txt.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.description_txt.StateCommon.Border.Rounding = 0;
            this.description_txt.StateCommon.Border.Width = 0;
            this.description_txt.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.description_txt.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.description_txt.TabIndex = 1;
            // 
            // timeStamp_txt
            // 
            this.timeStamp_txt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.timeStamp_txt.Font = new System.Drawing.Font("Poppins", 8F);
            this.timeStamp_txt.ForeColor = System.Drawing.Color.Silver;
            this.timeStamp_txt.Location = new System.Drawing.Point(189, 8);
            this.timeStamp_txt.Name = "timeStamp_txt";
            this.timeStamp_txt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.timeStamp_txt.Size = new System.Drawing.Size(104, 19);
            this.timeStamp_txt.TabIndex = 2;
            this.timeStamp_txt.Text = "timeStamp";
            // 
            // notificationCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.timeStamp_txt);
            this.Controls.Add(this.description_txt);
            this.Controls.Add(this.announcementTitle_txt);
            this.DoubleBuffered = true;
            this.Name = "notificationCARD";
            this.Size = new System.Drawing.Size(304, 126);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label announcementTitle_txt;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox description_txt;
        private System.Windows.Forms.Label timeStamp_txt;
    }
}
