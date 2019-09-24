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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtOpenFixpackFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if(!string.IsNullOrWhiteSpace(Properties.Settings.Default.fixpackPath))
            {
                fbd.SelectedPath = Properties.Settings.Default.fixpackPath;
            }

            if(fbd.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo fixpackDirectory = new DirectoryInfo(fbd.SelectedPath);

                ReleaseNotesUtils.GenerateReleaseNotes(fixpackDirectory);
            }

            Properties.Settings.Default.fixpackPath = fbd.SelectedPath;
            Properties.Settings.Default.Save();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReleaseNotesUtils.wordApp.Quit();
        }
    }
}
