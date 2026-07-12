using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Uebung3
{
    class Item
    {
        public string Name { get; set; }
        public int Wert {  get; private set; }

        public Item(string name, int wert)
        {
            Name = name;

            Wert = wert;
        }
    }
}
