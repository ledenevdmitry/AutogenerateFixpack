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
            this.LboxPatches = new System.Windows.Forms.ListBox();
            this.CbScenario = new System.Windows.Forms.CheckBox();
            this.CbRn = new System.Windows.Forms.CheckBox();
            this.CbExcel = new System.Windows.Forms.CheckBox();
            this.LbPatches = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.BtCheckRelease = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtByFiles
            // 
            this.BtByFiles.Location = new System.Drawing.Point(206, 67);
            this.BtByFiles.Name = "BtByFiles";
            this.BtByFiles.Size = new System.Drawing.Size(134, 23);
            this.BtByFiles.TabIndex = 1;
            this.BtByFiles.Text = "Создать по файлам патчей";
            this.BtByFiles.UseVisualStyleBackColor = true;
            this.BtByFiles.Click += new System.EventHandler(this.BtByFiles_Click);
            // 
            // BtByScenarios
            // 
            this.BtByScenarios.Location = new System.Drawing.Point(346, 67);
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
            this.TbFPDir.Size = new System.Drawing.Size(294, 20);
            this.TbFPDir.TabIndex = 3;
            // 
            // BtFPDir
            // 
            this.BtFPDir.Location = new System.Drawing.Point(428, 12);
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
            this.BtExcelFile.Location = new System.Drawing.Point(428, 41);
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
            this.TbExcelFile.Size = new System.Drawing.Size(294, 20);
            this.TbExcelFile.TabIndex = 6;
            // 
            // LboxPatches
            // 
            this.LboxPatches.FormattingEnabled = true;
            this.LboxPatches.Location = new System.Drawing.Point(149, 127);
            this.LboxPatches.Name = "LboxPatches";
            this.LboxPatches.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LboxPatches.Size = new System.Drawing.Size(342, 108);
            this.LboxPatches.TabIndex = 9;
            // 
            // CbScenario
            // 
            this.CbScenario.AutoSize = true;
            this.CbScenario.Checked = true;
            this.CbScenario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbScenario.Location = new System.Drawing.Point(15, 102);
            this.CbScenario.Name = "CbScenario";
            this.CbScenario.Size = new System.Drawing.Size(106, 17);
            this.CbScenario.TabIndex = 10;
            this.CbScenario.Text = "Файл сценария";
            this.CbScenario.UseVisualStyleBackColor = true;
            // 
            // CbRn
            // 
            this.CbRn.AutoSize = true;
            this.CbRn.Checked = true;
            this.CbRn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbRn.Location = new System.Drawing.Point(15, 125);
            this.CbRn.Name = "CbRn";
            this.CbRn.Size = new System.Drawing.Size(93, 17);
            this.CbRn.TabIndex = 11;
            this.CbRn.Text = "ReleaseNotes";
            this.CbRn.UseVisualStyleBackColor = true;
            // 
            // CbExcel
            // 
            this.CbExcel.AutoSize = true;
            this.CbExcel.Checked = true;
            this.CbExcel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbExcel.Location = new System.Drawing.Point(15, 148);
            this.CbExcel.Name = "CbExcel";
            this.CbExcel.Size = new System.Drawing.Size(75, 17);
            this.CbExcel.TabIndex = 12;
            this.CbExcel.Text = "Экселька";
            this.CbExcel.UseVisualStyleBackColor = true;
            // 
            // LbPatches
            // 
            this.LbPatches.AutoSize = true;
            this.LbPatches.Location = new System.Drawing.Point(146, 102);
            this.LbPatches.Name = "LbPatches";
            this.LbPatches.Size = new System.Drawing.Size(159, 13);
            this.LbPatches.TabIndex = 13;
            this.LbPatches.Text = "Участвующие в сборке патчи:";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(12, 168);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 13);
            this.lbStatus.TabIndex = 14;
            // 
            // BtCheckRelease
            // 
            this.BtCheckRelease.Location = new System.Drawing.Point(90, 67);
            this.BtCheckRelease.Name = "BtCheckRelease";
            this.BtCheckRelease.Size = new System.Drawing.Size(110, 23);
            this.BtCheckRelease.TabIndex = 15;
            this.BtCheckRelease.Text = "Сверить релиз";
            this.BtCheckRelease.UseVisualStyleBackColor = true;
            this.BtCheckRelease.Click += new System.EventHandler(this.BtCheckRelease_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 247);
            this.Controls.Add(this.BtCheckRelease);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.LbPatches);
            this.Controls.Add(this.CbExcel);
            this.Controls.Add(this.CbRn);
            this.Controls.Add(this.CbScenario);
            this.Controls.Add(this.LboxPatches);
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
            this.Resize += new System.EventHandler(this.MainForm_Resize);
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
        private System.Windows.Forms.ListBox LboxPatches;
        private System.Windows.Forms.CheckBox CbScenario;
        private System.Windows.Forms.CheckBox CbRn;
        private System.Windows.Forms.CheckBox CbExcel;
        private System.Windows.Forms.Label LbPatches;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button BtCheckRelease;
    }
}

