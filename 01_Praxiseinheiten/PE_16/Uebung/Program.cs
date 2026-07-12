using System;
using Uebung.Classes.Uebung4;

namespace Uebung
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Übung1
            Console.WriteLine("Übung 1");
            Console.WriteLine("=======");
            Console.WriteLine();
            /* Übung 1: Bankkonto kapseln
             * Properties: Inhaber, Kontostand
             * Kontostand darf von außen nur gelesen werden.
             * Der Startwert beträgt 0.
             * Die Methode Einzahlen(decimal betrag) nimmt nur positive Beträge an.
             * Die Methode Abheben(decimal betrag) verhindert negative Beträge und ein Überziehen des Kontos.
             * Die Methode ZeigeInfo() gibt Inhaber und Kontostand aus.
             */


            Classes.Uebung1.Bankkonto bankkonto = new Classes.Uebung1.Bankkonto("Dani");

            bankkonto.Einzahlen((decimal)120.50);
            bankkonto.Abheben((decimal)20.00);
            bankkonto.ZeigeInfo();
            #endregion

            #region Übung2
            Console.WriteLine();
            Console.WriteLine("=======");
            Console.WriteLine("Übung 2");
            Console.WriteLine("=======");
            Console.WriteLine();
            /* Übung 2: Spieler und Heiltrank
             * Erstelle die Klassen Spieler und Heiltrank
             * Der Heiltrank besitzt: Name / Heilwert
             * Der Spieler besitzt: Name / Leben / MaxLeben
             * Erstelle im Spieler die Methode: public void TrankVerwenden(Heiltrank trank)
             * Die Methode soll den Spieler um den Heilwert des Tranks heilen. Das Leben darf MaxLeben nicht überschreiten.
             */

            Classes.Uebung2.Spieler spieler = new Classes.Uebung2.Spieler("Nils", 500);
            Classes.Uebung2.Heiltrank h1 = new Classes.Uebung2.Heiltrank("Kleiner Heiltrank", 50);
            Classes.Uebung2.Heiltrank h2 = new Classes.Uebung2.Heiltrank("Großer Heiltrank", 100);

            Console.WriteLine($"{spieler.Name} hat {spieler.Leben} von {spieler.MaxLeben} Leben");
            spieler.TrankVerwenden(h1);
            Console.WriteLine($"{spieler.Name} hat {spieler.Leben} von {spieler.MaxLeben} Leben");
            spieler.TrankVerwenden(h2);
            Console.WriteLine($"{spieler.Name} hat {spieler.Leben} von {spieler.MaxLeben} Leben");

            #endregion

            #region Übung3
            Console.WriteLine();
            Console.WriteLine("=======");
            Console.WriteLine("Übung 3");
            Console.WriteLine("=======");
            Console.WriteLine();
            /* Übung 3: Inventar
             * Erstelle eine KLasse Item mit: Name / Wert
             * Erstelle eine Klasse Spieler mit: Name / Inventar
             * Methoden in der Klasse Spieler bereits vordefiniert
             * GesamtwertBerechnen() soll den Wert aller Item addieren und zurückgeben
             */

            Classes.Uebung3.Spieler spieler1 = new Classes.Uebung3.Spieler("Michael");
            Classes.Uebung3.Item item1 = new Classes.Uebung3.Item("Goldsack", 1000);
            Classes.Uebung3.Item item2 = new Classes.Uebung3.Item("Diamantaxt", 300);
            Classes.Uebung3.Item item3 = new Classes.Uebung3.Item("Eisenbaren", 120);

            spieler1.ItemAufnehmen(item1);
            spieler1.InventarAusgeben();
            spieler1.ItemAufnehmen(item2);
            spieler1.InventarAusgeben();
            spieler1.ItemAufnehmen(item3);
            spieler1.InventarAusgeben();

            spieler1.GesamtwertBerechnen();

            #endregion

            #region Übung4
            Console.WriteLine();
            Console.WriteLine("=======");
            Console.WriteLine("Übung 4");
            Console.WriteLine("=======");
            Console.WriteLine();

            /* Übung4: Kleines Kampfsystem
             * Erstelle einen Spieler und mindestens drei Gegner.
             * Speichere die Gegner in einer Liste: List<Gegner> gegnerListe = new List<Gegner>();
             * Der Spieler soll nacheinander gegen alle Gegner kämpfen.
             * 
             * Nach jedem Kampf soll ausgegeben werden:
             * - verbleibendes Leben des Spielers
             * - ob der Gegner besiegt wurde
             * - erhaltenes Gold
             * 
             * Der nächste Kampf darf nur beginnen, wenn der Spieler noch lebt.
             */

            Classes.Uebung4.Spieler spieler2 = new Classes.Uebung4.Spieler("Pezi", 400, 50);

            List<Gegner> gegnerListe = new List<Gegner>();
            gegnerListe.Add(new Classes.Uebung4.Gegner("Dani", 100, 20, 30));
            gegnerListe.Add(new Classes.Uebung4.Gegner("Michael", 200, 10, 30));
            gegnerListe.Add(new Classes.Uebung4.Gegner("Nils", 110, 30, 50));

            foreach(var gegner in gegnerListe)
            {
                Console.WriteLine($"Kampf gegen {gegner.Name} mit {gegner.Leben}");
                while(gegner.StillAlive() && spieler2.StillAlive())
                {
                    spieler2.Damagedealer(gegner);
        
                    if(gegner.StillAlive())
                    {
                        gegner.Damagedealer(spieler2);
                    }
                }

                if(!spieler2.StillAlive())
                {
                    Console.WriteLine("Leider gestorben!");
                    break;
                }
                Console.WriteLine($"verbleibende Leben: {spieler2.Leben}");
            }

            if(spieler2.StillAlive())
            {
                Console.WriteLine("Gewonnen");
            }
            #endregion

        }
    }
}
