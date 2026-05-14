using System;

Console.WriteLine("Parkticket Automat");
Console.WriteLine("==================");
Console.WriteLine();

Console.Write("Bitte geben Sie die Parkdauer in Stunden an: ");
int parkdauer = int.Parse(Console.ReadLine());

Console.Write("Ist es am Wochenende ( t / f ): ");

bool wochenende;

// Hier prüfen wir Console.ReadLine() direkt im if.
// Das funktioniert gut, wenn wir nur einen bestimmten Wert prüfen wollen
// und alle anderen Eingaben gleich behandelt werden sollen.
// In diesem Fall bedeutet das:
// "t" -> Wochenende = true
// alles andere -> Wochenende = false
//
// Wenn mehrere konkrete Eingaben unterschieden werden sollen,
// sollte die Eingabe vorher in einer Variable gespeichert werden.
// Beispiel: "t", "f", "ja", "nein", "abbrechen", ...
if (Console.ReadLine() == "t")
{
    wochenende = true;
}
else
{
    wochenende = false;
}

// Wichtig: Bei else-if-Ketten sollte man von spezifisch zu allgemein prüfen.
// Wenn wir zuerst parkdauer >= 3 prüfen würden, würden auch Werte über 5 dort landen.
// Dadurch würde parkdauer > 5 nie mehr erreicht werden.
double summe;

if (parkdauer > 5)
{
    summe = 10;
}
else if (parkdauer >= 3)
{
    summe = 5;
}
else
{
    summe = 2;
}

// Den Wochenendzuschlag berechnen wir erst nach dem Grundpreis.
// Da wochenende ein boolischer Wert ist, müssen wir nicht schreiben:
// if (wochenende == true)
//
// if (wochenende) reicht aus, weil in der Variable bereits true oder false steht.
if (wochenende)
{
    summe = summe * 1.5;
}

Console.WriteLine();
Console.WriteLine($"Sie müssen {summe:F2} Euro bezahlen");