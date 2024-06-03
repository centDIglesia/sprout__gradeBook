namespace sprout__gradeBook
{
    partial class CourseAndSectionCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourseAndSectionCARD));
            this.CourseOfStudent = new System.Windows.Forms.Label();
            this.CoursecSectionOfStudent = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CourseOfStudent
            // 
            this.CourseOfStudent.AutoSize = true;
            this.CourseOfStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(56)))));
            this.CourseOfStudent.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CourseOfStudent.ForeColor = System.Drawing.Color.White;
            this.CourseOfStudent.Location = new System.Drawing.Point(16, 11);
            this.CourseOfStudent.Name = "CourseOfStudent";
            this.CourseOfStudent.Size = new System.Drawing.Size(41, 23);
            this.CourseOfStudent.TabIndex = 1;
            this.CourseOfStudent.Text = "OOP";
            this.CourseOfStudent.Click += new System.EventHandler(this.CoursecSectionOfStudent_Click);
            this.CourseOfStudent.MouseHover += new System.EventHandler(this.CoursecSectionOfStudent_MouseHover);
            // 
            // CoursecSectionOfStudent
            // 
            this.CoursecSectionOfStudent.AutoSize = true;
            this.CoursecSectionOfStudent.BackColor = System.Drawing.Color.White;
            this.CoursecSectionOfStudent.Font = new System.Drawing.Font("Poppins SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CoursecSectionOfStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(102)))), ((int)(((byte)(56)))));
            this.CoursecSectionOfStudent.Location = new System.Drawing.Point(12, 52);
            this.CoursecSectionOfStudent.Name = "CoursecSectionOfStudent";
            this.CoursecSectionOfStudent.Size = new System.Drawing.Size(61, 48);
            this.CoursecSectionOfStudent.TabIndex = 2;
            this.CoursecSectionOfStudent.Text = "2-1";
            this.CoursecSectionOfStudent.Click += new System.EventHandler(this.CoursecSectionOfStudent_Click);
            this.CoursecSectionOfStudent.MouseHover += new System.EventHandler(this.CoursecSectionOfStudent_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 133);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.CoursecSectionOfStudent_Click);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            this.pictureBox1.MouseHover += new System.EventHandler(this.CoursecSectionOfStudent_MouseHover);
            // 
            // CourseAndSectionCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.CoursecSectionOfStudent);
            this.Controls.Add(this.CourseOfStudent);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CourseAndSectionCARD";
            this.Size = new System.Drawing.Size(235, 133);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label CourseOfStudent;
        private System.Windows.Forms.Label CoursecSectionOfStudent;
    }
}
