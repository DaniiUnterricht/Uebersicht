<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Dictionaries – Grundlagen

## Grundaufbau

Ein Dictionary wird mit zwei Datentypen erstellt.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();
```

Das bedeutet:

```text
string → int
```

Also:

```text
Schlüssel ist ein string
Wert ist ein int
```

---

## Allgemeine Schreibweise

```csharp
Dictionary<TKey, TValue> name = new Dictionary<TKey, TValue>();
```

| Teil | Bedeutung |
|-----|----------|
| `TKey` | Datentyp des Schlüssels |
| `TValue` | Datentyp des Wertes |
| `name` | Name der Dictionary-Variable |

---

## Beispiel: Name und Punkte

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", 100);
punkte.Add("Anna", 80);
punkte.Add("Lena", 50);
```

Die Daten sehen gedanklich so aus:

```text
Max  → 100
Anna → 80
Lena → 50
```

---

## Wert auslesen

Ein Wert wird über den Schlüssel ausgelesen.

```csharp
Console.WriteLine(punkte["Max"]);
```

### Ausgabe

```text
100
```

---

## Unterschied zu einer Liste

Bei einer Liste verwendet man eine Position.

```csharp
namen[0]
```

Bei einem Dictionary verwendet man einen Schlüssel.

```csharp
punkte["Max"]
```

👉 Der Schlüssel ersetzt also den klassischen Index als Suchkriterium.

---

## Verschiedene Kombinationen

Ein Dictionary kann unterschiedliche Schlüssel- und Werttypen verwenden.

```csharp
Dictionary<string, int> alter = new Dictionary<string, int>();
Dictionary<string, double> preise = new Dictionary<string, double>();
Dictionary<int, string> produkte = new Dictionary<int, string>();
Dictionary<string, bool> bestanden = new Dictionary<string, bool>();
```

Beispiele:

```text
string → int       Name → Alter
string → double    Produkt → Preis
int → string       Artikelnummer → Produktname
string → bool      Schülername → bestanden
```

---

## Initialisierung mit Startwerten

Ein Dictionary kann auch direkt mit Werten erstellt werden.

```csharp
Dictionary<string, string> hauptstaedte = new Dictionary<string, string>()
{
    { "Österreich", "Wien" },
    { "Deutschland", "Berlin" },
    { "Italien", "Rom" }
};
```

---

## Wichtig: Schlüssel müssen eindeutig sein

In einem Dictionary darf derselbe Schlüssel nicht doppelt vorkommen.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", 100);
punkte.Add("Max", 200); // Fehler
```

👉 Der Schlüssel `"Max"` existiert bereits.

---

## Zusammenfassung

Ein Dictionary besteht aus:

- einem Schlüsseltyp
- einem Werttyp
- mehreren Schlüssel-Wert-Paaren
- einem eindeutigen Schlüssel pro Eintrag
