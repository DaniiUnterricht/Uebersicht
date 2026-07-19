using System;
using Tierheimverwaltung.Classes;

namespace Tierheimverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1 - Erstelle ein Tierheim mit begrenzter Kapazität

            Console.WriteLine("Task1: Erstelle ein Tierheim mit begrenzter Kapazität.");
            Console.WriteLine();

            Tierheim tierheim = new Tierheim("Tierparadies",6);

            Console.WriteLine($"Tierheim „{tierheim.Name}“ wurde erstellt.");

            Console.WriteLine($"Maximale Anzahl: {tierheim.MaximaleAnzahl}");

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task2 - Erstelle mindestens sechs Tiere

            Console.WriteLine("Task2: Erstelle mindestens sechs Tiere.");
            Console.WriteLine();

            Tier bello = new Tier("Bello","Hund",4);

            Tier luna = new Tier("Luna","Katze",2);

            Tier max = new Tier("Max","Hund",7);

            Tier mimi = new Tier("Mimi","Katze",5);

            Tier hoppel = new Tier("Hoppel","Kaninchen",3);

            Tier coco = new Tier("Coco","Papagei",12);

            Tier rocky = new Tier("Rocky","Hund",6);

            Console.WriteLine("Die Tiere wurden erstellt.");

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task3 - Nimm die Tiere im Tierheim auf

            Console.WriteLine("Task3: Nimm die Tiere im Tierheim auf.");

            Console.WriteLine();

            tierheim.TierAufnehmen(bello);
            tierheim.TierAufnehmen(luna);
            tierheim.TierAufnehmen(max);
            tierheim.TierAufnehmen(mimi);
            tierheim.TierAufnehmen(hoppel);
            tierheim.TierAufnehmen(coco);

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task4 - Versuche, ein Tier doppelt aufzunehmen

            Console.WriteLine("Task4: Versuche, ein Tier doppelt aufzunehmen.");
            Console.WriteLine();

            tierheim.TierAufnehmen(bello);

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task5 - Versuche, die maximale Kapazität zu überschreiten

            Console.WriteLine("Task5: Versuche, die maximale Kapazität zu überschreiten.");
            Console.WriteLine();

            tierheim.TierAufnehmen(rocky);

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task6 - Vermittle mindestens zwei Tiere

            Console.WriteLine("Task6: Vermittle mindestens zwei Tiere.");
            Console.WriteLine();

            tierheim.TierVermitteln("Bello");
            tierheim.TierVermitteln("Mimi");

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task7 - Versuche, ein Tier ein zweites Mal zu vermitteln

            Console.WriteLine("Task7: Versuche, ein Tier ein zweites Mal zu vermitteln.");
            Console.WriteLine();

            tierheim.TierVermitteln("Bello");

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task8 - Gib alle Tiere aus

            Console.WriteLine("Task8: Gib alle Tiere aus.");
            Console.WriteLine();

            tierheim.ZeigeAlleTiere();

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task9 - Gib nur die noch nicht vermittelten Tiere aus

            Console.WriteLine("Task9: Gib nur die noch nicht vermittelten Tiere aus.");
            Console.WriteLine();

            tierheim.ZeigeNichtVermittelteTiere();

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task10 - Gib die Anzahl der noch nicht vermittelten Tiere aus

            Console.WriteLine("Task10: Gib die Anzahl der noch nicht vermittelten Tiere aus.");
            Console.WriteLine();

            Console.WriteLine($"Noch nicht vermittelte Tiere: {tierheim.AnzahlNichtVermittelterTiere()}");

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task11 - Gib nur Tiere einer bestimmten Tierart aus

            Console.WriteLine("Task11: Gib nur Tiere einer bestimmten Tierart aus.");
            Console.WriteLine();

            tierheim.ZeigeTiereNachTierart("Hund");

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion

            #region Task12 - Ermittle das älteste Tier

            Console.WriteLine("Task12: Ermittle das älteste Tier und gib dessen Informationen aus.");
            Console.WriteLine();

            Tier? aeltestesTier = tierheim.FindeAeltestesTier();

            if (aeltestesTier is null)
            {
                Console.WriteLine("Im Tierheim befinden sich keine Tiere.");
            }
            else
            {
                Console.WriteLine("Das älteste Tier ist:");
                aeltestesTier.ZeigeInfo();
            }

            Console.WriteLine();
            Console.WriteLine("=====================");

            #endregion
        }
    }
}