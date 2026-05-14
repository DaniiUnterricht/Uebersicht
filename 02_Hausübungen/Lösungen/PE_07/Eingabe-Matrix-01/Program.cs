using System;

Console.WriteLine("Eingabe-Matrix-01");
Console.WriteLine("=================");
Console.WriteLine();

// Die Anzahl der Reihen ist hier vorgegeben.
// Jede Reihe kann später aber unterschiedlich viele Werte enthalten.
int anzahlReihen = 3;

// Hier erstellen wir ein Jagged Array mit 3 Reihen.
//
// Wichtig:
// Die einzelnen Reihen selbst existieren hier noch nicht.
// Es wurde nur festgelegt, dass es 3 Reihen geben soll.
int[][] matrix = new int[anzahlReihen][];

// Mit dieser for-Schleife gehen wir jede Reihe durch.
//
// Für jede Reihe wird zuerst abgefragt,
// wie viele Werte sie enthalten soll.
for (int i = 0; i < matrix.Length; i++)
{
    int anzahlWerte = LiesZahlEin($"Wie viele Werte für Reihe {i + 1}: ");

    // Jetzt erstellen wir die aktuelle Reihe
    // mit genau der Länge, die der Benutzer eingegeben hat.
    matrix[i] = new int[anzahlWerte];

    // Danach werden alle Werte dieser Reihe eingelesen.
    for (int j = 0; j < matrix[i].Length; j++)
    {
        matrix[i][j] = LiesZahlEin("Wert eingeben: ");
    }

    Console.WriteLine();
}

Console.WriteLine("Daten:");

// Für die Ausgabe eines Jagged Arrays
// brauchen wir wieder zwei Schleifen.
//
// Die äußere Schleife geht durch die Reihen.
// Die innere Schleife geht durch die Werte der aktuellen Reihe.
for (int i = 0; i < matrix.Length; i++)
{
    for (int j = 0; j < matrix[i].Length; j++)
    {
        Console.Write(matrix[i][j] + " ");
    }

    Console.WriteLine();
}

// Diese Methode bekommt einen Text als Parameter.
//
// Dieser Text wird als Eingabeaufforderung ausgegeben.
// Danach wird so lange eine Eingabe abgefragt,
// bis der Benutzer eine gültige Ganzzahl eingibt.
//
// Am Ende gibt die Methode die gültige Zahl zurück.
static int LiesZahlEin(string text)
{
    bool isTrue;
    int zahl;

    do
    {
        Console.Write(text);
        isTrue = int.TryParse(Console.ReadLine(), out zahl);

        if (!isTrue)
        {
            Console.WriteLine("Ungültige Eingabe!");
        }

    } while (!isTrue);

    return zahl;
}