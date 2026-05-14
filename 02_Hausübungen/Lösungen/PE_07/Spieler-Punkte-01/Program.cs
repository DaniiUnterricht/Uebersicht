using System;

Console.WriteLine("Spieler-Punkte-01");
Console.WriteLine("=================");
Console.WriteLine();

// Hier erstellen wir ein Jagged Array.
//
// Jeder Spieler hat ein eigenes int-Array.
// Da es ein Jagged Array ist,
// dürfen diese Arrays unterschiedlich lang sein.
//
// Das passt hier gut,
// weil nicht jeder Spieler gleich viele Runden gespielt haben muss.
int[][] spielerPunkte = new int[3][];

// Die einzelnen Spieler werden hier selbst befüllt.
//
// Spieler 1 hat 3 Runden gespielt.
// Spieler 2 hat 2 Runden gespielt.
// Spieler 3 hat 4 Runden gespielt.
spielerPunkte[0] = new int[] { 10, 5, 15 };
spielerPunkte[1] = new int[] { 7, 8 };
spielerPunkte[2] = new int[] { 4, 6, 10, 4 };

// Mit dieser for-Schleife gehen wir durch alle Spieler.
//
// spielerPunkte.Length gibt die Anzahl der Spieler zurück.
// spielerPunkte[i] ist immer das Punkte-Array des aktuellen Spielers.
for (int i = 0; i < spielerPunkte.Length; i++)
{
    int gesamtpunkte = BerechneSumme(spielerPunkte[i]);

    Console.WriteLine($"Spieler {i + 1} hat {gesamtpunkte} Punkte erreicht");
}

// Diese Methode bekommt ein int-Array als Parameter.
//
// In diesem Array stehen die Punkte eines Spielers.
// Die Methode berechnet die Summe dieser Punkte
// und gibt die Summe als int zurück.
static int BerechneSumme(int[] punkte)
{
    int summe = 0;

    // Mit dieser for-Schleife gehen wir alle Punkte
    // des übergebenen Arrays durch.
    for (int i = 0; i < punkte.Length; i++)
    {
        summe = summe + punkte[i];
    }

    return summe;
}