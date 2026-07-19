using System.Timers;

namespace Quest_System.Classes
{
    public class Spieler
    {
        #region Properties
        public string Name { get; private set; }

        public int Level { get; private set; }
        public int Erfahrungspunkte { get; private set; }
        public int Gold { get; private set; }

        public List<string> Gegenstaende { get; private set; }
        public List<Quest> Quests { get; private set; }

        #endregion

        #region Konstruktor
        public Spieler(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Spielername darf nicht leer sein.", nameof(name));
            }

            Name = name;

            Level = 1;
            Erfahrungspunkte = 0;
            Gold = 0;

            Gegenstaende = new List<string>();
            Quests = new List<Quest>();
        }

        #endregion

        #region Methoden

        public bool QuestAnnehmen(Quest quest)
        {
            if (quest is null)
            {
                return false;
            }

            foreach (Quest vorhandeneQuest in Quests)
            {
                if (vorhandeneQuest.Titel.Equals(quest.Titel, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Die Quest „{quest.Titel}“ wurde bereits angenommen.");
                    return false;
                }
            }

            Quests.Add(quest);

            Console.WriteLine($"{Name} hat die Quest „{quest.Titel}“ angenommen.");
            return true;
        }

        public void QuestFortschrittHinzufuegen(string questTitel,int fortschritt)
        {
            Quest? gefundeneQuest = null;

            foreach (Quest quest in Quests)
            {
                if (quest.Titel.Equals(questTitel, StringComparison.OrdinalIgnoreCase))
                {
                    gefundeneQuest = quest;
                    break;
                }
            }

            if (gefundeneQuest is null)
            {
                Console.WriteLine($"Die Quest „{questTitel}“ wurde nicht gefunden.");
                return;
            }

            if(gefundeneQuest.IstAbgeschlossen)
            {
                Console.WriteLine($"Die Quest „{questTitel}“ ist bereits abgeschlossen.");
                return;
            }

            gefundeneQuest.FortschrittHinzufuegen(fortschritt);

            if (gefundeneQuest.IstAbgeschlossen)
            {
                BelohnungErhalten(gefundeneQuest.Belohnung);
            }
        }

        private void BelohnungErhalten(Belohnung belohnung)
        {




            Erfahrungspunkte += belohnung.Erfahrungspunkte;
            Gold += belohnung.Gold;
            Gegenstaende.Add(belohnung.Gegenstand);

            Console.WriteLine();
            Console.WriteLine($"{Name} erhält:");

            Console.WriteLine($"{belohnung.Erfahrungspunkte} Erfahrungspunkte");
            Console.WriteLine($"{belohnung.Gold} Gold");
            Console.WriteLine($"Gegenstand: {belohnung.Gegenstand}");

            LevelPruefen();
        }

        private void LevelPruefen()
        {
            int neuesLevel = Erfahrungspunkte / 500 + 1;

            while (Level < neuesLevel)
            {
                Level++;

                Console.WriteLine($"{Name} ist jetzt Level {Level}.");
            }
        }

        public void ZeigeSpielerInfo()
        {
            Console.WriteLine($"Spieler: {Name}");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Erfahrungspunkte: {Erfahrungspunkte}");
            Console.WriteLine($"Gold: {Gold}");

            Console.WriteLine();
            Console.WriteLine("Gegenstände:");

            if (Gegenstaende.Count == 0)
            {
                Console.WriteLine("Keine Gegenstände vorhanden.");
            }
            else
            {
                foreach (var gegenstand in Gegenstaende)
                {
                    Console.WriteLine($"- {gegenstand}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Quests:");

            if (Quests.Count == 0)
            {
                Console.WriteLine("Keine Quests angenommen.");
            }
            else
            {
                foreach (Quest quest in Quests)
                {
                    string status = quest.IstAbgeschlossen ? "Abgeschlossen" : "Offen";

                    Console.WriteLine($"- {quest.Titel}: {quest.AktuellerFortschritt}/{quest.BenoetigteFortschritte} – {status}");
                }
            }
        }

        #endregion
    }
}