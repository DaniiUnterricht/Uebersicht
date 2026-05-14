using System;

Console.WriteLine("Summe");
Console.WriteLine("=====");
Console.WriteLine();

int zahl = -1;
int summe = 0;

// Eine do-while-Schleife wird mindestens einmal ausgeführt.
// Der Grund ist:
// Die Bedingung wird erst am Ende der Schleife geprüft.
//
// Das passt hier gut, weil der Benutzer mindestens einmal
// eine Zahl eingeben soll.
do
{
    Console.Write("Bitte Zahl eingeben (0 beendet): ");

    // int.TryParse versucht, die Eingabe direkt in eine Ganzzahl umzuwandeln.
    //
    // Wenn die Umwandlung funktioniert:
    // - ist isTrue true
    // - steht die umgewandelte Zahl in zahl
    //
    // Wenn die Umwandlung nicht funktioniert:
    // - ist isTrue false
    // - das Programm stürzt nicht ab
    bool isTrue = int.TryParse(Console.ReadLine(), out zahl);

    if (isTrue)
    {
        // Die eingegebene Zahl wird zur Summe addiert.
        // Wenn zahl 0 ist, verändert sich die Summe nicht.
        //
        // Beispiel:
        // summe = 5
        // zahl = 7
        // summe = 5 + 7 = 12
        summe = summe + zahl;
    }
    else
    {
        Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");

        // Bei einer ungültigen Eingabe setzen wir zahl auf -1.
        // Dadurch wird die Schleife nicht beendet,
        // weil die Schleife nur bei 0 stoppen soll.
        zahl = -1;
    }

} while (zahl != 0);

// Sobald zahl den Wert 0 hat,
// ist die Bedingung zahl != 0 false.
// Dadurch wird die Schleife beendet und das Programm läuft hier weiter.
Console.WriteLine();
Console.WriteLine($"Summe: {summe}");