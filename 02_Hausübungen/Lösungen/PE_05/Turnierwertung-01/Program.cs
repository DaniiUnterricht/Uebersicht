using System;

Console.WriteLine("Turnierwertung");
Console.WriteLine("==============");
Console.WriteLine();

// Hier erstellen wir ein int-Array mit 5 Speicherplätzen.
// In diesem Array werden später die Punkte der 5 Runden gespeichert.
//
// Wichtig:
// Ein Array hat eine feste Größe.
// Diese Größe wird hier mit [5] festgelegt.
int[] punkte = new int[5];

// Mit dieser for-Schleife lesen wir die Punkte der 5 Runden ein.
//
// i startet bei 0.
// Die Schleife läuft so lange, wie i kleiner als punkte.Length ist.
// punkte.Length gibt die Länge des Arrays zurück.
//
// Bei einem Array mit 5 Elementen sind die gültigen Indizes:
// 0, 1, 2, 3, 4
for (int i = 0; i < punkte.Length; i++)
{
    Console.Write($"Punkte Runde {i + 1}: ");
    bool isTrue = int.TryParse(Console.ReadLine(), out punkte[i]);

    // Wenn die Eingabe keine gültige Ganzzahl war,
    // wird eine Fehlermeldung ausgegeben.
    //
    // Mit i-- sorgen wir dafür,
    // dass dieselbe Runde erneut abgefragt wird.
    if (isTrue == false)
    {
        Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
        i--;
    }
}

Console.WriteLine();
Console.WriteLine("Punkte:");

int summe = 0;

// Die höchste und niedrigste Punktzahl setzen wir zuerst
// auf den ersten eingegebenen Wert.
//
// Dadurch haben wir einen sinnvollen Startwert,
// mit dem die restlichen Werte verglichen werden können.
int hoechsteRunde = punkte[0];
int niedrigsteRunde = punkte[0];

int rundenMindestens10 = 0;

// Mit dieser for-Schleife gehen wir alle gespeicherten Punkte durch.
// Dabei führen wir mehrere Auswertungen gleichzeitig durch:
//
// 1. Punkte ausgeben
// 2. Gesamtpunkte berechnen
// 3. höchste Runde finden
// 4. niedrigste Runde finden
// 5. Runden mit mindestens 10 Punkten zählen
for (int i = 0; i < punkte.Length; i++)
{
    Console.WriteLine(punkte[i]);

    // Punkte zur Gesamtsumme addieren.
    summe = summe + punkte[i];

    // Prüfen, ob die aktuelle Runde mehr Punkte hat
    // als die bisher höchste gespeicherte Runde.
    if (punkte[i] > hoechsteRunde)
    {
        hoechsteRunde = punkte[i];
    }

    // Prüfen, ob die aktuelle Runde weniger Punkte hat
    // als die bisher niedrigste gespeicherte Runde.
    if (punkte[i] < niedrigsteRunde)
    {
        niedrigsteRunde = punkte[i];
    }

    // Wenn die aktuelle Runde mindestens 10 Punkte hat,
    // erhöhen wir den Zähler um 1.
    if (punkte[i] >= 10)
    {
        rundenMindestens10++;
    }
}

Console.WriteLine();
Console.WriteLine($"Gesamtpunkte: {summe}");
Console.WriteLine($"Höchste Runde: {hoechsteRunde}");
Console.WriteLine($"Niedrigste Runde: {niedrigsteRunde}");
Console.WriteLine($"Runden mit mindestens 10 Punkten: {rundenMindestens10}");