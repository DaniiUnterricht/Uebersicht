using System;

Console.WriteLine("Versandkosten");
Console.WriteLine("=============");
Console.WriteLine();

Console.WriteLine("1 - Österreich");
Console.WriteLine("2 - Deutschland");
Console.WriteLine("3 - Schweiz");
Console.WriteLine("4 - Italien");
Console.WriteLine();

Console.Write("Bitte wählen Sie ein Land (1-4): ");
int landAuswahl = int.Parse(Console.ReadLine());

double versandkosten = 0;

// Mit switch prüfen wir, welches Land der Benutzer ausgewählt hat.
// Je nach Auswahl werden andere Versandkosten gespeichert.
//
// Wichtig:
// Hier speichern wir nur die Grundkosten für das Land.
// Der Express-Zuschlag wird später mit einer eigenen if-Abfrage berechnet.
switch (landAuswahl)
{
    case 1:
        versandkosten = 4.90;
        break;

    case 2:
        versandkosten = 6.90;
        break;

    case 3:
        versandkosten = 9.90;
        break;

    case 4:
        versandkosten = 7.90;
        break;

    // Der default-Zweig wird ausgeführt,
    // wenn keine gültige Länderauswahl getroffen wurde.
    default:
        Console.WriteLine("Ungültige Länderauswahl!");
        break;
}

// Wenn die Versandkosten größer als 0 sind,
// wurde eine gültige Länderauswahl getroffen.
// Dadurch verhindern wir, dass bei einer ungültigen Auswahl
// trotzdem noch Expressversand abgefragt und weitergerechnet wird.
if (versandkosten > 0)
{
    Console.Write("Expressversand? (j/n): ");
    string express = Console.ReadLine();

    // Hier prüfen wir, ob Expressversand gewünscht ist.
    // Wenn der Benutzer "j" eingibt, werden 3,00 € dazugerechnet.
    //
    // Alle anderen Eingaben werden hier wie "kein Expressversand" behandelt.
    // Wenn man "j" und "n" genau unterscheiden möchte,
    // müsste man die Eingabe mit if / else if / else prüfen.
    if (express == "j")
    {
        versandkosten = versandkosten + 3.00;
    }

    Console.WriteLine();
    Console.WriteLine($"Versandkosten: {versandkosten:F2} €");
}