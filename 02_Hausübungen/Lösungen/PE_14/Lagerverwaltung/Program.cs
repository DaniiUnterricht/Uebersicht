using System;
using System.Collections.Generic;
using Lagerverwaltung;

namespace Lagerverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            int auswahl;

            Dictionary<string, int> lager = new Dictionary<string, int>()
            {
                { "Monitor", 5 },
                { "Tastatur", 12 },
                { "Maus", 20 },
                { "Headset", 7 }
            };

            do
            {
                auswahl = Methoden.Menue();

                switch (auswahl)
                {
                    case 1:
                        Methoden.ProdukteAnzeigen(lager);
                        break;

                    case 2:
                        Methoden.ProduktHinzufuegen(lager);
                        break;

                    case 3:
                        Methoden.BestandErhoehen(lager);
                        break;

                    case 4:
                        Methoden.BestandVerringern(lager);
                        break;

                    case 5:
                        Methoden.ProduktEntfernen(lager);
                        break;
                }

            } while (auswahl != 6);
        }
    }
}
