namespace sprout__gradeBook
{
    partial class studentsCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentsCARD));
            this.studentGender = new System.Windows.Forms.PictureBox();
            this.studentcard__studentID = new System.Windows.Forms.Label();
            this.studentcard__studentName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.clickedBG = new System.Windows.Forms.PictureBox();
            this.feedback_btn = new System.Windows.Forms.PictureBox();
            this.attendanceReport = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.removeStudent_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.studentGender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clickedBG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedback_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeStudent_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // studentGender
            // 
            this.studentGender.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.studentGender.Enabled = false;
            this.studentGender.Image = global::sprout__gradeBook.Properties.Resources.Male_Icon;
            this.studentGender.Location = new System.Drawing.Point(21, 36);
            this.studentGender.Name = "studentGender";
            this.studentGender.Size = new System.Drawing.Size(75, 75);
            this.studentGender.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.studentGender.TabIndex = 0;
            this.studentGender.TabStop = false;
            this.studentGender.Click += new System.EventHandler(this.studentcard__studentName_Click);
            this.studentGender.MouseLeave += new System.EventHandler(this.studentcard__studentID_MouseLeave);
            this.studentGender.MouseHover += new System.EventHandler(this.studentGender_MouseHover);
            // 
            // studentcard__studentID
            // 
            this.studentcard__studentID.AutoSize = true;
            this.studentcard__studentID.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentcard__studentID.ForeColor = System.Drawing.Color.DarkGray;
            this.studentcard__studentID.Location = new System.Drawing.Point(106, 39);
            this.studentcard__studentID.Name = "studentcard__studentID";
            this.studentcard__studentID.Size = new System.Drawing.Size(77, 23);
            this.studentcard__studentID.TabIndex = 1;
            this.studentcard__studentID.Text = "Student ID";
            this.studentcard__studentID.Click += new System.EventHandler(this.studentcard__studentName_Click);
            this.studentcard__studentID.MouseLeave += new System.EventHandler(this.studentcard__studentID_MouseLeave);
            this.studentcard__studentID.MouseHover += new System.EventHandler(this.studentGender_MouseHover);
            // 
            // studentcard__studentName
            // 
            this.studentcard__studentName.Enabled = false;
            this.studentcard__studentName.Location = new System.Drawing.Point(107, 59);
            this.studentcard__studentName.Multiline = true;
            this.studentcard__studentName.Name = "studentcard__studentName";
            this.studentcard__studentName.ReadOnly = true;
            this.studentcard__studentName.Size = new System.Drawing.Size(141, 44);
            this.studentcard__studentName.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.studentcard__studentName.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.studentcard__studentName.StateCommon.Border.Rounding = 0;
            this.studentcard__studentName.StateCommon.Border.Width = 0;
            this.studentcard__studentName.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.studentcard__studentName.StateCommon.Content.Font = new System.Drawing.Font("Poppins Medium", 10F, System.Drawing.FontStyle.Bold);
            this.studentcard__studentName.StateCommon.Content.Padding = new System.Windows.Forms.Padding(0);
            this.studentcard__studentName.TabIndex = 3;
            this.studentcard__studentName.Text = "Student Name dsdsfdsfdd";
            this.studentcard__studentName.Click += new System.EventHandler(this.studentcard__studentName_Click);
            this.studentcard__studentName.MouseLeave += new System.EventHandler(this.studentcard__studentID_MouseLeave);
            this.studentcard__studentName.MouseHover += new System.EventHandler(this.studentGender_MouseHover);
            // 
            // clickedBG
            // 
            this.clickedBG.Image = ((System.Drawing.Image)(resources.GetObject("clickedBG.Image")));
            this.clickedBG.Location = new System.Drawing.Point(0, -1);
            this.clickedBG.Name = "clickedBG";
            this.clickedBG.Size = new System.Drawing.Size(277, 160);
            this.clickedBG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.clickedBG.TabIndex = 4;
            this.clickedBG.TabStop = false;
            this.clickedBG.Click += new System.EventHandler(this.clickedBG_Click);
            // 
            // feedback_btn
            // 
            this.feedback_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.feedback_btn.Image = ((System.Drawing.Image)(resources.GetObject("feedback_btn.Image")));
            this.feedback_btn.Location = new System.Drawing.Point(69, 58);
            this.feedback_btn.Name = "feedback_btn";
            this.feedback_btn.Size = new System.Drawing.Size(141, 48);
            this.feedback_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.feedback_btn.TabIndex = 5;
            this.feedback_btn.TabStop = false;
            this.feedback_btn.Click += new System.EventHandler(this.feedback_btn_Click);
            // 
            // attendanceReport
            // 
            this.attendanceReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.attendanceReport.Image = ((System.Drawing.Image)(resources.GetObject("attendanceReport.Image")));
            this.attendanceReport.Location = new System.Drawing.Point(53, 6);
            this.attendanceReport.Name = "attendanceReport";
            this.attendanceReport.Padding = new System.Windows.Forms.Padding(5);
            this.attendanceReport.Size = new System.Drawing.Size(173, 58);
            this.attendanceReport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.attendanceReport.TabIndex = 6;
            this.attendanceReport.TabStop = false;
            this.attendanceReport.Click += new System.EventHandler(this.attendanceReport_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 159);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // removeStudent_btn
            // 
            this.removeStudent_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.removeStudent_btn.Image = ((System.Drawing.Image)(resources.GetObject("removeStudent_btn.Image")));
            this.removeStudent_btn.Location = new System.Drawing.Point(87, 106);
            this.removeStudent_btn.Name = "removeStudent_btn";
            this.removeStudent_btn.Size = new System.Drawing.Size(104, 48);
            this.removeStudent_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.removeStudent_btn.TabIndex = 8;
            this.removeStudent_btn.TabStop = false;
            this.removeStudent_btn.Click += new System.EventHandler(this.removeStudent_btn_Click);
            // 
            // studentsCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.removeStudent_btn);
            this.Controls.Add(this.feedback_btn);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.attendanceReport);
            this.Controls.Add(this.clickedBG);
            this.Controls.Add(this.studentcard__studentName);
            this.Controls.Add(this.studentcard__studentID);
            this.Controls.Add(this.studentGender);
            this.DoubleBuffered = true;
            this.Name = "studentsCARD";
            this.Size = new System.Drawing.Size(276, 159);
            this.Load += new System.EventHandler(this.studentsCARD_Load);
            this.Click += new System.EventHandler(this.studentcard__studentName_Click);
            this.MouseLeave += new System.EventHandler(this.studentcard__studentID_MouseLeave);
            this.MouseHover += new System.EventHandler(this.studentGender_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.studentGender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clickedBG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feedback_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.removeStudent_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox studentGender;
        private System.Windows.Forms.Label studentcard__studentID;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox studentcard__studentName;
        private System.Windows.Forms.PictureBox clickedBG;
        private System.Windows.Forms.PictureBox feedback_btn;
        private System.Windows.Forms.PictureBox attendanceReport;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.PictureBox removeStudent_btn;
    }
}
