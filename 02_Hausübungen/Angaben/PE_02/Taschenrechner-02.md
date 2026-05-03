# Taschenrechner-02

## Lernziel:
- Ausgabe
- Variablen
- Gleitkommazahl
- Rechnen
- Verschachtelte IF Statements

## Aufgabe:

- Programmieren Sie einen simplen Taschenrechner, der 2 Zahlen entweder Addiert, Subtrahiert, Multipliziert oder Dividiert.

## Ausgabe:

```
Bitte geben Sie die erste Zahl ein: 10
Bitte geben Sie die zweite Zahl ein: 4
Bitte geben Sie den Operator ( + , - , * , / ) an: *

10 * 4 = 40.00
```

```
Bitte geben Sie die erste Zahl ein: 10
Bitte geben Sie die zweite Zahl ein: 0
Bitte geben Sie den Operator ( + , - , * , / ) an: /

Es kann nicht durch 0 dividiert werden.
```

## Tipp:
- Es wird eine Variable mit Gleitkommazahl benötigt.
- Die Ausgabe kann mit Console.WriteLine($"{zahl:F2}"); auf 2 Nachkommazahlen gerundet werden -> Bei F4 wären es Bsp. 4 Nachkommazahlen.
- Wenn Sie bei int Variablen 10 / 0 Rechnen stürzt das Programm ab, durch IF muss man zuvor Überprüfen ob es Rechnerisch möglich ist.