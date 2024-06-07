namespace sprout__gradeBook
{
    partial class studentsCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentsCARD));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.studentcard__studentID = new System.Windows.Forms.Label();
            this.studentcard__studentName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // studentcard__studentID
            // 
            this.studentcard__studentID.AutoSize = true;
            this.studentcard__studentID.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentcard__studentID.ForeColor = System.Drawing.Color.DarkGray;
            this.studentcard__studentID.Location = new System.Drawing.Point(98, 27);
            this.studentcard__studentID.Name = "studentcard__studentID";
            this.studentcard__studentID.Size = new System.Drawing.Size(77, 23);
            this.studentcard__studentID.TabIndex = 1;
            this.studentcard__studentID.Text = "Student ID";
            this.studentcard__studentID.Click += new System.EventHandler(this.label1_Click);
            // 
            // studentcard__studentName
            // 
            this.studentcard__studentName.Location = new System.Drawing.Point(93, 42);
            this.studentcard__studentName.Multiline = true;
            this.studentcard__studentName.Name = "studentcard__studentName";
            this.studentcard__studentName.ReadOnly = true;
            this.studentcard__studentName.Size = new System.Drawing.Size(185, 57);
            this.studentcard__studentName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.studentcard__studentName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.studentcard__studentName.StateCommon.Border.Rounding = 0;
            this.studentcard__studentName.StateCommon.Border.Width = 0;
            this.studentcard__studentName.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.studentcard__studentName.StateCommon.Content.Font = new System.Drawing.Font("Poppins Medium", 13F, System.Drawing.FontStyle.Bold);
            this.studentcard__studentName.TabIndex = 3;
            this.studentcard__studentName.Text = "Student Name";
            // 
            // studentsCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.studentcard__studentName);
            this.Controls.Add(this.studentcard__studentID);
            this.DoubleBuffered = true;
            this.Name = "studentsCARD";
            this.Size = new System.Drawing.Size(293, 126);
            this.Load += new System.EventHandler(this.studentsCARD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label studentcard__studentID;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox studentcard__studentName;
    }
}
