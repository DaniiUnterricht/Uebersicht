using System;

Console.WriteLine("Schaden-Protokoll-01");
Console.WriteLine("====================");
Console.WriteLine();

bool isTrue;
int lvl;

do
{
    Console.Write("Anzahl Level: ");
    isTrue = int.TryParse(Console.ReadLine(), out lvl);
    if(!isTrue)
    {
        Console.WriteLine("Ungültige Eingabe!");
    }
} while(!isTrue);

int[,] rounds = new int[lvl, 3];
Console.WriteLine();

for(int i = 0; i < rounds.GetLength(0); i++)
{
    Console.WriteLine($"Level {i + 1}");
    for(int j = 0; j < rounds.GetLength(1); j++)
    {
        do
        {
            Console.Write($"Runde {j + 1}: ");
            isTrue = int.TryParse(Console.ReadLine(), out rounds[i,j]);
            if (!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
        } while (!isTrue);
    }
    Console.WriteLine();
}

//Variante mit foreach <-- Möglich, aber mit umwegen, 2 forschleifen wären besser gewesen
int spalte = 1, summe = 0, gesamtsumme = 0, aktlvl = 1;
foreach(int i in rounds)
{
    summe += i;
    spalte++;
    if(spalte > rounds.GetLength(1))
    {
        Console.WriteLine($"Schaden Level {aktlvl}: {summe}");

        gesamtsumme += summe;

        spalte = 1; 
        summe = 0; 
        aktlvl++;
    }
}
Console.WriteLine();
Console.WriteLine($"Gesamtschaden: {gesamtsumme}");