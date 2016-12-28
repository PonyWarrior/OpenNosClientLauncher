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
            InitAllStrings();
        }

        public string T(string s)
        {
            if (_d[Lng].ContainsKey(s))
                return _d[Lng][s];
            if (_d[Language.En].ContainsKey(s))
                return _d[Language.En][s];
            return "{" + s + "}";
        }


        private void InitAllStrings()
        {
            _d.Add(Language.En, new Dictionary<string, string>
            {
                {"WRONGDIR", "This launcher needs to be placed in the directory of the official Nostale Client!"},
                {"ERROR", "Error"},
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
                {"NOSTALESETTINGS", "Nostale Settings"},
                {"GRAPHICMODE", "Graphic Mode"},
                {"SEARCHUPDATES", "Check for updates"},
                {"CLIENTLAUNCHER", "Client Launcher"},
                {"OFFICIALNOSTALE", "Off. Nostale Client"},
                {"ABOUT", "About"},
                {"ONLYONEINSTANCE", "There can only be one instance of Nostale running."},
                {"SRCNOTFOUND", "The Nostale-Client-File can not be found. Please copy this launcher into the Nostale directory."},
                {"UNAUTHORIZEDACCESSEXCEPTION", "Unauthorized Access! Nostale can only be started once."},
                {"WIN32EXCEPTION", "The Nostale.dat file is perhaps invalid or you have not the right to open it. Try starting this launcher as administrator."},
                {"", ""},

            });
            _d.Add(Language.De, new Dictionary<string, string>
            {
                {"WRONGDIR", "Der Launcher muss sich im Verzeichnis von Nostale befinden."},
                {"ERROR", "Fehler"},
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
                {"NOSTALESETTINGS", "Nostale Einstellungen"},
                {"GRAPHICMODE", "Grafik Modus"},
                {"SEARCHUPDATES", "Nach Updates suchen"},
                {"CLIENTLAUNCHER", "Client Launcher"},
                {"OFFICIALNOSTALE", "Off. Nostale Client"},
                {"ABOUT", "Über"},
                {"ONLYONEINSTANCE", "Es kann nur eine Instanz von Nostale gestartet sein."},
                {"SRCNOTFOUND", "Die Nostale-Client-Datei konnte nicht gefunden werden. Bitte kopiere diesen Launcher ins Nostale-Verzeichnis."},
                {"UNAUTHORIZEDACCESSEXCEPTION", "Unauthorisierter Zugriff! Nostale kann nur einmal gestartet werden."},
                {"WIN32EXCEPTION", "Die Nostale.dat ist wahrscheinlich ungültig oder du besitzt keine Berechtigung, sie zu öffnen. Führe dieses Programm als Administrator aus."},
                {"", ""},
            });
            _d.Add(Language.Fr, new Dictionary<string, string>
            {
                {"", ""},
            });
            _d.Add(Language.It, new Dictionary<string, string>
            {
                {"WRONGDIR", "Questo launcher necessita di essere spostato nella cartella del Nostale Ufficiale!"},
                {"ERROR", "Errore"},
                {"SERVER", "Server"},
                {"LOGINAS", "Effettua l'accesso come"},
                {"CHANGEAUTOLOGIN", "Cambia impostazioni dell'AutoLogin"},
                {"SETTINGS", "Impostazioni"},
                {"STARTGAME", "Start"},
                {"QUIT", "Esci"},
                {"AUTOLOGININFO", "Dopo che il Client di Nostale è stato aperto, l'AutoLogin invierà automaticamente i dati di accesso al processo di Nostale; per questo tu non avrai bisogno di inserire le tue credenziali di volta in volta. In dei pc un po' datati hai la possibilità di aumentare il tempo di ritardo dopo il quale verranno inseriti i dati automaticamente. Presta attenzione a non cambiare la finestra che si apre oppure l'AutoLogin non funzionerà."},
                {"USERNAME", "Username"},
                {"PASSWORD", "Password"},
                {"AUTOLOGINENCRYPTED", "Stai tranquillo! I tuoi dati sono criptati durante il salvataggio."},
                {"DELAY", "Ritardo espresso in millisecondi"},
                {"SAVE", "Salva"},
                {"OFF", "Disabilita"},
                {"BACK", "Indietro"},
                {"LAUNCHERUPDATES", "Ci sono degli aggiornamenti disponibili per questo launcher.\nQuesti potrebbero risolvere problemi o bug presenti nel gioco. Noi raccomandiamo di installare questi aggiornamenti. Per questo controlla immediatamente la nostra Repo su GitHub."},
                {"NOSTALEUPDATES", "Ci sono degli aggiornamenti disponibili per il Client ufficiale di Nostale.\nDopo questi aggiornamenti il launcher nosyx potrebbe non funzionare correttamente. Puoi trovare ulteriori dettagli nella nostra pagina su GitHub.\n\nVuoi proseguire con l'aggiornamento?"},
                {"NOSTALEUPDATESGO", "Il Client ufficiale di Nostale si aprirà adesso per installare gli aggiornamenti.\nAppena l'aggiornamento sarà finito chiudi premendo il tasto rosso 'Quit'.\nQuesto launcher verrà automaticamente riaperto!"},
                {"UPDATESAVAILABLE", "Aggiornamenti disponibili."},
                {"NOSTALESETTINGS", "Impostazioni di Nostale"},
                {"GRAPHICMODE", "Impostazioni grafiche"},
                {"SEARCHUPDATES", "Controlla gli aggiornamenti"},
                {"CLIENTLAUNCHER", "Client Launcher"},
                {"OFFICIALNOSTALE", "Client Uff. Nostale"},
                {"ABOUT", "Informazioni"},
                {"ONLYONEINSTANCE", "Non puoi avere due processi di Nostale contemporaneamente."},
                {"SRCNOTFOUND", "Il client di Nostale non è stato trovato. Per favore copia questo launcher nella cartella di Nostale."},
                {"UNAUTHORIZEDACCESSEXCEPTION", "Accesso non autorizzato. Nostale può essere eseguito una volta sola."},
                {"WIN32EXCEPTION", "Il file Nostale.dat è invalido oppure tu non hai i diritti per poterlo aprire. Riprova ad aprire il Client come Amministratore."},
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
