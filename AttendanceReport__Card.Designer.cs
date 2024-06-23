namespace sprout__gradeBook
{
    partial class AttendanceReport__Card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendanceReport__Card));
            this.CourseCodelbl = new System.Windows.Forms.Label();
            this.Attendedlbl = new System.Windows.Forms.Label();
            this.ClassNumlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CourseCodelbl
            // 
            this.CourseCodelbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.CourseCodelbl.Font = new System.Drawing.Font("Poppins SemiBold", 8.5F, System.Drawing.FontStyle.Bold);
            this.CourseCodelbl.ForeColor = System.Drawing.Color.White;
            this.CourseCodelbl.Location = new System.Drawing.Point(35, 11);
            this.CourseCodelbl.Name = "CourseCodelbl";
            this.CourseCodelbl.Size = new System.Drawing.Size(93, 16);
            this.CourseCodelbl.TabIndex = 0;
            this.CourseCodelbl.Text = "CourseCode";
            this.CourseCodelbl.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Attendedlbl
            // 
            this.Attendedlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.Attendedlbl.Font = new System.Drawing.Font("Poppins SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Attendedlbl.ForeColor = System.Drawing.Color.Black;
            this.Attendedlbl.Location = new System.Drawing.Point(51, 49);
            this.Attendedlbl.Name = "Attendedlbl";
            this.Attendedlbl.Size = new System.Drawing.Size(92, 38);
            this.Attendedlbl.TabIndex = 1;
            this.Attendedlbl.Text = "Attended";
            this.Attendedlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClassNumlbl
            // 
            this.ClassNumlbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.ClassNumlbl.Font = new System.Drawing.Font("Poppins SemiBold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassNumlbl.ForeColor = System.Drawing.Color.Black;
            this.ClassNumlbl.Location = new System.Drawing.Point(183, 49);
            this.ClassNumlbl.Name = "ClassNumlbl";
            this.ClassNumlbl.Size = new System.Drawing.Size(87, 38);
            this.ClassNumlbl.TabIndex = 2;
            this.ClassNumlbl.Text = "Total";
            this.ClassNumlbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AttendanceReport__Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.ClassNumlbl);
            this.Controls.Add(this.Attendedlbl);
            this.Controls.Add(this.CourseCodelbl);
            this.DoubleBuffered = true;
            this.Name = "AttendanceReport__Card";
            this.Size = new System.Drawing.Size(330, 128);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label CourseCodelbl;
        public System.Windows.Forms.Label Attendedlbl;
        public System.Windows.Forms.Label ClassNumlbl;
    }
}
