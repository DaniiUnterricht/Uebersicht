using System;

Console.WriteLine("Ampel");
Console.WriteLine("=====");
Console.WriteLine();

Console.Write("Bitte geben Sie eine Ampelfarbe ein: ");
string farbe = Console.ReadLine();

// Mit ToLower() wandeln wir die Eingabe in Kleinbuchstaben um.
// Dadurch ist es egal, ob der Benutzer z. B. "Rot", "ROT" oder "rot" eingibt.
// Nach ToLower() wird daraus immer "rot".
farbe = farbe.ToLower();

Console.WriteLine();

// Mit switch können wir mehrere mögliche Werte einer Variable prüfen.
// Hier prüfen wir, welche Ampelfarbe eingegeben wurde.
switch (farbe)
{
    case "rot":
        Console.WriteLine("Stopp!");
        break;

    case "gelb":
        Console.WriteLine("Achtung!");
        break;

    case "grün":
        Console.WriteLine("Fahren erlaubt!");
        break;

    // Der default-Zweig wird ausgeführt,
    // wenn keiner der oberen Fälle zutrifft.
    // Also z. B. bei "blau", "lila" oder einer leeren Eingabe.
    default:
        Console.WriteLine("Ungültige Ampelfarbe!");
        break;
}