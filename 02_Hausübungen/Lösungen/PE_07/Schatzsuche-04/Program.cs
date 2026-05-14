using System;

Console.WriteLine("Schatzsuche-04");
Console.WriteLine("==============");
Console.WriteLine();

Random random = new Random();

// Die Anzahl der Reihen wird zufällig bestimmt.
//
// random.Next(2, 5) erzeugt eine Zahl von 2 bis 4.
// Die 2 ist inklusive.
// Die 5 ist exklusiv.
int anzahlReihen = random.Next(2, 5);

// Hier erstellen wir das Jagged Array.
//
// Wichtig:
// Wir legen hier nur fest, wie viele Reihen es gibt.
// Die einzelnen Reihen selbst werden erst später erstellt.
int[][] dungeon = new int[anzahlReihen][];

// Mit dieser for-Schleife wird jede Reihe des Dungeons erstellt.
//
// Jede Reihe wird durch die Methode ErstelleReihe()
// erzeugt und danach im Jagged Array gespeichert.
for (int i = 0; i < dungeon.Length; i++)
{
    dungeon[i] = ErstelleReihe();
}

// Hier rufen wir die Methode auf,
// die alle Schätze im gesamten Dungeon zählt.
int schaetze = ZaehleSchaetze(dungeon);

Console.WriteLine($"Schätze insgesamt: {schaetze}");
Console.WriteLine();

Console.WriteLine("Dungeon:");

// Für die Ausgabe eines Jagged Arrays brauchen wir zwei Schleifen.
//
// Die äußere Schleife geht durch die Reihen.
// Die innere Schleife geht durch die Felder der aktuellen Reihe.
for (int i = 0; i < dungeon.Length; i++)
{
    for (int j = 0; j < dungeon[i].Length; j++)
    {
        Console.Write(dungeon[i][j] + " ");
    }

    Console.WriteLine();
}

// Diese Methode erstellt eine einzelne Dungeon-Reihe.
//
// Sie bekommt keine Parameter.
// Sie erzeugt eine zufällige Länge von 2 bis 4.
// Danach befüllt sie jedes Feld zufällig mit 0 oder 1.
// Am Ende gibt sie die fertige Reihe zurück.
static int[] ErstelleReihe()
{
    Random random = new Random();

    // random.Next(2, 5) erzeugt eine Zahl von 2 bis 4.
    int laenge = random.Next(2, 5);

    int[] reihe = new int[laenge];

    for (int i = 0; i < reihe.Length; i++)
    {
        // random.Next(0, 2) erzeugt entweder 0 oder 1.
        //
        // 0 = leer
        // 1 = Schatz
        reihe[i] = random.Next(0, 2);
    }

    return reihe;
}

// Diese Methode zählt alle Schätze im gesamten Dungeon.
//
// Sie bekommt das komplette Jagged Array als Parameter.
// Danach geht sie durch jede Reihe und jedes Feld.
// Jedes Feld mit dem Wert 1 wird als Schatz gezählt.
// Am Ende gibt sie die Gesamtanzahl zurück.
static int ZaehleSchaetze(int[][] dungeon)
{
    int anzahl = 0;

    for (int i = 0; i < dungeon.Length; i++)
    {
        for (int j = 0; j < dungeon[i].Length; j++)
        {
            if (dungeon[i][j] == 1)
            {
                anzahl++;
            }
        }
    }

    return anzahl;
}