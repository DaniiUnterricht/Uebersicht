# Eingabe-Matrix-01

## Lernziel:

* Methoden mit Eingabe
* Jagged Arrays dynamisch befüllen
* Fehlervermeidung

## Aufgabe:

Ein Programm soll mehrere Zahlenreihen vom Benutzer einlesen.

Die Anzahl der Reihen ist vorgegeben (z. B. 3),
aber jede Reihe kann unterschiedlich viele Werte enthalten.

Programmieren Sie ein Programm, das:

* ein Jagged Array erstellt
* für jede Reihe den Benutzer fragt:

  * wie viele Werte eingegeben werden sollen
* anschließend die Werte einliest

---

👉 Erstellen Sie eine Methode:

* erhält einen Text als Parameter
* liest eine gültige Zahl ein (mit Prüfung)
* gibt diese zurück

---

Am Ende sollen alle Werte ausgegeben werden.

## Ausgabe:

```
Eingabe-Matrix-01
=================

Wie viele Werte für Reihe 1: 2
Wert eingeben: 5
Wert eingeben: 3

Wie viele Werte für Reihe 2: 1
Wert eingeben: 10

Wie viele Werte für Reihe 3: 3
Wert eingeben: 7
Wert eingeben: 8
Wert eingeben: 9

Daten:
5 3
10
7 8 9
```

## Tipp:

* Methode für Eingabe wiederverwenden
* `.Length` beachten
