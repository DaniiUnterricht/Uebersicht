using System;
using Bestellsystem.Classes;

namespace Bestellsystem
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            Console.WriteLine("Task1: Erstelle mindestens fünf Produkte.");

            Dictionary<string,Produkt> produkte = new Dictionary<string,Produkt>();
            produkte.Add("Tastatur", new Produkt("Tastatur", (decimal)59.9, 10));
            produkte.Add("Maus", new Produkt("Maus", (decimal)29.9, 20));
            produkte.Add("USB-Kabel", new Produkt("USB-Kabel", (decimal)8.5, 30));
            produkte.Add("Monitor", new Produkt("Monitor", (decimal)199.99, 10));
            produkte.Add("Computer", new Produkt("Computer", (decimal)1499.99, 5));

            Produkt tastatur = produkte["Tastatur"];
            Produkt maus = produkte["Maus"];
            Produkt usbKabel = produkte["USB-Kabel"];
            Produkt monitor = produkte["Monitor"];
            Produkt computer = produkte["Computer"];

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task2
            Console.WriteLine("Task2: Erstelle eine neue Bestellung.");

            Bestellung bestellung = new Bestellung(1001, "Dani");

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task3
            Console.WriteLine("Task3: Füge mindestens drei Produkte mit unterschiedlichen Mengen hinzu.");

            if (bestellung.ProduktHinzufuegen(tastatur, 1)) { Console.WriteLine("Produkt erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }
            if(bestellung.ProduktHinzufuegen(monitor, 2)) { Console.WriteLine("Produkt erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }
            if(bestellung.ProduktHinzufuegen(usbKabel, 3)) { Console.WriteLine("Produkt erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task4
            Console.WriteLine("Task4: Füge eines dieser Produkte ein zweites Mal hinzu.");

            if (bestellung.ProduktHinzufuegen(usbKabel, 1)) { Console.WriteLine("Produkt erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task5
            Console.WriteLine("Task5: Überprüfe, ob dabei die Menge der bestehenden Position erhöht wurde.");

            Console.WriteLine();
            bestellung.ZeigeBestellung();

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task6
            Console.WriteLine("Task6: Versuche, mehr Produkte hinzuzufügen, als auf Lager sind.");

            if (bestellung.ProduktHinzufuegen(computer, 6)) { Console.WriteLine("Produkt erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task7
            Console.WriteLine("Task7: Entferne ein Produkt aus der Bestellung.");

            if(bestellung.ProduktEntfernen("Monitor")) { Console.WriteLine("Produkt erfolgreich entfernt."); } else { Console.WriteLine("Fehler beim entfernen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task8
            Console.WriteLine("Task8: Versuche, ein nicht vorhandenes Produkt zu entfernen.");

            if(bestellung.ProduktEntfernen("Computer")) { Console.WriteLine("Produkt erfolgreich entfernt."); } else { Console.WriteLine("Fehler beim entfernen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task9
            Console.WriteLine("Task9: Gib die Bestellung und den Gesamtpreis aus.");

            bestellung.ZeigeBestellung();

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task10
            Console.WriteLine("Task10: Schließe die Bestellung ab.");

            if (bestellung.BestellungAbschliessen()) { Console.WriteLine("Bestellung erfolgreich abgeschlossen"); } else { Console.WriteLine("Fehler beim abschließen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task11
            Console.WriteLine("Task11: Gib die neuen Lagerbestände aus.");

            foreach (var produkt in produkte)
            {
                produkt.Value.ZeigeInfo();
            }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task12
            Console.WriteLine("Task12: Versuche, nachträglich ein weiteres Produkt hinzuzufügen.");

            if (bestellung.ProduktHinzufuegen(computer, 1)) { Console.WriteLine("Produkt erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task13
            Console.WriteLine("Task13: Versuche, nachträglich ein Produkt zu entfernen.");

            if (bestellung.ProduktEntfernen("USB-Kabel")) { Console.WriteLine("Produkt erfolgreich entfernt."); } else { Console.WriteLine("Fehler beim entfernen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task14
            Console.WriteLine("Task14: Versuche, die Bestellung ein zweites Mal abzuschließen.");

            if (bestellung.BestellungAbschliessen()) { Console.WriteLine("Bestellung erfolgreich abgeschlossen"); } else { Console.WriteLine("Fehler beim abschließen"); }

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task15
            Console.WriteLine("Task15: Bestelle bei mindestens einem Produkt neuen Lagerbestand nach.");

            computer.ZeigeInfo();
            computer.Nachbestellen(5);
            computer.ZeigeInfo();

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

            #region Task16
            Console.WriteLine("Task16: Ändere den Preis eines Produktes über die vorgesehene Methode.");

            monitor.ZeigeInfo();
            monitor.PreisAendern((decimal)300.0);
            monitor.ZeigeInfo();

            Console.WriteLine();
            Console.WriteLine("=======");
            #endregion

        }
    }
}
