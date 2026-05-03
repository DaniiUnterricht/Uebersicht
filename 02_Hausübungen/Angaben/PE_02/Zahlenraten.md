# Zahlenraten

## Lernziel:
- Random Zahlen
- IF Statements

## Aufgabe

- Programmieren Sie ein kleines Spiel, hierbei generiert der Computer eine Random Zahl zwischen 1 und 100, der User gibt dann eine Zahl ein und es wird überprüft ob diese zu Hoch, zu niedrig oder richtig ist.

## Ausgabe:

```
Zahlenraten
===========

Bitte geben Sie eine Zahl ein ( 1- 100 ): 69

Zu hoch! - Die Zahl des Computer war 49.
```

## Tipp
```csharp
Random random = new Random();

int computer = random.Next(1, 100);
```
Hier wird jetzt eine Random Zahl zwischen 1 und 100 in der Variable computer gespeichert.