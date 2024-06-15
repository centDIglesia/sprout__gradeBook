namespace sprout__gradeBook
{
    partial class Student__Dashboard
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Student__Dashboard));
            this.kryptonPalette2 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.student_Name = new System.Windows.Forms.Label();
            this.student_ID = new System.Windows.Forms.Label();
            this.student_gradesPanel = new System.Windows.Forms.Panel();
            this.student_CoursePanel = new System.Windows.Forms.FlowLayoutPanel();
            this.feedback_btn = new System.Windows.Forms.PictureBox();
            this.close_btn = new System.Windows.Forms.PictureBox();
            this.student_Icon = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.notification__icon = new System.Windows.Forms.PictureBox();
            this.Student__Dashboard__UI = new System.Windows.Forms.PictureBox();
            this.kryptonTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.notificationCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feedback_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_Icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notification__icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student__Dashboard__UI)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPalette2
            // 
            this.kryptonPalette2.BasePaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Global;
            this.kryptonPalette2.FormStyles.FormMain.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette2.FormStyles.FormMain.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette2.HeaderStyles.HeaderCommon.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonPalette2.HeaderStyles.HeaderCommon.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonPalette2.HeaderStyles.HeaderCommon.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.kryptonPalette2.HeaderStyles.HeaderCommon.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.kryptonPalette2.HeaderStyles.HeaderCommon.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonPalette2.InputControlStyles.InputControlCommon.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // student_Name
            // 
            this.student_Name.AutoSize = true;
            this.student_Name.BackColor = System.Drawing.Color.White;
            this.student_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.student_Name.Location = new System.Drawing.Point(826, 21);
            this.student_Name.Name = "student_Name";
            this.student_Name.Size = new System.Drawing.Size(141, 20);
            this.student_Name.TabIndex = 64;
            this.student_Name.Text = "Student__Name";
            // 
            // student_ID
            // 
            this.student_ID.AutoSize = true;
            this.student_ID.BackColor = System.Drawing.Color.White;
            this.student_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.student_ID.Location = new System.Drawing.Point(828, 44);
            this.student_ID.Name = "student_ID";
            this.student_ID.Size = new System.Drawing.Size(86, 15);
            this.student_ID.TabIndex = 65;
            this.student_ID.Text = "Student__ID";
            // 
            // student_gradesPanel
            // 
            this.student_gradesPanel.AutoScroll = true;
            this.student_gradesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.student_gradesPanel.Location = new System.Drawing.Point(401, 132);
            this.student_gradesPanel.Name = "student_gradesPanel";
            this.student_gradesPanel.Size = new System.Drawing.Size(716, 451);
            this.student_gradesPanel.TabIndex = 67;
            // 
            // student_CoursePanel
            // 
            this.student_CoursePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.student_CoursePanel.AutoScroll = true;
            this.student_CoursePanel.BackColor = System.Drawing.Color.White;
            this.student_CoursePanel.Location = new System.Drawing.Point(23, 132);
            this.student_CoursePanel.Name = "student_CoursePanel";
            this.student_CoursePanel.Size = new System.Drawing.Size(324, 535);
            this.student_CoursePanel.TabIndex = 94;
            // 
            // feedback_btn
            // 
            this.feedback_btn.Image = global::sprout__gradeBook.Properties.Resources.Feedback_Icon;
            this.feedback_btn.Location = new System.Drawing.Point(757, 27);
            this.feedback_btn.Name = "feedback_btn";
            this.feedback_btn.Size = new System.Drawing.Size(24, 24);
            this.feedback_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.feedback_btn.TabIndex = 99;
            this.feedback_btn.TabStop = false;
            this.feedback_btn.Click += new System.EventHandler(this.feedback_btn_Click);
            // 
            // close_btn
            // 
            this.close_btn.BackColor = System.Drawing.Color.Transparent;
            this.close_btn.Image = ((System.Drawing.Image)(resources.GetObject("close_btn.Image")));
            this.close_btn.Location = new System.Drawing.Point(1117, 9);
            this.close_btn.Name = "close_btn";
            this.close_btn.Size = new System.Drawing.Size(24, 24);
            this.close_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.close_btn.TabIndex = 97;
            this.close_btn.TabStop = false;
            this.close_btn.Click += new System.EventHandler(this.close_btn_Click);
            // 
            // student_Icon
            // 
            this.student_Icon.BackColor = System.Drawing.Color.White;
            this.student_Icon.Image = global::sprout__gradeBook.Properties.Resources.Female_Icon;
            this.student_Icon.Location = new System.Drawing.Point(1043, 14);
            this.student_Icon.Name = "student_Icon";
            this.student_Icon.Size = new System.Drawing.Size(71, 57);
            this.student_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.student_Icon.TabIndex = 0;
            this.student_Icon.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.pictureBox3.Location = new System.Drawing.Point(819, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 67);
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // notification__icon
            // 
            this.notification__icon.BackColor = System.Drawing.Color.White;
            this.notification__icon.Image = global::sprout__gradeBook.Properties.Resources.notification_icon;
            this.notification__icon.Location = new System.Drawing.Point(787, 27);
            this.notification__icon.Name = "notification__icon";
            this.notification__icon.Size = new System.Drawing.Size(22, 22);
            this.notification__icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.notification__icon.TabIndex = 62;
            this.notification__icon.TabStop = false;
            this.notification__icon.Click += new System.EventHandler(this.notifCount_Click);
            // 
            // Student__Dashboard__UI
            // 
            this.Student__Dashboard__UI.Image = global::sprout__gradeBook.Properties.Resources.student__Dashboard_UI;
            this.Student__Dashboard__UI.Location = new System.Drawing.Point(3, 4);
            this.Student__Dashboard__UI.Name = "Student__Dashboard__UI";
            this.Student__Dashboard__UI.Size = new System.Drawing.Size(1140, 697);
            this.Student__Dashboard__UI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Student__Dashboard__UI.TabIndex = 95;
            this.Student__Dashboard__UI.TabStop = false;
            // 
            // kryptonTextBox1
            // 
            this.kryptonTextBox1.Location = new System.Drawing.Point(621, 21);
            this.kryptonTextBox1.Multiline = true;
            this.kryptonTextBox1.Name = "kryptonTextBox1";
            this.kryptonTextBox1.Size = new System.Drawing.Size(21, 27);
            this.kryptonTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.Red;
            this.kryptonTextBox1.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonTextBox1.StateCommon.Border.Rounding = 10;
            this.kryptonTextBox1.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.kryptonTextBox1.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonTextBox1.TabIndex = 100;
            this.kryptonTextBox1.Text = "4";
            // 
            // notificationCount
            // 
            this.notificationCount.BackColor = System.Drawing.Color.Firebrick;
            this.notificationCount.ForeColor = System.Drawing.Color.White;
            this.notificationCount.Location = new System.Drawing.Point(592, 21);
            this.notificationCount.Name = "notificationCount";
            this.notificationCount.Size = new System.Drawing.Size(23, 23);
            this.notificationCount.TabIndex = 0;
            this.notificationCount.Text = "4";
            this.notificationCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Student__Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1147, 711);
            this.Controls.Add(this.kryptonTextBox1);
            this.Controls.Add(this.feedback_btn);
            this.Controls.Add(this.notificationCount);
            this.Controls.Add(this.close_btn);
            this.Controls.Add(this.student_CoursePanel);
            this.Controls.Add(this.student_Icon);
            this.Controls.Add(this.student_gradesPanel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.student_ID);
            this.Controls.Add(this.student_Name);
            this.Controls.Add(this.notification__icon);
            this.Controls.Add(this.Student__Dashboard__UI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Student__Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student__Dashboard";
            this.Load += new System.EventHandler(this.Student__Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feedback_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.close_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_Icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notification__icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Student__Dashboard__UI)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette2;
        private System.Windows.Forms.PictureBox notification__icon;
        private System.Windows.Forms.Label student_Name;
        private System.Windows.Forms.Label student_ID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel student_gradesPanel;
        private System.Windows.Forms.PictureBox student_Icon;
        public System.Windows.Forms.FlowLayoutPanel student_CoursePanel;
        private System.Windows.Forms.PictureBox Student__Dashboard__UI;
        private System.Windows.Forms.PictureBox close_btn;
        private System.Windows.Forms.PictureBox feedback_btn;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox kryptonTextBox1;
        private System.Windows.Forms.Label notificationCount;
    }
}