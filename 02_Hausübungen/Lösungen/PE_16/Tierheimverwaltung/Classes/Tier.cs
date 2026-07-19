using System;
using System.Collections.Generic;
using System.Text;

namespace Tierheimverwaltung.Classes
{
    public class Tier
    {
        #region Properties

        public string Name { get; private set; }
        public string Tierart { get; private set; }
        public int Alter { get; private set; }
        public bool IstVermittelt { get; private set; }

        #endregion

        #region Konstruktor

        public Tier(string name, string tierart, int alter)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name des Tieres darf nicht leer sein.", nameof(name));
            }

            if (string.IsNullOrWhiteSpace(tierart))
            {
                throw new ArgumentException("Die Tierart darf nicht leer sein.", nameof(tierart));
            }

            if (alter < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(alter), "Das Alter darf nicht negativ sein.");
            }

            Name = name;
            Tierart = tierart;
            Alter = alter;
            IstVermittelt = false;
        }

        #endregion

        #region Methoden

        public void Geburtstag()
        {
            Alter++;

            Console.WriteLine($"{Name} hatte Geburtstag und ist jetzt {Alter} Jahre alt.");
        }

        public bool Vermitteln()
        {
            if (IstVermittelt)
            {
                Console.WriteLine($"{Name} wurde bereits vermittelt.");

                return false;
            }

            IstVermittelt = true;

            Console.WriteLine($"{Name} wurde erfolgreich vermittelt.");

            return true;
        }

        public void ZeigeInfo()
        {
            string status = IstVermittelt ? "Bereits vermittelt" : "Noch nicht vermittelt";

            Console.WriteLine($"{Name} – {Tierart} – {Alter} Jahre – {status}");
        }

        #endregion
    }
}
