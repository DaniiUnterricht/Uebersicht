using System;

Console.WriteLine("RPG-Klassenauswahl");
Console.WriteLine("==================");
Console.WriteLine();

Console.WriteLine("1 - Krieger");
Console.WriteLine("2 - Magier");
Console.WriteLine("3 - Bogenschütze");
Console.WriteLine("4 - Heiler");
Console.WriteLine();

Console.Write("Wähle deine Klasse (1-4): ");
int klassenAuswahl = int.Parse(Console.ReadLine());

Console.WriteLine();

string klasse = "";
int hp = 0;
int mana = 0;
int angriff = 0;

// Mit dem ersten switch wählen wir die Klasse des Spielers aus.
// Je nach Klasse werden mehrere Variablen gesetzt:
// klasse, hp, mana und angriff.
//
// Wichtig:
// Hier wird nur die Grundklasse festgelegt.
// Die Waffe wird später in einem eigenen switch behandelt.
switch (klassenAuswahl)
{
    case 1:
        klasse = "Krieger";
        hp = 120;
        mana = 20;
        angriff = 15;
        break;

    case 2:
        klasse = "Magier";
        hp = 70;
        mana = 120;
        angriff = 20;
        break;

    case 3:
        klasse = "Bogenschütze";
        hp = 90;
        mana = 50;
        angriff = 18;
        break;

    case 4:
        klasse = "Heiler";
        hp = 80;
        mana = 100;
        angriff = 10;
        break;

    // Der default-Zweig wird ausgeführt,
    // wenn keine gültige Klasse gewählt wurde.
    default:
        Console.WriteLine("Ungültige Klassenauswahl!");
        break;
}

// Wenn klasse nicht leer ist, wurde eine gültige Klasse gewählt.
// Dadurch verhindern wir, dass bei einer ungültigen Klassenauswahl
// trotzdem noch eine Waffe ausgewählt und Werte ausgegeben werden.
if (klasse != "")
{
    Console.WriteLine("1 - Schwert (+5 Angriff)");
    Console.WriteLine("2 - Stab (+10 Mana)");
    Console.WriteLine("3 - Bogen (+7 Angriff)");
    Console.WriteLine();

    Console.Write("Wähle deine Waffe (1-3): ");
    int waffenAuswahl = int.Parse(Console.ReadLine());

    Console.WriteLine();

    // Mit dem zweiten switch wählen wir die Waffe aus.
    // Die Waffe verändert die bereits vorhandenen Werte der Klasse.
    //
    // Beispiel:
    // Der Magier startet mit 120 Mana.
    // Mit dem Stab bekommt er +10 Mana und hat danach 130 Mana.
    switch (waffenAuswahl)
    {
        case 1:
            angriff = angriff + 5;
            break;

        case 2:
            mana = mana + 10;
            break;

        case 3:
            angriff = angriff + 7;
            break;

        // Der default-Zweig wird ausgeführt,
        // wenn keine gültige Waffe gewählt wurde.
        default:
            Console.WriteLine("Ungültige Waffenauswahl!");
            break;
    }

    // Die Werte werden nur ausgegeben,
    // wenn eine gültige Waffe ausgewählt wurde.
    if (waffenAuswahl >= 1 && waffenAuswahl <= 3)
    {
        Console.WriteLine($"Deine Klasse: {klasse}");
        Console.WriteLine($"HP: {hp}");
        Console.WriteLine($"Mana: {mana}");
        Console.WriteLine($"Angriff: {angriff}");
    }
}