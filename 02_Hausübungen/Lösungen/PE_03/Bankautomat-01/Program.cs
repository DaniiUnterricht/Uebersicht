using System;

Console.WriteLine("Bankautomat");
Console.WriteLine("===========");
Console.WriteLine();

Console.WriteLine("1 - 20 €");
Console.WriteLine("2 - 50 €");
Console.WriteLine("3 - 100 €");
Console.WriteLine("4 - 200 €");
Console.WriteLine();

Console.Write("Wählen Sie einen Betrag (1-4): ");
int auswahl = int.Parse(Console.ReadLine());

Console.WriteLine();

double kontostand = 120.00;
double betrag = 0;

// Mit switch prüfen wir, welche Auswahl der Benutzer getroffen hat.
// Je nach Auswahl wird ein anderer Betrag in der Variable betrag gespeichert.
//
// Wichtig:
// Die Auszahlung passiert hier noch nicht.
// Wir wählen hier nur den gewünschten Betrag aus.
switch (auswahl)
{
    case 1:
        betrag = 20;
        break;

    case 2:
        betrag = 50;
        break;

    case 3:
        betrag = 100;
        break;

    case 4:
        betrag = 200;
        break;

    // Der default-Zweig wird ausgeführt,
    // wenn keine gültige Auswahl eingegeben wurde.
    default:
        Console.WriteLine("Ungültige Auswahl!");
        break;
}

// Wenn betrag größer als 0 ist, wurde eine gültige Auswahl getroffen.
// Dadurch verhindern wir, dass bei einer ungültigen Auswahl weitergerechnet wird.
if (betrag > 0)
{
    Console.WriteLine($"Gewählter Betrag: {betrag:F0} €");

    // Hier prüfen wir, ob genug Geld am Konto vorhanden ist.
    // Die Auszahlung darf nur durchgeführt werden,
    // wenn der Kontostand größer oder gleich dem gewünschten Betrag ist.
    if (kontostand >= betrag)
    {
        // Wenn mehr als 100 € abgehoben werden,
        // soll zusätzlich eine Sicherheitsmeldung erscheinen.
        if (betrag > 100)
        {
            Console.WriteLine("Sicherheitsmeldung: Sie heben mehr als 100 € ab.");
        }

        // Erst nach erfolgreicher Prüfung wird der Betrag vom Kontostand abgezogen.
        kontostand = kontostand - betrag;

        Console.WriteLine("Auszahlung erfolgreich.");
        Console.WriteLine($"Neuer Kontostand: {kontostand:F2} €");
    }
    else
    {
        // Dieser Fall tritt ein, wenn der gewünschte Betrag
        // größer als der aktuelle Kontostand ist.
        Console.WriteLine("Nicht genügend Guthaben!");
    }
}