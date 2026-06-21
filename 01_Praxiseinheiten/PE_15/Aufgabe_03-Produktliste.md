# Produktliste

## Aufgabenstellung

Erstelle ein C#-Programm zur Verwaltung einfacher Produkte.

Die Klasse `Produkt` soll folgende Eigenschaften besitzen:

- `Name`
- `Preis`
- `Anzahl`

## Konstruktor

Die Werte sollen über einen Konstruktor gesetzt werden.

## Methode

Erstelle eine Methode `BerechneGesamtpreis()`.

Diese Methode soll den Gesamtpreis eines Produkts zurückgeben.

```text
Gesamtpreis = Preis * Anzahl
```

## Anforderungen

- Erstelle mindestens 3 Produkte.
- Speichere die Produkte in einer Liste.
- Gib alle Produkte aus.
- Gib pro Produkt den Gesamtpreis aus.

## Beispielausgabe

```text
Maus: 2 Stück x 19,99 € = 39,98 €
Tastatur: 1 Stück x 49,99 € = 49,99 €
Monitor: 2 Stück x 149,99 € = 299,98 €
```

## Zusatzaufgabe

Berechne den Gesamtwert aller Produkte zusammen.

### Beispielausgabe Zusatz

```text
Gesamtwert aller Produkte: 389,95 €
```

## Hinweise

- Der Preis soll als `double` gespeichert werden.
- Die Anzahl soll als `int` gespeichert werden.
- Die Methode `BerechneGesamtpreis()` soll einen `double` zurückgeben.
