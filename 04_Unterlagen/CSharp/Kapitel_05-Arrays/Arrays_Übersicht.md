[C# Startseite](../CSharp.md)

# Arrays – Übersicht

## Grundidee

Ein **Array** speichert **mehrere Werte desselben Datentyps** in einer Variable.

---

# 📦 1D Arrays

## Struktur

```csharp
int[] zahlen = new int[3];
```

## Zugriff

```csharp
zahlen[0] = 10;
Console.WriteLine(zahlen[0]);
```

## Eigenschaften

- eine Dimension
- Zugriff über **einen Index**
- feste Länge

---

# 🧱 2D Arrays (Matrix)

## Struktur

```csharp
int[,] matrix = new int[2, 3];
```

## Zugriff

```csharp
matrix[0, 1] = 5;
```

## Eigenschaften

- Zeilen + Spalten
- feste Größe
- Tabellenstruktur

---

# 🧊 Mehrdimensionale Arrays

## Struktur

```csharp
int[,,] cube = new int[2, 3, 4];
```

## Zugriff

```csharp
cube[1, 2, 3] = 10;
```

## Eigenschaften

- mehrere Dimensionen
- feste Struktur
- selten in der Praxis

---

# 🧩 Jagged Arrays

## Struktur

```csharp
int[][] jagged = new int[3][];
```

## Befüllen

```csharp
jagged[0] = new int[] { 1, 2 };
jagged[1] = new int[] { 3, 4, 5 };
jagged[2] = new int[] { 6 };
```

## Zugriff

```csharp
Console.WriteLine(jagged[1][2]);
```

## Eigenschaften

- Array von Arrays
- unterschiedliche Längen möglich
- flexibel

---

# 🧩🧊 Mehrdimensionale Jagged Arrays

## Struktur

```csharp
int[][][] jagged = new int[2][][];
```

## Zugriff

```csharp
Console.WriteLine(jagged[0][1][0]);
```

## Eigenschaften

- mehrere Ebenen
- jede Ebene flexibel
- komplexe Struktur

---

# ⚙️ Wichtige Array-Befehle

## 🔄 Sortieren

### `Array.Sort()`

Sortiert ein Array **aufsteigend**.

```csharp
int[] zahlen = { 5, 2, 8, 1 };
Array.Sort(zahlen);
// Ergebnis: 1, 2, 5, 8
```

---

## 🔁 Umkehren

### `Array.Reverse()`

Dreht die Reihenfolge der Elemente um.

```csharp
Array.Reverse(zahlen);
// Ergebnis: 8, 5, 2, 1
```

---

## 🔍 Suchen

### `Array.IndexOf()`

Gibt den **Index eines Wertes** zurück.

```csharp
int index = Array.IndexOf(zahlen, 5);
```

👉 Wenn der Wert nicht existiert → Ergebnis ist `-1`

---

## 📋 Kopieren

### `Array.Copy()`

Kopiert Werte von einem Array in ein anderes.

```csharp
int[] original = { 1, 2, 3, 4 };
int[] ziel = new int[4];

Array.Copy(original, ziel, 4);
```

👉 Erklärung:

- `original` → Quelle  
- `ziel` → Zielarray  
- `4` → Anzahl der Elemente  

👉 Wichtig:
- Zielarray muss **genug Platz haben**
- Werte werden **elementweise kopiert**

---

### `Clone()`

Erstellt eine **exakte Kopie** eines Arrays.

```csharp
int[] kopie = (int[])original.Clone();
```

👉 Unterschied zu Copy:

- `Clone()` erstellt direkt ein neues Array  
- `Copy()` kopiert in ein bestehendes Array  

---

## 🧹 Leeren

### `Array.Clear()`

Setzt Werte im Array auf den Standardwert zurück.

```csharp
Array.Clear(zahlen, 0, zahlen.Length);
```

👉 Ergebnis bei `int`: alles wird `0`  
👉 Ergebnis bei `string`: alles wird `null`

---

## 📏 Länge

### `.Length`

Gibt die Anzahl der Elemente zurück.

```csharp
int länge = zahlen.Length;
```

---

## 🔄 Durchlaufen

### `foreach`

Einfaches Durchlaufen aller Elemente.

```csharp
foreach (int zahl in zahlen)
{
    Console.WriteLine(zahl);
}
```

👉 Kein Zugriff auf Index möglich

---

# ⚖️ Vergleich

| Typ | Schreibweise | Struktur | Flexibilität |
|-----|-------------|--------|-------------|
| 1D | `[]` | Liste | ❌ |
| 2D | `[,]` | Tabelle | ❌ |
| Mehrdimensional | `[,,]` | Würfel | ❌ |
| Jagged | `[][]` | verschachtelt | ✅ |
| Jagged mehrdim. | `[][][]` | komplex | ✅ |

---

# 🧠 Merksätze

👉 `[,]` → feste Tabelle  
👉 `[,,]` → feste Struktur  
👉 `[][]` → flexibel  
👉 `[][][]` → komplex & flexibel  

---

# ⚠️ Typische Fehler

- `[,]` mit `[][]` verwechseln  
- Jagged Arrays nicht initialisieren  
- falscher Index  
- `.Length` vs `GetLength()` verwechseln  
- `Copy()` ohne genügend großes Zielarray  

---

# 🚀 Fazit

- Arrays speichern mehrere Werte gleichen Typs  
- Mehrdimensionale Arrays sind **starr**  
- Jagged Arrays sind **flexibel**  
- Methoden helfen beim **Sortieren, Suchen und Kopieren**

---