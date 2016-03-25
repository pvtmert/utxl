using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTXL
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();

            if (Properties.Settings.Default.dark_mode)
                themeListBox.SelectedIndex = 1;
            else
                themeListBox.SelectedIndex = 0;


        }

        private void themeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (themeListBox.SelectedIndex == 0)
                Properties.Settings.Default.dark_mode = false;
            else
                Properties.Settings.Default.dark_mode = true;
        }
    }
}
