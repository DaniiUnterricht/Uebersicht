# Schatzsuche-03

## Lernziel:

- Zweidimensionale Arrays  
- Foreach-Schleifen  
- Zufallszahlen  
- Benutzereingaben  
- Logisches Denken  

## Aufgabe:

Ein Dungeon besteht aus **3 Zeilen und 3 Spalten**.

Jedes Feld wird zufällig befüllt:

- `0` = leer  
- `1` = Schatztruhe  

Programmieren Sie ein Programm, das:

- das Dungeon mit Zufallszahlen befüllt
- zählt, wie viele Schatztruhen vorhanden sind ( Minimum 1, Maximal 4 )

Anschließend soll der Benutzer:

- eine **Zeile**
- und eine **Spalte**

eingeben.

Das Programm soll prüfen, ob sich an dieser Position eine **Schatztruhe** befindet.

- Zum Schluss sollen alle Felder ausgegeben werden.

## Ausgabe:

```
Schatzsuche-03
==============

Schatztruhen: 4

Zeile wählen ( 1-3 ): 1
Spalte wählen (1-3 ): 2

Schatz gefunden!

Dungeon:
0 1 0
1 0 0
0 1 1
```

oder

```
Schatzsuche-03
==============

Schatztruhen: 1

Zeile wählen ( 1-3 ): 2
Spalte wählen (1-3 ): 3

Kein Schatz gefunden!

Dungeon:
0 0 0
0 0 0
0 1 0
```

## Tipp:

- Verwenden Sie `Random` für die Befüllung  
- Nutzen Sie `foreach` zum Zählen  
- Zugriff auf das Array mit `[zeile, spalte]`  