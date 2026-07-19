using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Uebung.Classes.Fahrzeuge
{
    class Auto : Fahrzeug
    {
        public int AnzahlTueren { get; private set; }

        //Vervollständige den Konstruktor
        //Dabei gilt:
            //Die Anzahl der Türen muss größer als 0 sein.
            //Die Marke wird an den Konstruktor der Basisklasse weitergegeben.
        public Auto(string marke, int anzahlTueren) : base(marke)
        {
            if(anzahlTueren <= 0)
            {
                Console.WriteLine("Die Anzahl der Türen darf nicht weniger als 1 sein");
                return;
            }

            AnzahlTueren = anzahlTueren;
        }

        //Überschreibe ZeigeInfo, hierbei soll die vorhandene Ausgabe aus der Basisklasse mit verwendet werden
        public override void ZeigeInfo()
        {
            base.ZeigeInfo();

            Console.WriteLine($"Anzahl der Türen: {AnzahlTueren}");
        }

    }
}
