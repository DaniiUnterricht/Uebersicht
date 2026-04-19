# 🐍 Einleitung try-except

## 🧠 Ziel der Einheit

- Verstehen, warum Programme abstürzen können
- Eingaben sicher verarbeiten
- Unterschied zwischen C# und Python erkennen

---

## ❗ Problem: Unsichere Eingabe

```python
zahl = int(input("Zahl: "))
print(zahl + 5)
```

👉 Problem: Wenn der Benutzer **keine Zahl** eingibt:

```text
abc
```

💥 Das Programm stürzt ab!

---

## ⚔️ Vergleich mit C#

In C# würde man das so lösen:

```csharp
int zahl;
if (int.TryParse(Console.ReadLine(), out zahl))
{
    Console.WriteLine(zahl + 5);
}
else
{
    Console.WriteLine("Ungültige Eingabe!");
}
```

👉 Vorteil:
- Programm stürzt **nicht ab**
- Eingabe wird überprüft

---

## 🐍 Lösung in Python: try / except

```python
try:
    zahl = int(input("Zahl: "))
    print(zahl + 5)
except:
    print("Das war keine gültige Zahl!")
```

---

## 🧠 Erklärung

- `try` → Versuche den Code auszuführen
- `except` → Wenn ein Fehler passiert, führe diesen Code aus

---

## 🔍 Bessere Variante

```python
try:
    zahl = int(input("Zahl: "))
    print(zahl + 5)
except ValueError:
    print("Bitte gib eine Zahl ein!")
```

👉 Vorteil:
- Nur bestimmte Fehler werden abgefangen
- Besserer Programmierstil

---

## ⚖️ Vergleich C# vs Python

| Konzept | C# | Python |
|--------|----|--------|
| Fehler vermeiden | TryParse | try/except |
| Rückgabe | true/false | Exception |
| Stil | präventiv | reaktiv |

---

## 🧠 Fazit

👉 Programme müssen **robust** sein  
👉 Benutzer machen Fehler – das ist normal  
👉 Gute Programme können damit umgehen 💪
