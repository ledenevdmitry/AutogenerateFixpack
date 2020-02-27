namespace AutogenerateFixpack
{
    partial class StatusForm
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
            this.LbATCJira = new System.Windows.Forms.Label();
            this.LbBankJira = new System.Windows.Forms.Label();
            this.TbBankJira = new System.Windows.Forms.TextBox();
            this.TbATCJira = new System.Windows.Forms.TextBox();
            this.TbCR = new System.Windows.Forms.TextBox();
            this.LbCR = new System.Windows.Forms.Label();
            this.BtATCJira = new System.Windows.Forms.Button();
            this.BtBankJira = new System.Windows.Forms.Button();
            this.BtCR = new System.Windows.Forms.Button();
            this.BtMakeStatus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LbATCJira
            // 
            this.LbATCJira.AutoSize = true;
            this.LbATCJira.Location = new System.Drawing.Point(12, 9);
            this.LbATCJira.Name = "LbATCJira";
            this.LbATCJira.Size = new System.Drawing.Size(125, 13);
            this.LbATCJira.TabIndex = 0;
            this.LbATCJira.Text = "Выгрузка из нашей Jira";
            // 
            // LbBankJira
            // 
            this.LbBankJira.AutoSize = true;
            this.LbBankJira.Location = new System.Drawing.Point(12, 32);
            this.LbBankJira.Name = "LbBankJira";
            this.LbBankJira.Size = new System.Drawing.Size(154, 13);
            this.LbBankJira.TabIndex = 1;
            this.LbBankJira.Text = "Выгрузка из Банковской Jira";
            // 
            // TbBankJira
            // 
            this.TbBankJira.Location = new System.Drawing.Point(172, 32);
            this.TbBankJira.Name = "TbBankJira";
            this.TbBankJira.Size = new System.Drawing.Size(231, 20);
            this.TbBankJira.TabIndex = 2;
            // 
            // TbATCJira
            // 
            this.TbATCJira.Location = new System.Drawing.Point(172, 9);
            this.TbATCJira.Name = "TbATCJira";
            this.TbATCJira.Size = new System.Drawing.Size(231, 20);
            this.TbATCJira.TabIndex = 3;
            // 
            // TbCR
            // 
            this.TbCR.Location = new System.Drawing.Point(172, 55);
            this.TbCR.Name = "TbCR";
            this.TbCR.Size = new System.Drawing.Size(231, 20);
            this.TbCR.TabIndex = 5;
            // 
            // LbCR
            // 
            this.LbCR.AutoSize = true;
            this.LbCR.Location = new System.Drawing.Point(12, 55);
            this.LbCR.Name = "LbCR";
            this.LbCR.Size = new System.Drawing.Size(121, 13);
            this.LbCR.TabIndex = 4;
            this.LbCR.Text = "Выгрузка номеров CR";
            // 
            // BtATCJira
            // 
            this.BtATCJira.Location = new System.Drawing.Point(409, 9);
            this.BtATCJira.Name = "BtATCJira";
            this.BtATCJira.Size = new System.Drawing.Size(75, 23);
            this.BtATCJira.TabIndex = 6;
            this.BtATCJira.Text = "Выбрать";
            this.BtATCJira.UseVisualStyleBackColor = true;
            // 
            // BtBankJira
            // 
            this.BtBankJira.Location = new System.Drawing.Point(409, 32);
            this.BtBankJira.Name = "BtBankJira";
            this.BtBankJira.Size = new System.Drawing.Size(75, 23);
            this.BtBankJira.TabIndex = 7;
            this.BtBankJira.Text = "Выбрать";
            this.BtBankJira.UseVisualStyleBackColor = true;
            // 
            // BtCR
            // 
            this.BtCR.Location = new System.Drawing.Point(409, 55);
            this.BtCR.Name = "BtCR";
            this.BtCR.Size = new System.Drawing.Size(75, 23);
            this.BtCR.TabIndex = 8;
            this.BtCR.Text = "Выбрать";
            this.BtCR.UseVisualStyleBackColor = true;
            // 
            // BtMakeStatus
            // 
            this.BtMakeStatus.Location = new System.Drawing.Point(15, 89);
            this.BtMakeStatus.Name = "BtMakeStatus";
            this.BtMakeStatus.Size = new System.Drawing.Size(469, 41);
            this.BtMakeStatus.TabIndex = 9;
            this.BtMakeStatus.Text = "Собрать статус";
            this.BtMakeStatus.UseVisualStyleBackColor = true;
            this.BtMakeStatus.Click += new System.EventHandler(this.BtMakeStatus_Click);
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 140);
            this.Controls.Add(this.BtMakeStatus);
            this.Controls.Add(this.BtCR);
            this.Controls.Add(this.BtBankJira);
            this.Controls.Add(this.BtATCJira);
            this.Controls.Add(this.TbCR);
            this.Controls.Add(this.LbCR);
            this.Controls.Add(this.TbATCJira);
            this.Controls.Add(this.TbBankJira);
            this.Controls.Add(this.LbBankJira);
            this.Controls.Add(this.LbATCJira);
            this.Name = "StatusForm";
            this.Text = "StatusForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LbATCJira;
        private System.Windows.Forms.Label LbBankJira;
        private System.Windows.Forms.TextBox TbBankJira;
        private System.Windows.Forms.TextBox TbATCJira;
        private System.Windows.Forms.TextBox TbCR;
        private System.Windows.Forms.Label LbCR;
        private System.Windows.Forms.Button BtATCJira;
        private System.Windows.Forms.Button BtBankJira;
        private System.Windows.Forms.Button BtCR;
        private System.Windows.Forms.Button BtMakeStatus;
    }
}