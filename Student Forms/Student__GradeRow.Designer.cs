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
            this.gradeRemarkslbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // studentCodelbl
            // 
            this.studentCodelbl.BackColor = System.Drawing.Color.White;
            this.studentCodelbl.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.studentCodelbl.ForeColor = System.Drawing.Color.DimGray;
            this.studentCodelbl.Location = new System.Drawing.Point(13, 14);
            this.studentCodelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.studentCodelbl.Name = "studentCodelbl";
            this.studentCodelbl.Size = new System.Drawing.Size(120, 53);
            this.studentCodelbl.TabIndex = 1;
            this.studentCodelbl.Text = "label1";
            this.studentCodelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // courseDescriptionlbl
            // 
            this.courseDescriptionlbl.BackColor = System.Drawing.Color.White;
            this.courseDescriptionlbl.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.courseDescriptionlbl.ForeColor = System.Drawing.Color.DimGray;
            this.courseDescriptionlbl.Location = new System.Drawing.Point(142, 14);
            this.courseDescriptionlbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.courseDescriptionlbl.Name = "courseDescriptionlbl";
            this.courseDescriptionlbl.Size = new System.Drawing.Size(200, 53);
            this.courseDescriptionlbl.TabIndex = 2;
            this.courseDescriptionlbl.Text = "label1";
            this.courseDescriptionlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // facultyNamelbl
            // 
            this.facultyNamelbl.BackColor = System.Drawing.Color.White;
            this.facultyNamelbl.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold);
            this.facultyNamelbl.ForeColor = System.Drawing.Color.DimGray;
            this.facultyNamelbl.Location = new System.Drawing.Point(352, 14);
            this.facultyNamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.facultyNamelbl.Name = "facultyNamelbl";
            this.facultyNamelbl.Size = new System.Drawing.Size(151, 53);
            this.facultyNamelbl.TabIndex = 3;
            this.facultyNamelbl.Text = "label1";
            this.facultyNamelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // finalGradelbl
            // 
            this.finalGradelbl.BackColor = System.Drawing.Color.White;
            this.finalGradelbl.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold);
            this.finalGradelbl.ForeColor = System.Drawing.Color.Black;
            this.finalGradelbl.Location = new System.Drawing.Point(512, 14);
            this.finalGradelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.finalGradelbl.Name = "finalGradelbl";
            this.finalGradelbl.Size = new System.Drawing.Size(110, 53);
            this.finalGradelbl.TabIndex = 4;
            this.finalGradelbl.Text = "label1";
            this.finalGradelbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gradeRemarkslbl
            // 
            this.gradeRemarkslbl.BackColor = System.Drawing.Color.White;
            this.gradeRemarkslbl.Font = new System.Drawing.Font("Poppins Medium", 7F, System.Drawing.FontStyle.Bold);
            this.gradeRemarkslbl.ForeColor = System.Drawing.Color.Gray;
            this.gradeRemarkslbl.Location = new System.Drawing.Point(634, 14);
            this.gradeRemarkslbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gradeRemarkslbl.Name = "gradeRemarkslbl";
            this.gradeRemarkslbl.Size = new System.Drawing.Size(72, 53);
            this.gradeRemarkslbl.TabIndex = 6;
            this.gradeRemarkslbl.Text = "label1";
            this.gradeRemarkslbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::sprout__gradeBook.Properties.Resources.Student__GradesRow;
            this.pictureBox1.Location = new System.Drawing.Point(8, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Size = new System.Drawing.Size(705, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Student__GradeRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gradeRemarkslbl);
            this.Controls.Add(this.finalGradelbl);
            this.Controls.Add(this.facultyNamelbl);
            this.Controls.Add(this.courseDescriptionlbl);
            this.Controls.Add(this.studentCodelbl);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Student__GradeRow";
            this.Size = new System.Drawing.Size(718, 83);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label studentCodelbl;
        public System.Windows.Forms.Label courseDescriptionlbl;
        public System.Windows.Forms.Label facultyNamelbl;
        public System.Windows.Forms.Label finalGradelbl;
        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label gradeRemarkslbl;
    }
}
