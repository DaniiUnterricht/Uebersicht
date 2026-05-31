/*
* Punkte System
* Es soll folgende Funktionen haben:
* - Punkte aller Spieler anzeigen
* - Spieler hinzufügen
* - Spieler bearbeiten
* - Spieler entfernen
*/

int Menue()
{
    Console.WriteLine();
    Console.WriteLine("Menü");
    Console.WriteLine("1 - Punkte anzeigen");
    Console.WriteLine("2 - Spieler hinzufügen");
    Console.WriteLine("3 - Spieler bearbeiten");
    Console.WriteLine("4 - Spieler entfernen");
    Console.WriteLine("5 - Programm beenden");

    bool isTrue;
    int auswahl;

    do
    {
        Console.Write("Auswahl treffen: ");
        isTrue = int.TryParse(Console.ReadLine(), out auswahl);

        if (!isTrue)
        {
            Console.WriteLine("Ungültige Eingabe!");
        }
        else if (auswahl > 5 || auswahl < 1)
        {
            Console.WriteLine("Menüpunkt nicht gefunden");
            isTrue = false;
        }

    } while (!isTrue);

    Console.WriteLine();
    return auswahl;
}

void ShowPlayer(Dictionary<string, int> player)
{
    if (player.Count > 0)
    {
	//Man könnte hier auch: "foreach (var kvp in player)" schreiben
        foreach (KeyValuePair<string, int> kvp in player)
        {
            Console.WriteLine($"{kvp.Key} hat {kvp.Value} Punkte.");
        }
    }
    else
    {
        Console.WriteLine("Keine Spieler in der Dictionary vorhanden.");
    }
}

void NewPlayer(Dictionary<string, int> player)
{
    bool isTrue;
    int points;
    string playername;

    do
    {
        Console.Write("Bitte Name des Spielers eingeben: ");
        playername = Console.ReadLine()!;
        if (playername == "")
        {
            Console.WriteLine("Der Name darf nicht Leer sein!");
            isTrue = true;
        }
        else if (player.ContainsKey(playername))
        {
            Console.WriteLine("Dieser Spieler exisitiert bereits!");
            isTrue = true;
        }
        else
        {
            isTrue = false;
        }

    } while (isTrue);

    points = InputPoints();

    player.Add(playername, points);
}

void EditPlayer(Dictionary<string, int> player)
{
    int points;
    string playername;

    playername = ContainsPlayer(player);

    points = InputPoints();

    player[playername] = points;
}

void DeletePlayer(Dictionary<string, int> player)
{
    string playername;

    playername = ContainsPlayer(player);

    player.Remove(playername);
}

int InputPoints()
{
    bool isTrue;
    int points;

    do
    {
        Console.Write("Bitte geben Sie die Punkte des Spielers ein: ");
        isTrue = int.TryParse(Console.ReadLine(), out points);

        if (!isTrue)
        {
            Console.WriteLine("Ungültige Eingabe!");
        }
    } while (!isTrue);

    return points;
}

string ContainsPlayer(Dictionary<string,int> player)
{
    string playername;
    bool isTrue;

    do
    {
        Console.Write("Bitte Name des Spielers eingeben: ");
        playername = Console.ReadLine()!;
        if (!player.ContainsKey(playername))
        {
            Console.WriteLine("Dieser Spieler existiert nicht!");
            isTrue = true;
        }
        else
        {
            isTrue = false;
        }
    } while (isTrue);

    return playername;
}

int auswahl;

Dictionary<string, int> player = new Dictionary<string, int>();

do
{
    auswahl = Menue();

    switch (auswahl)
    {
        case 1:
            ShowPlayer(player);
            break;

        case 2:
            NewPlayer(player);
            break;

        case 3:
            EditPlayer(player);
            break;

        case 4:
            DeletePlayer(player);
            break;
    }

} while (auswahl != 5);