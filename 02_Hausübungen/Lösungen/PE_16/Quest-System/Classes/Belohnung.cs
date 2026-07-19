namespace Quest_System.Classes
{
    public class Belohnung
    {
        #region Properties
        public int Erfahrungspunkte { get; private set; }
        public int Gold { get; private set; }
        public string Gegenstand { get; private set; }

        #endregion

        #region Konstruktor
        public Belohnung(int erfahrungspunkte, int gold, string gegenstand)
        {
            if (erfahrungspunkte < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(erfahrungspunkte), "Die Erfahrungspunkte dürfen nicht negativ sein.");
            }

            if (gold < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(gold), "Das Gold darf nicht negativ sein.");
            }

            if (string.IsNullOrWhiteSpace(gegenstand))
            {
                throw new ArgumentException("Der Gegenstand darf nicht leer sein.", nameof(gegenstand));
            }

            Erfahrungspunkte = erfahrungspunkte;
            Gold = gold;
            Gegenstand = gegenstand;

        }

        

        #endregion

        #region Methoden
        public void ZeigeInfo()
        {
            Console.WriteLine("Belohnung:");
            Console.WriteLine($"{Erfahrungspunkte} Erfahrungspunkte");
            Console.WriteLine($"{Gold} Gold");
            Console.WriteLine($"Gegenstand: {Gegenstand}");
        }

        #endregion
    }
}