using System;

Console.WriteLine("Monsterkampf");
Console.WriteLine("============");
Console.WriteLine();

int monsterLeben = 20;

// Eine while-Schleife wiederholt den Code so lange,
// wie die Bedingung in den runden Klammern true ist.
//
// In diesem Fall läuft die Schleife so lange,
// wie das Monster noch mehr als 0 Lebenspunkte hat.
while (monsterLeben > 0)
{
    Console.WriteLine($"Monster-Leben: {monsterLeben}");

    Console.Write("Schaden eingeben: ");

    // int.TryParse versucht, die Eingabe direkt in eine Ganzzahl umzuwandeln.
    //
    // Wenn die Umwandlung funktioniert:
    // - ist isTrue true
    // - steht die umgewandelte Zahl in schaden
    //
    // Wenn die Umwandlung nicht funktioniert:
    // - ist isTrue false
    // - das Programm stürzt nicht ab
    bool isTrue = int.TryParse(Console.ReadLine(), out int schaden);

    if (isTrue)
    {
        // Der eingegebene Schaden wird von den Lebenspunkten abgezogen.
        // Beispiel:
        // monsterLeben = 20
        // schaden = 5
        // monsterLeben = 20 - 5 = 15
        monsterLeben = monsterLeben - schaden;
    }
    else
    {
        Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
    }

    Console.WriteLine();
}

// Sobald monsterLeben 0 oder kleiner ist,
// ist die Bedingung der while-Schleife false.
// Dadurch wird die Schleife beendet und das Programm läuft hier weiter.
Console.WriteLine("Monster besiegt!");