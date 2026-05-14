using System;

namespace Noten_Auswertung.Tools
{
    internal class GradeService
    {
        // Diese Methode berechnet den Durchschnitt aller Noten.
        //
        // grades ist das Array mit allen eingegebenen Noten.
        //
        // Rückgabewert:
        // Der Durchschnitt als double.
        public static double CalculateAverage(int[] grades)
        {
            int summe = 0;

            // Mit dieser for-Schleife gehen wir alle Noten durch
            // und addieren sie zur Summe.
            for (int i = 0; i < grades.Length; i++)
            {
                summe = summe + grades[i];
            }

            // Der Cast auf double ist wichtig,
            // damit auch Kommazahlen als Ergebnis möglich sind.
            //
            // Beispiel:
            // 8 / 3 wäre mit int-Werten 2.
            // (double)8 / 3 ergibt 2.666...
            return (double)summe / grades.Length;
        }

        // Diese Methode sucht die beste Note.
        //
        // Bei Schulnoten ist die kleinste Zahl die beste Note.
        // Deshalb ist 1 besser als 2, 3, 4 oder 5.
        public static int GetBestGrade(int[] grades)
        {
            // Als Startwert nehmen wir die erste Note aus dem Array.
            // Dadurch haben wir einen sinnvollen Wert,
            // mit dem wir die restlichen Noten vergleichen können.
            int bestGrade = grades[0];

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] < bestGrade)
                {
                    bestGrade = grades[i];
                }
            }

            return bestGrade;
        }

        // Diese Methode sucht die schlechteste Note.
        //
        // Bei Schulnoten ist die größte Zahl die schlechteste Note.
        public static int GetWorstGrade(int[] grades)
        {
            // Als Startwert nehmen wir wieder die erste Note aus dem Array.
            int worstGrade = grades[0];

            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] > worstGrade)
                {
                    worstGrade = grades[i];
                }
            }

            return worstGrade;
        }

        // Diese Methode gibt eine verbale Bewertung
        // passend zum Durchschnitt zurück.
        //
        // Die Grenzen können natürlich je nach gewünschter Bewertung
        // angepasst werden.
        public static string GetRating(double average)
        {
            if (average <= 1.5)
            {
                return "Sehr gut";
            }
            else if (average <= 2.5)
            {
                return "Gut";
            }
            else if (average <= 3.5)
            {
                return "Befriedigend";
            }
            else if (average <= 4.5)
            {
                return "Genügend";
            }
            else
            {
                return "Nicht genügend";
            }
        }
    }
}