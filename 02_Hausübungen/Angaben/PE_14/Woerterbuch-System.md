# Wörterbuch-System mit Dictionary 📘

## 🎯 Lernziel

* `Dictionary<string, string>` verwenden
* Einträge hinzufügen
* Einträge suchen
* Einträge entfernen
* Dictionary als Parameter an Methoden übergeben
* Methoden sinnvoll strukturieren

---

## 📝 Angabe

Erstelle ein C#-Konsolenprogramm, das ein kleines Wörterbuch verwaltet.

Das Programm soll deutsche Begriffe und ihre englische Übersetzung speichern.

Verwende dafür ein Dictionary:

```csharp
Dictionary<string, string> woerterbuch = new Dictionary<string, string>();
```

Beim Start sollen bereits folgende Wörter vorhanden sein:

```text
Haus -> house
Baum -> tree
Auto -> car
Hund -> dog
```

Das Programm soll über ein Menü gesteuert werden.

Folgende Funktionen sollen möglich sein:

* Alle Wörter anzeigen
* Neues Wort hinzufügen
* Übersetzung zu einem Wort suchen
* Wort entfernen
* Programm beenden

---

## 🔧 Methodenbeschreibung

### `Menue`

Diese Methode soll das Menü anzeigen und die Auswahl des Benutzers einlesen.

Die Methode soll nur gültige Zahlen von `1` bis `5` akzeptieren.

Am Ende soll die Methode die ausgewählte Zahl zurückgeben.

---

### `WoerterAnzeigen`

Diese Methode soll alle Wörter und deren Übersetzungen ausgeben.

Falls noch keine Wörter vorhanden sind, soll eine passende Meldung ausgegeben werden.

---

### `WortHinzufuegen`

Diese Methode soll ein neues deutsches Wort und die englische Übersetzung einlesen.

Falls das Wort bereits existiert, soll es nicht erneut hinzugefügt werden.

---

### `WortSuchen`

Diese Methode soll ein deutsches Wort einlesen und prüfen, ob es im Wörterbuch existiert.

Falls ja, soll die englische Übersetzung ausgegeben werden.

Falls nein, soll eine Fehlermeldung ausgegeben werden.

---

### `WortEntfernen`

Diese Methode soll ein deutsches Wort einlesen und aus dem Wörterbuch entfernen.

Falls das Wort nicht existiert, soll eine passende Meldung ausgegeben werden.

---

## 💻 Erwartete Beispielausgabe

```text
Wörterbuch-System
=================

Menü
1 - Alle Wörter anzeigen
2 - Neues Wort hinzufügen
3 - Wort suchen
4 - Wort entfernen
5 - Programm beenden

Auswahl treffen: 1

Aktuelle Wörter:
Haus: house
Baum: tree
Auto: car
Hund: dog
```

---

## 💡 Hinweise

Zum Hinzufügen kannst du verwenden:

```csharp
woerterbuch.Add("Haus", "house");
```

Zum Prüfen, ob ein Wort existiert:

```csharp
woerterbuch.ContainsKey("Haus");
```

Zum Zugriff auf die Übersetzung:

```csharp
woerterbuch["Haus"];
```

Zum Entfernen:

```csharp
woerterbuch.Remove("Haus");
```

Zum Ausgeben aller Einträge kannst du eine `foreach`-Schleife verwenden:

```csharp
foreach (KeyValuePair<string, string> eintrag in woerterbuch)
{
    Console.WriteLine(eintrag.Key + ": " + eintrag.Value);
}
```

---

## 💻 Template

```csharp
/*
* Wörterbuch-System
* Das Programm verwaltet deutsche Wörter und deren englische Übersetzung.
*/

int Menue()
{
    // TODO: Menü anzeigen
    // TODO: Auswahl einlesen und prüfen
    return 0;
}

void WoerterAnzeigen(Dictionary<string, string> woerterbuch)
{
    // TODO: Alle Wörter mit Übersetzung anzeigen
}

void WortHinzufuegen(Dictionary<string, string> woerterbuch)
{
    // TODO: Deutsches Wort einlesen
    // TODO: Englische Übersetzung einlesen
    // TODO: Prüfen, ob Wort bereits existiert
    // TODO: Wort hinzufügen
}

void WortSuchen(Dictionary<string, string> woerterbuch)
{
    // TODO: Deutsches Wort einlesen
    // TODO: Prüfen, ob Wort existiert
    // TODO: Übersetzung ausgeben
}

void WortEntfernen(Dictionary<string, string> woerterbuch)
{
    // TODO: Deutsches Wort einlesen
    // TODO: Prüfen, ob Wort existiert
    // TODO: Wort entfernen
}

int auswahl;

Dictionary<string, string> woerterbuch = new Dictionary<string, string>()
{
    { "Haus", "house" },
    { "Baum", "tree" },
    { "Auto", "car" },
    { "Hund", "dog" }
};

do
{
    auswahl = Menue();

    switch (auswahl)
    {
        case 1:
            WoerterAnzeigen(woerterbuch);
            break;

        case 2:
            WortHinzufuegen(woerterbuch);
            break;

        case 3:
            WortSuchen(woerterbuch);
            break;

        case 4:
            WortEntfernen(woerterbuch);
            break;
    }

} while (auswahl != 5);
```

---

## ⭐ Zusatzaufgabe

Verhindere, dass ein Wort doppelt hinzugefügt wird.

Falls das Wort bereits existiert, soll folgende Meldung erscheinen:

```text
Dieses Wort existiert bereits.
```

Gib außerdem aus, wie viele Wörter aktuell gespeichert sind.
