namespace sprout__gradeBook.Student_Forms
{
    partial class Student__GradeRow
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
            this.studentCodelbl = new System.Windows.Forms.Label();
            this.courseDescriptionlbl = new System.Windows.Forms.Label();
            this.facultyNamelbl = new System.Windows.Forms.Label();
            this.finalGradelbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // studentCodelbl
            // 
            this.studentCodelbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.studentCodelbl.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentCodelbl.ForeColor = System.Drawing.Color.DarkGray;
            this.studentCodelbl.Location = new System.Drawing.Point(12, 7);
            this.studentCodelbl.Name = "studentCodelbl";
            this.studentCodelbl.Size = new System.Drawing.Size(127, 65);
            this.studentCodelbl.TabIndex = 1;
            this.studentCodelbl.Text = "label1";
            this.studentCodelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseDescriptionlbl
            // 
            this.courseDescriptionlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.courseDescriptionlbl.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold);
            this.courseDescriptionlbl.ForeColor = System.Drawing.Color.DarkGray;
            this.courseDescriptionlbl.Location = new System.Drawing.Point(149, 6);
            this.courseDescriptionlbl.Name = "courseDescriptionlbl";
            this.courseDescriptionlbl.Size = new System.Drawing.Size(164, 65);
            this.courseDescriptionlbl.TabIndex = 2;
            this.courseDescriptionlbl.Text = "label1";
            this.courseDescriptionlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // facultyNamelbl
            // 
            this.facultyNamelbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.facultyNamelbl.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold);
            this.facultyNamelbl.ForeColor = System.Drawing.Color.DarkGray;
            this.facultyNamelbl.Location = new System.Drawing.Point(327, 7);
            this.facultyNamelbl.Name = "facultyNamelbl";
            this.facultyNamelbl.Size = new System.Drawing.Size(140, 65);
            this.facultyNamelbl.TabIndex = 3;
            this.facultyNamelbl.Text = "label1";
            this.facultyNamelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finalGradelbl
            // 
            this.finalGradelbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.finalGradelbl.Font = new System.Drawing.Font("Poppins Medium", 10.2F, System.Drawing.FontStyle.Bold);
            this.finalGradelbl.ForeColor = System.Drawing.Color.Black;
            this.finalGradelbl.Location = new System.Drawing.Point(483, 7);
            this.finalGradelbl.Name = "finalGradelbl";
            this.finalGradelbl.Size = new System.Drawing.Size(147, 65);
            this.finalGradelbl.TabIndex = 4;
            this.finalGradelbl.Text = "label1";
            this.finalGradelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::sprout__gradeBook.Properties.Resources.Group_69;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Size = new System.Drawing.Size(713, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Student__GradeRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.finalGradelbl);
            this.Controls.Add(this.facultyNamelbl);
            this.Controls.Add(this.courseDescriptionlbl);
            this.Controls.Add(this.studentCodelbl);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Student__GradeRow";
            this.Size = new System.Drawing.Size(713, 83);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label studentCodelbl;
        private System.Windows.Forms.Label courseDescriptionlbl;
        private System.Windows.Forms.Label facultyNamelbl;
        private System.Windows.Forms.Label finalGradelbl;
    }
}
