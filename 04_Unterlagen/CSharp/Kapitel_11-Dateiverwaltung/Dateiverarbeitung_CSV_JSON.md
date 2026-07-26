# PE18 – Dateiverarbeitung: CSV und JSON importieren und exportieren

## Lernziele

- Dateien mit C# erstellen und lesen,
- mehrere Zeilen in einer Datei speichern,
- Objekte als CSV exportieren,
- CSV-Dateien wieder in Objekte umwandeln,
- Objekte als JSON serialisieren,
- JSON-Dateien wieder deserialisieren,
- überprüfen, ob eine Datei vorhanden ist,
- einfache Fehler beim Import abfangen,
- Dateiverarbeitung in einen eigenen Service auslagern,
- die Aufgaben von Klassen, Services und `Program.cs` voneinander unterscheiden.

---

# 1. Warum speichern wir Daten in Dateien?

Bisher existierten unsere Objekte nur so lange, wie das Programm ausgeführt wurde.

```csharp
Spieler spieler = new Spieler("Danii", 5, 250, "Magier");
```

Solange das Programm läuft, befindet sich dieses Objekt im Arbeitsspeicher. Sobald das Programm beendet wird, gehen diese Daten verloren.

Damit Daten auch nach dem Beenden des Programms erhalten bleiben, müssen sie dauerhaft gespeichert werden.

Dafür können unter anderem folgende Systeme verwendet werden:

- Textdateien
- CSV-Dateien
- JSON-Dateien
- XML-Dateien
- Datenbanken

In dieser Einheit verwenden wir CSV und JSON.

---

# 2. Grundlegende Dateiverarbeitung

C# stellt über die Klasse `File` verschiedene Methoden zum Lesen und Schreiben von Dateien bereit.

```csharp
using System.IO;
```

## 2.1 Eine Textdatei erstellen

```csharp
string dateiPfad = "daten.txt";

File.WriteAllText(dateiPfad, "Hallo aus C#!");
```

Existiert die Datei noch nicht, wird sie erstellt. Existiert sie bereits, wird ihr Inhalt überschrieben.

## 2.2 Eine Textdatei lesen

```csharp
string inhalt = File.ReadAllText("daten.txt");
Console.WriteLine(inhalt);
```

## 2.3 Mehrere Zeilen speichern

```csharp
List<string> namen = new List<string>
{
    "Nils",
    "Michael",
    "Danii"
};

File.WriteAllLines("namen.txt", namen);
```

## 2.4 Mehrere Zeilen lesen

```csharp
string[] zeilen = File.ReadAllLines("namen.txt");

foreach (string zeile in zeilen)
{
    Console.WriteLine(zeile);
}
```

---

# 3. Überprüfen, ob eine Datei existiert

Bevor eine Datei gelesen wird, sollte überprüft werden, ob sie vorhanden ist.

```csharp
string dateiPfad = "spieler.csv";

if (!File.Exists(dateiPfad))
{
    Console.WriteLine("Die Datei wurde nicht gefunden.");
    return;
}
```

Das Ausrufezeichen bedeutet `nicht`.

```csharp
!File.Exists(dateiPfad)
```

bedeutet daher:

> Die Datei existiert nicht.

---

# 4. Was ist CSV?

CSV bedeutet:

```text
Comma-Separated Values
```

Eine CSV-Datei speichert Daten tabellenartig.

```csv
Name;Level;Gold;Klasse
Danii;5;250;Magier
Anna;3;125;Bogenschützin
Leon;7;500;Schwertkämpfer
```

Jede Zeile entspricht einem Datensatz. Die Werte werden durch ein Trennzeichen getrennt.

Im deutschsprachigen Raum wird häufig ein Semikolon verwendet, weil das Komma bereits als Dezimaltrennzeichen vorkommt.

---

# 5. Aufbau einer CSV-Datei

Die erste Zeile enthält meistens die Überschriften:

```csv
Name;Level;Gold;Klasse
```

Diese Zeile wird als Header bezeichnet.

Die Reihenfolge der Werte muss immer gleich bleiben:

```text
Index 0: Name
Index 1: Level
Index 2: Gold
Index 3: Klasse
```

---

# 6. Beispielklasse `Spieler`

```csharp
namespace Dateiverarbeitung.Classes
{
    public class Spieler
    {
        #region Properties

        public string Name { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public string Klasse { get; set; }

        #endregion

        #region Konstruktoren

        public Spieler()
        {
            Name = "";
            Klasse = "";
        }

        public Spieler(string name, int level, int gold, string klasse)
        {
            Name = name;
            Level = level;
            Gold = gold;
            Klasse = klasse;
        }

        #endregion

        #region Methoden

        public void ZeigeInfo()
        {
            Console.WriteLine($"{Name} – Level {Level} – {Klasse} – {Gold} Gold");
        }

        #endregion
    }
}
```

Der parameterlose Konstruktor ist besonders für das Laden aus JSON hilfreich. Der zweite Konstruktor wird verwendet, wenn wir selbst neue Spieler erstellen.

---

# 7. CSV exportieren

Beim Export wird jedes Objekt in eine Textzeile umgewandelt.

Aus:

```csharp
new Spieler("Danii", 5, 250, "Magier")
```

wird:

```csv
Danii;5;250;Magier
```

## 7.1 CSV-Export Schritt für Schritt

```csharp
List<string> zeilen = new List<string>();
zeilen.Add("Name;Level;Gold;Klasse");
```

Danach wird für jeden Spieler eine CSV-Zeile erzeugt:

```csharp
foreach (Spieler spieler in spielerListe)
{
    string zeile = $"{spieler.Name};{spieler.Level};{spieler.Gold};{spieler.Klasse}"

    zeilen.Add(zeile);
}
```

Zum Schluss werden alle Zeilen gespeichert:

```csharp
File.WriteAllLines(dateiPfad, zeilen);
```

## 7.2 Vollständige Exportmethode

```csharp
public static void AlsCsvSpeichern(List<Spieler> spielerListe, string dateiPfad)
{
    List<string> zeilen = new List<string>();
    zeilen.Add("Name;Level;Gold;Klasse");

    foreach (Spieler spieler in spielerListe)
    {
        string zeile = $"{spieler.Name};{spieler.Level};{spieler.Gold};{spieler.Klasse}"

        zeilen.Add(zeile);
    }

    File.WriteAllLines(dateiPfad, zeilen);
    Console.WriteLine($"CSV-Datei wurde gespeichert: {dateiPfad}");
}
```

---

# 8. CSV importieren

Beim Import wird der umgekehrte Weg durchgeführt.

Aus:

```csv
Danii;5;250;Magier
```

wird wieder:

```csharp
new Spieler("Danii", 5, 250, "Magier");
```

## 8.1 Zeilen einlesen

```csharp
string[] zeilen = File.ReadAllLines(dateiPfad);
```

Da die erste Zeile nur die Überschriften enthält, beginnen wir bei Index `1`:

```csharp
for (int i = 1; i < zeilen.Length; i++)
{
}
```

## 8.2 Eine Zeile aufteilen

```csharp
string[] werte = zeilen[i].Split(';');
```

Aus:

```text
Danii;5;250;Magier
```

wird:

```text
werte[0] = "Danii"
werte[1] = "5"
werte[2] = "250"
werte[3] = "Magier"
```

## 8.3 Werte überprüfen

```csharp
if (werte.Length != 4)
{
    Console.WriteLine($"Ungültige CSV-Zeile: {zeilen[i]}");
    continue;
}
```

`continue` beendet nur den aktuellen Schleifendurchlauf. Die nächste Zeile wird weiterhin verarbeitet.

## 8.4 Zahlen sicher umwandeln

```csharp
if (
    !int.TryParse(werte[1], out int level)
    ||
    !int.TryParse(werte[2], out int gold)
)
{
    Console.WriteLine($"Ungültige Zahlen in Zeile {i + 1}.");
    continue;
}
```

## 8.5 Objekt erstellen

```csharp
Spieler spieler = new Spieler(
    werte[0],
    level,
    gold,
    werte[3]
);

spielerListe.Add(spieler);
```

## 8.6 Vollständige Importmethode

```csharp
public static List<Spieler> AusCsvLaden(string dateiPfad)
{
    List<Spieler> spielerListe = new List<Spieler>();

    if (!File.Exists(dateiPfad))
    {
        Console.WriteLine("Die CSV-Datei wurde nicht gefunden.");
        return spielerListe;
    }

    string[] zeilen = File.ReadAllLines(dateiPfad);

    for (int i = 1; i < zeilen.Length; i++)
    {
        string[] werte = zeilen[i].Split(';');

        if (werte.Length != 4)
        {
            Console.WriteLine($"Ungültige CSV-Zeile: {zeilen[i]}");
            continue;
        }

        if (
            !int.TryParse(werte[1], out int level)
            ||
            !int.TryParse(werte[2], out int gold)
        )
        {
            Console.WriteLine($"Ungültige Zahlen in Zeile {i + 1}.");
            continue;
        }

        Spieler spieler = new Spieler(
            werte[0],
            level,
            gold,
            werte[3]
        );

        spielerListe.Add(spieler);
    }

    return spielerListe;
}
```

---

# 9. Grenzen von einfachem CSV

Unser selbst gebauter CSV-Import funktioniert für einfache Daten.

Problematisch wird es, wenn ein Wert selbst das Trennzeichen enthält.

Auch folgende Daten sind in CSV schwieriger:

- Listen innerhalb eines Objekts
- verschachtelte Objekte
- mehrzeilige Texte
- unterschiedliche Datentypen
- Vererbungsstrukturen

Für professionelle Programme werden häufig eigene CSV-Bibliotheken verwendet. Für diese Einheit reicht unsere einfache Variante vollständig aus.

---

# 10. Was ist JSON?

JSON bedeutet:

```text
JavaScript Object Notation
```

JSON kann die Struktur von Objekten abbilden.

```json
{
  "Name": "Danii",
  "Level": 5,
  "Gold": 250,
  "Klasse": "Magier"
}
```

Eine Liste aus mehreren Spielern:

```json
[
  {
    "Name": "Danii",
    "Level": 5,
    "Gold": 250,
    "Klasse": "Magier"
  },
  {
    "Name": "Anna",
    "Level": 3,
    "Gold": 125,
    "Klasse": "Bogenschützin"
  }
]
```

JSON kann darstellen:

- Objekte
- Listen
- verschachtelte Objekte
- Wahrheitswerte
- Zahlen
- Texte
- `null`

---

# 11. JSON mit `System.Text.Json`

```csharp
using System.Text.Json;
```

Die wichtigste Klasse ist:

```csharp
JsonSerializer
```

Sie kann Objekte serialisieren und deserialisieren.

---

# 12. Was bedeutet Serialisierung?

Serialisierung bedeutet:

> Ein Objekt wird in ein speicherbares Format umgewandelt.

```text
C#-Objekt → JSON-Text
```

---

# 13. Was bedeutet Deserialisierung?

Deserialisierung bedeutet:

> Gespeicherte Daten werden wieder in ein Objekt umgewandelt.

```text
JSON-Text → C#-Objekt
```

---

# 14. JSON exportieren

## 14.1 Objekt serialisieren

```csharp
string json = JsonSerializer.Serialize(spielerListe);
File.WriteAllText(dateiPfad, json);
```

## 14.2 JSON lesbar formatieren

```csharp
JsonSerializerOptions optionen = new JsonSerializerOptions
{
    WriteIndented = true
};

string json = JsonSerializer.Serialize(spielerListe, optionen);
```

## 14.3 Vollständige Exportmethode

```csharp
public static void AlsJsonSpeichern(List<Spieler> spielerListe, string dateiPfad)
{
    JsonSerializerOptions optionen = new JsonSerializerOptions
    {
        WriteIndented = true
    };

    string json = JsonSerializer.Serialize(spielerListe, optionen);
    File.WriteAllText(dateiPfad, json);

    Console.WriteLine($"JSON-Datei wurde gespeichert: {dateiPfad}");
}
```

---

# 15. JSON importieren

```csharp
string json = File.ReadAllText(dateiPfad);

List<Spieler>? spielerListe =
    JsonSerializer.Deserialize<List<Spieler>>(json);
```

Die Methode kann `null` zurückgeben. Darum verwenden wir:

```csharp
return spielerListe ?? new List<Spieler>();
```

Der Operator `??` bedeutet:

> Verwende den linken Wert, wenn er nicht `null` ist. Ansonsten verwende den rechten Wert.

## 15.1 Vollständige Importmethode

```csharp
public static List<Spieler> AusJsonLaden(string dateiPfad)
{
    if (!File.Exists(dateiPfad))
    {
        Console.WriteLine("Die JSON-Datei wurde nicht gefunden.");
        return new List<Spieler>();
    }

    string json = File.ReadAllText(dateiPfad);

    List<Spieler>? spielerListe =
        JsonSerializer.Deserialize<List<Spieler>>(json);

    return spielerListe ?? new List<Spieler>();
}
```

---

# 16. Fehlerhafte JSON-Dateien

Ist eine JSON-Datei falsch aufgebaut, kann eine `JsonException` auftreten.

```csharp
try
{
    List<Spieler>? spielerListe =
        JsonSerializer.Deserialize<List<Spieler>>(json);
}
catch (JsonException)
{
    Console.WriteLine("Die JSON-Datei ist ungültig.");
}
```

Vollständige Variante:

```csharp
public static List<Spieler> AusJsonLaden(string dateiPfad)
{
    if (!File.Exists(dateiPfad))
    {
        Console.WriteLine("Die JSON-Datei wurde nicht gefunden.");
        return new List<Spieler>();
    }

    try
    {
        string json = File.ReadAllText(dateiPfad);

        List<Spieler>? spielerListe =
            JsonSerializer.Deserialize<List<Spieler>>(json);

        return spielerListe ?? new List<Spieler>();
    }
    catch (JsonException)
    {
        Console.WriteLine("Die JSON-Datei besitzt kein gültiges Format.");
        return new List<Spieler>();
    }
}
```

---

# 17. CSV und JSON im Vergleich

## CSV

Geeignet für:

- tabellarische Daten
- einfache Listen
- Daten für Excel
- kleine und übersichtliche Datensätze

Vorteile:

- einfach aufgebaut
- leicht lesbar
- kleine Dateigröße
- gut für Tabellenprogramme

Nachteile:

- keine echte Objektstruktur
- verschachtelte Objekte sind schwierig
- Trennzeichen können Probleme verursachen
- Datentypen müssen selbst umgewandelt werden

## JSON

Geeignet für:

- Objekte
- Listen von Objekten
- verschachtelte Daten
- Konfigurationsdateien
- Spielstände
- Web-APIs

Vorteile:

- bildet Objektstrukturen gut ab
- Listen und Unterobjekte sind möglich
- automatische Serialisierung
- gut lesbar
- weit verbreitet

Nachteile:

- größere Dateien als CSV
- weniger praktisch für Tabellenprogramme
- ungültige Syntax kann den gesamten Import verhindern

---

# 18. Warum trennen wir den Code?

Man könnte alle Methoden direkt in `Program.cs` schreiben.

Bei kleinen Programmen funktioniert das. Je größer das Programm wird, desto unübersichtlicher wird jedoch `Program.cs`.

Dann befinden sich dort gleichzeitig:

- Objekte erstellen
- Konsolenausgaben
- Programmablauf
- CSV-Dateien schreiben
- CSV-Dateien lesen
- JSON-Dateien schreiben
- JSON-Dateien lesen
- Fehlerbehandlung

Eine einzelne Datei übernimmt dadurch zu viele verschiedene Aufgaben.

---

# 19. Trennung von Verantwortlichkeiten

Eine wichtige Regel lautet:

> Eine Klasse sollte eine klar definierte Aufgabe besitzen.

Eine mögliche Projektstruktur:

```text
Dateiverarbeitung
│
├── Classes
│   └── Spieler.cs
│
├── Services
│   └── SpielerDateiService.cs
│
└── Program.cs
```

---

# 20. Was macht die Klasse `Spieler`?

Die Klasse `Spieler` beschreibt ein Spielerobjekt.

Sie enthält:

- Daten eines Spielers
- Properties
- Konstruktoren
- Methoden, die direkt zum Spieler gehören

Die Klasse beantwortet die Frage:

> Was ist ein Spieler und welche Daten besitzt er?

Das Speichern einer vollständigen Spielerliste ist dagegen keine grundlegende Eigenschaft eines einzelnen Spielers.

---

# 21. Was macht ein Service?

Ein Service ist eine Klasse, die eine bestimmte Aufgabe für andere Teile des Programms übernimmt.

Unser `SpielerDateiService` übernimmt:

```text
Spielerdaten speichern
Spielerdaten laden
CSV verarbeiten
JSON verarbeiten
```

Der Service kennt die Klasse `Spieler` und kann mit Spielerobjekten arbeiten. Er beschreibt aber nicht, was ein Spieler ist.

## 21.1 Beispiel für einen Service

```csharp
namespace Dateiverarbeitung.Services
{
    public static class SpielerDateiService
    {
        public static void AlsCsvSpeichern(...)
        {
        }

        public static List<Spieler> AusCsvLaden(...)
        {
        }

        public static void AlsJsonSpeichern(...)
        {
        }

        public static List<Spieler> AusJsonLaden(...)
        {
        }
    }
}
```

---

# 22. Warum heißt es Service?

Das englische Wort `Service` bedeutet Dienst oder Dienstleistung.

Die Klasse bietet dem restlichen Programm eine Dienstleistung an.

```csharp
SpielerDateiService.AlsJsonSpeichern(
    spielerListe,
    "spieler.json"
);
```

`Program.cs` sagt nur:

> Speichere diese Spieler als JSON.

Wie genau das funktioniert, entscheidet der Service.

Der Service kümmert sich intern um:

- Serialisierung
- Erstellen des JSON-Texts
- Schreiben der Datei
- Fehlerbehandlung

---

# 23. Vergleich aus dem Alltag

Man kann sich das Programm wie ein Restaurant vorstellen.

## `Spieler`

Der Spieler ist vergleichbar mit einem Gericht. Das Gericht besitzt eigene Daten.

## `SpielerDateiService`

Der Service ist vergleichbar mit dem Personal, das das Gericht verpackt oder ausliefert. Das Gericht liefert sich nicht selbst aus.

## `Program.cs`

`Program.cs` organisiert den Ablauf:

- Objekte auswählen
- Service beauftragen
- Ergebnisse anzeigen

---

# 24. Aufgabe von `Program.cs`

`Program.cs` steuert den Ablauf des Programms.

Dort werden:

- Objekte erstellt
- Methoden aufgerufen
- Listen angelegt
- Ergebnisse ausgegeben
- Services verwendet

Beispiel:

```csharp
List<Spieler> spielerListe = new List<Spieler>
{
    new Spieler("Danii", 5, 250, "Magier"),
    new Spieler("Anna", 3, 125, "Bogenschützin")
};

SpielerDateiService.AlsCsvSpeichern(
    spielerListe,
    "spieler.csv"
);

List<Spieler> geladeneSpieler =
    SpielerDateiService.AusCsvLaden("spieler.csv");

foreach (Spieler spieler in geladeneSpieler)
{
    spieler.ZeigeInfo();
}
```

`Program.cs` kennt den Ablauf, enthält aber nicht alle technischen Details des CSV-Imports.

---

# 25. Vorteile eines Services

## Übersichtlichkeit

`Program.cs` bleibt kürzer und leichter lesbar.

## Wiederverwendbarkeit

Der Service kann später aus einem Menü, einer Benutzeroberfläche, einem Spiel oder einem Test verwendet werden.

## Leichtere Änderungen

Ändert sich die Art des Speicherns, muss hauptsächlich der Service angepasst werden.

## Bessere Wartbarkeit

Fehler bei der Dateiverarbeitung werden gezielt im Service gesucht.

## Klare Zuständigkeiten

```text
Spieler.cs
→ beschreibt Spieler

SpielerDateiService.cs
→ speichert und lädt Spieler

Program.cs
→ steuert den Programmablauf
```

---

# 26. Warum ist der Service `static`?

```csharp
public static class SpielerDateiService
```

Dadurch muss kein Objekt des Services erstellt werden.

```csharp
SpielerDateiService.AlsCsvSpeichern(...);
```

Für unseren einfachen Service ist `static` sinnvoll, weil:

- der Service keinen eigenen Zustand besitzt,
- keine Daten dauerhaft innerhalb des Services gespeichert werden,
- die Methoden nur übergebene Daten verarbeiten.

---

# 27. Wann wäre ein Service nicht statisch?

Ein Service könnte später eigene Abhängigkeiten oder Einstellungen besitzen.

Beispiele:

- Datenbankverbindung
- Speicherpfad
- Benutzerkonto
- Konfiguration
- Logger
- Web-API-Verbindung

Dann könnte ein normales Objekt sinnvoll sein.

---

# 28. Vollständige Projektstruktur

```text
Dateiverarbeitung
│
├── Classes
│   └── Spieler.cs
│
├── Services
│   └── SpielerDateiService.cs
│
└── Program.cs
```

Namespaces:

```csharp
namespace Dateiverarbeitung.Classes
{
}
```

```csharp
using Dateiverarbeitung.Classes;

namespace Dateiverarbeitung.Services
{
}
```

```csharp
using Dateiverarbeitung.Classes;
using Dateiverarbeitung.Services;

namespace Dateiverarbeitung
{
}
```

---

# 29. Vollständiger `SpielerDateiService`

```csharp
using System.Text.Json;
using Dateiverarbeitung.Classes;

namespace Dateiverarbeitung.Services
{
    public static class SpielerDateiService
    {
        #region CSV

        public static void AlsCsvSpeichern(
            List<Spieler> spielerListe,
            string dateiPfad)
        {
            List<string> zeilen = new List<string>();
            zeilen.Add("Name;Level;Gold;Klasse");

            foreach (Spieler spieler in spielerListe)
            {
                string zeile =
                    $"{spieler.Name};" +
                    $"{spieler.Level};" +
                    $"{spieler.Gold};" +
                    $"{spieler.Klasse}";

                zeilen.Add(zeile);
            }

            File.WriteAllLines(dateiPfad, zeilen);
            Console.WriteLine($"CSV-Datei gespeichert: {dateiPfad}");
        }

        public static List<Spieler> AusCsvLaden(string dateiPfad)
        {
            List<Spieler> spielerListe = new List<Spieler>();

            if (!File.Exists(dateiPfad))
            {
                Console.WriteLine("Die CSV-Datei wurde nicht gefunden.");
                return spielerListe;
            }

            string[] zeilen = File.ReadAllLines(dateiPfad);

            for (int i = 1; i < zeilen.Length; i++)
            {
                string[] werte = zeilen[i].Split(';');

                if (werte.Length != 4)
                {
                    Console.WriteLine($"Ungültige CSV-Zeile: {zeilen[i]}");
                    continue;
                }

                if (
                    !int.TryParse(werte[1], out int level)
                    ||
                    !int.TryParse(werte[2], out int gold)
                )
                {
                    Console.WriteLine($"Ungültige Zahlen in Zeile {i + 1}.");
                    continue;
                }

                Spieler spieler = new Spieler(
                    werte[0],
                    level,
                    gold,
                    werte[3]
                );

                spielerListe.Add(spieler);
            }

            return spielerListe;
        }

        #endregion

        #region JSON

        public static void AlsJsonSpeichern(
            List<Spieler> spielerListe,
            string dateiPfad)
        {
            JsonSerializerOptions optionen = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(
                spielerListe,
                optionen
            );

            File.WriteAllText(dateiPfad, json);
            Console.WriteLine($"JSON-Datei gespeichert: {dateiPfad}");
        }

        public static List<Spieler> AusJsonLaden(string dateiPfad)
        {
            if (!File.Exists(dateiPfad))
            {
                Console.WriteLine("Die JSON-Datei wurde nicht gefunden.");
                return new List<Spieler>();
            }

            try
            {
                string json = File.ReadAllText(dateiPfad);

                List<Spieler>? spielerListe =
                    JsonSerializer.Deserialize<List<Spieler>>(json);

                return spielerListe ?? new List<Spieler>();
            }
            catch (JsonException)
            {
                Console.WriteLine("Die JSON-Datei besitzt kein gültiges Format.");
                return new List<Spieler>();
            }
        }

        #endregion
    }
}
```

---

# 30. Vollständiger Programmablauf

```csharp
using Dateiverarbeitung.Classes;
using Dateiverarbeitung.Services;

namespace Dateiverarbeitung
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Spieler> spielerListe = new List<Spieler>
            {
                new Spieler("Danii", 5, 250, "Magier"),
                new Spieler("Anna", 3, 125, "Bogenschützin"),
                new Spieler("Leon", 7, 500, "Schwertkämpfer")
            };

            SpielerDateiService.AlsCsvSpeichern(
                spielerListe,
                "spieler.csv"
            );

            SpielerDateiService.AlsJsonSpeichern(
                spielerListe,
                "spieler.json"
            );

            Console.WriteLine();
            Console.WriteLine("Spieler aus CSV:");
            Console.WriteLine();

            List<Spieler> spielerAusCsv =
                SpielerDateiService.AusCsvLaden("spieler.csv");

            foreach (Spieler spieler in spielerAusCsv)
            {
                spieler.ZeigeInfo();
            }

            Console.WriteLine();
            Console.WriteLine("Spieler aus JSON:");
            Console.WriteLine();

            List<Spieler> spielerAusJson =
                SpielerDateiService.AusJsonLaden("spieler.json");

            foreach (Spieler spieler in spielerAusJson)
            {
                spieler.ZeigeInfo();
            }
        }
    }
}
```

---

# 31. Wo werden die Dateien gespeichert?

Wird nur ein Dateiname angegeben:

```csharp
"spieler.csv"
```

wird die Datei im aktuellen Arbeitsverzeichnis des Programms gespeichert. Während der Entwicklung befindet sich dieses meistens in einem Ordner wie:

```text
bin/Debug/net...
```

---

# 32. Ordner automatisch erstellen

```csharp
string ordner = "Daten";

if (!Directory.Exists(ordner))
{
    Directory.CreateDirectory(ordner);
}

string dateiPfad = Path.Combine(ordner, "spieler.json");
```

`Path.Combine()` setzt Pfadteile korrekt zusammen.

---

# 33. Wichtige Begriffe

## Export

```text
Objekte → Datei
```

## Import

```text
Datei → Objekte
```

## Serialisierung

```text
Objekt → JSON
```

## Deserialisierung

```text
JSON → Objekt
```

## Service

Eine Klasse, die eine bestimmte Aufgabe für andere Teile des Programms übernimmt.

---

# 34. Zusammenfassung

Dateien ermöglichen es, Daten dauerhaft zu speichern.

CSV speichert Daten tabellenartig. Beim Import müssen die Werte selbst getrennt und umgewandelt werden.

JSON bildet Objektstrukturen ab. Mit `JsonSerializer.Serialize()` werden Objekte in JSON umgewandelt. Mit `JsonSerializer.Deserialize()` wird JSON wieder in Objekte umgewandelt.

Die Projektstruktur wird getrennt:

```text
Classes
→ beschreibt Datenobjekte

Services
→ übernimmt eine bestimmte Verarbeitung

Program.cs
→ steuert den Programmablauf
```

Ein Service sorgt dafür, dass der Dateicode nicht überall im Programm verteilt ist.

Dadurch wird der Code:

- übersichtlicher
- wiederverwendbarer
- leichter zu warten
- leichter zu erweitern

---

# 35. Kontrollfragen

1. Warum gehen Objekte nach dem Beenden eines Programms normalerweise verloren?
2. Was ist der Unterschied zwischen `WriteAllText()` und `WriteAllLines()`?
3. Was überprüft `File.Exists()`?
4. Was ist ein CSV-Header?
5. Warum beginnen wir beim CSV-Import häufig bei Index `1`?
6. Was macht `Split(';')`?
7. Warum verwenden wir beim Import `TryParse()`?
8. Was bedeutet Serialisierung?
9. Was bedeutet Deserialisierung?
10. Welche Vorteile besitzt JSON gegenüber einfachem CSV?
11. Welche Aufgabe besitzt die Klasse `Spieler`?
12. Welche Aufgabe besitzt der `SpielerDateiService`?
13. Welche Aufgabe besitzt `Program.cs`?
14. Warum wird die Dateiverarbeitung nicht vollständig in `Program.cs` geschrieben?
15. Warum ist unser Service als `static` definiert?
16. Was bewirkt der Operator `??`?
17. Wann kann eine `JsonException` auftreten?
18. Warum ist `Path.Combine()` sinnvoll?
