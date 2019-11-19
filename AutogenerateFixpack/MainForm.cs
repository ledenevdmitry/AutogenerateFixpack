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

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.excelPath))
            {
                if (File.Exists(Properties.Settings.Default.excelPath))
                {
                    FileInfo excelFilePrev = new FileInfo(Properties.Settings.Default.excelPath);
                    DirectoryInfo excelDir = excelFilePrev.Directory;

                    //выбираем последний эксель файл в папке
                    FileInfo newExcelFile = excelDir.EnumerateFiles("*.xls*", SearchOption.TopDirectoryOnly).OrderByDescending(x => x.LastWriteTime).First();

                    TbExcelFile.Text = newExcelFile.FullName;
                }
            }

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.fixpackPath))
            {
                TbFPDir.Text = Properties.Settings.Default.fixpackPath;

                LboxPatches.Items.Clear();
                foreach (DirectoryInfo directoryInfo in new DirectoryInfo(Properties.Settings.Default.fixpackPath).EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    LboxPatches.Items.Add(directoryInfo);
                    LboxPatches.SelectedItem = directoryInfo;
                }
            }

            CbScenario.Checked = Properties.Settings.Default.fileScChecked;
            CbRn.Checked = Properties.Settings.Default.releaseNotesChecked;
            CbExcel.Checked = Properties.Settings.Default.excelFileChecked;
        }

        delegate bool ScenarioGenerator(DirectoryInfo fixpackDirectory, List<DirectoryInfo> selectedPatches, List<DirectoryInfo> beforeInstructionPatches);

        private void GenerateFixpack(ScenarioGenerator Generator)
        {
            LbStatus.Text = "";
            List<DirectoryInfo> beforeInstructionPatches = new List<DirectoryInfo>();
            if (CbRn.Checked)
            {
                if (Directory.Exists(TbFPDir.Text))
                {
                    if (ReleaseNotesUtils.GenerateReleaseNotes(new DirectoryInfo(TbFPDir.Text), LboxPatches.SelectedItems.Cast<DirectoryInfo>().ToList(), out beforeInstructionPatches))
                    {
                        LbStatus.Text += "ReleaseNotes создан" + Environment.NewLine;
                    }
                }
                else
                {
                    MessageBox.Show($"Папка с фикспаком {TbFPDir.Text} не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (CbScenario.Checked)
            {
                Generator(new DirectoryInfo(TbFPDir.Text), LboxPatches.SelectedItems.Cast<DirectoryInfo>().ToList(),
                    //пустой список, если autowait отключен
                    Properties.Settings.Default.autoWait ? beforeInstructionPatches : new List<DirectoryInfo>());
                LbStatus.Text += "Файл сценария создан" + Environment.NewLine;
            }
            if (CbExcel.Checked)
            {
                if (File.Exists(TbExcelFile.Text))
                {
                    ExcelUtils.PrepareExcelFile(new FileInfo(TbExcelFile.Text), new DirectoryInfo(TbFPDir.Text));
                    LbStatus.Text += "Эксель-файл создан" + Environment.NewLine;
                }
                else
                {
                    MessageBox.Show($"Исходный эксель файл {TbExcelFile.Text} не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LbStatus.Text += "Готово!";
        }

        private void BtByFiles_Click(object sender, EventArgs e)
        {
            GenerateFixpack(ScenarioUtils.CreateFPScenarioByFiles);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.fileScChecked = CbScenario.Checked;
            Properties.Settings.Default.releaseNotesChecked = CbRn.Checked;
            Properties.Settings.Default.excelFileChecked = CbExcel.Checked;
            Properties.Settings.Default.Save();

            if (ReleaseNotesUtils.wordApp != null)
                try
                {
                    ReleaseNotesUtils.wordApp.Quit();
                }
                catch { }
            if (ExcelUtils.excApp != null)
                try
                {
                    ExcelUtils.excApp.Quit();
                }
                catch { }
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

            LboxPatches.Items.Clear();
            foreach(DirectoryInfo directoryInfo in new DirectoryInfo(fbd.SelectedPath).EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                LboxPatches.Items.Add(directoryInfo);
                LboxPatches.SelectedItem = directoryInfo;
            }
        }

        private void BtExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Эксель файлы|*.xls*"
            };

            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.excelPath))
            {
                ofd.InitialDirectory = Properties.Settings.Default.excelPath;
            }
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TbExcelFile.Text = ofd.FileName;
            }

            Properties.Settings.Default.excelPath = ofd.FileName;
            Properties.Settings.Default.Save();
        }

        private void BtByScenarios_Click(object sender, EventArgs e)
        {
            GenerateFixpack(ScenarioUtils.CreateFPScenarioByPatchesScenario);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            TbExcelFile.Width = ClientRectangle.Width - TbExcelFile.Left - BtExcelFile.Width - 16;
            TbFPDir.Width     = ClientRectangle.Width - TbFPDir.Left     - BtFPDir.Width     - 16;

            BtExcelFile.Left = ClientRectangle.Width - BtExcelFile.Width - 8;
            BtFPDir.Left     = ClientRectangle.Width - BtFPDir.Width     - 8;

            LboxPatches.Width  = ClientRectangle.Width - LboxPatches.Left - 8;
            LboxPatches.Height = ClientRectangle.Height - LboxPatches.Top - 8;
        }

        private void BtCheckRelease_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (Directory.Exists(TbFPDir.Text))
            {
                fbd.SelectedPath = new DirectoryInfo(TbFPDir.Text).Parent.FullName;
            }

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo releaseDir = new DirectoryInfo(fbd.SelectedPath);

                ScenarioUtils.CheckFilesAndPatchScenario(releaseDir, releaseDir.EnumerateDirectories("*", SearchOption.TopDirectoryOnly).ToList(), out List<string> scenarioNotFound, out List<string> filesNotFound, out List<string> linesNotFound);

                if (scenarioNotFound.Count > 0 || filesNotFound.Count > 0 || linesNotFound.Count > 0)
                {
                    CheckForm cf = new CheckForm(
                        string.Join(Environment.NewLine, scenarioNotFound),
                        string.Join(Environment.NewLine, filesNotFound),
                        string.Join(Environment.NewLine, linesNotFound));

                    DialogResult dr = cf.ShowDialog();
                }
            }
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void CbExcel_CheckedChanged(object sender, EventArgs e)
        {
            LbExcelFile.Visible = TbExcelFile.Visible = BtExcelFile.Visible = CbExcel.Checked;
        }
    }
}
