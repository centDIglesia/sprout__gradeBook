namespace sprout__gradeBook
{
    partial class StudentScheduleCard
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
            this.subjectScheduleLBL = new System.Windows.Forms.Label();
            this.subjectNameLBL = new System.Windows.Forms.Label();
            this.teacherNameLBL = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.subjectCodeLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectScheduleLBL
            // 
            this.subjectScheduleLBL.AutoSize = true;
            this.subjectScheduleLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.subjectScheduleLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectScheduleLBL.ForeColor = System.Drawing.SystemColors.InfoText;
            this.subjectScheduleLBL.Location = new System.Drawing.Point(16, 50);
            this.subjectScheduleLBL.Name = "subjectScheduleLBL";
            this.subjectScheduleLBL.Size = new System.Drawing.Size(106, 19);
            this.subjectScheduleLBL.TabIndex = 12;
            this.subjectScheduleLBL.Text = "12:00 PM-03:00 PM";
            // 
            // subjectNameLBL
            // 
            this.subjectNameLBL.AutoSize = true;
            this.subjectNameLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.subjectNameLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectNameLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.subjectNameLBL.Location = new System.Drawing.Point(16, 31);
            this.subjectNameLBL.Name = "subjectNameLBL";
            this.subjectNameLBL.Size = new System.Drawing.Size(174, 19);
            this.subjectNameLBL.TabIndex = 9;
            this.subjectNameLBL.Text = "Object Oriented Programming";
            // 
            // teacherNameLBL
            // 
            this.teacherNameLBL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.teacherNameLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.teacherNameLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.teacherNameLBL.ForeColor = System.Drawing.Color.Gray;
            this.teacherNameLBL.Location = new System.Drawing.Point(102, 94);
            this.teacherNameLBL.Name = "teacherNameLBL";
            this.teacherNameLBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.teacherNameLBL.Size = new System.Drawing.Size(194, 19);
            this.teacherNameLBL.TabIndex = 14;
            this.teacherNameLBL.Text = "Teacher__Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::sprout__gradeBook.Properties.Resources.Student_CourseCard;
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // subjectCodeLBL
            // 
            this.subjectCodeLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.subjectCodeLBL.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold);
            this.subjectCodeLBL.ForeColor = System.Drawing.Color.White;
            this.subjectCodeLBL.Location = new System.Drawing.Point(15, 4);
            this.subjectCodeLBL.Name = "subjectCodeLBL";
            this.subjectCodeLBL.Size = new System.Drawing.Size(276, 19);
            this.subjectCodeLBL.TabIndex = 16;
            this.subjectCodeLBL.Text = "CODE";
            // 
            // StudentScheduleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.subjectCodeLBL);
            this.Controls.Add(this.teacherNameLBL);
            this.Controls.Add(this.subjectScheduleLBL);
            this.Controls.Add(this.subjectNameLBL);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "StudentScheduleCard";
            this.Size = new System.Drawing.Size(313, 119);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label teacherNameLBL;
        public System.Windows.Forms.Label subjectScheduleLBL;
        public System.Windows.Forms.Label subjectNameLBL;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label subjectCodeLBL;
    }
}
