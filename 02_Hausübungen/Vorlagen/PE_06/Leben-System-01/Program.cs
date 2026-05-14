using System;

bool isTrue;
int lvl, rounds;

Console.WriteLine("Leben-System-01");
Console.WriteLine("===============");
Console.WriteLine();

do
{
    Console.Write("Wie viele Level gibt es: ");
    isTrue = int.TryParse(Console.ReadLine(), out lvl);
    if(!isTrue)
    {
        Console.WriteLine("Ungültige Eingabe");
    }
} while (!isTrue);

do
{
    Console.Write("Wie viele Runden gibt es: ");
    isTrue = int.TryParse(Console.ReadLine(), out rounds);
    if (!isTrue)
    {
        Console.WriteLine("Ungültige Eingabe");
    }
} while (!isTrue);

int[,] leben = new int[lvl, rounds];
Console.WriteLine();
for ( int i = 0; i < leben.GetLength(0);i++)
{
    Console.WriteLine($"Level {i + 1}");
    for ( int j = 0; j < leben.GetLength(1);j++)
    {
        do
        {
            Console.Write($"Runde {j + 1}: ");
            isTrue = int.TryParse(Console.ReadLine(), out leben[i,j]);
            if (!isTrue)
            {
                Console.WriteLine("Ungültige Eingabe");
            }
        } while (!isTrue);
    }
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine("--------");
Console.WriteLine();

for (int i = 0; i < leben.GetLength(0); i++)
{
    Console.WriteLine($"Level {i + 1}");
    Console.WriteLine($"Startleben: {leben[i, 0]}");
    int heilung = 0, schaden = 0;
    for (int j = 1;j < leben.GetLength(1); j++)
    {
        if (leben[i,j-1] >  leben[i,j])
        {
            schaden += leben[i, j - 1] - leben[i, j];
        }
        else
        {
            heilung += leben[i, j] - leben[i, j - 1];
        }
    }
    Console.WriteLine($"Heilung: {heilung}");
    Console.WriteLine($"Schaden: {schaden}");
    Console.WriteLine();
}

Console.WriteLine($"Endleben: {leben[leben.GetLength(0)-1,leben.GetLength(1)-1]}");