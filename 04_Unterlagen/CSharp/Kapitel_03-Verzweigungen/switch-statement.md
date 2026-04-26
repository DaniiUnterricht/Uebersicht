[C# Startseite](../CSharp.md)
# Switch Statement

## Definition
Das ``switch``-Statement ist eine **Verzweigungsanweisung** (Kontrollstruktur).
Es ermöglicht dem Programm, abhängig vom Wert einer Variable unterschiedliche Codeblöcke auszuführen.

Im Gegensatz zum ``if``-Statement werden hier meist **feste Vergleichswerte** geprüft.

Das ``switch``-Statement eignet sich besonders, wenn:

- viele feste Werte verglichen werden

- die gleiche Variable geprüft wird

- der Code übersichtlicher gestaltet werden soll

## Grundstruktur

```csharp
switch (variable)
{
    case Wert1:
        // Codeblock
        break;

    case Wert2:
        // Codeblock
        break;

    default:
        // Codeblock, wenn kein Fall zutrifft
        break;
}
```
### Bestandteile
| Element   | Bedeutung                                  |
| --------- | ------------------------------------------ |
| `switch`  | leitet die Fallunterscheidung ein          |
| `case`    | prüft auf einen bestimmten Wert            |
| `break`   | beendet den aktuellen Fall                 |
| `default` | wird ausgeführt, wenn kein `case` zutrifft |

## Einfaches Beispiel
```csharp
int note = 2;

switch (note)
{
    case 1:
        Console.WriteLine("Sehr gut");
        break;

    case 2:
        Console.WriteLine("Gut");
        break;

    case 3:
        Console.WriteLine("Befriedigend");
        break;

    default:
        Console.WriteLine("Andere Note");
        break;
}
```
### Ablauf
1. Der Wert von ``note`` wird geprüft

2. Der passende ``case`` wird gesucht

3. Der Code im ``case`` wird ausgeführt

4. ``break`` beendet das ``switch``

## Wichtig: Warum ist ``break`` notwendig?

Ohne ``break`` würde das Programm in den nächsten ``case`` „hineinfallen“.

Beispiel ohne ``break``:
```csharp
int zahl = 1;

switch (zahl)
{
    case 1:
        Console.WriteLine("Eins");

    case 2:
        Console.WriteLine("Zwei");
        break;
}

//Ausgabe:
Eins
Zwei
```
### Warum?

Weil ohne ``break`` der nächste ``case`` ebenfalls ausgeführt wird.

Dieses Verhalten nennt man:

> "Fall-Through"

## Der default-Zweig
Der ``default``-Block wird ausgeführt,

wenn kein ``case`` zutrifft.
```csharp
int monat = 15;

switch (monat)
{
    case 1:
        Console.WriteLine("Jänner");
        break;

    default:
        Console.WriteLine("Ungültiger Monat");
        break;
}
```

## Mehrere Fälle zusammenfassen
Mehrere Werte können denselben Codeblock ausführen:
```csharp
char zeichen = 'a';

switch (zeichen)
{
    case 'a':
    case 'e':
    case 'i':
    case 'o':
    case 'u':
        Console.WriteLine("Vokal");
        break;

    default:
        Console.WriteLine("Konsonant");
        break;
}
```
Hier führen mehrere ``case``-Werte zum gleichen Code.

## Datentypen im Switch
Switch funktioniert mit:

- ``int``

- ``char``

- ``string``

- ``enum``

Beispiel mit ``string``:
```csharp
string rolle = "Admin";

switch (rolle)
{
    case "Admin":
        Console.WriteLine("Voller Zugriff");
        break;

    case "User":
        Console.WriteLine("Eingeschränkter Zugriff");
        break;

    default:
        Console.WriteLine("Unbekannte Rolle");
        break;
}
```

## Reihenfolge der Ausführung
- Das ``switch`` prüft von oben nach unten

- Sobald ein passender ``case`` gefunden wird

- Wird der Code ausgeführt

- ``break`` beendet das ``switch``

Im Gegensatz zu ``if-else`` werden keine Bedingungen wie ``>=`` geprüft,
sondern feste Werte verglichen.

## Vergleich: IF vs. Switch

### IF-Variante
```csharp
if (note == 1)
{
    Console.WriteLine("Sehr gut");
}
else if (note == 2)
{
    Console.WriteLine("Gut");
}
```
### Switch-Variante
```csharp
switch (note)
{
    case 1:
        Console.WriteLine("Sehr gut");
        break;

    case 2:
        Console.WriteLine("Gut");
        break;
}
```
- Switch ist übersichtlicher bei vielen festen Vergleichswerten.
- Jedes Switch kann man mit IF lösen.

### Zusatz
Mit moderner C#-Syntax (Pattern Matching im Switch)
kann ``switch`` mittlerweile auch Bereiche prüfen:
```csharp
int punkte = 90;

switch (punkte)
{
    case >= 90:
        Console.WriteLine("Sehr gut");
        break;
}
```

## Typische Fehler
- ``break`` vergessen

- ``default`` vergessen

- Falscher Datentyp

- Logik, die besser mit ``if`` gelöst wäre

## Wann ist Switch sinnvoll?
Switch eignet sich besonders bei:

- Notensystemen

- Menü-Auswahl

- Statuswerten

- Befehlsverarbeitung

- festen Codes

- usw.

Switch ist weniger geeignet bei:

- komplexen Bedingungen (``>=``, ``&&``, ``||``)

- verschachtelten Logiken

## Zusammenfassung
Das ``switch``-Statement:

- ist eine Verzweigungsanweisung

- prüft feste Werte

- verwendet ``case``-Blöcke

- benötigt ``break``

- besitzt optional einen ``default``-Zweig

- ist übersichtlicher als viele ``else if``-Blöcke

## Mini-Übungen ( Siehe PE_03_01-03-2026 )