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

# Übung 1 – Quest-System für ein Spiel

Erstelle ein kleines Quest-System für ein Rollenspiel.

Dafür werden drei Klassen benötigt:

* `Spieler`
* `Quest`
* `Belohnung`

---

## Klasse `Belohnung`

Die Klasse soll folgende Properties besitzen:

```csharp
public int Erfahrungspunkte { get; private set; }
public int Gold { get; private set; }
public string Gegenstand { get; private set; }
```

Alle Werte sollen über einen Konstruktor gesetzt werden.

Dabei gelten folgende Regeln:

* Erfahrungspunkte dürfen nicht negativ sein.
* Gold darf nicht negativ sein.
* Der Gegenstand darf nicht leer sein.

Erstelle außerdem folgende Methode:

```csharp
public void ZeigeInfo()
```

Beispielausgabe:

```text
Belohnung:
250 Erfahrungspunkte
100 Gold
Gegenstand: Eisenschwert
```

---

## Klasse `Quest`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Titel { get; private set; }
public string Beschreibung { get; private set; }
public int BenoetigteFortschritte { get; private set; }
public int AktuellerFortschritt { get; private set; }
public bool IstAbgeschlossen { get; private set; }
public Belohnung Belohnung { get; private set; }
```

Beim Erstellen einer Quest sollen folgende Werte gesetzt werden:

* Titel
* Beschreibung
* benötigte Fortschritte
* Belohnung

`AktuellerFortschritt` soll am Anfang `0` sein.

`IstAbgeschlossen` soll am Anfang `false` sein.

---

## Methoden der Klasse `Quest`

### `FortschrittHinzufuegen`

```csharp
public void FortschrittHinzufuegen(int fortschritt)
```

Die Methode soll den Fortschritt der Quest erhöhen.

Dabei gelten folgende Regeln:

* Der Wert muss größer als `0` sein.
* Eine abgeschlossene Quest darf nicht weiter verändert werden.
* Der Fortschritt darf nicht größer als der benötigte Fortschritt werden.
* Sobald der benötigte Fortschritt erreicht wurde, soll die Quest abgeschlossen werden.

Beispiel:

```text
Quest: Besiege 5 Schleime
Fortschritt: 3 von 5
```

Nach dem letzten Fortschritt:

```text
Quest abgeschlossen: Besiege 5 Schleime
```

### `ZeigeInfo`

```csharp
public void ZeigeInfo()
```

Die Methode soll alle Informationen zur Quest ausgeben.

Beispiel:

```text
Quest: Besiege die Schleime
Beschreibung: Besiege 5 Schleime im Wald.
Fortschritt: 3 von 5
Status: Offen
```

---

## Klasse `Spieler`

Die Klasse soll folgende Properties besitzen:

```csharp
public string Name { get; private set; }
public int Level { get; private set; }
public int Erfahrungspunkte { get; private set; }
public int Gold { get; private set; }
public List<string> Gegenstaende { get; private set; }
public List<Quest> Quests { get; private set; }
```

Beim Erstellen eines Spielers gilt:

* Level beginnt bei `1`.
* Erfahrungspunkte beginnen bei `0`.
* Gold beginnt bei `0`.
* Die Listen werden leer erstellt.

---

## Methoden der Klasse `Spieler`

### `QuestAnnehmen`

```csharp
public bool QuestAnnehmen(Quest quest)
```

Die Quest darf nur angenommen werden, wenn noch keine Quest mit demselben Titel vorhanden ist.

Die Methode soll:

* die Quest hinzufügen,
* eine Meldung ausgeben,
* `true` bei Erfolg zurückgeben,
* `false` zurückgeben, wenn die Quest bereits vorhanden ist.

### `QuestFortschrittHinzufuegen`

```csharp
public void QuestFortschrittHinzufuegen(string questTitel, int fortschritt)
```

Die Methode soll:

1. die Quest anhand ihres Titels suchen,
2. den Fortschritt der Quest erhöhen,
3. überprüfen, ob die Quest dadurch abgeschlossen wurde,
4. bei einem neuen Abschluss die Belohnung an den Spieler vergeben.

Die Belohnung darf nur einmal vergeben werden.

### `BelohnungErhalten`

```csharp
private void BelohnungErhalten(Belohnung belohnung)
```

Die Methode soll:

* Erfahrungspunkte hinzufügen,
* Gold hinzufügen,
* den Gegenstand zur Liste hinzufügen.

Die Methode soll `private` sein, da Belohnungen nicht beliebig von außen vergeben werden dürfen.

### `LevelPruefen`

```csharp
private void LevelPruefen()
```

Für jeweils `500` gesammelte Erfahrungspunkte soll der Spieler ein Level aufsteigen.

Beispiel:

```text
Danii ist jetzt Level 2.
```

### `ZeigeSpielerInfo`

```csharp
public void ZeigeSpielerInfo()
```

Die Methode soll ausgeben:

* Name
* Level
* Erfahrungspunkte
* Gold
* alle erhaltenen Gegenstände
* alle angenommenen Quests

---

## Programmablauf

1. Erstelle mindestens drei verschiedene Belohnungen.
2. Erstelle mindestens drei verschiedene Quests.
3. Erstelle einen Spieler.
4. Lasse den Spieler alle Quests annehmen.
5. Versuche, eine Quest doppelt anzunehmen.
6. Erhöhe den Fortschritt verschiedener Quests.
7. Schließe mindestens zwei Quests ab.
8. Versuche, bei einer bereits abgeschlossenen Quest weiteren Fortschritt hinzuzufügen.
9. Gib die Spielerdaten aus.
10. Gib alle Quests mit ihrem aktuellen Status aus.