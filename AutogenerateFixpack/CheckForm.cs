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
        }
    }
}
