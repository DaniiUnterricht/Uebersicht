/*
 * Schüler sollen sich ein Beispiel ausdenken
*/


/*
 * Der User soll sich seine Ausrüstung auswählen
 * Waffe: Bogen, Schwert, Axt
 * Schutz: Schild, Helm, Körperpanzerung Leder, Körperpanzerung Eisen
 * Tränke: Heiltrank, Manatrank, Schutztrank
 * Am Schluss soll seine Ausgabe angezeigt werden
*/

string[] waffe = { "Bogen", "Schwert", "Axt" };
string[] schutz = { "Schild", "Hörner Helm", "Körperpanzerung Leder", "Körperpanzerung Eisen" };
string[] traenke = { "Heiltrank", "Manatrank", "Schutztrank" };

List<string> inventar =  new List<string>();

Console.WriteLine("Inventar-auswahl");
inventar.Add(Auswahl(waffe, "Waffe"));
inventar.Add(Auswahl(schutz, "Schutz"));
inventar.Add(Auswahl(traenke, "Tränke"));

foreach(string s in inventar)
{
    Console.WriteLine(s);
}

string Auswahl(string[] items, string typ)
{
    Console.Write($"{typ}: ");

   for(int i = 0; i < items.Length; i++)
   {
        Console.Write($"{items[i]} ({i+1}) ");
        if(i != items.Length - 1)
        {
            Console.Write(", ");
        }
   }
    Console.Write(": ");
    int input = int.Parse(Console.ReadLine());

    input--;
    return items[input];
}