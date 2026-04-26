# Leben-System 🎮

## 🎯 Lernziel

* Arbeiten mit der `while`-Schleife
* Verwendung von Zufallszahlen
* Variablen verändern (Zustand speichern)
* Abbruchbedingungen verstehen

---

## 📝 Angabe

* Der Spieler startet mit **10 bis 20 Leben**.
* Ein Gegner greift in jeder Runde an und verursacht **0 bis 3 Schaden**.
* Nach jedem Angriff wird das verbleibende Leben ausgegeben.
* Das Programm läuft so lange, bis der Spieler **keine Leben mehr hat**.
* Am Ende soll ausgegeben werden, **wie viele Runden der Spieler überlebt hat**.

---

## 💻 Ausgabe

```
Leben-System
============

Der Gegner greift mit 3 Schaden an! 7 Leben verbleibend.
Der Gegner greift mit 2 Schaden an! 5 Leben verbleibend.
Der Gegner greift mit 0 Schaden an! 5 Leben verbleibend.
Der Gegner greift mit 3 Schaden an! 2 Leben verbleibend.
Der Gegner greift mit 1 Schaden an! 1 Leben verbleibend.
Der Gegner greift mit 3 Schaden an! 0 Leben verbleibend.

Der Spieler hat insgesamt 6 Runden überlebt!
```

---

## 💡 Tipps

* Verwenden Sie eine `while`-Schleife, die so lange läuft, **wie der Spieler noch Leben hat**.

* Sie benötigen eine Variable für:

  * die aktuellen Leben
  * die Anzahl der Runden

* Um eine Zufallszahl zu erzeugen, können Sie das Modul `random` verwenden:

```python
import random

schaden = random.randint(0, 3)
```

👉 Diese Funktion liefert eine zufällige Zahl **zwischen 0 und 3 (inklusive)**.

---

* Denken Sie daran, die Leben nach jedem Angriff zu reduzieren:

```python
leben -= schaden
```

---

* Vergessen Sie nicht, die Runden mitzuzählen:

```python
runden += 1
```

---

* Achten Sie darauf, dass die Leben **nicht negativ ausgegeben werden** (optional verbessern 😉).
