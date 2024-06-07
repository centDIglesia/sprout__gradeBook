namespace sprout__gradeBook
{
    partial class studentSectionLIST
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
            this.studentCourseSectionFlow = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.studentCourseSectionFlow.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentCourseSectionFlow
            // 
            this.studentCourseSectionFlow.Controls.Add(this.label1);
            this.studentCourseSectionFlow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentCourseSectionFlow.Location = new System.Drawing.Point(0, 0);
            this.studentCourseSectionFlow.Name = "studentCourseSectionFlow";
            this.studentCourseSectionFlow.Size = new System.Drawing.Size(739, 514);
            this.studentCourseSectionFlow.TabIndex = 0;
            this.studentCourseSectionFlow.Paint += new System.Windows.Forms.PaintEventHandler(this.studentCourseSectionFlow_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "flow1";
            // 
            // studentSectionLIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 514);
            this.Controls.Add(this.studentCourseSectionFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "studentSectionLIST";
            this.Text = "studentSectionLIST";
            this.Load += new System.EventHandler(this.studentSectionLIST_Load);
            this.studentCourseSectionFlow.ResumeLayout(false);
            this.studentCourseSectionFlow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel studentCourseSectionFlow;
        private System.Windows.Forms.Label label1;
    }
}