using System;
using Noten_Auswertung.Tools;

namespace Noten_Auswertung
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] grades;

            // Hier fragen wir ab, wie viele Noten eingegeben werden sollen.
            //
            // ZahlInput prüft die Eingabe.
            // min = 1 bedeutet: Es muss mindestens eine Note eingegeben werden.
            // max = -1 ist hier egal, weil maxActive auf false steht.
            int anzahl = Input.ZahlInput(1, -1, true, false, "Wie viele Noten möchtest du eingeben: ");

            Console.WriteLine();

            // Jetzt erstellen wir ein Array mit genau so vielen Speicherplätzen,
            // wie der Benutzer angegeben hat.
            grades = new int[anzahl];

            // Mit dieser for-Schleife werden alle Noten eingelesen.
            //
            // Die Noten müssen zwischen 1 und 5 liegen.
            // Deshalb sind minActive und maxActive beide true.
            for (int i = 0; i < anzahl; i++)
            {
                grades[i] = Input.ZahlInput(1, 5, true, true, $"Note {i + 1}: ");
            }

            // Der Durchschnitt wird einmal berechnet und gespeichert.
            // Dadurch müssen wir CalculateAverage nicht doppelt aufrufen.
            double average = GradeService.CalculateAverage(grades);

            Console.WriteLine();
            Console.WriteLine("--- Ergebnis ---");
            Console.WriteLine();

            Console.WriteLine($"Durchschnitt: {average:F1}");
            Console.WriteLine($"Beste Note: {GradeService.GetBestGrade(grades)}");
            Console.WriteLine($"Schlechteste Note: {GradeService.GetWorstGrade(grades)}");
            Console.WriteLine($"Bewertung: {GradeService.GetRating(average)}");
        }
    }
}