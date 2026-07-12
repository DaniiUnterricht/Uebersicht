using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Uebung.Classes.Uebung4
{
    class Gegner
    {
        public string Name { get; set; }
        public int Leben { get; private set; }
        public int Schaden { get; private set; }
        public int Belohnung { get; private set; }

        public Gegner(string name, int leben, int schaden, int belohnung)
        {
            Name = name;
            Leben = leben;
            Schaden = schaden;
            Belohnung = belohnung;
        }
        public void Damagedealer(Spieler gegner)
        {
            int dmg = Schaden;
            Random random = new Random();
            int krit = random.Next(1, 100);
            if (krit > 60)
            {
                dmg = dmg * 2;
            }
            gegner.Schadennehmen(dmg);
        }
        public void Schadennehmen(int dmg)
        {
            if (Leben < dmg)
            {
                Leben = 0;
            }
            else
            {
                Leben -= dmg;
            }
        }
        public bool StillAlive()
        {
            return Leben > 0;
        }
    }
}
