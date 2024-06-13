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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoursesCARD));
            this.subjectNameLBL = new System.Windows.Forms.Label();
            this.subjectCodeLBL = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.subjectScheduleLBL = new System.Windows.Forms.Label();
            this.subjectStudentCountLBL = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.studentCountTooltip = new System.Windows.Forms.Label();
            this.subjectCourseSectionLBL = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aanounceBTN = new System.Windows.Forms.PictureBox();
            this.announcementBTN = new System.Windows.Forms.PictureBox();
            this.COSEbtn = new System.Windows.Forms.PictureBox();
            this.removeBTN = new System.Windows.Forms.PictureBox();
            this.addSubComponentBTN = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aanounceBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.announcementBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.COSEbtn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addSubComponentBTN)).BeginInit();
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
            this.subjectNameLBL.Size = new System.Drawing.Size(270, 26);
            this.subjectNameLBL.TabIndex = 1;
            this.subjectNameLBL.Text = "Object Oriented Programming";
            this.subjectNameLBL.Click += new System.EventHandler(this.subjectCourseSectionLBL_Click);
            // 
            // subjectCodeLBL
            // 
            this.subjectCodeLBL.Location = new System.Drawing.Point(13, 10);
            this.subjectCodeLBL.Name = "subjectCodeLBL";
            this.subjectCodeLBL.Size = new System.Drawing.Size(59, 27);
            this.subjectCodeLBL.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.subjectCodeLBL.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.subjectCodeLBL.StateCommon.ShortText.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectCodeLBL.TabIndex = 4;
            this.subjectCodeLBL.Values.Text = "CODE";
            this.subjectCodeLBL.Click += new System.EventHandler(this.subjectCourseSectionLBL_Click);
            // 
            // subjectScheduleLBL
            // 
            this.subjectScheduleLBL.AutoSize = true;
            this.subjectScheduleLBL.BackColor = System.Drawing.Color.White;
            this.subjectScheduleLBL.Font = new System.Drawing.Font("Poppins", 8F);
            this.subjectScheduleLBL.ForeColor = System.Drawing.Color.Gray;
            this.subjectScheduleLBL.Location = new System.Drawing.Point(103, 141);
            this.subjectScheduleLBL.Name = "subjectScheduleLBL";
            this.subjectScheduleLBL.Size = new System.Drawing.Size(139, 25);
            this.subjectScheduleLBL.TabIndex = 5;
            this.subjectScheduleLBL.Text = "12:00 PM-03:00 PM";
            this.subjectScheduleLBL.Click += new System.EventHandler(this.subjectCourseSectionLBL_Click);
            // 
            // subjectStudentCountLBL
            // 
            this.subjectStudentCountLBL.Location = new System.Drawing.Point(195, 12);
            this.subjectStudentCountLBL.Name = "subjectStudentCountLBL";
            this.subjectStudentCountLBL.Size = new System.Drawing.Size(28, 23);
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
            this.studentCountTooltip.Size = new System.Drawing.Size(77, 29);
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
            this.subjectCourseSectionLBL.Click += new System.EventHandler(this.subjectCourseSectionLBL_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 172);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // aanounceBTN
            // 
            this.aanounceBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.aanounceBTN.Image = ((System.Drawing.Image)(resources.GetObject("aanounceBTN.Image")));
            this.aanounceBTN.Location = new System.Drawing.Point(215, 189);
            this.aanounceBTN.Name = "aanounceBTN";
            this.aanounceBTN.Size = new System.Drawing.Size(158, 54);
            this.aanounceBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.aanounceBTN.TabIndex = 12;
            this.aanounceBTN.TabStop = false;
            // 
            // announcementBTN
            // 
            this.announcementBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.announcementBTN.Image = ((System.Drawing.Image)(resources.GetObject("announcementBTN.Image")));
            this.announcementBTN.Location = new System.Drawing.Point(53, 70);
            this.announcementBTN.Name = "announcementBTN";
            this.announcementBTN.Size = new System.Drawing.Size(137, 43);
            this.announcementBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.announcementBTN.TabIndex = 15;
            this.announcementBTN.TabStop = false;
            this.announcementBTN.Click += new System.EventHandler(this.announcementBTN_Click);
            // 
            // COSEbtn
            // 
            this.COSEbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.COSEbtn.Image = ((System.Drawing.Image)(resources.GetObject("COSEbtn.Image")));
            this.COSEbtn.Location = new System.Drawing.Point(199, 12);
            this.COSEbtn.Name = "COSEbtn";
            this.COSEbtn.Size = new System.Drawing.Size(24, 21);
            this.COSEbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.COSEbtn.TabIndex = 16;
            this.COSEbtn.TabStop = false;
            this.COSEbtn.Click += new System.EventHandler(this.COSEbtn_Click);
            // 
            // removeBTN
            // 
            this.removeBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.removeBTN.Image = ((System.Drawing.Image)(resources.GetObject("removeBTN.Image")));
            this.removeBTN.Location = new System.Drawing.Point(68, 119);
            this.removeBTN.Name = "removeBTN";
            this.removeBTN.Size = new System.Drawing.Size(106, 43);
            this.removeBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.removeBTN.TabIndex = 17;
            this.removeBTN.TabStop = false;
            this.removeBTN.Click += new System.EventHandler(this.removeBTN_Click);
            // 
            // addSubComponentBTN
            // 
            this.addSubComponentBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.addSubComponentBTN.Image = ((System.Drawing.Image)(resources.GetObject("addSubComponentBTN.Image")));
            this.addSubComponentBTN.Location = new System.Drawing.Point(53, 21);
            this.addSubComponentBTN.Name = "addSubComponentBTN";
            this.addSubComponentBTN.Size = new System.Drawing.Size(137, 43);
            this.addSubComponentBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.addSubComponentBTN.TabIndex = 18;
            this.addSubComponentBTN.TabStop = false;
            this.addSubComponentBTN.Click += new System.EventHandler(this.addSubComponentBTN_Click);
            // 
            // CoursesCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::sprout__gradeBook.Properties.Resources.Group_66d;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.addSubComponentBTN);
            this.Controls.Add(this.removeBTN);
            this.Controls.Add(this.announcementBTN);
            this.Controls.Add(this.COSEbtn);
            this.Controls.Add(this.aanounceBTN);
            this.Controls.Add(this.pictureBox1);
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
            this.Click += new System.EventHandler(this.subjectCourseSectionLBL_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aanounceBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.announcementBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.COSEbtn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addSubComponentBTN)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox aanounceBTN;
        private System.Windows.Forms.PictureBox announcementBTN;
        private System.Windows.Forms.PictureBox COSEbtn;
        private System.Windows.Forms.PictureBox removeBTN;
        private System.Windows.Forms.PictureBox addSubComponentBTN;
    }
}
