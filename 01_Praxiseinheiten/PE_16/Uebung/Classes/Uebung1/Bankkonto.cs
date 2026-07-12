using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Uebung1
{
    class Bankkonto
    {
        public string Inhaber {  get; set; }
        public decimal Kontostand { get; private set; }

        public Bankkonto(string inhaber)
        {
            Inhaber = inhaber;
            Kontostand = 0;
        }

        public void Einzahlen(decimal betrag)
        {
            if(betrag < 0)
            {
                return;
            }

            Kontostand += betrag;
        }

        public void Abheben(decimal betrag)
        {
            if(Kontostand < betrag)
            {
                return;
            }
            Kontostand -= betrag;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine($"Inhaber: {Inhaber} ; Kontostand: {Kontostand}");
        }

    }
}
