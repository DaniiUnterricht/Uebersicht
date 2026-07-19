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
            auto.Beschleunigen(________);
            motorrad.Beschleunigen(________);
            fahrrad.Beschleunigen(________);

            //Speichere alle Fahrzeuge in einer Liste
            List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
            {
                ___________________,
                ___________________,
                ___________________
            };

            //Durchlaufe die Liste und gibt ZeigeInfo() aus
            foreach (Fahrzeug fahrzeug in fahrzeuge)
            {
                ____________________________
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

            ---
            2.) Welche Properties übernimmt Motorrad von Fahrzeug?

            ---
            3.) Was bewirkt base(marke) ?

            ---
            4.) Warum ist ZeigeInfo() in Fahrzeug als virtual definiert?

            ---
            5.) Was bewirkt override?

            ---
            6.) Warum können Auto, Motorrad und Fahrrad gemeinsam in einer List<Fahrzeug> gespeichert werden?

            ---
            7.) Welche Methode wird bei einem Auto innerhalb der Schleife ausgeführt?

            ---
            */

        }
    }
}
