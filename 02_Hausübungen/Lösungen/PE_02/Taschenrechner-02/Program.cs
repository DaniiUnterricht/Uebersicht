using System;

// Hier arbeiten wir noch mit int.Parse.
// int.Parse wandelt die Eingabe von Console.ReadLine() in eine Ganzzahl um.
// Später wird int.Parse durch eine sicherere Variante ersetzt,
// da das Programm bei ungültiger Eingabe sonst abstürzt.
Console.Write("Bitte geben Sie die erste Zahl ein: ");
int zahl1 = int.Parse(Console.ReadLine());

Console.Write("Bitte geben Sie die zweite Zahl ein: ");
int zahl2 = int.Parse(Console.ReadLine());

Console.Write("Bitte geben Sie den Operator ( + , - , * , / ) an: ");
string operatorEingabe = Console.ReadLine();

Console.WriteLine();

double ergebnis;

// Hier prüfen wir, welchen Operator der Benutzer eingegeben hat.
// Je nach Operator wird eine andere Rechnung durchgeführt.
if (operatorEingabe == "+")
{
    ergebnis = zahl1 + zahl2;
    Console.WriteLine($"{zahl1} + {zahl2} = {ergebnis:F2}");
}
else if (operatorEingabe == "-")
{
    ergebnis = zahl1 - zahl2;
    Console.WriteLine($"{zahl1} - {zahl2} = {ergebnis:F2}");
}
else if (operatorEingabe == "*")
{
    ergebnis = zahl1 * zahl2;
    Console.WriteLine($"{zahl1} * {zahl2} = {ergebnis:F2}");
}
else if (operatorEingabe == "/")
{
    // Bei der Division müssen wir vorher prüfen,
    // ob die zweite Zahl 0 ist.
    //
    // Eine Division durch 0 ist nicht erlaubt.
    // Ohne diese Prüfung würde das Programm bei int-Werten abstürzen.
    if (zahl2 == 0)
    {
        Console.WriteLine("Es kann nicht durch 0 dividiert werden.");
    }
    else
    {
        // Bei der Division ist der Cast auf double wichtig.
        // Ohne (double) würden zwei int-Werte ganzzahlig dividiert werden.
        // Beispiel: 10 / 4 wäre dann 2 statt 2.5.
        ergebnis = (double)zahl1 / zahl2;
        Console.WriteLine($"{zahl1} / {zahl2} = {ergebnis:F2}");
    }
}
else
{
    // Dieser Fall tritt ein, wenn der Benutzer keinen gültigen Operator eingibt.
    // Gültig wären nur: +, -, * oder /
    Console.WriteLine("Ungültiger Operator.");
}