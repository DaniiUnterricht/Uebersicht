namespace PE18_Miniuebung_Dateiverarbeitung;

public class Spielstand
{
    public string Spielername { get; set; }
    public int Level { get; set; }
    public int Punkte { get; set; }

    public Spielstand(string spielername, int level, int punkte)
    {
        Spielername = spielername;
        Level = level;
        Punkte = punkte;
    }
}
