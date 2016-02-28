using System.Runtime.InteropServices;
using System.Text;

namespace OpenNosClientLauncher.Helper
{
    public class IniFile
    {
        /// <summary>
        /// Pfad der Ini-Datei.
        /// </summary>
        private string _path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="Path">Pfad zur Ini-Datei</param>
        public IniFile(string Path)
        {
            _path = Path;
        }

        /// <summary>
        /// Gibt den Pfad der aktuell geladenen Ini-Datei zurück.
        /// </summary>
        /// <returns></returns>
        public string GetIniPath()
        {
            return _path;
        }

        /// <summary>
        /// Sektion der Ini-Datei
        /// </summary>
        /// <param name="Section">Name der Sektion</param>
        /// <returns>Sektion</returns>
        public Section this[string Section]
        {
            get
            {
                return new Section(Section, this);
            }
        }

        /// <summary>
        /// Sektion-Struktur
        /// </summary>
        public class Section
        {
            private string Name;
            private IniFile File;

            /// <summary>
            /// Konstruktor für die Sektion
            /// </summary>
            /// <param name="name">Name der Sektion</param>
            /// <param name="file">Verweis auf die Ini-Datei</param>
            public Section(string name, IniFile file)
            {
                Name = name;
                File = file;
            }

            /// <summary>
            /// Schreibt oder ermittelt einen Ini-Wert.
            /// </summary>
            /// <param name="Key">Bezeichner des Wertes</param>
            /// <returns>String des Wertes</returns>
            public string this[string Key]
            {
                get { return File.IniReadValue(Name, Key); }
                set { if (value != this[Key]) File.IniWriteValue(Name, Key, value); }
            }
        }

        /// <summary>
        /// Schreibt einen Ini-Wert
        /// </summary>
        /// <param name="Section">Name der Sektion</param>
        /// <param name="Key">Bezeichner des Wertes</param>
        /// <param name="Value">Wert</param>
        protected void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this._path);
        }

        /// <summary>
        /// Ermittelt einen Ini-Wert
        /// </summary>
        /// <param name="Section">Name der Sektion</param>
        /// <param name="Key">Bezeichner des Wertes</param>
        /// <returns>Wert</returns>
        protected string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, this._path);
            return temp.ToString();
        }
    }
}
