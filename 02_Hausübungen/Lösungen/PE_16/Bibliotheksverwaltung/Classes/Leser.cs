using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheksverwaltung.Classes
{
    class Leser
    {
        #region Properties
        public string Name { get; private set; }
        public int MaximaleAusleihen { get; private set; }
        public List<Buch> AusgelieheneBuecher { get; private set; }
        #endregion

        #region Konstruktor
        public Leser(string name, int maximaleAusleihen)
        {
            Name = name;
            MaximaleAusleihen = maximaleAusleihen;
            AusgelieheneBuecher = new List<Buch>();
        }
        #endregion

        #region Methoden
        public bool BuchAusleihen(Buch buch)
        {
            if(AusgelieheneBuecher.Count >= MaximaleAusleihen)
            {
                return false;
            }

            if (buch.Ausleihen(Name)) { AusgelieheneBuecher.Add(buch); return true;  } else { return false; }
        }

        public bool BuchZurueckgeben(Buch buch)
        {
            bool isVorhanden = false;

            foreach (var books in AusgelieheneBuecher)
            {
                if (books == buch)
                {
                    isVorhanden = true;
                }
            }
            if (!isVorhanden) { return false; }

            if (buch.Zurueckgeben(Name))
            {
                AusgelieheneBuecher.Remove(buch);
                return true;
            }

            return false;
        }

        public void ZeigeAusgelieheneBuecher()
        {
            foreach(var book in AusgelieheneBuecher)
            {
                book.ZeigeInfo();
                Console.WriteLine();
            }
        }
        #endregion
    }
}
