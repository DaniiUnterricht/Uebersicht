using System;
using System.Collections.Generic;
using System.Text;

namespace Bestellsystem.Classes
{
    class Bestellposition
    {
        #region Properties
        public Produkt Produkt { get; private set; }
        public int Menge { get; private set; }
        #endregion

        #region Konstruktor
        public Bestellposition(Produkt produkt, int menge)
        {
            Produkt = produkt;
            Menge = menge;
        }
        #endregion

        #region Methoden
        public decimal BerechnePreis()
        {
            return Produkt.Preis * Menge;
        }

        public bool MengeErhoehen(int menge)
        {
            if (menge < 0 || Produkt.Lagerbestand < menge + Menge)
            {
                return false;
            }

            Menge += menge;
            return true;
        }
        #endregion
    }
}
