using System;

Console.WriteLine("Zahlenraten");
Console.WriteLine("===========");
Console.WriteLine();

// Mit Random können wir zufällige Zahlen erzeugen.
// Dafür erstellen wir zuerst ein Random-Objekt.
Random random = new Random();

// random.Next(1, 101) erzeugt eine Zufallszahl von 1 bis 100.
//
// Wichtig:
// Die erste Zahl ist inklusive.
// Die zweite Zahl ist exklusiv.
//
// Das bedeutet:
// 1 kann vorkommen.
// 101 kann nicht vorkommen.
// Dadurch ist die größte mögliche Zahl 100.
//
// Würden wir random.Next(1, 100) schreiben,
// wäre die größte mögliche Zahl 99.
int computer = random.Next(1, 101);

Console.Write("Bitte geben Sie eine Zahl ein ( 1-100 ): ");
int user = int.Parse(Console.ReadLine());

Console.WriteLine();

// Hier vergleichen wir die Eingabe des Benutzers mit der Zufallszahl des Computers.
// Ist die Eingabe größer als die Computerzahl, war die Eingabe zu hoch.
// Ist die Eingabe kleiner als die Computerzahl, war die Eingabe zu niedrig.
// Ansonsten sind beide Zahlen gleich und der Benutzer hat richtig geraten.
if (user > computer)
{
    Console.WriteLine($"Zu hoch! - Die Zahl des Computers war {computer}.");
}
else if (user < computer)
{
    Console.WriteLine($"Zu niedrig! - Die Zahl des Computers war {computer}.");
}
else
{
    Console.WriteLine($"Richtig! - Die Zahl des Computers war {computer}.");
}