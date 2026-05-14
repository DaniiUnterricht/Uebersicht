<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen vs Dictionaries

## Überblick

Listen und Dictionaries speichern beide mehrere Werte.

Der wichtigste Unterschied ist der Zugriff.

```text
List       → Zugriff über Index
Dictionary → Zugriff über Schlüssel
```

---

## Liste

Eine Liste speichert Werte in einer Reihenfolge.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

Console.WriteLine(namen[0]);
```

### Ausgabe

```text
Max
```

Der Zugriff erfolgt über die Position.

```text
0 → Max
1 → Anna
2 → Lena
```

---

## Dictionary

Ein Dictionary speichert Werte mit einem Schlüssel.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", 100);
punkte.Add("Anna", 80);
punkte.Add("Lena", 50);

Console.WriteLine(punkte["Max"]);
```

### Ausgabe

```text
100
```

Der Zugriff erfolgt über den Schlüssel.

```text
Max  → 100
Anna → 80
Lena → 50
```

---

## Vergleich

| Frage | List | Dictionary |
|------|------|------------|
| Wie wird zugegriffen? | über Index | über Schlüssel |
| Gibt es eine feste Reihenfolge? | ja, wichtig | meistens nicht der Hauptfokus |
| Können Werte doppelt vorkommen? | ja | Werte ja, Schlüssel nein |
| Typisches Beispiel | Namenliste | Name → Punkte |
| Eigenschaft | einfache Sammlung | Zuordnung von Daten |

---

## Wann nimmt man eine Liste?

Eine Liste ist gut, wenn:

- man einfach mehrere Werte speichern möchte
- die Reihenfolge wichtig ist
- man alle Werte nacheinander durchgehen möchte
- man keinen eigenen Schlüssel braucht

Beispiele:

```text
Namen
Noten
Zahlen
Aufgaben
Produkte im Warenkorb
```

---

## Wann nimmt man ein Dictionary?

Ein Dictionary ist gut, wenn:

- jeder Wert zu einem bestimmten Schlüssel gehört
- man schnell über einen Namen, Code oder eine ID suchen möchte
- man eine Zuordnung darstellen möchte

Beispiele:

```text
Name → Punkte
Land → Hauptstadt
Artikelnummer → Produkt
Username → Passwort
Fach → Note
```

---

## Brücke zur OOP

Ein Dictionary kann sich manchmal so anfühlen, als würde man ein kleines Objekt beschreiben.

```csharp
Dictionary<string, string> person = new Dictionary<string, string>();

person["Name"] = "Max";
person["Alter"] = "17";
person["Beruf"] = "Schüler";
```

Das beschreibt eine Person über Eigenschaften.

Aber:

👉 Eine Klasse ist dafür später sauberer, weil sie feste Eigenschaften, Datentypen und Methoden haben kann.

```csharp
class Person
{
    public string Name { get; set; }
    public int Alter { get; set; }
}
```

---

## Merksatz

Eine Liste ist gut für:

```text
mehrere Dinge nacheinander
```

Ein Dictionary ist gut für:

```text
eine Zuordnung von Schlüssel zu Wert
```

---

## Zusammenfassung

Listen und Dictionaries sind beide wichtige Collections.

- Listen verwenden einen Index
- Dictionaries verwenden einen Schlüssel
- Listen sind gut für einfache Reihenfolgen
- Dictionaries sind gut für Zuordnungen
- Dictionaries bereiten gut auf objektorientiertes Denken vor
