# Punkte-System 🎮

## 🎯 Lernziel

* Methoden verstehen und fertigstellen
* Arrays als Parameter verwenden
* Rückgabewerte verwenden
* `for`-Schleifen in Methoden einsetzen
* Summe, Durchschnitt und Maximum berechnen

---

## 📝 Angabe

Ergänze das vorgegebene C#-Projekt.

Das **Hauptprogramm ist bereits im Projekt vorhanden** und darf nicht verändert werden.

Deine Aufgabe ist es, die fehlenden Methoden fertig zu schreiben.

Folgende Methoden sollen ergänzt werden:

* `BerechneGesamtpunkte`
* `BerechneDurchschnitt`
* `FindeBestenSpielerIndex`
* `GibAuswertungAus`

---

## 🔧 Aufgabenbeschreibung

### `BerechneGesamtpunkte`

Diese Methode soll alle Punkte aus dem Punkte-Array zusammenrechnen.

Am Ende soll die Methode die **Gesamtpunkte** zurückgeben.

---

### `BerechneDurchschnitt`

Diese Methode soll den Durchschnitt der Punkte berechnen.

Dazu werden die Gesamtpunkte durch die Anzahl der Spieler dividiert.

Am Ende soll die Methode den **Durchschnitt** zurückgeben.

---

### `FindeBestenSpielerIndex`

Diese Methode soll herausfinden, welcher Spieler die meisten Punkte erreicht hat.

Die Methode soll nicht den Namen zurückgeben, sondern den **Index** des besten Spielers.

---

### `GibAuswertungAus`

Diese Methode soll die fertige Auswertung ausgeben.

Es sollen ausgegeben werden:

* alle Spieler mit ihren Punkten
* die Gesamtpunkte
* der Durchschnitt
* der beste Spieler mit Punkteanzahl

---

## 💻 Erwartete Ausgabe

```text
Punkte-System
=============

Auswertung
==========

Anna: 120 Punkte
Ben: 80 Punkte
Clara: 150 Punkte
Dani: 100 Punkte

Gesamtpunkte: 450
Durchschnitt: 112,5
Bester Spieler: Clara mit 150 Punkten
```

---

## 💡 Hinweise

### Gesamtpunkte berechnen

Du brauchst eine Variable für die Summe.

```csharp
int summe = 0;
```

Danach kannst du mit einer `for`-Schleife durch das Array gehen und alle Punkte addieren.

---

### Durchschnitt berechnen

Der Durchschnitt ergibt sich aus:

```csharp
gesamtpunkte / anzahl
```

Achte darauf, dass ein `double` zurückgegeben werden soll.

---

### Besten Spieler finden

Speichere zuerst den Index des ersten Spielers.

```csharp
int besterIndex = 0;
```

Vergleiche danach die Punkte der Spieler mit den Punkten des aktuell besten Spielers.

---

### Auswertung ausgeben

Verwende eine `for`-Schleife, um alle Namen und Punkte auszugeben.

```csharp
Console.WriteLine(namen[i] + ": " + punkte[i] + " Punkte");
```

---

## 🧠 Hinweis

* Das Hauptprogramm darf nicht verändert werden.
* Schreibe den Code nur in die vorgesehenen Methoden.
* Achte auf saubere Einrückung.
* Verwende sprechende Variablennamen.
* Teste, ob die Ausgabe zur erwarteten Ausgabe passt.

---

## ⭐ Zusatzaufgabe

Erweitere das Programm um eine weitere Methode:

```csharp
static int ZaehleSpielerUeberDurchschnitt(int[] punkte, double durchschnitt)
{
    // TODO
    return 0;
}
```

Diese Methode soll zählen, wie viele Spieler **mehr Punkte als der Durchschnitt** erreicht haben.
