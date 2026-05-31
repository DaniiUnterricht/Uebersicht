using System;
using System.Collections.Generic;
using System.Text;

namespace InventarSystem
{
    class Methoden
    {
        public static int Menue()
        {
            // TODO: Menü anzeigen
            // TODO: Auswahl einlesen und prüfen
            return 0;
        }

        public static void InventarAnzeigen(Dictionary<string, int> inventar)
        {
            // TODO: Alle Items mit Anzahl anzeigen
        }

        public static void ItemHinzufuegen(Dictionary<string, int> inventar)
        {
            // TODO: Itemname einlesen
            // TODO: Anzahl einlesen
            // TODO: Prüfen, ob Item bereits existiert
            // TODO: Item hinzufügen
        }

        public static void ItemAnzahlErhoehen(Dictionary<string, int> inventar)
        {
            // TODO: Itemname einlesen
            // TODO: Prüfen, ob Item existiert
            // TODO: Anzahl einlesen
            // TODO: Item-Anzahl erhöhen
        }

        public static void ItemAnzahlVerringern(Dictionary<string, int> inventar)
        {
            // TODO: Itemname einlesen
            // TODO: Prüfen, ob Item existiert
            // TODO: Anzahl einlesen
            // TODO: Item-Anzahl verringern
            // TODO: Verhindern, dass die Anzahl unter 0 fällt
        }

        public static void ItemEntfernen(Dictionary<string, int> inventar)
        {
            // TODO: Itemname einlesen
            // TODO: Prüfen, ob Item existiert
            // TODO: Item entfernen
        }
    }
}
