[C# Startseite](../CSharp.md)
# IF Statements

## Definition
Das `if`-Statement ist eine **Verzweigungsanweisung** (Kontrollstruktur).  
Es ermöglicht dem Programm, eine **Bedingung zu überprüfen** und abhängig vom Ergebnis unterschiedlichen Code auszuführen.

Eine Bedingung liefert immer einen **booleschen Wert**:
- `true`
- `false`

```csharp
if (Bedingung)
{
    // Code wird ausgeführt, wenn die Bedingung true ist
}

// Bsp.

int alter = 18;

if ( alter >= 18 )
{
    Console.WriteLine("Volljährig");
}

// Die Ausgabe erfolgt nur, wenn die Bedingung alter >= 18 wahr ist.
```

---

## Vergleichsoperatoren

| Operator | Bedeutung           |
| -------- | ------------------- |
| ==       | gleich              |
| !=       | ungleich            |
| >        | größer              |
| <        | kleiner             |
| >=       | größer oder gleich  |
| <=       | kleiner oder gleich |

## IF-ELSE

### Wenn eine alternative Ausführung benötigt wird:

```csharp
if (Bedingung)
{
    // Wird ausgeführt wenn true
}
else
{
    // Wird ausgeführt wenn false
}

//Bsp
int note = 4;

if (note <= 4)
{
    Console.WriteLine("Bestanden");
}
else
{
    Console.WriteLine("Nicht bestanden");
}
```

## ELSE IF ( Mehrere Bedingungen )
```csharp
if (note == 1)
{
    Console.WriteLine("Sehr gut");
}
else if (note == 2)
{
    Console.WriteLine("Gut");
}
else
{
    Console.WriteLine("Andere Note");
}
```
**Wichtig**: Bedingungen werden von oben nach unten geprüft.
Sobald eine Bedingung true ist, wird der restliche Block übersprungen.

### Beispiel: Code wird niemals ausgeführt

```csharp
int zahl = 10;

if (zahl > 5)
{
    Console.WriteLine("Größer als 5");
}
else if (zahl > 8)
{
    Console.WriteLine("Größer als 8");
}
else
{
    Console.WriteLine("Andere Zahl");
}
```

### Korrekte Reihenfolge / Antwort

<details>
<summary>Antwort</summary>
Weil jede Zahl, die größer als 8 ist, automatisch auch größer als 5 ist.<br><br>

Die erste Bedingung „fängt“ also bereits alle Werte ab, die die zweite Bedingung prüfen würde.
</details>
<details>
<summary>Code anzeigen</summary>

```csharp
int zahl = 10;

if (zahl > 8)
{
    Console.WriteLine("Größer als 8");
}
else if (zahl > 5)
{
    Console.WriteLine("Größer als 5");
}
else
{
    Console.WriteLine("5 oder kleiner");
}
```
</details>
<details>
<summary>Merksatz</summary>
Bedingungen sollten von spezifisch nach allgemein formuliert werden,<br><br>
sonst entstehen logisch unerreichbare Codebereiche.
</details>

---

## Logische Operatoren

Mehrere Bedingungen können kombiniert werden:

| Operator | Bedeutung |
| -------- | --------- |
| &&       | UND       |
| \|\|     | ODER      |
| !        | NICHT     |

### Bsp
```csharp
bool hatFuehrerschein = true;
int alter = 20;

if (alter >= 18 && hatFuehrerschein)
{
    Console.WriteLine("Darf Auto fahren");
}
```

---

### Reihenfolge der Auswertung (Operator-Priorität)

In C# werden logische Operatoren in folgender Reihenfolge ausgewertet:

1. `!`  (NICHT)
2. `&&` (UND)
3. `||` (ODER)

Das bedeutet:

`&&` wird vor `||` ausgewertet.

---

### Beispiel ohne Klammern

```csharp
bool a = true;
bool b = false;
bool c = true;

if (a || b && c)
{
    Console.WriteLine("Wird ausgeführt");
}
```
#### Was passiert hier?
Zuerst wird `b && c` berechnet:
```
false && true → false
```
Dann:
```
true || false → true
```
Das Ergebnis ist also ``true``.

### Beispiel mit Klammern
```csharp
if ((a || b) && c)
{
    Console.WriteLine("Wird ausgeführt");
}
```
Jetzt wird zuerst ``(a || b)`` berechnet:
```
true || false → true
```
Dann:
```
true && true → true
```

#### Warum sind Klammern wichtig?

Klammern verändern die Reihenfolge der Auswertung
und machen den Code verständlicher.

#### Merksatz

Auch wenn man die Priorität kennt:

Verwende Klammern zur besseren Lesbarkeit und um Missverständnisse zu vermeiden.

## Verschachtelte IF-Statements
Ein verschachteltes IF-Statement bedeutet,  
dass sich ein `if`-Block innerhalb eines anderen `if`-Blocks befindet.

Das innere `if` wird nur geprüft,  
wenn die äußere Bedingung `true` ist.

---

## Grundstruktur

```csharp
if (Bedingung1)
{
    if (Bedingung2)
    {
        // Code wird nur ausgeführt,
        // wenn beide Bedingungen true sind
    }
}
```
### Bsp.:
```csharp
if (alter >= 18)
{
    if (hatFuehrerschein)
    {
        Console.WriteLine("Darf Auto fahren");
    }
}
```
#### Ablauf

1. Zuerst wird geprüft: alter >= 18

2. Nur wenn das true ist, wird geprüft: hatFuehrerschein

3. Nur wenn beide Bedingungen true sind, wird der Code ausgeführt

### Mit ELSE-Zweig
```csharp
int alter = 16;
bool hatFuehrerschein = true;

if (alter >= 18)
{
    if (hatFuehrerschein)
    {
        Console.WriteLine("Darf Auto fahren");
    }
    else
    {
        Console.WriteLine("Kein Führerschein");
    }
}
else
{
    Console.WriteLine("Zu jung");
}
// Hier entstehen mehrere Entscheidungsebenen.
```

### Vergleich: Verschachteltes IF vs. Logischer Operator

Statt verschachtelt zu schreiben:
```csharp
if (alter >= 18)
{
    if (hatFuehrerschein)
    {
        Console.WriteLine("Darf Auto fahren");
    }
}
```
kann man auch schreiben:
```csharp
if (alter >= 18 && hatFuehrerschein)
{
    Console.WriteLine("Darf Auto fahren");
}
```
Beide Varianten sind logisch gleich.

### Wann sind verschachtelte IFs sinnvoll?

Verschachtelungen sind sinnvoll, wenn:

- Eine zweite Bedingung nur relevant ist, wenn die erste erfüllt ist

- Mehrere Entscheidungsebenen benötigt werden

- Unterschiedliche Fehlerfälle getrennt behandelt werden sollen

### Problem: Zu tiefe Verschachtelung

Viele Ebenen verschlechtern die Lesbarkeit:
```csharp
if (a)
{
    if (b)
    {
        if (c)
        {
            if (d)
            {
                Console.WriteLine("Sehr schwer lesbar");
            }
        }
    }
}
```
Solche Strukturen nennt man:

> "Pyramid of Doom"

### Zusammenfassung

Verschachtelte IF-Statements:

- Sind IF-Statements innerhalb eines IF-Blocks

- Werden von außen nach innen geprüft

- Können durch logische Operatoren ersetzt werden

- Sollten nicht zu tief verschachtelt werden

- Beeinflussen stark die Lesbarkeit des Codes

## Wichtige Hinweise
- Die Bedingung muss immer einen bool-Wert liefern.

- Geschweifte Klammern {} sind bei mehreren Anweisungen notwendig.

- else ist optional.

- else if kann beliebig oft verwendet werden.

- Bedingungen werden von oben nach unten geprüft.

## Zusammenfassung
Das ``if``-Statement:

- Prüft eine Bedingung

- Führt Code abhängig von ``true`` oder ``false`` aus

- Gehört zu den Verzweigungsanweisungen

- Ist eine zentrale Kontrollstruktur in C#