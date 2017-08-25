using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Configurations;


namespace HubSwitcher {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void btnLaunch_Click(object sender, EventArgs e) {

        }

        private void btnEdit_Click(object sender, EventArgs e) {
            tbURL.Text = "WWW.IMAGEPOINTHOSTED.COM";
            tbUIN.Text = "1";

        }

        private void btnCurrent_Click(object sender, EventArgs e) {
            Config _AdminConfig = new Config();
            _AdminConfig.ReadConfigFile();
        }
    }
}
