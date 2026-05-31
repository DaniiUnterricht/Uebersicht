# Übung 3 – Inventar-System mit Dictionary 🎮

**Hausübung 2**

---

## 🎯 Lernziel

* `Dictionary<string, int>` praktisch einsetzen
* Items und Mengen speichern
* Werte verändern
* Einträge suchen und löschen
* Ein Gaming-Inventar über ein Menü verwalten
* Methoden sauber strukturieren

---

## 📝 Angabe

Erstelle ein C#-Konsolenprogramm, das das Inventar eines Spielers verwaltet.

Der Name des Items soll als Schlüssel gespeichert werden.  
Die Anzahl des Items soll als Wert gespeichert werden.

Verwende dafür ein Dictionary:

```csharp
Dictionary<string, int> inventar = new Dictionary<string, int>();
```

Beim Start sollen bereits folgende Items vorhanden sein:

```text
Heiltrank: 3
Mana-Trank: 2
Gold: 150
Schlüssel: 1
```

Das Programm soll über ein Menü gesteuert werden.

Folgende Funktionen sollen möglich sein:

* Alle Items anzeigen
* Neues Item hinzufügen
* Anzahl eines Items erhöhen
* Anzahl eines Items verringern
* Item entfernen
* Programm beenden

---

## 🔧 Methodenbeschreibung

### `Menue`

Diese Methode soll das Menü anzeigen und die Auswahl des Benutzers einlesen.

Die Methode soll nur Zahlen von `1` bis `6` akzeptieren.

Am Ende soll die Methode die Auswahl zurückgeben.

---

### `InventarAnzeigen`

Diese Methode soll alle Items mit ihrer Anzahl ausgeben.

Falls das Inventar leer ist, soll eine passende Meldung ausgegeben werden.

---

### `ItemHinzufuegen`

Diese Methode soll ein neues Item und dessen Anzahl einlesen.

Falls das Item bereits existiert, soll es nicht erneut hinzugefügt werden.

Die Anzahl darf nicht negativ sein.

---

### `ItemAnzahlErhoehen`

Diese Methode soll den Namen eines Items einlesen.

Falls das Item existiert, soll anschließend eine Anzahl eingelesen und zur aktuellen Anzahl addiert werden.

Falls das Item nicht existiert, soll eine Fehlermeldung ausgegeben werden.

---

### `ItemAnzahlVerringern`

Diese Methode soll den Namen eines Items einlesen.

Falls das Item existiert, soll anschließend eine Anzahl eingelesen und von der aktuellen Anzahl abgezogen werden.

Die Anzahl darf dabei nicht unter `0` fallen.

---

### `ItemEntfernen`

Diese Methode soll ein Item aus dem Inventar entfernen.

Falls das Item nicht existiert, soll eine passende Meldung ausgegeben werden.

---

## 💻 Erwartete Beispielausgabe

```text
Inventar-System
===============

Menü
1 - Inventar anzeigen
2 - Item hinzufügen
3 - Item-Anzahl erhöhen
4 - Item-Anzahl verringern
5 - Item entfernen
6 - Programm beenden

Auswahl treffen: 1

Aktuelles Inventar:
Heiltrank: 3x
Mana-Trank: 2x
Gold: 150x
Schlüssel: 1x
```

---

## 💡 Hinweise

Achte darauf, dass ein Item nur bearbeitet werden kann, wenn es existiert.

Beispiel:

```csharp
if (inventar.ContainsKey(itemName))
{
    inventar[itemName] += anzahl;
}
```

Zum Hinzufügen eines Items:

```csharp
inventar.Add("Heiltrank", 3);
```

Zum Zugriff auf die Anzahl:

```csharp
inventar["Gold"];
```

Zum Verringern der Anzahl:

```csharp
inventar[itemName] -= anzahl;
```

Die Anzahl soll nicht kleiner als `0` werden.

Beispiel:

```csharp
if (inventar[itemName] - anzahl < 0)
{
    Console.WriteLine("Die Anzahl darf nicht unter 0 fallen.");
}
else
{
    inventar[itemName] -= anzahl;
}
```

Zum Entfernen eines Items:

```csharp
inventar.Remove(itemName);
```

Zum Ausgeben aller Items:

```csharp
foreach (KeyValuePair<string, int> eintrag in inventar)
{
    Console.WriteLine(eintrag.Key + ": " + eintrag.Value + "x");
}
```

Prüfe Zahlen-Eingaben mit `TryParse`:

```csharp
int zahl;
bool gueltig = int.TryParse(Console.ReadLine(), out zahl);
```

Falls ein Item nach dem Verringern `0` erreicht, darfst du entscheiden:

```text
Item bleibt mit Anzahl 0 im Inventar
```

oder

```text
Item wird automatisch entfernt
```

---

## 💻 Template

```csharp
/*
* Inventar-System
* Das Programm verwaltet Items und deren Anzahl.
*/

int Menue()
{
    // TODO: Menü anzeigen
    // TODO: Auswahl einlesen und prüfen
    return 0;
}

void InventarAnzeigen(Dictionary<string, int> inventar)
{
    // TODO: Alle Items mit Anzahl anzeigen
}

void ItemHinzufuegen(Dictionary<string, int> inventar)
{
    // TODO: Itemname einlesen
    // TODO: Anzahl einlesen
    // TODO: Prüfen, ob Item bereits existiert
    // TODO: Item hinzufügen
}

void ItemAnzahlErhoehen(Dictionary<string, int> inventar)
{
    // TODO: Itemname einlesen
    // TODO: Prüfen, ob Item existiert
    // TODO: Anzahl einlesen
    // TODO: Item-Anzahl erhöhen
}

void ItemAnzahlVerringern(Dictionary<string, int> inventar)
{
    // TODO: Itemname einlesen
    // TODO: Prüfen, ob Item existiert
    // TODO: Anzahl einlesen
    // TODO: Item-Anzahl verringern
    // TODO: Verhindern, dass die Anzahl unter 0 fällt
}

void ItemEntfernen(Dictionary<string, int> inventar)
{
    // TODO: Itemname einlesen
    // TODO: Prüfen, ob Item existiert
    // TODO: Item entfernen
}

int auswahl;

Dictionary<string, int> inventar = new Dictionary<string, int>()
{
    { "Heiltrank", 3 },
    { "Mana-Trank", 2 },
    { "Gold", 150 },
    { "Schlüssel", 1 }
};

do
{
    auswahl = Menue();

    switch (auswahl)
    {
        case 1:
            InventarAnzeigen(inventar);
            break;

        case 2:
            ItemHinzufuegen(inventar);
            break;

        case 3:
            ItemAnzahlErhoehen(inventar);
            break;

        case 4:
            ItemAnzahlVerringern(inventar);
            break;

        case 5:
            ItemEntfernen(inventar);
            break;
    }

} while (auswahl != 6);
```

---

## ⭐ Zusatzaufgabe

Gib zusätzlich aus, welches Item am häufigsten im Inventar vorkommt.

Beispiel:

```text
Häufigstes Item:
Gold mit 150x
```
