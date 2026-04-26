[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../../../04_Unterlagen/CSharp/CSharp.md) | [Python Unterlagen](../../../04_Unterlagen/Python/Python.md)

<- [Zurück zur Übersicht](../Python.md)

# Python – Schleifen -> while Schleife

## 🔁 Was ist eine while-Schleife?

Die `while`-Schleife wiederholt Code **solange eine Bedingung wahr ist**.

👉 Sie wird verwendet, wenn:

* die Anzahl der Wiederholungen **nicht bekannt ist**
* eine Eingabe oder ein Zustand überprüft wird

---

## 🧾 Syntax in Python

```python
while bedingung:
    # Code
```

---

## 🧾 Syntax in C#

```csharp
while (bedingung)
{
    // Code
}
```

---

## ⚖️ Vergleich Python vs. C#

| Python          | C#                |
| --------------- | ----------------- |
| `while x < 5:`  | `while (x < 5)`   |
| Kein `()` nötig | `()` erforderlich |
| Einrückung      | `{}`              |

---

## 📌 Beispiel 1 – Klassisches Hochzählen

```python
x = 0

while x < 5:
    print(x)
    x += 1
```

👉 Ausgabe:
0 1 2 3 4

---

## ⚠️ Wichtig: Veränderung der Bedingung

👉 Die Variable muss verändert werden!

❌ Falsch:

```python
x = 0

while x < 5:
    print(x)
```

👉 Ergebnis: Endlosschleife

---

## 📌 Beispiel 2 – Benutzereingabe

```python
zahl = int(input("Zahl eingeben: "))

while zahl != 0:
    print("Du hast eingegeben:", zahl)
    zahl = int(input("Zahl eingeben: "))
```

👉 Schleife endet erst bei Eingabe von 0

---

## 🔁 do-while Vergleich

### 🧾 C# do-while

```csharp
int zahl;

do
{
    zahl = int.Parse(Console.ReadLine());
} while (zahl != 0);
```

👉 Wird **mindestens einmal ausgeführt**

---

## 🔄 Python Ersatz

```python
while True:
    zahl = int(input("Zahl eingeben: "))
    
    if zahl == 0:
        break
```

👉 Erklärung:

* `while True` startet eine Endlosschleife
* `break` beendet sie gezielt

---

## ⚖️ Vergleich

| C# do-while            | Python Lösung |
| ---------------------- | ------------- |
| mindestens 1 Durchlauf | `while True`  |
| Bedingung am Ende      | `break`       |

---

## 🔧 break und continue

### break → Schleife beenden

```python
if zahl == 0:
    break
```

---

### continue → Durchlauf überspringen

```python
if zahl < 0:
    continue
```

---

## 📌 Beispiel 3 – Kombination

```python
x = 0

while x < 10:
    x += 1
    
    if x == 5:
        continue
    
    if x == 8:
        break
    
    print(x)
```

👉 Ausgabe:
1 2 3 4 6 7

---

## 🧠 Wichtige Eigenschaften

* läuft solange Bedingung **True**
* flexibel einsetzbar
* kann Endlosschleifen erzeugen

---

## ⚠️ Typische Fehler

* Bedingung wird nie geändert
* falsche Einrückung
* `break` vergessen

---

## 🧠 Merksatz

👉 Die `while`-Schleife wird verwendet, wenn:
➡️ **die Anzahl der Wiederholungen nicht bekannt ist**

👉 Für „mindestens einmal ausführen“:
➡️ **while True + break**
