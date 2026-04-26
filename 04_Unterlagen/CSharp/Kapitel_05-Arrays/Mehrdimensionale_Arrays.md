[C# Startseite](../CSharp.md)

# Mehrdimensionale Arrays

## Definition

Ein mehrdimensionales Array ist ein Array mit **mehr als einer Dimension**.

Es erweitert das Konzept eines Arrays auf:

- Zeilen und Spalten (2D)
- zusätzliche Ebenen (3D und mehr)

---

## Beispiel für Dimensionen

| Dimension | Beschreibung |
|----------|-------------|
| 1D | Liste |
| 2D | Tabelle |
| 3D | Würfel |
| nD | komplexe Struktur |

---

## Grundstruktur

```csharp
Datentyp[,,] name = new Datentyp[x, y, z];
```

---

## Beispiel: 3D Array

```csharp
int[,,] cube = new int[2, 3, 4];
```

→ 2 Ebenen  
→ 3 Zeilen  
→ 4 Spalten  

---

## Zugriff auf Elemente

```csharp
cube[1, 2, 3] = 10;
```

---

## Durchlaufen mit For-Schleifen

```csharp
for (int i = 0; i < cube.GetLength(0); i++)
{
    for (int j = 0; j < cube.GetLength(1); j++)
    {
        for (int k = 0; k < cube.GetLength(2); k++)
        {
            Console.WriteLine(cube[i, j, k]);
        }
    }
}
```

---

## Länge eines mehrdimensionalen Arrays

```csharp
cube.GetLength(0); // Dimension 1
cube.GetLength(1); // Dimension 2
cube.GetLength(2); // Dimension 3
```

---

# 🧩 Mehrdimensionale Jagged Arrays

## Definition

Ein mehrdimensionales Jagged Array ist ein **Array von Arrays von Arrays**.

👉 Beispiel: `[][][]`

Jede Ebene kann **unterschiedlich groß sein**.

---

## Grundstruktur

```csharp
Datentyp[][][] name = new Datentyp[Anzahl][][];
```

---

## Beispiel: Array erstellen

```csharp
int[][][] jagged = new int[2][][];
```

---

## Beispiel: Befüllen

```csharp
jagged[0] = new int[2][];
jagged[0][0] = new int[] { 1, 2 };
jagged[0][1] = new int[] { 3 };

jagged[1] = new int[1][];
jagged[1][0] = new int[] { 4, 5, 6 };
```

---

## Zugriff auf Elemente

```csharp
Console.WriteLine(jagged[0][1][0]); // Ausgabe: 3
```

👉 Zugriff erfolgt Ebene für Ebene

---

## Durchlaufen mit For-Schleifen

```csharp
for (int i = 0; i < jagged.Length; i++)
{
    for (int j = 0; j < jagged[i].Length; j++)
    {
        for (int k = 0; k < jagged[i][j].Length; k++)
        {
            Console.WriteLine(jagged[i][j][k]);
        }
    }
}
```

---

## Besonderheiten

- Jede Dimension kann **unterschiedlich groß sein**
- Sehr flexibel, aber komplexer
- Häufig bei verschachtelten Daten (z. B. JSON)

---

## Unterschied: Mehrdimensional vs Jagged

| Mehrdimensional | Jagged |
|---------------|--------|
| `[,,]` | `[][][]` |
| feste Struktur | flexibel |
| ein zusammenhängender Speicherblock | mehrere einzelne Arrays |
| gleiche Größe | unterschiedliche Größen |

---

## Wann verwendet man mehrdimensionale Arrays?

- 3D-Daten (z. B. Spiele, Simulationen)  
- Matrizen  
- feste Tabellenstrukturen  
- Raster / Karten mit fixer Größe  

---

## Wann verwendet man mehrdimensionale Jagged Arrays?

- verschachtelte Daten mit unterschiedlicher Länge  
- komplexe Strukturen  
- API / JSON Daten  
- Spiele mit variablen Ebenen  

---

## Typische Fehler

- falsche Dimension (`[,]` vs `[][]`)  
- innere Arrays nicht initialisiert  
- falscher Index  
- `GetLength()` vs `.Length` verwechselt  

---

## Erweiterung: Mehr als 3 Dimensionen

Auch mehr als 3 Dimensionen sind möglich:

```csharp
int[,,,] daten = new int[2, 2, 2, 2];
```

👉 Wird in der Praxis jedoch selten verwendet

---

## Zusammenfassung

Mehrdimensionale Arrays:

- haben **mehrere Dimensionen**  
- werden mit `[ , ]` erweitert (`[,,]`, `[,,,]`)  
- haben eine **feste Struktur**  

Mehrdimensionale Jagged Arrays:

- sind **Arrays von Arrays von Arrays**  
- werden mit `[][][]` definiert  
- sind **flexibel und unregelmäßig**  

---
