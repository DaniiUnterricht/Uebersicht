using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheksverwaltung.Classes
{
    class Buch
    {
        #region Properties
        public string Titel { get; private set; }
        public string Autor { get; private set; }
        public string Kategorie { get; private set; }
        public bool IstAusgeliehen { get; private set; }
        public string? AusgeliehenVon { get; private set; }
        #endregion

        #region Konstruktor
        public Buch(string titel, string autor, string kategorie)
        {
            Titel = titel;
            Autor = autor;
            Kategorie = kategorie;
            IstAusgeliehen = false;
            AusgeliehenVon = null;
        }
        #endregion

        #region Methoden
        public bool Ausleihen(string leserName)
        {
            if (IstAusgeliehen)
            {
                return false;
            }

            IstAusgeliehen = true;
            AusgeliehenVon = leserName;
            return true;
        }

        public bool Zurueckgeben(string leserName)
        {
            if(!IstAusgeliehen || AusgeliehenVon != leserName)
            {
                return false;
            }

            IstAusgeliehen = false;
            AusgeliehenVon = null;
            return true;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine($"{Titel} von {Autor}");
            Console.WriteLine($"Kategorie: {Kategorie}");
            if(IstAusgeliehen)
            {
                Console.WriteLine($"Status: Ausgeliehen von {AusgeliehenVon}");
            }
            else
            {
                Console.WriteLine("Status: Verfügbar");
            }
        }
        #endregion
    }
}
