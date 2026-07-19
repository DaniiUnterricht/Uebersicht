using System;
using Bibliotheksverwaltung.Classes;

namespace Bibliotheksverwaltung
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1
            Console.WriteLine("Task1: Erstelle eine Bibliothek.");

            Bibliothek bibliothek = new Bibliothek("Stadtbibliothek");

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task2
            Console.WriteLine("Task2: Erstelle mindestens sechs Bücher aus verschiedenen Kategorien.");

            List<Buch> buecher = new List<Buch>
            {
                new Buch("Der Hobbit", "J. R. R. Tolkien", "Fantasy"),
                new Buch("Harry Potter und der Stein der Weisen", "J. K. Rowling", "Fantasy"),
                new Buch("Das Lied von Eis und Feuer – Die Herren von Winterfell", "George R. R. Martin", "Fantasy"),

                new Buch("Der Marsianer", "Andy Weir", "Science-Fiction"),
                new Buch("Dune – Der Wüstenplanet", "Frank Herbert", "Science-Fiction"),

                new Buch("1984", "George Orwell", "Dystopie"),
                new Buch("Die Tribute von Panem", "Suzanne Collins", "Dystopie"),

                new Buch("Mord im Orient-Express", "Agatha Christie", "Krimi"),
                new Buch("Der Hund von Baskerville", "Arthur Conan Doyle", "Krimi"),
                new Buch("Verblendung", "Stieg Larsson", "Krimi")
            };

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task3
            Console.WriteLine("Task3: Füge die Bücher zur Bibliothek hinzu.");

            foreach (var buch in buecher)
            {
                if (bibliothek.BuchHinzufuegen(buch)) { Console.WriteLine($"{buch.Titel} von {buch.Autor} erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }
            }
            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task4
            Console.WriteLine("Task4: Versuche, ein Buch doppelt hinzuzufügen.");

            if (bibliothek.BuchHinzufuegen(buecher[0])) { Console.WriteLine($"{buecher[0].Titel} von {buecher[0].Autor} erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim Hinzufügen"); }

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task5
            Console.WriteLine("Task5: Erstelle mindestens zwei Leser.");

            List<Leser> leser = new List<Leser>()
            {
                new Leser("Dani", 3),
                new Leser("Michael", 4),
                new Leser("Nils", 4),
                new Leser("Pezi", 5)
            };
            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task6
            Console.WriteLine("Task6: Registriere beide Leser.");

            foreach(var oneleser in leser)
            {
                if (bibliothek.LeserRegistrieren(oneleser)) { Console.WriteLine($"{oneleser.Name} erfolgreich hinzugefügt."); } else { Console.WriteLine("Fehler beim hinzufügen"); }
            }
            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task7
            Console.WriteLine("Task7: Lasse beide Leser mehrere Bücher ausleihen.");

            if (leser[0].BuchAusleihen(buecher[0])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }
            if (leser[0].BuchAusleihen(buecher[1])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }
            if (leser[0].BuchAusleihen(buecher[6])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }

            if (leser[1].BuchAusleihen(buecher[2])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }
            if (leser[1].BuchAusleihen(buecher[3])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }

            if (leser[2].BuchAusleihen(buecher[4])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }
            if (leser[2].BuchAusleihen(buecher[5])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task8
            Console.WriteLine("Task8: Versuche, ein bereits ausgeliehenes Buch erneut auszuleihen.");

            if (buecher[1].Ausleihen(leser[1].Name)) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task9
            Console.WriteLine("Task9: Überschreite bei einem Leser das Ausleihlimit.");

            if (leser[0].BuchAusleihen(buecher[7])) { Console.WriteLine("Buch erfolgreich verleiht"); } else { Console.WriteLine("Fehler beim Buch verleihen"); }

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task10
            Console.WriteLine("Task10: Gib alle ausgeliehenen Bücher eines Lesers aus.");

            leser[0].ZeigeAusgelieheneBuecher();

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task11
            Console.WriteLine("Task11: Gib ein Buch zurück.");

            if(leser[0].BuchZurueckgeben(buecher[0])) { Console.WriteLine("Buch erfolgreich zurückgegeben"); } else { Console.WriteLine("Fehler beim zurückgeben"); }

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task12
            Console.WriteLine("Task12: Versuche, ein Buch durch den falschen Leser zurückzugeben.");

            if (leser[1].BuchZurueckgeben(buecher[1])) { Console.WriteLine("Buch erfolgreich zurückgegeben"); } else { Console.WriteLine("Fehler beim zurückgeben"); }

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task13
            Console.WriteLine("Task13: Gib alle verfügbaren Bücher aus.");

            bibliothek.ZeigeVerfuegbareBuecher();

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion

            #region Task14
            Console.WriteLine("Task14: Gib alle Bücher einer bestimmten Kategorie aus.");

            bibliothek.ZeigeBuecherNachKategorie("Fantasy");

            Console.WriteLine();
            Console.WriteLine("======");
            #endregion
        }
    }
}
