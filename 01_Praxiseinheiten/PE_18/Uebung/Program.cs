using PE18_Miniuebung_Dateiverarbeitung;
using PE18_Miniuebung_Dateiverarbeitung.Services;

List<Spielstand> spielstaende = new()
{
    new Spielstand("Luna", 4, 1250),
    new Spielstand("Mika", 7, 2800),
    new Spielstand("Alex", 2, 650)
};

string csvPfad = "spielstaende.csv";
string jsonPfad = "spielstaende.json";

//Müsse wir machen, da SpielstandService nicht static ist
SpielstandService spielstandService = new();

Console.WriteLine("=== Neuen Spielstand anlegen ===");

Console.Write("Spielername: ");
string spielername = Console.ReadLine() ?? "";

while (string.IsNullOrWhiteSpace(spielername))
{
    Console.Write("Der Spielername darf nicht leer sein: ");
    spielername = Console.ReadLine() ?? "";
}

int level = ZahlEinlesen("Level: ");
int punkte = ZahlEinlesen("Punkte: ");

// TODO 1:
// Erstelle aus spielername, level und punkte ein neues Spielstand-Objekt.
Spielstand neuerSpielstand = new Spielstand(spielername, level, punkte);

// TODO 2:
// Füge neuerSpielstand zur Liste spielstaende hinzu.
spielstaende.Add(neuerSpielstand);

// Die eigentliche Dateiverarbeitung befindet sich im SpielstandService.
spielstandService.ExportiereCsv(spielstaende, csvPfad);
spielstandService.GibCsvDateiAus(csvPfad);
spielstandService.ExportiereJson(spielstaende, jsonPfad);

Console.WriteLine();
Console.WriteLine("Bearbeitung abgeschlossen.");
Console.WriteLine($"CSV-Datei:  {Path.GetFullPath(csvPfad)}");
Console.WriteLine($"JSON-Datei: {Path.GetFullPath(jsonPfad)}");

static int ZahlEinlesen(string aufforderung)
{
    int zahl;

    Console.Write(aufforderung);

    while (!int.TryParse(Console.ReadLine(), out zahl) || zahl < 0)
    {
        Console.Write("Bitte eine gültige, nicht negative Zahl eingeben: ");
    }

    return zahl;
}
