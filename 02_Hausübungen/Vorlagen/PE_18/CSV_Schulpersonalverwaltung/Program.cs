using PE18_CSV_Schulpersonalverwaltung.Models;
using PE18_CSV_Schulpersonalverwaltung.Services;

string importPfad = Path.Combine("Data", "mitarbeiter.csv");
string exportPfad = Path.Combine("Data", "mitarbeiter_export.csv");

MitarbeiterService mitarbeiterService = new MitarbeiterService();

List<Mitarbeiter> mitarbeiter = mitarbeiterService.ImportiereCsv(importPfad);

mitarbeiterService.ZeigeAlleMitarbeiter(mitarbeiter);

Console.Write("\nID des Mitarbeiters: ");
int id = Convert.ToInt32(Console.ReadLine());

Mitarbeiter? gefundenerMitarbeiter =
    mitarbeiterService.FindeNachId(mitarbeiter, id);

if (gefundenerMitarbeiter != null)
{
    Console.Write("Neue Rolle: ");
    gefundenerMitarbeiter.Rolle = Console.ReadLine() ?? "";

    Console.Write("Neue Abteilung: ");
    gefundenerMitarbeiter.Abteilung = Console.ReadLine() ?? "";

    Console.Write("Neue Wochenstunden: ");
    gefundenerMitarbeiter.Wochenstunden = Convert.ToInt32(Console.ReadLine());
}
else
{
    Console.WriteLine("Mitarbeiter wurde nicht gefunden.");
}

Console.WriteLine("\nNeuen Mitarbeiter anlegen");
Console.Write("ID: ");
int neueId = Convert.ToInt32(Console.ReadLine());

Console.Write("Vorname: ");
string neuerVorname = Console.ReadLine() ?? "";

Console.Write("Nachname: ");
string neuerNachname = Console.ReadLine() ?? "";

Console.Write("Rolle: ");
string neueRolle = Console.ReadLine() ?? "";

Console.Write("Abteilung: ");
string neueAbteilung = Console.ReadLine() ?? "";

Console.Write("Wochenstunden: ");
int neueWochenstunden = Convert.ToInt32(Console.ReadLine());

Mitarbeiter neuerMitarbeiter = new Mitarbeiter(
    neueId,
    neuerVorname,
    neuerNachname,
    neueRolle,
    neueAbteilung,
    neueWochenstunden
);

mitarbeiter.Add(neuerMitarbeiter);

mitarbeiterService.ExportiereCsv(exportPfad, mitarbeiter);

List<Mitarbeiter> exportierteMitarbeiter =
    mitarbeiterService.ImportiereCsv(exportPfad);

Console.WriteLine("\nExportierte Mitarbeiterliste:");
mitarbeiterService.ZeigeAlleMitarbeiter(exportierteMitarbeiter);
