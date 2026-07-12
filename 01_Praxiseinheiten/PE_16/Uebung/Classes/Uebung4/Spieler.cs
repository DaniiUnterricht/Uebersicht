using System;
using System.Collections.Generic;
using System.Text;

namespace Uebung.Classes.Uebung4
{
    class Spieler
    {
        public string Name { get; set; }
        public int Leben { get; private set; }
        public int Damage { get; private set; }

        public Spieler(string name, int leben, int damage)
        {
            Name = name;
            Leben = leben;
            Damage = damage;
        }

        public void Damagedealer(Gegner gegner)
        {
            int dmg = Damage;
            Random random = new Random();
            int krit = random.Next(1, 100);
            if (krit > 40)
            {
                dmg = dmg * 2;
            }
            gegner.Schadennehmen(dmg);
            Console.WriteLine($"    {dmg} Schaden gemacht!");
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
            Console.WriteLine($"    {dmg} Schaden erhalten!");
        }

        public bool StillAlive()
        {
            return Leben > 0;
        }
    }
}
