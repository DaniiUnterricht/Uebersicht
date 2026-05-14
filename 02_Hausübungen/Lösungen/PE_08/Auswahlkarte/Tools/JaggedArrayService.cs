using System;

namespace Auswahlkarte.Tools
{
    class JaggedArrayService
    {
        // Diese Methode gibt das gesamte Jagged Array aus.
        //
        // data ist das komplette Menü.
        // Jede Reihe in data ist eine Kategorie.
        public static void PrintJaggedArray(string[][] data)
        {
            // Mit dieser for-Schleife gehen wir durch alle Kategorien.
            //
            // data.Length gibt die Anzahl der Kategorien zurück.
            for (int i = 0; i < data.Length; i++)
            {
                // Für jede Kategorie rufen wir eine eigene Methode auf.
                //
                // data[i] ist die aktuelle Kategorie.
                // i + 1 ist die sichtbare Nummer für den Benutzer.
                PrintCategory(data[i], i + 1);
            }
        }

        // Diese Methode gibt eine einzelne Kategorie aus.
        //
        // category enthält alle Einträge dieser Kategorie.
        // index ist die Nummer, die vor der Kategorie angezeigt wird.
        public static void PrintCategory(string[] category, int index)
        {
            Console.Write(index + ": ");

            // Mit dieser for-Schleife geben wir alle Einträge
            // der aktuellen Kategorie aus.
            for (int i = 0; i < category.Length; i++)
            {
                Console.Write(category[i]);

                // Nach jedem Eintrag soll ein Komma ausgegeben werden,
                // aber nicht nach dem letzten Eintrag.
                if (i < category.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }

        // Diese Methode gibt ein bestimmtes Element aus dem Jagged Array zurück.
        //
        // data          -> gesamtes Jagged Array
        // categoryIndex -> Index der gewählten Kategorie
        // itemIndex     -> Index des gewählten Elements
        //
        // Beispiel:
        // data[1][2] bedeutet:
        // Kategorie 2, Element 3
        public static string GetItem(string[][] data, int categoryIndex, int itemIndex)
        {
            return data[categoryIndex][itemIndex];
        }
    }
}