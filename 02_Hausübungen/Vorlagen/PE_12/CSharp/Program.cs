using System;
using CSharp.Methoden;
class Program
{
    static void Main()
    {
        Console.WriteLine("Punkte-System");
        Console.WriteLine("=============");
        Console.WriteLine();

        string[] namen = { "Dani", "Michael", "Nils", "Pezi" };
        int[] punkte = { 120, 100, 150, 100 };

        int gesamtpunkte = Methoden.BerechneGesamtpunkte(punkte);
        double durchschnitt = Methoden.BerechneDurchschnitt(gesamtpunkte, punkte.Length);
        int besterIndex = Methoden.FindeBestenSpielerIndex(punkte);

        Methoden.GibAuswertungAus(namen, punkte, gesamtpunkte, durchschnitt, besterIndex);
    }
}
