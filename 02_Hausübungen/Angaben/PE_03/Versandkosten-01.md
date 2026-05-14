# Versandkosten-01

## Lernziel:

- Switch Statement

- IF-Abfrage

- Variablen

- Rechnen mit Gleitkommazahlen

- Benutzerinteraktion

## Aufgabe:

Programmieren Sie einen Versandkosten-Rechner.

Der Benutzer wählt ein Land:
```
1 - Österreich
2 - Deutschland
3 - Schweiz
4 - Italien
```

Anschließend soll abgefragt werden, ob Expressversand gewünscht ist (j/n).

Je nach Land sollen folgende Versandkosten gelten:

- Österreich → 4,90 €

- Deutschland → 6,90 €

- Schweiz → 9,90 €

- Italien → 7,90 €

Expressversand kostet zusätzlich 3,00 €.

Bei ungültiger Eingabe soll eine Fehlermeldung ausgegeben werden.

## Ausgabe:

```
Versandkosten
=============

1 - Österreich
2 - Deutschland
3 - Schweiz
4 - Italien

Bitte wählen Sie ein Land (1-4): 2
Expressversand? (j/n): j

Versandkosten: 9.90 €
```

## Tipp:

- Verwenden Sie ein switch-Statement zur Auswahl des Landes.

- Verwenden Sie IF für die Express-Abfrage.

- Speichern Sie die Versandkosten in einer double-Variable.

- Formatieren Sie die Ausgabe auf 2 Nachkommastellen.