# PE18 – JSON-Dateiverarbeitung

## Aufgabe 2: Charakter- und Inventarverwaltung

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

## Ausgangssituation

Für ein Spiel sollen Charaktere und ihre Inventare verwaltet werden.

Die vorhandene Datei `charaktere.json` enthält bereits mehrere Charaktere.
Jeder Charakter besitzt eine Liste mit Gegenständen.

Die Daten sollen:

1. aus der JSON-Datei importiert,
2. ausgegeben,
3. verändert,
4. in eine neue JSON-Datei exportiert,
5. erneut importiert
6. und abschließend noch einmal ausgegeben werden.

---

## Projektstruktur

```text
PE18_JSON_Charakterverwaltung/
├── Data/
│   └── charaktere.json
├── Models/
│   ├── Charakter.cs
│   └── Gegenstand.cs
├── Services/
│   └── CharakterService.cs
├── Program.cs
└── PE18_JSON_Charakterverwaltung.csproj
```

---

## Vorhandene Klassen

### Charakter

Ein Charakter besitzt:

- ID
- Name
- Klasse
- Level
- Gold
- Inventar

Das Inventar ist eine Liste aus `Gegenstand`-Objekten.

### Gegenstand

Ein Gegenstand besitzt:

- ID
- Name
- Kategorie
- Wert
- Anzahl

---

## Vorhandene Datei

Die Datei befindet sich unter:

```text
Data/charaktere.json
```

Sie enthält mehrere Charaktere mit jeweils eigenem Inventar.

Die ursprüngliche Datei darf beim Export nicht überschrieben werden.

---

# Arbeitsauftrag

## 1. JSON importieren

Implementiere in `CharakterService.cs` die Methode:

```csharp
public List<Charakter> ImportiereJson(string pfad)
```

Die Methode soll:

- die Datei lesen,
- den JSON-Text in eine `List<Charakter>` umwandeln,
- die Liste zurückgeben,
- sinnvoll reagieren, wenn die Datei nicht existiert,
- sinnvoll reagieren, wenn die Datei ungültiges JSON enthält.

Verwende dafür `JsonSerializer.Deserialize`.

---

## 2. Charaktere ausgeben

Implementiere:

```csharp
public void ZeigeCharaktere(
    List<Charakter> charaktere)
```

Gib jeden Charakter übersichtlich aus.

Beispiel:

```text
ID: 1
Name: Liora
Klasse: Magierin
Level: 8
Gold: 240

Inventar:
  1 | Manatrank | Trank | Wert: 25 | Anzahl: 3
  2 | Alter Zauberstab | Waffe | Wert: 120 | Anzahl: 1
```

Das Inventar soll unter dem jeweiligen Charakter ausgegeben werden.

---

## 3. Charakter suchen

Implementiere:

```csharp
public Charakter? FindeCharakterNachId(
    List<Charakter> charaktere,
    int id)
```

Die Methode soll den Charakter mit der passenden ID zurückgeben.

Wird kein Charakter gefunden, soll `null` zurückgegeben werden.

---

## 4. Charakterdaten verändern

Der Benutzer soll eine Charakter-ID eingeben.

Suche den Charakter über die Service-Methode.

Danach soll der Benutzer auswählen können:

```text
1 - Level verändern
2 - Gold verändern
```

Der gewählte Wert soll beim gefundenen Charakter aktualisiert werden.

Achte auf gültige Zahleneingaben.

---

## 5. Gegenstand suchen

Implementiere:

```csharp
public Gegenstand? FindeGegenstandNachId(
    Charakter charakter,
    int gegenstandId)
```

Die Methode soll im Inventar des übergebenen Charakters nach der Gegenstands-ID suchen.

Wird kein Gegenstand gefunden, soll `null` zurückgegeben werden.

---

## 6. Inventar verändern

Der Benutzer soll auswählen können:

```text
1 - Gegenstand hinzufügen
2 - Anzahl eines Gegenstands verändern
3 - Gegenstand entfernen
```

### Gegenstand hinzufügen

Lies folgende Daten ein:

- ID
- Name
- Kategorie
- Wert
- Anzahl

Erstelle daraus ein neues `Gegenstand`-Objekt und füge es zum Inventar des ausgewählten Charakters hinzu.

Die Gegenstands-ID darf innerhalb dieses Inventars noch nicht existieren.

### Anzahl verändern

Lies eine Gegenstands-ID ein.

Suche den Gegenstand über `FindeGegenstandNachId`.

Danach soll eine neue Anzahl eingegeben und gespeichert werden.

### Gegenstand entfernen

Lies eine Gegenstands-ID ein.

Suche den Gegenstand und entferne ihn aus dem Inventar.

---

## 7. JSON exportieren

Implementiere:

```csharp
public void ExportiereJson(
    string pfad,
    List<Charakter> charaktere)
```

Exportiere die veränderte Liste nach:

```text
Data/charaktere_export.json
```

Die JSON-Datei soll eingerückt und gut lesbar gespeichert werden.

Verwende dafür:

```csharp
new JsonSerializerOptions
{
    WriteIndented = true
}
```

---

## 8. Exportierte Datei erneut importieren

Importiere nach dem Export die Datei:

```text
Data/charaktere_export.json
```

Verwende dazu erneut die Methode:

```csharp
ImportiereJson(...)
```

Speichere das Ergebnis in einer neuen Liste.

---

## 9. Endergebnis ausgeben

Gib die erneut importierten Charaktere mit ihren Inventaren noch einmal vollständig aus.

Damit wird überprüft, ob:

- die Änderungen gespeichert wurden,
- das Inventar korrekt exportiert wurde,
- die verschachtelten Objekte korrekt importiert werden.

---

# Vorgeschriebener Ablauf

```text
1. charaktere.json importieren
2. Ursprüngliche Daten ausgeben
3. Charakter über ID auswählen
4. Level oder Gold verändern
5. Inventar verändern
6. charaktere_export.json erstellen
7. charaktere_export.json erneut importieren
8. Endergebnis ausgeben
```

---

# Vorgaben

- Verwende die vorhandenen Klassen.
- Die Dateiverarbeitung gehört in `CharakterService`.
- Verwende keine fertigen Beispielschleifen aus der Angabe.
- Verwende `JsonSerializer`.
- Überschreibe nicht die ursprüngliche Datei.
- Prüfe Benutzereingaben mit `TryParse`.
- Gib verständliche Fehlermeldungen aus.
- Verwende sinnvolle Variablennamen.
- Achte auf eine übersichtliche Konsolenausgabe.

---

# Abgabe

Abzugeben sind:

```text
Program.cs
Models/Charakter.cs
Models/Gegenstand.cs
Services/CharakterService.cs
Data/charaktere_export.json
```
