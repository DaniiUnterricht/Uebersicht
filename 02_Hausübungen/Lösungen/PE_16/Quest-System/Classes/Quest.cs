namespace Quest_System.Classes
{
    public class Quest
    {
        #region Properties
        public string Titel { get; private set; }
        public string Beschreibung { get; private set; }

        public int BenoetigteFortschritte { get; private set; }
        public int AktuellerFortschritt { get; private set; }

        public bool IstAbgeschlossen { get; private set; }

        public Belohnung Belohnung { get; private set; }

        #endregion

        #region Konstruktor
        public Quest(string titel, string beschreibung, int benoetigteFortschritte, Belohnung belohnung)
        {
            if (string.IsNullOrWhiteSpace(titel))
            {
                throw new ArgumentException("Der Titel darf nicht leer sein.", nameof(titel));
            }

            if (string.IsNullOrWhiteSpace(beschreibung))
            {
                throw new ArgumentException("Die Beschreibung darf nicht leer sein.", nameof(beschreibung));
            }

            if (benoetigteFortschritte <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(benoetigteFortschritte), "Die benötigten Fortschritte müssen größer als 0 sein.");
            }

            if (belohnung is null)
            {
                throw new ArgumentNullException(nameof(belohnung));
            }

            Titel = titel;
            Beschreibung = beschreibung;
            BenoetigteFortschritte = benoetigteFortschritte;
            Belohnung = belohnung;

            AktuellerFortschritt = 0;
            IstAbgeschlossen = false;
        }

        #endregion

        #region Methoden
        public void FortschrittHinzufuegen(int fortschritt)
        {
            if (fortschritt <= 0)
            {
                Console.WriteLine($"Der Fortschritt für die Quest „{Titel}“ muss größer als 0 sein.");
                return;
            }

            if (IstAbgeschlossen)
            {
                Console.WriteLine($"Die Quest „{Titel}“ ist bereits abgeschlossen.");
                return;
            }

            AktuellerFortschritt += fortschritt;

            if (AktuellerFortschritt >= BenoetigteFortschritte)
            {
                AktuellerFortschritt = BenoetigteFortschritte;
                IstAbgeschlossen = true;
                Console.WriteLine($"Quest abgeschlossen: {Titel}");
                return;
            }

            Console.WriteLine($"Quest: {Titel}");
            Console.WriteLine($"Fortschritt: {AktuellerFortschritt} von {BenoetigteFortschritte}");
        }

        public void ZeigeInfo()
        {
            string status = IstAbgeschlossen ? "Abgeschlossen" : "Offen";

            /* Ausgeschriebene Schreibweise:
            string status;
            if (IstAbgeschlossen)
            {
                status = "Abgeschlossen";
            }
            else
            {
                status = "Offen";
            }
            */
            
            Console.WriteLine($"Quest: {Titel}");
            Console.WriteLine($"Beschreibung: {Beschreibung}");

            Console.WriteLine($"Fortschritt: {AktuellerFortschritt} von {BenoetigteFortschritte}");

            Console.WriteLine($"Status: {status}");
        }

        #endregion
    }
}