namespace sprout__gradeBook
{
    partial class todaysScheduleCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(todaysScheduleCARD));
            this.scheduleSection = new System.Windows.Forms.Label();
            this.scheduleRoom = new System.Windows.Forms.Label();
            this.scheduleSubjectName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.markasdoneBTN = new System.Windows.Forms.PictureBox();
            this.donemark = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.markasdoneBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donemark)).BeginInit();
            this.SuspendLayout();
            // 
            // scheduleSection
            // 
            this.scheduleSection.AutoSize = true;
            this.scheduleSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.scheduleSection.Font = new System.Drawing.Font("Poppins Medium", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleSection.ForeColor = System.Drawing.Color.White;
            this.scheduleSection.Location = new System.Drawing.Point(12, 7);
            this.scheduleSection.Name = "scheduleSection";
            this.scheduleSection.Size = new System.Drawing.Size(38, 16);
            this.scheduleSection.TabIndex = 2;
            this.scheduleSection.Text = "label1";
            this.scheduleSection.Click += new System.EventHandler(this.scheduleRoom_Click);
            // 
            // scheduleRoom
            // 
            this.scheduleRoom.AutoSize = true;
            this.scheduleRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.scheduleRoom.Font = new System.Drawing.Font("Poppins", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleRoom.ForeColor = System.Drawing.Color.Silver;
            this.scheduleRoom.Location = new System.Drawing.Point(94, 80);
            this.scheduleRoom.Name = "scheduleRoom";
            this.scheduleRoom.Size = new System.Drawing.Size(34, 16);
            this.scheduleRoom.TabIndex = 3;
            this.scheduleRoom.Text = "label2";
            this.scheduleRoom.Click += new System.EventHandler(this.scheduleRoom_Click);
            // 
            // scheduleSubjectName
            // 
            this.scheduleSubjectName.Enabled = false;
            this.scheduleSubjectName.Location = new System.Drawing.Point(8, 22);
            this.scheduleSubjectName.Multiline = true;
            this.scheduleSubjectName.Name = "scheduleSubjectName";
            this.scheduleSubjectName.ReadOnly = true;
            this.scheduleSubjectName.Size = new System.Drawing.Size(182, 56);
            this.scheduleSubjectName.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.scheduleSubjectName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.scheduleSubjectName.StateCommon.Border.Rounding = 0;
            this.scheduleSubjectName.StateCommon.Border.Width = 0;
            this.scheduleSubjectName.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.scheduleSubjectName.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleSubjectName.TabIndex = 4;
            this.scheduleSubjectName.Text = "scheduelSubject";
            this.scheduleSubjectName.Click += new System.EventHandler(this.scheduleRoom_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(203, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.scheduleRoom_Click);
            // 
            // markasdoneBTN
            // 
            this.markasdoneBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.markasdoneBTN.Image = ((System.Drawing.Image)(resources.GetObject("markasdoneBTN.Image")));
            this.markasdoneBTN.Location = new System.Drawing.Point(168, 9);
            this.markasdoneBTN.Name = "markasdoneBTN";
            this.markasdoneBTN.Size = new System.Drawing.Size(20, 20);
            this.markasdoneBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.markasdoneBTN.TabIndex = 6;
            this.markasdoneBTN.TabStop = false;
            // 
            // donemark
            // 
            this.donemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.donemark.Image = ((System.Drawing.Image)(resources.GetObject("donemark.Image")));
            this.donemark.Location = new System.Drawing.Point(168, 9);
            this.donemark.Name = "donemark";
            this.donemark.Size = new System.Drawing.Size(20, 20);
            this.donemark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.donemark.TabIndex = 7;
            this.donemark.TabStop = false;
            // 
            // todaysScheduleCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.donemark);
            this.Controls.Add(this.markasdoneBTN);
            this.Controls.Add(this.scheduleSubjectName);
            this.Controls.Add(this.scheduleRoom);
            this.Controls.Add(this.scheduleSection);
            this.Controls.Add(this.pictureBox1);
            this.Name = "todaysScheduleCARD";
            this.Size = new System.Drawing.Size(203, 106);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.markasdoneBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donemark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label scheduleSection;
        private System.Windows.Forms.Label scheduleRoom;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox scheduleSubjectName;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
        private System.Windows.Forms.PictureBox markasdoneBTN;
        private System.Windows.Forms.PictureBox donemark;
    }
}
