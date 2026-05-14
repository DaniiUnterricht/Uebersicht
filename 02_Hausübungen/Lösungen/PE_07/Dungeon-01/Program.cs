using System;

Console.WriteLine("Dungeon-01");
Console.WriteLine("==========");
Console.WriteLine();

Random random = new Random();

// Die Anzahl der Reihen wird zufällig bestimmt.
// random.Next(1, 11) erzeugt eine Zahl von 1 bis 10.
int anzahlReihen = random.Next(1, 11);

// Hier erstellen wir ein Jagged Array.
//
// Ein Jagged Array ist ein Array,
// das in jeder Reihe wieder ein eigenes Array enthält.
//
// Wichtig:
// Die einzelnen Reihen können unterschiedlich lang sein.
int[][] dungeon = new int[anzahlReihen][];

// Mit dieser for-Schleife gehen wir durch alle Reihen des Jagged Arrays.
//
// dungeon.Length gibt die Anzahl der Reihen zurück.
//
// Jede einzelne Reihe wird mit der Methode ErstelleReihe()
// erzeugt und im Jagged Array gespeichert.
for (int i = 0; i < dungeon.Length; i++)
{
    dungeon[i] = ErstelleReihe();
}

// Mit dieser for-Schleife gehen wir erneut durch alle Reihen.
//
// Für jede Reihe wird mit der Methode ZaehleMonster()
// gezählt, wie viele Monster enthalten sind.
for (int i = 0; i < dungeon.Length; i++)
{
    int monster = ZaehleMonster(dungeon[i]);

    Console.WriteLine($"Reihe {i + 1} enthält {monster} Monster");
}

// Diese Methode erstellt eine einzelne Reihe für den Dungeon.
//
// Sie bekommt keine Parameter.
// Sie erstellt ein int-Array mit zufälliger Länge.
// Sie befüllt dieses Array zufällig mit Monstern.
// Danach gibt sie die fertige Reihe zurück.
static int[] ErstelleReihe()
{
    Random random = new Random();

    // Die Länge der Reihe wird zufällig bestimmt.
    // random.Next(3, 11) erzeugt eine Zahl von 3 bis 10.
    int feldAnzahl = random.Next(3, 11);

    int[] reihe = new int[feldAnzahl];

    // Die Anzahl der Monster wird zufällig bestimmt.
    // Es soll mindestens 1 Monster geben.
    // Maximal so viele Monster, wie Felder vorhanden sind.
    int monsterAnzahl = random.Next(1, feldAnzahl + 1);

    int platzierteMonster = 0;

    // Diese while-Schleife läuft so lange,
    // bis die gewünschte Anzahl an Monstern platziert wurde.
    while (platzierteMonster < monsterAnzahl)
    {
        int position = random.Next(0, reihe.Length);

        // 0 bedeutet leer.
        // 1 bedeutet Monster.
        //
        // Hier prüfen wir, ob das Feld noch leer ist.
        // Dadurch verhindern wir,
        // dass ein Monster doppelt auf dieselbe Position gesetzt wird.
        if (reihe[position] == 0)
        {
            reihe[position] = 1;
            platzierteMonster++;
        }
    }

    return reihe;
}

// Diese Methode zählt die Monster in einer einzelnen Reihe.
//
// Sie bekommt eine Reihe als Parameter.
// Sie durchläuft alle Felder dieser Reihe.
// Jedes Feld mit dem Wert 1 wird gezählt.
// Am Ende gibt sie die Anzahl der Monster zurück.
static int ZaehleMonster(int[] reihe)
{
    int monster = 0;

    for (int i = 0; i < reihe.Length; i++)
    {
        if (reihe[i] == 1)
        {
            monster++;
        }
    }

    return monster;
}