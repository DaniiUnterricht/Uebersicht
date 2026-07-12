# Übungen – Kapselung und Objekte miteinander verbinden

## Allgemeine Vorgaben

Achte bei allen Übungen auf folgende Punkte:

* Verwende passende Klassen.
* Initialisiere wichtige Werte über Konstruktoren.
* Werte sollen nicht unnötig von außen verändert werden können.
* Verwende bei geeigneten Properties `private set`.
* Veränderungen sollen über passende Methoden erfolgen.
* Überprüfe ungültige Eingaben.
* Gib die wichtigsten Informationen übersichtlich in der Konsole aus.
* Verwende `#region` und `#endregion`, um deine Klassen sinnvoll zu gliedern.

Eine mögliche Gliederung:

```csharp
#region Properties

#endregion

#region Konstruktor

#endregion

#region Methoden

#endregion
```

---

# Übung 4 – Bestellsystem für einen Onlineshop

Erstelle ein kleines Bestellsystem.

Dafür werden drei Klassen benötigt:

* `Produkt`
* `Bestellposition`
* `Bestellung`

---

## Klasse `Produkt`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Name { get; private set; }
public decimal Preis { get; private set; }
public int Lagerbestand { get; private set; }
```

Dabei gelten folgende Regeln:

* Der Name darf nicht leer sein.
* Der Preis darf nicht negativ sein.
* Der Lagerbestand darf nicht negativ sein.

---

## Methoden der Klasse `Produkt`

### `IstVerfuegbar`

```csharp
public bool IstVerfuegbar(int menge)
```

Die Methode soll überprüfen, ob die gewünschte Menge auf Lager ist.

### `LagerbestandReduzieren`

```csharp
public bool LagerbestandReduzieren(int menge)
```

Der Lagerbestand darf nur reduziert werden, wenn:

* die Menge größer als `0` ist,
* genügend Produkte vorhanden sind.

### `Nachbestellen`

```csharp
public void Nachbestellen(int menge)
```

Die Menge muss größer als `0` sein.

### `PreisAendern`

```csharp
public void PreisAendern(decimal neuerPreis)
```

Der neue Preis darf nicht negativ sein.

Der Preis darf nicht direkt von außen verändert werden.

### `ZeigeInfo`

```csharp
public void ZeigeInfo()
```

Beispielausgabe:

```text
Tastatur – 59,90 € – Lagerbestand: 12 Stück
```

---

## Klasse `Bestellposition`

Eine Bestellposition verbindet ein Produkt mit einer bestellten Menge.

Die Klasse soll folgende Properties besitzen:

```csharp
public Produkt Produkt { get; private set; }
public int Menge { get; private set; }
```

---

## Methoden der Klasse `Bestellposition`

### `BerechnePreis`

```csharp
public decimal BerechnePreis()
```

Die Methode soll berechnen:

```text
Preis des Produktes × Menge
```

### `MengeErhoehen`

```csharp
public bool MengeErhoehen(int menge)
```

Die Methode soll die bestehende Menge erhöhen.

Die Erhöhung darf nur stattfinden, wenn:

* die Menge größer als `0` ist,
* insgesamt genügend Produkte auf Lager sind.

Die Property `Menge` darf weiterhin nur innerhalb der Klasse verändert werden.

---

## Klasse `Bestellung`

Die Klasse soll folgende Properties besitzen:

```csharp
public int Bestellnummer { get; private set; }
public string Kundenname { get; private set; }
public List<Bestellposition> Positionen { get; private set; }
public bool IstAbgeschlossen { get; private set; }
```

Die Liste soll im Konstruktor erstellt werden.

`IstAbgeschlossen` soll am Anfang `false` sein.

---

## Methoden der Klasse `Bestellung`

### `ProduktHinzufuegen`

```csharp
public bool ProduktHinzufuegen(Produkt produkt, int menge)
```

Das Produkt darf nur hinzugefügt werden, wenn:

* die Menge größer als `0` ist,
* genügend Produkte auf Lager sind,
* die Bestellung noch nicht abgeschlossen wurde.

Ist das Produkt noch nicht in der Bestellung vorhanden, soll eine neue Bestellposition erstellt werden.

Ist das Produkt bereits vorhanden, soll keine zweite Bestellposition erstellt werden. Stattdessen soll die Methode `MengeErhoehen` verwendet werden.

Der Lagerbestand soll zu diesem Zeitpunkt noch nicht reduziert werden.

### `ProduktEntfernen`

```csharp
public bool ProduktEntfernen(string produktName)
```

Ein Produkt darf nur entfernt werden, wenn:

* es in der Bestellung vorhanden ist,
* die Bestellung noch nicht abgeschlossen wurde.

### `BerechneGesamtpreis`

```csharp
public decimal BerechneGesamtpreis()
```

Die Methode soll die Preise aller Bestellpositionen zusammenrechnen.

### `BestellungAbschliessen`

```csharp
public bool BestellungAbschliessen()
```

Beim Abschließen der Bestellung soll:

1. erneut geprüft werden, ob alle Produkte verfügbar sind,
2. bei jedem Produkt der Lagerbestand reduziert werden,
3. `IstAbgeschlossen` auf `true` gesetzt werden.

Eine abgeschlossene Bestellung darf nicht erneut abgeschlossen werden.

Wird bei einem Produkt festgestellt, dass nicht mehr genügend Bestand vorhanden ist, darf die gesamte Bestellung nicht abgeschlossen werden.

### `ZeigeBestellung`

```csharp
public void ZeigeBestellung()
```

Beispielausgabe:

```text
Bestellung Nr. 1001
Kunde: Marie

2 × Tastatur zu je 59,90 € = 119,80 €
1 × Maus zu je 29,90 € = 29,90 €
3 × USB-Kabel zu je 8,50 € = 25,50 €

Gesamtpreis: 175,20 €
Status: Offen
```

---

## Programmablauf

1. Erstelle mindestens fünf Produkte.
2. Erstelle eine neue Bestellung.
3. Füge mindestens drei Produkte mit unterschiedlichen Mengen hinzu.
4. Füge eines dieser Produkte ein zweites Mal hinzu.
5. Überprüfe, ob dabei die Menge der bestehenden Position erhöht wurde.
6. Versuche, mehr Produkte hinzuzufügen, als auf Lager sind.
7. Entferne ein Produkt aus der Bestellung.
8. Versuche, ein nicht vorhandenes Produkt zu entfernen.
9. Gib die Bestellung und den Gesamtpreis aus.
10. Schließe die Bestellung ab.
11. Gib die neuen Lagerbestände aus.
12. Versuche, nachträglich ein weiteres Produkt hinzuzufügen.
13. Versuche, nachträglich ein Produkt zu entfernen.
14. Versuche, die Bestellung ein zweites Mal abzuschließen.
15. Bestelle bei mindestens einem Produkt neuen Lagerbestand nach.
16. Ändere den Preis eines Produktes über die vorgesehene Methode.
