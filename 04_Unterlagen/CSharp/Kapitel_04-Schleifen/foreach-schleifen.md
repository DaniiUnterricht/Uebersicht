[C# Startseite](../CSharp.md)

# Foreach-Schleifen

## Definition
Die `foreach`-Schleife ist eine **Wiederholungsanweisung** (Kontrollstruktur).

Sie wird verwendet, um **alle Elemente einer Sammlung** (z. B. Array oder Liste) **nacheinander zu durchlaufen**.

Dabei wird jedes Element automatisch in einer **temporären Variable** gespeichert.

---

## Foreach-Schleife

### Grundstruktur

```csharp
foreach (Datentyp variable in Sammlung)
{
    // Codeblock
}
```

### Bestandteile

| Element | Bedeutung |
|--------|-----------|
| `foreach` | leitet die Schleife ein |
| `Datentyp` | Datentyp der Elemente (z. B. int, string) |
| `variable` | aktuelle Variable für das Element |
| `Sammlung` | z. B. Array oder Liste |
| `{ }` | enthält den Codeblock |

---

## Ablauf

1. Das erste Element der Sammlung wird genommen  
2. Es wird in der Variable gespeichert  
3. Der Codeblock wird ausgeführt  
4. Das nächste Element wird genommen  
5. Dieser Ablauf wiederholt sich  
6. Sobald alle Elemente durchlaufen wurden, endet die Schleife  

---

## Wichtig: Automatisches Durchlaufen

Die `foreach`-Schleife übernimmt den kompletten Ablauf automatisch:

- Kein Index notwendig  
- Keine Bedingung notwendig  
- Keine Veränderung (`i++`) notwendig  

---

## Einfaches Beispiel

```csharp
int[] zahlen = { 1, 2, 3, 4, 5 };

foreach (int zahl in zahlen)
{
    Console.WriteLine(zahl);
}
```

### Ausgabe

```text
1
2
3
4
5
```

---

## Beispiel: Strings durchlaufen

```csharp
string[] namen = { "Anna", "Max", "Lena" };

foreach (string name in namen)
{
    Console.WriteLine(name);
}
```

### Ausgabe

```text
Anna
Max
Lena
```

---

## Beispiel: Summe berechnen

```csharp
int[] zahlen = { 2, 4, 6 };

int summe = 0;

foreach (int zahl in zahlen)
{
    summe += zahl;
}

Console.WriteLine(summe);
```

### Ausgabe

```text
12
```

---

## Beispiel: Zeichen eines Wortes

```csharp
string wort = "Hallo";

foreach (char buchstabe in wort)
{
    Console.WriteLine(buchstabe);
}
```

### Ausgabe

```text
H
a
l
l
o
```

---

## Unterschied zur For-Schleife

| Eigenschaft | Foreach | For |
|-------------|--------|-----|
| Zugriff über Index | ❌ | ✅ |
| Einfach zu lesen | ✅ | ❌ |
| Änderung der Werte möglich | ❌ | ✅ |
| Automatischer Ablauf | ✅ | ❌ |

---

## Wichtig: Keine Veränderung der Elemente

Mit `foreach` kann man die Elemente **nicht direkt verändern**.

```csharp
int[] zahlen = { 1, 2, 3 };

foreach (int zahl in zahlen)
{
    zahl = 10; // ❌ Fehler!
}
```

Grund:  
Die Variable ist **nur eine Kopie**, keine Referenz auf das Original.

---

## Werte verändern (Alternative mit For)

```csharp
int[] zahlen = { 1, 2, 3 };

for (int i = 0; i < zahlen.Length; i++)
{
    zahlen[i] = 10;
}
```

---

## Schleife mit Abbruch (break)

```csharp
int[] zahlen = { 1, 2, 3, 4, 5 };

foreach (int zahl in zahlen)
{
    if (zahl == 3)
    {
        break;
    }

    Console.WriteLine(zahl);
}
```

### Ausgabe

```text
1
2
```

---

## Schleifendurchlauf überspringen (continue)

```csharp
int[] zahlen = { 1, 2, 3, 4, 5 };

foreach (int zahl in zahlen)
{
    if (zahl == 3)
    {
        continue;
    }

    Console.WriteLine(zahl);
}
```

### Ausgabe

```text
1
2
4
5
```

---

## Wann ist die Foreach-Schleife sinnvoll?

Die `foreach`-Schleife eignet sich besonders bei:

- Arrays durchlaufen  
- Listen (`List<T>`) durchlaufen  
- Strings (Zeichen) durchlaufen  
- Daten ausgeben  
- einfache Berechnungen (z. B. Summe)  

---

## Typische Fehler

- Falscher Datentyp (`int` statt `string`)  
- Versuch, Werte zu verändern  
- Verwechslung mit `for`  
- Zugriff auf Index (nicht möglich bei foreach)  

---

## Vergleich: While vs Do-While vs For vs Foreach

| Eigenschaft | While | Do-While | For | Foreach |
|-------------|------|----------|-----|---------|
| Bedingung notwendig | ✅ | ✅ | ✅ | ❌ |
| Automatischer Ablauf | ❌ | ❌ | ❌ | ✅ |
| Zugriff über Index | ❌ | ❌ | ✅ | ❌ |
| Gut für Sammlungen | ❌ | ❌ | ⚠️ | ✅ |

---

## Zusammenfassung

Die `foreach`-Schleife:

- ist eine **Wiederholungsanweisung**
- durchläuft **alle Elemente einer Sammlung**
- ist **einfach und übersichtlich**

Sie benötigt:

- eine **Sammlung**
- eine **Variable für das aktuelle Element**

Wichtige Punkte:

- Kein Index notwendig  
- Kein Zähler notwendig  
- Keine direkte Veränderung der Elemente möglich  
- Ideal für das **Lesen von Daten**  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )