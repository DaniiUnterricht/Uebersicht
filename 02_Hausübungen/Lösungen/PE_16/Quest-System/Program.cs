using Quest_System.Classes;

namespace Quest_System
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1 - Erstelle mindestens drei verschiedene Belohnungen.
            Console.WriteLine("Task1: Erstelle mindestens drei verschiedene Belohnungen.");
            Console.WriteLine();

            Belohnung schleimBelohnung = new Belohnung(250,100,"Schleimschwert");

            Belohnung wolfBelohnung = new Belohnung(400,175,"Wolfspelz");

            Belohnung raeuberBelohnung = new Belohnung(600,350,"Dolch des Räuberhauptmanns");

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task2 - Erstelle mindestens drei verschiedene Quests.
            Console.WriteLine("Task2: Erstelle mindestens drei verschiedene Quests.");
            Console.WriteLine();

            Quest schleimQuest = new Quest("Besiege die Schleime","Besiege 5 Schleime im Wald.",5,schleimBelohnung);

            Quest wolfQuest = new Quest("Die Wölfe des Nordens","Besiege 3 Wölfe in den Bergen.",3,wolfBelohnung);

            Quest raeuberQuest = new Quest("Das Räuberlager","Besiege 4 Räuber und sichere das Lager.",4,raeuberBelohnung);

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task3 - Erstelle einen Spieler.
            Console.WriteLine("Task3: Erstelle einen Spieler.");
            Console.WriteLine();

            Spieler spieler = new Spieler("Danii");

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task4 - Lasse den Spieler alle Quests annehmen.
            Console.WriteLine("Task4: Lasse den Spieler alle Quests annehmen.");
            Console.WriteLine();

            spieler.QuestAnnehmen(schleimQuest);
            spieler.QuestAnnehmen(wolfQuest);
            spieler.QuestAnnehmen(raeuberQuest);

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task5 - Versuche, eine Quest doppelt anzunehmen.
            Console.WriteLine("Task5: Versuche, eine Quest doppelt anzunehmen.");
            Console.WriteLine();

            spieler.QuestAnnehmen(schleimQuest);

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task6 - Erhöhe den Fortschritt verschiedener Quests.
            Console.WriteLine("Task6: Erhöhe den Fortschritt verschiedener Quests.");
            Console.WriteLine();

            spieler.QuestFortschrittHinzufuegen("Besiege die Schleime",2);

            Console.WriteLine();

            spieler.QuestFortschrittHinzufuegen("Die Wölfe des Nordens",1);

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task7 - Schließe mindestens zwei Quests ab.
            Console.WriteLine("Task7: Schließe mindestens zwei Quests ab.");
            Console.WriteLine();

            // Schleim-Quest abschließen
            spieler.QuestFortschrittHinzufuegen("Besiege die Schleime",3);

            Console.WriteLine();

            // Wolf-Quest abschließen
            spieler.QuestFortschrittHinzufuegen("Die Wölfe des Nordens",2);

            Console.WriteLine();

            // Räuber-Quest nur teilweise erledigen
            spieler.QuestFortschrittHinzufuegen("Das Räuberlager",2);

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task8 - Versuche, bei einer bereits abgeschlossenen Quest weiteren Fortschritt hinzuzufügen.
            Console.WriteLine("Task8: Versuche, bei einer bereits abgeschlossenen Quest weiteren Fortschritt hinzuzufügen.");
            Console.WriteLine();

            spieler.QuestFortschrittHinzufuegen("Besiege die Schleime",1);

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task9 - Gib die Spielerdaten aus.
            Console.WriteLine("Task9: Gib die Spielerdaten aus.");
            Console.WriteLine();

            spieler.ZeigeSpielerInfo();

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

            #region Task10 - Gib alle Quests mit ihrem aktuellen Status aus.
            Console.WriteLine("Task10: Gib alle Quests mit ihrem aktuellen Status aus.");
            Console.WriteLine();

            foreach (Quest quest in spieler.Quests)
            {
                quest.ZeigeInfo();

                Console.WriteLine();
                quest.Belohnung.ZeigeInfo();

                Console.WriteLine();
                Console.WriteLine("------------------------------");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("=====================");
            #endregion

        }
    }
}