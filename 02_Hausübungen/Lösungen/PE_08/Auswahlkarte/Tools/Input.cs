using System;

namespace Auswahlkarte.Tools
{
    internal class Input
    {
        // Diese Methode fragt so lange eine Zahl ab,
        // bis der Benutzer eine gültige Zahl im erlaubten Bereich eingibt.
        //
        // min  -> kleinste erlaubte Zahl
        // max  -> größte erlaubte Zahl
        // text -> Text, der vor der Eingabe angezeigt wird
        //
        // Rückgabewert:
        // Die gültige Zahl des Benutzers.
        public static int ZahlenInput(int min, int max, string text)
        {
            bool isTrue;
            int zahl;

            do
            {
                Console.Write(text);
                isTrue = int.TryParse(Console.ReadLine(), out zahl);

                // Die Eingabe ist ungültig, wenn:
                // - sie keine Zahl ist
                // - sie kleiner als min ist
                // - sie größer als max ist
                if (!isTrue || zahl < min || zahl > max)
                {
                    Console.WriteLine($"Ungültige Eingabe! Bitte geben Sie eine Zahl von {min} bis {max} ein.");
                    isTrue = false;
                }

            } while (!isTrue);

            return zahl;
        }
    }
}