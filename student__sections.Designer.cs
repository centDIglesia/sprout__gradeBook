namespace sprout__gradeBook
{
    partial class Student__sections
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
            this.components = new System.ComponentModel.Container();
            this.subjectCodeTXT = new System.Windows.Forms.Label();
            this.studentCountTXT = new System.Windows.Forms.Label();
            this.subjectNameTXT = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.subjectScheduleTXT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // subjectCodeTXT
            // 
            this.subjectCodeTXT.AutoSize = true;
            this.subjectCodeTXT.Font = new System.Drawing.Font("Poppins Medium", 25F, System.Drawing.FontStyle.Bold);
            this.subjectCodeTXT.ForeColor = System.Drawing.Color.White;
            this.subjectCodeTXT.Location = new System.Drawing.Point(12, 9);
            this.subjectCodeTXT.Name = "subjectCodeTXT";
            this.subjectCodeTXT.Size = new System.Drawing.Size(128, 60);
            this.subjectCodeTXT.TabIndex = 0;
            this.subjectCodeTXT.Text = "label1";
            this.subjectCodeTXT.MouseHover += new System.EventHandler(this.subjectCodeTXT_MouseHover);
            // 
            // studentCountTXT
            // 
            this.studentCountTXT.AutoSize = true;
            this.studentCountTXT.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentCountTXT.ForeColor = System.Drawing.Color.Silver;
            this.studentCountTXT.Location = new System.Drawing.Point(181, 74);
            this.studentCountTXT.Name = "studentCountTXT";
            this.studentCountTXT.Size = new System.Drawing.Size(42, 19);
            this.studentCountTXT.TabIndex = 1;
            this.studentCountTXT.Text = "label2";
            this.studentCountTXT.MouseHover += new System.EventHandler(this.subjectCodeTXT_MouseHover);
            // 
            // subjectNameTXT
            // 
            this.subjectNameTXT.AutoSize = true;
            this.subjectNameTXT.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectNameTXT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.subjectNameTXT.Location = new System.Drawing.Point(19, 55);
            this.subjectNameTXT.Name = "subjectNameTXT";
            this.subjectNameTXT.Size = new System.Drawing.Size(40, 19);
            this.subjectNameTXT.TabIndex = 2;
            this.subjectNameTXT.Text = "label1";
            this.subjectNameTXT.MouseHover += new System.EventHandler(this.subjectCodeTXT_MouseHover);
            // 
            // subjectScheduleTXT
            // 
            this.subjectScheduleTXT.AutoSize = true;
            this.subjectScheduleTXT.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectScheduleTXT.ForeColor = System.Drawing.Color.Silver;
            this.subjectScheduleTXT.Location = new System.Drawing.Point(19, 74);
            this.subjectScheduleTXT.Name = "subjectScheduleTXT";
            this.subjectScheduleTXT.Size = new System.Drawing.Size(42, 19);
            this.subjectScheduleTXT.TabIndex = 3;
            this.subjectScheduleTXT.Text = "label2";
            // 
            // student__sections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.Controls.Add(this.subjectScheduleTXT);
            this.Controls.Add(this.subjectNameTXT);
            this.Controls.Add(this.studentCountTXT);
            this.Controls.Add(this.subjectCodeTXT);
            this.Name = "student__sections";
            this.Size = new System.Drawing.Size(235, 97);
            this.Load += new System.EventHandler(this.student__sections_Load);
            this.MouseLeave += new System.EventHandler(this.student__sections_MouseLeave);
            this.MouseHover += new System.EventHandler(this.student__sections_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label subjectCodeTXT;
        private System.Windows.Forms.Label studentCountTXT;
        private System.Windows.Forms.Label subjectNameTXT;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label subjectScheduleTXT;
    }
}
