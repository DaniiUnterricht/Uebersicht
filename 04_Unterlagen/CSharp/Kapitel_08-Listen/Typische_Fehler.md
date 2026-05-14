<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen – Typische Fehler

## Überblick

Beim Arbeiten mit Listen passieren oft ähnliche Fehler wie bei Arrays.

Viele Fehler hängen mit Index, Datentyp oder der Verwechslung von `.Length` und `.Count` zusammen.

---

## Fehler 1: `.Length` statt `.Count`

Falsch:

```csharp
List<int> zahlen = new List<int>() { 1, 2, 3 };

Console.WriteLine(zahlen.Length);
```

Richtig:

```csharp
Console.WriteLine(zahlen.Count);
```

👉 Listen verwenden `.Count`.

---

## Fehler 2: Index außerhalb der Liste

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

Console.WriteLine(namen[3]);
```

Diese Liste hat nur die Indizes:

```text
0
1
2
```

Der Index `3` existiert nicht.

---

## Fehler 3: Falscher Datentyp

```csharp
List<int> zahlen = new List<int>();

zahlen.Add("Hallo");
```

Das ist falsch, weil eine `List<int>` nur ganze Zahlen speichern kann.

Richtig wäre:

```csharp
zahlen.Add(5);
```

---

## Fehler 4: Liste verwenden, bevor sie erstellt wurde

Falsch:

```csharp
List<string> namen;

namen.Add("Max");
```

Richtig:

```csharp
List<string> namen = new List<string>();

namen.Add("Max");
```

👉 Eine Liste muss zuerst erstellt werden.

---

## Fehler 5: Entfernen in foreach-Schleife

Problematisch:

```csharp
foreach (int zahl in zahlen)
{
    if (zahl < 0)
    {
        zahlen.Remove(zahl);
    }
}
```

Während einer `foreach`-Schleife sollte die Liste nicht verändert werden.

Besser:

```csharp
for (int i = zahlen.Count - 1; i >= 0; i--)
{
    if (zahlen[i] < 0)
    {
        zahlen.RemoveAt(i);
    }
}
```

---

## Fehler 6: `Remove()` und `RemoveAt()` verwechseln

```csharp
List<int> zahlen = new List<int>() { 10, 20, 30 };
```

### `Remove()` entfernt einen Wert

```csharp
zahlen.Remove(20);
```

### `RemoveAt()` entfernt einen Index

```csharp
zahlen.RemoveAt(1);
```

In diesem Beispiel entfernen beide Varianten die Zahl `20`, aber sie bedeuten nicht dasselbe.

---

## Fehler 7: Leere Liste direkt auslesen

```csharp
List<int> zahlen = new List<int>();

Console.WriteLine(zahlen[0]);
```

Die Liste ist leer. Deshalb existiert der Index `0` nicht.

Besser:

```csharp
if (zahlen.Count > 0)
{
    Console.WriteLine(zahlen[0]);
}
else
{
    Console.WriteLine("Die Liste ist leer.");
}
```

---

## Zusammenfassung

Typische Fehler bei Listen:

- `.Length` statt `.Count`
- Index außerhalb der Liste
- falscher Datentyp
- Liste nicht erstellt
- Liste während `foreach` verändert
- `Remove()` und `RemoveAt()` verwechselt
- leere Liste direkt ausgelesen
