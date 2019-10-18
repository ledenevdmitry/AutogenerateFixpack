namespace AutogenerateFixpack
{
    partial class SettingsForm
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
            this.CbAddWaits = new System.Windows.Forms.CheckBox();
            this.BtSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CbAddWaits
            // 
            this.CbAddWaits.AutoSize = true;
            this.CbAddWaits.Location = new System.Drawing.Point(12, 12);
            this.CbAddWaits.Name = "CbAddWaits";
            this.CbAddWaits.Size = new System.Drawing.Size(284, 17);
            this.CbAddWaits.TabIndex = 0;
            this.CbAddWaits.Text = "Автоматически добавлять WAIT|| в файл сценария";
            this.CbAddWaits.UseVisualStyleBackColor = true;
            // 
            // BtSubmit
            // 
            this.BtSubmit.Location = new System.Drawing.Point(12, 35);
            this.BtSubmit.Name = "BtSubmit";
            this.BtSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtSubmit.TabIndex = 1;
            this.BtSubmit.Text = "Применить";
            this.BtSubmit.UseVisualStyleBackColor = true;
            this.BtSubmit.Click += new System.EventHandler(this.BtSubmit_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 74);
            this.Controls.Add(this.BtSubmit);
            this.Controls.Add(this.CbAddWaits);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CbAddWaits;
        private System.Windows.Forms.Button BtSubmit;
    }
}