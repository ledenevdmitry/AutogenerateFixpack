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
            this.LbStatus = new System.Windows.Forms.Label();
            this.BtCheckRelease = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtByFiles
            // 
            this.BtByFiles.Location = new System.Drawing.Point(245, 84);
            this.BtByFiles.Name = "BtByFiles";
            this.BtByFiles.Size = new System.Drawing.Size(115, 23);
            this.BtByFiles.TabIndex = 1;
            this.BtByFiles.Text = "Создать по файлам патчей";
            this.BtByFiles.UseVisualStyleBackColor = true;
            this.BtByFiles.Click += new System.EventHandler(this.BtByFiles_Click);
            // 
            // BtByScenarios
            // 
            this.BtByScenarios.Location = new System.Drawing.Point(366, 84);
            this.BtByScenarios.Name = "BtByScenarios";
            this.BtByScenarios.Size = new System.Drawing.Size(137, 23);
            this.BtByScenarios.TabIndex = 2;
            this.BtByScenarios.Text = "Создать по сценариям патчей";
            this.BtByScenarios.UseVisualStyleBackColor = true;
            this.BtByScenarios.Click += new System.EventHandler(this.BtByScenarios_Click);
            // 
            // TbFPDir
            // 
            this.TbFPDir.Location = new System.Drawing.Point(128, 29);
            this.TbFPDir.Name = "TbFPDir";
            this.TbFPDir.Size = new System.Drawing.Size(294, 20);
            this.TbFPDir.TabIndex = 3;
            // 
            // BtFPDir
            // 
            this.BtFPDir.Location = new System.Drawing.Point(428, 29);
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
            this.LbFPDir.Location = new System.Drawing.Point(12, 29);
            this.LbFPDir.Name = "LbFPDir";
            this.LbFPDir.Size = new System.Drawing.Size(70, 13);
            this.LbFPDir.TabIndex = 5;
            this.LbFPDir.Text = "Папка с ФП";
            // 
            // LbExcelFile
            // 
            this.LbExcelFile.AutoSize = true;
            this.LbExcelFile.Location = new System.Drawing.Point(12, 58);
            this.LbExcelFile.Name = "LbExcelFile";
            this.LbExcelFile.Size = new System.Drawing.Size(107, 13);
            this.LbExcelFile.TabIndex = 8;
            this.LbExcelFile.Text = "Исходная экселька";
            // 
            // BtExcelFile
            // 
            this.BtExcelFile.Location = new System.Drawing.Point(428, 58);
            this.BtExcelFile.Name = "BtExcelFile";
            this.BtExcelFile.Size = new System.Drawing.Size(75, 23);
            this.BtExcelFile.TabIndex = 7;
            this.BtExcelFile.Text = "Задать";
            this.BtExcelFile.UseVisualStyleBackColor = true;
            this.BtExcelFile.Click += new System.EventHandler(this.BtExcelFile_Click);
            // 
            // TbExcelFile
            // 
            this.TbExcelFile.Location = new System.Drawing.Point(128, 58);
            this.TbExcelFile.Name = "TbExcelFile";
            this.TbExcelFile.Size = new System.Drawing.Size(294, 20);
            this.TbExcelFile.TabIndex = 6;
            // 
            // LboxPatches
            // 
            this.LboxPatches.FormattingEnabled = true;
            this.LboxPatches.Location = new System.Drawing.Point(149, 144);
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
            this.CbScenario.Location = new System.Drawing.Point(15, 119);
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
            this.CbRn.Location = new System.Drawing.Point(15, 142);
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
            this.CbExcel.Location = new System.Drawing.Point(15, 165);
            this.CbExcel.Name = "CbExcel";
            this.CbExcel.Size = new System.Drawing.Size(75, 17);
            this.CbExcel.TabIndex = 12;
            this.CbExcel.Text = "Экселька";
            this.CbExcel.UseVisualStyleBackColor = true;
            this.CbExcel.CheckedChanged += new System.EventHandler(this.CbExcel_CheckedChanged);
            // 
            // LbPatches
            // 
            this.LbPatches.AutoSize = true;
            this.LbPatches.Location = new System.Drawing.Point(146, 119);
            this.LbPatches.Name = "LbPatches";
            this.LbPatches.Size = new System.Drawing.Size(159, 13);
            this.LbPatches.TabIndex = 13;
            this.LbPatches.Text = "Участвующие в сборке патчи:";
            // 
            // LbStatus
            // 
            this.LbStatus.AutoSize = true;
            this.LbStatus.Location = new System.Drawing.Point(12, 185);
            this.LbStatus.Name = "LbStatus";
            this.LbStatus.Size = new System.Drawing.Size(0, 13);
            this.LbStatus.TabIndex = 14;
            // 
            // BtCheckRelease
            // 
            this.BtCheckRelease.Location = new System.Drawing.Point(132, 84);
            this.BtCheckRelease.Name = "BtCheckRelease";
            this.BtCheckRelease.Size = new System.Drawing.Size(107, 23);
            this.BtCheckRelease.TabIndex = 15;
            this.BtCheckRelease.Text = "Сверить релиз";
            this.BtCheckRelease.UseVisualStyleBackColor = true;
            this.BtCheckRelease.Click += new System.EventHandler(this.BtCheckRelease_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.SettingsToolStripMenuItem.Text = "Настройки";
            this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Создать статус";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 264);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtCheckRelease);
            this.Controls.Add(this.LbStatus);
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
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Создание фикспака";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private System.Windows.Forms.Label LbStatus;
        private System.Windows.Forms.Button BtCheckRelease;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

