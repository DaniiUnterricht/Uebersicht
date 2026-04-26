[C# Startseite](../CSharp.md)

# Jagged Arrays

## Definition

Ein **Jagged Array** ist ein **Array von Arrays**.

Das bedeutet:  
Jedes Element im Hauptarray ist **selbst wieder ein Array**.

---

## Besonderheit

Die inneren Arrays können **unterschiedlich viele Elemente** besitzen.

👉 Das Array ist also **nicht rechteckig**, sondern flexibel.

---

## Grundstruktur

```csharp
Datentyp[][] name = new Datentyp[Anzahl][];
```

---

## Beispiel: Array erstellen

```csharp
int[][] zahlen = new int[3][];
```

→ Das äußere Array hat 3 Elemente  
→ Die inneren Arrays sind noch **nicht erstellt**

### Beispiel: Array + innere erstellen
```csharp
int[][] zahlen = new int[3][];

zahlen[0] = new int[2];
zahlen[1] = new int[3];
zahlen[2] = new int[1];
```
---

## Beispiel: Arrays befüllen

```csharp
zahlen[0] = new int[] { 1, 2 };
zahlen[1] = new int[] { 3, 4, 5 };
zahlen[2] = new int[] { 6 };
```

---

## Darstellung

```
Index 0 → [1, 2]  
Index 1 → [3, 4, 5]  
Index 2 → [6]
```

---

## Zugriff auf Elemente

```csharp
Console.WriteLine(zahlen[1][2]); // Ausgabe: 5
```

👉 Erst äußeres Array, dann inneres

---

## Durchlaufen mit For-Schleifen

```csharp
for (int i = 0; i < zahlen.Length; i++)
{
    for (int j = 0; j < zahlen[i].Length; j++)
    {
        Console.Write(zahlen[i][j] + " ");
    }
    Console.WriteLine();
}
```

---

## Beispiel: Unterschiedliche Längen

```csharp
int[][] punkte =
{
    new int[] { 10, 20 },
    new int[] { 5 },
    new int[] { 7, 8, 9 }
};
```

---

## Typische Fehler

- Innere Arrays nicht initialisiert  
- Zugriff auf falschen Index  
- `.Length` falsch verwendet (`zahlen[i].Length` vergessen)  

---

## Unterschied zu 2D Arrays

| Jagged Array | 2D Array |
|-------------|---------|
| `int[][]` | `int[,]` |
| flexible Länge | feste Größe |
| mehrere Arrays | eine Tabelle |

---

## Wann verwendet man Jagged Arrays?

- Daten mit **unterschiedlicher Länge**  
- Punkte / Scores / Listen  
- unregelmäßige Strukturen  
- API / JSON Daten  

---

## Zusammenfassung

Jagged Arrays:

- sind **Arrays von Arrays**  
- haben **unterschiedlich lange Elemente**  
- werden mit `[][]` definiert  

Wichtig:

- zuerst äußeres Array erstellen  
- dann jedes innere Array einzeln  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )