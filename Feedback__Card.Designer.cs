namespace sprout__gradeBook
{
    partial class Feedback__Card
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Feedback__Card));
            this.feedback_Title = new System.Windows.Forms.Label();
            this.teacher__Name = new System.Windows.Forms.Label();
            this.feedback_Description = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // feedback_Title
            // 
            this.feedback_Title.AutoEllipsis = true;
            this.feedback_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.feedback_Title.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedback_Title.ForeColor = System.Drawing.Color.White;
            this.feedback_Title.Location = new System.Drawing.Point(10, 6);
            this.feedback_Title.Name = "feedback_Title";
            this.feedback_Title.Size = new System.Drawing.Size(157, 23);
            this.feedback_Title.TabIndex = 1;
            this.feedback_Title.Text = "titleName";
            // 
            // teacher__Name
            // 
            this.teacher__Name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.teacher__Name.Font = new System.Drawing.Font("Poppins", 8F);
            this.teacher__Name.ForeColor = System.Drawing.Color.Silver;
            this.teacher__Name.Location = new System.Drawing.Point(173, 6);
            this.teacher__Name.Name = "teacher__Name";
            this.teacher__Name.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.teacher__Name.Size = new System.Drawing.Size(126, 23);
            this.teacher__Name.TabIndex = 2;
            this.teacher__Name.Text = "teacherName";
            this.teacher__Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // feedback_Description
            // 
            this.feedback_Description.Enabled = false;
            this.feedback_Description.Location = new System.Drawing.Point(11, 33);
            this.feedback_Description.Multiline = true;
            this.feedback_Description.Name = "feedback_Description";
            this.feedback_Description.ReadOnly = true;
            this.feedback_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.feedback_Description.Size = new System.Drawing.Size(280, 80);
            this.feedback_Description.TabIndex = 3;
            // 
            // Feedback__Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Controls.Add(this.feedback_Description);
            this.Controls.Add(this.teacher__Name);
            this.Controls.Add(this.feedback_Title);
            this.DoubleBuffered = true;
            this.Name = "Feedback__Card";
            this.Size = new System.Drawing.Size(304, 126);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label feedback_Title;
        private System.Windows.Forms.Label teacher__Name;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox feedback_Description;
    }
}
