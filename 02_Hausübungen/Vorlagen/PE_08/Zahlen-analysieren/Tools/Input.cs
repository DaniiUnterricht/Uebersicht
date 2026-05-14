using System;
using System.Collections.Generic;
using System.Text;

namespace Zahlen_analysieren.Tools
{
    class Input
    {
        public static int Zahl(int min, int max, bool minActive, bool maxActive, string text)
        {
            int output;
            bool isTrue;

            do
            {
                Console.Write(text);
                isTrue = int.TryParse(Console.ReadLine(), out output);
                if (!isTrue)
                {
                    Console.WriteLine("Ungültige Eingabe");
                }
                else if (minActive && output < min)
                {
                    Console.WriteLine($"Eingabe zu klein, Minimum: {min}");
                    isTrue = false;
                }
                else if (maxActive && output > max)
                {
                    Console.WriteLine($"Eingabe zu groß, Maximum: {max}");
                    isTrue = false;
                }
            } while (!isTrue);

            return output;
        }
    }
}
