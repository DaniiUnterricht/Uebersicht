using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Uebung2
{
    class Heiltrank
    {
        public string Name { get; set; }
        public int Heilwert { get; set; }

        public Heiltrank(string name, int heilwert)
        {
            Name = name;
            if (heilwert < 0)
            {
                Heilwert = 50;
            }
            else
            { 
                Heilwert = heilwert;
            }
        }
    }
}
