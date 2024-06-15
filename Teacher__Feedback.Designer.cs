namespace sprout__gradeBook
{
    partial class Teacher__Feedback
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Teacher__Feedback));
            this.feedback_studentname_lbl = new System.Windows.Forms.Label();
            this.feedbackTitle_txt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.feedbackDescription_txt = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonPalette2 = new ComponentFactory.Krypton.Toolkit.KryptonPalette(this.components);
            this.cancel_btn = new System.Windows.Forms.PictureBox();
            this.sendFeedback_btn = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cancel_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendFeedback_btn)).BeginInit();
            this.SuspendLayout();
            // 
            // feedback_studentname_lbl
            // 
            this.feedback_studentname_lbl.AutoSize = true;
            this.feedback_studentname_lbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedback_studentname_lbl.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedback_studentname_lbl.ForeColor = System.Drawing.Color.White;
            this.feedback_studentname_lbl.Location = new System.Drawing.Point(-4, -1);
            this.feedback_studentname_lbl.Name = "feedback_studentname_lbl";
            this.feedback_studentname_lbl.Padding = new System.Windows.Forms.Padding(15, 6, 400, 5);
            this.feedback_studentname_lbl.Size = new System.Drawing.Size(590, 33);
            this.feedback_studentname_lbl.TabIndex = 7;
            this.feedback_studentname_lbl.Text = "Give _blank some feedback";
            // 
            // feedbackTitle_txt
            // 
            this.feedbackTitle_txt.Location = new System.Drawing.Point(12, 49);
            this.feedbackTitle_txt.Multiline = true;
            this.feedbackTitle_txt.Name = "feedbackTitle_txt";
            this.feedbackTitle_txt.Size = new System.Drawing.Size(405, 38);
            this.feedbackTitle_txt.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.feedbackTitle_txt.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedbackTitle_txt.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedbackTitle_txt.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.feedbackTitle_txt.StateCommon.Border.Rounding = 4;
            this.feedbackTitle_txt.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedbackTitle_txt.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackTitle_txt.TabIndex = 6;
            this.feedbackTitle_txt.Text = "Title";
            this.feedbackTitle_txt.Enter += new System.EventHandler(this.feedbackTitle_txt_Enter);
            this.feedbackTitle_txt.Leave += new System.EventHandler(this.feedbackTitle_txt_Leave);
            // 
            // feedbackDescription_txt
            // 
            this.feedbackDescription_txt.Location = new System.Drawing.Point(12, 97);
            this.feedbackDescription_txt.Multiline = true;
            this.feedbackDescription_txt.Name = "feedbackDescription_txt";
            this.feedbackDescription_txt.Size = new System.Drawing.Size(405, 189);
            this.feedbackDescription_txt.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedbackDescription_txt.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedbackDescription_txt.StateCommon.Border.DrawBorders = ((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders)((((ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Top | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Left) 
            | ComponentFactory.Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.feedbackDescription_txt.StateCommon.Border.Rounding = 4;
            this.feedbackDescription_txt.StateCommon.Content.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(103)))), ((int)(((byte)(56)))));
            this.feedbackDescription_txt.StateCommon.Content.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.feedbackDescription_txt.TabIndex = 5;
            this.feedbackDescription_txt.Text = "Description";
            this.feedbackDescription_txt.Enter += new System.EventHandler(this.feedbackDescription_txt_Enter);
            this.feedbackDescription_txt.Leave += new System.EventHandler(this.feedbackDescription_txt_Leave);
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
            // cancel_btn
            // 
            this.cancel_btn.Image = ((System.Drawing.Image)(resources.GetObject("cancel_btn.Image")));
            this.cancel_btn.Location = new System.Drawing.Point(222, 305);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(90, 30);
            this.cancel_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cancel_btn.TabIndex = 8;
            this.cancel_btn.TabStop = false;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // sendFeedback_btn
            // 
            this.sendFeedback_btn.Image = ((System.Drawing.Image)(resources.GetObject("sendFeedback_btn.Image")));
            this.sendFeedback_btn.Location = new System.Drawing.Point(318, 305);
            this.sendFeedback_btn.Name = "sendFeedback_btn";
            this.sendFeedback_btn.Size = new System.Drawing.Size(97, 30);
            this.sendFeedback_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.sendFeedback_btn.TabIndex = 9;
            this.sendFeedback_btn.TabStop = false;
            this.sendFeedback_btn.Click += new System.EventHandler(this.sendFeedback_btn_Click);
            // 
            // Teacher__Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 352);
            this.Controls.Add(this.sendFeedback_btn);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.feedback_studentname_lbl);
            this.Controls.Add(this.feedbackTitle_txt);
            this.Controls.Add(this.feedbackDescription_txt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Teacher__Feedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teacher__Feedback";
            ((System.ComponentModel.ISupportInitialize)(this.cancel_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sendFeedback_btn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label feedback_studentname_lbl;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox feedbackTitle_txt;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox feedbackDescription_txt;
        private ComponentFactory.Krypton.Toolkit.KryptonPalette kryptonPalette2;
        private System.Windows.Forms.PictureBox cancel_btn;
        private System.Windows.Forms.PictureBox sendFeedback_btn;
    }
}