namespace sprout__gradeBook
{
    partial class CoursesCARD
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
            this.subjectNameLBL = new System.Windows.Forms.Label();
            this.subjectCodeLBL = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.subjectScheduleLBL = new System.Windows.Forms.Label();
            this.subjectStudentCountLBL = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.studentCountTooltip = new System.Windows.Forms.Label();
            this.subjectCourseSectionLBL = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.SuspendLayout();
            // 
            // subjectNameLBL
            // 
            this.subjectNameLBL.AutoSize = true;
            this.subjectNameLBL.BackColor = System.Drawing.Color.White;
            this.subjectNameLBL.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectNameLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.subjectNameLBL.Location = new System.Drawing.Point(16, 45);
            this.subjectNameLBL.Name = "subjectNameLBL";
            this.subjectNameLBL.Size = new System.Drawing.Size(218, 22);
            this.subjectNameLBL.TabIndex = 1;
            this.subjectNameLBL.Text = "Object Oriented Programming";
            this.subjectNameLBL.MouseLeave += new System.EventHandler(this.subjectNameLBL_MouseLeave);
            this.subjectNameLBL.MouseHover += new System.EventHandler(this.subjectCourseSectionLBL_MouseHover);
            // 
            // subjectCodeLBL
            // 
            this.subjectCodeLBL.Location = new System.Drawing.Point(13, 10);
            this.subjectCodeLBL.Name = "subjectCodeLBL";
            this.subjectCodeLBL.Size = new System.Drawing.Size(48, 22);
            this.subjectCodeLBL.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.subjectCodeLBL.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.subjectCodeLBL.StateCommon.ShortText.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectCodeLBL.TabIndex = 4;
            this.subjectCodeLBL.Values.Text = "CODE";
            this.subjectCodeLBL.MouseLeave += new System.EventHandler(this.subjectNameLBL_MouseLeave);
            this.subjectCodeLBL.MouseHover += new System.EventHandler(this.subjectCourseSectionLBL_MouseHover);
            // 
            // subjectScheduleLBL
            // 
            this.subjectScheduleLBL.AutoSize = true;
            this.subjectScheduleLBL.BackColor = System.Drawing.Color.White;
            this.subjectScheduleLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectScheduleLBL.ForeColor = System.Drawing.Color.Gray;
            this.subjectScheduleLBL.Location = new System.Drawing.Point(103, 141);
            this.subjectScheduleLBL.Name = "subjectScheduleLBL";
            this.subjectScheduleLBL.Size = new System.Drawing.Size(106, 19);
            this.subjectScheduleLBL.TabIndex = 5;
            this.subjectScheduleLBL.Text = "12:00 PM-03:00 PM";
            this.subjectScheduleLBL.MouseLeave += new System.EventHandler(this.subjectNameLBL_MouseLeave);
            this.subjectScheduleLBL.MouseHover += new System.EventHandler(this.subjectCourseSectionLBL_MouseHover);
            // 
            // subjectStudentCountLBL
            // 
            this.subjectStudentCountLBL.Location = new System.Drawing.Point(195, 12);
            this.subjectStudentCountLBL.Name = "subjectStudentCountLBL";
            this.subjectStudentCountLBL.Size = new System.Drawing.Size(24, 19);
            this.subjectStudentCountLBL.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.subjectStudentCountLBL.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.subjectStudentCountLBL.StateCommon.ShortText.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectStudentCountLBL.TabIndex = 7;
            this.subjectStudentCountLBL.Values.Text = "00";
            this.subjectStudentCountLBL.MouseLeave += new System.EventHandler(this.subjectStudentCountLBL_MouseLeave);
            this.subjectStudentCountLBL.MouseHover += new System.EventHandler(this.subjectStudentCountLBL_MouseHover);
            // 
            // studentCountTooltip
            // 
            this.studentCountTooltip.AutoSize = true;
            this.studentCountTooltip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.studentCountTooltip.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentCountTooltip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.studentCountTooltip.Location = new System.Drawing.Point(171, 29);
            this.studentCountTooltip.Name = "studentCountTooltip";
            this.studentCountTooltip.Padding = new System.Windows.Forms.Padding(2);
            this.studentCountTooltip.Size = new System.Drawing.Size(61, 23);
            this.studentCountTooltip.TabIndex = 8;
            this.studentCountTooltip.Text = "Students";
            // 
            // subjectCourseSectionLBL
            // 
            this.subjectCourseSectionLBL.Enabled = false;
            this.subjectCourseSectionLBL.Location = new System.Drawing.Point(15, 66);
            this.subjectCourseSectionLBL.Multiline = true;
            this.subjectCourseSectionLBL.Name = "subjectCourseSectionLBL";
            this.subjectCourseSectionLBL.ReadOnly = true;
            this.subjectCourseSectionLBL.Size = new System.Drawing.Size(209, 74);
            this.subjectCourseSectionLBL.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.subjectCourseSectionLBL.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left)
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.subjectCourseSectionLBL.StateCommon.Border.Width = 0;
            this.subjectCourseSectionLBL.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.subjectCourseSectionLBL.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectCourseSectionLBL.TabIndex = 9;
            this.subjectCourseSectionLBL.Text = "kryptonTextBox1";
            this.subjectCourseSectionLBL.TextChanged += new System.EventHandler(this.subjectCourseSectionLBL_TextChanged);
            this.subjectCourseSectionLBL.MouseLeave += new System.EventHandler(this.subjectNameLBL_MouseLeave);
            this.subjectCourseSectionLBL.MouseHover += new System.EventHandler(this.subjectCourseSectionLBL_MouseHover);
            // 
            // CoursesCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::sprout__gradeBook.Properties.Resources.Group_66d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.subjectCourseSectionLBL);
            this.Controls.Add(this.studentCountTooltip);
            this.Controls.Add(this.subjectStudentCountLBL);
            this.Controls.Add(this.subjectScheduleLBL);
            this.Controls.Add(this.subjectCodeLBL);
            this.Controls.Add(this.subjectNameLBL);
            this.DoubleBuffered = true;
            this.Name = "CoursesCARD";
            this.Size = new System.Drawing.Size(235, 172);
            this.Load += new System.EventHandler(this.CoursesCARD_Load_1);
            this.MouseLeave += new System.EventHandler(this.subjectNameLBL_MouseLeave);
            this.MouseHover += new System.EventHandler(this.subjectCourseSectionLBL_MouseHover);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label subjectNameLBL;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel subjectCodeLBL;
        private System.Windows.Forms.Label subjectScheduleLBL;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel subjectStudentCountLBL;
        private System.Windows.Forms.Label studentCountTooltip;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox subjectCourseSectionLBL;
    }
}
