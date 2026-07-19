using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes
{
    public class Fahrzeug
    {
        #region Properties

        public string Marke { get; protected set; }
        public int Geschwindigkeit { get; protected set; }

        #endregion

        #region Konstruktor

        public Fahrzeug(string marke)
        {
            if (string.IsNullOrWhiteSpace(marke))
            {
                throw new ArgumentException("Die Marke darf nicht leer sein.", nameof(marke));
            }

            Marke = marke;
            Geschwindigkeit = 0;
        }

        #endregion

        #region Methoden

        public void Beschleunigen(int geschwindigkeit)
        {
            if (geschwindigkeit <= 0)
            {
                Console.WriteLine("Die Geschwindigkeit muss größer als 0 sein.");

                return;
            }

            Geschwindigkeit += geschwindigkeit;
        }

        public virtual void ZeigeInfo()
        {
            Console.WriteLine($"Fahrzeug der Marke {Marke}");
            Console.WriteLine($"Geschwindigkeit: {Geschwindigkeit} km/h");
        }

        #endregion
    }
}
