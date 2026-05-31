# Übung 2 – Lagerverwaltung mit Dictionary 📦

**Hausübung 1**

---

## 🎯 Lernziel

* `Dictionary<string, int>` verwenden
* Produktnamen und Lagerbestände speichern
* Werte erhöhen und verringern
* Einträge entfernen
* Benutzereingaben prüfen
* Methoden mit Dictionary-Parametern verwenden

---

## 📝 Angabe

Erstelle ein C#-Konsolenprogramm für eine kleine Lagerverwaltung.

Das Programm soll Produktnamen und deren Lagerbestand speichern.

Verwende dafür ein Dictionary:

```csharp
Dictionary<string, int> lager = new Dictionary<string, int>();
```

Beim Start sollen bereits folgende Produkte vorhanden sein:

```text
Monitor: 5 Stück
Tastatur: 12 Stück
Maus: 20 Stück
Headset: 7 Stück
```

Das Programm soll über ein Menü gesteuert werden.

Folgende Funktionen sollen möglich sein:

* Alle Produkte anzeigen
* Neues Produkt hinzufügen
* Bestand eines Produkts erhöhen
* Bestand eines Produkts verringern
* Produkt entfernen
* Programm beenden

---

## 🔧 Methodenbeschreibung

### `Menue`

Diese Methode soll das Menü anzeigen und die Auswahl des Benutzers einlesen.

Die Methode soll nur Zahlen von `1` bis `6` akzeptieren.

Am Ende soll die Methode die Auswahl zurückgeben.

---

### `ProdukteAnzeigen`

Diese Methode soll alle Produkte mit ihrem aktuellen Lagerbestand ausgeben.

Falls keine Produkte vorhanden sind, soll eine passende Meldung ausgegeben werden.

---

### `ProduktHinzufuegen`

Diese Methode soll einen neuen Produktnamen und einen Startbestand einlesen.

Falls das Produkt bereits existiert, soll es nicht erneut hinzugefügt werden.

Der Bestand darf nicht negativ sein.

---

### `BestandErhoehen`

Diese Methode soll den Namen eines Produkts einlesen.

Falls das Produkt existiert, soll anschließend eine Anzahl eingelesen und zum aktuellen Bestand addiert werden.

Falls das Produkt nicht existiert, soll eine Fehlermeldung ausgegeben werden.

---

### `BestandVerringern`

Diese Methode soll den Namen eines Produkts einlesen.

Falls das Produkt existiert, soll anschließend eine Anzahl eingelesen und vom aktuellen Bestand abgezogen werden.

Der Bestand darf dabei nicht unter `0` fallen.

---

### `ProduktEntfernen`

Diese Methode soll ein Produkt aus dem Dictionary entfernen.

Falls das Produkt nicht existiert, soll eine passende Meldung ausgegeben werden.

---

## 💻 Erwartete Beispielausgabe

```text
Lagerverwaltung
===============

Menü
1 - Produkte anzeigen
2 - Produkt hinzufügen
3 - Bestand erhöhen
4 - Bestand verringern
5 - Produkt entfernen
6 - Programm beenden

Auswahl treffen: 1

Aktueller Lagerbestand:
Monitor: 5 Stück
Tastatur: 12 Stück
Maus: 20 Stück
Headset: 7 Stück
```

---

## 💡 Hinweise

Achte darauf, dass ein Produkt nur bearbeitet werden kann, wenn es existiert.

Beispiel:

```csharp
if (lager.ContainsKey(produktname))
{
    lager[produktname] += anzahl;
}
```

Zum Hinzufügen eines Produkts:

```csharp
lager.Add("Monitor", 5);
```

Zum Verringern eines Bestands:

```csharp
lager[produktname] -= anzahl;
```

Achte darauf, dass der Bestand nicht kleiner als `0` wird.

Eine einfache Prüfung könnte so aussehen:

```csharp
if (lager[produktname] - anzahl < 0)
{
    Console.WriteLine("Der Bestand darf nicht unter 0 fallen.");
}
else
{
    lager[produktname] -= anzahl;
}
```

Zum Entfernen:

```csharp
lager.Remove(produktname);
```

Zum Ausgeben aller Produkte:

```csharp
foreach (KeyValuePair<string, int> eintrag in lager)
{
    Console.WriteLine(eintrag.Key + ": " + eintrag.Value + " Stück");
}
```

Prüfe Zahlen-Eingaben mit `TryParse`:

```csharp
int zahl;
bool gueltig = int.TryParse(Console.ReadLine(), out zahl);
```

---

## 💻 Template

```csharp
/*
* Lagerverwaltung
* Das Programm verwaltet Produkte und deren Lagerbestand.
*/

int Menue()
{
    // TODO: Menü anzeigen
    // TODO: Auswahl einlesen und prüfen
    return 0;
}

void ProdukteAnzeigen(Dictionary<string, int> lager)
{
    // TODO: Alle Produkte mit Bestand anzeigen
}

void ProduktHinzufuegen(Dictionary<string, int> lager)
{
    // TODO: Produktname einlesen
    // TODO: Startbestand einlesen
    // TODO: Prüfen, ob Produkt bereits existiert
    // TODO: Produkt hinzufügen
}

void BestandErhoehen(Dictionary<string, int> lager)
{
    // TODO: Produktname einlesen
    // TODO: Prüfen, ob Produkt existiert
    // TODO: Anzahl einlesen
    // TODO: Bestand erhöhen
}

void BestandVerringern(Dictionary<string, int> lager)
{
    // TODO: Produktname einlesen
    // TODO: Prüfen, ob Produkt existiert
    // TODO: Anzahl einlesen
    // TODO: Bestand verringern
    // TODO: Verhindern, dass Bestand unter 0 fällt
}

void ProduktEntfernen(Dictionary<string, int> lager)
{
    // TODO: Produktname einlesen
    // TODO: Prüfen, ob Produkt existiert
    // TODO: Produkt entfernen
}

int auswahl;

Dictionary<string, int> lager = new Dictionary<string, int>()
{
    { "Monitor", 5 },
    { "Tastatur", 12 },
    { "Maus", 20 },
    { "Headset", 7 }
};

do
{
    auswahl = Menue();

    switch (auswahl)
    {
        case 1:
            ProdukteAnzeigen(lager);
            break;

        case 2:
            ProduktHinzufuegen(lager);
            break;

        case 3:
            BestandErhoehen(lager);
            break;

        case 4:
            BestandVerringern(lager);
            break;

        case 5:
            ProduktEntfernen(lager);
            break;
    }

} while (auswahl != 6);
```

---

## ⭐ Zusatzaufgabe

Gib zusätzlich aus, welches Produkt den höchsten Lagerbestand hat.

Beispiel:

```text
Produkt mit höchstem Bestand:
Maus mit 20 Stück
```
