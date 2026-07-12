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

# Übung 3 – Tierheimverwaltung

Erstelle ein Programm zur Verwaltung eines kleinen Tierheims.

Dafür werden zwei Klassen benötigt:

* `Tier`
* `Tierheim`

---

## Klasse `Tier`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Name { get; private set; }
public string Tierart { get; private set; }
public int Alter { get; private set; }
public bool IstVermittelt { get; private set; }
```

Beim Erstellen eines Tieres soll `IstVermittelt` automatisch auf `false` gesetzt werden.

Das Alter darf nicht negativ sein.

---

## Methoden der Klasse `Tier`

### `Geburtstag`

```csharp
public void Geburtstag()
```

Die Methode erhöht das Alter des Tieres um eins.

### `Vermitteln`

```csharp
public bool Vermitteln()
```

Ein Tier darf nur einmal vermittelt werden.

Die Methode soll:

* `IstVermittelt` auf `true` setzen,
* `true` zurückgeben, wenn das Tier erfolgreich vermittelt wurde,
* `false` zurückgeben, wenn es bereits vermittelt wurde.

### `ZeigeInfo`

```csharp
public void ZeigeInfo()
```

Beispielausgabe:

```text
Bello – Hund – 4 Jahre – Noch nicht vermittelt
```

oder:

```text
Bello – Hund – 4 Jahre – Bereits vermittelt
```

---

## Klasse `Tierheim`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Name { get; private set; }
public int MaximaleAnzahl { get; private set; }
public List<Tier> Tiere { get; private set; }
```

Die Liste soll im Konstruktor leer erstellt werden.

---

## Methoden der Klasse `Tierheim`

### `TierAufnehmen`

```csharp
public bool TierAufnehmen(Tier tier)
```

Ein Tier darf nur aufgenommen werden, wenn:

* das Tierheim noch nicht voll ist,
* noch kein Tier mit demselben Namen und derselben Tierart vorhanden ist.

### `TierVermitteln`

```csharp
public bool TierVermitteln(string tierName)
```

Die Methode soll:

1. das Tier anhand seines Namens suchen,
2. überprüfen, ob es bereits vermittelt wurde,
3. die Methode `Vermitteln` des Tieres aufrufen.

Das Tier soll nach der Vermittlung weiterhin in der Liste bleiben.

### `ZeigeAlleTiere`

```csharp
public void ZeigeAlleTiere()
```

### `ZeigeNichtVermittelteTiere`

```csharp
public void ZeigeNichtVermittelteTiere()
```

### `AnzahlNichtVermittelterTiere`

```csharp
public int AnzahlNichtVermittelterTiere()
```

### `ZeigeTiereNachTierart`

```csharp
public void ZeigeTiereNachTierart(string tierart)
```

Damit sollen beispielsweise nur Hunde oder nur Katzen ausgegeben werden.

### `FindeAeltestesTier`

```csharp
public Tier? FindeAeltestesTier()
```

Die Methode soll das älteste Tier des Tierheims zurückgeben.

Ist kein Tier vorhanden, soll `null` zurückgegeben werden.

---

## Programmablauf

1. Erstelle ein Tierheim mit begrenzter Kapazität.
2. Erstelle mindestens sechs Tiere.
3. Nimm die Tiere im Tierheim auf.
4. Versuche, ein Tier doppelt aufzunehmen.
5. Versuche, die maximale Kapazität zu überschreiten.
6. Vermittle mindestens zwei Tiere.
7. Versuche, ein Tier ein zweites Mal zu vermitteln.
8. Gib alle Tiere aus.
9. Gib nur die noch nicht vermittelten Tiere aus.
10. Gib die Anzahl der noch nicht vermittelten Tiere aus.
11. Gib nur Tiere einer bestimmten Tierart aus.
12. Ermittle das älteste Tier und gib dessen Informationen aus.