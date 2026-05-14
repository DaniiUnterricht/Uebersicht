<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen durchlaufen

## Einführung

Wie Arrays können auch Listen mit Schleifen durchlaufen werden.

Das ist wichtig, wenn man alle Elemente anzeigen, berechnen oder überprüfen möchte.

---

## Liste mit for-Schleife durchlaufen

Eine Liste kann mit einer normalen `for`-Schleife durchlaufen werden.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

for (int i = 0; i < namen.Count; i++)
{
    Console.WriteLine(namen[i]);
}
```

### Ausgabe

```text
Max
Anna
Lena
```

---

## Warum `Count`?

Bei einer Liste verwendet man:

```csharp
namen.Count
```

Bei einem Array verwendet man:

```csharp
namen.Length
```

👉 Listen haben `.Count`, Arrays haben `.Length`.

---

## Liste mit foreach-Schleife durchlaufen

Eine Liste kann auch mit `foreach` durchlaufen werden.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

foreach (string name in namen)
{
    Console.WriteLine(name);
}
```

---

## for oder foreach?

| Schleife | Sinnvoll, wenn ... |
|---------|--------------------|
| `for` | man den Index benötigt |
| `foreach` | man nur alle Werte ausgeben oder lesen möchte |

---

## Beispiel: Summe berechnen

```csharp
List<int> zahlen = new List<int>() { 4, 8, 3, 10 };

int summe = 0;

foreach (int zahl in zahlen)
{
    summe += zahl;
}

Console.WriteLine("Summe: " + summe);
```

### Ausgabe

```text
Summe: 25
```

---

## Beispiel: Größte Zahl finden

```csharp
List<int> zahlen = new List<int>() { 4, 8, 3, 10 };

int groessteZahl = zahlen[0];

for (int i = 1; i < zahlen.Count; i++)
{
    if (zahlen[i] > groessteZahl)
    {
        groessteZahl = zahlen[i];
    }
}

Console.WriteLine("Größte Zahl: " + groessteZahl);
```

### Ausgabe

```text
Größte Zahl: 10
```

---

## Elemente während einer Schleife entfernen

Beim Durchlaufen einer Liste muss man vorsichtig sein, wenn Elemente entfernt werden.

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

👉 Während einer `foreach`-Schleife sollte die Liste nicht verändert werden.

---

## Besser: Rückwärts mit for entfernen

```csharp
List<int> zahlen = new List<int>() { 5, -2, 8, -1, 3 };

for (int i = zahlen.Count - 1; i >= 0; i--)
{
    if (zahlen[i] < 0)
    {
        zahlen.RemoveAt(i);
    }
}
```

Warum rückwärts?

👉 Wenn ein Element entfernt wird, verschieben sich die nachfolgenden Elemente.  
👉 Rückwärts bleibt der restliche Indexbereich sicherer.

---

## Zusammenfassung

Listen können mit `for` und `foreach` durchlaufen werden.

- `for` ist gut, wenn man den Index braucht
- `foreach` ist gut, wenn man nur Werte lesen möchte
- beim Entfernen während einer Schleife muss man vorsichtig sein
- für das Entfernen mehrerer Elemente eignet sich oft eine rückwärts laufende `for`-Schleife
