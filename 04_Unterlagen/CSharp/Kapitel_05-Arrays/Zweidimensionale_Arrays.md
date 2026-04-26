[C# Startseite](../CSharp.md)

# Zweidimensionale Arrays (2D Arrays)

## Definition
Ein zweidimensionales Array ist ein Array mit **Zeilen und Spalten**.

Man kann es sich wie eine **Tabelle** oder ein **Raster** vorstellen.

---

## Darstellung

|   | Spalte 0 | Spalte 1 | Spalte 2 |
|---|----------|----------|----------|
| Zeile 0 | 1 | 2 | 3 |
| Zeile 1 | 4 | 5 | 6 |

---

## Grundstruktur

```csharp
Datentyp[,] name = new Datentyp[Zeilen, Spalten];
```

---

## Beispiel: Array erstellen

```csharp
int[,] matrix = new int[2, 3];
```

→ 2 Zeilen, 3 Spalten

---

## Beispiel: Direkt befüllen

```csharp
int[,] matrix =
{
    { 1, 2, 3 },
    { 4, 5, 6 }
};
```

---

## Zugriff auf Elemente

```csharp
Console.WriteLine(matrix[0, 1]); // Ausgabe: 2
```

---

## Erklärung der Indizes

| Zugriff | Bedeutung |
|--------|----------|
| `matrix[0,0]` | Zeile 0, Spalte 0 |
| `matrix[0,1]` | Zeile 0, Spalte 1 |
| `matrix[1,2]` | Zeile 1, Spalte 2 |

---

## Durchlaufen mit For-Schleifen

```csharp
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.WriteLine(matrix[i, j]);
    }
}
```

---

## Ausgabe als Tabelle

```csharp
for (int i = 0; i < 2; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
```

### Ausgabe

```text
1 2 3
4 5 6
```

---

## Durchlaufen mit Foreach

```csharp
foreach (int zahl in matrix)
{
    Console.WriteLine(zahl);
}
```

### Wichtig
- `foreach` durchläuft alle Elemente **nacheinander**
- Reihenfolge: **Zeile für Zeile**

---

## Beispiel: Foreach mit 2D Array

```csharp
int[,] zahlen =
{
    { 10, 20 },
    { 30, 40 }
};

foreach (int zahl in zahlen)
{
    Console.WriteLine(zahl);
}
```

### Ausgabe

```text
10
20
30
40
```

---

## Unterschied: For vs Foreach

| Eigenschaft | For | Foreach |
|-------------|-----|---------|
| Zugriff auf Zeile/Spalte | ✅ | ❌ |
| Tabellenstruktur möglich | ✅ | ❌ |
| Einfach zu schreiben | ❌ | ✅ |
| Reihenfolge steuerbar | ✅ | ❌ |

---

## Länge eines 2D Arrays

```csharp
matrix.GetLength(0); // Anzahl der Zeilen
matrix.GetLength(1); // Anzahl der Spalten
```

---

## Beispiel mit GetLength

```csharp
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}
```

---

## Typische Fehler

- Indizes vertauschen (`[Zeile, Spalte]`)
- Grenzen falsch setzen (`< Länge`)
- Versuch mit `foreach` Tabellenstruktur darzustellen
- Falsche Dimension (z. B. `[2][3]` statt `[2,3]`)

---

## Wann verwendet man 2D Arrays?

- Tabellen (z. B. Stundenplan)
- Spielfelder (z. B. Tic Tac Toe)
- Matrizen
- Raster / Karten

---

## Zusammenfassung

Zweidimensionale Arrays:

- bestehen aus **Zeilen und Spalten**
- werden mit `[ , ]` definiert
- Zugriff erfolgt über `[Zeile, Spalte]`

Wichtige Punkte:

- `for` → für strukturierte Ausgabe  
- `foreach` → für einfaches Durchlaufen  
- `GetLength()` → für flexible Schleifen  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )