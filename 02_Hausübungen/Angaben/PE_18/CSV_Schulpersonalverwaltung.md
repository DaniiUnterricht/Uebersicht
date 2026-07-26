# PE18 – CSV-Schulpersonalverwaltung

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

## Inhaltsverzeichnis

1. [Ausgangssituation](#1-ausgangssituation)
2. [Vorhandene CSV-Datei](#2-vorhandene-csv-datei)
3. [Projektstruktur](#3-projektstruktur)
4. [Programmablauf](#4-programmablauf)
5. [Aufgaben](#5-aufgaben)
6. [Anforderungen](#6-anforderungen)
7. [Erwartete Ausgabe](#7-erwartete-ausgabe)

---

# 1. Ausgangssituation

Eine Schule verwaltet ihre Mitarbeiter in einer CSV-Datei.

In der Datei befinden sich unterschiedliche Rollen, zum Beispiel:

- Lehrer und Lehrerinnen
- Direktor oder Direktorin
- Reinigungskräfte
- Schulwart
- Sekretariat

Das Programm soll die vorhandenen Daten importieren, anzeigen, verändern und anschließend wieder exportieren.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

# 2. Vorhandene CSV-Datei

Die Datei befindet sich unter:

```text
Data/mitarbeiter.csv
```

Aufbau der Datei:

```csv
Id;Vorname;Nachname;Rolle;Abteilung;Wochenstunden
1;Anna;Huber;Lehrerin;Informatik;22
2;Markus;Leitner;Direktor;Schulleitung;40
3;Petra;Gruber;Reinigungskraft;Gebäudeverwaltung;30
4;Thomas;Bauer;Schulwart;Gebäudeverwaltung;38
5;Laura;Moser;Sekretärin;Sekretariat;35
```

Die erste Zeile enthält die Überschriften und darf nicht als Mitarbeiter importiert werden.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

# 3. Projektstruktur

```text
PE18_CSV_Schulpersonalverwaltung/
├── Data/
│   └── mitarbeiter.csv
├── Models/
│   └── Mitarbeiter.cs
├── Services/
│   └── MitarbeiterService.cs
├── Program.cs
└── PE18_CSV_Schulpersonalverwaltung.csproj
```

Die Dateien und Klassen sind bereits miteinander verknüpft.

Die Methoden im `MitarbeiterService` sind noch nicht umgesetzt.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

# 4. Programmablauf

Das fertige Programm soll:

1. die vorhandene CSV-Datei importieren,
2. alle Mitarbeiter ausgeben,
3. einen Mitarbeiter über seine ID suchen,
4. Rolle, Abteilung und Wochenstunden verändern,
5. einen neuen Mitarbeiter über die Konsole anlegen,
6. alle Daten in `mitarbeiter_export.csv` exportieren,
7. die exportierte Datei erneut importieren,
8. die endgültige Mitarbeiterliste nochmals ausgeben.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

# 5. Aufgaben

## 5.1 CSV importieren

Implementiere im `MitarbeiterService` die Methode:

```csharp
public List<Mitarbeiter> ImportiereCsv(string pfad)
```

Die Methode soll:

- die Datei einlesen,
- die Überschrift überspringen,
- jede CSV-Zeile beim Semikolon trennen,
- die Werte in die passenden Datentypen umwandeln,
- aus jeder Zeile ein `Mitarbeiter`-Objekt erstellen,
- alle Objekte in einer Liste speichern,
- die fertige Liste zurückgeben.

---

## 5.2 Mitarbeiter ausgeben

Implementiere die Methode:

```csharp
public void ZeigeAlleMitarbeiter(List<Mitarbeiter> mitarbeiter)
```

Gib für jeden Mitarbeiter mindestens folgende Informationen aus:

```text
ID: 1
Name: Anna Huber
Rolle: Lehrerin
Abteilung: Informatik
Wochenstunden: 22
```

Zwischen zwei Mitarbeitern soll eine Leerzeile oder eine Trennlinie stehen.

---

## 5.3 Mitarbeiter suchen

Implementiere die Methode:

```csharp
public Mitarbeiter? FindeNachId(List<Mitarbeiter> mitarbeiter, int id)
```

Die Methode soll:

- die Liste durchsuchen,
- den Mitarbeiter mit der passenden ID zurückgeben,
- `null` zurückgeben, wenn keine passende ID gefunden wurde.

---

## 5.4 Mitarbeiter verändern

Dieser Teil ist bereits in `Program.cs` verknüpft.

Der gefundene Mitarbeiter erhält neue Werte für:

- Rolle
- Abteilung
- Wochenstunden

Da sich das gefundene Objekt bereits in der Liste befindet, müssen die Änderungen nicht erneut zur Liste hinzugefügt werden.

---

## 5.5 Neuen Mitarbeiter hinzufügen

Die Eingaben und das Erstellen des Objekts sind bereits in `Program.cs` vorbereitet.

Der neue Mitarbeiter wird anschließend zur bestehenden Liste hinzugefügt.

---

## 5.6 CSV exportieren

Implementiere die Methode:

```csharp
public void ExportiereCsv(string pfad, List<Mitarbeiter> mitarbeiter)
```

Die exportierte Datei soll:

- dieselbe Überschrift wie die Ausgangsdatei besitzen,
- jeden Mitarbeiter in einer eigenen Zeile enthalten,
- Semikolons als Trennzeichen verwenden.

Format einer Mitarbeiterzeile:

```text
Id;Vorname;Nachname;Rolle;Abteilung;Wochenstunden
```

Beispiel:

```csv
6;David;Hofer;Lehrer;Mathematik;24
```

Die Datei soll unter folgendem Pfad gespeichert werden:

```text
Data/mitarbeiter_export.csv
```

---

## 5.7 Export erneut kontrollieren

Nach dem Export wird `mitarbeiter_export.csv` erneut über die Import-Methode eingelesen.

Die erneut importierte Liste wird zum Abschluss noch einmal vollständig ausgegeben.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

# 6. Anforderungen

- Verwende die vorhandene Klasse `Mitarbeiter`.
- Die Dateiverarbeitung gehört in den `MitarbeiterService`.
- `Program.cs` steuert den Ablauf des Programms.
- Verwende eine `List<Mitarbeiter>`.
- Verwende keine zusätzliche CSV-Bibliothek.
- Das Trennzeichen ist ein Semikolon.
- Die Überschrift darf nicht als Mitarbeiter eingelesen werden.
- Die ursprüngliche Datei `mitarbeiter.csv` darf nicht überschrieben werden.
- Die neue Datei muss `mitarbeiter_export.csv` heißen.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

# 7. Erwartete Ausgabe

Die genaue Darstellung darf unterschiedlich sein.

Beispiel:

```text
Vorhandene Mitarbeiter
----------------------
ID: 1
Name: Anna Huber
Rolle: Lehrerin
Abteilung: Informatik
Wochenstunden: 22

ID des Mitarbeiters: 3
Neue Rolle: Reinigungskraft
Neue Abteilung: Gebäudeverwaltung
Neue Wochenstunden: 35

Neuen Mitarbeiter anlegen
ID: 6
Vorname: David
Nachname: Hofer
Rolle: Lehrer
Abteilung: Mathematik
Wochenstunden: 24

Exportierte Mitarbeiterliste:
...
```

Am Ende müssen sowohl die Änderungen als auch der neu angelegte Mitarbeiter in der Ausgabe sichtbar sein.

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)
