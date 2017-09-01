using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Security;

namespace Configurations {
    public class Config {
        private string _UIN = "";
        private string _ManagerURL = "";
        private string _SecondaryManagerURL = "";
        private string _HubSwitcherDescription = "";

        private Encrypt _encObj = new Encrypt();
        private Configuration _config = ConfigurationManager.OpenExeConfiguration(@"C:\Program Files (x86)\Bluepoint Solutions\RDC\IP Admin\IP Admin.exe");


        public void ReadConfigFile() {
            AppSettingsSection _settings = (AppSettingsSection)_config.GetSection("appSettings");
            if(_settings != null) {
                _UIN = _VerrifyValue(_settings.Settings["UIN"].Value);
                _ManagerURL = _VerrifyValue(_settings.Settings["ManagerURL"].Value);

                // Optional Config entries:
                // If they do not exist in the Config File default to something
                try {
                    _SecondaryManagerURL = _VerrifyValue(_settings.Settings["SecondaryManagerURL"].Value);
                } catch(Exception) {
                    _SecondaryManagerURL = _ManagerURL;
                }
                try {
                    _HubSwitcherDescription = _VerrifyValue(_settings.Settings["HubSwitcher"].Value);
                } catch(Exception) {
                    _HubSwitcherDescription = "Current";
                }

            }

        }

        public void WriteConfigFile() {
            AppSettingsSection _settings = (AppSettingsSection)_config.GetSection("appSettings");
            if(_settings != null) {
                _settings.Settings["UIN"].Value = _UIN;
                _settings.Settings["ManagerURL"].Value = _ManagerURL;
                _settings.Settings["SecondaryManagerURL"].Value = _SecondaryManagerURL;
                _settings.Settings["HubSwitcher"].Value = _HubSwitcherDescription;
            }

            _config.Save(ConfigurationSaveMode.Modified);
        }

        private string _VerrifyValue(string _fValue) {
            string _fResult = "";

            if(_fValue.StartsWith("~") && _fValue.Length > 1) {
                _fResult = _encObj.DecryptValue(_fValue);

            }



         
            return _fResult;
        }
    }
}
