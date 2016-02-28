using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using LSC.Cryptography;
using OpenNosClientLauncher.Helper;

namespace OpenNosClientLauncher
{
    public partial class LoginForm : Form
    {
        /*
        4000 EN
        4001 DE
        4002 FR
        4003 IT
        4004 PL
        4005 ES
        4006 CZ
        4007 RU
        4008 TR
        */


        private readonly IniFile _cfg = new IniFile(Environment.CurrentDirectory + "\\OpenNosClientLauncher.ini");
        private readonly LanguageSystem _l;
        private const string RemoteVersion = "https://raw.githubusercontent.com/genyx/OpenNosClientLauncher/master/OpenNosClientLauncher/OpenNosClientLauncher/Properties/AssemblyInfo.cs";
        private Point _mouseposition;



        string _loginserver1Ip = "";
        string _loginserver2Ip = "";

        private string _logInAs = "-";
        

        public LoginForm()
        {
            InitializeComponent();

            // ReSharper disable once VirtualMemberCallInContructor
            Size = MinimumSize;
            panel_mainmenu.Dock = panel_autologin.Dock = panel_settings.Dock = DockStyle.Fill;
            panel_autologin.Visible = panel_settings.Visible = false;

            _l = new LanguageSystem();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Language
            string lng = _cfg["Form"]["Language"];
            if (!string.IsNullOrEmpty(lng) && lng.Length == 2)
            {
                LangChange(lng);
            }
            else
            {
                // Check language.dat
                try
                {
                    FileStream fileStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Language.dat"));
                    int readByte = fileStream.ReadByte();
                    LanguageSystem.Language lng1 = (LanguageSystem.Language)readByte;
                    LangChange(lng1.ToString());
                }
                catch (Exception)
                {
                    // ignored
                    LangChange("en");
                }
            }


            // Wrong dir?
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (!File.Exists("NostaleX.dat") && !File.Exists("Nostale.dat") && !File.Exists("Nostale.exe") && false)
            {
                MessageBox.Show(_l.T("Der ClientLauncher muss sich im Verzeichnis von Nostale befinden!"),_l.T("Fehler"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            if (_cfg["Autologin"]["Enabled"] == "1")
            {
                _logInAs = textBox_username.Text = _cfg["Autologin"]["Username"];
            }

            UpdateCheck(true);

        }

        #region form movement

        void MovementlogopbMDown(object sender, MouseEventArgs e)
        {
            _mouseposition = new Point(-e.X, -e.Y);
        }
        void MovementlogopbMMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(_mouseposition.X - ((Control)sender).Left, _mouseposition.Y - ((Control)sender).Top);
                Location = mousePos;
            }
        }

        #endregion
        

        private void button_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private bool UpdateCheck(bool doall = false)
        {
            WebClient wc = new WebClient();

            bool updateNeedsToBeInstalled = false;

            if (doall || (_cfg["Update"]["Launcher"] == "1"))
            {
                try
                {
                    string remoteVersion = "0.0.0.0";

                    string remoteData = wc.DownloadString(RemoteVersion);
                    foreach (string line in remoteData.Split('\n'))
                    {
                        if (line.Trim().StartsWith("//")) continue;
                        if (line.Trim().StartsWith("[assembly: AssemblyVersion(\""))
                        {
                            int start = line.Trim().IndexOf("\"", StringComparison.Ordinal)+1;
                            remoteVersion = line.Trim().Substring(start, line.Trim().IndexOf("\"", start, StringComparison.Ordinal)-start);
                            break;
                        }
                    }

                    if (new Version(remoteData).CompareTo(Assembly.GetExecutingAssembly().GetName().Version) > 0)
                    {
                        // Update available
                        MessageBox.Show(string.Format(_l.T("LAUNCHERUPDATES"), remoteVersion), _l.T("UPDATESAVAILABLE"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            if ((doall || (_cfg["Update"]["Nostale"] == "1")) && updateNeedsToBeInstalled == false)
            {
                // Update nostale
                string contents, localversion, remoteversion;
                bool nosClientUpdateAvailable = false;

                contents = wc.DownloadString("http://dlcl.gfsrv.net/nostale/patch/de/Update.txt");
                #region check
                if (!nosClientUpdateAvailable)
                {
                    remoteversion = contents.Trim('\n').Trim('\r').Split('\n').Last().Trim('\r');
                    try
                    {
                        localversion = File.ReadAllText(Environment.CurrentDirectory + "\\Update.dat");
                        int remote, local;
                        int.TryParse(remoteversion.Replace(".PKG","").Replace("mu","").Replace("xp","").Replace("xm","").Replace("xg","").Replace("xi",""), out remote);
                        int.TryParse(localversion.Replace(".PKG","").Replace("mu","").Replace("xp","").Replace("xm","").Replace("xg","").Replace("xi",""), out local);
                        if (local < remote)
                            nosClientUpdateAvailable = true;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                #endregion
                contents = wc.DownloadString("http://dlcl.gfsrv.net/nostale/patch/de/muUpdate.txt");
                #region check
                if (!nosClientUpdateAvailable)
                {
                    remoteversion = contents.Trim('\n').Trim('\r').Split('\n').Last().Trim('\r');
                    try
                    {
                        localversion = File.ReadAllText(Environment.CurrentDirectory + "\\Update.dat");
                        int remote = 0, local = 0;
                        int.TryParse(remoteversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out remote);
                        int.TryParse(localversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out local);
                        if (local < remote)
                            nosClientUpdateAvailable = true;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                #endregion
                contents = wc.DownloadString("http://dlcl.gfsrv.net/nostale/patch/de/xpUpdate.txt");
                #region check
                if (!nosClientUpdateAvailable)
                {
                    remoteversion = contents.Trim('\n').Trim('\r').Split('\n').Last().Trim('\r');
                    try
                    {
                        localversion = File.ReadAllText(Environment.CurrentDirectory + "\\Update.dat");
                        int remote = 0, local = 0;
                        int.TryParse(remoteversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out remote);
                        int.TryParse(localversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out local);
                        if (local < remote)
                            nosClientUpdateAvailable = true;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                #endregion
                contents = wc.DownloadString("http://dlcl.gfsrv.net/nostale/patch/de/xmUpdate.txt");
                #region check
                if (!nosClientUpdateAvailable)
                {
                    remoteversion = contents.Trim('\n').Trim('\r').Split('\n').Last().Trim('\r');
                    try
                    {
                        localversion = File.ReadAllText(Environment.CurrentDirectory + "\\Update.dat");
                        int remote = 0, local = 0;
                        int.TryParse(remoteversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out remote);
                        int.TryParse(localversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out local);
                        if (local < remote)
                            nosClientUpdateAvailable = true;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                #endregion
                contents = wc.DownloadString("http://dlcl.gfsrv.net/nostale/patch/de/xgUpdate.txt");
                #region check
                if (!nosClientUpdateAvailable)
                {
                    remoteversion = contents.Trim('\n').Trim('\r').Split('\n').Last().Trim('\r');
                    try
                    {
                        localversion = File.ReadAllText(Environment.CurrentDirectory + "\\Update.dat");
                        int remote = 0, local = 0;
                        int.TryParse(remoteversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out remote);
                        int.TryParse(localversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out local);
                        if (local < remote)
                            nosClientUpdateAvailable = true;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                #endregion
                contents = wc.DownloadString("http://dlcl.gfsrv.net/nostale/patch/de/xiUpdate.txt");
                #region check
                if (!nosClientUpdateAvailable)
                {
                    remoteversion = contents.Trim('\n').Trim('\r').Split('\n').Last().Trim('\r');
                    try
                    {
                        localversion = File.ReadAllText(Environment.CurrentDirectory + "\\Update.dat");
                        int remote = 0, local = 0;
                        int.TryParse(remoteversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out remote);
                        int.TryParse(localversion.Replace(".PKG", "").Replace("mu", "").Replace("xp", "").Replace("xm", "").Replace("xg", "").Replace("xi", ""), out local);
                        if (local < remote)
                            nosClientUpdateAvailable = true;
                    }
                    catch
                    {
                        // ignored
                    }
                }
                #endregion

                if (nosClientUpdateAvailable)
                {
                    DialogResult drua = MessageBox.Show(_l.T("NOSTALEUPDATES"), 
                        _l.T("UPDATESAVAILABLE"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (drua == DialogResult.Yes)
                    {
                        Hide();

                        MessageBox.Show(_l.T("NOSTALEUPDATESGO"), _l.T("UPDATESAVAILABLE"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        // Start
                        Process p = new Process
                        {
                            StartInfo = {FileName = Environment.CurrentDirectory + "\\Nostale.exe"}
                        };
                        p.Start();
                        p.WaitForExit();

                        updateNeedsToBeInstalled = true;
                        Application.Restart();

                    }
                }

            }
            return updateNeedsToBeInstalled;
        }

        
        private void textBox_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBox_password.Focus();
                e.SuppressKeyPress = true;
            }
            button_autologin_save.Text = _l.T(textBox_username.Text.Trim().Length == 0 ? "OFF" : "SAVE");
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_autologin_save_Click(sender, null);
                e.SuppressKeyPress = true;
            }
        }
        
        private void button_gamestart_Click(object sender, EventArgs e)
        {
            button_gamestart.Enabled = false;
            try
            {
                // Wenn Nostale bereits läuft..
                Process[] processesNt = Process.GetProcessesByName("Nostale.dat");
                Process[] processesNtx = Process.GetProcessesByName("NostaleX.dat");
                Process[] processesNx = Process.GetProcessesByName("nosyx.dat");
                if (processesNt.Length > 0 || processesNx.Length > 0 || processesNtx.Length > 0)
                {
                    // There is already an instance running
                    MessageBox.Show("Es kann nur eine Instanz von Nostale gestartet sein!\n\nThere can only be one instance of Nostale!", _l.T("Fehler"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string result = _cfg["GameStart"]["UseByteManipulation"] != "0"
                        ? NosyxModder.GoHack(_cfg["Graph"]["Mode"] != "GL", _loginserver1Ip, _loginserver2Ip)
                        : NosyxModder.GoWithIniFile(_cfg["Graph"]["Mode"] != "GL", _loginserver1Ip, 4001); // TODO Port depends on Language

                    if (result != "ok")
                    {
                        MessageBox.Show(result, _l.T("Fehler"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Hide();

                        int tmp;
                        int.TryParse(_cfg["GameStart"]["delay"], out tmp);
                        if (tmp < 750)
                            tmp = 1250;
                        else if (tmp > 10000)
                            tmp = 10000;
                        _cfg["GameStart"]["delay"] = tmp.ToString();

                        Thread.Sleep(3000);

                        if (_cfg["GameStart"]["EnableAutoLogon"] != "0")
                            NosyxModder.SendCred(textBox_username.Text, textBox_password.Text, _cfg);

                        Application.Exit();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), _l.T("Fehler"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            button_gamestart.Enabled = true;
        }
        

        private void LangChange(object sender, EventArgs e)
        {
            string lng = ((Control) sender).Name.Split('_')[1];
            LangChange(lng);
        }

        private void LangChange(string lng)
        {
            switch (lng.ToLower())
            {
                case "en":
                    panel_langselect.Location = new Point(pictureBox_en.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.En;
                    break;
                case "de":
                    panel_langselect.Location = new Point(pictureBox_de.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.De;
                    break;
                case "fr":
                    panel_langselect.Location = new Point(pictureBox_fr.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.Fr;
                    break;
                case "it":
                    panel_langselect.Location = new Point(pictureBox_it.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.It;
                    break;
                case "pl":
                    panel_langselect.Location = new Point(pictureBox_pl.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.Pl;
                    break;
                case "es":
                    panel_langselect.Location = new Point(pictureBox_es.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.Es;
                    break;
                case "cz":
                    panel_langselect.Location = new Point(pictureBox_cz.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.Cz;
                    break;
                case "ru":
                    panel_langselect.Location = new Point(pictureBox_ru.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.Ru;
                    break;
                case "tr":
                    panel_langselect.Location = new Point(pictureBox_tr.Left + 3, 5);
                    _l.Lng = LanguageSystem.Language.Tr;
                    break;
            }

            _cfg["Form"]["Language"] = lng;

            groupBox_server.Text = _l.T("SERVER");
            label_loginas.Text = _l.T("LOGINAS") + ": " + _logInAs;
            linkLabel_changeautologin.Text = _l.T("CHANGEAUTOLOGIN");
            linkLabel_settings.Text = _l.T("SETTINGS");
            button_gamestart.Text = _l.T("STARTGAME");
            button_quit.Text = _l.T("QUIT");

            label_autologininfo.Text = _l.T("AUTOLOGININFO");
            groupBox_username.Text = _l.T("USERNAME");
            groupBox_password.Text = _l.T("PASSWORD");
            label_autologininfo_encrypted.Text = _l.T("AUTOLOGINENCRYPTED");
            groupBox_delay.Text = _l.T("DELAY");
            button_autologin_save.Text = _l.T("SAVE");
            button_autologin_back.Text = _l.T("BACK");

        }


        private void label_xmenu_x_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_autologin_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_username.Text) || string.IsNullOrEmpty(textBox_password.Text))
            {
                _cfg["Autologin"]["Enabled"] = "0";
                _cfg["Autologin"]["Username"] = _cfg["Autologin"]["Password"] = _logInAs = "-";
                button_autologin_back_Click(sender, null);
                return;
            }

            _cfg["Autologin"]["Enabled"] = "1";
            _cfg["Autologin"]["Username"] = textBox_username.Text;
            _cfg["Autologin"]["Password"] = SimpleStringCipher.Encrypt(textBox_password.Text, "OPENNOSROCKXXX");

            _logInAs = textBox_username.Text;
            button_autologin_back_Click(sender, null);
        }

        private void button_autologin_back_Click(object sender, EventArgs e)
        {
            panel_autologin.Visible = false;
            panel_mainmenu.Visible = true;
            textBox_server.Focus();
        }

        private void linkLabel_changeautologin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_mainmenu.Visible = false;
            panel_autologin.Visible = true;
            textBox_username.Focus();
        }

        private void linkLabel_settings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_mainmenu.Visible = false;
            panel_settings.Visible = true;

            /*SettingsForm sfrm = new SettingsForm(_cfg, _l);
            sfrm.ShowDialog();
            panel_settings.Visible = false;
            panel_mainmenu.Visible = true;*/
        }
    }
}
