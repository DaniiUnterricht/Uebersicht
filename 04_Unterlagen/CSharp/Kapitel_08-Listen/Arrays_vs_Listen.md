<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Arrays vs Listen

## Einführung

Arrays und Listen speichern beide mehrere Werte.

Trotzdem gibt es wichtige Unterschiede.

---

## Gemeinsamkeiten

Arrays und Listen:

- speichern mehrere Werte
- haben einen festen Datentyp
- beginnen beim Index 0
- können mit Schleifen durchlaufen werden
- eignen sich für ähnliche Daten

---

## Unterschied: Größe

### Array

Ein Array hat eine feste Größe.

```csharp
int[] zahlen = new int[3];
```

Dieses Array hat genau 3 Plätze.

---

### Liste

Eine Liste kann wachsen.

```csharp
List<int> zahlen = new List<int>();

zahlen.Add(10);
zahlen.Add(20);
zahlen.Add(30);
zahlen.Add(40);
```

Die Liste passt sich an die Anzahl der Elemente an.

---

## Unterschied: Anzahl ermitteln

### Array

```csharp
zahlen.Length
```

### Liste

```csharp
zahlen.Count
```

---

## Unterschied: Werte hinzufügen

### Array

Bei einem Array kann man nicht einfach mit einem Befehl einen neuen Platz hinzufügen.

```csharp
int[] zahlen = new int[3];
```

Die Größe bleibt 3.

---

### Liste

Bei einer Liste geht das mit `Add()`.

```csharp
List<int> zahlen = new List<int>();

zahlen.Add(5);
zahlen.Add(8);
```

---

## Unterschied: Werte entfernen

Bei Listen können Werte einfach entfernt werden.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

namen.Remove("Anna");
```

Bei Arrays ist das nicht so einfach, weil die Größe fest ist.

---

## Übersicht

| Thema | Array | Liste |
|------|------|-------|
| Größe | fest | dynamisch |
| Anzahl | `.Length` | `.Count` |
| Hinzufügen | nicht direkt | `Add()` |
| Entfernen | umständlich | `Remove()` / `RemoveAt()` |
| Zugriff über Index | ja | ja |
| Datentyp festgelegt | ja | ja |

---

## Wann Array?

Ein Array ist sinnvoll, wenn:

- die Anzahl der Werte fix ist
- man eine einfache Datenstruktur braucht
- man mit Tabellen oder festen Feldern arbeitet
- die Größe während des Programms nicht verändert wird

---

## Wann Liste?

Eine Liste ist sinnvoll, wenn:

- die Anzahl der Werte vorher nicht bekannt ist
- der Benutzer beliebig viele Werte eingeben kann
- Elemente hinzugefügt oder entfernt werden sollen
- ein Menüprogramm Daten verwaltet

---

## Merksatz

👉 Array = feste Anzahl  
👉 Liste = flexible Anzahl

---

## Zusammenfassung

Arrays und Listen sind sich ähnlich, aber Listen sind im Alltag oft praktischer.

Nach Arrays sind Listen ein logischer nächster Schritt, weil sie dieselbe Grundidee verwenden, aber flexibler sind.
