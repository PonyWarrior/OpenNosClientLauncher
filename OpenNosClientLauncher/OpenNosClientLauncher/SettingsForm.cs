using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
using OpenNosClientLauncher.Helper;

namespace OpenNosClientLauncher
{
    public partial class SettingsForm : Form
    {
        readonly IniFile _cfg;

        public SettingsForm(IniFile cfg, LanguageSystem _l)
        {
            InitializeComponent();
            _cfg = cfg;

            Text = _l.T("Einstellungen");
            button_nosconf.Text = "Nostale " + _l.T("Einstellungen");
            groupBox2.Text = _l.T("Felder speichern");
            checkBox_savemail.Text = _l.T("Benutzername");
            checkBox_savepw.Text = _l.T("Passwort");
            groupBox3.Text = _l.T("Nach Updates suchen");
            groupBox4.Text = _l.T("Über");
            checkBox_autoGameLogon.Text = _l.T("Aktivieren");
            checkBox_GS_GUI.Text = _l.T("Zeige Konsolen-Log");
            label1.Text = _l.T("Verzög. (ms):");
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (_cfg["Graph"]["Mode"] == "GL")
                radioButton_ogl.Checked = true;

            if (_cfg["Form"]["UserS"] == "1")
            {
                checkBox_savemail.Checked = true;
                checkBox_savepw.Enabled = true;
                checkBox_savepw.Checked = _cfg["Form"]["PwS"] == "1";
            }

            checkBox_upd_nosyx.Checked = _cfg["Update"]["nosyx"] == "1";
            checkBox_upd_nost.Checked = _cfg["Update"]["nostale"] == "1";

            checkBox_GS_GUI.Checked = _cfg["GameStart"]["GUI"] == "1";
            checkBox_autoGameLogon.Checked = _cfg["GameStart"]["EnableAutoLogon"] == "1";

            int tmp;
            int.TryParse(_cfg["GameStart"]["delay"], out tmp);
            if (tmp < 750)
                tmp = 1000;
            else if (tmp > 10000)
                tmp = 10000;

            numericUpDown1.Value = tmp;


            Version asn = Assembly.GetExecutingAssembly().GetName().Version;
            label_copyright.Text = label_copyright.Text.Replace("{v}", asn.ToString(4));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Environment.CurrentDirectory + "\\NtConfig.exe");
            }
            catch
            {
                MessageBox.Show("Die Konfigurationsdatei konnte nicht gefunden werden!");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Graph"]["Mode"] = radioButton_X.Checked ? "DX" : "GL";
        }

        private void checkBox_savemail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_savemail.Checked)
            {
                _cfg["Form"]["UserS"] = "1";
                checkBox_savepw.Enabled = true;
            }
            else
            {
                _cfg["Form"]["UserS"] = "0";
                checkBox_savepw.Enabled = false;
                checkBox_savepw.Checked = false;
            }
        }

        private void checkBox_savepw_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Form"]["PwS"] = checkBox_savepw.Checked ? "1" : "0";
        }

        private void checkBox_upd_nost_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Update"]["nostale"] = checkBox_upd_nost.Checked ? "1" : "0";
        }

        private void checkBox_upd_nosyx_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["Update"]["nosyx"] = checkBox_upd_nosyx.Checked ? "1" : "0";
        }

        private void checkBox_autoGameLogon_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["GameStart"]["EnableAutoLogon"] = checkBox_autoGameLogon.Checked ? "1" : "0";
        }

        private void checkBox_GS_GUI_CheckedChanged(object sender, EventArgs e)
        {
            _cfg["GameStart"]["GUI"] = checkBox_GS_GUI.Checked ? "1" : "0";
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int tmp;
            int.TryParse(numericUpDown1.Value.ToString(CultureInfo.InvariantCulture), out tmp);
            if (tmp < 750)
                tmp = 1000;
            else if (tmp > 10000)
                tmp = 10000;

            _cfg["GameStart"]["delay"] = tmp.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("AutoGameLogon sendet nach Starten des Spiels automatisch die Tastendrücke zum Anmelden an den NosTale-Client. Dadurch müssen die Anmeldedaten nicht nochmal eingegeben werden. Auf langsameren PCs muss evtl die Verzögerung höher eingestellt werden. Achte darauf, dass du nicht das Fenster wechselst, während der NosTale-Client startet.\n\nAutoGameLogon sends after the NosTale-Client has started keypresses to the NosTale-Client. Because of this the credentials dont need to be entered again. On slower PCs you possibly have to increase the delay time. Make sure that you do not change the activated window while the NosTale client is starting.");
        }

    }
}
