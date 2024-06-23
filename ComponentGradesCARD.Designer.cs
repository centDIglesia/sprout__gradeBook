namespace sprout__gradeBook
{
    partial class ComponentGradesCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComponentGradesCARD));
            this.compNumber = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.compGrade = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.compMaxGrade = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.compPercentage = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // compNumber
            // 
            this.compNumber.Location = new System.Drawing.Point(11, 8);
            this.compNumber.Multiline = true;
            this.compNumber.Name = "compNumber";
            this.compNumber.Size = new System.Drawing.Size(103, 24);
            this.compNumber.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.compNumber.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.compNumber.StateCommon.Border.Width = 0;
            this.compNumber.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(101)))), ((int)(((byte)(55)))));
            this.compNumber.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compNumber.TabIndex = 1;
            this.compNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.compNumber.TextChanged += new System.EventHandler(this.compNumber_TextChanged);
            // 
            // compGrade
            // 
            this.compGrade.Location = new System.Drawing.Point(125, 8);
            this.compGrade.Name = "compGrade";
            this.compGrade.Size = new System.Drawing.Size(96, 21);
            this.compGrade.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.compGrade.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.compGrade.StateCommon.Border.Width = 0;
            this.compGrade.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(101)))), ((int)(((byte)(55)))));
            this.compGrade.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compGrade.TabIndex = 2;
            this.compGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.compGrade.TextChanged += new System.EventHandler(this.compGrade_TextChanged);
            this.compGrade.Enter += new System.EventHandler(this.compGrade_Enter);
            this.compGrade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.compGrade_KeyPress);
            this.compGrade.Leave += new System.EventHandler(this.compGrade_Leave);
            // 
            // compMaxGrade
            // 
            this.compMaxGrade.Location = new System.Drawing.Point(245, 8);
            this.compMaxGrade.Name = "compMaxGrade";
            this.compMaxGrade.Size = new System.Drawing.Size(112, 21);
            this.compMaxGrade.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            this.compMaxGrade.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.compMaxGrade.StateCommon.Border.Width = 0;
            this.compMaxGrade.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(101)))), ((int)(((byte)(55)))));
            this.compMaxGrade.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compMaxGrade.TabIndex = 3;
            this.compMaxGrade.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.compMaxGrade.TextChanged += new System.EventHandler(this.compMaxGrade_TextChanged);
            this.compMaxGrade.Enter += new System.EventHandler(this.compMaxGrade_Enter);
            this.compMaxGrade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.compMaxGrade_KeyPress);
            this.compMaxGrade.Leave += new System.EventHandler(this.compMaxGrade_Leave);
            // 
            // compPercentage
            // 
            this.compPercentage.Enabled = false;
            this.compPercentage.Location = new System.Drawing.Point(376, 8);
            this.compPercentage.Name = "compPercentage";
            this.compPercentage.ReadOnly = true;
            this.compPercentage.Size = new System.Drawing.Size(78, 22);
            this.compPercentage.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.compPercentage.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.compPercentage.StateCommon.Border.Width = 0;
            this.compPercentage.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(101)))), ((int)(((byte)(55)))));
            this.compPercentage.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compPercentage.TabIndex = 4;
            this.compPercentage.Text = "00%";
            this.compPercentage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.compPercentage.TextChanged += new System.EventHandler(this.compPercentage_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(4, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(466, 37);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ComponentGradesCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.compPercentage);
            this.Controls.Add(this.compMaxGrade);
            this.Controls.Add(this.compGrade);
            this.Controls.Add(this.compNumber);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ComponentGradesCARD";
            this.Size = new System.Drawing.Size(474, 41);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox compNumber;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox compGrade;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox compMaxGrade;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox compPercentage;
    }
}
