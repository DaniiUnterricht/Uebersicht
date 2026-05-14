<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Dictionaries – Durchlaufen

## Überblick

Ein Dictionary kann mit einer Schleife durchlaufen werden.

Dabei bekommt man nicht nur einen einzelnen Wert, sondern immer ein Paar aus:

```text
Key + Value
```

---

## Durchlaufen mit `foreach`

Am häufigsten verwendet man bei Dictionaries eine `foreach`-Schleife.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>()
{
    { "Max", 100 },
    { "Anna", 80 },
    { "Lena", 50 }
};

foreach (KeyValuePair<string, int> eintrag in punkte)
{
    Console.WriteLine(eintrag.Key + ": " + eintrag.Value);
}
```

### Ausgabe

```text
Max: 100
Anna: 80
Lena: 50
```

---

## Was ist `KeyValuePair`?

Ein Eintrag in einem Dictionary besteht immer aus zwei Teilen.

```text
Key   → Schlüssel
Value → Wert
```

Darum ist ein einzelner Eintrag ein `KeyValuePair`.

```csharp
KeyValuePair<string, int> eintrag
```

Das bedeutet:

```text
Der Schlüssel ist ein string.
Der Wert ist ein int.
```

---

## Einfacher mit `var`

Man kann die Schreibweise auch kürzer machen.

```csharp
foreach (var eintrag in punkte)
{
    Console.WriteLine(eintrag.Key + ": " + eintrag.Value);
}
```

`var` bedeutet hier:

👉 C# erkennt den Datentyp automatisch.

Für Anfänger ist es aber oft hilfreich, zuerst die lange Schreibweise zu sehen.

---

## Nur Schlüssel durchlaufen

Man kann auch nur die Schlüssel durchlaufen.

```csharp
foreach (string name in punkte.Keys)
{
    Console.WriteLine(name);
}
```

### Ausgabe

```text
Max
Anna
Lena
```

---

## Nur Werte durchlaufen

Man kann auch nur die Werte durchlaufen.

```csharp
foreach (int punktestand in punkte.Values)
{
    Console.WriteLine(punktestand);
}
```

### Ausgabe

```text
100
80
50
```

---

## Wann verwendet man welche Variante?

| Variante | Verwendung |
|---------|------------|
| `foreach (var eintrag in dictionary)` | wenn man Schlüssel und Wert braucht |
| `foreach (var key in dictionary.Keys)` | wenn man nur die Schlüssel braucht |
| `foreach (var value in dictionary.Values)` | wenn man nur die Werte braucht |

---

## Zusammenfassung

Dictionaries werden meistens mit `foreach` durchlaufen.

Wichtig ist:

- ein Eintrag besteht aus `Key` und `Value`
- mit `.Key` bekommt man den Schlüssel
- mit `.Value` bekommt man den Wert
- mit `.Keys` bekommt man nur die Schlüssel
- mit `.Values` bekommt man nur die Werte
