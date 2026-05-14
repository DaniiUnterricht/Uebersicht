using System;

Console.WriteLine("Inventar");
Console.WriteLine("========");
Console.WriteLine();

// Hier erstellen wir ein string-Array mit 4 Speicherplätzen.
// In diesem Array werden später die Gegenstände gespeichert.
//
// Wichtig:
// Ein Array hat eine feste Größe.
// Diese Größe wird hier mit [4] festgelegt.
string[] inventar = new string[4];

// Mit dieser for-Schleife lesen wir die 4 Gegenstände ein.
//
// i startet bei 0.
// Die Schleife läuft so lange, wie i kleiner als inventar.Length ist.
// inventar.Length gibt die Länge des Arrays zurück.
//
// Bei einem Array mit 4 Elementen sind die gültigen Indizes:
// 0, 1, 2, 3
for (int i = 0; i < inventar.Length; i++)
{
    Console.Write($"Gegenstand {i + 1} eingeben: ");
    inventar[i] = Console.ReadLine();
}

Console.WriteLine();
Console.WriteLine("Inventar:");

// Mit dieser for-Schleife gehen wir alle gespeicherten Gegenstände durch.
// inventar[i] greift dabei immer auf den Gegenstand
// an der aktuellen Position im Array zu.
for (int i = 0; i < inventar.Length; i++)
{
    Console.WriteLine(inventar[i]);
}