[C# Startseite](../CSharp.md)

# Methoden – Übersicht

## Definition

Eine Methode ist ein **Codeblock**, der eine Aufgabe ausführt.

---

# 🧱 Grundlagen

```csharp
void Begruessung()
{
    Console.WriteLine("==== Willkommen ====");
    Console.WriteLine("Programm gestartet");
    Console.WriteLine("===================");
}

Begruessung();
```

---

# 🧩 Mit Parametern

```csharp
void Begruessung(string name)
{
    Console.WriteLine("Hallo " + name);
}

Begruessung("Dani");
```

---

# 🔄 Mit Rückgabewert

```csharp
int Addiere(int a, int b)
{
    return a + b;
}

int ergebnis = Addiere(3, 5);
```

---

# ⚖️ Vergleich

| Typ | Beschreibung |
|-----|------------|
| `void` | macht etwas |
| Parameter | bekommt Werte |
| Rückgabewert | gibt Ergebnis zurück |

---

# 🧠 Merksätze

👉 `void` → führt Code aus  
👉 Parameter → machen Methoden flexibel  
👉 Rückgabewert → liefert Ergebnis  

---

# ⚠️ Typische Fehler

- Methode nicht aufgerufen  
- Parameter vergessen  
- `return` fehlt  
- falscher Datentyp  

---

# 🚀 Fazit

Methoden:

- vermeiden Wiederholungen  
- strukturieren Programme  
- machen Code flexibler  

---

## Mini-Übungen ( Siehe PE_XX_XX-XX-XXXX )