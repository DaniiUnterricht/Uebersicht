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

# Übung 2 – Bibliotheksverwaltung

Erstelle ein Programm zur Verwaltung einer Bibliothek.

Dafür werden drei Klassen benötigt:

* `Buch`
* `Leser`
* `Bibliothek`

---

## Klasse `Buch`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Titel { get; private set; }
public string Autor { get; private set; }
public string Kategorie { get; private set; }
public bool IstAusgeliehen { get; private set; }
public string? AusgeliehenVon { get; private set; }
```

Beim Erstellen eines Buches gilt:

* `IstAusgeliehen` ist am Anfang `false`.
* `AusgeliehenVon` ist am Anfang `null`.

---

## Methoden der Klasse `Buch`

### `Ausleihen`

```csharp
public bool Ausleihen(string leserName)
```

Ein Buch darf nur ausgeliehen werden, wenn es aktuell verfügbar ist.

Die Methode soll:

* `IstAusgeliehen` auf `true` setzen,
* den Namen des Lesers speichern,
* `true` zurückgeben.

Ist das Buch bereits ausgeliehen, soll `false` zurückgegeben werden.

### `Zurueckgeben`

```csharp
public bool Zurueckgeben(string leserName)
```

Ein Buch darf nur von dem Leser zurückgegeben werden, der es ausgeliehen hat.

Bei erfolgreicher Rückgabe soll:

* `IstAusgeliehen` auf `false` gesetzt werden,
* `AusgeliehenVon` auf `null` gesetzt werden,
* `true` zurückgegeben werden.

### `ZeigeInfo`

```csharp
public void ZeigeInfo()
```

Beispielausgabe für ein verfügbares Buch:

```text
Der Hobbit von J. R. R. Tolkien
Kategorie: Fantasy
Status: Verfügbar
```

Beispielausgabe für ein ausgeliehenes Buch:

```text
Der Hobbit von J. R. R. Tolkien
Kategorie: Fantasy
Status: Ausgeliehen von Anna
```

---

## Klasse `Leser`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Name { get; private set; }
public int MaximaleAusleihen { get; private set; }
public List<Buch> AusgelieheneBuecher { get; private set; }
```

Die Liste soll im Konstruktor leer erstellt werden.

---

## Methoden der Klasse `Leser`

### `BuchAusleihen`

```csharp
public bool BuchAusleihen(Buch buch)
```

Ein Leser darf ein Buch nur ausleihen, wenn:

* das Buch verfügbar ist,
* das persönliche Ausleihlimit noch nicht erreicht wurde.

Die Methode soll die Methode `Ausleihen` des Buches verwenden.

### `BuchZurueckgeben`

```csharp
public bool BuchZurueckgeben(Buch buch)
```

Die Methode soll:

* überprüfen, ob das Buch in der Liste des Lesers vorhanden ist,
* die Methode `Zurueckgeben` des Buches aufrufen,
* das Buch aus der Liste entfernen.

### `ZeigeAusgelieheneBuecher`

```csharp
public void ZeigeAusgelieheneBuecher()
```

Die Methode soll alle aktuell ausgeliehenen Bücher des Lesers ausgeben.

---

## Klasse `Bibliothek`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Name { get; private set; }
public List<Buch> Buecher { get; private set; }
public List<Leser> Leser { get; private set; }
```

Beide Listen sollen im Konstruktor leer erstellt werden.

---

## Methoden der Klasse `Bibliothek`

### `BuchHinzufuegen`

```csharp
public bool BuchHinzufuegen(Buch buch)
```

Ein Buch darf nicht doppelt hinzugefügt werden.

Als doppelt gilt ein Buch, wenn Titel und Autor identisch sind.

### `LeserRegistrieren`

```csharp
public bool LeserRegistrieren(Leser leser)
```

Ein Leser darf nicht doppelt registriert werden.

### `BuchSuchen`

```csharp
public Buch? BuchSuchen(string titel)
```

Die Methode soll ein Buch anhand des Titels suchen und zurückgeben.

Wird kein Buch gefunden, soll `null` zurückgegeben werden.

### `ZeigeVerfuegbareBuecher`

```csharp
public void ZeigeVerfuegbareBuecher()
```

### `ZeigeBuecherNachKategorie`

```csharp
public void ZeigeBuecherNachKategorie(string kategorie)
```

Die Methode soll nur Bücher einer bestimmten Kategorie ausgeben.

### `ZeigeAlleBuecher`

```csharp
public void ZeigeAlleBuecher()
```

Die Methode soll alle Bücher inklusive Ausleihstatus ausgeben.

---

## Programmablauf

1. Erstelle eine Bibliothek.
2. Erstelle mindestens sechs Bücher aus verschiedenen Kategorien.
3. Füge die Bücher zur Bibliothek hinzu.
4. Versuche, ein Buch doppelt hinzuzufügen.
5. Erstelle mindestens zwei Leser.
6. Registriere beide Leser.
7. Lasse beide Leser mehrere Bücher ausleihen.
8. Versuche, ein bereits ausgeliehenes Buch erneut auszuleihen.
9. Überschreite bei einem Leser das Ausleihlimit.
10. Gib alle ausgeliehenen Bücher eines Lesers aus.
11. Gib ein Buch zurück.
12. Versuche, ein Buch durch den falschen Leser zurückzugeben.
13. Gib alle verfügbaren Bücher aus.
14. Gib alle Bücher einer bestimmten Kategorie aus.