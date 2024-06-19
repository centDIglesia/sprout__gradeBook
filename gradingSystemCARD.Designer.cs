namespace sprout__gradeBook
{
    partial class gradingSystemCARD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gradingSystemCARD));
            this.componentsTXT = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.componentsWeightTXT = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.detethisCardbtn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.detethisCardbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // componentsTXT
            // 
            this.componentsTXT.Location = new System.Drawing.Point(36, 8);
            this.componentsTXT.MaximumSize = new System.Drawing.Size(360, 32);
            this.componentsTXT.MinimumSize = new System.Drawing.Size(360, 32);
            this.componentsTXT.Multiline = true;
            this.componentsTXT.Name = "componentsTXT";
            this.componentsTXT.Size = new System.Drawing.Size(360, 32);
            this.componentsTXT.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.componentsTXT.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.componentsTXT.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.componentsTXT.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.componentsTXT.StateCommon.Border.Rounding = 4;
            this.componentsTXT.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.componentsTXT.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentsTXT.TabIndex = 0;
            this.componentsTXT.Text = "Component";
            this.componentsTXT.TextChanged += new System.EventHandler(this.componentsTXT_TextChanged);
            this.componentsTXT.Enter += new System.EventHandler(this.componentsTXT_Enter);
            // 
            // componentsWeightTXT
            // 
            this.componentsWeightTXT.Location = new System.Drawing.Point(405, 8);
            this.componentsWeightTXT.MaximumSize = new System.Drawing.Size(127, 32);
            this.componentsWeightTXT.MinimumSize = new System.Drawing.Size(127, 32);
            this.componentsWeightTXT.Multiline = true;
            this.componentsWeightTXT.Name = "componentsWeightTXT";
            this.componentsWeightTXT.Size = new System.Drawing.Size(127, 32);
            this.componentsWeightTXT.StateActive.Content.Color1 = System.Drawing.Color.White;
            this.componentsWeightTXT.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.componentsWeightTXT.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.componentsWeightTXT.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.componentsWeightTXT.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.componentsWeightTXT.StateCommon.Border.Rounding = 4;
            this.componentsWeightTXT.StateCommon.Content.Color1 = System.Drawing.Color.White;
            this.componentsWeightTXT.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.componentsWeightTXT.TabIndex = 1;
            this.componentsWeightTXT.Text = "0";
            this.componentsWeightTXT.TextChanged += new System.EventHandler(this.componentsWeightTXT_TextChanged);
            this.componentsWeightTXT.Enter += new System.EventHandler(this.componentsWeightTXT_Enter);
            this.componentsWeightTXT.Leave += new System.EventHandler(this.componentsWeightTXT_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.label1.Location = new System.Drawing.Point(532, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "(%)";
            // 
            // detethisCardbtn
            // 
            this.detethisCardbtn.Image = ((System.Drawing.Image)(resources.GetObject("detethisCardbtn.Image")));
            this.detethisCardbtn.Location = new System.Drawing.Point(4, 8);
            this.detethisCardbtn.Name = "detethisCardbtn";
            this.detethisCardbtn.Size = new System.Drawing.Size(31, 32);
            this.detethisCardbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.detethisCardbtn.TabIndex = 3;
            this.detethisCardbtn.TabStop = false;
            this.detethisCardbtn.Click += new System.EventHandler(this.detethisCardbtn_Click);
            // 
            // gradingSystemCARD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.detethisCardbtn);
            this.Controls.Add(this.componentsWeightTXT);
            this.Controls.Add(this.componentsTXT);
            this.Controls.Add(this.label1);
            this.Name = "gradingSystemCARD";
            this.Size = new System.Drawing.Size(569, 51);
            this.Load += new System.EventHandler(this.gradingSystemCARD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detethisCardbtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonTextBox componentsTXT;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox componentsWeightTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox detethisCardbtn;
    }
}
