using System;
using System.Collections.Generic;
using InventarSystem;

namespace InventarSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int auswahl;

            Dictionary<string, int> inventar = new Dictionary<string, int>()
            {
                { "Heiltrank", 3 },
                { "Mana-Trank", 2 },
                { "Gold", 150 },
                { "Schlüssel", 1 }
            };

            do
            {
                auswahl = Methoden.Menue();

                switch (auswahl)
                {
                    case 1:
                        Methoden.InventarAnzeigen(inventar);
                        break;

                    case 2:
                        Methoden.ItemHinzufuegen(inventar);
                        break;

                    case 3:
                        Methoden.ItemAnzahlErhoehen(inventar);
                        break;

                    case 4:
                        Methoden.ItemAnzahlVerringern(inventar);
                        break;

                    case 5:
                        Methoden.ItemEntfernen(inventar);
                        break;
                }

            } while (auswahl != 6);
        }
    }
}
