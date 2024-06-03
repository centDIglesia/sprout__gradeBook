namespace sprout__gradeBook
{
    partial class NewTask
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
            this.newTask__chkbx = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
            this.deleteTask_Tooltip = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deleteTask_Tooltip)).BeginInit();
            this.SuspendLayout();
            // 
            // newTask__chkbx
            // 
            this.newTask__chkbx.AutoSize = false;
            this.newTask__chkbx.Images.CheckedDisabled = global::sprout__gradeBook.Properties.Resources.task_normal;
            this.newTask__chkbx.Images.CheckedNormal = global::sprout__gradeBook.Properties.Resources.task_checked;
            this.newTask__chkbx.Images.CheckedPressed = global::sprout__gradeBook.Properties.Resources.task_checked;
            this.newTask__chkbx.Images.CheckedTracking = global::sprout__gradeBook.Properties.Resources.task_checked;
            this.newTask__chkbx.Images.Common = global::sprout__gradeBook.Properties.Resources.task_normal;
            this.newTask__chkbx.Images.UncheckedNormal = global::sprout__gradeBook.Properties.Resources.task_normal;
            this.newTask__chkbx.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
            this.newTask__chkbx.Location = new System.Drawing.Point(15, 5);
            this.newTask__chkbx.Name = "newTask__chkbx";
            this.newTask__chkbx.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalOffice2003;
            this.newTask__chkbx.Size = new System.Drawing.Size(382, 25);
            this.newTask__chkbx.StateNormal.ShortText.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.newTask__chkbx.StateNormal.ShortText.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.newTask__chkbx.StateNormal.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.newTask__chkbx.TabIndex = 0;
            this.newTask__chkbx.Values.Text = "New Task";
            this.newTask__chkbx.CheckedChanged += new System.EventHandler(this.newTask__chkbx_CheckedChanged);
            // 
            // deleteTask_Tooltip
            // 
            this.deleteTask_Tooltip.Image = global::sprout__gradeBook.Properties.Resources.recycle_bin;
            this.deleteTask_Tooltip.Location = new System.Drawing.Point(351, 3);
            this.deleteTask_Tooltip.Name = "deleteTask_Tooltip";
            this.deleteTask_Tooltip.Size = new System.Drawing.Size(41, 25);
            this.deleteTask_Tooltip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.deleteTask_Tooltip.TabIndex = 1;
            this.deleteTask_Tooltip.TabStop = false;
            this.deleteTask_Tooltip.Click += new System.EventHandler(this.deleteTask_Tooltip_Click);
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(239)))), ((int)(((byte)(233)))));
            this.Controls.Add(this.deleteTask_Tooltip);
            this.Controls.Add(this.newTask__chkbx);
            this.Name = "NewTask";
            this.Size = new System.Drawing.Size(399, 32);
            this.Load += new System.EventHandler(this.NewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deleteTask_Tooltip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonCheckBox newTask__chkbx;
        private System.Windows.Forms.PictureBox deleteTask_Tooltip;
    }
}
