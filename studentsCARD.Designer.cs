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
            this.studentGender = new System.Windows.Forms.PictureBox();
            this.studentcard__studentID = new System.Windows.Forms.Label();
            this.studentcard__studentName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentGender)).BeginInit();
            this.SuspendLayout();
            // 
            // studentGender
            // 
            this.studentGender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.studentGender.Image = global::sprout__gradeBook.Properties.Resources.femaleee;
            this.studentGender.Location = new System.Drawing.Point(21, 26);
            this.studentGender.Name = "studentGender";
            this.studentGender.Size = new System.Drawing.Size(75, 75);
            this.studentGender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.studentGender.TabIndex = 0;
            this.studentGender.TabStop = false;
            this.studentGender.Click += new System.EventHandler(this.studentcard__studentName_Click);
            // 
            // studentcard__studentID
            // 
            this.studentcard__studentID.AutoSize = true;
            this.studentcard__studentID.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentcard__studentID.ForeColor = System.Drawing.Color.DarkGray;
            this.studentcard__studentID.Location = new System.Drawing.Point(129, 26);
            this.studentcard__studentID.Name = "studentcard__studentID";
            this.studentcard__studentID.Size = new System.Drawing.Size(77, 23);
            this.studentcard__studentID.TabIndex = 1;
            this.studentcard__studentID.Text = "Student ID";
            this.studentcard__studentID.Click += new System.EventHandler(this.studentcard__studentName_Click);
            // 
            // studentcard__studentName
            // 
            this.studentcard__studentName.Enabled = false;
            this.studentcard__studentName.Location = new System.Drawing.Point(133, 49);
            this.studentcard__studentName.Multiline = true;
            this.studentcard__studentName.Name = "studentcard__studentName";
            this.studentcard__studentName.ReadOnly = true;
            this.studentcard__studentName.Size = new System.Drawing.Size(141, 44);
            this.studentcard__studentName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.studentcard__studentName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.studentcard__studentName.StateCommon.Border.Rounding = 0;
            this.studentcard__studentName.StateCommon.Border.Width = 0;
            this.studentcard__studentName.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.studentcard__studentName.StateCommon.Content.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold);
            this.studentcard__studentName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(-5, -5, 0, 0);
            this.studentcard__studentName.TabIndex = 3;
            this.studentcard__studentName.Text = "Student Name dsdsfdsfdd";
            this.studentcard__studentName.TextChanged += new System.EventHandler(this.studentcard__studentName_TextChanged);
            this.studentcard__studentName.Click += new System.EventHandler(this.studentcard__studentName_Click);
            // 
            // studentsCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.studentGender);
            this.Controls.Add(this.studentcard__studentName);
            this.Controls.Add(this.studentcard__studentID);
            this.DoubleBuffered = true;
            this.Name = "studentsCARD";
            this.Size = new System.Drawing.Size(293, 126);
            this.Load += new System.EventHandler(this.studentsCARD_Load);
            this.Click += new System.EventHandler(this.studentcard__studentName_Click);
            ((System.ComponentModel.ISupportInitialize)(this.studentGender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox studentGender;
        private System.Windows.Forms.Label studentcard__studentID;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox studentcard__studentName;
    }
}
