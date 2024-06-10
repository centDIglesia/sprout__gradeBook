namespace sprout__gradeBook
{
    partial class EditCourseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditCourseForm));
            this.CourseCode = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.EditCOurseSaveBTN = new System.Windows.Forms.PictureBox();
            this.SubjectNameLbl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.subjectCourseandSectionlbl = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.subjectScheduleLBL = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.studentCountLBL = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.EditCOurseSaveBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // CourseCode
            // 
            this.CourseCode.Location = new System.Drawing.Point(37, 108);
            this.CourseCode.Name = "CourseCode";
            this.CourseCode.Size = new System.Drawing.Size(486, 83);
            this.CourseCode.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.CourseCode.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.CourseCode.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.CourseCode.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.CourseCode.StateCommon.Content.Font = new System.Drawing.Font("Poppins Medium", 34F, System.Drawing.FontStyle.Bold);
            this.CourseCode.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.CourseCode.TabIndex = 5;
            this.CourseCode.Text = "CourseCode";
            // 
            // EditCOurseSaveBTN
            // 
            this.EditCOurseSaveBTN.Image = ((System.Drawing.Image)(resources.GetObject("EditCOurseSaveBTN.Image")));
            this.EditCOurseSaveBTN.Location = new System.Drawing.Point(243, 281);
            this.EditCOurseSaveBTN.Name = "EditCOurseSaveBTN";
            this.EditCOurseSaveBTN.Size = new System.Drawing.Size(205, 67);
            this.EditCOurseSaveBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.EditCOurseSaveBTN.TabIndex = 8;
            this.EditCOurseSaveBTN.TabStop = false;
            this.EditCOurseSaveBTN.Click += new System.EventHandler(this.EditCOurseSaveBTN_Click_1);
            // 
            // SubjectNameLbl
            // 
            this.SubjectNameLbl.Location = new System.Drawing.Point(37, 182);
            this.SubjectNameLbl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.SubjectNameLbl.Multiline = true;
            this.SubjectNameLbl.Name = "SubjectNameLbl";
            this.SubjectNameLbl.Size = new System.Drawing.Size(429, 93);
            this.SubjectNameLbl.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.SubjectNameLbl.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.SubjectNameLbl.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.SubjectNameLbl.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.SubjectNameLbl.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 15.25F);
            this.SubjectNameLbl.TabIndex = 9;
            this.SubjectNameLbl.Text = "coursename coursename coursename";
            // 
            // subjectCourseandSectionlbl
            // 
            this.subjectCourseandSectionlbl.Location = new System.Drawing.Point(37, 38);
            this.subjectCourseandSectionlbl.Multiline = true;
            this.subjectCourseandSectionlbl.Name = "subjectCourseandSectionlbl";
            this.subjectCourseandSectionlbl.ReadOnly = true;
            this.subjectCourseandSectionlbl.Size = new System.Drawing.Size(218, 64);
            this.subjectCourseandSectionlbl.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.subjectCourseandSectionlbl.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.subjectCourseandSectionlbl.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.subjectCourseandSectionlbl.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.subjectCourseandSectionlbl.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 10.25F);
            this.subjectCourseandSectionlbl.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.subjectCourseandSectionlbl.TabIndex = 10;
            this.subjectCourseandSectionlbl.Text = "course - section";
            // 
            // subjectScheduleLBL
            // 
            this.subjectScheduleLBL.Location = new System.Drawing.Point(277, 41);
            this.subjectScheduleLBL.Name = "subjectScheduleLBL";
            this.subjectScheduleLBL.ReadOnly = true;
            this.subjectScheduleLBL.Size = new System.Drawing.Size(146, 27);
            this.subjectScheduleLBL.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.subjectScheduleLBL.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.subjectScheduleLBL.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.subjectScheduleLBL.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.subjectScheduleLBL.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 10.25F);
            this.subjectScheduleLBL.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.subjectScheduleLBL.TabIndex = 11;
            this.subjectScheduleLBL.Text = "12:00 PM - 12:00 PM";
            // 
            // studentCountLBL
            // 
            this.studentCountLBL.Location = new System.Drawing.Point(78, 281);
            this.studentCountLBL.Name = "studentCountLBL";
            this.studentCountLBL.ReadOnly = true;
            this.studentCountLBL.Size = new System.Drawing.Size(68, 42);
            this.studentCountLBL.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.studentCountLBL.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.studentCountLBL.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.studentCountLBL.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.studentCountLBL.StateCommon.Content.Font = new System.Drawing.Font("Poppins Medium", 17F, System.Drawing.FontStyle.Bold);
            this.studentCountLBL.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.studentCountLBL.TabIndex = 12;
            this.studentCountLBL.Text = "24";
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(261, 23);
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.ReadOnly = true;
            this.kryptonTextBox1.Size = new System.Drawing.Size(10, 58);
            this.kryptonTextBox1.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.Gray;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Poppins ExtraLight", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.kryptonTextBox1.TabIndex = 13;
            this.kryptonTextBox1.Text = "|";
            this.kryptonTextBox1.TextChanged += new System.EventHandler(this.kryptonTextBox1_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 281);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // EditCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(478, 372);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.studentCountLBL);
            this.Controls.Add(this.subjectScheduleLBL);
            this.Controls.Add(this.subjectCourseandSectionlbl);
            this.Controls.Add(this.SubjectNameLbl);
            this.Controls.Add(this.EditCOurseSaveBTN);
            this.Controls.Add(this.CourseCode);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditCourseForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EditCourseForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.EditCOurseSaveBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox CourseCode;
        private System.Windows.Forms.PictureBox EditCOurseSaveBTN;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox SubjectNameLbl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox subjectCourseandSectionlbl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox subjectScheduleLBL;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox studentCountLBL;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}