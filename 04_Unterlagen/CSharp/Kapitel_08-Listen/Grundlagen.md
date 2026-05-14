<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Listen – Grundlagen

## Definition

Eine **Liste** ist eine Datenstruktur, mit der mehrere Werte desselben Datentyps gespeichert werden können.

Im Gegensatz zu einem Array ist eine Liste **dynamisch**.

Das bedeutet:

👉 Elemente können während des Programms hinzugefügt oder entfernt werden.

---

## Namespace

Für Listen wird der Namespace `System.Collections.Generic` benötigt.

```csharp
using System.Collections.Generic;
```

In vielen Projekten ist dieser Namespace bereits automatisch verfügbar. Trotzdem ist es wichtig zu wissen, woher `List<T>` kommt.

---

## Liste erstellen

### Grundstruktur

```csharp
List<Datentyp> name = new List<Datentyp>();
```

### Beispiel mit int

```csharp
List<int> zahlen = new List<int>();
```

Diese Liste kann mehrere ganze Zahlen speichern.

---

## Beispiel mit string

```csharp
List<string> namen = new List<string>();
```

Diese Liste kann mehrere Texte speichern.

---

## Elemente hinzufügen

Mit `Add()` wird ein neues Element am Ende der Liste eingefügt.

```csharp
List<string> namen = new List<string>();

namen.Add("Max");
namen.Add("Anna");
namen.Add("Lena");
```

Die Liste enthält nun:

```text
Max
Anna
Lena
```

---

## Werte direkt beim Erstellen eintragen

Eine Liste kann auch direkt mit Startwerten erstellt werden.

```csharp
List<int> zahlen = new List<int>() { 5, 8, 12, 20 };
```

Oder bei Strings:

```csharp
List<string> faecher = new List<string>()
{
    "Mathematik",
    "Deutsch",
    "Informatik"
};
```

---

## Zugriff über den Index

Wie bei Arrays beginnt der Index bei **0**.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

Console.WriteLine(namen[0]);
Console.WriteLine(namen[1]);
Console.WriteLine(namen[2]);
```

### Ausgabe

```text
Max
Anna
Lena
```

---

## Wert ändern

Ein Element kann über seinen Index verändert werden.

```csharp
List<string> namen = new List<string>() { "Max", "Anna", "Lena" };

namen[1] = "Sophie";

Console.WriteLine(namen[1]);
```

### Ausgabe

```text
Sophie
```

---

## Anzahl der Elemente

Bei Arrays verwendet man `.Length`.

Bei Listen verwendet man `.Count`.

```csharp
List<int> zahlen = new List<int>() { 10, 20, 30 };

Console.WriteLine(zahlen.Count);
```

### Ausgabe

```text
3
```

---

## Wichtig: `Count` statt `Length`

```csharp
zahlen.Count
```

Nicht:

```csharp
zahlen.Length
```

👉 `.Length` gehört zu Arrays.  
👉 `.Count` gehört zu Listen.

---

## Zusammenfassung

Eine Liste:

- wird mit `List<Datentyp>` erstellt
- kann Werte mit `Add()` aufnehmen
- beginnt beim Index 0
- verwendet `.Count` für die Anzahl der Elemente
- ist flexibler als ein Array
