using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Security;

namespace Configurations {
    public class Config {
        private Dictionary<string, string> _configSettings =
            new Dictionary<string, string>();

        private Configuration _config;
        private AppSettingsSection _settings;

        public void ReadConfigFile() {
            foreach(var _setting in _settings.Settings.AllKeys) {
                string _settingName = _setting.ToString();
                _configSettings.Add(
                    _settingName,
                    _settings.Settings[_settingName].Value
                );
            }

            _VerrifyConfig();

        }

        private bool _VerrifyConfig() {
            if(_configSettings.TryGetValue("UIN", out string _testResult)) {
                if(Int32.TryParse(_VerrifyValue(_testResult), out int intUIN)) {
                    if(_configSettings.TryGetValue("ManagerURL", out _testResult)) {

                        if(_configSettings.TryGetValue("SecondaryManagerURL", out _testResult)) {
                            if(_configSettings.TryGetValue("HubSwitcher", out _testResult)) {
                            } else {
                                _configSettings.Add("HubSwitcher", "Current");
                            }
                        } else {
                            _configSettings.Add("SecondaryManagerURL", _configSettings["ManagerURL"]);
                        }
                    }
                }
            }
            return true;
        }

        public void WriteConfigFile() {
            Encrypt _encObj = new Encrypt();

            //if(_settings != null) {
            //    _settings.Settings["UIN"].Value = _encObj.EncryptValue(_UIN);
            //    _settings.Settings["ManagerURL"].Value = _encObj.EncryptValue(_ManagerURL);
            //    _settings.Settings["SecondaryManagerURL"].Value = _encObj.EncryptValue(_SecondaryManagerURL);
            //    _settings.Settings["HubSwitcher"].Value = _encObj.EncryptValue(_HubSwitcherDescription);
            //}

            _config.Save(ConfigurationSaveMode.Modified);
        }

        public string GetValue(string KeyName) {
            string _value = "";
            Encrypt _encObj = new Encrypt();

            if(_configSettings.TryGetValue(KeyName, out _value)) {
                if(_value.StartsWith("~") && _value.Length > 1) {
                    _value = _encObj.DecryptValue(_value);
                }
            } else {
                _value = "ERROR: Unable to find " + KeyName;
            }

            return _value;

        }

        public Dictionary<string, string> GetSettings() {
            return _configSettings;
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
            //  Constructor
            _config = ConfigurationManager.OpenExeConfiguration(AdminPath);
            _settings = (AppSettingsSection)_config.GetSection("appSettings");

            ReadConfigFile();

        }
    }
}

