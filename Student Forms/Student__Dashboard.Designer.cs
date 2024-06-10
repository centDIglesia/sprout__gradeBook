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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.notification__icon = new System.Windows.Forms.PictureBox();
            this.student_Name = new System.Windows.Forms.Label();
            this.student_ID = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.student_gradesPanel = new System.Windows.Forms.Panel();
            this.student_Icon = new System.Windows.Forms.PictureBox();
            this.student_CoursePanel = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notification__icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_Icon)).BeginInit();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(17, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1116, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(16, 89);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1116, 603);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // notification__icon
            // 
            this.notification__icon.BackColor = System.Drawing.Color.White;
            this.notification__icon.Image = ((System.Drawing.Image)(resources.GetObject("notification__icon.Image")));
            this.notification__icon.Location = new System.Drawing.Point(825, 36);
            this.notification__icon.Name = "notification__icon";
            this.notification__icon.Size = new System.Drawing.Size(38, 24);
            this.notification__icon.TabIndex = 62;
            this.notification__icon.TabStop = false;
            // 
            // student_Name
            // 
            this.student_Name.AutoSize = true;
            this.student_Name.BackColor = System.Drawing.Color.White;
            this.student_Name.Font = new System.Drawing.Font("Poppins SemiBold", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_Name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.student_Name.Location = new System.Drawing.Point(870, 28);
            this.student_Name.Name = "student_Name";
            this.student_Name.Size = new System.Drawing.Size(159, 30);
            this.student_Name.TabIndex = 64;
            this.student_Name.Text = "Student__Name";
            // 
            // student_ID
            // 
            this.student_ID.AutoSize = true;
            this.student_ID.BackColor = System.Drawing.Color.White;
            this.student_ID.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.student_ID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.student_ID.Location = new System.Drawing.Point(872, 51);
            this.student_ID.Name = "student_ID";
            this.student_ID.Size = new System.Drawing.Size(99, 22);
            this.student_ID.TabIndex = 65;
            this.student_ID.Text = "Student__ID";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(862, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(2, 67);
            this.pictureBox3.TabIndex = 66;
            this.pictureBox3.TabStop = false;
            // 
            // student_gradesPanel
            // 
            this.student_gradesPanel.AutoScroll = true;
            this.student_gradesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.student_gradesPanel.Location = new System.Drawing.Point(360, 128);
            this.student_gradesPanel.Name = "student_gradesPanel";
            this.student_gradesPanel.Size = new System.Drawing.Size(765, 399);
            this.student_gradesPanel.TabIndex = 67;
            // 
            // student_Icon
            // 
            this.student_Icon.BackColor = System.Drawing.Color.White;
            this.student_Icon.Image = global::sprout__gradeBook.Properties.Resources.femaleee;
            this.student_Icon.Location = new System.Drawing.Point(1056, 21);
            this.student_Icon.Name = "student_Icon";
            this.student_Icon.Size = new System.Drawing.Size(71, 57);
            this.student_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.student_Icon.TabIndex = 0;
            this.student_Icon.TabStop = false;
            // 
            // student_CoursePanel
            // 
            this.student_CoursePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.student_CoursePanel.AutoScroll = true;
            this.student_CoursePanel.BackColor = System.Drawing.Color.White;
            this.student_CoursePanel.Location = new System.Drawing.Point(28, 128);
            this.student_CoursePanel.Name = "student_CoursePanel";
            this.student_CoursePanel.Size = new System.Drawing.Size(303, 242);
            this.student_CoursePanel.TabIndex = 94;
            // 
            // Student__Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.ClientSize = new System.Drawing.Size(1147, 711);
            this.Controls.Add(this.student_CoursePanel);
            this.Controls.Add(this.student_Icon);
            this.Controls.Add(this.student_gradesPanel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.student_ID);
            this.Controls.Add(this.student_Name);
            this.Controls.Add(this.notification__icon);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Student__Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student__Dashboard";
            this.Load += new System.EventHandler(this.Student__Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notification__icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox notification__icon;
        private System.Windows.Forms.Label student_Name;
        private System.Windows.Forms.Label student_ID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel student_gradesPanel;
        private System.Windows.Forms.PictureBox student_Icon;
        public System.Windows.Forms.FlowLayoutPanel student_CoursePanel;
    }
}