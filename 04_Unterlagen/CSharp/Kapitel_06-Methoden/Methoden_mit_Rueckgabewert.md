[C# Startseite](../CSharp.md)

# Methoden mit Rückgabewert

## Definition

Eine Methode kann ein Ergebnis **zurückgeben**.

👉 Statt `void` wird ein **Datentyp** verwendet.

---

## Warum Rückgabewerte?

### Ohne Rückgabewert

```csharp
void Addiere(int a, int b)
{
    Console.WriteLine(a + b);
}
```

👉 Ergebnis wird nur angezeigt  
👉 kann **nicht weiterverwendet werden**

---

### Mit Rückgabewert

```csharp
int Addiere(int a, int b)
{
    return a + b;
}
```

---

## Verwendung

```csharp
int ergebnis = Addiere(3, 5);
Console.WriteLine(ergebnis);
```

---

## 🎯 Didaktischer Effekt

👉 Ohne Rückgabewert:

- Ergebnis ist „weg“ nach der Ausgabe

👉 Mit Rückgabewert:

- Ergebnis kann weiterverarbeitet werden

💥 Methoden können Teil größerer Programme werden

---

## Grundstruktur

```csharp
Datentyp MethodenName()
{
    return Wert;
}
```

---

## Wichtig

- `return` beendet die Methode  
- der Rückgabewert muss zum Datentyp passen  

---

## Typische Fehler

- `return` vergessen  
- falscher Datentyp  
- `void` und Rückgabewert vermischt  

---

## Zusammenfassung

Methoden mit Rückgabewert:

- liefern ein Ergebnis  
- nutzen `return`  
- machen Programme flexibel  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )