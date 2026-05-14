using System;

bool isTrue;
int lvl, rounds;

Console.WriteLine("Leben-System-01");
Console.WriteLine("===============");
Console.WriteLine();

// Hier fragen wir ab, wie viele Level gespeichert werden sollen.
//
// int.TryParse verhindert,
// dass das Programm bei einer ungültigen Eingabe abstürzt.
//
// Die do-while-Schleife wiederholt die Eingabe so lange,
// bis eine gültige Ganzzahl eingegeben wurde.
do
{
    Console.Write("Wie viele Level gibt es: ");
    isTrue = int.TryParse(Console.ReadLine(), out lvl);

    if (!isTrue)
    {
        Console.WriteLine("Ungültige Eingabe");
    }

} while (!isTrue);

// Hier fragen wir ab, wie viele Runden jedes Level haben soll.
//
// Auch hier verwenden wir eine do-while-Schleife,
// damit bei einer ungültigen Eingabe erneut gefragt wird.
do
{
    Console.Write("Wie viele Runden gibt es: ");
    isTrue = int.TryParse(Console.ReadLine(), out rounds);

    if (!isTrue)
    {
        Console.WriteLine("Ungültige Eingabe");
    }

} while (!isTrue);

// Hier erstellen wir ein zweidimensionales int-Array.
//
// Die erste Dimension steht für die Level.
// Die zweite Dimension steht für die Runden.
//
// Beispiel:
// leben[0, 0] -> Level 1, Runde 1
// leben[0, 1] -> Level 1, Runde 2
// leben[1, 0] -> Level 2, Runde 1
int[,] leben = new int[lvl, rounds];

Console.WriteLine();

// Für die Eingabe eines zweidimensionalen Arrays
// sind zwei for-Schleifen sinnvoll.
//
// Die äußere Schleife geht durch die Level.
// Die innere Schleife geht durch die Runden.
for (int i = 0; i < leben.GetLength(0); i++)
{
    Console.WriteLine($"Level {i + 1}");

    for (int j = 0; j < leben.GetLength(1); j++)
    {
        do
        {
            Console.Write($"Runde {j + 1}: ");
            isTrue = int.TryParse(Console.ReadLine(), out leben[i, j]);

            if (!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe");
            }

        } while (!isTrue);
    }

    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("--------");
Console.WriteLine();

// Jetzt werten wir die gespeicherten Lebenswerte aus.
//
// Pro Level soll ausgegeben werden:
// - Startleben
// - gesamte Heilung
// - gesamter Schaden
for (int i = 0; i < leben.GetLength(0); i++)
{
    Console.WriteLine($"Level {i + 1}");

    // Das Startleben ist der Wert aus der ersten Runde des aktuellen Levels.
    Console.WriteLine($"Startleben: {leben[i, 0]}");

    int heilung = 0;
    int schaden = 0;

    // Wir starten hier bei j = 1,
    // weil wir immer die aktuelle Runde mit der vorherigen Runde vergleichen.
    //
    // Beispiel:
    // j = 1 -> Runde 2 wird mit Runde 1 verglichen
    // j = 2 -> Runde 3 wird mit Runde 2 verglichen
    for (int j = 1; j < leben.GetLength(1); j++)
    {
        // Wenn der vorherige Lebenswert größer ist als der aktuelle,
        // hat der Spieler Leben verloren.
        //
        // Beispiel:
        // vorher: 10
        // aktuell: 4
        // Schaden: 10 - 4 = 6
        if (leben[i, j - 1] > leben[i, j])
        {
            schaden = schaden + (leben[i, j - 1] - leben[i, j]);
        }
        else
        {
            // Wenn der aktuelle Lebenswert größer oder gleich ist,
            // wurde der Spieler geheilt oder der Wert ist gleich geblieben.
            //
            // Beispiel:
            // vorher: 3
            // aktuell: 10
            // Heilung: 10 - 3 = 7
            heilung = heilung + (leben[i, j] - leben[i, j - 1]);
        }
    }

    Console.WriteLine($"Heilung: {heilung}");
    Console.WriteLine($"Schaden: {schaden}");
    Console.WriteLine();
}

// Das Endleben ist der letzte Wert im zweidimensionalen Array.
//
// leben.GetLength(0) gibt die Anzahl der Level zurück.
// leben.GetLength(1) gibt die Anzahl der Runden zurück.
//
// Da Arrays bei 0 beginnen,
// müssen wir jeweils -1 rechnen.
Console.WriteLine($"Endleben: {leben[leben.GetLength(0) - 1, leben.GetLength(1) - 1]}");