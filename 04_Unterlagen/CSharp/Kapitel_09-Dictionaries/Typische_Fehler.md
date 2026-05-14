<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Dictionaries – Typische Fehler

## Überblick

Bei Dictionaries passieren am Anfang oft ähnliche Fehler.

Viele davon entstehen, weil ein Dictionary anders funktioniert als eine Liste.

---

## Fehler 1: Zugriff auf nicht vorhandenen Schlüssel

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

Console.WriteLine(punkte["Max"]); // Fehler
```

Der Schlüssel `"Max"` existiert noch nicht.

Besser:

```csharp
if (punkte.ContainsKey("Max"))
{
    Console.WriteLine(punkte["Max"]);
}
else
{
    Console.WriteLine("Max wurde nicht gefunden.");
}
```

---

## Fehler 2: Doppelten Schlüssel mit `Add()` hinzufügen

```csharp
punkte.Add("Max", 100);
punkte.Add("Max", 200); // Fehler
```

Ein Schlüssel darf nur einmal vorkommen.

Besser, wenn der Wert geändert werden soll:

```csharp
punkte["Max"] = 200;
```

---

## Fehler 3: `Length` statt `Count`

Arrays verwenden `Length`.

```csharp
int[] zahlen = new int[3];
Console.WriteLine(zahlen.Length);
```

Dictionaries verwenden `Count`.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();
Console.WriteLine(punkte.Count);
```

---

## Fehler 4: Dictionary wie eine Liste behandeln

```csharp
Console.WriteLine(punkte[0]); // meistens falsch
```

Ein Dictionary wird normalerweise nicht über `0`, `1`, `2` angesprochen.

Richtig ist der Zugriff über den Schlüssel.

```csharp
Console.WriteLine(punkte["Max"]);
```

---

## Fehler 5: Schlüssel und Wert verwechseln

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();
```

Das bedeutet:

```text
string → int
```

Also:

```text
Schlüssel: string
Wert: int
```

Richtig:

```csharp
punkte.Add("Max", 100);
```

Falsch:

```csharp
punkte.Add(100, "Max");
```

---

## Fehler 6: Falscher Datentyp

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", "100"); // Fehler
```

Der Wert muss ein `int` sein, kein `string`.

Richtig:

```csharp
punkte.Add("Max", 100);
```

---

## Fehler 7: Beim Durchlaufen nur an Werte denken

Ein Dictionary-Eintrag besteht immer aus `Key` und `Value`.

```csharp
foreach (var eintrag in punkte)
{
    Console.WriteLine(eintrag.Key);
    Console.WriteLine(eintrag.Value);
}
```

Man muss also wissen, ob man den Schlüssel, den Wert oder beides braucht.

---

## Zusammenfassung

Typische Fehler sind:

- Zugriff auf einen nicht vorhandenen Schlüssel
- doppelter Schlüssel mit `Add()`
- `Length` statt `Count`
- Dictionary wie eine Liste verwenden
- Schlüssel und Wert vertauschen
- falsche Datentypen verwenden
- beim Durchlaufen `Key` und `Value` verwechseln
