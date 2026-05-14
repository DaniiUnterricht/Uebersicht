<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen – Wichtige Befehle

## Überblick

Listen besitzen viele fertige Befehle, mit denen man Elemente hinzufügen, entfernen, suchen oder zählen kann.

Die wichtigsten Befehle reichen für den Einstieg völlig aus.

---

## `Add()` – Element hinzufügen

Mit `Add()` wird ein Element am Ende der Liste eingefügt.

```csharp
List<string> namen = new List<string>();

namen.Add("Max");
namen.Add("Anna");
```

---

## `Insert()` – Element an bestimmter Stelle einfügen

Mit `Insert()` kann ein Element an einer bestimmten Position eingefügt werden.

```csharp
List<string> namen = new List<string>() { "Max", "Lena" };

namen.Insert(1, "Anna");
```

Die Liste enthält danach:

```text
Max
Anna
Lena
```

---

## `Remove()` – bestimmtes Element entfernen

Mit `Remove()` wird ein bestimmter Wert entfernt.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

namen.Remove("Anna");
```

Die Liste enthält danach:

```text
Max
Lena
```

Wichtig:

👉 Wenn der Wert mehrfach vorkommt, wird nur das erste passende Element entfernt.

---

## `RemoveAt()` – Element über Index entfernen

Mit `RemoveAt()` wird ein Element an einer bestimmten Position entfernt.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

namen.RemoveAt(1);
```

Die Liste enthält danach:

```text
Max
Lena
```

---

## `Contains()` – prüfen, ob ein Wert vorhanden ist

Mit `Contains()` kann überprüft werden, ob ein Wert in der Liste vorkommt.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

if (namen.Contains("Anna"))
{
    Console.WriteLine("Anna ist in der Liste.");
}
```

---

## `IndexOf()` – Position eines Wertes finden

Mit `IndexOf()` kann der Index eines bestimmten Wertes gefunden werden.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

int index = namen.IndexOf("Lena");

Console.WriteLine(index);
```

### Ausgabe

```text
2
```

Wenn der Wert nicht gefunden wird, liefert `IndexOf()` den Wert `-1` zurück.

---

## `Clear()` – Liste leeren

Mit `Clear()` werden alle Elemente aus der Liste entfernt.

```csharp
List<int> zahlen = new List<int>() { 1, 2, 3, 4 };

zahlen.Clear();

Console.WriteLine(zahlen.Count);
```

### Ausgabe

```text
0
```

---

## `Count` – Anzahl der Elemente

`Count` zeigt an, wie viele Elemente aktuell in der Liste gespeichert sind.

```csharp
List<int> zahlen = new List<int>() { 4, 8, 12 };

Console.WriteLine(zahlen.Count);
```

---

## Übersicht der wichtigsten Befehle

| Befehl | Bedeutung |
|-------|----------|
| `Add(wert)` | fügt einen Wert am Ende hinzu |
| `Insert(index, wert)` | fügt einen Wert an einer bestimmten Stelle ein |
| `Remove(wert)` | entfernt einen bestimmten Wert |
| `RemoveAt(index)` | entfernt einen Wert an einem bestimmten Index |
| `Contains(wert)` | prüft, ob ein Wert vorhanden ist |
| `IndexOf(wert)` | liefert den Index eines Wertes |
| `Clear()` | entfernt alle Elemente |
| `Count` | Anzahl der Elemente |

---

## Zusammenfassung

Die wichtigsten Listenbefehle sind:

- `Add()` zum Hinzufügen
- `Remove()` und `RemoveAt()` zum Entfernen
- `Contains()` zum Suchen
- `Count` zum Zählen
- `Clear()` zum Leeren der Liste
