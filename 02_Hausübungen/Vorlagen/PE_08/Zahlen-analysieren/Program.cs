using System;
using Zahlen_analysieren.Tools;

namespace Zahlen_analysieren
{
    class Programm
    {
        static void Main(string[] args)
        {
            int[] numbers;
            int anzahl = Input.Zahl(1, -1, true, false, "Wie viele Zahlen möchtest du eingeben: ");
            Console.WriteLine();

            numbers = new int[anzahl];
            for (int i = 0; i < anzahl; i++)
            {
                numbers[i] = Input.Zahl(1, -1, true, false, $"Zahl {i + 1}: ");
            }

            Console.WriteLine();
            Console.WriteLine("--- Auswertung ---");
            Console.WriteLine();

            Console.Write($"Eingegeben Zahlen: "); NumberService.PrintNumbers(numbers);
            Console.WriteLine($"Summe: {NumberService.Sum(numbers)}");
            Console.WriteLine($"Durschnitt: {NumberService.Average(numbers)}");
            Console.WriteLine($"Größte Zahl: {NumberService.Max(numbers)}");
        }
    }
}
