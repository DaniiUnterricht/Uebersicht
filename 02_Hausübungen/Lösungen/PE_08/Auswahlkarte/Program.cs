using System;
using Auswahlkarte.Tools;

namespace Auswahlkarte
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hier erstellen wir ein Jagged Array mit 3 Kategorien.
            //
            // Jede Kategorie ist ein eigenes string-Array.
            // Dadurch dürfen die Kategorien unterschiedlich viele Einträge haben.
            string[][] data = new string[3][];

            data[0] = new string[] { "Pizza", "Pasta" };
            data[1] = new string[] { "Cola", "Wasser", "Saft" };
            data[2] = new string[] { "Eis", "Kuchen" };

            Console.WriteLine("--- Menü ---");
            Console.WriteLine();

            // Die Ausgabe des gesamten Menüs wird in eine eigene Klasse ausgelagert.
            // Dadurch bleibt Program.cs übersichtlicher.
            JaggedArrayService.PrintJaggedArray(data);

            Console.WriteLine();

            // Der Benutzer wählt eine Kategorie.
            //
            // ZahlenInput gibt eine Zahl zwischen 1 und data.Length zurück.
            // Da Arrays aber bei 0 beginnen, rechnen wir -1.
            int kategorie = Input.ZahlenInput(1, data.Length, "Kategorie wählen: ") - 1;

            // Danach wählt der Benutzer ein Element aus der gewählten Kategorie.
            //
            // data[kategorie].Length gibt die Anzahl der Einträge
            // in der gewählten Kategorie zurück.
            int element = Input.ZahlenInput(1, data[kategorie].Length, "Element wählen: ") - 1;

            Console.WriteLine();

            // GetItem gibt den ausgewählten Eintrag zurück.
            Console.WriteLine($"Du hast gewählt: {JaggedArrayService.GetItem(data, kategorie, element)}");
        }
    }
}