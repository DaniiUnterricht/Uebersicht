[C# Startseite](../CSharp.md)

# For-Schleifen

## Definition
Die `for`-Schleife ist eine **Wiederholungsanweisung** (Kontrollstruktur).

Sie wird verwendet, wenn ein Codeblock **mehrmals ausgeführt** werden soll und die Anzahl der Wiederholungen bereits ungefähr bekannt ist.

Die Schleife arbeitet mit einer **Zählvariable**, die sich bei jedem Durchlauf verändert.

---

## For-Schleife

### Grundstruktur

```csharp
for (Startwert; Bedingung; Veränderung)
{
    // Codeblock
}
```

### Bestandteile

| Element | Bedeutung |
|--------|-----------|
| `for` | leitet die Schleife ein |
| `Startwert` | wird genau einmal am Anfang ausgeführt |
| `Bedingung` | wird vor jedem Durchlauf geprüft |
| `Veränderung` | wird nach jedem Durchlauf ausgeführt |
| `{ }` | enthält den Codeblock |

---

## Einfaches Beispiel

```csharp
for (int zahl = 1; zahl <= 5; zahl++)
{
    Console.WriteLine(zahl);
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

1. Die Zählvariable wird erstellt  
2. Die Bedingung wird geprüft  
3. Ist sie **true**, wird der Code ausgeführt  
4. Danach wird die Veränderung ausgeführt  
5. Anschließend wird die Bedingung erneut geprüft  
6. Sobald sie **false** ist, endet die Schleife  

---

## Wichtig: Bedingung wird vor jedem Durchlauf geprüft

Bei der For-Schleife wird die **Bedingung vor jedem Durchlauf geprüft**.

Wenn sie von Anfang an **false** ist, wird der Code **kein einziges Mal ausgeführt**.

```csharp
for (int zahl = 10; zahl < 5; zahl++)
{
    Console.WriteLine("Hallo");
}
```

### Ausgabe

```
(keine Ausgabe)
```

---

## Bestandteile genauer erklärt

Eine For-Schleife besteht aus drei Bereichen:

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```

### Erklärung

- `int i = 0` → Startwert  
- `i < 5` → Bedingung  
- `i++` → Veränderung nach jedem Durchlauf  

---

## Beispiel: Rückwärts zählen

```csharp
for (int i = 5; i >= 1; i--)
{
    Console.WriteLine(i);
}
```

### Ausgabe

```
5
4
3
2
1
```

---

## Beispiel: Nur gerade Zahlen

```csharp
for (int i = 2; i <= 10; i += 2)
{
    Console.WriteLine(i);
}
```

### Ausgabe

```
2
4
6
8
10
```

---

## Beispiel: Summe berechnen

```csharp
int summe = 0;

for (int i = 1; i <= 5; i++)
{
    summe += i;
}

Console.WriteLine(summe);
```

### Ausgabe

```
15
```

---

## Beispiel: Text mehrfach ausgeben

```csharp
for (int i = 1; i <= 3; i++)
{
    Console.WriteLine("Hallo");
}
```

### Ausgabe

```
Hallo
Hallo
Hallo
```

---

## Endlosschleifen

Wenn die Bedingung **immer true bleibt**, entsteht eine **Endlosschleife**.

```csharp
for (;;)
{
    Console.WriteLine("Endlosschleife");
}
```

Diese Schleife endet nur, wenn das Programm beendet wird.

---

## Schleife mit Abbruch (break)

Mit `break` kann eine Schleife **sofort beendet werden**.

```csharp
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(i);

    if (i == 3)
    {
        break;
    }
}
```

### Ausgabe

```
1
2
3
```

---

## Schleifendurchlauf überspringen (continue)

Mit `continue` wird der aktuelle Durchlauf **übersprungen**.

Danach läuft die Schleife normal weiter.

```csharp
for (int i = 1; i <= 5; i++)
{
    if (i == 3)
    {
        continue;
    }

    Console.WriteLine(i);
}
```

### Ausgabe

```
1
2
4
5
```

---

# Vergleich: While vs Do-While vs For

| Eigenschaft | While | Do-While | For |
|-------------|------|----------|-----|
| Bedingung wird geprüft | vor der Ausführung | nach der Ausführung | vor der Ausführung |
| Code kann 0-mal laufen | ✅ | ❌ | ✅ |
| Code läuft mindestens einmal | ❌ | ✅ | ❌ |
| Gut für bekannte Anzahl an Wiederholungen | ❌ | ❌ | ✅ |

---

## Typische Fehler

- Bedingung wird falsch formuliert  
- Veränderung der Zählvariable fehlt → **Endlosschleife**  
- falsche Vergleichsoperatoren (`<`, `<=`, `>` usw.)  
- Zählvariable wird falsch erhöht oder verringert  
- Startwert, Bedingung und Veränderung passen nicht zusammen  

---

## Wann ist die For-Schleife sinnvoll?

Die For-Schleife eignet sich besonders bei:

- Zählschleifen  
- festgelegter Anzahl von Wiederholungen  
- Berechnungen mit Zählern  
- Durchläufen von Zahlenbereichen  
- Tabellen oder Mustern  

---

## Zusammenfassung

Die `for`-Schleife:

- ist eine **Wiederholungsanweisung**
- führt Code **mehrmals aus**
- eignet sich besonders dann, wenn man weiß, **wie oft** etwas wiederholt werden soll

Sie besteht aus drei Teilen:

- **Startwert**
- **Bedingung**
- **Veränderung**

Die Bedingung wird **vor jedem Durchlauf geprüft**.

Wenn sie **false** ist, wird der Code **nicht ausgeführt**.

---

## Mini-Übungen ( Siehe PE_04_08-03-2026 )