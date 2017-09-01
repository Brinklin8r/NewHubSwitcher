using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Security;

namespace Configurations {
    public class Config {
        private string _UIN;
        private string _ManagerURL;
        private string _SecondaryManagerURL;
        private string _HubSwitcherDescription;                                               
        private Configuration _config;

        public void ReadConfigFile() {
            AppSettingsSection _settings = (AppSettingsSection)_config.GetSection("appSettings");

            if(_settings != null) {
                _UIN = _VerrifyValue(_settings.Settings["UIN"].Value);
                _ManagerURL = _VerrifyValue(_settings.Settings["ManagerURL"].Value);

                // Optional Config entries:
                // If they do not exist in the Config File create them and then
                // default to something
                try {
                    _SecondaryManagerURL = _VerrifyValue(_settings.Settings["SecondaryManagerURL"].Value);
                } catch(Exception) {
                    _config.AppSettings.Settings.Add("SecondaryManagerURL", _ManagerURL);
                    _SecondaryManagerURL = _ManagerURL;
                }
                try {
                    _HubSwitcherDescription = _VerrifyValue(_settings.Settings["HubSwitcher"].Value);
                } catch(Exception) {
                    _config.AppSettings.Settings.Add("HubSwitcher", "");
                    _HubSwitcherDescription = "Current";
                }
            }
        }

        public void WriteConfigFile() {
            AppSettingsSection _settings = (AppSettingsSection)_config.GetSection("appSettings");
            Encrypt _encObj = new Encrypt();

            if(_settings != null) {
                _settings.Settings["UIN"].Value = _encObj.EncryptValue(_UIN);
                _settings.Settings["ManagerURL"].Value = _encObj.EncryptValue(_ManagerURL);
                _settings.Settings["SecondaryManagerURL"].Value = _encObj.EncryptValue(_SecondaryManagerURL);
                _settings.Settings["HubSwitcher"].Value = _encObj.EncryptValue(_HubSwitcherDescription);
            }

            _config.Save(ConfigurationSaveMode.Modified);
        }

        public string GetUIN() {
            return _UIN;
        }

        public string GetManagerURL() {
            return _ManagerURL;
        }

        public string GetDescription() {
            return _HubSwitcherDescription;
        }

        private string _VerrifyValue(string _fValue) {
            string _fResult = "";
            StringBuilder _fstringBuilder = new StringBuilder();
            Encrypt _encObj = new Encrypt();

            if(_fValue.StartsWith("~") && _fValue.Length > 1) {
                _fstringBuilder.Append(_encObj.DecryptValue(_fValue));
                _fstringBuilder.Replace("tcp://", "");
                _fstringBuilder.Replace(":50669/MerchantCaptureCommObj.rem", "");
                _fResult = _fstringBuilder.ToString();
            }

            return _fResult;
        }

        private string buildTCPString(string ManagerURL) {
            return "tcp://" + ManagerURL + ":50669/MerchantCaptureCommObj.rem";
        }

        public Config(string AdminPath) {
            _UIN = "";
            _ManagerURL = "";
            _SecondaryManagerURL = "";
            _HubSwitcherDescription = "";

            _config = ConfigurationManager.OpenExeConfiguration(AdminPath);
        }
    }
}

