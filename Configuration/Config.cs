using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Security;

namespace Configurations {
    public class Config {
        private Dictionary<ConfSet , string> _configSettings =
            new Dictionary<ConfSet , string>();

        private Configuration _config;
        private AppSettingsSection _settings;

        enum ConfSet {
            UIN,
            ManagerURL,
            SecondaryManagerURL,
            HubSwitcher
        }

        private void _BuildDict() {
            foreach( var _setting in _settings.Settings.AllKeys ) {
                string _settingName = _setting.ToString();

                switch( _settingName ) {
                    case nameof( ConfSet.UIN ): {
                            _configSettings.Add(
                                ConfSet.UIN ,
                                _settings.Settings[_settingName].Value
                            );
                            break;
                        }
                    case nameof( ConfSet.ManagerURL ): {
                            _configSettings.Add(
                                ConfSet.ManagerURL ,
                                _settings.Settings[_settingName].Value
                            );
                            break;
                        }
                    case nameof( ConfSet.SecondaryManagerURL ): {
                            _configSettings.Add(
                                ConfSet.SecondaryManagerURL ,
                                _settings.Settings[_settingName].Value
                            );
                            break;
                        }
                    case nameof( ConfSet.HubSwitcher ): {
                            _configSettings.Add(
                                ConfSet.HubSwitcher ,
                                _settings.Settings[_settingName].Value
                            );
                            break;
                        }
                    default:
                        break;
                }
            }
            bool _tempBool = VerrifyConfig();
        }

        public bool VerrifyConfig() {
            if( _configSettings.ContainsKey( ConfSet.UIN ) ) {
                _configSettings[ConfSet.UIN] = _VerrifyValue( _configSettings[ConfSet.UIN] );
                if( _configSettings.ContainsKey( ConfSet.ManagerURL ) ) {
                    _configSettings[ConfSet.ManagerURL] = _VerrifyValue( _configSettings[ConfSet.ManagerURL] );
                } else {
                    if( _configSettings.ContainsKey( ConfSet.SecondaryManagerURL ) ) {
                        // Set ManagerURL to SecondayManagerURL
                        _configSettings[ConfSet.ManagerURL] = _VerrifyValue( _configSettings[ConfSet.SecondaryManagerURL] );
                    } else {
                        // Excepton No ManagerURL nor SecondayManagerURL
                        return false;
                    }
                    // Exception No ManagerURL
                    return false;
                }
            } else {
                // Exception No UIN
                return false;
            }
            if( _configSettings.ContainsKey( ConfSet.HubSwitcher ) ) {
                _configSettings[ConfSet.HubSwitcher] = _VerrifyValue( _configSettings[ConfSet.HubSwitcher] );
            } else {
                // No HubSwitcher means this is a new Config file.
                _configSettings[ConfSet.HubSwitcher] = "Current";
            }
            // All is good
            return true;
        }

        private bool _VerrifyKey( ConfSet _key, out string StrVal ) {
            StrVal = "";
            int IntVal = 0;

            if( _configSettings.ContainsKey( _key ) ) {

                if( _key == ConfSet.UIN ) {
                    // IF UIN Checn that it is an INT
                    bool _val = Int32.TryParse( _VerrifyValue( _configSettings[_key] ) , out IntVal );
                    if( _val ) {
                        StrVal = _val.ToString();
                    } else {
                        // Exception UIN has a Value but is not an Int
                        return false;
                    }
                }
            } else {
                // Exception No UIN
                return false;
            }
            // All is good
            StrVal = _VerrifyValue( _configSettings[_key] );
            return true;
        }





        public void WriteConfigFile() {
            Encrypt _encObj = new Encrypt();

            _config.AppSettings.Settings.Remove( "UIN" );
            _config.AppSettings.Settings.Add( "UIN" , "5" );

            //if(_settings != null) {
            //    _settings.Settings["UIN"].Value = _encObj.EncryptValue(_UIN);
            //    _settings.Settings["ManagerURL"].Value = _encObj.EncryptValue(_ManagerURL);
            //    _settings.Settings["SecondaryManagerURL"].Value = _encObj.EncryptValue(_SecondaryManagerURL);
            //    _settings.Settings["HubSwitcher"].Value = _encObj.EncryptValue(_HubSwitcherDescription);
            //}

            _config.Save( ConfigurationSaveMode.Modified );
        }

        //public string GetValue( string KeyName ) {
        //    string _value = "";
        //    Encrypt _encObj = new Encrypt();

        //    if( _configSettings.TryGetValue( KeyName , out _value ) ) {
        //        if( _value.StartsWith( "~" ) && _value.Length > 1 ) {
        //            _value = _encObj.DecryptValue( _value );
        //        }
        //    } else {
        //        _value = "ERROR: Unable to find " + KeyName;
        //    }

        //    return _value;

        //}

        //public Dictionary<string , string> GetSettings() {
        //    return _configSettings;
        //}

        private string _VerrifyValue( string _fValue ) {
            string _fResult = "";
            StringBuilder _fstringBuilder = new StringBuilder();
            Encrypt _encObj = new Encrypt();

            if( _fValue.StartsWith( "~" ) && _fValue.Length > 1 ) {
                _fstringBuilder.Append( _encObj.DecryptValue( _fValue ) );
                _fstringBuilder.Replace( "tcp://" , "" );
                _fstringBuilder.Replace( ":50669/MerchantCaptureCommObj.rem" , "" );
                _fResult = _fstringBuilder.ToString();
            }

            return _fResult;
        }

        private string buildTCPString( string ManagerURL ) {
            return "tcp://" + ManagerURL + ":50669/MerchantCaptureCommObj.rem";
        }

        public Config( string AdminPath ) {
            //  Constructor
            _config = ConfigurationManager.OpenExeConfiguration( AdminPath );
            _settings = (AppSettingsSection) _config.GetSection( "appSettings" );

            _BuildDict();

        }
    }
}

