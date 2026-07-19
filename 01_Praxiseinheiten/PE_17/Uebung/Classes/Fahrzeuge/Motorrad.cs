using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Fahrzeuge
{
    class Motorrad : Fahrzeug
    {
        public bool HatBeiwagen { get; private set; }

        public Motorrad(string marke, bool hatBeiwagen) : base(marke)
        {
            HatBeiwagen = hatBeiwagen;
        }

        //Überschreibe ZeigeInfo, hierbei soll die vorhandene Ausgabe aus der Basisklasse mit verwendet werden und Beiwagen: Ja/Nein zusätzlich ausgegeben werden
        public override void ZeigeInfo()
        {
            base.ZeigeInfo();

            string beiwagenText = HatBeiwagen ? "Ja" : "Nein";
            /*
             * Lange Schreibweise:
            if(HatBeiwagen)
            {
               beiwagenText = "Ja";
            }
            else
            {
                beiwagenText = "Nein";
            }
            */

            Console.WriteLine($"Hatbeiwagen: {beiwagenText}");

        }
    }
}
