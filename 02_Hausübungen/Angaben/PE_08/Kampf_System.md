# Kampf-System

## Aufgabenstellung
Erstelle ein Kampf-System.

Benutzereingaben:
- Name
- Leben
- Angriff
- Krit-Chance (%)

Das Programm:
- führt einen Kampf aus
- berücksichtigt kritische Treffer
- läuft, bis der Gegner besiegt ist
- fragt danach, ob erneut gespielt werden soll

Ein-/Ausgabe → `Program.cs`  
Logik → `PlayerService.cs`

---

## Projektstruktur
```text
Program.cs
PlayerService.cs
```

---

## Methoden
```csharp
static bool IsCriticalHit(int critChance, Random random)
static int CalculateDamage(int damage, bool isCritical)
static int ApplyDamage(int enemyHealth, int attackDamage)
static void PrintAttackResult(int damage, bool isCritical, int enemyHealth)
static bool AskRepeat()
```

---

## Methodenbeschreibung

### IsCriticalHit(int critChance, Random random)
Diese Methode entscheidet, ob ein Angriff ein kritischer Treffer ist.

**Parameter:**
- `critChance` → Krit-Chance in Prozent (z. B. 25 für 25%)
- `random` → Zufallsobjekt, das eine Zahl zwischen 0 und 100 erzeugt, um zu prüfen, ob der Angriff kritisch ist

**Funktionsweise (gedanklich):**
Es wird eine Zufallszahl zwischen 0 und 100 erzeugt.  
Liegt diese Zahl unter der Krit-Chance, ist der Treffer kritisch.

**Rückgabewert:**
- `true` → kritischer Treffer  
- `false` → normaler Treffer  

---

### CalculateDamage(int damage, bool isCritical)
Diese Methode berechnet den tatsächlichen Schaden eines Angriffs.

**Parameter:**
- `damage` → Grundschaden des Spielers  
- `isCritical` → gibt an, ob der Treffer kritisch ist  

**Rückgabewert:**
- tatsächlicher Schaden (z. B. doppelter Schaden bei kritischem Treffer)

---

### ApplyDamage(int enemyHealth, int attackDamage)
Zieht dem Gegner Leben ab.

**Parameter:**
- `enemyHealth` → aktuelles Leben des Gegners  
- `attackDamage` → Schaden des aktuellen Angriffs  

**Rückgabewert:**
- neues Leben des Gegners  

---

### PrintAttackResult(int damage, bool isCritical, int enemyHealth)
Gibt das Ergebnis eines Angriffs auf der Konsole aus.

**Parameter:**
- `damage` → verursachter Schaden  
- `isCritical` → ob der Treffer kritisch war  
- `enemyHealth` → verbleibendes Leben des Gegners  

---

### AskRepeat()
Fragt den Benutzer, ob das Spiel erneut gestartet werden soll.

**Rückgabewert:**
- `true` → ja  
- `false` → nein  

---

## Beispielausgabe
```text
Spielername: Dani
Start-Leben: 100
Angriff: 15
Krit-Chance in %: 25

Gegner Leben: 60

--- Kampf startet ---

Du greifst an!
Treffer: 15 Schaden
Gegner Leben: 45

Du greifst an!
Kritischer Treffer! 30 Schaden
Gegner Leben: 15

Du greifst an!
Treffer: 15 Schaden
Gegner Leben: 0

Gegner besiegt!

Erneut spielen? (y/n): n
```