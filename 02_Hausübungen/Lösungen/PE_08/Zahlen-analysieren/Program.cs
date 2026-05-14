using System;
using Zahlen_analysieren.Tools;

namespace Zahlen_analysieren
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers;

            // Hier fragen wir ab, wie viele Zahlen eingegeben werden sollen.
            //
            // min = 1 bedeutet:
            // Es muss mindestens eine Zahl eingegeben werden.
            //
            // max = -1 ist hier egal,
            // weil maxActive auf false steht.
            int anzahl = Input.Zahl(1, -1, true, false, "Wie viele Zahlen möchtest du eingeben: ");

            Console.WriteLine();

            // Jetzt erstellen wir ein Array mit genau so vielen Speicherplätzen,
            // wie der Benutzer angegeben hat.
            numbers = new int[anzahl];

            // Mit dieser for-Schleife werden alle Zahlen eingelesen.
            for (int i = 0; i < anzahl; i++)
            {
                numbers[i] = Input.Zahl(1, -1, true, false, $"Zahl {i + 1}: ");
            }

            Console.WriteLine();
            Console.WriteLine("--- Auswertung ---");
            Console.WriteLine();

            Console.Write("Eingegebene Zahlen: ");
            NumberService.PrintNumbers(numbers);

            Console.WriteLine($"Summe: {NumberService.Sum(numbers)}");
            Console.WriteLine($"Durchschnitt: {NumberService.Average(numbers):F1}");
            Console.WriteLine($"Größte Zahl: {NumberService.Max(numbers)}");
        }
    }
}