namespace PE18_CSV_Schulpersonalverwaltung.Models;

public class Mitarbeiter
{
    public int Id { get; set; }
    public string Vorname { get; set; }
    public string Nachname { get; set; }
    public string Rolle { get; set; }
    public string Abteilung { get; set; }
    public int Wochenstunden { get; set; }

    public Mitarbeiter(
        int id,
        string vorname,
        string nachname,
        string rolle,
        string abteilung,
        int wochenstunden)
    {
        Id = id;
        Vorname = vorname;
        Nachname = nachname;
        Rolle = rolle;
        Abteilung = abteilung;
        Wochenstunden = wochenstunden;
    }
}
