using System;

Console.WriteLine("Taschenrechner");
Console.WriteLine("==============");
Console.WriteLine();

int auswahl = -1;

// Die while-Schleife läuft so lange,
// bis der Benutzer die Auswahl 0 eingibt.
//
// Dadurch kann der Taschenrechner mehrere Rechnungen durchführen,
// ohne dass das Programm nach einer Rechnung beendet wird.
while (auswahl != 0)
{
    Console.WriteLine("1 - Addition");
    Console.WriteLine("2 - Subtraktion");
    Console.WriteLine("3 - Multiplikation");
    Console.WriteLine("4 - Division");
    Console.WriteLine("0 - Beenden");
    Console.WriteLine();

    Console.Write("Bitte wählen Sie eine Operation: ");
    bool isTrue = int.TryParse(Console.ReadLine(), out auswahl);

    Console.WriteLine();

    // Wenn die Eingabe keine gültige Ganzzahl war,
    // wird eine Fehlermeldung ausgegeben.
    //
    // Mit continue springen wir direkt zum nächsten Schleifendurchlauf.
    // Dadurch wird das Menü erneut angezeigt.
    if (isTrue == false)
    {
        Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
        Console.WriteLine("---");
        Console.WriteLine();
        continue;
    }

    // Wenn der Benutzer 0 eingibt,
    // soll das Programm beendet werden.
    //
    // Mit break verlassen wir die while-Schleife sofort.
    if (auswahl == 0)
    {
        break;
    }

    // Wenn eine Zahl außerhalb von 1 bis 4 eingegeben wurde,
    // ist die Operation ungültig.
    //
    // Auch hier verwenden wir continue,
    // damit keine Zahlen abgefragt werden.
    if (auswahl < 1 || auswahl > 4)
    {
        Console.WriteLine("Ungültige Operation!");
        Console.WriteLine("---");
        Console.WriteLine();
        continue;
    }

    Console.Write("Zahl 1: ");
    bool zahl1Gueltig = int.TryParse(Console.ReadLine(), out int zahl1);

    Console.Write("Zahl 2: ");
    bool zahl2Gueltig = int.TryParse(Console.ReadLine(), out int zahl2);

    Console.WriteLine();

    // Wenn mindestens eine der beiden Zahlen ungültig war,
    // kann keine Rechnung durchgeführt werden.
    if (zahl1Gueltig == false || zahl2Gueltig == false)
    {
        Console.WriteLine("Ungültige Zahleneingabe!");
        Console.WriteLine("---");
        Console.WriteLine();
        continue;
    }

    double ergebnis;

    // Mit switch prüfen wir,
    // welche Rechenoperation der Benutzer ausgewählt hat.
    switch (auswahl)
    {
        case 1:
            ergebnis = zahl1 + zahl2;
            Console.WriteLine($"Ergebnis: {ergebnis:F2}");
            break;

        case 2:
            ergebnis = zahl1 - zahl2;
            Console.WriteLine($"Ergebnis: {ergebnis:F2}");
            break;

        case 3:
            ergebnis = zahl1 * zahl2;
            Console.WriteLine($"Ergebnis: {ergebnis:F2}");
            break;

        case 4:
            // Bei der Division muss geprüft werden,
            // ob die zweite Zahl 0 ist.
            //
            // Eine Division durch 0 ist nicht erlaubt.
            if (zahl2 == 0)
            {
                Console.WriteLine("Es kann nicht durch 0 dividiert werden.");
            }
            else
            {
                // Der Cast auf double ist wichtig,
                // damit auch Kommazahlen als Ergebnis möglich sind.
                //
                // Beispiel:
                // 5 / 2 wäre mit int-Werten 2.
                // (double)5 / 2 ergibt 2.5.
                ergebnis = (double)zahl1 / zahl2;
                Console.WriteLine($"Ergebnis: {ergebnis:F2}");
            }
            break;
    }

    Console.WriteLine();
    Console.WriteLine("---");
    Console.WriteLine();
}