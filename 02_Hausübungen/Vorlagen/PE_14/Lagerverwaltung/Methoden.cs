using System;
using System.Collections.Generic;
using System.Text;

namespace Lagerverwaltung
{
    class Methoden
    {
        public static int Menue()
        {
            // TODO: Menü anzeigen
            // TODO: Auswahl einlesen und prüfen
            return 0;
        }

        public static void ProdukteAnzeigen(Dictionary<string, int> lager)
        {
            // TODO: Alle Produkte mit Bestand anzeigen
        }

        public static void ProduktHinzufuegen(Dictionary<string, int> lager)
        {
            // TODO: Produktname einlesen
            // TODO: Startbestand einlesen
            // TODO: Prüfen, ob Produkt bereits existiert
            // TODO: Produkt hinzufügen
        }

        public static void BestandErhoehen(Dictionary<string, int> lager)
        {
            // TODO: Produktname einlesen
            // TODO: Prüfen, ob Produkt existiert
            // TODO: Anzahl einlesen
            // TODO: Bestand erhöhen
        }

        public static void BestandVerringern(Dictionary<string, int> lager)
        {
            // TODO: Produktname einlesen
            // TODO: Prüfen, ob Produkt existiert
            // TODO: Anzahl einlesen
            // TODO: Bestand verringern
            // TODO: Verhindern, dass Bestand unter 0 fällt
        }

        public static void ProduktEntfernen(Dictionary<string, int> lager)
        {
            // TODO: Produktname einlesen
            // TODO: Prüfen, ob Produkt existiert
            // TODO: Produkt entfernen
        }
    }
}
