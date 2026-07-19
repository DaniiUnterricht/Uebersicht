using System;
using System.Collections.Generic;
using System.Text;

namespace Tierheimverwaltung.Classes
{
    public class Tierheim
    {
        #region Properties

        public string Name { get; private set; }
        public int MaximaleAnzahl { get; private set; }
        public List<Tier> Tiere { get; private set; }

        #endregion

        #region Konstruktor

        public Tierheim(string name, int maximaleAnzahl)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Der Name des Tierheims darf nicht leer sein.", nameof(name));
            }

            if (maximaleAnzahl <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maximaleAnzahl), "Die maximale Anzahl muss größer als 0 sein.");
            }

            Name = name;
            MaximaleAnzahl = maximaleAnzahl;
            Tiere = new List<Tier>();
        }

        #endregion

        #region Methoden

        public bool TierAufnehmen(Tier tier)
        {
            if (tier is null)
            {
                return false;
            }

            foreach (Tier vorhandenesTier in Tiere)
            {
                if (vorhandenesTier.Name.Equals(tier.Name, StringComparison.OrdinalIgnoreCase) && vorhandenesTier.Tierart.Equals(tier.Tierart, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{tier.Name} ({tier.Tierart}) befindet sich bereits im Tierheim.");

                    return false;
                }
            }

            if (Tiere.Count >= MaximaleAnzahl)
            {
                Console.WriteLine($"Das Tierheim {Name} ist bereits voll.");

                return false;
            }

            Tiere.Add(tier);

            Console.WriteLine($"{tier.Name} wurde im Tierheim {Name} aufgenommen.");

            return true;
        }

        public bool TierVermitteln(string tierName)
        {
            if (string.IsNullOrWhiteSpace(tierName))
            {
                Console.WriteLine("Der Tiername darf nicht leer sein.");

                return false;
            }

            Tier? gefundenesTier = null;

            foreach (Tier tier in Tiere)
            {
                if (tier.Name.Equals(tierName, StringComparison.OrdinalIgnoreCase))
                {
                    gefundenesTier = tier;
                    break;
                }
            }

            if (gefundenesTier is null)
            {
                Console.WriteLine($"Das Tier „{tierName}“ wurde nicht gefunden.");

                return false;
            }

            return gefundenesTier.Vermitteln();
        }

        public void ZeigeAlleTiere()
        {
            Console.WriteLine($"Alle Tiere im Tierheim {Name}:");
            Console.WriteLine();

            if (Tiere.Count == 0)
            {
                Console.WriteLine("Im Tierheim befinden sich aktuell keine Tiere.");

                return;
            }

            foreach (Tier tier in Tiere)
            {
                tier.ZeigeInfo();
            }
        }

        public void ZeigeNichtVermittelteTiere()
        {
            Console.WriteLine("Noch nicht vermittelte Tiere:");
            Console.WriteLine();

            bool tierGefunden = false;

            foreach (Tier tier in Tiere)
            {
                if (!tier.IstVermittelt)
                {
                    tier.ZeigeInfo();
                    tierGefunden = true;
                }
            }

            if (!tierGefunden)
            {
                Console.WriteLine("Alle Tiere wurden bereits vermittelt.");
            }
        }

        public int AnzahlNichtVermittelterTiere()
        {
            int anzahl = 0;

            foreach (Tier tier in Tiere)
            {
                if (!tier.IstVermittelt)
                {
                    anzahl++;
                }
            }

            return anzahl;
        }

        public void ZeigeTiereNachTierart(string tierart)
        {
            if (string.IsNullOrWhiteSpace(tierart))
            {
                Console.WriteLine("Die Tierart darf nicht leer sein.");

                return;
            }

            Console.WriteLine($"Tiere der Tierart {tierart}:");
            Console.WriteLine();

            bool tierGefunden = false;

            foreach (Tier tier in Tiere)
            {
                if (tier.Tierart.Equals(tierart, StringComparison.OrdinalIgnoreCase))
                {
                    tier.ZeigeInfo();
                    tierGefunden = true;
                }
            }

            if (!tierGefunden)
            {
                Console.WriteLine($"Es wurden keine Tiere der Tierart „{tierart}“ gefunden.");
            }
        }

        public Tier? FindeAeltestesTier()
        {
            if (Tiere.Count == 0)
            {
                return null;
            }

            Tier aeltestesTier = Tiere[0];

            foreach (Tier tier in Tiere)
            {
                if (tier.Alter > aeltestesTier.Alter)
                {
                    aeltestesTier = tier;
                }
            }

            return aeltestesTier;
        }

        #endregion
    }
}
