namespace AutogenerateFixpack
{
    partial class MainForm
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
            this.BtByFiles = new System.Windows.Forms.Button();
            this.BtByScenarios = new System.Windows.Forms.Button();
            this.TbFPDir = new System.Windows.Forms.TextBox();
            this.BtFPDir = new System.Windows.Forms.Button();
            this.LbFPDir = new System.Windows.Forms.Label();
            this.LbExcelFile = new System.Windows.Forms.Label();
            this.BtExcelFile = new System.Windows.Forms.Button();
            this.TbExcelFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtByFiles
            // 
            this.BtByFiles.Location = new System.Drawing.Point(12, 67);
            this.BtByFiles.Name = "BtByFiles";
            this.BtByFiles.Size = new System.Drawing.Size(134, 23);
            this.BtByFiles.TabIndex = 1;
            this.BtByFiles.Text = "Создать по файлам патчей";
            this.BtByFiles.UseVisualStyleBackColor = true;
            this.BtByFiles.Click += new System.EventHandler(this.BtByFiles_Click);
            // 
            // BtByScenarios
            // 
            this.BtByScenarios.Location = new System.Drawing.Point(152, 67);
            this.BtByScenarios.Name = "BtByScenarios";
            this.BtByScenarios.Size = new System.Drawing.Size(157, 23);
            this.BtByScenarios.TabIndex = 2;
            this.BtByScenarios.Text = "Создать по сценариям патчей";
            this.BtByScenarios.UseVisualStyleBackColor = true;
            this.BtByScenarios.Click += new System.EventHandler(this.BtByScenarios_Click);
            // 
            // TbFPDir
            // 
            this.TbFPDir.Location = new System.Drawing.Point(128, 12);
            this.TbFPDir.Name = "TbFPDir";
            this.TbFPDir.Size = new System.Drawing.Size(100, 20);
            this.TbFPDir.TabIndex = 3;
            // 
            // BtFPDir
            // 
            this.BtFPDir.Location = new System.Drawing.Point(234, 12);
            this.BtFPDir.Name = "BtFPDir";
            this.BtFPDir.Size = new System.Drawing.Size(75, 23);
            this.BtFPDir.TabIndex = 4;
            this.BtFPDir.Text = "Задать";
            this.BtFPDir.UseVisualStyleBackColor = true;
            this.BtFPDir.Click += new System.EventHandler(this.BtFPDir_Click);
            // 
            // LbFPDir
            // 
            this.LbFPDir.AutoSize = true;
            this.LbFPDir.Location = new System.Drawing.Point(12, 12);
            this.LbFPDir.Name = "LbFPDir";
            this.LbFPDir.Size = new System.Drawing.Size(70, 13);
            this.LbFPDir.TabIndex = 5;
            this.LbFPDir.Text = "Папка с ФП";
            // 
            // LbExcelFile
            // 
            this.LbExcelFile.AutoSize = true;
            this.LbExcelFile.Location = new System.Drawing.Point(12, 41);
            this.LbExcelFile.Name = "LbExcelFile";
            this.LbExcelFile.Size = new System.Drawing.Size(107, 13);
            this.LbExcelFile.TabIndex = 8;
            this.LbExcelFile.Text = "Исходная экселька";
            // 
            // BtExcelFile
            // 
            this.BtExcelFile.Location = new System.Drawing.Point(234, 41);
            this.BtExcelFile.Name = "BtExcelFile";
            this.BtExcelFile.Size = new System.Drawing.Size(75, 23);
            this.BtExcelFile.TabIndex = 7;
            this.BtExcelFile.Text = "Задать";
            this.BtExcelFile.UseVisualStyleBackColor = true;
            this.BtExcelFile.Click += new System.EventHandler(this.BtExcelFile_Click);
            // 
            // TbExcelFile
            // 
            this.TbExcelFile.Location = new System.Drawing.Point(128, 41);
            this.TbExcelFile.Name = "TbExcelFile";
            this.TbExcelFile.Size = new System.Drawing.Size(100, 20);
            this.TbExcelFile.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 101);
            this.Controls.Add(this.LbExcelFile);
            this.Controls.Add(this.BtExcelFile);
            this.Controls.Add(this.TbExcelFile);
            this.Controls.Add(this.LbFPDir);
            this.Controls.Add(this.BtFPDir);
            this.Controls.Add(this.TbFPDir);
            this.Controls.Add(this.BtByScenarios);
            this.Controls.Add(this.BtByFiles);
            this.Name = "MainForm";
            this.Text = "Создание фикспака";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtByFiles;
        private System.Windows.Forms.Button BtByScenarios;
        private System.Windows.Forms.TextBox TbFPDir;
        private System.Windows.Forms.Button BtFPDir;
        private System.Windows.Forms.Label LbFPDir;
        private System.Windows.Forms.Label LbExcelFile;
        private System.Windows.Forms.Button BtExcelFile;
        private System.Windows.Forms.TextBox TbExcelFile;
    }
}

