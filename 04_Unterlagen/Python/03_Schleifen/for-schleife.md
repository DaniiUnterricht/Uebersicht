[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../../../04_Unterlagen/CSharp/CSharp.md) | [Python Unterlagen](../../../04_Unterlagen/Python/Python.md)

<- [Zurück zur Übersicht](../Python.md)

# Python – Schleifen -> for Schleife

## 🔁 Was ist eine for-Schleife?

Die `for`-Schleife wird verwendet, wenn man **eine feste Anzahl an Wiederholungen** hat.

👉 Typische Fälle:

* Zählen (1 bis 10)
* Mehrfach dieselbe Aktion ausführen
* Arbeiten mit Zahlenbereichen

---

## 🧾 Syntax in Python

```python
for variable in range(anzahl):
    # Code
```

---

## 🧾 Syntax in C#

```csharp
for (int i = 0; i < anzahl; i++)
{
    // Code
}
```

---

## ⚖️ Vergleich Python vs. C#

| Python                      | C#                            |
| --------------------------- | ----------------------------- |
| `for i in range(5):`        | `for (int i = 0; i < 5; i++)` |
| Kein Datentyp nötig         | Datentyp notwendig (`int`)    |
| Kein Zähler-Update sichtbar | `i++` notwendig               |
| Einrückung                  | `{}`                          |

👉 In Python wird der Zähler **automatisch verwaltet**.

---

## 🔢 range() im Detail

Die Funktion `range()` erzeugt eine Zahlenfolge.

### Varianten:

```python
range(5)        # 0,1,2,3,4
range(2, 6)     # 2,3,4,5
range(1, 10, 2) # 1,3,5,7,9
```

👉 Wichtig:

* Der **letzte Wert wird nicht erreicht**
* Startwert ist optional

---

## 📌 Beispiel 1 – Einfaches Zählen

```python
for i in range(5):
    print(i)
```

👉 Ausgabe:
0 1 2 3 4

---

## 📌 Beispiel 2 – Startwert definieren

```python
for i in range(1, 6):
    print(i)
```

👉 Ausgabe:
1 2 3 4 5

---

## 📌 Beispiel 3 – Schrittweite

```python
for i in range(0, 10, 2):
    print(i)
```

👉 Ausgabe:
0 2 4 6 8

---

## 📌 Beispiel 4 – Rückwärts zählen

```python
for i in range(10, 0, -1):
    print(i)
```

👉 Ausgabe:
10 9 8 7 6 5 4 3 2 1

---

## 🧠 Wichtige Eigenschaften

* Schleife läuft **genau so oft wie die Anzahl der Werte**
* Die Variable (`i`) verändert sich automatisch
* Kein Risiko für klassische Endlosschleifen wie bei `while`

---

## ⚠️ Typische Fehler

### ❌ range falsch verstanden

```python
range(5)  # endet bei 4
```

---

### ❌ Einrückung vergessen

```python
for i in range(5):
print(i)
```

---

## 🧠 Merksatz

👉 Die `for`-Schleife in Python ist:

* einfacher
* kompakter
* sicherer als in C#

👉 Sie wird immer dann verwendet, wenn:
➡️ **die Anzahl der Wiederholungen bekannt ist**
