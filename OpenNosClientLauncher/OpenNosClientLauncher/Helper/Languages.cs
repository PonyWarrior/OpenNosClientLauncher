using System;
using System.Collections.Generic;

namespace OpenNosClientLauncher.Helper
{
    public class LanguageSystem
    {
        public enum Language
        {
            En = 0,
            De = 1,
            Fr = 2,
            It = 3,
            Pl = 4,
            Es = 5,
            Cz = 6,
            Ru = 7,
            Tr = 8
        }

        public Language Lng { get; set; }
        private readonly Dictionary<Language, Dictionary<string, string>> _d;

        public LanguageSystem()
        {
            _d = new Dictionary<Language, Dictionary<string, string>>();
            init();
        }
        
        public string T(string s)
        {
            if (_d[Lng].ContainsKey(s))
                return _d[Lng][s];
            if (_d[Language.En].ContainsKey(s))
                return _d[Language.En][s];
            return "{" + s + "}";
        }


        private void init()
        {
            _d.Add(Language.En, new Dictionary<string, string>
            {
                {"WRONGDIR", "This launcher needs to be placed in the directory of the official Nostale Client!"},
                {"SERVER", "Server"},
                {"LOGINAS", "Login as"},
                {"CHANGEAUTOLOGIN", "Change AutoLogin"},
                {"SETTINGS", "Settings"},
                {"STARTGAME", "Start"},
                {"QUIT", "Quit"},
                {"AUTOLOGININFO", "After the NosTale-Client has been started 'AutoLogin' sends keystrokes to the NosTale-Client Process. Because of this the credentials dont need to be entered again and again. On slower PCs you possibly have to increase the delay time. Make sure that you do not change the activated window while the NosTale client is starting or the keystrokes will be sent to that (active) window."},
                {"USERNAME", "Username"},
                {"PASSWORD", "Password"},
                {"AUTOLOGINENCRYPTED", "Your data will be encrypted."},
                {"DELAY", "Delay (ms)"},
                {"SAVE", "Save"},
                {"OFF", "Turn off"},
                {"BACK", "Back"},
                {"LAUNCHERUPDATES", "There are updates for this launcher available.\nThese may fix problems or bugs in game. We recommend to install these updates. For that please clone the current Git-Repository."},
                {"NOSTALEUPDATES", "For the official Nostale Client are updates available.\nAfter this update nosyx may not function correctly. You'll find more details on our Git-page.\n\nDo you want to update now?"},
                {"NOSTALEUPDATESGO", "The official Nostale Client will launch now, to install the updates.\nAs it has finished, close it with the red 'Quit'-Button.\nThis launcher will reappear automatic!"},
                {"UPDATESAVAILABLE", "Updates available"},
                {"", ""},
            });
            _d.Add(Language.De, new Dictionary<string, string>
            {
                {"WRONGDIR", "Der Launcher muss sich im Verzeichnis von Nostale befinden."},
                {"SERVER", "Server"},
                {"LOGINAS", "Anmelden als"},
                {"CHANGEAUTOLOGIN", "AutoLogin ändern"},
                {"SETTINGS", "Einstellungen"},
                {"STARTGAME", "Start"},
                {"QUIT", "Beenden"},
                {"AUTOLOGININFO", "AutoLogin sendet nach Starten des Spiels automatisch die Tastendrücke zum Anmelden an den NosTale-Client. Dadurch müssen die Anmeldedaten nicht nochmal eingegeben werden. Auf langsameren PCs muss evtl die Verzögerung höher eingestellt werden. Achte darauf, dass du nicht das Fenster wechselst, während der NosTale-Client startet da die Tastendrücke sonst an dieses (aktive) Fenster gesendet werden."},
                {"USERNAME", "Accountname"},
                {"PASSWORD", "Passwort"},
                {"AUTOLOGINENCRYPTED", "Deine Daten werden verschlüsselt."},
                {"DELAY", "Verzögerung (ms)"},
                {"SAVE", "Speichern"},
                {"OFF", "Ausschalten"},
                {"BACK", "Zurück"},
                {"LAUNCHERUPDATES", "Für den Launcher ist ein Update verfügbar: {0} \nDieses behebt möglicherweise essentielle Probleme und Bugs. Es wird dringend empfohlen, dieses zu installieren. Bitte clone dazu das aktuelle Git-Repository!"},
                {"NOSTALEUPDATES", "Für den offiziellen Nostale Client sind Updates verfügbar.\nNach diesem Update funktioniert nosyx möglicherweise nur noch eingeschränkt. Details findest du auf unserer Git-Seite.\n\nMöchtest du diese Updates jetzt installieren?"},
                {"NOSTALEUPDATESGO", "Der offizielle Nostale Client wird nun gestartet, um die Updates zu installieren.\nSobald dieser abgeschlossen hat, schließe ihn wieder (mit einem Klick auf das rote 'Quit').\nDieser Launcher wird danach automatisch wieder erscheinen!"},
                {"UPDATESAVAILABLE", "Updates verfügbar"},
                {"", ""},
            }); 
            _d.Add(Language.Fr, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.It, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.Pl, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.Es, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.Cz, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.Ru, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.Tr, new Dictionary<string, string>
            {
                {"", ""},
            });

            
        }
    }
}
