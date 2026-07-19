using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Fahrzeuge
{
    class Fahrrad : Fahrzeug
    {
        public int AnzahlGaenge { get; private set; }

        //Vervollständige den Konstruktor
        //Dabei gilt:
            //Die Anzahl der Gänge muss größer als 0 sein.
        public Fahrrad(string marke, int anzahlGaenge) : base(marke)
        {
            /**/
        }

        //Überschreibe ZeigeInfo, hierbei soll die vorhandene Ausgabe aus der Basisklasse mit verwendet werden und Zusätzlich die Anzahl der Gänge angezeigt werden
        public override void ZeigeInfo()
        {
            base.ZeigeInfo();
            /**/
        }
    }
}
