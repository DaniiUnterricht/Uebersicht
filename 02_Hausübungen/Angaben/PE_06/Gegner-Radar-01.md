# Gegner-Radar-01

## Lernziel:

- Foreach-Schleifen  
- Bedingungen (`if`)  
- Zählen von Werten  

## Aufgabe:

Ein Spielfeld enthält eine Anzahl von Gegner:

- `0` = kein Gegner  
- `X` = X Gegner  

```csharp
int[,] feld =
{
    { 1, 0, 2 },
    { 0, 3, 0 }
};
```

Programmieren Sie ein Programm, das:

- Das Feld mit Random Gegner füllt
- zählt, wie viele **Gegner** im Feld vorhanden sind  

## Ausgabe:

```
Gegner-Radar-01
===============

Feld
1 0 2
0 3 0

Gegner gesamt: 6
```

## Tipp:

- Verwenden Sie `Random` für die Befüllung  
- Verwenden Sie eine Zählvariable  