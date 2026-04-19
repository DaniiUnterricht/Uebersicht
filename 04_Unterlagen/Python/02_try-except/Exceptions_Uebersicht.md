# 🐍 Python – Exceptions Übersicht

## 🧠 Was sind Exceptions?

Exceptions sind **Fehler**, die während der Programmausführung auftreten können.

👉 Mit `try` und `except` kannst du diese Fehler abfangen und dein Programm stabil halten.

---

## 🔥 Wichtige Exception-Typen

### 🔢 ValueError
Falscher Wert (z. B. Text statt Zahl)

```python
int("abc")
```

---

### 🔤 TypeError
Falscher Datentyp

```python
"Hallo" + 5
```

---

### ➗ ZeroDivisionError
Division durch 0

```python
10 / 0
```

---

### 📦 IndexError
Ungültiger Index (Liste)

```python
[1, 2, 3][5]
```

---

### 🔑 KeyError
Key existiert nicht (Dictionary)

```python
{"name": "Dani"}["alter"]
```

---

### 📁 FileNotFoundError
Datei nicht gefunden

```python
open("test.txt")
```

---

### ⌨️ NameError
Variable existiert nicht

```python
print(x)
```

---

### ⚙️ AttributeError
Objekt hat dieses Attribut nicht

```python
"abc".upperr()
```

---

## ⚠️ Allgemeines `except`

```python
try:
    ...
except:
    print("Fehler!")
```

👉 Fängt **ALLE Fehler** ab

❗ Nachteil:
- Man weiß nicht, welcher Fehler passiert ist

---

## 🔗 Mehrere Exceptions behandeln

### Variante 1: getrennt

```python
try:
    ...
except ValueError:
    print("Value Error")
except TypeError:
    print("Type Error")
```

---

### Variante 2: zusammengefasst

```python
try:
    ...
except (ValueError, TypeError):
    print("Fehler bei Eingabe!")
```

👉 Beide Fehler werden gleich behandelt

---

## 📌 Reihenfolge ist wichtig!

👉 Python prüft `except` von **oben nach unten**

### ❌ FALSCH

```python
try:
    ...
except:
    print("Allgemeiner Fehler")
except ValueError:
    print("Value Error")
```

👉 `ValueError` wird **nie erreicht**

---

### ✅ RICHTIG

```python
try:
    ...
except ValueError:
    print("Value Error")
except:
    print("Allgemeiner Fehler")
```

---

## 🎯 Merksatz

👉 Spezifische Fehler **immer zuerst**  
👉 Allgemeines `except` **immer zuletzt**

---

## 🧠 Fazit

- Exceptions verhindern Abstürze
- Es gibt viele verschiedene Typen
- Du kannst mehrere behandeln
- Reihenfolge ist entscheidend!
