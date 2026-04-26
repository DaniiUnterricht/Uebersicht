# Inventar-System 🎮

## 🎯 Lernziel

* Arbeiten mit `for`-Schleifen
* Eingaben mehrfach wiederholen
* Werte aufsummieren
* Einfache Inventar-Logik verstehen

---

## 📝 Angabe

* Der Spieler gibt an, **wie viele Items** gesammelt wurden.
* Für jedes Item wird abgefragt:

  * der **Name des Items**
  * der **Wert des Items in Gold**
* Das Programm berechnet den **Gesamtwert des Inventars**.
* Falsche Eingaben sollen wiederholt werden:

  * keine Zahl → Fehlermeldung
  * negative Zahl oder 0 → Fehlermeldung

---

## 💻 Ausgabe

```text
Inventar-System
===============

Wie viele Items wurden gesammelt: 3

Name von Item 1: Schwert
Wert von Schwert in Gold: 50

Name von Item 2: Schild
Wert von Schild in Gold: 35

Name von Item 3: Heiltrank
Wert von Heiltrank in Gold: 10

Der Gesamtwert des Inventars beträgt: 95 Gold
```

```text
Inventar-System
===============

Wie viele Items wurden gesammelt: a
> Error: Ungültige Eingabe!
Wie viele Items wurden gesammelt: 2

Name von Item 1: Schwert
Wert von Schwert in Gold: -20
> Error: Die Zahl muss größer als 0 sein.
Wert von Schwert in Gold: 20

Name von Item 2: Heiltrank
Wert von Heiltrank in Gold: 10

Der Gesamtwert des Inventars beträgt: 30 Gold
```

---

## 💡 Tipps

* Verwenden Sie eine `for`-Schleife, da vorher bekannt ist, **wie viele Items abgefragt werden sollen**.

```python
for i in range(anzahl):
    print(i)
```

---

* Damit die Ausgabe bei Item 1 startet, können Sie `i + 1` verwenden:

```python
for i in range(anzahl):
    name = input("Name von Item " + str(i + 1) + ": ")
```

---

* Verwenden Sie eine Variable für den Gesamtwert:

```python
gesamtwert = 0
```

---

* Addieren Sie nach jedem Item den Wert dazu:

```python
gesamtwert += wert
```

---

* Für ungültige Zahlen können Sie wieder `try` und `except` verwenden:

```python
try:
    wert = int(input("Wert in Gold: "))
except:
    print("> Error: Ungültige Eingabe!")
```

---

* Prüfen Sie zusätzlich, ob die Zahl größer als 0 ist:

```python
if wert <= 0:
    print("> Error: Die Zahl muss größer als 0 sein.")
```
