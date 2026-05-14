# Schatzsuche-02

## Lernziel:

- Arrays
- For-Schleifen
- Zufallszahlen
- Vergleichsoperatoren
- Spiel-Logik

## Aufgabe:

Programmieren Sie eine **Schatzsuche im Dungeon**.

Im Dungeon gibt es **10 Räume**.

Zu Beginn sollen **3 zufällige Räume** ausgewählt werden, in denen sich Schätze befinden.

Speichern Sie diese **Schatzpositionen in einem Array**.

Der Spieler kann nun **einen Raum zwischen 1 und 10 wählen**.

Das Programm soll überprüfen:

- Wenn sich dort ein Schatz befindet →  
```
Schatz gefunden!
```

- Wenn sich dort kein Schatz befindet →  
```
Kein Schatz hier!
```

Das Spiel endet nach **einem Versuch**.

## Ausgabe:

```
Schatzsuche im Dungeon
======================

Wähle einen Raum (1-10): 6
Kein Schatz hier!
```

oder

```
Schatzsuche im Dungeon
======================

Wähle einen Raum (1-10): 3
Schatz gefunden!
```

## Tipp:

- Verwenden Sie ein **int-Array mit 3 Elementen**, um die Schatzräume zu speichern.
- Verwenden Sie **Random**, um die Räume zu erzeugen.
- Durchlaufen Sie das Array mit einer **for-Schleife**, um zu prüfen, ob der Spieler einen Schatz gefunden hat.