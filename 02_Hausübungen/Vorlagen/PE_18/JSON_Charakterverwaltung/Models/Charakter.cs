namespace PE18_JSON_Charakterverwaltung.Models;

public class Charakter
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Klasse { get; set; }
    public int Level { get; set; }
    public int Gold { get; set; }
    public List<Gegenstand> Inventar { get; set; }

    public Charakter()
    {
        Name = string.Empty;
        Klasse = string.Empty;
        Inventar = new List<Gegenstand>();
    }

    public Charakter(
        int id,
        string name,
        string klasse,
        int level,
        int gold,
        List<Gegenstand> inventar)
    {
        Id = id;
        Name = name;
        Klasse = klasse;
        Level = level;
        Gold = gold;
        Inventar = inventar;
    }
}
