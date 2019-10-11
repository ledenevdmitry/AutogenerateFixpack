namespace AutogenerateFixpack
{
    partial class CheckForm
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
            this.TbFilesNotFound = new System.Windows.Forms.TextBox();
            this.GbFilesNotFound = new System.Windows.Forms.GroupBox();
            this.GbLinesNotFound = new System.Windows.Forms.GroupBox();
            this.TbLinesNotFound = new System.Windows.Forms.TextBox();
            this.GbScenariosNotFound = new System.Windows.Forms.GroupBox();
            this.TbScenariosNotFound = new System.Windows.Forms.TextBox();
            this.BtAbort = new System.Windows.Forms.Button();
            this.BtContinue = new System.Windows.Forms.Button();
            this.GbFilesNotFound.SuspendLayout();
            this.GbLinesNotFound.SuspendLayout();
            this.GbScenariosNotFound.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbFilesNotFound
            // 
            this.TbFilesNotFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbFilesNotFound.Location = new System.Drawing.Point(3, 16);
            this.TbFilesNotFound.Multiline = true;
            this.TbFilesNotFound.Name = "TbFilesNotFound";
            this.TbFilesNotFound.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbFilesNotFound.Size = new System.Drawing.Size(501, 98);
            this.TbFilesNotFound.TabIndex = 0;
            // 
            // GbFilesNotFound
            // 
            this.GbFilesNotFound.Controls.Add(this.TbFilesNotFound);
            this.GbFilesNotFound.Location = new System.Drawing.Point(12, 12);
            this.GbFilesNotFound.Name = "GbFilesNotFound";
            this.GbFilesNotFound.Size = new System.Drawing.Size(507, 117);
            this.GbFilesNotFound.TabIndex = 1;
            this.GbFilesNotFound.TabStop = false;
            this.GbFilesNotFound.Text = "Ненайденные файлы";
            // 
            // GbLinesNotFound
            // 
            this.GbLinesNotFound.Controls.Add(this.TbLinesNotFound);
            this.GbLinesNotFound.Location = new System.Drawing.Point(12, 135);
            this.GbLinesNotFound.Name = "GbLinesNotFound";
            this.GbLinesNotFound.Size = new System.Drawing.Size(507, 117);
            this.GbLinesNotFound.TabIndex = 2;
            this.GbLinesNotFound.TabStop = false;
            this.GbLinesNotFound.Text = "Ненайденные строки";
            // 
            // TbLinesNotFound
            // 
            this.TbLinesNotFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbLinesNotFound.Location = new System.Drawing.Point(3, 16);
            this.TbLinesNotFound.Multiline = true;
            this.TbLinesNotFound.Name = "TbLinesNotFound";
            this.TbLinesNotFound.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbLinesNotFound.Size = new System.Drawing.Size(501, 98);
            this.TbLinesNotFound.TabIndex = 0;
            // 
            // GbScenariosNotFound
            // 
            this.GbScenariosNotFound.Controls.Add(this.TbScenariosNotFound);
            this.GbScenariosNotFound.Location = new System.Drawing.Point(12, 258);
            this.GbScenariosNotFound.Name = "GbScenariosNotFound";
            this.GbScenariosNotFound.Size = new System.Drawing.Size(507, 117);
            this.GbScenariosNotFound.TabIndex = 3;
            this.GbScenariosNotFound.TabStop = false;
            this.GbScenariosNotFound.Text = "Ненайденные файлы сценария";
            // 
            // TbScenariosNotFound
            // 
            this.TbScenariosNotFound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbScenariosNotFound.Location = new System.Drawing.Point(3, 16);
            this.TbScenariosNotFound.Multiline = true;
            this.TbScenariosNotFound.Name = "TbScenariosNotFound";
            this.TbScenariosNotFound.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbScenariosNotFound.Size = new System.Drawing.Size(501, 98);
            this.TbScenariosNotFound.TabIndex = 0;
            // 
            // BtAbort
            // 
            this.BtAbort.Location = new System.Drawing.Point(149, 381);
            this.BtAbort.Name = "BtAbort";
            this.BtAbort.Size = new System.Drawing.Size(105, 32);
            this.BtAbort.TabIndex = 4;
            this.BtAbort.Text = "Прекратить";
            this.BtAbort.UseVisualStyleBackColor = true;
            this.BtAbort.Click += new System.EventHandler(this.BtAbort_Click);
            // 
            // BtContinue
            // 
            this.BtContinue.Location = new System.Drawing.Point(260, 381);
            this.BtContinue.Name = "BtContinue";
            this.BtContinue.Size = new System.Drawing.Size(105, 32);
            this.BtContinue.TabIndex = 5;
            this.BtContinue.Text = "Продолжить";
            this.BtContinue.UseVisualStyleBackColor = true;
            this.BtContinue.Click += new System.EventHandler(this.BtContinue_Click);
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 425);
            this.Controls.Add(this.BtContinue);
            this.Controls.Add(this.BtAbort);
            this.Controls.Add(this.GbScenariosNotFound);
            this.Controls.Add(this.GbLinesNotFound);
            this.Controls.Add(this.GbFilesNotFound);
            this.Name = "CheckForm";
            this.Text = "Проверка";
            this.Resize += new System.EventHandler(this.CheckForm_Resize);
            this.GbFilesNotFound.ResumeLayout(false);
            this.GbFilesNotFound.PerformLayout();
            this.GbLinesNotFound.ResumeLayout(false);
            this.GbLinesNotFound.PerformLayout();
            this.GbScenariosNotFound.ResumeLayout(false);
            this.GbScenariosNotFound.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TbFilesNotFound;
        private System.Windows.Forms.GroupBox GbFilesNotFound;
        private System.Windows.Forms.GroupBox GbLinesNotFound;
        private System.Windows.Forms.TextBox TbLinesNotFound;
        private System.Windows.Forms.GroupBox GbScenariosNotFound;
        private System.Windows.Forms.TextBox TbScenariosNotFound;
        private System.Windows.Forms.Button BtAbort;
        private System.Windows.Forms.Button BtContinue;
    }
}