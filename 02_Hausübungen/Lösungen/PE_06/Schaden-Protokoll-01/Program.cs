using System;

Console.WriteLine("Schaden-Protokoll-01");
Console.WriteLine("====================");
Console.WriteLine();

bool isTrue;
int lvl;

// Hier fragen wir ab, wie viele Level gespeichert werden sollen.
//
// int.TryParse verhindert,
// dass das Programm bei einer ungültigen Eingabe abstürzt.
//
// Die do-while-Schleife wiederholt die Eingabe so lange,
// bis eine gültige Ganzzahl eingegeben wurde.
do
{
    Console.Write("Anzahl Level: ");
    isTrue = int.TryParse(Console.ReadLine(), out lvl);

    if (!isTrue)
    {
        Console.WriteLine("Ungültige Eingabe!");
    }

} while (!isTrue);

// Hier erstellen wir ein zweidimensionales int-Array.
//
// Die erste Dimension steht für die Level.
// Die zweite Dimension steht für die Runden.
//
// Da jedes Level genau 3 Runden hat,
// steht in der zweiten Dimension fix die Zahl 3.
//
// Beispiel:
// rounds[0, 0] -> Level 1, Runde 1
// rounds[0, 1] -> Level 1, Runde 2
// rounds[0, 2] -> Level 1, Runde 3
// rounds[1, 0] -> Level 2, Runde 1
int[,] rounds = new int[lvl, 3];

Console.WriteLine();

// Für die Eingabe eines zweidimensionalen Arrays
// sind zwei for-Schleifen sinnvoll.
//
// Die äußere Schleife geht durch die Level.
// Die innere Schleife geht durch die Runden.
for (int i = 0; i < rounds.GetLength(0); i++)
{
    Console.WriteLine($"Level {i + 1}");

    for (int j = 0; j < rounds.GetLength(1); j++)
    {
        do
        {
            Console.Write($"Runde {j + 1}: ");
            isTrue = int.TryParse(Console.ReadLine(), out rounds[i, j]);

            if (!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe!");
            }

        } while (!isTrue);
    }

    Console.WriteLine();
}

// Diese Auswertung ist bewusst mit foreach gelöst.
//
// foreach geht bei einem zweidimensionalen Array
// alle Werte nacheinander durch.
//
// Wichtig:
// foreach kennt hier nicht automatisch,
// in welchem Level oder in welcher Runde wir gerade sind.
//
// Deshalb brauchen wir zusätzliche Zählvariablen,
// um nach jeder dritten Runde einen Zeilenabschluss zu erkennen.
int aktuelleRunde = 0;
int summeLevel = 0;
int gesamtsumme = 0;
int aktuellesLevel = 1;

foreach (int schaden in rounds)
{
    // Der aktuelle Schaden wird zur Summe des aktuellen Levels addiert.
    summeLevel = summeLevel + schaden;

    // Wir zählen mit, wie viele Runden im aktuellen Level bereits gelesen wurden.
    aktuelleRunde++;

    // Sobald aktuelleRunde gleich der Anzahl der Spalten ist,
    // wurden alle Runden eines Levels verarbeitet.
    //
    // rounds.GetLength(1) gibt hier die Anzahl der Runden pro Level zurück.
    if (aktuelleRunde == rounds.GetLength(1))
    {
        Console.WriteLine($"Schaden Level {aktuellesLevel}: {summeLevel}");

        // Die Summe des aktuellen Levels wird zur Gesamtsumme addiert.
        gesamtsumme = gesamtsumme + summeLevel;

        // Danach bereiten wir die Variablen für das nächste Level vor.
        aktuelleRunde = 0;
        summeLevel = 0;
        aktuellesLevel++;
    }
}

Console.WriteLine();
Console.WriteLine($"Gesamtschaden: {gesamtsumme}");