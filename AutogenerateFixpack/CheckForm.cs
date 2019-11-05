using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutogenerateFixpack
{
    public partial class CheckForm : Form
    {
        public CheckForm(string scenariosNotFound, string filesNotFound, string linesNotFound)
        {
            InitializeComponent();
            TbScenariosNotFound.Text = scenariosNotFound;
            TbFilesNotFound.Text = filesNotFound;
            TbLinesNotFound.Text = linesNotFound;
            DialogResult = DialogResult.Abort;
        }

        private void BtAbort_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void BtContinue_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            DeleteRows = CbDeleteRows.Checked;
            AddRows = CbAddRows.Checked;
        }

        private void CheckForm_Resize(object sender, EventArgs e)
        {
            GbFilesNotFound.Width = ClientRectangle.Width - 2 * 8;
            GbLinesNotFound.Width = ClientRectangle.Width - 2 * 8;
            GbScenariosNotFound.Width = ClientRectangle.Width - 2 * 8;

            GbFilesNotFound.Height = (ClientRectangle.Height - BtAbort.Height - 4 * 8) / 3;
            GbLinesNotFound.Height = (ClientRectangle.Height - BtAbort.Height - 4 * 8) / 3;
            GbScenariosNotFound.Height = (ClientRectangle.Height - BtAbort.Height - 4 * 8) / 3;

            GbLinesNotFound.Top = GbFilesNotFound.Bottom + 8;
            GbScenariosNotFound.Top = GbLinesNotFound.Bottom + 8;

            BtAbort.Top = GbScenariosNotFound.Bottom + 8 / 2;
            BtContinue.Top = GbScenariosNotFound.Bottom + 8 / 2;
        }

        public bool DeleteRows { get; private set; } = false;
        public bool AddRows { get; private set; } = false;
    }
}
