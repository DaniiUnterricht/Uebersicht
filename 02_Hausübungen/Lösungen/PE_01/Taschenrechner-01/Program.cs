using System;

// Hier arbeiten wir noch mit int.Parse.
// int.Parse wandelt die Eingabe von Console.ReadLine() in eine Ganzzahl um.
// Später wird int.Parse durch eine sicherere Variante ersetzt,
// da das Programm bei ungültiger Eingabe sonst abstürzt.
Console.Write("Bitte geben Sie die erste Zahl ein: ");
int zahl1 = int.Parse(Console.ReadLine());

Console.Write("Bitte geben Sie die zweite Zahl ein: ");
int zahl2 = int.Parse(Console.ReadLine());

Console.WriteLine();

// Wir speichern jedes Ergebnis in einer double-Variable.
// Dadurch können wir alle Ergebnisse einheitlich mit 2 Nachkommastellen ausgeben.
// Mit {zahl:F2} wird die Zahl auf 2 Nachkommastellen formatiert.
double zahl = zahl1 + zahl2;
Console.WriteLine($"{zahl1} + {zahl2} = {zahl:F2}");

zahl = zahl1 - zahl2;
Console.WriteLine($"{zahl1} - {zahl2} = {zahl:F2}");

zahl = zahl1 * zahl2;
Console.WriteLine($"{zahl1} * {zahl2} = {zahl:F2}");

// Bei der Division ist der Cast auf double wichtig.
// Ohne (double) würden zwei int-Werte ganzzahlig dividiert werden.
// Beispiel: 10 / 4 wäre dann 2 statt 2.5.
zahl = (double)zahl1 / zahl2;
Console.WriteLine($"{zahl1} / {zahl2} = {zahl:F2}");