using System;

namespace CSharp.Methoden
{
    public class Methoden
    {
        // Diese Methode berechnet die Summe aller Punkte.
        //
        // punkte ist das Array mit den Punkten aller Spieler.
        //
        // Rückgabewert:
        // Die Gesamtpunkte als int.
        public static int BerechneGesamtpunkte(int[] punkte)
        {
            int summe = 0;

            for (int i = 0; i < punkte.Length; i++)
            {
                summe = summe + punkte[i];
            }

            return summe;
        }

        // Diese Methode berechnet den Durchschnitt.
        //
        // gesamtpunkte enthält die Summe aller Punkte.
        // anzahl enthält die Anzahl der Spieler.
        //
        // Der Cast auf double ist wichtig,
        // damit auch Kommazahlen möglich sind.
        public static double BerechneDurchschnitt(int gesamtpunkte, int anzahl)
        {
            return (double)gesamtpunkte / anzahl;
        }

        // Diese Methode findet den Index des Spielers
        // mit den meisten Punkten.
        //
        // Es wird nicht der Name zurückgegeben,
        // sondern nur die Position im Array.
        public static int FindeBestenSpielerIndex(int[] punkte)
        {
            int besterIndex = 0;

            for (int i = 0; i < punkte.Length; i++)
            {
                if (punkte[i] > punkte[besterIndex])
                {
                    besterIndex = i;
                }
            }

            return besterIndex;
        }

        // Diese Methode gibt die gesamte Auswertung aus.
        //
        // namen enthält die Spielernamen.
        // punkte enthält die Punkte der Spieler.
        // gesamtpunkte enthält die Summe aller Punkte.
        // durchschnitt enthält den Punktedurchschnitt.
        // besterIndex zeigt auf den besten Spieler.
        public static void GibAuswertungAus(string[] namen, int[] punkte, int gesamtpunkte, double durchschnitt, int besterIndex)
        {
            Console.WriteLine("Auswertung");
            Console.WriteLine("==========");
            Console.WriteLine();

            for (int i = 0; i < namen.Length; i++)
            {
                Console.WriteLine($"{namen[i]}: {punkte[i]} Punkte");
            }

            Console.WriteLine();
            Console.WriteLine($"Gesamtpunkte: {gesamtpunkte}");
            Console.WriteLine($"Durchschnitt: {durchschnitt:F1}");
            Console.WriteLine($"Bester Spieler: {namen[besterIndex]} mit {punkte[besterIndex]} Punkten");
        }

        // Zusatzaufgabe:
        // Diese Methode zählt,
        // wie viele Spieler mehr Punkte als der Durchschnitt erreicht haben.
        public static int ZaehleSpielerUeberDurchschnitt(int[] punkte, double durchschnitt)
        {
            int anzahl = 0;

            for (int i = 0; i < punkte.Length; i++)
            {
                if (punkte[i] > durchschnitt)
                {
                    anzahl++;
                }
            }

            return anzahl;
        }
    }
}