using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Uebung.Classes.Uebung2
{
    class Spieler
    {
        public string Name { get; set; }
        public int Leben { get; private set; }
        public int MaxLeben { get; private set; }

        public Spieler(string name, int maxleben)
        {
            if(maxleben <= 0)
            {
                return;
            }
            Name = name;
            MaxLeben = maxleben;
            Leben = MaxLeben - 100;
        }

        public void TrankVerwenden(Heiltrank trank)
        {
            if(MaxLeben < Leben + trank.Heilwert)
            {
                Leben = MaxLeben;
            }
            else
            {
                Leben += trank.Heilwert;
            }

        }
    }
}
