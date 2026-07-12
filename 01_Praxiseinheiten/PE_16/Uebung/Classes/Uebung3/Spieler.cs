using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Uebung3
{
    class Spieler
    {
        public string Name { get; set; }

        public List<Item> Items { get; private set; }

        public Spieler(string name)
        {
            Name = name;
            Items = new List<Item>();
        }

        public void ItemAufnehmen(Item item)
        {
            Items.Add(item);
        }
        public void InventarAusgeben()
        {
            Console.WriteLine($"Inventar von {Name}");

            foreach (var item in Items)
            {
                Console.WriteLine($"    Name: {item.Name} ; Wert: {item.Wert}");
            }
        }
        public void GesamtwertBerechnen()
        {
            int gesamtwert = 0;
            foreach (var item in Items)
            {
                gesamtwert += item.Wert;
            }

            Console.WriteLine($"Gesamtwert: {gesamtwert}");
        }
    }
}
