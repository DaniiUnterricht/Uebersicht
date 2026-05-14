<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen – Übersicht

## Einordnung

Nach Arrays sind **Listen** der nächste sinnvolle Schritt.

Arrays speichern mehrere Werte, haben aber eine **feste Größe**. Eine Liste kann dagegen während des Programms **wachsen oder kleiner werden**.

👉 Eine Liste ist also besonders praktisch, wenn man vorher nicht genau weiß, wie viele Werte gespeichert werden sollen.

---

## Grundidee

Eine **List** ist eine Sammlung von mehreren Elementen desselben Datentyps.

Beispiel:

```csharp
List<string> namen = new List<string>();

namen.Add("Max");
namen.Add("Anna");
namen.Add("Lena");
```

Die Liste `namen` enthält nun drei Strings.

---

## Vergleich zu Arrays

### Array

```csharp
string[] namen = new string[3];

namen[0] = "Max";
namen[1] = "Anna";
namen[2] = "Lena";
```

Ein Array hat eine feste Größe.

---

### Liste

```csharp
List<string> namen = new List<string>();

namen.Add("Max");
namen.Add("Anna");
namen.Add("Lena");
```

Eine Liste kann dynamisch erweitert werden.

---

## Warum Listen?

Listen sind sinnvoll, wenn:

- die Anzahl der Werte vorher nicht bekannt ist
- Werte später hinzugefügt werden sollen
- Werte wieder entfernt werden sollen
- man flexibel mit Daten arbeiten möchte
- ein Menüprogramm Daten sammeln soll

---

## Beispiele aus der Praxis

Listen eignen sich zum Beispiel für:

- Namen von Spielern
- Noten einer Klasse
- Produkte in einem Warenkorb
- Aufgaben in einer To-do-Liste
- Highscores in einem Spiel
- eingegebene Zahlen in einem Konsolenprogramm

---

## Wichtige Begriffe

| Begriff | Bedeutung |
|--------|----------|
| `List<T>` | allgemeine Schreibweise einer Liste |
| `T` | Platzhalter für den Datentyp |
| `Add()` | fügt ein Element hinzu |
| `Remove()` | entfernt ein Element |
| `Count` | Anzahl der Elemente |
| Index | Position eines Elements |

---

## Was bedeutet `List<T>`?

Das `T` steht für den Datentyp der Elemente.

Beispiele:

```csharp
List<int> zahlen = new List<int>();
List<string> namen = new List<string>();
List<double> preise = new List<double>();
List<bool> antworten = new List<bool>();
```

👉 Eine Liste enthält immer Elemente eines bestimmten Datentyps.

---

## Merksatz

Ein Array ist wie ein Regal mit fixer Anzahl an Fächern.

Eine Liste ist wie ein Regal, bei dem man später weitere Fächer hinzufügen oder entfernen kann.

---

## Zusammenfassung

Listen:

- speichern mehrere Werte desselben Datentyps
- sind flexibler als Arrays
- können wachsen und kleiner werden
- besitzen wie Arrays einen Index
- werden in C# sehr häufig verwendet
