namespace sprout__gradeBook
{
    partial class TermsCons
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TermsCons));
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.acceptBtn = new System.Windows.Forms.PictureBox();
            this.declineBtn = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.acceptBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.declineBtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Enabled = false;
            this.kryptonTextBox1.Location = new System.Drawing.Point(-1, -1);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.ReadOnly = true;
            this.kryptonTextBox1.Size = new System.Drawing.Size(455, 31);
            this.kryptonTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Width = 0;
            this.kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(5);
            this.kryptonTextBox1.TabIndex = 64;
            this.kryptonTextBox1.Text = "Terms and Conditions";
            // 
            // acceptBtn
            // 
            this.acceptBtn.Image = ((System.Drawing.Image)(resources.GetObject("acceptBtn.Image")));
            this.acceptBtn.Location = new System.Drawing.Point(209, 495);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Padding = new System.Windows.Forms.Padding(2);
            this.acceptBtn.Size = new System.Drawing.Size(126, 34);
            this.acceptBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.acceptBtn.TabIndex = 66;
            this.acceptBtn.TabStop = false;
            this.acceptBtn.Click += new System.EventHandler(this.acceptBtn_Click);
            // 
            // declineBtn
            // 
            this.declineBtn.Image = ((System.Drawing.Image)(resources.GetObject("declineBtn.Image")));
            this.declineBtn.Location = new System.Drawing.Point(51, 495);
            this.declineBtn.Name = "declineBtn";
            this.declineBtn.Padding = new System.Windows.Forms.Padding(2);
            this.declineBtn.Size = new System.Drawing.Size(126, 34);
            this.declineBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.declineBtn.TabIndex = 67;
            this.declineBtn.TabStop = false;
            this.declineBtn.Click += new System.EventHandler(this.declineBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(31, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 432);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // TermsCons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(394, 554);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.declineBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.kryptonTextBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TermsCons";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TermsCons";
            this.Load += new System.EventHandler(this.TermsCons_Load);
            ((System.ComponentModel.ISupportInitialize)(this.acceptBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.declineBtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.PictureBox acceptBtn;
        private System.Windows.Forms.PictureBox declineBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}