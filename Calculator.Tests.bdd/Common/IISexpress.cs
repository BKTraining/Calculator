using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Calculator.Tests.bdd.Common
{
    public class IISExpress
    {
        Process _iisProcess;

        private void StartIisExpress()
        {

            string AppLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
  //         AppLocation += @"\..\..\..\Calculator";
            AppLocation = AppLocation.Substring(0, AppLocation.LastIndexOf('\\'));
            AppLocation = AppLocation.Substring(0, AppLocation.LastIndexOf('\\'));
            AppLocation = AppLocation.Substring(0, AppLocation.LastIndexOf('\\'));
            AppLocation += @"\Calculator";
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = string.Format("/path:\"{0}\" /port:{1}", AppLocation, 8081)
            };

            var programfiles = string.IsNullOrEmpty(startInfo.EnvironmentVariables["programfiles"])
                                ? startInfo.EnvironmentVariables["programfiles(x86)"]
                                : startInfo.EnvironmentVariables["programfiles"];

            startInfo.FileName = programfiles + "\\IIS Express\\iisexpress.exe";

            try
            {
                _iisProcess = new Process { StartInfo = startInfo };

                _iisProcess.Start();
                _iisProcess.WaitForExit();
            }
            catch
            {
                _iisProcess.CloseMainWindow();
                _iisProcess.Dispose();
            }
        }
        
        public IISExpress()
        {

        }

        public void Start()
        {
            var thread = new Thread(new ThreadStart(StartIisExpress)) { IsBackground = true };
            thread.Start();
        }

        public void Stop()
        {
            _iisProcess.CloseMainWindow();
            _iisProcess.Dispose();
        }
    }
}
