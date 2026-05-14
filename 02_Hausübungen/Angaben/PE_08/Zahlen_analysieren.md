# Zahlen analysieren

## Aufgabenstellung
Der Benutzer gibt mehrere Zahlen ein.  
Das Programm soll diese Zahlen auswerten.

- Alle Zahlen anzeigen  
- Summe berechnen  
- Durchschnitt berechnen  
- Größte Zahl ermitteln  

Ein-/Ausgabe → `Program.cs`  
Logik → `NumberService.cs`

## Projektstruktur
```text
Program.cs
NumberService.cs
```

## Methoden
```csharp
static void PrintNumbers(int[] numbers)
static int Sum(int[] numbers)
static double Average(int[] numbers)
static int Max(int[] numbers)
```

## Methodenbeschreibung

### PrintNumbers(int[] numbers)
Gibt alle Zahlen aus dem Array formatiert auf der Konsole aus.

**Parameter:**
- `numbers` → Array mit allen eingegebenen Zahlen

---

### Sum(int[] numbers)
Berechnet die Summe aller Zahlen im Array.

**Parameter:**
- `numbers` → Array mit Zahlen

**Rückgabewert:**
- Summe aller Werte

---

### Average(int[] numbers)
Berechnet den Durchschnitt aller Zahlen.

**Parameter:**
- `numbers` → Array mit Zahlen

**Rückgabewert:**
- Durchschnitt als `double`

---

### Max(int[] numbers)
Ermittelt die größte Zahl im Array.

**Parameter:**
- `numbers` → Array mit Zahlen

**Rückgabewert:**
- Größter Wert im Array

---

## Beispielausgabe
```text
Wie viele Zahlen möchtest du eingeben: 5

Zahl 1: 4
Zahl 2: 7
Zahl 3: 2
Zahl 4: 9
Zahl 5: 6

--- Auswertung ---

Eingegebene Zahlen: 4, 7, 2, 9, 6
Summe: 28
Durchschnitt: 5,6
Größte Zahl: 9
```
