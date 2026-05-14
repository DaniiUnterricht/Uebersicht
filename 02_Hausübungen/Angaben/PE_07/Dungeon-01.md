# Dungeon-01

## Lernziel:

* Jagged Arrays
* Methoden mit Parameter & Rückgabewert
* Schleifen
* Random

## Aufgabe:

Ein Dungeon besteht aus **mehreren Reihen**, wobei jede Reihe unterschiedlich viele Felder haben kann.

Die Werte sind:

* `0` = leer
* `1` = Monster

Programmieren Sie ein Programm, das:

* ein **Jagged Array** mit Random Reihen ( 1 - 10 ), Felder ( 3 - 10 ) und Monster ( 1 - Max Felder ) erstellt
* für jede Reihe die Anzahl der Monster berechnet

---

👉 Erstellen Sie dazu zwei Methoden:

1.
    * keine Parameter
    * erstellt einen Feld Array ( 3 - 10 )
    * befüllt diesen Array mit 1 - Max Felder Monster
    * Gibt diesen Array zurück <br><br>

2.
    * erhält **eine Reihe (Array)** als Parameter
    * zählt die Monster (`1`)
    * gibt die Anzahl zurück

    

---

Anschließend soll:

* für jede Reihe ausgegeben werden:

  * „Reihe X enthält Y Monster“

## Ausgabe:

```
Dungeon-01
==========

Reihe 1 enthält 2 Monster
Reihe 2 enthält 1 Monster
Reihe 3 enthält 3 Monster
```

## Tipp
Erstellen Sie ein Jagged Array mit [random][]

Erstellen Sie danach eine forschleife die diesen Array durchgeht ( jaggedArray.Length )

In dieser forschleife kommt die erste Methode rein: jaggedArray[i] = Methode1() <-- Damit ist der Jagged Array befüllt.

Danach erstellen Sie wieder die selbe forschleife.

In dieser geben Sie die einzelnen Reihen aus, dementsprechend verwenden Sie für die Berechnung die 2. Methode: Methode2(jaggedArray[i])
