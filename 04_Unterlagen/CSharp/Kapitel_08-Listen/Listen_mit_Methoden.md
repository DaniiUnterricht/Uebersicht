<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen mit Methoden verwenden

## Einführung

Listen werden oft gemeinsam mit Methoden verwendet.

Dadurch bleibt der Code übersichtlich und einzelne Aufgaben können klar getrennt werden.

---

## Liste an Methode übergeben

Eine Liste kann als Parameter an eine Methode übergeben werden.

```csharp
static void NamenAusgeben(List<string> namen)
{
    foreach (string name in namen)
    {
        Console.WriteLine(name);
    }
}
```

Aufruf:

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

NamenAusgeben(namen);
```

---

## Methode zum Hinzufügen

```csharp
static void NameHinzufuegen(List<string> namen, string neuerName)
{
    namen.Add(neuerName);
}
```

Aufruf:

```csharp
List<string> namen = new List<string>();

NameHinzufuegen(namen, "Max");
NameHinzufuegen(namen, "Anna");
```

---

## Methode mit Rückgabewert

Eine Methode kann mit einer Liste arbeiten und ein Ergebnis zurückgeben.

```csharp
static int SummeBerechnen(List<int> zahlen)
{
    int summe = 0;

    foreach (int zahl in zahlen)
    {
        summe += zahl;
    }

    return summe;
}
```

Aufruf:

```csharp
List<int> zahlen = new List<int>() { 5, 8, 3 };

int ergebnis = SummeBerechnen(zahlen);

Console.WriteLine(ergebnis);
```

---

## Methode gibt eine Liste zurück

Eine Methode kann auch eine ganze Liste zurückgeben.

```csharp
static List<int> ZahlenErstellen()
{
    List<int> zahlen = new List<int>();

    zahlen.Add(10);
    zahlen.Add(20);
    zahlen.Add(30);

    return zahlen;
}
```

Aufruf:

```csharp
List<int> meineZahlen = ZahlenErstellen();
```

---

## Beispiel: Noten anzeigen

```csharp
static void NotenAnzeigen(List<int> noten)
{
    for (int i = 0; i < noten.Count; i++)
    {
        Console.WriteLine("Note " + (i + 1) + ": " + noten[i]);
    }
}
```

---

## Warum Listen und Methoden kombinieren?

Vorteile:

- Code wird übersichtlicher
- einzelne Aufgaben sind klar getrennt
- Methoden können wiederverwendet werden
- die `Main()` bleibt kürzer
- Vorbereitung auf größere Projekte

---

## Wichtiger Hinweis

Wenn eine Liste an eine Methode übergeben wird, kann die Methode die Liste verändern.

```csharp
static void ZahlHinzufuegen(List<int> zahlen)
{
    zahlen.Add(100);
}
```

Aufruf:

```csharp
List<int> zahlen = new List<int>();

ZahlHinzufuegen(zahlen);

Console.WriteLine(zahlen.Count);
```

### Ausgabe

```text
1
```

👉 Die ursprüngliche Liste wurde verändert.

---

## Zusammenfassung

Listen können:

- als Parameter übergeben werden
- in Methoden verändert werden
- für Berechnungen verwendet werden
- als Rückgabewert zurückgegeben werden

Listen und Methoden zusammen sind eine wichtige Grundlage für größere Programme.
