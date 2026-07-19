using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Bestellsystem.Classes
{
    class Produkt
    {
        #region Properties
        public string Name { get; private set; }
        public decimal Preis { get; private set; }
        public int Lagerbestand { get; private set; }
        #endregion

        #region Konstruktor
        public Produkt(string name, decimal preis, int lagerbestand)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(
                    "Der Produktname darf nicht leer sein.",
                    nameof(name)
                );
            }

            if (preis < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(preis),
                    "Der Preis darf nicht negativ sein."
                );
            }

            if (lagerbestand < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(lagerbestand),
                    "Der Lagerbestand darf nicht negativ sein."
                );
            }

            Name = name;
            Preis = preis;
            Lagerbestand = lagerbestand;
        }
        #endregion

        #region Methoden
        public bool IstVerfuegbar(int menge)
        {
            if(Lagerbestand < menge)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool LagerbestandReduzieren(int menge)
        {
            if (menge > 0 && menge <= Lagerbestand)
            {
                Lagerbestand -= menge;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Nachbestellen(int menge)
        {
            if(menge <= 0)
            {
                return;
            }

            Lagerbestand += menge;
        }

        public void PreisAendern(decimal neuerPreis)
        {
            if (neuerPreis < 0)
            {
                return;
            }

            Preis = neuerPreis;
        }

        public void ZeigeInfo()
        {
            Console.WriteLine($"{Name} - {Preis} - Lagerbestand: {Lagerbestand} Stück");
        }
        #endregion
    }
}
