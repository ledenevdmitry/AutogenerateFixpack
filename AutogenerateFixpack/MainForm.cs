using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutogenerateFixpack
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TbFPDir.Text = Properties.Settings.Default.fixpackPath;
        }

        private void BtByFiles_Click(object sender, EventArgs e)
        {
            ExcelUtils.PrepareExcelFile(new FileInfo(TbExcelFile.Text));
            ReleaseNotesUtils.GenerateReleaseNotes(new DirectoryInfo(TbFPDir.Text));
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ReleaseNotesUtils.wordApp != null)
                ReleaseNotesUtils.wordApp.Quit();
            if(ExcelUtils.excApp != null)
                ExcelUtils.excApp.Quit();
        }

        private void BtFPDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.fixpackPath))
            {
                fbd.SelectedPath = Properties.Settings.Default.fixpackPath;
            }

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                TbFPDir.Text = fbd.SelectedPath;
            }

            Properties.Settings.Default.fixpackPath = fbd.SelectedPath;
            Properties.Settings.Default.Save();
        }

        private void BtExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.excelPath))
            {
                ofd.InitialDirectory = Properties.Settings.Default.excelPath;
            }

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TbExcelFile.Text = ofd.FileName;
            }

            Properties.Settings.Default.excelPath = new FileInfo(ofd.FileName).Directory.FullName;
            Properties.Settings.Default.Save();
        }

        private void BtByScenarios_Click(object sender, EventArgs e)
        {
            ScenarioUtils.CreateFPScenarioByPatchesScenario(new DirectoryInfo(TbFPDir.Text));
            ExcelUtils.PrepareExcelFile(new FileInfo(TbExcelFile.Text));
            ReleaseNotesUtils.GenerateReleaseNotes(new DirectoryInfo(TbFPDir.Text));
            Properties.Settings.Default.Save();
        }
    }
}
