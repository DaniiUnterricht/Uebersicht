using System;
using System.Collections.Generic;
using System.Text;

namespace Bibliotheksverwaltung.Classes
{
    class Bibliothek
    {
        #region Properties
        public string Name { get; private set; }
        public List<Buch> Buecher { get; private set; }
        public List<Leser> Leser { get; private set; }
        #endregion

        #region Konstruktor
        public Bibliothek(string name)
        {
            Name = name;
            Buecher = new List<Buch>();
            Leser = new List<Leser>();
        }
        #endregion

        #region Methoden
        public bool BuchHinzufuegen(Buch buch)
        {
            foreach (var item in Buecher)
            {
                if (item.Titel == buch.Titel && item.Autor == buch.Autor) { return false; }
            }

            Buecher.Add(buch);
            return true;
        }

        public bool LeserRegistrieren(Leser leser)
        {
            foreach (var item in Leser)
            {
                if (item == leser) { return false; }
            }
            Leser.Add(leser);
            return true;
        }

        public Buch? BuchSuchen(string titel)
        {
            foreach(var item in Buecher) { if(item.Titel == titel) { return item; } }

            return null;
        }

        public void ZeigeVerfuegbareBuecher()
        {
            foreach(var item in Buecher)
            {
                if(!item.IstAusgeliehen)
                {
                    item.ZeigeInfo();
                    Console.WriteLine();
                }
            }
        }

        public void ZeigeBuecherNachKategorie(string kategorie)
        {
            foreach(var item in Buecher)
            {
                if(item.Kategorie == kategorie)
                {
                    item.ZeigeInfo();
                    Console.WriteLine();
                }
            }
        }

        public void ZeigeAlleBuecher()
        {
            foreach(var item in Buecher)
            {
                item.ZeigeInfo();
                Console.WriteLine();
            }
        }
        #endregion
    }
}
