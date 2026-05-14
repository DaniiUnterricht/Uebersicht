# Ampel-01

## Lernziel:

- Switch mit String

- ToLower()

- Benutzerinteraktion

- Default-Zweig

## Aufgabe:

Programmieren Sie eine Ampel-Simulation.

Der Benutzer gibt eine Farbe ein:

- rot

- gelb

- grün

Je nach Eingabe soll folgendes ausgegeben werden:

- rot → Stopp!

- gelb → Achtung!

- grün → Fahren erlaubt!

Bei ungültiger Eingabe soll eine Fehlermeldung erscheinen.

Die Eingabe soll unabhängig von Groß- und Kleinschreibung funktionieren.

## Ausgabe:

```
Ampel
=====

Bitte geben Sie eine Ampelfarbe ein: Rot

Stopp!
```

```
Ampel
=====

Bitte geben Sie eine Ampelfarbe ein: blau

Ungültige Ampelfarbe!
```

## Tipp:

- Verwenden Sie string.ToLower(). Bsp.: stringVariable = stringVariable.ToLower();

- Nutzen Sie ein Switch-Statement.

- Vergessen Sie den default-Zweig nicht.