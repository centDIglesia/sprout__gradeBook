namespace sprout__gradeBook
{
    partial class addStudentDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addStudentDashboard));
            this.kryptonPalette2 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.displayStudentsflowlayout = new System.Windows.Forms.FlowLayoutPanel();
            this.deleteBTN = new System.Windows.Forms.PictureBox();
            this.addstudentBTN = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.deleteBTN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addstudentBTN)).BeginInit();
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
            // displayStudentsflowlayout
            // 
            this.displayStudentsflowlayout.Location = new System.Drawing.Point(16, 16);
            this.displayStudentsflowlayout.Name = "displayStudentsflowlayout";
            this.displayStudentsflowlayout.Size = new System.Drawing.Size(704, 472);
            this.displayStudentsflowlayout.TabIndex = 0;
            // 
            // deleteBTN
            // 
            this.deleteBTN.Image = global::sprout__gradeBook.Properties.Resources.recycle_bin;
            this.deleteBTN.Location = new System.Drawing.Point(512, 494);
            this.deleteBTN.Name = "deleteBTN";
            this.deleteBTN.Size = new System.Drawing.Size(49, 50);
            this.deleteBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.deleteBTN.TabIndex = 90;
            this.deleteBTN.TabStop = false;
            // 
            // addstudentBTN
            // 
            this.addstudentBTN.Image = ((System.Drawing.Image)(resources.GetObject("addstudentBTN.Image")));
            this.addstudentBTN.Location = new System.Drawing.Point(567, 494);
            this.addstudentBTN.Name = "addstudentBTN";
            this.addstudentBTN.Size = new System.Drawing.Size(153, 50);
            this.addstudentBTN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.addstudentBTN.TabIndex = 91;
            this.addstudentBTN.TabStop = false;
            this.addstudentBTN.Click += new System.EventHandler(this.addstudentBTN_Click);
            // 
            // addStudentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(739, 556);
            this.Controls.Add(this.deleteBTN);
            this.Controls.Add(this.displayStudentsflowlayout);
            this.Controls.Add(this.addstudentBTN);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "addStudentDashboard";
            this.Text = "addStudentDashboard";
            this.Load += new System.EventHandler(this.addStudentDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.deleteBTN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addstudentBTN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette2;
        private System.Windows.Forms.FlowLayoutPanel displayStudentsflowlayout;
        private System.Windows.Forms.PictureBox deleteBTN;
        private System.Windows.Forms.PictureBox addstudentBTN;
    }
}