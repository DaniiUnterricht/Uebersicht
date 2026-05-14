# Auswahlskarte

## Aufgabenstellung
Erstelle ein Programm mit einem **Jagged Array**.

- Mehrere Kategorien
- Jede Kategorie hat **unterschiedlich viele Einträge**

Die Schüler dürfen den Jagged Array **selbst befüllen**, zum Beispiel mit:
- Essen
- Tieren
- Filmen
- Ländern
- Werkzeugen

Das Programm soll:
1. Alle Kategorien anzeigen  
2. Benutzer wählt eine Kategorie  
3. Benutzer wählt ein Element daraus  
4. Auswahl wird ausgegeben  

Ein-/Ausgabe → `Program.cs`  
Logik → `JaggedArrayService.cs`

## Projektstruktur
```text
Program.cs
JaggedArrayService.cs
```

## Methoden
```csharp
static void PrintJaggedArray(string[][] data)
static void PrintCategory(string[] category, int index)
static string GetItem(string[][] data, int categoryIndex, int itemIndex)
```

## Methodenbeschreibung

### PrintJaggedArray(string[][] data) 
Gibt alle Kategorien mit ihren Einträgen aus.

**Parameter:**
- `data` → Jagged Array mit allen Kategorien

---

### PrintCategory(string[] category, int index)
Gibt eine einzelne Kategorie mit ihren Einträgen aus.

**Parameter:**
- `category` → Array mit den Einträgen einer Kategorie
- `index` → Nummer der Kategorie

---

### GetItem(string[][] data, int categoryIndex, int itemIndex)
Gibt ein ausgewähltes Element aus dem Jagged Array zurück.

**Parameter:**
- `data` → gesamter Jagged Array
- `categoryIndex` → ausgewählte Kategorie
- `itemIndex` → ausgewähltes Element innerhalb der Kategorie

**Rückgabewert:**
- Ausgewählter Eintrag als `string`

---

## Beispielausgabe
```text
--- Menü ---

1: Pizza, Pasta
2: Cola, Wasser, Saft
3: Eis, Kuchen

Kategorie wählen: 2
Element wählen: 3

Du hast gewählt: Saft
```
