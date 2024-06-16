namespace sprout__gradeBook
{
    partial class studentsInGradebookCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(studentsInGradebookCARD));
            this.kryptonPalette2 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.nameofStudent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.idOfStudent = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
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
            // nameofStudent
            // 
            this.nameofStudent.Location = new System.Drawing.Point(7, 6);
            this.nameofStudent.Name = "nameofStudent";
            this.nameofStudent.Size = new System.Drawing.Size(103, 22);
            this.nameofStudent.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.nameofStudent.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.nameofStudent.StateCommon.ShortText.Font = new System.Drawing.Font("Poppins Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameofStudent.TabIndex = 0;
            this.nameofStudent.Values.Text = "kryptonLabel1";
            this.nameofStudent.Click += new System.EventHandler(this.studentsInGradebookCARD_Click);
            // 
            // idOfStudent
            // 
            this.idOfStudent.Location = new System.Drawing.Point(7, 27);
            this.idOfStudent.Name = "idOfStudent";
            this.idOfStudent.Size = new System.Drawing.Size(89, 19);
            this.idOfStudent.StateCommon.ShortText.Color1 = System.Drawing.Color.White;
            this.idOfStudent.StateCommon.ShortText.Color2 = System.Drawing.Color.White;
            this.idOfStudent.StateCommon.ShortText.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idOfStudent.TabIndex = 1;
            this.idOfStudent.Values.Text = "kryptonLabel2";
            this.idOfStudent.Click += new System.EventHandler(this.studentsInGradebookCARD_Click);
            // 
            // studentsInGradebookCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.nameofStudent);
            this.Controls.Add(this.idOfStudent);
            this.DoubleBuffered = true;
            this.Name = "studentsInGradebookCARD";
            this.Size = new System.Drawing.Size(235, 52);
            this.Click += new System.EventHandler(this.studentsInGradebookCARD_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette2;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel nameofStudent;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel idOfStudent;
    }
}
