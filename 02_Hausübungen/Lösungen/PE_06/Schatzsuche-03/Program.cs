using System;

Console.WriteLine("Schatzsuche-03");
Console.WriteLine("==============");
Console.WriteLine();

Random random = new Random();

// Hier erstellen wir ein zweidimensionales int-Array.
// Die erste Zahl steht für die Zeilen.
// Die zweite Zahl steht für die Spalten.
//
// int[3, 3] bedeutet also:
// 3 Zeilen und 3 Spalten.
int[,] dungeon = new int[3, 3];

int anzahlSchatztruhen = random.Next(1, 5);

// Mit dieser Variable zählen wir,
// wie viele Schatztruhen bereits platziert wurden.
int platzierteSchatztruhen = 0;

// Diese while-Schleife läuft so lange,
// bis die gewünschte Anzahl an Schatztruhen platziert wurde.
while (platzierteSchatztruhen < anzahlSchatztruhen)
{
    int zeile = random.Next(0, 3);
    int spalte = random.Next(0, 3);

    // Hier prüfen wir, ob das zufällig gewählte Feld noch leer ist.
    //
    // 0 bedeutet leer.
    // 1 bedeutet Schatztruhe.
    //
    // Dadurch verhindern wir,
    // dass zwei Schatztruhen auf dasselbe Feld gesetzt werden.
    if (dungeon[zeile, spalte] == 0)
    {
        dungeon[zeile, spalte] = 1;
        platzierteSchatztruhen++;
    }
}

// Mit foreach gehen wir durch alle Werte im Array.
// Bei einem zweidimensionalen Array durchläuft foreach
// trotzdem jedes einzelne Feld.
int schatztruhen = 0;

foreach (int feld in dungeon)
{
    if (feld == 1)
    {
        schatztruhen++;
    }
}

Console.WriteLine($"Schatztruhen: {schatztruhen}");
Console.WriteLine();

bool isTrue;
int userZeile;

do
{
    Console.Write("Zeile wählen ( 1-3 ): ");
    isTrue = int.TryParse(Console.ReadLine(), out userZeile);

    if (!isTrue || userZeile < 1 || userZeile > 3)
    {
        Console.WriteLine("Ungültige Eingabe!");
        isTrue = false;
    }

} while (!isTrue);

int userSpalte;

do
{
    Console.Write("Spalte wählen ( 1-3 ): ");
    isTrue = int.TryParse(Console.ReadLine(), out userSpalte);

    if (!isTrue || userSpalte < 1 || userSpalte > 3)
    {
        Console.WriteLine("Ungültige Eingabe!");
        isTrue = false;
    }

} while (!isTrue);

Console.WriteLine();

// Der Benutzer gibt Zeile und Spalte von 1 bis 3 ein.
// Arrays beginnen aber bei Index 0.
//
// Deshalb müssen wir jeweils -1 rechnen.
//
// Beispiel:
// Eingabe Zeile 1 wird zu Index 0.
// Eingabe Spalte 2 wird zu Index 1.
int arrayZeile = userZeile - 1;
int arraySpalte = userSpalte - 1;

// Hier prüfen wir,
// ob an der gewählten Position eine Schatztruhe liegt.
if (dungeon[arrayZeile, arraySpalte] == 1)
{
    Console.WriteLine("Schatz gefunden!");
}
else
{
    Console.WriteLine("Kein Schatz gefunden!");
}

Console.WriteLine();
Console.WriteLine("Dungeon:");

// Für die Ausgabe eines zweidimensionalen Arrays
// sind zwei for-Schleifen sinnvoll.
//
// Die äußere Schleife geht durch die Zeilen.
// Die innere Schleife geht durch die Spalten.
for (int i = 0; i < dungeon.GetLength(0); i++)
{
    for (int j = 0; j < dungeon.GetLength(1); j++)
    {
        Console.Write(dungeon[i, j] + " ");
    }

    Console.WriteLine();
}