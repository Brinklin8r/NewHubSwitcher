﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration {
    public class Config {
        //<add key = "UIN" value="~5E6B644F777773582A514B2F716C505F5970582F712D7B412A2F742D782F6A622A77616F5B6C56796D65652D5F65656E6E7474656572722D5F79796F6F757572722D5F555549494E4E2D5F6E6E75756D6D626265657272"/>
		//<add key = "ManagerURL" value="~5C6C5A636C2F59542A622A502A4E404E2A5252757572726C6C7C7C5E5E5B5B5C5C78782D712D6F2D6C5C5C78782D7645455D5D7B7B2D712D6B7D7D2D637C7C50506C6C65656161737365652D5F65656E6E7474656572722D5F7474686865652D5F7373656572727676656572722D5F6E6E61616D6D6565"/>
		//<add key = "SecondaryManagerURL" value="~5D4C4961707670572A562A57475943502A562A594B625056444F2A5A42572A5D2A45455A4A7575756F6C6C7C7C5E5E5B5B5C5C78782D712D6F2D6C5C5C78782D7645455D5D7B7B2D712D6B7D7D2D637C7C50506C6C65656161737365652D5F65656E6E7474656572722D5F7474686865652D5F7373656563636F6F6E6E64646161727279792D5F7373656572727676656572722D5F6E6E61616D6D6565"/>

        private int _UIN = 1;
        private string _ManagerURL = "";
        private string SecondaryManagerURL = "";

        public void ReadConfigFile() {

        }

        public void WriteConfigFile() {

        }
    }
}
