<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Dictionaries – Übersicht

## Einordnung

Nach **Listen** sind **Dictionaries** der nächste sinnvolle Schritt.

Eine Liste speichert Werte über einen **Index**.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

Console.WriteLine(namen[0]);
```

Ein Dictionary speichert Werte dagegen über einen **Schlüssel**.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", 100);
punkte.Add("Anna", 80);

Console.WriteLine(punkte["Max"]);
```

👉 Man kann sich ein Dictionary wie eine kleine Tabelle aus **Schlüssel → Wert** vorstellen.

---

## Grundidee

Ein Dictionary speichert immer Paare.

```text
Schlüssel → Wert
```

Beispiele:

```text
Name → Punktestand
Land → Hauptstadt
Artikelnummer → Produktname
Username → Passwort
Produkt → Preis
```

---

## Warum braucht man Dictionaries?

Dictionaries sind sinnvoll, wenn man Daten nicht über eine Position, sondern über einen Namen oder Schlüssel finden möchte.

Beispiel mit Liste:

```csharp
List<int> punkte = new List<int>() { 100, 80, 50 };
```

Hier weiß man nicht direkt, zu welchem Spieler die Punkte gehören.

Beispiel mit Dictionary:

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", 100);
punkte.Add("Anna", 80);
punkte.Add("Lena", 50);
```

Hier ist klar:

```text
Max  → 100
Anna → 80
Lena → 50
```

---

## Vergleich zu Listen

| Struktur | Zugriff über | Beispiel |
|---------|--------------|----------|
| Array | Index | `namen[0]` |
| List | Index | `namen[0]` |
| Dictionary | Schlüssel | `punkte["Max"]` |

---

## Beispiele aus der Praxis

Dictionaries eignen sich zum Beispiel für:

- Spielername → Punkte
- Produktname → Preis
- Land → Hauptstadt
- Benutzername → Passwort
- Artikelnummer → Lagerbestand
- Fach → Note

---

## Wichtige Begriffe

| Begriff | Bedeutung |
|--------|----------|
| `Dictionary<TKey, TValue>` | allgemeine Schreibweise eines Dictionaries |
| `TKey` | Datentyp des Schlüssels |
| `TValue` | Datentyp des Wertes |
| Key | Schlüssel, über den man einen Wert findet |
| Value | gespeicherter Wert |
| `Add()` | fügt ein neues Paar hinzu |
| `ContainsKey()` | prüft, ob ein Schlüssel existiert |

---

## Merksatz

Eine Liste fragt:

```text
Was steht an Position 0?
```

Ein Dictionary fragt:

```text
Welcher Wert gehört zu diesem Schlüssel?
```

---

## Zusammenfassung

Dictionaries:

- speichern Schlüssel-Wert-Paare
- verwenden keinen normalen Index als Hauptzugriff
- eignen sich, wenn Daten über Namen, Codes oder IDs gefunden werden sollen
- sind eine gute Brücke zu objektorientiertem Denken
