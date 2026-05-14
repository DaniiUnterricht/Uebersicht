using System;

namespace Zahlen_analysieren.Tools
{
    internal class NumberService
    {
        // Diese Methode gibt alle Zahlen aus dem Array aus.
        //
        // Die Zahlen sollen in einer Zeile ausgegeben werden.
        // Zwischen den Zahlen steht ein Komma.
        // Nach der letzten Zahl soll kein Komma mehr stehen.
        public static void PrintNumbers(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);

                if (i < numbers.Length - 1)
                {
                    Console.Write(", ");
                }
            }

            Console.WriteLine();
        }

        // Diese Methode berechnet die Summe aller Zahlen.
        //
        // numbers ist das Array mit allen eingegebenen Zahlen.
        //
        // Rückgabewert:
        // Die Summe aller Werte als int.
        public static int Sum(int[] numbers)
        {
            int summe = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                summe = summe + numbers[i];
            }

            return summe;
        }

        // Diese Methode berechnet den Durchschnitt aller Zahlen.
        //
        // Dafür verwenden wir die Sum-Methode,
        // damit die Summenberechnung nicht doppelt geschrieben werden muss.
        public static double Average(int[] numbers)
        {
            // Der Cast auf double ist wichtig,
            // damit auch Kommazahlen als Ergebnis möglich sind.
            return (double)Sum(numbers) / numbers.Length;
        }

        // Diese Methode sucht die größte Zahl im Array.
        public static int Max(int[] numbers)
        {
            // Als Startwert nehmen wir die erste Zahl aus dem Array.
            // Dadurch haben wir einen sinnvollen Vergleichswert.
            int max = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }

            return max;
        }
    }
}