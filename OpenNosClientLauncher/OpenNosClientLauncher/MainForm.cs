using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using LSC.Cryptography;
using OpenNosClientLauncher.Helper;

namespace OpenNosClientLauncher
{
    public partial class MainForm : Form
    {

        private readonly IniFile _cfg = new IniFile(Environment.CurrentDirectory + "\\OpenNosClientLauncher.ini");
        private readonly LanguageSystem _l;
        private const string RemoteVersion = "https://raw.githubusercontent.com/genyx/OpenNosClientLauncher/master/OpenNosClientLauncher/OpenNosClientLauncher/Properties/AssemblyInfo.cs";
        private Point _mouseposition;
        private string _logInAs = "-";

        public sealed override Size MinimumSize
        {
            get { return base.MinimumSize; }
            set { base.MinimumSize = value; }
        }



        #region Initiation
        public MainForm()
        {
            InitializeComponent();

            Size = MinimumSize;
            panel_mainmenu.Dock = panel_autologin.Dock = panel_settings.Dock = DockStyle.Fill;
            panel_autologin.Visible = panel_settings.Visible = false;

            _l = new LanguageSystem();

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Loading Config
            try
            {
                #region Apply Language

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
                        using (FileStream fileStream = File.OpenRead(Path.Combine(Environment.CurrentDirectory, "Language.dat")))
                        {
                            LangChange(((LanguageSystem.Language)fileStream.ReadByte()).ToString());
                        }
                    }
                    catch (Exception)
                    {
                        // ignored
                        LangChange("en");
                    }
                }
                
                #endregion

                #region Load in Settings

                radioButton_Gl.Checked = _cfg["Graph"]["Mode"] == "GL";

                checkBox_update_launcher.Checked = _cfg["Update"]["launcher"] == "1";
                checkBox_update_nostale.Checked = _cfg["Update"]["nostale"] == "1";

                label_copyright.Text = label_copyright.Text.Replace("{v}",
                    Assembly.GetExecutingAssembly().GetName().Version.ToString());

                textBox_server.Text = !string.IsNullOrEmpty(_cfg["Form"]["LastServer"]) ? _cfg["Form"]["LastServer"] : "localhost";

                try
                {
                    if (_cfg["Autologin"]["Enabled"] == "1")
                        _logInAs = textBox_username.Text = _cfg["Autologin"]["Username"];

                    int tmp = Convert.ToInt32(_cfg["Autologin"]["Delay"]);
                    if (tmp < 750)
                        tmp = 1000;
                    else if (tmp > 10000)
                        tmp = 10000;
                    numericUpDown_delay.Value = tmp;
                }
                catch (Exception)
                {
                    // ignored
                }

                #endregion


                // Wrong dir?
                if (!File.Exists("NostaleX.dat") && !File.Exists("Nostale.dat") && !File.Exists("Nostale.exe"))
                {
                    MessageBox.Show(_l.T("WRONGDIR"), _l.T("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                timer_UpdateCheck.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex, _l.T("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void timer_UpdateCheck_Tick(object sender, EventArgs e)
        {
            timer_UpdateCheck.Stop();
            UpdateCheck();
            button_gamestart.Enabled = true;
        }

        #endregion


        #region Top Bar

        private void MovementlogopbMDown(object sender, MouseEventArgs e)
        {
            _mouseposition = new Point(-e.X, -e.Y);
        }

        private void MovementlogopbMMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = MousePosition;
                mousePos.Offset(_mouseposition.X - ((Control)sender).Left, _mouseposition.Y - ((Control)sender).Top);
                Location = mousePos;
            }
        }

        private void label_xmenu_x_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label_xmenu_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Mainmenu

        private void pictureBox_LanguageChange_Click(object sender, EventArgs e)
        {
            string lng = ((Control)sender).Name.Split('_')[1];
            LangChange(lng);
        }

        private void textBox_server_TextChanged(object sender, EventArgs e)
        {
            _cfg["Form"]["LastServer"] = textBox_server.Text;
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
        }

        private void button_gamestart_Click(object sender, EventArgs e)
        {
            button_gamestart.Enabled = false;
            try
            {
                Process[] processesNt = Process.GetProcessesByName("Nostale.dat");
                Process[] processesNtx = Process.GetProcessesByName("NostaleX.dat");
                Process[] processesOn = Process.GetProcessesByName("NostaleOpen.dat");
                if (processesNt.Length > 0 || processesOn.Length > 0 || processesNtx.Length > 0)
                {
                    // There is already an instance running
                    MessageBox.Show(_l.T("ONLYONEINSTANCE"), _l.T("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        IPAddress[] hostAddresses = Dns.GetHostAddresses(textBox_server.Text);
                        IPAddress ipAddress = hostAddresses.Contains(IPAddress.Parse("127.0.0.1"))
                            ? IPAddress.Parse("127.0.0.1")
                            : hostAddresses[0];

                        int port = 4000 + _l.Lng.GetHashCode();

                        if (!string.IsNullOrEmpty(_cfg["Form"]["OverridePort"]))
                            int.TryParse(_cfg["Form"]["OverridePort"], out port);
                        else
                            _cfg["Form"]["OverridePort"] = "";

                        string result = NosModder.GoWithIniFile(_cfg["Graph"]["Mode"] != "GL", ipAddress.ToString(), port);

                        if (result != "ok")
                        {
                            MessageBox.Show(_l.T(result), _l.T("Fehler"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            Hide();

                            int tmp;
                            int.TryParse(_cfg["Autologin"]["Delay"], out tmp);
                            if (tmp < 750)
                                tmp = 1250;
                            else if (tmp > 10000)
                                tmp = 10000;
                            _cfg["Autologin"]["Delay"] = tmp.ToString();

                            string password = "";
                            try
                            {
                                password = SimpleStringCipher.Decrypt(_cfg["Autologin"]["Password"], "OPENNOSROCKXXX");
                            }
                            catch (FormatException exception)
                            {
                                // Password in config was false formated/encrypted
                                // Reset
                                _cfg["Autologin"]["Password"] = "";
                            }
                            catch (Exception exception)
                            {
                                MessageBox.Show(exception.ToString(), _l.T("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Application.Exit();
                            }

                            Thread.Sleep(3000);

                            if (_cfg["Autologin"]["Enabled"] != "0")
                                NosModder.SendCredentials(textBox_username.Text, password, _cfg);

                            Application.Exit();

                        }
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.ToString(), _l.T("ERROR"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region AutoLogin

        private void textBox_username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                textBox_password.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_autologin_save_Click(sender, null);
                e.SuppressKeyPress = true;
            }
        }

        private void button_autologin_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_username.Text) || (_cfg["Autologin"]["Enabled"] == "0" && string.IsNullOrEmpty(textBox_password.Text)))
            {
                if (string.IsNullOrEmpty(textBox_username.Text))
                    textBox_username.Focus();
                else
                    textBox_password.Focus();
                return;
            }

            _cfg["Autologin"]["Enabled"] = "1";
            _cfg["Autologin"]["Username"] = textBox_username.Text;
            if (!string.IsNullOrEmpty(textBox_password.Text))
                _cfg["Autologin"]["Password"] = SimpleStringCipher.Encrypt(textBox_password.Text, "OPENNOSROCKXXX");

            int tmp = Convert.ToInt32(numericUpDown_delay.Value);
            if (tmp < 750)
                tmp = 1000;
            else if (tmp > 10000)
                tmp = 10000;
            _cfg["Autologin"]["Delay"] = tmp.ToString();

            _logInAs = textBox_username.Text;
            textBox_password.Text = "";
            button_back_Click(sender, null);
        }

        private void button_autologin_off_Click(object sender, EventArgs e)
        {
            _cfg["Autologin"]["Enabled"] = "0";
            _cfg["Autologin"]["Username"] = _cfg["Autologin"]["Password"] = _logInAs = "-";
            button_back_Click(sender, null);
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            panel_autologin.Visible = panel_settings.Visible = false;
            panel_mainmenu.Visible = true;
            textBox_server.Focus();
        }

        #endregion

        #region Settings

        private void linkLabel_nostalesettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(Path.Combine(Environment.CurrentDirectory, "NtConfig.exe"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), _l.T("ERROR"));
            }
        }

        private void radioButton_graphicsMode_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Graph"]["Mode"] = radioButton_Dx.Checked ? "DX" : "GL";
        }

        private void checkBox_update_launcher_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Update"]["launcher"] = checkBox_update_launcher.Checked ? "1" : "0";
        }

        private void checkBox_update_nostale_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Update"]["nostale"] = checkBox_update_nostale.Checked ? "1" : "0";
        }


        #endregion


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
                            int start = line.Trim().IndexOf("\"", StringComparison.Ordinal) + 1;
                            remoteVersion = line.Trim().Substring(start, line.Trim().IndexOf("\"", start, StringComparison.Ordinal) - start);
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
                            StartInfo = { FileName = Environment.CurrentDirectory + "\\Nostale.exe" }
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

        private void LangChange(string lng)
        {
            const int height = 7;
            switch (lng.ToLower())
            {
                case "en":
                    panel_langselect.Location = new Point(pictureBox_en.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.En;
                    break;
                case "de":
                    panel_langselect.Location = new Point(pictureBox_de.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.De;
                    break;
                case "fr":
                    panel_langselect.Location = new Point(pictureBox_fr.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.Fr;
                    break;
                case "it":
                    panel_langselect.Location = new Point(pictureBox_it.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.It;
                    break;
                case "pl":
                    panel_langselect.Location = new Point(pictureBox_pl.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.Pl;
                    break;
                case "es":
                    panel_langselect.Location = new Point(pictureBox_es.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.Es;
                    break;
                case "cz":
                    panel_langselect.Location = new Point(pictureBox_cz.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.Cz;
                    break;
                case "ru":
                    panel_langselect.Location = new Point(pictureBox_ru.Left + 3, height);
                    _l.Lng = LanguageSystem.Language.Ru;
                    break;
                case "tr":
                    panel_langselect.Location = new Point(pictureBox_tr.Left + 3, height);
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
            button_autologin_off.Text = _l.T("OFF");
            button_autologin_back.Text = _l.T("BACK");

            label_settingstitle.Text = _l.T("SETTINGS");
            linkLabel_nostalesettings.Text = _l.T("NOSTALESETTINGS");
            groupBox_graphicsmode.Text = _l.T("GRAPHICMODE");
            groupBox_searchupdates.Text = _l.T("SEARCHUPDATES");
            checkBox_update_launcher.Text = _l.T("CLIENTLAUNCHER");
            checkBox_update_nostale.Text = _l.T("OFFICIALNOSTALE");
            groupBox_about.Text = _l.T("ABOUT");
            button_settings_back.Text = _l.T("BACK");

        }

    }
}
