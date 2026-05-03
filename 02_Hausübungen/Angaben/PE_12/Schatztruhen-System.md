# Schatztruhen-System 🎮

## 🎯 Lernziel

* Arbeiten mit `for`-Schleifen
* Eingaben mehrfach wiederholen
* Werte aufsummieren
* Eingabevalidierung mit `while`
* Rechnen mit Variablen

---

## 📝 Angabe

* Der Spieler gibt an, **wie viele Schatztruhen** geöffnet werden sollen.
* Für jede Schatztruhe wird abgefragt:

  * der **Name der Truhe**
  * der **Goldwert der Truhe**

* Das Programm berechnet den **gesamten Goldwert aller Truhen**.
* Falsche Eingaben sollen wiederholt werden:

  * keine Zahl → Fehlermeldung
  * negative Zahl oder `0` → Fehlermeldung

---

## 💻 Ausgabe

```text
Schatztruhen-System
===================

Wie viele Schatztruhen sollen geöffnet werden: 3

Name von Truhe 1: Alte Holzkiste
Goldwert von Alte Holzkiste: 15

Name von Truhe 2: Silbertruhe
Goldwert von Silbertruhe: 40

Name von Truhe 3: Goldtruhe
Goldwert von Goldtruhe: 100

Der Gesamtwert aller Schatztruhen beträgt: 155 Gold
```

```text
Schatztruhen-System
===================

Wie viele Schatztruhen sollen geöffnet werden: a
> Error: Ungültige Eingabe!
Wie viele Schatztruhen sollen geöffnet werden: 2

Name von Truhe 1: Silbertruhe
Goldwert von Silbertruhe: -20
> Error: Die Zahl muss größer als 0 sein.
Goldwert von Silbertruhe: 20

Name von Truhe 2: Goldtruhe
Goldwert von Goldtruhe: 80

Der Gesamtwert aller Schatztruhen beträgt: 100 Gold
```

---

## 💡 Tipps

* Verwende eine `for`-Schleife, weil vorher bekannt ist, wie viele Truhen abgefragt werden sollen.

```python
for i in range(anzahl):
    print(i)
```

* Damit die Ausgabe bei Truhe 1 startet, kannst du `i + 1` verwenden.

```python
name = input("Name von Truhe " + str(i + 1) + ": ")
```

* Verwende eine Variable für den Gesamtwert.

```python
gesamtwert = 0
```

* Addiere nach jeder Truhe den Goldwert dazu.

```python
gesamtwert += goldwert
```

* Für ungültige Zahlen kannst du `try` und `except` verwenden.

```python
try:
    goldwert = int(input("Goldwert: "))
except:
    print("> Error: Ungültige Eingabe!")
```
