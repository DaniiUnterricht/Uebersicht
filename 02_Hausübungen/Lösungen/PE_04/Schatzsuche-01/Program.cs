using System;

Console.WriteLine("Schatzsuche im Dungeon");
Console.WriteLine("======================");
Console.WriteLine();

// Mit Random können wir zufällige Zahlen erzeugen.
// Dafür erstellen wir zuerst ein Random-Objekt.
Random random = new Random();

// random.Next(1, 11) erzeugt eine Zufallszahl von 1 bis 10.
//
// Wichtig:
// Die erste Zahl ist inklusive.
// Die zweite Zahl ist exklusiv.
//
// Das bedeutet:
// 1 kann vorkommen.
// 11 kann nicht vorkommen.
// Dadurch ist die größte mögliche Zahl 10.
int schatzPosition = random.Next(1, 11);

bool schatzGefunden = false;

// Eine while-Schleife wiederholt den Code so lange,
// wie die Bedingung in den runden Klammern true ist.
//
// In diesem Fall läuft die Schleife so lange,
// wie der Schatz noch nicht gefunden wurde.
while (schatzGefunden == false)
{
    Console.Write("Wähle einen Raum (1-10): ");

    // int.TryParse versucht, die Eingabe direkt in eine Ganzzahl umzuwandeln.
    //
    // Wenn die Umwandlung funktioniert:
    // - ist isTrue true
    // - steht die umgewandelte Zahl in raum
    //
    // Wenn die Umwandlung nicht funktioniert:
    // - ist isTrue false
    // - das Programm stürzt nicht ab
    bool isTrue = int.TryParse(Console.ReadLine(), out int raum);

    if (isTrue)
    {
        if (raum == schatzPosition)
        {
            // Sobald der Schatz gefunden wurde,
            // setzen wir die boolische Variable auf true.
            // Dadurch ist die while-Bedingung beim nächsten Prüfen false
            // und die Schleife wird beendet.
            Console.WriteLine("Schatz gefunden!");
            schatzGefunden = true;
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

    Console.WriteLine();
}