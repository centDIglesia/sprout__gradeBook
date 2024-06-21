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
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonContextMenu1 = new ComponentFactory.Krypton.Toolkit.KryptonContextMenu();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scheduleSection
            // 
            this.scheduleSection.AutoSize = true;
            this.scheduleSection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.scheduleSection.Font = new System.Drawing.Font("Poppins", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleSection.ForeColor = System.Drawing.Color.White;
            this.scheduleSection.Location = new System.Drawing.Point(13, 54);
            this.scheduleSection.Name = "scheduleSection";
            this.scheduleSection.Size = new System.Drawing.Size(32, 16);
            this.scheduleSection.TabIndex = 2;
            this.scheduleSection.Text = "label1";
            // 
            // scheduleRoom
            // 
            this.scheduleRoom.AutoSize = true;
            this.scheduleRoom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.scheduleRoom.Font = new System.Drawing.Font("Poppins", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleRoom.ForeColor = System.Drawing.Color.White;
            this.scheduleRoom.Location = new System.Drawing.Point(156, 79);
            this.scheduleRoom.Name = "scheduleRoom";
            this.scheduleRoom.Size = new System.Drawing.Size(34, 16);
            this.scheduleRoom.TabIndex = 3;
            this.scheduleRoom.Text = "label2";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(8, 7);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(182, 44);
            this.kryptonTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 0;
            this.kryptonTextBox1.StateCommon.Border.Width = 0;
            this.kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Poppins Medium", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.TabIndex = 4;
            this.kryptonTextBox1.Text = "scheduelSubject";
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
            // 
            // todaysScheduleCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.scheduleRoom);
            this.Controls.Add(this.scheduleSection);
            this.Controls.Add(this.pictureBox1);
            this.Name = "todaysScheduleCARD";
            this.Size = new System.Drawing.Size(203, 106);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label scheduleSection;
        private System.Windows.Forms.Label scheduleRoom;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonContextMenu kryptonContextMenu1;
    }
}
