using System;

Console.WriteLine("Schatzsuche im Dungeon");
Console.WriteLine("======================");
Console.WriteLine();

// Mit Random können wir zufällige Zahlen erzeugen.
// Dafür erstellen wir zuerst ein Random-Objekt.
Random random = new Random();

// Hier erstellen wir ein int-Array mit 3 Speicherplätzen.
// In diesem Array werden später die 3 Schatzräume gespeichert.
int[] schatzRaeume = new int[3];

// Mit dieser for-Schleife werden 3 zufällige Schatzräume erzeugt.
//
// random.Next(1, 11) erzeugt eine Zahl von 1 bis 10.
// Die erste Zahl ist inklusive.
// Die zweite Zahl ist exklusiv.
//
// Das bedeutet:
// 1 kann vorkommen.
// 11 kann nicht vorkommen.
// Dadurch ist die größte mögliche Zahl 10.
for (int i = 0; i < schatzRaeume.Length; i++)
{
    schatzRaeume[i] = random.Next(1, 11);
}

Console.Write("Wähle einen Raum (1-10): ");
bool isTrue = int.TryParse(Console.ReadLine(), out int raum);

Console.WriteLine();

// Diese Variable merkt sich,
// ob der Spieler einen Schatz gefunden hat.
bool schatzGefunden = false;

if (isTrue)
{
    // Mit dieser for-Schleife gehen wir alle gespeicherten Schatzräume durch.
    // Dabei vergleichen wir jeden Schatzraum mit der Eingabe des Spielers.
    //
    // Wenn ein gespeicherter Schatzraum gleich dem gewählten Raum ist,
    // wurde ein Schatz gefunden.
    for (int i = 0; i < schatzRaeume.Length; i++)
    {
        if (raum == schatzRaeume[i])
        {
            schatzGefunden = true;
        }
    }

    if (schatzGefunden)
    {
        Console.WriteLine("Schatz gefunden!");
    }
    else
    {
        Console.WriteLine("Kein Schatz hier!");
    }
}
else
{
    Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
}