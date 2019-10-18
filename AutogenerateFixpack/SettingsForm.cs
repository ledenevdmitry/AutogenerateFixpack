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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            CbAddWaits.Checked = Properties.Settings.Default.autoWait;
        }

        private void BtSubmit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.autoWait = CbAddWaits.Checked;
            Properties.Settings.Default.Save();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
