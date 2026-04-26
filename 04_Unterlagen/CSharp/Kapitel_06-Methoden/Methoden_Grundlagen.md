[C# Startseite](../CSharp.md)

# Methoden – Grundlagen

## Definition

Eine **Methode** ist ein **benannter Codeblock**, der eine bestimmte Aufgabe ausführt.

👉 Methoden helfen dabei, Code **zu strukturieren und wiederzuverwenden**.

---

## Warum Methoden?

### Ohne Methode

```csharp
Console.WriteLine("==== Willkommen ====");
Console.WriteLine("Programm gestartet");
Console.WriteLine("===================");

// später nochmal...
Console.WriteLine("==== Willkommen ====");
Console.WriteLine("Programm gestartet");
Console.WriteLine("===================");
```

---

### Mit Methode

```csharp
void Begruessung()
{
    Console.WriteLine("==== Willkommen ====");
    Console.WriteLine("Programm gestartet");
    Console.WriteLine("===================");
}

Begruessung();
Begruessung();
```

---

## 🎯 Didaktischer Effekt

👉 Wenn sich der Text ändert:

- Ohne Methode → **überall ändern**
- Mit Methode → **nur einmal ändern**

💥 Dadurch spart man Zeit und vermeidet Fehler

---

## Aufbau einer Methode

```csharp
void MethodenName()
{
    // Code
}
```

---

## Bestandteile

| Teil | Bedeutung |
|------|----------|
| `void` | kein Rückgabewert |
| `MethodenName` | Name der Methode |
| `{ }` | Codeblock |

---

## Methode aufrufen

```csharp
Begruessung();
```

👉 Die Methode wird ausgeführt

---

## Beispiel: Menü

```csharp
void ZeigeMenue()
{
    Console.WriteLine("1 - Start");
    Console.WriteLine("2 - Einstellungen");
    Console.WriteLine("3 - Beenden");
}

ZeigeMenue();
```

---

## Typische Fehler

- Methode wird nicht aufgerufen  
- Klammern vergessen `()`  
- Methode außerhalb der Klasse definiert  

---

## Zusammenfassung

Methoden:

- strukturieren Code  
- vermeiden Wiederholungen  
- machen Programme übersichtlicher  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )