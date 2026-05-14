using System;

Console.WriteLine("Person 1:");
Console.Write("Bitte geben Sie den Vornamen ein: ");
string vorname1 = Console.ReadLine();

Console.Write("Bitte geben Sie den Nachnamen ein: ");
string nachname1 = Console.ReadLine();

Console.Write("Bitte geben Sie das Alter ein: ");
int alter1 = int.Parse(Console.ReadLine());

Console.WriteLine();

Console.WriteLine("Person 2:");
Console.Write("Bitte geben Sie den Vornamen ein: ");
string vorname2 = Console.ReadLine();

Console.Write("Bitte geben Sie den Nachnamen ein: ");
string nachname2 = Console.ReadLine();

Console.Write("Bitte geben Sie das Alter ein: ");
int alter2 = int.Parse(Console.ReadLine());

// Mit Math.Abs() kann man den Betrag einer Zahl berechnen.
// Das bedeutet: Das Ergebnis wird immer positiv ausgegeben.
//
// In Math.Abs() kann auch direkt eine Rechnung stehen.
// Dadurch sparen wir uns eine zusätzliche Zwischenvariable.
//
// Beispiel:
// alter1 = 5
// alter2 = 8
// alter1 - alter2 = -3
// Math.Abs(alter1 - alter2) = 3
int unterschied = Math.Abs(alter1 - alter2);

Console.WriteLine();
Console.WriteLine("Ausgabe:");
Console.WriteLine($"{vorname1} {nachname1} ist {alter1} Jahre alt und hat zu {vorname2} {nachname2} ( {alter2} ) einen Altersunterschied von {unterschied} Jahren.");