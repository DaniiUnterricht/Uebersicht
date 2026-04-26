[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../../../04_Unterlagen/CSharp/CSharp.md) | [Python Unterlagen](../../../04_Unterlagen/Python/Python.md)

<- [Zurück zur Übersicht](../Python.md)

# Python – Grundlagen -> Einführung

## 🧠 Was ist Programmieren?

Programmieren bedeutet:
👉 Du gibst dem Computer **klare Anweisungen**, was er tun soll.

Beispiel:
- "Zeige einen Text an"
- "Rechne etwas aus"
- "Treffe eine Entscheidung"

Ein Programm ist also einfach eine **Liste von Befehlen**.

---

## 🔄 Vergleich mit dem echten Leben

Stell dir vor:
👉 Du gibst jemandem eine Anleitung zum Kochen

Wenn du sagst:
- "Mach irgendwas mit Nudeln" ❌ → unklar  
- "Koche Wasser, gib Nudeln rein, warte 10 Minuten" ✅ → klar  

👉 Genau so denkt ein Computer!

---

## ⚔️ Python vs. C#

Falls ihr schon C# kennt:

| C# | Python |
|----|--------|
| Sehr streng | Locker & einfacher |
| Viele Regeln | Weniger Regeln |
| `{ }` | Einrückung |

👉 Python ist perfekt zum Lernen 😊

## 🌍 Einsatzgebiete von Python

Python ist eine der **meistgenutzten Programmiersprachen weltweit** 🚀

### 🖥️ 1. Software & Tools
- Kleine Programme
- Automatisierungen (z. B. Dateien sortieren)

---

### 🌐 2. Webentwicklung
- Websites & APIs
- Frameworks wie Django oder Flask

👉 Vergleich:
- C# → ASP.NET  
- Python → Django

---

### 🤖 3. Künstliche Intelligenz (KI)
- Chatbots 🤖
- Bilderkennung
- Machine Learning

👉 Python ist hier **Standard!**

---

### 📊 4. Datenanalyse
- Excel auswerten
- Statistiken berechnen
- Diagramme erstellen

---

### 🎮 5. Spiele (einfachere)
- Kleine Games
- Prototypen

👉 Für große Games eher:
- C# → Unity

---

### ⚙️ 6. Automatisierung
- Aufgaben automatisch erledigen
- Bots schreiben
- Prozesse vereinfachen

---

## 🧠 Fazit

👉 Python ist:
- einfach zu lernen  
- extrem vielseitig  
- perfekt für den Einstieg  

👉 C# ist:
- strukturierter  
- stärker für große Anwendungen  

👉 Beide sind **sehr wertvoll!** 💯

# 🔢 Variablen (Speicher für Daten)

## 🧠 Was ist eine Variable?

Eine Variable ist wie eine **Box**, in der du etwas speicherst.

Beispiel:
👉 Eine Box mit deinem Namen

---

## 📦 Python Beispiel

```python
name = "Dani"
```

👉 Bedeutung:
- Links = Name der Box  
- Rechts = Inhalt  

---

## 📊 Vergleich mit C#

```csharp
string name = "Dani";
```

```python
name = "Dani"
```

👉 Unterschied:
- C# → Typ muss angegeben werden  
- Python → macht das automatisch  

---

## 🔥 Wichtig

```python
x = 5
x = "Hallo"
```

👉 Python erlaubt das  
👉 C# ❌ nicht!

# 📥 Eingabe & Ausgabe

## 🖨️ Ausgabe

### Python
```python
print("Hallo Welt")
```

### C#
```csharp
Console.WriteLine("Hallo Welt");
```

👉 Beide machen das gleiche: Text anzeigen

---

## ⌨️ Eingabe

### Python
```python
name = input("Dein Name: ")
```

### C#
```csharp
Console.Write("Dein Name: ");
string name = Console.ReadLine();
```

👉 Unterschied:
- Python → direkt verwendbar
- C# → muss typisiert werden

---

## ⚠️ Wichtig

Alles aus `input()` ist TEXT!

```python
zahl = input("Zahl: ")
```

### C#
```csharp
Console.Write("Zahl: ");
string zahl = Console.ReadLine();
```

👉 Beide liefern Text zurück!

---

## ❌ Fehler

### Python
```python
print(zahl + 5)
```

### C#
```csharp
Console.WriteLine(zahl + 5);
```

👉 In beiden Fällen falsch!

---

## ✅ Lösung (Casting)

### Python
```python
zahl = int(input("Zahl: "))
print(zahl + 5)
```

### C#
```csharp
Console.Write("Zahl: ");
int zahl = int.Parse(Console.ReadLine());
Console.WriteLine(zahl + 5);
```


# 🔀 IF-Bedingungen (Entscheidungen)

## 🧠 Was macht IF?

👉 Der Computer kann Entscheidungen treffen!

---

## 🔄 Beispiel aus dem echten Leben

Wenn es regnet:
→ nimm einen Regenschirm

---

## 💻 Python

```python
if True:
    print("Das passiert")
```

---

## 📌 Beispiel

```python
zahl = int(input("Zahl: "))

if zahl > 10:
    print("Größer als 10")
```

---

## 🔁 Mehrere Möglichkeiten

```python
if zahl > 10:
    print("Groß")
elif zahl == 10:
    print("Genau 10")
else:
    print("Klein")
```

---

## ⚖️ Vergleich mit C#

```csharp
if (zahl > 10)
{
    Console.WriteLine("Groß");
}
```

```python
if zahl > 10:
    print("Groß")
```

