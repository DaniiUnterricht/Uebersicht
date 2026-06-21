# Spieler-System

## Aufgabenstellung

Erstelle ein kleines Spieler-System mit Objektorientierung.

Die Klasse `Spieler` soll folgende Eigenschaften besitzen:

- `Name`
- `Punkte`

Zusätzlich soll die Klasse einen Konstruktor besitzen.

## Konstruktor

Der Konstruktor soll Name und Punkte übernehmen.

```csharp
public Spieler(string name, int punkte)
{
    Name = name;
    Punkte = punkte;
}
```

## Methode

Die Klasse soll eine Methode `ZeigeInfo()` besitzen.

Diese Methode soll den Namen und die Punkte des Spielers ausgeben.

## Anforderungen

Erstelle mindestens 3 Spieler-Objekte.

Speichere diese Spieler in einer Liste.

```csharp
List<Spieler> spielerListe = new List<Spieler>();
```

Gib danach alle Spieler mit einer `foreach`-Schleife aus.

## Beispielausgabe

```text
Lena hat 120 Punkte.
Max hat 80 Punkte.
Anna hat 150 Punkte.
```

## Zusatzaufgabe

Erstelle eine Methode `HatGewonnen()`.

Diese Methode soll `true` zurückgeben, wenn der Spieler mindestens 100 Punkte hat.

Danach soll zusätzlich ausgegeben werden:

```text
Lena hat gewonnen.
Max hat nicht gewonnen.
Anna hat gewonnen.
```

## Hinweise

- Für die Liste wird `using System.Collections.Generic;` benötigt.
- Die Methode `HatGewonnen()` hat den Rückgabetyp `bool`.
- Verwende `foreach`, um alle Spieler zu durchlaufen.
