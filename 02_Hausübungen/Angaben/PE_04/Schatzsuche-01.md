# Schatzsuche-01

## Lernziel:

- While-Schleife
- Variablen
- Benutzerinteraktion
- Zufallszahlen
- Spiel-Logik

## Aufgabe:

Programmieren Sie eine kleine **Schatzsuche im Dungeon**.

Zu Beginn wird eine **zufällige Zahl zwischen 1 und 10** erzeugt.  
Diese Zahl stellt die **Position des Schatzes** im Dungeon dar.

Der Spieler soll nun versuchen, den Schatz zu finden, indem er eine **Zahl zwischen 1 und 10** eingibt.

Nach jeder Eingabe soll das Programm prüfen:

- Wenn die Zahl **falsch** ist →  
  ```
  Kein Schatz hier!
  ```

- Wenn die Zahl **richtig** ist →  
  ```
  Schatz gefunden!
  ```

Das Spiel soll so lange weiterlaufen, bis der Spieler den **richtigen Raum** gefunden hat.

## Ausgabe:

```
Schatzsuche im Dungeon
======================

Wähle einen Raum (1-10): 3
Kein Schatz hier!

Wähle einen Raum (1-10): 7
Kein Schatz hier!

Wähle einen Raum (1-10): 5
Schatz gefunden!
```

## Tipp:

- Verwenden Sie eine **while-Schleife**, solange der Schatz noch nicht gefunden wurde.
- Verwenden Sie `Random`, um die Schatzposition zu erzeugen. ( Finden Sie unter PE-02-22-02-2026 Zahlenraten )