# C# Cheatsheet

> Kompakte Übersicht zu den bisher gelernten C#-Grundlagen.

---

## Inhaltsverzeichnis

1. [Grundlagen](#1-grundlagen)
2. [Variablen und Eingaben](#2-variablen-und-eingaben)
3. [IF-Bedingungen](#3-if-bedingungen)
4. [Switch](#4-switch)
5. [Schleifen](#5-schleifen)
6. [Arrays](#6-arrays)
7. [Methoden](#7-methoden)
8. [Projektstruktur](#8-projektstruktur)
9. [Listen](#9-listen)
10. [Dictionaries](#10-dictionaries)
11. [Objektorientierung](#11-objektorientierung)
12. [Vererbung und Polymorphie](#12-vererbung-und-polymorphie)
13. [Commands](#13-commands)

---

# 1. Grundlagen 
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Ausgabe

```csharp
Console.WriteLine("Hallo Welt!"); // Ausgabe mit Zeilenumbruch
Console.Write("Hallo ");          // Ausgabe ohne Zeilenumbruch
Console.WriteLine("Welt!");
```

## Eingabe

```csharp
string eingabe = Console.ReadLine();
```

## Kommentare

```csharp
// Einzeiliger Kommentar

/*
   Mehrzeiliger
   Kommentar
*/
```

## Text zusammensetzen

```csharp
string name = "Alex";
int alter = 16;

Console.WriteLine($"{name} ist {alter} Jahre alt.");
```

## Escape-Sequenzen

| Schreibweise | Bedeutung |
|---|---|
| `\n` | Neue Zeile |
| `\t` | Tabulator |
| `\"` | Anführungszeichen |
| `\\` | Backslash |

```csharp
Console.WriteLine("Name:\tAlex\nAlter:\t16");
```

## Typische Use Cases

- Texte ausgeben
- Menüs darstellen
- Benutzereingaben lesen
- Ergebnisse anzeigen
- Fehler oder Hinweise ausgeben

---

# 2. Variablen und Eingaben
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Variable erstellen

```csharp
Datentyp variablenName = wert;
```

```csharp
string name = "Alex";
int leben = 100;
double preis = 19.99;
float geschwindigkeit = 5.5f;
decimal kontostand = 100.50m;
char rang = 'A';
bool istOnline = true;
```

## Häufige Datentypen

| Datentyp | Beispiel | Verwendung |
|---|---|---|
| `int` | `42` | Ganze Zahlen |
| `double` | `3.14` | Kommazahlen |
| `float` | `3.14f` | Kommazahlen |
| `decimal` | `19.99m` | Geldbeträge |
| `string` | `"Hallo"` | Texte |
| `char` | `'A'` | Einzelnes Zeichen |
| `bool` | `true` | Wahr oder falsch |

## Variable ändern

```csharp
int punkte = 10;

punkte = 20;
punkte = punkte + 5;
punkte += 5;
punkte -= 2;
punkte *= 2;
punkte /= 2;
```

## Erhöhen und Verringern

```csharp
punkte++;
punkte--;
```

## Konstante

```csharp
const double Mehrwertsteuer = 0.20;
```

Eine Konstante kann später nicht mehr verändert werden.

## Automatische Typbestimmung

```csharp
var name = "Alex"; // string
var alter = 16;     // int
```

## String in Zahl umwandeln

### Mit `Parse`

```csharp
int alter = int.Parse(Console.ReadLine());
```

Nur verwenden, wenn die Eingabe sicher eine Zahl ist.

### Mit `TryParse`

```csharp
bool erfolgreich = int.TryParse(Console.ReadLine(), out int zahl);
```

```csharp
if (int.TryParse(Console.ReadLine(), out int alter))
{
    Console.WriteLine($"Alter: {alter}");
}
else
{
    Console.WriteLine("Ungültige Eingabe!");
}
```

### Verkürzte Schreibweise

```csharp
if (!int.TryParse(Console.ReadLine(), out int zahl))
{
    Console.WriteLine("Keine gültige Zahl!");
}
```

## Typische Use Cases

- Name eines Spielers speichern
- Punkte oder Leben speichern
- Preise berechnen
- Benutzereingaben umwandeln
- Zustände wie `istOnline` speichern

---

# 3. IF-Bedingungen
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Einfache IF-Bedingung

```csharp
if (bedingung)
{
    // Wird ausgeführt, wenn die Bedingung true ist
}
```

```csharp
int alter = 18;

if (alter >= 18)
{
    Console.WriteLine("Volljährig");
}
```

## IF und ELSE

```csharp
if (alter >= 18)
{
    Console.WriteLine("Volljährig");
}
else
{
    Console.WriteLine("Minderjährig");
}
```

## ELSE IF

```csharp
int punkte = 75;

if (punkte >= 90)
{
    Console.WriteLine("Sehr gut");
}
else if (punkte >= 75)
{
    Console.WriteLine("Gut");
}
else if (punkte >= 50)
{
    Console.WriteLine("Bestanden");
}
else
{
    Console.WriteLine("Nicht bestanden");
}
```

## Vergleichsoperatoren

| Operator | Bedeutung |
|---|---|
| `==` | Gleich |
| `!=` | Ungleich |
| `>` | Größer als |
| `<` | Kleiner als |
| `>=` | Größer oder gleich |
| `<=` | Kleiner oder gleich |

```csharp
if (name == "Alex")
{
    Console.WriteLine("Hallo Alex!");
}
```

## Logische Operatoren

| Operator | Bedeutung |
|---|---|
| `&&` | UND – beide Bedingungen müssen stimmen |
| <code>&#124;&#124;</code> | ODER – mindestens eine Bedingung muss stimmen |
| `!` | NICHT – kehrt einen Wahrheitswert um |

```csharp
if (alter >= 18 && hatTicket)
{
    Console.WriteLine("Eintritt erlaubt");
}
```

```csharp
if (istAdmin || istModerator)
{
    Console.WriteLine("Zugriff erlaubt");
}
```

```csharp
if (!istGesperrt)
{
    Console.WriteLine("Benutzer ist nicht gesperrt");
}
```

## Bedingungen gruppieren

```csharp
if ((alter >= 18 && hatTicket) || istMitarbeiter)
{
    Console.WriteLine("Eintritt erlaubt");
}
```

## Verschachtelte IF-Bedingung

```csharp
if (istOnline)
{
    if (hatBerechtigung)
    {
        Console.WriteLine("Zugriff erlaubt");
    }
}
```

## Einzeilige IF-Bedingung

```csharp
if (leben <= 0)
    Console.WriteLine("Game Over");
```

Nur bei genau einer Anweisung verwenden.

## Ternärer Operator

Kurzform für ein einfaches `if-else`.

```csharp
string ergebnis = bedingung ? wertWennTrue : wertWennFalse;
```

```csharp
string status = alter >= 18 ? "Volljährig" : "Minderjährig";
```

```csharp
int groessereZahl = zahl1 > zahl2 ? zahl1 : zahl2;
```

## Bool direkt prüfen

### Lang

```csharp
if (istOnline == true)
{
    Console.WriteLine("Online");
}
```

### Kürzer

```csharp
if (istOnline)
{
    Console.WriteLine("Online");
}
```

### Auf `false` prüfen

```csharp
if (!istOnline)
{
    Console.WriteLine("Offline");
}
```

## Guard Clause

Ungültigen Fall früh beenden.

```csharp
if (alter < 0)
{
    Console.WriteLine("Ungültiges Alter");
    return;
}

Console.WriteLine("Alter ist gültig");
```

## Typische Use Cases

1. Prüfen, ob ein Spieler genug Leben hat
2. Login-Daten kontrollieren
3. Altersfreigabe prüfen
4. Punkte in eine Note umwandeln
5. Kontrollieren, ob ein Gegenstand vorhanden ist

---

# 4. Switch
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Grundstruktur

```csharp
switch (wert)
{
    case wert1:
        // Code
        break;

    case wert2:
        // Code
        break;

    default:
        // Kein Fall passt
        break;
}
```

## Beispiel

```csharp
int auswahl = 2;

switch (auswahl)
{
    case 1:
        Console.WriteLine("Neues Spiel");
        break;

    case 2:
        Console.WriteLine("Spiel laden");
        break;

    case 3:
        Console.WriteLine("Beenden");
        break;

    default:
        Console.WriteLine("Ungültige Auswahl");
        break;
}
```

## Mehrere Fälle zusammenfassen

```csharp
switch (tag)
{
    case "Samstag":
    case "Sonntag":
        Console.WriteLine("Wochenende");
        break;

    default:
        Console.WriteLine("Wochentag");
        break;
}
```

## Switch Expression

Kurze Schreibweise, wenn ein Wert zurückgegeben werden soll.

```csharp
string text = auswahl switch
{
    1 => "Neues Spiel",
    2 => "Spiel laden",
    3 => "Beenden",
    _ => "Ungültige Auswahl"
};
```

## IF oder Switch?

| IF | Switch |
|---|---|
| Bereiche prüfen | Einzelne feste Werte prüfen |
| Mehrere Variablen prüfen | Meist eine Variable prüfen |
| Komplexe Bedingungen | Menüauswahl oder Statuswerte |

## Typische Use Cases

1. Menüauswahl
2. Wochentage
3. Schwierigkeitsgrad
4. Charakterklasse
5. Statuscode auswerten

---

# 5. Schleifen
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## 5.1 While-Schleife

Wird ausgeführt, solange die Bedingung `true` ist.

```csharp
while (bedingung)
{
    // Code
}
```

```csharp
int zahl = 1;

while (zahl <= 5)
{
    Console.WriteLine(zahl);
    zahl++;
}
```

### Endlosschleife

```csharp
while (true)
{
    // Läuft bis zu einem break
}
```

### Typische Use Cases

- Eingabe wiederholen, bis sie gültig ist
- Menü dauerhaft anzeigen
- Spiel laufen lassen
- Wiederholen, solange Leben vorhanden ist
- Datei lesen, solange Daten vorhanden sind

---

## 5.2 Do-While-Schleife

Wird mindestens einmal ausgeführt.

```csharp
do
{
    // Code
}
while (bedingung);
```

```csharp
int auswahl;

do
{
    Console.WriteLine("1 - Starten");
    Console.WriteLine("0 - Beenden");
    int.TryParse(Console.ReadLine(), out auswahl);
}
while (auswahl != 0);
```

### Typische Use Cases

- Menü mindestens einmal anzeigen
- Passwort mindestens einmal abfragen
- Eingabe mit Wiederholung
- Spielrunde mindestens einmal starten
- Wiederholungsfrage stellen

---

## 5.3 For-Schleife

```csharp
for (start; bedingung; veraenderung)
{
    // Code
}
```

```csharp
for (int i = 0; i < 5; i++)
{
    Console.WriteLine(i);
}
```

### Rückwärts zählen

```csharp
for (int i = 10; i >= 1; i--)
{
    Console.WriteLine(i);
}
```

### Schritte verändern

```csharp
for (int i = 0; i <= 10; i += 2)
{
    Console.WriteLine(i);
}
```

### Typische Use Cases

- Eine Aktion eine bestimmte Anzahl wiederholen
- Arrays oder Listen über den Index durchlaufen
- Countdown erstellen
- Werte automatisch erzeugen
- Tabellen oder Spielfelder durchlaufen

---

## 5.4 Foreach-Schleife

```csharp
foreach (Datentyp element in sammlung)
{
    // Code
}
```

```csharp
string[] namen = { "Alex", "Mia", "Sam" };

foreach (string name in namen)
{
    Console.WriteLine(name);
}
```

### Mit `var`

```csharp
foreach (var name in namen)
{
    Console.WriteLine(name);
}
```

### Typische Use Cases

- Alle Namen ausgeben
- Werte summieren
- Objekte einer Liste anzeigen
- Ein Dictionary durchlaufen
- Nach einem Wert suchen

---

## 5.5 Break und Continue

### Schleife beenden

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        break;
    }

    Console.WriteLine(i);
}
```

### Durchlauf überspringen

```csharp
for (int i = 0; i < 10; i++)
{
    if (i == 5)
    {
        continue;
    }

    Console.WriteLine(i);
}
```

## Schleifenvergleich

| Schleife | Verwenden, wenn ... |
|---|---|
| `while` | die Anzahl der Durchläufe unbekannt ist |
| `do-while` | der Code mindestens einmal laufen muss |
| `for` | die Anzahl der Durchläufe bekannt ist |
| `foreach` | alle Elemente einer Sammlung gebraucht werden |

---

# 6. Arrays
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## 6.1 Eindimensionales Array

### Erstellen

```csharp
int[] zahlen = new int[5];
```

### Direkt befüllen

```csharp
int[] zahlen = { 10, 20, 30, 40, 50 };
string[] namen = { "Alex", "Mia", "Sam" };
```

### Zugriff

```csharp
Console.WriteLine(zahlen[0]);
zahlen[1] = 99;
```

Der erste Index ist immer `0`.

### Länge

```csharp
Console.WriteLine(zahlen.Length);
```

### Durchlaufen

```csharp
for (int i = 0; i < zahlen.Length; i++)
{
    Console.WriteLine(zahlen[i]);
}
```

```csharp
foreach (int zahl in zahlen)
{
    Console.WriteLine(zahl);
}
```

---

## 6.2 Zweidimensionales Array

```csharp
int[,] spielfeld = new int[3, 3];
```

```csharp
int[,] matrix =
{
    { 1, 2, 3 },
    { 4, 5, 6 },
    { 7, 8, 9 }
};
```

### Zugriff

```csharp
Console.WriteLine(matrix[0, 1]); // 2
matrix[2, 2] = 10;
```

### Durchlaufen

```csharp
for (int zeile = 0; zeile < matrix.GetLength(0); zeile++)
{
    for (int spalte = 0; spalte < matrix.GetLength(1); spalte++)
    {
        Console.Write(matrix[zeile, spalte] + " ");
    }

    Console.WriteLine();
}
```

---

## 6.3 Jagged Array

Ein Array, dessen Elemente wieder Arrays sind.

```csharp
int[][] zahlen = new int[3][];

zahlen[0] = new int[2];
zahlen[1] = new int[4];
zahlen[2] = new int[1];
```

### Direkt befüllen

```csharp
int[][] zahlen =
{
    new int[] { 1, 2 },
    new int[] { 3, 4, 5 },
    new int[] { 6 }
};
```

### Zugriff

```csharp
Console.WriteLine(zahlen[1][2]); // 5
```

### Durchlaufen

```csharp
for (int i = 0; i < zahlen.Length; i++)
{
    for (int j = 0; j < zahlen[i].Length; j++)
    {
        Console.WriteLine(zahlen[i][j]);
    }
}
```

---

## 6.4 Mehrdimensionales Array

```csharp
int[,,] raum = new int[3, 4, 5];
```

### Zugriff

```csharp
raum[0, 1, 2] = 10;
```

---

## 6.5 Wichtige Array-Befehle

```csharp
Array.Sort(zahlen);                 // Sortieren
Array.Reverse(zahlen);              // Reihenfolge umdrehen
int index = Array.IndexOf(zahlen, 5); // Wert suchen
Array.Clear(zahlen);                // Alle Werte zurücksetzen
int[] kopie = (int[])zahlen.Clone(); // Array kopieren
```

## Typische Use Cases

1. Mehrere Noten speichern
2. Spielernamen speichern
3. Spielfeld als 2D Array darstellen
4. Sitzordnung speichern
5. Tabellenwerte verarbeiten

---

# 7. Methoden
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Methode ohne Parameter und Rückgabewert

```csharp
static void Begruessung()
{
    Console.WriteLine("Hallo!");
}
```

### Aufruf

```csharp
Begruessung();
```

## Methode mit Parameter

```csharp
static void Begruessung(string name)
{
    Console.WriteLine($"Hallo {name}!");
}
```

```csharp
Begruessung("Alex");
```

## Mehrere Parameter

```csharp
static void ZeigeSpieler(string name, int leben)
{
    Console.WriteLine($"{name}: {leben} Leben");
}
```

```csharp
ZeigeSpieler("Alex", 100);
```

## Methode mit Rückgabewert

```csharp
static int Addieren(int zahl1, int zahl2)
{
    return zahl1 + zahl2;
}
```

```csharp
int ergebnis = Addieren(5, 3);
```

## Verkürzte Methode

```csharp
static int Addieren(int zahl1, int zahl2) => zahl1 + zahl2;
```

```csharp
static bool IstVolljaehrig(int alter) => alter >= 18;
```

## Frühes Return

```csharp
static void PruefeAlter(int alter)
{
    if (alter < 0)
    {
        Console.WriteLine("Ungültiges Alter");
        return;
    }

    Console.WriteLine("Alter ist gültig");
}
```

## Liste als Parameter

```csharp
static void ZeigeNamen(List<string> namen)
{
    foreach (string name in namen)
    {
        Console.WriteLine(name);
    }
}
```

## Liste zurückgeben

```csharp
static List<int> ErstelleZahlen()
{
    return new List<int> { 1, 2, 3 };
}
```

## Typische Use Cases

1. Berechnungen auslagern
2. Eingaben prüfen
3. Menüs anzeigen
4. Listen oder Arrays verarbeiten
5. Wiederholten Code vermeiden

---

# 8. Projektstruktur
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Einfache `Program.cs`

```csharp
namespace MeinProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Programm gestartet");
        }
    }
}
```

## Klasse in eigener Datei

### `Spieler.cs`

```csharp
namespace MeinProjekt
{
    internal class Spieler
    {
        public string Name { get; set; }
    }
}
```

### `Program.cs`

```csharp
namespace MeinProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Spieler spieler = new Spieler();
            spieler.Name = "Alex";
        }
    }
}
```

## Using

```csharp
using System;
using System.Collections.Generic;
```

## Namespace

```csharp
namespace MeinProjekt.Models
{
    internal class Spieler
    {
    }
}
```

```csharp
using MeinProjekt.Models;
```

## Häufige Ordner

```text
MeinProjekt/
├── Program.cs
├── Models/
│   ├── Spieler.cs
│   └── Produkt.cs
├── Services/
│   └── SpielerService.cs
└── Helpers/
    └── EingabeHelper.cs
```

## Typische Use Cases

- Klassen auf mehrere Dateien verteilen
- Modelle in `Models` speichern
- Programmlogik in Services auslagern
- Hilfsmethoden sammeln
- Größere Projekte übersichtlich halten

---

# 9. Listen
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Liste erstellen

```csharp
List<string> namen = new List<string>();
```

### Kurzschreibweise

```csharp
List<string> namen = new();
```

### Direkt befüllen

```csharp
List<string> namen = new List<string>
{
    "Alex",
    "Mia",
    "Sam"
};
```

## Zugriff

```csharp
Console.WriteLine(namen[0]);
namen[1] = "Lena";
```

## Anzahl

```csharp
Console.WriteLine(namen.Count);
```

## Wichtige Befehle

```csharp
namen.Add("Noah");             // Hinzufügen
namen.Insert(1, "Lena");      // An Position einfügen
namen.Remove("Alex");         // Wert entfernen
namen.RemoveAt(0);             // Index entfernen
bool vorhanden = namen.Contains("Mia");
int index = namen.IndexOf("Sam");
namen.Clear();                 // Liste leeren
```

## Durchlaufen

```csharp
for (int i = 0; i < namen.Count; i++)
{
    Console.WriteLine(namen[i]);
}
```

```csharp
foreach (string name in namen)
{
    Console.WriteLine(name);
}
```

## Elemente sicher entfernen

```csharp
for (int i = namen.Count - 1; i >= 0; i--)
{
    if (namen[i] == "Alex")
    {
        namen.RemoveAt(i);
    }
}
```

## Array oder Liste?

| Array | Liste |
|---|---|
| Feste Größe | Veränderbare Größe |
| `.Length` | `.Count` |
| Weniger Befehle | Viele praktische Methoden |

## Typische Use Cases

1. Inventar mit veränderbarer Größe
2. Schülerliste
3. Aufgabenliste
4. Warenkorb
5. Liste von Objekten

---

# 10. Dictionaries
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Dictionary erstellen

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();
```

### Kurzschreibweise

```csharp
Dictionary<string, int> punkte = new();
```

### Direkt befüllen

```csharp
Dictionary<string, int> punkte = new()
{
    { "Alex", 100 },
    { "Mia", 85 },
    { "Sam", 70 }
};
```

## Hinzufügen

```csharp
punkte.Add("Lena", 90);
```

## Auslesen

```csharp
Console.WriteLine(punkte["Alex"]);
```

## Hinzufügen oder verändern

```csharp
punkte["Alex"] = 120;
punkte["Noah"] = 50;
```

## Prüfen, ob Schlüssel vorhanden ist

```csharp
if (punkte.ContainsKey("Alex"))
{
    Console.WriteLine(punkte["Alex"]);
}
```

## Sicher auslesen mit `TryGetValue`

```csharp
if (punkte.TryGetValue("Alex", out int wert))
{
    Console.WriteLine(wert);
}
else
{
    Console.WriteLine("Spieler nicht gefunden");
}
```

## Weitere Befehle

```csharp
punkte.ContainsValue(100);
punkte.Remove("Alex");
Console.WriteLine(punkte.Count);
punkte.Clear();
```

## Durchlaufen

```csharp
foreach (KeyValuePair<string, int> eintrag in punkte)
{
    Console.WriteLine($"{eintrag.Key}: {eintrag.Value}");
}
```

### Kürzer mit `var`

```csharp
foreach (var eintrag in punkte)
{
    Console.WriteLine($"{eintrag.Key}: {eintrag.Value}");
}
```

### Nur Schlüssel

```csharp
foreach (string name in punkte.Keys)
{
    Console.WriteLine(name);
}
```

### Nur Werte

```csharp
foreach (int wert in punkte.Values)
{
    Console.WriteLine(wert);
}
```

## Liste oder Dictionary?

| Liste | Dictionary |
|---|---|
| Zugriff über Index | Zugriff über Schlüssel |
| Reihenfolge wichtig | Zuordnung wichtig |
| Doppelte Werte möglich | Schlüssel müssen eindeutig sein |

## Typische Use Cases

1. Spielername und Punktestand
2. Artikelnummer und Produkt
3. Fach und Note
4. Benutzername und Passwort
5. Itemname und Anzahl

---

# 11. Objektorientierung
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## 11.1 Klasse und Objekt

### Klasse

```csharp
internal class Spieler
{
    public string Name { get; set; }
    public int Leben { get; set; }
}
```

### Objekt erstellen

```csharp
Spieler spieler = new Spieler();
spieler.Name = "Alex";
spieler.Leben = 100;
```

### Kurzschreibweise

```csharp
Spieler spieler = new();
```

### Objektinitialisierer

```csharp
Spieler spieler = new Spieler
{
    Name = "Alex",
    Leben = 100
};
```

---

## 11.2 Properties

### Auto-Property

```csharp
public string Name { get; set; }
```

### Property mit Startwert

```csharp
public int Leben { get; set; } = 100;
```

### Von außen nur lesbar

```csharp
public int Leben { get; private set; }
```

### Get-only Property

```csharp
public string Id { get; }
```

### Berechnete Property

```csharp
public bool IstBesiegt
{
    get { return Leben <= 0; }
}
```

### Verkürzt

```csharp
public bool IstBesiegt => Leben <= 0;
```

### Property mit eigener Logik

```csharp
private int alter;

public int Alter
{
    get
    {
        return alter;
    }
    set
    {
        if (value >= 0)
        {
            alter = value;
        }
    }
}
```

### `init` Property

```csharp
public string Name { get; init; }
```

```csharp
Spieler spieler = new Spieler
{
    Name = "Alex"
};
```

---

## 11.3 Konstruktor

```csharp
internal class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }

    public Spieler(string name, int leben)
    {
        Name = name;
        Leben = leben;
    }
}
```

```csharp
Spieler spieler = new Spieler("Alex", 100);
```

### Mit `this`

```csharp
public Spieler(string name, int leben)
{
    this.Name = name;
    this.Leben = leben;
}
```

### Standardwert

```csharp
public Spieler(string name, int leben = 100)
{
    Name = name;
    Leben = leben;
}
```

```csharp
Spieler spieler = new Spieler("Alex");
```

### Mehrere Konstruktoren

```csharp
public Spieler()
{
    Name = "Unbekannt";
    Leben = 100;
}

public Spieler(string name)
{
    Name = name;
    Leben = 100;
}
```

---

## 11.4 Methoden in Klassen

```csharp
internal class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; } = 100;

    public void SchadenErhalten(int schaden)
    {
        if (schaden <= 0)
        {
            return;
        }

        Leben -= schaden;

        if (Leben < 0)
        {
            Leben = 0;
        }
    }

    public bool IstBesiegt()
    {
        return Leben <= 0;
    }
}
```

---

## 11.5 Kapselung

### Property schützen

```csharp
public int Leben { get; private set; }
```

### Kontrollierte Änderung

```csharp
public void Heilen(int heilung)
{
    if (heilung <= 0)
    {
        return;
    }

    Leben += heilung;
}
```

### Vollständig privates Feld

```csharp
private int leben;
```

## Zugriffsmodifizierer

| Modifizierer | Zugriff |
|---|---|
| `public` | Von überall |
| `private` | Nur innerhalb derselben Klasse |
| `protected` | Klasse und abgeleitete Klassen |
| `internal` | Innerhalb desselben Projekts |

---

## 11.6 Objekte verbinden

### Objekt als Property

```csharp
internal class Quest
{
    public string Titel { get; set; }
    public Belohnung Belohnung { get; set; }
}
```

### Objekt als Parameter

```csharp
public void QuestAnnehmen(Quest quest)
{
    Console.WriteLine($"Quest angenommen: {quest.Titel}");
}
```

### Liste von Objekten

```csharp
public List<Item> Inventar { get; private set; } = new();
```

```csharp
public void ItemHinzufuegen(Item item)
{
    Inventar.Add(item);
}
```

## Typische Use Cases

1. Spieler mit Eigenschaften und Methoden
2. Produkte mit Preis und Lagerbestand
3. Schüler mit Name und Noten
4. Quest mit Belohnung
5. Bibliothek mit einer Liste von Büchern

---

# 12. Vererbung und Polymorphie
[Zurück Inhaltsverzeichnis](#inhaltsverzeichnis)
## Basisklasse

```csharp
internal class Lebewesen
{
    public string Name { get; set; }
    public int Leben { get; protected set; }

    public Lebewesen(string name, int leben)
    {
        Name = name;
        Leben = leben;
    }
}
```

## Abgeleitete Klasse

```csharp
internal class Spieler : Lebewesen
{
    public Spieler(string name, int leben)
        : base(name, leben)
    {
    }
}
```

## `base`

Ruft den Konstruktor der Basisklasse auf.

```csharp
public Magier(string name, int leben, int mana)
    : base(name, leben)
{
    Mana = mana;
}
```

## `protected`

```csharp
public int Leben { get; protected set; }
```

Kann in der Basisklasse und in abgeleiteten Klassen verändert werden.

## Virtuelle Methode

```csharp
internal class Gegner
{
    public virtual void AktionAusfuehren()
    {
        Console.WriteLine("Der Gegner führt eine Aktion aus.");
    }
}
```

## Methode überschreiben

```csharp
internal class Goblin : Gegner
{
    public override void AktionAusfuehren()
    {
        Console.WriteLine("Der Goblin stiehlt Gold.");
    }
}
```

## Basismethode zusätzlich aufrufen

```csharp
public override void AktionAusfuehren()
{
    base.AktionAusfuehren();
    Console.WriteLine("Zusätzliche Goblin-Aktion");
}
```

## Polymorphie

```csharp
List<Gegner> gegnerListe = new()
{
    new Goblin(),
    new Wolf(),
    new Raeuber()
};

foreach (Gegner gegner in gegnerListe)
{
    gegner.AktionAusfuehren();
}
```

Jedes Objekt führt seine eigene überschriebene Methode aus.

## Mehrstufige Vererbung

```text
Lebewesen
├── Spieler
│   ├── Magier
│   ├── Bogenschuetze
│   └── Schwertkaempfer
└── Gegner
    ├── Goblin
    ├── Wolf
    └── Raeuber
```

```csharp
internal class Magier : Spieler
{
    public int Mana { get; set; }

    public Magier(string name, int leben, int mana)
        : base(name, leben)
    {
        Mana = mana;
    }
}
```

## Gemeinsame Liste der Basisklasse

```csharp
List<Lebewesen> lebewesen = new()
{
    new Magier("Merlin", 100, 50),
    new Goblin("Grim", 40)
};
```

## Ist-ein-Beziehung

```text
Ein Magier ist ein Spieler.
Ein Spieler ist ein Lebewesen.
Ein Goblin ist ein Gegner.
Ein Gegner ist ein Lebewesen.
```

## Wichtige Schlüsselwörter

| Schlüsselwort | Bedeutung |
|---|---|
| `:` | Von einer Klasse erben |
| `base(...)` | Basiskonstruktor aufrufen |
| `protected` | Zugriff für Klasse und Unterklassen |
| `virtual` | Methode darf überschrieben werden |
| `override` | Methode wird überschrieben |

## Typische Use Cases

1. Verschiedene Charakterklassen
2. Verschiedene Fahrzeugarten
3. Verschiedene Medien wie Buch, Film und Spiel
4. Verschiedene Schulpersonen wie Schüler und Lehrer
5. Verschiedene Produkte mit gemeinsamem Grundaufbau

---

# Häufige Fehler

```csharp
// Falsch: Zuweisung statt Vergleich
if (zahl = 5)
```

```csharp
// Richtig
if (zahl == 5)
```

```csharp
// Falsch: Index zu groß
int[] zahlen = new int[3];
Console.WriteLine(zahlen[3]);
```

```csharp
// Richtig: letzter Index ist Length - 1
Console.WriteLine(zahlen[zahlen.Length - 1]);
```

```csharp
// Array
zahlen.Length;

// Liste und Dictionary
namen.Count;
punkte.Count;
```

```csharp
// Strings mit doppelten Anführungszeichen
string name = "Alex";

// Chars mit einfachen Anführungszeichen
char zeichen = 'A';
```

```csharp
// Kommazahlen
float zahl1 = 2.5f;
decimal zahl2 = 2.5m;
double zahl3 = 2.5;
```

---

# Mini-Übersicht

```csharp
// Ausgabe
Console.WriteLine("Text");

// Eingabe
string eingabe = Console.ReadLine();

// Sichere Zahleneingabe
int.TryParse(Console.ReadLine(), out int zahl);

// Bedingung
if (zahl > 0) { }
else if (zahl == 0) { }
else { }

// Kurzbedingung
string text = zahl > 0 ? "Positiv" : "Nicht positiv";

// Switch
switch (zahl)
{
    case 1:
        break;
    default:
        break;
}

// Schleifen
while (zahl > 0) { }
do { } while (zahl > 0);
for (int i = 0; i < 10; i++) { }
foreach (int wert in zahlen) { }

// Array
int[] array = { 1, 2, 3 };

// Liste
List<int> liste = new() { 1, 2, 3 };

// Dictionary
Dictionary<string, int> dictionary = new()
{
    { "Alex", 100 }
};

// Methode
static int Addieren(int a, int b) => a + b;

// Objekt
Spieler spieler = new Spieler("Alex", 100);

// Vererbung
internal class Magier : Spieler
{
    public Magier(string name, int leben)
        : base(name, leben)
    {
    }
}
```

---

# 13. Commands

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

1. [Strings](#131-strings)
2. [Zahlen](#132-zahlen)
3. [Zufallszahlen](#133-zufallszahlen)
4. [Arrays](#134-arrays)
5. [Listen](#135-listen)
6. [Dictionaries](#136-dictionaries)
7. [Console](#137-console)
8. [Bedingungen](#138-bedingungen)
9. [Switch](#139-switch)
10. [Schleifen](#1310-schleifen)
11. [Methoden](#1311-methoden)
12. [Klassen und Objekte](#1312-klassen-und-objekte)
13. [Properties](#1313-properties)
14. [Konstruktoren](#1314-konstruktoren)
15. [Access Modifier](#1315-access-modifier)
16. [Vererbung](#1316-vererbung)
17. [Polymorphie](#1317-polymorphie)
18. [Typen prüfen und umwandeln](#1318-typen-prüfen-und-umwandeln)
19. [Null Werte](#1319-null-werte)
20. [Datum und Uhrzeit](#1320-datum-und-uhrzeit)
21. [Dateien](#1321-dateien)
22. [Exceptions](#1322-exceptions)
23. [Kommentare und Regionen](#1323-kommentare-und-regionen)
24. [Nützliche Schlüsselwörter](#1324-nützliche-schlüsselwörter)

## 13.1 Strings
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
string text = "Hallo";

text.Length;                  // Länge
text.ToUpper();               // Großbuchstaben
text.ToLower();               // Kleinbuchstaben

text.Trim();                  // Leerzeichen außen entfernen
text.TrimStart();             // Leerzeichen vorne entfernen
text.TrimEnd();               // Leerzeichen hinten entfernen

text.Contains("all");         // Enthält Text
text.StartsWith("Ha");        // Beginnt mit
text.EndsWith("lo");          // Endet mit

text.IndexOf("l");            // Erste Position
text.LastIndexOf("l");        // Letzte Position

text.Replace("Hallo", "Hi");  // Text ersetzen
text.Remove(2);               // Ab Position entfernen
text.Remove(2, 2);            // Bereich entfernen

text.Substring(1);            // Ab Position ausschneiden
text.Substring(1, 3);         // Bereich ausschneiden

text.Split(' ');              // String aufteilen
string.Join(", ", array);     // Werte zusammenfügen

string.IsNullOrEmpty(text);       // null oder leer
string.IsNullOrWhiteSpace(text);  // null, leer oder Leerzeichen
```

```csharp
string name = "Dani";

$"Hallo {name}";     // String-Interpolation
```

---

## 13.2 Zahlen
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
int.Parse("10");
double.Parse("10,5");

int.TryParse(eingabe, out int zahl);
double.TryParse(eingabe, out double wert);

Convert.ToInt32(wert);
Convert.ToDouble(wert);
Convert.ToString(wert);
```

```csharp
Math.Abs(-10);          // Betrag
Math.Round(5.67);       // Runden
Math.Floor(5.67);       // Abrunden
Math.Ceiling(5.12);     // Aufrunden

Math.Min(5, 10);        // Kleinster Wert
Math.Max(5, 10);        // Größter Wert

Math.Pow(2, 3);         // Potenz
Math.Sqrt(16);          // Quadratwurzel
```

---

## 13.3 Zufallszahlen
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
Random random = new Random();

random.Next(10);        // 0 bis 9
random.Next(1, 11);     // 1 bis 10
random.NextDouble();    // 0.0 bis kleiner als 1.0
```

---

## 13.4 Arrays
[Zurück zum Inhaltsverzeichnis](#13-commands)

```csharp
int[] zahlen = { 5, 2, 8 };

zahlen.Length;                  // Anzahl der Elemente
zahlen[0];                      // Element an Index 0 lesen
zahlen[0] = 10;                 // Element an Index 0 ändern

Array.Sort(zahlen);             // Elemente aufsteigend sortieren
Array.Reverse(zahlen);          // Reihenfolge der Elemente umdrehen

Array.IndexOf(zahlen, 8);       // Index eines Elements suchen
Array.Clear(zahlen);            // Alle Elemente auf Standardwerte setzen
```

> `Array.IndexOf()` gibt `-1` zurück, wenn das Element nicht gefunden wurde.

---

## 13.5 Listen
[Zurück zum Inhaltsverzeichnis](#13-commands)

```csharp
List<string> namen = new List<string>();

namen.Add("Dani");              // Einzelnes Element hinzufügen
namen.AddRange(neueNamen);      // Mehrere Elemente hinzufügen

namen.Insert(0, "Alex");        // Element an einem Index einfügen

namen.Remove("Dani");           // Erstes passendes Element entfernen
namen.RemoveAt(0);              // Element an einem Index entfernen
namen.Clear();                  // Alle Elemente entfernen

namen.Contains("Dani");         // Prüfen, ob ein Element enthalten ist
namen.IndexOf("Dani");          // Index eines Elements suchen

namen.Count;                    // Anzahl der Elemente
namen.Sort();                   // Elemente aufsteigend sortieren
namen.Reverse();                // Reihenfolge der Elemente umdrehen
```

```csharp
namen.First();                  // Erstes Element zurückgeben
namen.Last();                   // Letztes Element zurückgeben
```

> `IndexOf()` gibt `-1` zurück, wenn das Element nicht gefunden wurde.

---

## 13.6 Dictionaries
[Zurück zum Inhaltsverzeichnis](#13-commands)

```csharp
Dictionary<string, int> punkte =
    new Dictionary<string, int>();

punkte.Add("Dani", 10);         // Neuen Schlüssel mit Wert hinzufügen
punkte["Dani"] = 20;            // Wert hinzufügen oder überschreiben

punkte["Dani"];                 // Wert über den Schlüssel abrufen

punkte.ContainsKey("Dani");     // Prüfen, ob ein Schlüssel existiert
punkte.ContainsValue(20);       // Prüfen, ob ein Wert existiert

punkte.Remove("Dani");          // Eintrag über den Schlüssel entfernen
punkte.Clear();                 // Alle Einträge entfernen

punkte.Count;                   // Anzahl der Einträge
punkte.Keys;                    // Sammlung aller Schlüssel
punkte.Values;                  // Sammlung aller Werte
```

```csharp
punkte.TryGetValue(
    "Dani",
    out int wert
);                              // Wert sicher über den Schlüssel abrufen
```

> `TryGetValue()` gibt `true` zurück, wenn der Schlüssel gefunden wurde.

---

## 13.7 Console
[Zurück zum Inhaltsverzeichnis](#13-commands)

```csharp
Console.WriteLine("Text");       // Text mit Zeilenumbruch ausgeben
Console.Write("Text");           // Text ohne Zeilenumbruch ausgeben

Console.ReadLine();              // Eine vollständige Zeile einlesen
Console.ReadKey();               // Einen einzelnen Tastendruck einlesen

Console.Clear();                 // Konsoleninhalt löschen

Console.ForegroundColor =
    ConsoleColor.Green;          // Schriftfarbe ändern

Console.BackgroundColor =
    ConsoleColor.Black;          // Hintergrundfarbe ändern

Console.ResetColor();            // Farben auf Standard zurücksetzen
```

---

## 13.8 Bedingungen
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
if (bedingung)
{
}
```

```csharp
if (bedingung)
{
}
else
{
}
```

```csharp
if (bedingung)
{
}
else if (andereBedingung)
{
}
else
{
}
```

### Kurzschreibweise

```csharp
string status = alter >= 18
    ? "Volljährig"
    : "Minderjährig";
```

### Vergleichsoperatoren

```csharp
==      // Gleich
!=      // Ungleich

<       // Kleiner
>       // Größer

<=      // Kleiner oder gleich
>=      // Größer oder gleich
```

### Logische Operatoren

```csharp
&&      // UND
||      // ODER
!       // NICHT
```

---

## 13.9 Switch
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
switch (wert)
{
    case 1:
        break;

    case 2:
        break;

    default:
        break;
}
```

### Switch Expression

```csharp
string text = wert switch
{
    1 => "Eins",
    2 => "Zwei",
    _ => "Unbekannt"
};
```

---

## 13.10 Schleifen
[Zurück zum Inhaltsverzeichnis](#13-commands)
### While

```csharp
while (bedingung)
{
}
```

### Do-While

```csharp
do
{
}
while (bedingung);
```

### For

```csharp
for (int i = 0; i < 10; i++)
{
}
```

### Foreach

```csharp
foreach (var name in namen)
{
}
```

### Schleifenbefehle

```csharp
break;       // Schleife beenden
continue;    // Nächsten Durchlauf starten
```

---

## 13.11 Methoden
[Zurück zum Inhaltsverzeichnis](#13-commands)
### Ohne Parameter und Rückgabewert

```csharp
static void Begruessen()
{
}
```

### Mit Parameter

```csharp
static void Begruessen(string name)
{
}
```

### Mit Rückgabewert

```csharp
static int Addieren(int zahl1, int zahl2)
{
    return zahl1 + zahl2;
}
```

### Mehrere Parameter

```csharp
static void Anzeigen(string name, int alter)
{
}
```

---

## 13.12 Klassen und Objekte
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
Spieler spieler = new Spieler();
```

```csharp
Spieler spieler = new Spieler("Dani");
```

```csharp
spieler.Name;
spieler.Name = "Dani";

spieler.Bewegen();
```

---

## 13.13 Properties
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
public string Name { get; set; }
```

```csharp
public string Name { get; private set; }
```

```csharp
public string Name { get; init; }
```

```csharp
private int alter;

public int Alter
{
    get
    {
        return alter;
    }

    set
    {
        alter = value;
    }
}
```

### Kurzschreibweise

```csharp
public int Alter
{
    get => alter;
    set => alter = value;
}
```

---

## 13.14 Konstruktoren
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
public Spieler()
{
}
```

```csharp
public Spieler(string name)
{
    Name = name;
}
```

### Konstruktorverkettung

```csharp
public Spieler(string name)
    : this()
{
    Name = name;
}
```

### Basiskonstruktor

```csharp
public Magier(string name)
    : base(name)
{
}
```

---

## 13.15 Access Modifier
[Zurück zum Inhaltsverzeichnis](#13-commands)
| Modifier             | Zugriff                              |
| -------------------- | ------------------------------------ |
| `public`             | Überall                              |
| `private`            | Nur eigene Klasse                    |
| `protected`          | Eigene und erbende Klassen           |
| `internal`           | Nur im selben Projekt                |
| `protected internal` | Gleiches Projekt oder erbende Klasse |
| `private protected`  | Gleiches Projekt und erbende Klasse  |

---

## 13.16 Vererbung
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
public class Magier : Spieler
{
}
```

```csharp
public Magier(string name)
    : base(name)
{
}
```

```csharp
base.Methode();
```

---

## 13.17 Polymorphie
[Zurück zum Inhaltsverzeichnis](#13-commands)
### Virtual

```csharp
public virtual void Anzeigen()
{
}
```

### Override

```csharp
public override void Anzeigen()
{
}
```

### Polymorphe Liste

```csharp
List<Tier> tiere = new List<Tier>();

tiere.Add(new Hund());
tiere.Add(new Katze());
```

---

## 13.18 Typen prüfen und umwandeln
[Zurück zum Inhaltsverzeichnis](#13-commands)
### Is

```csharp
objekt is Spieler;
```

```csharp
if (objekt is Spieler spieler)
{
}
```

### As

```csharp
Spieler? spieler = objekt as Spieler;
```

### Direkter Cast

```csharp
Spieler spieler = (Spieler)objekt;
```

### Typ abfragen

```csharp
objekt.GetType();
```

---

## 13.19 Null-Werte
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
string? text = null;
```

```csharp
text == null;
text != null;
```

### Null Conditional Operator

```csharp
text?.ToUpper();
```

### Null Coalescing Operator

```csharp
string ausgabe = text ?? "Unbekannt";
```

### Wert nur bei null setzen

```csharp
text ??= "Standard";
```

### Null-Unterdrückung

```csharp
text!.ToUpper();
```

---

## 13.20 Datum und Uhrzeit
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
DateTime.Now;
DateTime.Today;
```

```csharp
DateTime datum = new DateTime(2026, 7, 19);
```

```csharp
datum.Day;
datum.Month;
datum.Year;

datum.Hour;
datum.Minute;
datum.Second;
```

```csharp
datum.AddDays(1);
datum.AddMonths(1);
datum.AddYears(1);
```

```csharp
datum.ToString("dd.MM.yyyy");
datum.ToString("HH:mm");
datum.ToString("dd.MM.yyyy HH:mm");
```

```csharp
DateTime.Parse("19.07.2026");

DateTime.TryParse(
    eingabe,
    out DateTime datum
);
```

---

## 13.21 Dateien

```csharp
File.WriteAllText(
    "datei.txt",
    text
);
```

```csharp
File.AppendAllText(
    "datei.txt",
    text
);
```

```csharp
string text =
    File.ReadAllText("datei.txt");
```

```csharp
File.Exists("datei.txt");
File.Delete("datei.txt");
```

```csharp
File.WriteAllLines(
    "datei.txt",
    zeilen
);
```

```csharp
string[] zeilen =
    File.ReadAllLines("datei.txt");
```

---

## 13.22 Exceptions
[Zurück zum Inhaltsverzeichnis](#13-commands)
### Try-Catch-Finally

```csharp
try
{
    // Fehleranfälliger Code
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    // Wird immer ausgeführt
}
```

### Häufige Exceptions

| Exception                     | Häufige Parameter                                                           | Bedeutung                                 |
| ----------------------------- | --------------------------------------------------------------------------- | ----------------------------------------- |
| `Exception`                   | `message`<br>`message, innerException`                                      | Allgemeiner Fehler                        |
| `ArgumentException`           | `message`<br>`message, paramName`<br>`message, paramName, innerException`   | Ungültiges Argument                       |
| `ArgumentNullException`       | `paramName`<br>`paramName, message`<br>`paramName, message, innerException` | Argument ist `null`                       |
| `ArgumentOutOfRangeException` | `paramName`<br>`paramName, message`<br>`paramName, actualValue, message`    | Argument außerhalb des erlaubten Bereichs |
| `NullReferenceException`      | `message`<br>`message, innerException`                                      | Zugriff auf ein Objekt mit `null`         |
| `IndexOutOfRangeException`    | `message`<br>`message, innerException`                                      | Ungültiger Array-Index                    |
| `KeyNotFoundException`        | `message`<br>`message, innerException`                                      | Dictionary-Schlüssel nicht gefunden       |
| `InvalidOperationException`   | `message`<br>`message, innerException`                                      | Operation im aktuellen Zustand ungültig   |
| `FormatException`             | `message`<br>`message, innerException`                                      | Ungültiges Format                         |
| `OverflowException`           | `message`<br>`message, innerException`                                      | Zahl zu groß oder zu klein                |
| `DivideByZeroException`       | `message`<br>`message, innerException`                                      | Division durch null                       |
| `FileNotFoundException`       | `message`<br>`message, fileName`<br>`message, fileName, innerException`     | Datei nicht gefunden                      |
| `DirectoryNotFoundException`  | `message`<br>`message, innerException`                                      | Ordner nicht gefunden                     |
| `IOException`                 | `message`<br>`message, innerException`                                      | Allgemeiner Dateifehler                   |
| `UnauthorizedAccessException` | `message`<br>`message, innerException`                                      | Keine Berechtigung                        |
| `NotImplementedException`     | `message`<br>`message, innerException`                                      | Methode noch nicht umgesetzt              |
| `NotSupportedException`       | `message`<br>`message, innerException`                                      | Operation nicht unterstützt               |
| `TimeoutException`            | `message`<br>`message, innerException`                                      | Zeitüberschreitung                        |

### Mehrere Exceptions behandeln

```csharp
try
{
    int zahl = int.Parse(
        Console.ReadLine()
    );
}
catch (FormatException)
{
    Console.WriteLine(
        "Ungültiges Zahlenformat."
    );
}
catch (OverflowException)
{
    Console.WriteLine(
        "Die Zahl ist zu groß."
    );
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
```

### Exception selbst auslösen

```csharp
throw new Exception(
    "Allgemeiner Fehler."
);
```

```csharp
throw new ArgumentException(
    "Der Name ist ungültig.",
    nameof(name)
);
```

```csharp
throw new ArgumentNullException(
    nameof(name),
    "Der Name darf nicht null sein."
);
```

```csharp
throw new ArgumentOutOfRangeException(
    nameof(alter),
    alter,
    "Das Alter muss zwischen 0 und 120 liegen."
);
```

```csharp
throw new InvalidOperationException(
    "Diese Aktion ist derzeit nicht möglich."
);
```

```csharp
throw new FileNotFoundException(
    "Die Datei wurde nicht gefunden.",
    dateiName
);
```

```csharp
throw new NotImplementedException(
    "Diese Methode wurde noch nicht umgesetzt."
);
```

### Parameterreihenfolge

```csharp
new ArgumentException(
    message,
    paramName
);
```

```csharp
new ArgumentNullException(
    paramName,
    message
);
```

```csharp
new ArgumentOutOfRangeException(
    paramName,
    actualValue,
    message
);
```

```csharp
new FileNotFoundException(
    message,
    fileName
);
```

### Bedingung prüfen

```csharp
if (name == null)
{
    throw new ArgumentNullException(
        nameof(name)
    );
}
```

```csharp
if (alter < 0)
{
    throw new ArgumentOutOfRangeException(
        nameof(alter),
        alter,
        "Das Alter darf nicht negativ sein."
    );
}
```

```csharp
if (string.IsNullOrWhiteSpace(name))
{
    throw new ArgumentException(
        "Der Name darf nicht leer sein.",
        nameof(name)
    );
}
```

### Exception-Informationen

```csharp
catch (Exception ex)
{
    ex.Message;
    ex.StackTrace;
    ex.InnerException;
    ex.GetType();
}
```

### Exception weiterwerfen

```csharp
catch (Exception)
{
    throw;
}
```

### Eigene Exception

```csharp
public class UngueltigerSpielerException
    : Exception
{
    public UngueltigerSpielerException(
        string message
    )
        : base(message)
    {
    }
}
```

```csharp
throw new UngueltigerSpielerException(
    "Der Spieler ist ungültig."
);
```

---

## 13.23 Kommentare und Regionen
[Zurück zum Inhaltsverzeichnis](#13-commands)
### Einzeiliger Kommentar

```csharp
// Einzeiliger Kommentar
```

### Mehrzeiliger Kommentar

```csharp
/*
    Mehrzeiliger Kommentar
*/
```

### Regionen

```csharp
#region Methoden

#endregion
```

---

## 13.24 Nützliche Schlüsselwörter
[Zurück zum Inhaltsverzeichnis](#13-commands)
```csharp
this.Name = name;      // Aktuelles Objekt
base.Methode();        // Basisklasse

return wert;           // Wert zurückgeben
return;                // Methode beenden

new Spieler();         // Objekt erstellen

static                  // Gehört zur Klasse
const                   // Konstanter Wert
readonly                // Nur einmal setzen

virtual                 // Überschreibbar
override                // Überschreibt Methode
abstract                // Muss umgesetzt werden

sealed                   // Vererbung verhindern
```