using System;

Console.WriteLine("Rabatt-System");
Console.WriteLine("=============");
Console.WriteLine();

// Wir verwenden hier double, weil ein Einkaufswert auch Nachkommastellen haben kann.
// Beispiel: 249,99 Euro oder 300,50 Euro.
// Trotzdem kann der Benutzer auch ganze Zahlen wie 300 eingeben.
// double.Parse wandelt die Eingabe dann automatisch in 300,0 um.
Console.Write("Bitte geben Sie Ihren Einkaufswert ein: ");
double einkaufswert = double.Parse(Console.ReadLine());

int rabatt;

// Wichtig: Bei else-if-Ketten mit Bereichen sollte man auf die Reihenfolge achten.
// Hier prüfen wir von spezifisch zu allgemein.
//
// Wenn wir zuerst einkaufswert >= 100 prüfen würden,
// würden auch Werte ab 250 oder 500 dort landen.
// Dadurch würden die höheren Rabatte nie erreicht werden.
//
// Deshalb prüfen wir zuerst den höchsten Rabatt.
if (einkaufswert >= 500)
{
    rabatt = 30;
}
else if (einkaufswert >= 250)
{
    rabatt = 20;
}
else if (einkaufswert >= 100)
{
    rabatt = 10;
}
else
{
    rabatt = 0;
}

Console.WriteLine();
Console.WriteLine($"Ihr Rabatt beträgt {rabatt}%!");