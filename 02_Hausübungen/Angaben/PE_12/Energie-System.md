# Energie-System ⚡

## 🎯 Lernziel

* Arbeiten mit `while`-Schleifen
* Zufallszahlen verwenden
* Variablen verändern
* Abbruchbedingungen verstehen
* Runden mitzählen

---

## 📝 Angabe

* Der Spieler startet mit **20 Energie**.
* In jeder Runde wird zufällig entschieden, wie viel Energie verbraucht wird.
* Der Energieverbrauch soll zwischen **1 und 5** liegen.
* Nach jeder Runde wird ausgegeben:

  * wie viel Energie verbraucht wurde
  * wie viel Energie noch übrig ist

* Das Programm läuft so lange, bis der Spieler **keine Energie mehr hat**.
* Am Ende soll ausgegeben werden, **wie viele Runden der Spieler durchgehalten hat**.
* Die Energie soll am Ende **nicht negativ ausgegeben werden**.

---

## 💻 Ausgabe

```text
Energie-System
==============

Runde 1: Es wurden 4 Energie verbraucht. 16 Energie verbleibend.
Runde 2: Es wurden 2 Energie verbraucht. 14 Energie verbleibend.
Runde 3: Es wurden 5 Energie verbraucht. 9 Energie verbleibend.
Runde 4: Es wurden 3 Energie verbraucht. 6 Energie verbleibend.
Runde 5: Es wurden 5 Energie verbraucht. 1 Energie verbleibend.
Runde 6: Es wurden 4 Energie verbraucht. 0 Energie verbleibend.

Der Spieler hat insgesamt 6 Runden durchgehalten!
```

---

## 💡 Tipps

* Verwende eine `while`-Schleife, die so lange läuft, wie der Spieler noch Energie hat.

```python
while energie > 0:
    # Code
```

* Für Zufallszahlen kannst du `random` verwenden.

```python
import random

verbrauch = random.randint(1, 5)
```

* Ziehe den Verbrauch von der Energie ab.

```python
energie -= verbrauch
```

* Zähle jede Runde mit.

```python
runden += 1
```

* Damit die Energie nicht negativ ausgegeben wird, kannst du sie nach dem Abziehen prüfen.

```python
if energie < 0:
    energie = 0
```
