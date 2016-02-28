using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace OpenNosClientLauncher.Helper
{
    class NosModder
    {
        private static readonly GameStartStatusForm GssFrm = new GameStartStatusForm();
        
        public static string GoWithIniFile(bool useDirectXFile, string ls1Ip, int port)
        {
            try
            {
                string orgNostaleXFile = Path.Combine(Environment.CurrentDirectory, useDirectXFile ? "NostaleX.dat" : "Nostale.dat");
                string newNostaleXFile = Path.Combine(Environment.CurrentDirectory, "NostaleOpen.dat");

                if (!File.Exists(orgNostaleXFile))
                    return "SRCNOTFOUND";


                // Delete file from last start
                if (File.Exists(newNostaleXFile))
                    File.Delete(newNostaleXFile);
                    
                Thread.Sleep(10); // Wait for Windows

                File.Copy(orgNostaleXFile, newNostaleXFile);

                using (StreamWriter streamWriter = File.CreateText(Path.Combine(Environment.CurrentDirectory, "Config.ini")))
                {
                    streamWriter.WriteLine("[NosTale_Network]");
                    streamWriter.WriteLine("IP="+ls1Ip);
                    streamWriter.WriteLine("Port="+port);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                Thread.Sleep(100); // Wait for Windows

                // Start
                GssFrm.textBox_log.Text = "Process starting.. ";
                Process p = new Process
                {
                    StartInfo =
                    {
                        UseShellExecute = false,
                        FileName = newNostaleXFile,
                        Arguments = "EntwellNostaleClientLoadFromIni",
                        CreateNoWindow = true
                    }
                };
                p.Start();
                GssfLog("started!");

                return "ok";
            }
            catch (UnauthorizedAccessException)
            {
                return "UNAUTHORIZEDACCESSEXCEPTION";
            }
            catch (Win32Exception)
            {
                // Try start this program as admin
                return "WIN32EXCEPTION";
            }
        }

        public static void SendCredentials(string uname, string upass, IniFile cfg)
        {
            int sleeptime;

            int.TryParse(cfg["Autologin"]["Delay"], out sleeptime);

            if (sleeptime < 500)
                sleeptime = 500;
            else if (sleeptime > 10000)
                sleeptime = 10000;

            string targetProcessWindowTitle = "Nostale";
            bool done = false;
            while (!done)
            {
                try
                {
                    Thread.Sleep(250);

                    GssFrm.textBox_log.Text += "Searching Window...";

                    IntPtr hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, targetProcessWindowTitle);

                    while (hWnd == IntPtr.Zero)
                        hWnd = FindWindowEx(IntPtr.Zero, IntPtr.Zero, null, targetProcessWindowTitle);

                    GssfLog(" found");

                    uint loginWindowProcId;
                    uint loginWindowThreadId = GetWindowThreadProcessId(hWnd, out loginWindowProcId);

                    GssfLog("ProcID gotten");

                    if (0 != loginWindowProcId)
                    {
                        GssfLog("Getting Process");
                        var loginWindowProcess = Process.GetProcessById((int)loginWindowProcId);
                        GssfLog("Waiting for InputIdle");
                        loginWindowProcess.WaitForInputIdle();
                        GssfLog("Setting Foreground");
                        SetForegroundWindow(hWnd);

                        GssfLog("Awaiting GUI... Sleeping "+sleeptime+"ms");

                        Thread.Sleep(sleeptime);

                        GssfLog("Sending keys...");
                        
                        GssfLog(uname);
                        SendKeys.SendWait(uname);
                        
                        GssfLog("{TAB}");
                        SendKeys.SendWait("{TAB}");
                        
                        string pw = upass.Aggregate("", (current, c) => current + "x");
                        GssfLog(pw);
                        SendKeys.SendWait(upass);
                        
                        GssfLog("{ENTER}");
                        SendKeys.SendWait("{ENTER}");
                        done = true;
                        GssfLog("Done.");

                    }
                }
                catch
                {
                    // ignored
                }
            }

            Thread.Sleep(100);

            if (cfg["GameStart"]["GUI"] == "1")
            {
                GssfLog("");
                GssFrm.ShowDialog();
                Thread.Sleep(500);
                GssFrm.Hide();
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint procId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private static void GssfLog(string s)
        {
            GssFrm.textBox_log.Text += s+"\r\n";
        }

    }
}
