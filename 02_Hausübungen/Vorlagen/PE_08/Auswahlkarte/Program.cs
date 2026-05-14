using System;
using Auswahlkarte.Tools;

namespace Auswahlkarte
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] data = new string[3][];
            data[0] = new string[] { "Pizza","Pasta" };
            data[1] = new string[] { "Cola", "Wasser","Saft" };
            data[2] = new string[] { "Eis", "Kuchen" };

            Console.WriteLine("--- Menü ---");
            Console.WriteLine();

            JaggedArrayService.PrintJaggedArray(data);

            Console.WriteLine();

            int kategorie = Input.ZahlenInput(1, data.Length, "Kategorie wählen: ") - 1;
            int element = Input.ZahlenInput(1, data[kategorie].Length, "Element wählen: ") - 1;

            Console.WriteLine();
            Console.WriteLine($"Du hast gewählt: {JaggedArrayService.GetItem(data, kategorie, element)}");
        }
    }
}
