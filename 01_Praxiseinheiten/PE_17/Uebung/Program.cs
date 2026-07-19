using System;
using Uebung.Classes;
using Uebung.Classes.Fahrzeuge;

namespace Uebung
{
    class Program
    {
        static void Main(string[] args)
        {
            Auto auto = new Auto("BMW", 5);
            Motorrad motorrad = new Motorrad("Honda", false);
            Fahrrad fahrrad = new Fahrrad("KTM", 21);

            //Vervollständige mit Auto 70km/h, Motorrad 90 km/h, Fahrrad 25 km/h
            auto.Beschleunigen(70);
            motorrad.Beschleunigen(90);
            fahrrad.Beschleunigen(25);

            //Speichere alle Fahrzeuge in einer Liste
            List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
            {
                auto,
                motorrad,
                fahrrad,
                new Auto("Renault", 3)
            };

            //Hier wird jetzt die Geschwindigkeit vom zuvor definierten Renault gesetzt ( Durch Aufruf mit Index )
            fahrzeuge[3].Beschleunigen(60);

            //Durchlaufe die Liste und gibt ZeigeInfo() aus
            foreach (Fahrzeug fahrzeug in fahrzeuge)
            {
                fahrzeug.ZeigeInfo();
                Console.WriteLine();
            }
            //Obwohl die Variable innerhalb der Schleife vom Typ Fahrzeug ist, soll jeweils die passende Methode von Auto, Motorrad oder Fahrrad ausgeführt werden.

            //Erwartete Ausgabe:
            /*
            Fahrzeug der Marke BMW
            Geschwindigkeit: 70 km / h
            Anzahl der Türen: 5

            Fahrzeug der Marke Honda
            Geschwindigkeit: 90 km / h
            Beiwagen: Nein

            Fahrzeug der Marke KTM
            Geschwindigkeit: 25 km / h
            Anzahl der Gänge: 21
            */

            //Fragen zum Abschluss:
            /*
            1.) Von welcher Klasse erbt Auto?
            Fahrzeug.cs -> class Fahrzeug
            ---
            2.) Welche Properties übernimmt Motorrad von Fahrzeug?
            Marke und Geschwindigkeit
            ---
            3.) Was bewirkt base(marke) ?
            Es Führt den Konstruktor von Fahrzeug aus.
            ---
            4.) Warum ist ZeigeInfo() in Fahrzeug als virtual definiert?
            Dadurch wird erlaubt, dass die abgeleiteten Klassen diese Methode Überschreiben können.
            ---
            5.) Was bewirkt override?
            Überschreibt die Methode der Basis Klasse komplett.
            ---
            6.) Wie kann ich dennoch diesen Code aus der Methode in der Basisklasse auch in der abgeleiteten Klasse ausführen lassen? ( beim override )
            base.Methodenname();
            ---
            7.) Warum können Auto, Motorrad und Fahrrad gemeinsam in einer List<Fahrzeug> gespeichert werden?
            Weil alle die selbe Basis Klasse ( Fahrzeug ) besitzen.
            ---
            */

        }
    }
}
