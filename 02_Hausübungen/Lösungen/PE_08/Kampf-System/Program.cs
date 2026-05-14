using System;
using Kampf_System.Tools;

namespace Kampf_System
{
    class Program
    {
        static void Main(string[] args)
        {
            // Das gesamte Spiel läuft in einer do-while-Schleife.
            //
            // Dadurch wird das Spiel mindestens einmal gestartet.
            // Am Ende entscheidet AskRepeat(),
            // ob das Spiel erneut gestartet werden soll.
            do
            {
                Random rnd = new Random();

                Console.Write("Spielername: ");
                string playername = Console.ReadLine();

                int startleben = Input.ZahlInput(1, -1, true, false, "Start-Leben: ");
                int angriff = Input.ZahlInput(1, -1, true, false, "Angriff: ");
                int crit = Input.ZahlInput(0, 100, true, true, "Krit-Chance in %: ");

                Console.WriteLine();

                int enemyHP = Input.ZahlInput(1, -1, true, false, "Gegner Leben: ");

                Console.WriteLine();
                Console.WriteLine("--- Kampf startet ---");
                Console.WriteLine();

                // Diese Schleife läuft so lange,
                // wie der Gegner noch mehr als 0 Leben hat.
                do
                {
                    bool isCritical = PlayerService.IsCriticalHit(crit, rnd);
                    int damage = PlayerService.CalculateDamage(angriff, isCritical);

                    enemyHP = PlayerService.ApplyDamage(enemyHP, damage);

                    PlayerService.PrintAttackResult(damage, isCritical, enemyHP);

                } while (enemyHP > 0);

                Console.WriteLine("Gegner besiegt!");
                Console.WriteLine();

            } while (PlayerService.AskRepeat());
        }
    }
}