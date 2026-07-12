using System;

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


            Classes.Uebung1.Bankkonto bankkonto = new Classes.Uebung1.Bankkonto();

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
            #endregion

        }
    }
}
