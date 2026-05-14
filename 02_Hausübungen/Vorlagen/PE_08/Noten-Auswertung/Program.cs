using System;
using Noten_Auswertung.Tools;

namespace Noten_Auswertung
{
    class Programm
    {
        static void Main(string[] args)
        {
            int[] grades;
            int anzahl = Input.ZahlInput(1, -1, true, false, "Wie viele Noten möchtest du eingeben: ");
            Console.WriteLine();

            grades = new int[anzahl];
            for (int i = 0; i < anzahl; i++)
            {
                grades[i] = Input.ZahlInput(1, 5, true, true, $"Note {i + 1}: ");
            }

            Console.WriteLine();
            Console.WriteLine("--- Ergebnis ---");
            Console.WriteLine();
            Console.WriteLine($"Durchschnitt: {GradeService.CalculateAverage(grades):F1}");
            Console.WriteLine($"Beste Note: {GradeService.GetBestGrade(grades)}");
            Console.WriteLine($"Schlechteste Note: {GradeService.GetWorstGrade(grades)}");
            Console.WriteLine($"Bewertung: {GradeService.GetRating(GradeService.CalculateAverage(grades))}");
        }
    }
}
