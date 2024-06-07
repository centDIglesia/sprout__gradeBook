namespace sprout__gradeBook.Student_Forms
{
    partial class Student__GlobalNavigationBar
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
            this.currentStudentID = new System.Windows.Forms.Label();
            this.student_Name = new System.Windows.Forms.Label();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Student_viewPanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student_viewPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // currentStudentID
            // 
            this.currentStudentID.AutoSize = true;
            this.currentStudentID.BackColor = System.Drawing.Color.White;
            this.currentStudentID.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStudentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.currentStudentID.Location = new System.Drawing.Point(923, 38);
            this.currentStudentID.Name = "currentStudentID";
            this.currentStudentID.Size = new System.Drawing.Size(96, 23);
            this.currentStudentID.TabIndex = 109;
            this.currentStudentID.Text = "Student__ID";
            // 
            // student_Name
            // 
            this.student_Name.AutoSize = true;
            this.student_Name.BackColor = System.Drawing.Color.White;
            this.student_Name.Font = new System.Drawing.Font("Poppins SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.student_Name.Location = new System.Drawing.Point(921, 13);
            this.student_Name.Name = "student_Name";
            this.student_Name.Size = new System.Drawing.Size(213, 34);
            this.student_Name.TabIndex = 108;
            this.student_Name.Text = "Aries John Tolentino";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.Enabled = false;
            this.kryptonButton1.Location = new System.Drawing.Point(12, 7);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(1123, 61);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 10;
            this.kryptonButton1.TabIndex = 110;
            this.kryptonButton1.Values.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::sprout__gradeBook.Properties.Resources.logo_green_wsprout;
            this.pictureBox1.Location = new System.Drawing.Point(18, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 42);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // Student_viewPanel
            // 
            this.Student_viewPanel.Location = new System.Drawing.Point(18, 74);
            this.Student_viewPanel.Name = "Student_viewPanel";
            this.Student_viewPanel.Size = new System.Drawing.Size(362, 625);
            this.Student_viewPanel.StateCommon.Color1 = System.Drawing.Color.White;
            this.Student_viewPanel.StateCommon.Color2 = System.Drawing.Color.White;
            this.Student_viewPanel.TabIndex = 113;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Location = new System.Drawing.Point(400, 74);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(362, 625);
            this.kryptonPanel1.StateCommon.Color1 = System.Drawing.Color.White;
            this.kryptonPanel1.StateCommon.Color2 = System.Drawing.Color.White;
            this.kryptonPanel1.TabIndex = 114;
            // 
            // Student__GlobalNavigationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1147, 711);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.Student_viewPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.currentStudentID);
            this.Controls.Add(this.student_Name);
            this.Controls.Add(this.kryptonButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Student__GlobalNavigationBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student__GlobalNavigationBar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student_viewPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label currentStudentID;
        private System.Windows.Forms.Label student_Name;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel Student_viewPanel;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
    }
}