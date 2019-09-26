﻿using System;
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
            TbExcelFile.Text = Properties.Settings.Default.excelPath;

            foreach (DirectoryInfo directoryInfo in new DirectoryInfo(Properties.Settings.Default.fixpackPath).EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                LboxPatches.Items.Add(directoryInfo);
                LboxPatches.SelectedItem = directoryInfo;
            }
        }

        delegate void ScenarioGenerator(DirectoryInfo fixpackDirectory, List<DirectoryInfo> selectedPatches);

        private void GenerateFixpack(ScenarioGenerator generator)
        {
            if (CbScenario.Checked)
            {
                generator(new DirectoryInfo(TbFPDir.Text), LboxPatches.SelectedItems.Cast<DirectoryInfo>().ToList());
            }
            if (CbRn.Checked)
            {
                if (Directory.Exists(TbFPDir.Text))
                {
                    ReleaseNotesUtils.GenerateReleaseNotes(new DirectoryInfo(TbFPDir.Text));
                }
                else
                {
                    MessageBox.Show($"Папка с фикспаком {TbFPDir.Text} не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (CbExcel.Checked)
            {
                if (File.Exists(TbExcelFile.Text))
                {
                    ExcelUtils.PrepareExcelFile(new FileInfo(TbExcelFile.Text));
                }
                else
                {
                    MessageBox.Show($"Исходный эксель файл {TbExcelFile.Text} не найден!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtByFiles_Click(object sender, EventArgs e)
        {
            GenerateFixpack(ScenarioUtils.CreateFPScenarioByFiles);
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

            foreach(DirectoryInfo directoryInfo in new DirectoryInfo(fbd.SelectedPath).EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                LboxPatches.Items.Add(directoryInfo);
                LboxPatches.SelectedItem = directoryInfo;
            }
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
        }
    }
}