namespace AutogenerateFixpack
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LbScenario = new System.Windows.Forms.ListBox();
            this.BtOpenFixpackFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbScenario
            // 
            this.LbScenario.FormattingEnabled = true;
            this.LbScenario.Location = new System.Drawing.Point(12, 58);
            this.LbScenario.Name = "LbScenario";
            this.LbScenario.Size = new System.Drawing.Size(208, 225);
            this.LbScenario.TabIndex = 0;
            // 
            // BtOpenFixpackFolder
            // 
            this.BtOpenFixpackFolder.Location = new System.Drawing.Point(12, 12);
            this.BtOpenFixpackFolder.Name = "BtOpenFixpackFolder";
            this.BtOpenFixpackFolder.Size = new System.Drawing.Size(130, 23);
            this.BtOpenFixpackFolder.TabIndex = 1;
            this.BtOpenFixpackFolder.Text = "Открыть фикспак";
            this.BtOpenFixpackFolder.UseVisualStyleBackColor = true;
            this.BtOpenFixpackFolder.Click += new System.EventHandler(this.BtOpenFixpackFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 295);
            this.Controls.Add(this.BtOpenFixpackFolder);
            this.Controls.Add(this.LbScenario);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbScenario;
        private System.Windows.Forms.Button BtOpenFixpackFolder;
    }
}

