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
    class NosyxModder
    {
        private static readonly GameStartStatusForm GssFrm = new GameStartStatusForm();

        public static string GoHack(bool useDirectXFile, string ls1Ip, string ls2Ip)
        {
            try
            {
                string orgNostaleXFile = Path.Combine(Environment.CurrentDirectory, useDirectXFile ? "NostaleX.dat" : "Nostale.dat");
                string newNostaleXFile = Path.Combine(Environment.CurrentDirectory, "nosyx.dat");

                byte[] loginserver1 = new byte[15], loginserver2 = new byte[15];

                if (File.Exists(orgNostaleXFile)) // Richtiges Verzeichnis?
                {
                    // Delete nosyx.dat from last start
                    if (File.Exists(newNostaleXFile))
                        File.Delete(newNostaleXFile);

                    #region String To Byte Array
                    try
                    {
                        char[] srv1Char = ls1Ip.ToCharArray();
                        char[] srv2Char = ls2Ip.ToCharArray();

                        // 84.76.194.180
                        // 13 ->  0x0D

                        for (int i = 0; i < 15; i++)
                        {
                            try
                            {
                                loginserver1[i] = (byte) srv1Char[i];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                // Fills the last bytes with 0x00
                                loginserver1[i] = 0x0;
                            }

                            try
                            {
                                loginserver2[i] = (byte) srv2Char[i];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                // Fills the last bytes with 0x00
                                loginserver2[i] = 0x0;
                            }
                        }
                    }
                    catch
                    {
                        // Default 127.0.0.1
                        loginserver1 = new byte[] { 0x31, 0x32, 0x37, 0x2e, 0x30, 0x2e, 0x30, 0x2e, 0x31, 0x00, 0x0, 0x0, 0x0, 0x0, 0x0 };
                        loginserver2 = new byte[] { 0x31, 0x32, 0x37, 0x2e, 0x30, 0x2e, 0x30, 0x2e, 0x32, 0x00, 0x0, 0x0, 0x0, 0x0, 0x0 };
                    }
                    #endregion
                    

                    #region Replace Bytes and create new File
                    FileInfo fi = new FileInfo(orgNostaleXFile);
                    byte[] byteArr = new byte[fi.Length];

                    // Read In NostaleX.dat as byte[]
                    using (FileStream fs = new FileStream(orgNostaleXFile, FileMode.Open, FileAccess.Read))
                        fs.Read(byteArr, 0, (int)fi.Length);

                    // Make List of new ip (in byte-List)
                    List<byte> newipsByteList = new List<byte>();
                    newipsByteList.AddRange(new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00 });
                    newipsByteList.AddRange(loginserver1);
                    newipsByteList.AddRange(new byte[] { 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x0F, 0x00, 0x00, 0x00 });
                    newipsByteList.AddRange(loginserver2);

                    // Find and Replace bytes
                    byte[] oldips = { 
                        0xFF, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, 
                        0x37, 0x39, 0x2E, 0x31, 0x31, 0x30, 0x2E, 0x38, 0x34, 0x2E, 0x37, 0x35, 0x00, 0x00, 0x00, 0x00, 
                        0xFF, 0xFF, 0xFF, 0xFF, 0x0C, 0x00, 0x00, 0x00, 
                        0x37, 0x39, 0x2E, 0x31, 0x31, 0x30, 0x2E, 0x38, 0x34, 0x2E, 0x34, 0x36, 0x00, 0x00, 0x00 };
                    byte[] newips = newipsByteList.ToArray();
                    byteArr = ReplaceBytes(byteArr, oldips, newips);


                    // Write Out
                    using (BinaryWriter binWriter = new BinaryWriter(new FileStream(newNostaleXFile, FileMode.Create, FileAccess.Write)))
                        binWriter.Write(byteArr);
                    #endregion

                    // Start
                    GssFrm.textBox_log.Text = "Process starting.. ";
                    Process p = new Process
                    {
                        StartInfo =
                        {
                            UseShellExecute = false,
                            FileName = newNostaleXFile,
                            //Arguments = "EntwellNostaleClientLoadFromIni",
                            Arguments = "EntwellNostaleClient",
                            CreateNoWindow = true
                        }
                    };
                    p.Start();
                    GssfLog("started!");

                    return "ok";

                }
                return "Datei '" + orgNostaleXFile + "' konnte nicht gefunden werden. Bitte kopiere diese EXE-Datei ins Nostale-Verzeichnis!\n";
            }
            catch (UnauthorizedAccessException)
            {
                return ("Unauthorisierter Zugriff! Nostale kann nur einmal gestartet werden!\n");
            }
            catch (ArgumentNullException ex)
            {
                // NostaleX.dat is not the original (maybe it has already the 127.0.0.1)
                return ("Die NostaleX.dat ist wahrscheinlich ungültig.\n"+ex);
            }
            catch (Win32Exception ex)
            {
                // Try start this program as admin
                return ("Die NostaleX.dat ist wahrscheinlich ungültig oder du besitzt keine Berechtigung, sie zu öffnen. Führe dieses Programm als Administrator aus!\nDetails: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Unknown
                return ("Ein unbekannter Fehler ist aufgetreten:\n"+ex);
            }
        }
        public static string GoWithIniFile(bool useDirectXFile, string ls1Ip, int port)
        {
            try
            {
                string orgNostaleXFile = Path.Combine(Environment.CurrentDirectory, useDirectXFile ? "NostaleX.dat" : "Nostale.dat");
                string newNostaleXFile = Path.Combine(Environment.CurrentDirectory, "nosyx.dat");

                if (!File.Exists(orgNostaleXFile))
                    return "Datei '" + orgNostaleXFile + "' konnte nicht gefunden werden. Bitte kopiere diese EXE-Datei ins Nostale-Verzeichnis!\n";


                // Delete nosyx.dat from last start
                if (File.Exists(newNostaleXFile))
                    File.Delete(newNostaleXFile);
                    
                Thread.Sleep(10);

                File.Copy(orgNostaleXFile, newNostaleXFile);

                using (StreamWriter streamWriter = File.CreateText(Path.Combine(Environment.CurrentDirectory, "Config.ini")))
                {
                    streamWriter.WriteLine("[NosTale_Network]");
                    streamWriter.WriteLine("IP="+ls1Ip);
                    streamWriter.WriteLine("Port="+port);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                Thread.Sleep(100);

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
                return ("Unauthorisierter Zugriff! Nostale kann nur einmal gestartet werden!\n");
            }
            catch (ArgumentNullException ex)
            {
                // NostaleX.dat is not the original (maybe it has already the 127.0.0.1)
                return ("Die NostaleX.dat ist wahrscheinlich ungültig.\n" + ex);
            }
            catch (Win32Exception ex)
            {
                // Try start this program as admin
                return ("Die NostaleX.dat ist wahrscheinlich ungültig oder du besitzt keine Berechtigung, sie zu öffnen. Führe dieses Programm als Administrator aus!\nDetails: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Unknown
                return ("Ein unbekannter Fehler ist aufgetreten:\n" + ex);
            }
        }

        // This function is from the internet
        private static int FindBytes(byte[] src, byte[] find)
        {
            int index = -1;
            int matchIndex = 0;
            // handle the complete source array
            for (int i = 0; i < src.Length; i++)
            {
                if (src[i] == find[matchIndex])
                {
                    if (matchIndex == (find.Length - 1))
                    {
                        index = i - matchIndex;
                        break;
                    }
                    matchIndex++;
                }
                else
                {
                    matchIndex = 0;
                }

            }
            return index;
        }

        // This too
        private static byte[] ReplaceBytes(byte[] src, byte[] search, byte[] repl)
        {
            byte[] dst = null;
            int index = FindBytes(src, search);
            if (index >= 0)
            {
                dst = new byte[src.Length - search.Length + repl.Length];
                // before found array
                Buffer.BlockCopy(src, 0, dst, 0, index);
                // repl copy
                Buffer.BlockCopy(repl, 0, dst, index, repl.Length);
                // rest of src array
                Buffer.BlockCopy(
                    src,
                    index + search.Length,
                    dst,
                    index + repl.Length,
                    src.Length - (index + search.Length));
            }
            return dst;
        }

        public static void SendCred(string uname, string upass, IniFile _CFG)
        {
            int sleeptime;

            int.TryParse(_CFG["GameStart"]["delay"], out sleeptime);

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

            if (_CFG["GameStart"]["GUI"] == "1")
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
