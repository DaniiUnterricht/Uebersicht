using System;
using System.Collections.Generic;
using System.Text;

namespace Bestellsystem.Classes
{
    class Bestellung
    {
        #region Properties
        public int Bestellnummer { get; private set; }
        public string Kundenname { get; private set; }
        public List<Bestellposition> Positionen { get; private set; }
        public bool IstAbgeschlossen { get; private set; }
        #endregion

        #region Konstruktor
        public Bestellung(int bestellnummer, string kundenname)
        {
            Bestellnummer = bestellnummer;
            Kundenname = kundenname;
            Positionen = new List<Bestellposition>();
            IstAbgeschlossen = false;
        }
        #endregion

        #region Methoden
        public bool ProduktHinzufuegen(Produkt produkt, int menge)
        {
            if (menge <= 0 || menge > produkt.Lagerbestand || IstAbgeschlossen)
            {
                return false;
            }

            foreach (var position in Positionen)
            {
                if (position.Produkt == produkt)
                {
                    return position.MengeErhoehen(menge);
                }
            }

            Positionen.Add(new Bestellposition(produkt, menge));
            return true;
        }

        public bool ProduktEntfernen(string produktName)
        {
            if (IstAbgeschlossen) return false;

            foreach (var position in Positionen)
            {
                if (position.Produkt.Name == produktName)
                {
                    Positionen.Remove(position);
                    return true;
                }
            }
            return false;
        }

        public decimal BerechneGesamtpreis()
        {
            decimal summe = 0;
            foreach (var position in Positionen)
            {
                summe += position.BerechnePreis();
            }
            return summe;
        }

        public bool BestellungAbschliessen()
        {
            if(IstAbgeschlossen)
            {
                return false;
            }

            foreach (var position in Positionen)
            {
                if(position.Menge > position.Produkt.Lagerbestand)
                {
                    return false;
                }
            }
            foreach(var position in Positionen)
            {
                position.Produkt.LagerbestandReduzieren(position.Menge);
            }
            IstAbgeschlossen = true;
            return true;
        }

        public void ZeigeBestellung()
        {
            Console.WriteLine($"Bestellung Nr. {Bestellnummer}");
            Console.WriteLine($"Kunde: {Kundenname}");
            Console.WriteLine();
            foreach (var position in Positionen)
            {
                Console.WriteLine($"{position.Menge} x {position.Produkt.Name} zu je {position.Produkt.Preis} € = {position.BerechnePreis()} € ");
            }
            Console.WriteLine();
            Console.WriteLine($"{BerechneGesamtpreis()} €");
            if (IstAbgeschlossen) { Console.WriteLine("Status: Abgeschlossen"); } else { Console.WriteLine("Status: Offen"); }
        }
        #endregion
    }
}
