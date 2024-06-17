namespace sprout__gradeBook
{
    partial class Attendance__Row
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
            this.attendance_studentID = new System.Windows.Forms.Label();
            this.attendance_studentName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.presentButton = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.absentButton = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.lateButton = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.excusedButton = new ComponentFactory.Krypton.Toolkit.KryptonCheckButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // attendance_studentID
            // 
            this.attendance_studentID.BackColor = System.Drawing.Color.White;
            this.attendance_studentID.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendance_studentID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.attendance_studentID.Location = new System.Drawing.Point(2, 5);
            this.attendance_studentID.Name = "attendance_studentID";
            this.attendance_studentID.Size = new System.Drawing.Size(177, 45);
            this.attendance_studentID.TabIndex = 1;
            this.attendance_studentID.Text = "Student ID";
            this.attendance_studentID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // attendance_studentName
            // 
            this.attendance_studentName.BackColor = System.Drawing.Color.White;
            this.attendance_studentName.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attendance_studentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.attendance_studentName.Location = new System.Drawing.Point(184, 4);
            this.attendance_studentName.Name = "attendance_studentName";
            this.attendance_studentName.Size = new System.Drawing.Size(249, 45);
            this.attendance_studentName.TabIndex = 2;
            this.attendance_studentName.Text = "Student Name";
            this.attendance_studentName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.label1.Location = new System.Drawing.Point(446, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Present";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins Medium", 8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.label2.Location = new System.Drawing.Point(510, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "Absent";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.label3.Location = new System.Drawing.Point(577, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Late";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins Medium", 8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.label4.Location = new System.Drawing.Point(626, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Excused";
            // 
            // presentButton
            // 
            this.presentButton.Location = new System.Drawing.Point(456, 6);
            this.presentButton.Name = "presentButton";
            this.presentButton.Size = new System.Drawing.Size(36, 25);
            this.presentButton.StateCheckedNormal.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StateCheckedNormal.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.StateCheckedNormal.Back.Image = global::sprout__gradeBook.Properties.Resources.Present_Checked;
            this.presentButton.StateCheckedPressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.presentButton.StateCheckedPressed.Border.Image = global::sprout__gradeBook.Properties.Resources.Present_Checked;
            this.presentButton.StateCheckedTracking.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StateCheckedTracking.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.StateCheckedTracking.Back.Image = global::sprout__gradeBook.Properties.Resources.Present_Checked;
            this.presentButton.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.StateCommon.Back.Image = global::sprout__gradeBook.Properties.Resources.Present_Unchecked;
            this.presentButton.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.presentButton.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.presentButton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.presentButton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.presentButton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.presentButton.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.presentButton.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.presentButton.TabIndex = 13;
            this.presentButton.Values.Text = "";
            // 
            // absentButton
            // 
            this.absentButton.Location = new System.Drawing.Point(519, 6);
            this.absentButton.Name = "absentButton";
            this.absentButton.Size = new System.Drawing.Size(36, 25);
            this.absentButton.StateCheckedNormal.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StateCheckedNormal.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.StateCheckedNormal.Back.Image = global::sprout__gradeBook.Properties.Resources.Absent_Checked;
            this.absentButton.StateCheckedPressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.absentButton.StateCheckedPressed.Border.Image = global::sprout__gradeBook.Properties.Resources.Absent_Checked;
            this.absentButton.StateCheckedTracking.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StateCheckedTracking.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.StateCheckedTracking.Back.Image = global::sprout__gradeBook.Properties.Resources.Absent_Checked;
            this.absentButton.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.StateCommon.Back.Image = global::sprout__gradeBook.Properties.Resources.Absent_Unchecked;
            this.absentButton.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.absentButton.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.absentButton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.absentButton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.absentButton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.absentButton.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.absentButton.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.absentButton.TabIndex = 14;
            this.absentButton.Values.Text = "";
            // 
            // lateButton
            // 
            this.lateButton.Location = new System.Drawing.Point(576, 6);
            this.lateButton.Name = "lateButton";
            this.lateButton.Size = new System.Drawing.Size(36, 25);
            this.lateButton.StateCheckedNormal.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StateCheckedNormal.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.StateCheckedNormal.Back.Image = global::sprout__gradeBook.Properties.Resources.Late_Checked;
            this.lateButton.StateCheckedPressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.lateButton.StateCheckedPressed.Border.Image = global::sprout__gradeBook.Properties.Resources.Late_Checked;
            this.lateButton.StateCheckedTracking.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StateCheckedTracking.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.StateCheckedTracking.Back.Image = global::sprout__gradeBook.Properties.Resources.Late_Checked;
            this.lateButton.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.StateCommon.Back.Image = global::sprout__gradeBook.Properties.Resources.Late_Unchecked;
            this.lateButton.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.lateButton.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.lateButton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.lateButton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.lateButton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.lateButton.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.lateButton.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.lateButton.TabIndex = 15;
            this.lateButton.Values.Text = "";
            // 
            // excusedButton
            // 
            this.excusedButton.Location = new System.Drawing.Point(637, 6);
            this.excusedButton.Name = "excusedButton";
            this.excusedButton.Size = new System.Drawing.Size(36, 25);
            this.excusedButton.StateCheckedNormal.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateCheckedNormal.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.StateCheckedNormal.Back.Image = global::sprout__gradeBook.Properties.Resources.Excused_Checked;
            this.excusedButton.StateCheckedPressed.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.excusedButton.StateCheckedPressed.Border.Image = global::sprout__gradeBook.Properties.Resources.Excused_Checked;
            this.excusedButton.StateCheckedTracking.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateCheckedTracking.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.StateCheckedTracking.Back.Image = global::sprout__gradeBook.Properties.Resources.Excused_Checked;
            this.excusedButton.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.StateCommon.Back.Image = global::sprout__gradeBook.Properties.Resources.Excused_Unchecked;
            this.excusedButton.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.excusedButton.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.excusedButton.StateCommon.Border.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateCommon.Border.Color2 = System.Drawing.Color.White;
            this.excusedButton.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.excusedButton.StateDisabled.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateDisabled.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.StateNormal.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateNormal.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.StatePressed.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StatePressed.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.StateTracking.Back.Color1 = System.Drawing.Color.White;
            this.excusedButton.StateTracking.Back.Color2 = System.Drawing.Color.White;
            this.excusedButton.TabIndex = 16;
            this.excusedButton.Values.Text = "";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.pictureBox3.Location = new System.Drawing.Point(179, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1, 61);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(90)))), ((int)(((byte)(35)))));
            this.pictureBox2.Location = new System.Drawing.Point(437, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1, 61);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // Attendance__Row
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.excusedButton);
            this.Controls.Add(this.lateButton);
            this.Controls.Add(this.absentButton);
            this.Controls.Add(this.presentButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.attendance_studentName);
            this.Controls.Add(this.attendance_studentID);
            this.Name = "Attendance__Row";
            this.Size = new System.Drawing.Size(693, 50);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label attendance_studentID;
        private System.Windows.Forms.Label attendance_studentName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton presentButton;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton absentButton;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton lateButton;
        private ComponentFactory.Krypton.Toolkit.KryptonCheckButton excusedButton;
    }
}
