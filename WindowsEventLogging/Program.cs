using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsEventLogging
{
    static class Program
    {
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private static bool Handler(CtrlType signal)
        {
            switch (signal)
            {
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                    LogTimeStamps(DateTime.Now, "Computer shut down or program terminated at");
                    // TODO Cleanup resources
                    Environment.Exit(0);
                    return false;

                default:
                    return false;
            }
        }

        static void Main()
        {
            LogTimeStamps(DateTime.Now, "Program started at");
            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);

            // Some biolerplate to react to close window event
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }

        static void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                //I left my desk
                LogTimeStamps(DateTime.Now, "I left my desk at");
            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                //I returned to my desk
                LogTimeStamps(DateTime.Now, "I returned to my desk at");
            }
        }

        static void LogTimeStamps(DateTime timeStamp, string state) 
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + @"\log.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(state + " {" + timeStamp.ToShortTimeString()+ "} " + "[" + timeStamp.ToShortDateString() + "]");
                }
            }
            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(state + " {" + timeStamp.ToShortTimeString() + "} " + "[" + timeStamp.ToShortDateString() + "]");
            }
        }
    }
}
