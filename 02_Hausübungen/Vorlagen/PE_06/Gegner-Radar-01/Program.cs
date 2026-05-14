using System;

Random random = new Random();

int maxGegner = 3, zeilen = 2, spalten = 3; //Kann für größere Programme durchaus Sinn machen, falls man an verschiedenen stellen die Werte braucht

int[,] feld = new int[zeilen, spalten];

for  (int i = 0; i < feld.GetLength(0); i++)
{
    for (int j = 0; j < feld.GetLength(1); j++)
    {
        feld[i, j] = random.Next(0, maxGegner + 1);
    }
}

Console.WriteLine("Gegner-Radar-01");
Console.WriteLine("===============");
Console.WriteLine();

Console.WriteLine("Feld");

int spalte = 1;
int summe = 0;
foreach(int i in feld)
{
    Console.Write(i + " ");
    summe += i;
    spalte++;
    if(spalte > feld.GetLength(1))
    {
        Console.WriteLine();
        spalte = 1;
    }
}

Console.WriteLine();
Console.WriteLine($"Gegner gesamt: {summe}");