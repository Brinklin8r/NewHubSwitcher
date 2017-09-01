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

            _AdminConfig.ReadConfigFile();
            updateWindow();

        }
        static string _AdminPath = @"C:\Program Files (x86)\Bluepoint Solutions\RDC\IP Admin\IP Admin.exe";
        Config _AdminConfig = new Config(_AdminPath);


        private void btnLaunch_Click(object sender, EventArgs e) {
            _AdminConfig.WriteConfigFile();
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            tbURL.Text = "WWW.IMAGEPOINTHOSTED.COM";
            tbUIN.Text = "1";
            cbSystemDropDown.Text = "New";

        }

        private void btnCurrent_Click(object sender, EventArgs e) {
            _AdminConfig.ReadConfigFile();
            updateWindow();
        }

        private void updateWindow() {
            tbUIN.Text = _AdminConfig.GetUIN();
            tbURL.Text = _AdminConfig.GetManagerURL();
            cbSystemDropDown.Text = _AdminConfig.GetDescription();
        }
    }
}
