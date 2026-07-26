using System.Text.Json;

namespace PE18_Miniuebung_Dateiverarbeitung.Services;

public class SpielstandService
{
    public void ExportiereCsv(List<Spielstand> spielstaende, string dateiPfad)
    {
        List<string> csvZeilen = new()
        {
            "Spielername;Level;Punkte"
        };

        foreach (Spielstand spielstand in spielstaende)
        {
            // TODO 3:
            // Erstelle aus dem aktuellen Spielstand eine CSV-Zeile.
            // Format: Spielername;Level;Punkte
            string csvZeile = $"{spielstand.Spielername};{spielstand.Level};{spielstand.Punkte}";

            csvZeilen.Add(csvZeile);
        }

        // TODO 4:
        // Speichere csvZeilen mit File.WriteAllLines() in dateiPfad.
        File.WriteAllLines(dateiPfad, csvZeilen);

        Console.WriteLine();
        Console.WriteLine("CSV-Datei wurde exportiert.");
    }

    public void GibCsvDateiAus(string dateiPfad)
    {
        Console.WriteLine();
        Console.WriteLine("=== Inhalt der CSV-Datei ===");

        if (!File.Exists(dateiPfad))
        {
            Console.WriteLine("Die CSV-Datei wurde nicht gefunden.");
            return;
        }

        string[] csvZeilen = File.ReadAllLines(dateiPfad);

        // Index 0 enthält die Überschrift und wird deshalb übersprungen.
        for (int i = 1; i < csvZeilen.Length; i++)
        {
            string[] werte = csvZeilen[i].Split(';');

            if (werte.Length != 3)
            {
                Console.WriteLine($"Ungültige CSV-Zeile: {csvZeilen[i]}");
                continue;
            }

            string spielername = werte[0];

            // TODO 5:
            // Wandle werte[1] und werte[2] mit int.Parse() in Zahlen um.
            if (!int.TryParse(werte[1], out int level) || !int.TryParse(werte[2], out int punkte))
            {
                Console.WriteLine("Level oder Punkte sind Fehlerhaft");
                continue;
            }

            Console.WriteLine(
                $"Spieler: {spielername} | Level: {level} | Punkte: {punkte}"
            );
        }
    }

    public void ExportiereJson(List<Spielstand> spielstaende, string dateiPfad)
    {
        JsonSerializerOptions optionen = new()
        {
            WriteIndented = true
        };

        // TODO 6:
        // Wandle spielstaende mit JsonSerializer.Serialize() in einen JSON-String um.
        // Übergib dabei auch die Variable optionen.
        string json = JsonSerializer.Serialize(spielstaende,optionen);

        File.WriteAllText(dateiPfad, json);

        Console.WriteLine();
        Console.WriteLine("JSON-Datei wurde exportiert.");
    }
}
