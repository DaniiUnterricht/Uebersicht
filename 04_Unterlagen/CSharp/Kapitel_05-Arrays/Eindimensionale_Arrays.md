[C# Startseite](../CSharp.md)

# Arrays (Eindimensional)

## Definition

Ein **Array** ist eine Datenstruktur, mit der **mehrere Werte desselben Datentyps** in einer einzigen Variable gespeichert werden können.

Anstatt viele einzelne Variablen zu erstellen, kann man alle Werte **geordnet in einem Array speichern**.

Beispiel ohne Array:

```csharp
int zahl1 = 5;
int zahl2 = 8;
int zahl3 = 3;
```

Beispiel mit Array:

```csharp
int[] zahlen = { 5, 8, 3 };
```

Das Array enthält **mehrere Werte**, die über einen **Index** angesprochen werden.

---

## Eigenschaften eines Arrays

- Ein Array speichert **mehrere Werte**
- Alle Werte haben **denselben Datentyp**
- Jedes Element besitzt einen **Index**
- Der **erste Index beginnt immer bei 0**

---

## Array erstellen

### Grundstruktur

```csharp
Datentyp[] name = new Datentyp[Anzahl];
```

### Beispiel

```csharp
int[] zahlen = new int[5];
```

Dieses Array enthält **5 Elemente**.

Die Indizes sind:

```
0
1
2
3
4
```

---

## Werte zuweisen

Einzelne Werte können über den **Index** gespeichert werden.

```csharp
int[] zahlen = new int[3];

zahlen[0] = 10;
zahlen[1] = 20;
zahlen[2] = 30;
```

---

## Werte auslesen

```csharp
Console.WriteLine(zahlen[0]);
Console.WriteLine(zahlen[1]);
Console.WriteLine(zahlen[2]);
```

### Ausgabe

```
10
20
30
```

---

## Array direkt initialisieren

Arrays können auch **direkt mit Werten erstellt werden**.

```csharp
int[] zahlen = { 10, 20, 30, 40 };
```

---

## Beispiel mit Strings

```csharp
string[] faecher = { "Mathematik", "Deutsch", "Informatik" };

Console.WriteLine(faecher[0]);
Console.WriteLine(faecher[1]);
Console.WriteLine(faecher[2]);
```

### Ausgabe

```
Mathematik
Deutsch
Informatik
```

---

## Länge eines Arrays

Die Anzahl der Elemente eines Arrays kann mit **`.Length`** ermittelt werden.

```csharp
int[] zahlen = { 3, 6, 9, 12 };

Console.WriteLine(zahlen.Length);
```

### Ausgabe

```
4
```

---

## Arrays mit for-Schleifen durchlaufen

Arrays werden häufig mit einer **for-Schleife** durchlaufen.

```csharp
int[] zahlen = { 5, 8, 3, 7 };

for (int i = 0; i < zahlen.Length; i++)
{
    Console.WriteLine(zahlen[i]);
}
```

### Ausgabe

```
5
8
3
7
```

---

## Array mit Benutzereingaben füllen

```csharp
int[] zahlen = new int[3];

for (int i = 0; i < zahlen.Length; i++)
{
    Console.Write("Zahl eingeben: ");
    zahlen[i] = int.Parse(Console.ReadLine());
}
```

---

## Typische Fehler

- Zugriff auf einen **Index außerhalb des Arrays**
- falscher Index (Array beginnt bei **0**)
- falscher Datentyp
- `.Length` wird falsch verwendet

Beispiel für einen Fehler:

```csharp
int[] zahlen = new int[3];

zahlen[3] = 10;
```

Dieses Array hat nur die Indizes:

```
0
1
2
```

Der Zugriff auf **Index 3** führt zu einem Fehler.

---

# Vergleich: Einzelne Variablen vs Array

| Einzelne Variablen | Array |
|--------------------|------|
| viele Variablen nötig | eine Variable |
| schwer zu verwalten | übersichtlich |
| keine Schleifen möglich | gut mit Schleifen nutzbar |

---

## Wann sind Arrays sinnvoll?

Arrays eignen sich besonders bei:

- mehreren ähnlichen Daten
- Listen von Zahlen
- Listen von Namen
- Benutzereingaben
- Tabellen oder Berechnungen

---

## Zusammenfassung

Ein **Array**:

- speichert **mehrere Werte**
- hat **einen festen Datentyp**
- verwendet **Indizes**
- beginnt immer bei **Index 0**

Arrays werden häufig zusammen mit:

- **for-Schleifen**
- **Berechnungen**
- **Benutzereingaben**

verwendet.

---

## Mini-Übungen ( Siehe PE_04_XX-XX-2026 )