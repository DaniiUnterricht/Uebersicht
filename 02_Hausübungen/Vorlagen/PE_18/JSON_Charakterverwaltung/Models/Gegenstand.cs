namespace PE18_JSON_Charakterverwaltung.Models;

public class Gegenstand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Kategorie { get; set; }
    public int Wert { get; set; }
    public int Anzahl { get; set; }

    public Gegenstand()
    {
        Name = string.Empty;
        Kategorie = string.Empty;
    }

    public Gegenstand(
        int id,
        string name,
        string kategorie,
        int wert,
        int anzahl)
    {
        Id = id;
        Name = name;
        Kategorie = kategorie;
        Wert = wert;
        Anzahl = anzahl;
    }
}
