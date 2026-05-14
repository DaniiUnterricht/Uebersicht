# Noten Auswertung

## Aufgabenstellung
Der Benutzer gibt mehrere Noten ein.  
Das Programm soll diese auswerten.

- Durchschnitt berechnen  
- Beste Note finden  
- Schlechteste Note finden  
- Verbale Bewertung ausgeben  

Ein-/Ausgabe → `Program.cs`  
Logik → `GradeService.cs`

## Projektstruktur
```text
Program.cs
GradeService.cs
```

## Methoden
```csharp
static double CalculateAverage(int[] grades)
static int GetBestGrade(int[] grades)
static int GetWorstGrade(int[] grades)
static string GetRating(double average)
```

## Methodenbeschreibung

### CalculateAverage(int[] grades)
Berechnet den Durchschnitt aller Noten.

**Parameter:**
- `grades` → Array mit Noten

**Rückgabewert:**
- Durchschnitt als `double`

---

### GetBestGrade(int[] grades)
Ermittelt die beste Note.

**Parameter:**
- `grades` → Array mit Noten

**Rückgabewert:**
- Beste Note (kleinster Wert)

---

### GetWorstGrade(int[] grades)
Ermittelt die schlechteste Note.

**Parameter:**
- `grades` → Array mit Noten

**Rückgabewert:**
- Schlechteste Note (größter Wert)

---

### GetRating(double average)
Gibt eine verbale Bewertung zum Durchschnitt zurück.

**Parameter:**
- `average` → Durchschnittsnote

**Rückgabewert:**
- Text, zum Beispiel `"Gut"`

---

## Beispielausgabe
```text
Wie viele Noten möchtest du eingeben: 4

Note 1: 2
Note 2: 1
Note 3: 3
Note 4: 2

--- Ergebnis ---

Durchschnitt: 2,0
Beste Note: 1
Schlechteste Note: 3
Bewertung: Gut
```
