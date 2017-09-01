using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubSwitcher {
    class RunProgram {


        public void Start(string targetPath) {
            ProcessStartInfo _start = new ProcessStartInfo();

            // Enter in the command line arguments, everything you would enter 
            //  after the executable name itself
            //  _start.Arguments = arguments;

            // Enter the executable to run, including the complete path
            _start.FileName = targetPath;

            // Do you want to show a console window?
            _start.WindowStyle = ProcessWindowStyle.Hidden;
            _start.CreateNoWindow = true;
            //  int exitCode = 0;

            // Run the external process & wait for it to finish
            using(Process proc = Process.Start(_start)) {
                //      proc.WaitForExit();
                // Retrieve the app's exit code
                //      exitCode = proc.ExitCode;
            }
        }
    }
}
