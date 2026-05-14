# Leben-System-01

## Lernziel:

- Foreach-Schleifen  
- Berechnungen  
- Arbeiten mit 2D Arrays  

## Aufgabe:

Ein Spieler hat Leben in mehreren Levels:

```csharp
int[,] leben = new int[level, rounds]
```

Programmieren Sie ein Programm, das:

- Die Anzahl der Level und Rounds abfragt
- Alle Leben eingibt
- Die Startleben, Heilung und Schaden pro Level ausgibt.  
- das **Endleben** berechnet  

## Ausgabe:

```
Leben-System-01
===============

Wie viele Level gibt es: 2
Wie viele Runden gibt es: 4

Level 1
Runde 1: 5
Runde 2: 3
Runde 3: 10
Runde 4: 4

Level 2
Runde 1: 7
Runde 2: 5
Runde 3: 10
Runde 4: 8

--------

Level 1
Startleben: 5
Heilung: 7
Schaden: 8

Level 2
Startleben: 7
Heilung: 5
Schaden: 4

Endleben: 8
```

## Tipp:

- Verwenden Sie eine `foreach`-Schleife jeweils für die Eingabe und Ausgabe