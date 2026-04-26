[C# Startseite](../CSharp.md)

# While / Do-While Schleifen

## Definition
Die ``while``- und ``do-while``-Schleifen sind **Wiederholungsanweisungen** (Kontrollstrukturen).

Sie ermöglichen es, einen Codeblock **mehrmals auszuführen**, solange eine Bedingung erfüllt ist.

Eine Bedingung liefert immer einen **booleschen Wert**:

- `true`
- `false`

Solange die Bedingung **true** ist, wird die Schleife erneut ausgeführt.

---

## While-Schleife

### Grundstruktur

```csharp
while (Bedingung)
{
    // Codeblock
}
```

### Bestandteile

| Element | Bedeutung |
|--------|-----------|
| `while` | leitet die Schleife ein |
| `(Bedingung)` | wird vor jeder Wiederholung geprüft |
| `{ }` | enthält den Codeblock |

---

## Einfaches Beispiel

```csharp
int zahl = 1;

while (zahl <= 5)
{
    Console.WriteLine(zahl);
    zahl++;
}
```

### Ausgabe

```
1
2
3
4
5
```

### Ablauf

1. Die Bedingung wird geprüft  
2. Ist sie **true**, wird der Code ausgeführt  
3. Danach wird die Bedingung erneut geprüft  
4. Sobald sie **false** ist, endet die Schleife  

---

## Wichtig: Bedingung wird zuerst geprüft

Bei der While-Schleife wird die **Bedingung zuerst geprüft**.

Wenn sie **false** ist, wird der Code **kein einziges Mal ausgeführt**.

```csharp
int zahl = 10;

while (zahl < 5)
{
    Console.WriteLine("Hallo");
}
```

### Ausgabe

```
(keine Ausgabe)
```

---

## Endlosschleifen

Wenn die Bedingung **immer true bleibt**, entsteht eine **Endlosschleife**.

```csharp
while (true)
{
    Console.WriteLine("Endlosschleife");
}
```

Diese Schleife endet nur, wenn das Programm beendet wird.

---

## Do-While-Schleife

### Grundstruktur

```csharp
do
{
    // Codeblock
}
while (Bedingung);
```

### Bestandteile

| Element | Bedeutung |
|--------|-----------|
| `do` | startet den Codeblock |
| `{ }` | enthält den Code |
| `while` | prüft die Bedingung |
| `;` | beendet die Schleife |

---

## Besonderheit von do-while

Der Code wird **immer mindestens einmal ausgeführt**.

Die Bedingung wird **erst nach der Ausführung geprüft**.

---

## Einfaches Beispiel

```csharp
int zahl = 1;

do
{
    Console.WriteLine(zahl);
    zahl++;
}
while (zahl <= 5);
```

### Ausgabe

```
1
2
3
4
5
```

---

## Beispiel: Bedingung ist false

```csharp
int zahl = 10;

do
{
    Console.WriteLine("Hallo");
}
while (zahl < 5);
```

### Ausgabe

```
Hallo
```

Obwohl die Bedingung **false** ist, wird der Code **einmal ausgeführt**.

---

## Beispiel: Eingabe prüfen

Ein typischer Einsatz ist die **Eingabeüberprüfung**.

```csharp
int zahl;

do
{
    Console.Write("Bitte Zahl größer als 10 eingeben: ");
    zahl = Convert.ToInt32(Console.ReadLine());

} while (zahl <= 10);
```

Das Programm fordert so lange eine Eingabe, bis die Bedingung erfüllt ist.

---

## Beispiel: Menüsystem

```csharp
int auswahl;

do
{
    Console.WriteLine("1 - Start");
    Console.WriteLine("2 - Einstellungen");
    Console.WriteLine("0 - Beenden");

    auswahl = Convert.ToInt32(Console.ReadLine());

} while (auswahl != 0);
```

Das Menü wird so lange angezeigt, bis der Benutzer **0** eingibt.

---

# Vergleich: While vs Do-While

| Eigenschaft | While | Do-While |
|-------------|------|----------|
| Bedingung wird geprüft | vor der Ausführung | nach der Ausführung |
| Code kann 0-mal laufen | ✅ | ❌ |
| Code läuft mindestens einmal | ❌ | ✅ |

---

## Schleife mit Abbruch (break)

Mit ``break`` kann eine Schleife **sofort beendet werden**.

```csharp
int zahl = 1;

while (true)
{
    Console.WriteLine(zahl);

    if (zahl == 3)
    {
        break;
    }

    zahl++;
}
```

### Ausgabe

```
1
2
3
```

---

## Typische Fehler

- Bedingung wird nie geändert → **Endlosschleife**
- falsche Vergleichsoperatoren
- Semikolon bei ``do-while`` vergessen

---

## Wann sind diese Schleifen sinnvoll?

While eignet sich besonders bei:

- Zählschleifen
- Berechnungen
- Bedingungen

Do-While eignet sich besonders bei:

- Menüsystemen
- Benutzereingaben
- Spielen
- Programmen, die mindestens einmal laufen müssen

---

## Zusammenfassung

Die ``while``- und ``do-while``-Schleifen:

- sind **Wiederholungsanweisungen**
- führen Code **mehrmals aus**
- prüfen eine **Bedingung**

Unterschied:

**While**

- prüft zuerst die Bedingung
- Code kann **0-mal ausgeführt werden**

**Do-While**

- führt Code zuerst aus
- Code wird **mindestens einmal ausgeführt**

---

## Mini-Übungen ( Siehe PE_04_08-03-2026 )