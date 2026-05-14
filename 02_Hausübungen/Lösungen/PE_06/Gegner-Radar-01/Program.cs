using System;

Random random = new Random();

Console.WriteLine("Gegner-Radar-01");
Console.WriteLine("===============");
Console.WriteLine();

// Diese Variablen bestimmen die Größe des Spielfeldes
// und wie viele Gegner maximal auf einem Feld stehen können.
//
// Das ist praktisch, wenn man diese Werte später ändern möchte.
// Dann muss man nicht überall im Code einzelne Zahlen suchen.
int maxGegner = 3;
int zeilen = 2;
int spalten = 3;

// Hier erstellen wir ein zweidimensionales int-Array.
//
// Die erste Dimension steht für die Zeilen.
// Die zweite Dimension steht für die Spalten.
int[,] feld = new int[zeilen, spalten];

// Für das Befüllen eines zweidimensionalen Arrays
// sind zwei for-Schleifen sinnvoll.
//
// Die äußere Schleife geht durch die Zeilen.
// Die innere Schleife geht durch die Spalten.
//
// random.Next(0, maxGegner + 1) erzeugt eine Zahl von 0 bis maxGegner.
// Da die zweite Zahl bei random.Next exklusiv ist,
// müssen wir +1 rechnen, damit maxGegner auch vorkommen kann.
for (int i = 0; i < feld.GetLength(0); i++)
{
    for (int j = 0; j < feld.GetLength(1); j++)
    {
        feld[i, j] = random.Next(0, maxGegner + 1);
    }
}

Console.WriteLine("Feld");

int aktuelleSpalte = 0;
int summe = 0;

// Mit foreach gehen wir durch alle Werte im Array.
// Bei einem zweidimensionalen Array durchläuft foreach
// trotzdem jedes einzelne Feld.
//
// Das ist hier praktisch,
// weil wir jeden Wert ausgeben und zur Summe addieren wollen.
foreach (int gegner in feld)
{
    Console.Write(gegner + " ");

    // Da die Zahl im Feld angibt,
    // wie viele Gegner dort stehen,
    // können wir sie direkt zur Gesamtsumme addieren.
    summe = summe + gegner;

    aktuelleSpalte++;

    // Sobald so viele Werte ausgegeben wurden,
    // wie das Feld Spalten hat,
    // machen wir einen Zeilenumbruch.
    if (aktuelleSpalte == feld.GetLength(1))
    {
        Console.WriteLine();
        aktuelleSpalte = 0;
    }
}

Console.WriteLine();
Console.WriteLine($"Gegner gesamt: {summe}");