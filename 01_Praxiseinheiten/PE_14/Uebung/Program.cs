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

}

void NewPlayer(Dictionary<string, int> player)
{

}

void EditPlayer(Dictionary<string, int> player)
{

}

void DeletePlayer(Dictionary<string, int> player)
{

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