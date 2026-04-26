[C# Startseite](../CSharp.md)

# Methoden mit Parametern

## Definition

Parameter sind **Eingabewerte**, die einer Methode übergeben werden.

👉 Dadurch wird die Methode **flexibel**.

---

## Warum Parameter?

### Ohne Parameter

```csharp
void Begruessung()
{
    Console.WriteLine("Hallo Dani");
}

Begruessung();
Begruessung();
```

👉 Funktioniert nur für **eine Person**

---

### Mit Parameter

```csharp
void Begruessung(string name)
{
    Console.WriteLine("Hallo " + name);
}

Begruessung("Dani");
Begruessung("Alex");
```

👉 Funktioniert für **beliebige Namen**

---

## 🎯 Didaktischer Effekt

👉 Ohne Parameter:

- Methode ist **unflexibel**

👉 Mit Parameter:

- Methode kann **immer wieder verwendet werden**

💥 Eine Methode → viele Möglichkeiten

---

## Grundstruktur

```csharp
void MethodenName(Datentyp parameter)
{
    // Code
}
```

---

## Beispiel: Mehrere Parameter

```csharp
void Addiere(int a, int b)
{
    Console.WriteLine(a + b);
}

Addiere(3, 5);
Addiere(10, 2);
```

---

## Erklärung

- `a` und `b` sind Parameter  
- Werte werden beim Aufruf übergeben  

---

## Typische Fehler

- falsche Anzahl an Parametern  
- falscher Datentyp  
- Reihenfolge vertauscht  

---

## Zusammenfassung

Parameter:

- machen Methoden flexibel  
- ermöglichen unterschiedliche Eingaben  
- werden beim Aufruf übergeben  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )