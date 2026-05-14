# Bankautomat-01

## Lernziel:

- Kombination von Switch und IF

- Sicherheitsprüfung

- Vergleichsoperatoren

- Logisches Denken

## Aufgabe:

Programmieren Sie einen Bankautomaten.

Der Benutzer wählt einen Betrag:
```
1 - 20 €
2 - 50 €
3 - 100 €
4 - 200 €
```
Das Konto besitzt folgenden Startwert:
```csharp
double kontostand = 120.00;
```

Das Programm soll prüfen:

- Ist genügend Geld vorhanden?

- Wenn ja → Auszahlung durchführen

- Wenn nein → Fehlermeldung anzeigen

Wenn mehr als 100 € abgehoben werden,
soll zusätzlich eine Sicherheitsmeldung erscheinen.

## Ausgabe:

```
Bankautomat
===========

1 - 20 €
2 - 50 €
3 - 100 €
4 - 200 €

Wählen Sie einen Betrag (1-4): 2

Gewählter Betrag: 50 €
Auszahlung erfolgreich.
Neuer Kontostand: 70.00 €
```

```
Bankautomat
===========

1 - 20 €
2 - 50 €
3 - 100 €
4 - 200 €

Wählen Sie einen Betrag (1-4): 4

Gewählter Betrag: 200 €
Nicht genügend Guthaben!
```

## Tipp:

- Verwenden Sie Switch zur Betragsauswahl.

- Verwenden Sie IF zur Kontostandprüfung.

- Reduzieren Sie den Kontostand nur bei erfolgreicher Auszahlung.

- Formatieren Sie die Ausgabe auf 2 Nachkommastellen.