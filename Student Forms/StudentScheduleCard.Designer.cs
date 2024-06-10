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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.subjectScheduleLBL = new System.Windows.Forms.Label();
            this.subjectCodeLBL = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.subjectNameLBL = new System.Windows.Forms.Label();
            this.teacherNameLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.pictureBox1.Location = new System.Drawing.Point(186, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 18);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // subjectScheduleLBL
            // 
            this.subjectScheduleLBL.AutoSize = true;
            this.subjectScheduleLBL.BackColor = System.Drawing.Color.White;
            this.subjectScheduleLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectScheduleLBL.ForeColor = System.Drawing.Color.Black;
            this.subjectScheduleLBL.Location = new System.Drawing.Point(37, 62);
            this.subjectScheduleLBL.Name = "subjectScheduleLBL";
            this.subjectScheduleLBL.Size = new System.Drawing.Size(106, 19);
            this.subjectScheduleLBL.TabIndex = 12;
            this.subjectScheduleLBL.Text = "12:00 PM-03:00 PM";
            // 
            // subjectCodeLBL
            // 
            this.subjectCodeLBL.Location = new System.Drawing.Point(35, 10);
            this.subjectCodeLBL.Name = "subjectCodeLBL";
            this.subjectCodeLBL.Size = new System.Drawing.Size(48, 22);
            this.subjectCodeLBL.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.subjectCodeLBL.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.subjectCodeLBL.StateCommon.ShortText.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectCodeLBL.TabIndex = 11;
            this.subjectCodeLBL.Values.Text = "CODE";
            // 
            // subjectNameLBL
            // 
            this.subjectNameLBL.AutoSize = true;
            this.subjectNameLBL.BackColor = System.Drawing.Color.White;
            this.subjectNameLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectNameLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.subjectNameLBL.Location = new System.Drawing.Point(37, 43);
            this.subjectNameLBL.Name = "subjectNameLBL";
            this.subjectNameLBL.Size = new System.Drawing.Size(174, 19);
            this.subjectNameLBL.TabIndex = 9;
            this.subjectNameLBL.Text = "Object Oriented Programming";
            // 
            // teacherNameLBL
            // 
            this.teacherNameLBL.AutoSize = true;
            this.teacherNameLBL.BackColor = System.Drawing.Color.White;
            this.teacherNameLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.teacherNameLBL.ForeColor = System.Drawing.Color.Gray;
            this.teacherNameLBL.Location = new System.Drawing.Point(109, 91);
            this.teacherNameLBL.Name = "teacherNameLBL";
            this.teacherNameLBL.Size = new System.Drawing.Size(103, 19);
            this.teacherNameLBL.TabIndex = 14;
            this.teacherNameLBL.Text = "Teacher__Name";
            // 
            // StudentScheduleCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::sprout__gradeBook.Properties.Resources.sub;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.teacherNameLBL);
            this.Controls.Add(this.subjectScheduleLBL);
            this.Controls.Add(this.subjectCodeLBL);
            this.Controls.Add(this.subjectNameLBL);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "StudentScheduleCard";
            this.Size = new System.Drawing.Size(269, 125);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label teacherNameLBL;
        public System.Windows.Forms.Label subjectScheduleLBL;
        public ComponentFactory.Krypton.Toolkit.KryptonLabel subjectCodeLBL;
        public System.Windows.Forms.Label subjectNameLBL;
    }
}
