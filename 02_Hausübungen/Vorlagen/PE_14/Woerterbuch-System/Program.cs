using System;
using WoerterbuchSystem;

namespace WoerterbuchSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            int auswahl;

            Dictionary<string, string> woerterbuch = new Dictionary<string, string>()
                {
                    { "Haus", "house" },
                    { "Baum", "tree" },
                    { "Auto", "car" },
                    { "Hund", "dog" }
                };

            do
            {
                auswahl = Methoden.Menue();

                switch (auswahl)
                {
                    case 1:
                        Methoden.WoerterAnzeigen(woerterbuch);
                        break;

                    case 2:
                        Methoden.WortHinzufuegen(woerterbuch);
                        break;

                    case 3:
                        Methoden.WortSuchen(woerterbuch);
                        break;

                    case 4:
                        Methoden.WortEntfernen(woerterbuch);
                        break;
                }

            } while (auswahl != 5);
        }
    }
}


