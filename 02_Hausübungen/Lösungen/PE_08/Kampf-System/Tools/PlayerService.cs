using System;

namespace Kampf_System.Tools
{
    class PlayerService
    {
        // Diese Methode entscheidet,
        // ob ein Angriff ein kritischer Treffer ist.
        //
        // critChance ist die Krit-Chance in Prozent.
        // Beispiel:
        // critChance = 25 bedeutet 25%.
        //
        // random.Next(0, 100) erzeugt eine Zahl von 0 bis 99.
        // Wenn diese Zahl kleiner als critChance ist,
        // zählt der Angriff als kritischer Treffer.
        public static bool IsCriticalHit(int critChance, Random random)
        {
            int zufallszahl = random.Next(0, 100);

            if (zufallszahl < critChance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Diese Methode berechnet den tatsächlichen Schaden.
        //
        // Wenn der Treffer kritisch ist,
        // wird der Schaden verdoppelt.
        //
        // Wenn der Treffer nicht kritisch ist,
        // bleibt der Schaden unverändert.
        public static int CalculateDamage(int damage, bool isCritical)
        {
            if (isCritical)
            {
                return damage * 2;
            }
            else
            {
                return damage;
            }
        }

        // Diese Methode zieht dem Gegner Leben ab.
        //
        // enemyHealth ist das aktuelle Leben des Gegners.
        // attackDamage ist der Schaden des aktuellen Angriffs.
        //
        // Rückgabewert:
        // Das neue Leben des Gegners.
        public static int ApplyDamage(int enemyHealth, int attackDamage)
        {
            enemyHealth = enemyHealth - attackDamage;

            // Wenn der Schaden größer ist als das restliche Leben,
            // könnte enemyHealth negativ werden.
            //
            // Für die Ausgabe ist 0 schöner als z. B. -10.
            if (enemyHealth < 0)
            {
                enemyHealth = 0;
            }

            return enemyHealth;
        }

        // Diese Methode gibt das Ergebnis eines Angriffs aus.
        //
        // damage zeigt den verursachten Schaden.
        // isCritical zeigt, ob es ein kritischer Treffer war.
        // enemyHealth zeigt das verbleibende Leben des Gegners.
        public static void PrintAttackResult(int damage, bool isCritical, int enemyHealth)
        {
            Console.WriteLine("Du greifst an!");

            if (isCritical)
            {
                Console.WriteLine($"Kritischer Treffer! {damage} Schaden");
            }
            else
            {
                Console.WriteLine($"Treffer: {damage} Schaden");
            }

            Console.WriteLine($"Gegner Leben: {enemyHealth}");
            Console.WriteLine();
        }

        // Diese Methode fragt,
        // ob der Benutzer erneut spielen möchte.
        //
        // Gibt der Benutzer "y" ein, wird true zurückgegeben.
        // Gibt der Benutzer "n" ein, wird false zurückgegeben.
        //
        // Bei ungültigen Eingaben wird erneut gefragt.
        public static bool AskRepeat()
        {
            string eingabe;

            do
            {
                Console.Write("Erneut spielen? (y/n): ");
                eingabe = Console.ReadLine().ToLower();

                if (eingabe == "y")
                {
                    return true;
                }
                else if (eingabe == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe!");
                }

            } while (eingabe != "y" && eingabe != "n");

            return false;
        }
    }
}