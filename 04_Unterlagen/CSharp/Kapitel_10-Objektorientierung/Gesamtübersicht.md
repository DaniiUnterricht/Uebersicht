<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Objektorientierung – Gesamtunterlage

## Einordnung

Nach **Arrays**, **Listen** und **Dictionaries** ist **Objektorientierung** der nächste große Schritt.

Bisher wurden zusammengehörige Daten oft getrennt gespeichert oder im Dictionary mit maximal 2 Werten:

```csharp
List<string> namen = new List<string>();
List<int> alter = new List<int>();
List<string> klassen = new List<string>();

Dictionary<string, int> personen = new Dictionary<string, int>();
```

Das funktioniert bei kleinen Programmen, wird aber schnell unübersichtlich. Name, Alter und Klasse gehören eigentlich zu **einem Schüler**.

Objektorientierung löst genau dieses Problem:

```text
Daten + Verhalten = Objekt
```

Ein Objekt speichert also Daten und kann zusätzlich Methoden besitzen.

```text
Schueler
├─ Name
├─ Alter
├─ Klasse
└─ StelleDichVor()
```

---

## 1. Klassen und Objekte

Eine **Klasse** ist ein Bauplan.

Ein **Objekt** ist ein konkretes Ding, das nach diesem Bauplan erstellt wurde.

```text
Klasse → Bauplan
Objekt → echtes Ding im Programm
```

Vergleich aus der echten Welt:

```text
Bauplan: Haus
Objekte: Haus 1, Haus 2, Haus 3
```

In der Programmierung:

```text
Klasse: Schueler
Objekte: Max, Anna, Lena
```

Alle Objekte derselben Klasse haben dieselbe Grundstruktur, aber unterschiedliche Werte.

---

## 2. Erste Klasse erstellen

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }
    public string Klasse { get; set; }
}
```

Diese Class beschreibt, dass ein Schüler einen Namen, ein Alter und eine Klasse besitzt.

Wichtig:

```text
Die Class ist noch kein echter Schüler.
Sie ist nur der Bauplan.
```

---

## 3. Objekt erstellen

Ein Objekt wird mit `new` erstellt.

```csharp
Schueler s1 = new Schueler();
```

Danach können Werte gesetzt werden.

```csharp
s1.Name = "Max";
s1.Alter = 16;
s1.Klasse = "2AHIT";
```

Mit dem Punkt greift man auf Eigenschaften eines Objekts zu.

```text
s1.Name
s1.Alter
s1.Klasse
```

---

## 4. Werte ausgeben

```csharp
Console.WriteLine(s1.Name + " ist " + s1.Alter + " Jahre alt.");
Console.WriteLine("Klasse: " + s1.Klasse);
```

### Beispielausgabe

```text
Max ist 16 Jahre alt.
Klasse: 2AHIT
```

---

## 5. Properties

Objekte speichern Daten in Eigenschaften. In C# verwendet man dafür meistens **Properties**.

```csharp
public string Name { get; set; }
public int Alter { get; set; }
```

| Teil | Bedeutung |
|---|---|
| `public` | von außen zugreifbar |
| `get` | Wert darf gelesen werden |
| `set` | Wert darf verändert werden |

Für den Einstieg kann man sich merken:

```text
Property = Eigenschaft eines Objekts
```

Es gibt auch Felder:

```csharp
public string Name;
public int Alter;
```

Für neue C#-Beispiele ist aber die Property-Schreibweise sauberer.

---

## 6. Komplettes erstes Beispiel

```csharp
using System;

namespace OOP_Einstieg
{
    class Schueler
    {
        public string Name { get; set; }
        public int Alter { get; set; }
        public string Klasse { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Schueler s1 = new Schueler();
            s1.Name = "Max";
            s1.Alter = 16;
            s1.Klasse = "2AHIT";

            Schueler s2 = new Schueler();
            s2.Name = "Anna";
            s2.Alter = 17;
            s2.Klasse = "2BHIT";

            Console.WriteLine(s1.Name + " ist " + s1.Alter + " Jahre alt und geht in die " + s1.Klasse + ".");
            Console.WriteLine(s2.Name + " ist " + s2.Alter + " Jahre alt und geht in die " + s2.Klasse + ".");
        }
    }
}
```

---

## 7. Konstruktoren

Ein **Konstruktor** ist eine spezielle Methode, die beim Erstellen eines Objekts automatisch aufgerufen wird.

Ohne Konstruktor:

```csharp
Schueler s1 = new Schueler();
s1.Name = "Max";
s1.Alter = 16;
s1.Klasse = "2AHIT";
```

Mit Konstruktor:

```csharp
Schueler s1 = new Schueler("Max", 16, "2AHIT");
```

Der Konstruktor sorgt dafür, dass das Objekt direkt gültige Startwerte bekommt.

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }
    public string Klasse { get; set; }

    public Schueler(string name, int alter, string klasse)
    {
        Name = name;
        Alter = alter;
        Klasse = klasse;
    }
}
```

Wichtig:

```text
Der Konstruktor heißt genau wie die Klasse.
Ein Konstruktor hat keinen Rückgabetyp.
```

---

## 8. Methoden in Klassen

Eine Klasse kann nicht nur Daten speichern, sondern auch Methoden besitzen.

```text
Daten     → Properties
Verhalten → Methoden
```

Beispiel:

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Punkte { get; set; }

    public Spieler(string name, int punkte)
    {
        Name = name;
        Punkte = punkte;
    }

    public void ZeigeInfo()
    {
        Console.WriteLine(Name + " hat " + Punkte + " Punkte.");
    }
}
```

Aufruf:

```csharp
Spieler spieler1 = new Spieler("Lena", 120);
spieler1.ZeigeInfo();
```

### Beispielausgabe

```text
Lena hat 120 Punkte.
```

---

## 9. Methoden können Werte verändern

```csharp
public void PunkteHinzufuegen(int neuePunkte)
{
    Punkte = Punkte + neuePunkte;
}
```

Aufruf:

```csharp
spieler1.PunkteHinzufuegen(30);
spieler1.ZeigeInfo();
```

### Beispielausgabe

```text
Lena hat 150 Punkte.
```

---

## 10. Methoden mit Rückgabewert

Eine Methode kann auch einen Wert zurückgeben.

```csharp
public bool HatGewonnen()
{
    return Punkte >= 100;
}
```

Aufruf:

```csharp
if (spieler1.HatGewonnen())
{
    Console.WriteLine("Gewonnen!");
}
```

---

## 11. Listen von Objekten

Objektorientierung wird besonders nützlich, wenn mehrere Objekte gespeichert werden.

```csharp
List<Schueler> schuelerListe = new List<Schueler>();
```

Das bedeutet:

```text
Eine Liste, die Schueler-Objekte speichert.
```

Beispiel:

```csharp
using System;
using System.Collections.Generic;

namespace OOP_Liste
{
    class Schueler
    {
        public string Name { get; set; }
        public int Alter { get; set; }

        public Schueler(string name, int alter)
        {
            Name = name;
            Alter = alter;
        }

        public void StelleDichVor()
        {
            Console.WriteLine("Hallo, ich bin " + Name + " und bin " + Alter + " Jahre alt.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Schueler> schuelerListe = new List<Schueler>();

            schuelerListe.Add(new Schueler("Max", 16));
            schuelerListe.Add(new Schueler("Anna", 17));
            schuelerListe.Add(new Schueler("Lena", 16));

            foreach (Schueler schueler in schuelerListe)
            {
                schueler.StelleDichVor();
            }
        }
    }
}
```

### Beispielausgabe

```text
Hallo, ich bin Max und bin 16 Jahre alt.
Hallo, ich bin Anna und bin 17 Jahre alt.
Hallo, ich bin Lena und bin 16 Jahre alt.
```

---

## 12. Eingabe durch Benutzer und Objekt speichern

```csharp
Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Alter: ");
int alter = Convert.ToInt32(Console.ReadLine());

Schueler neuerSchueler = new Schueler(name, alter);
schuelerListe.Add(neuerSchueler);
```

---

## 13. Warum ist `List<Schueler>` besser als mehrere Listen?

Nicht ideal:

```csharp
List<string> namen = new List<string>();
List<int> alter = new List<int>();
```

Besser:

```csharp
List<Schueler> schuelerListe = new List<Schueler>();
```

Weil Name und Alter direkt im selben Objekt zusammengehören.

---

## 14. Mini-Spickzettel

| Schreibweise | Bedeutung |
|---|---|
| `class Schueler` | Klasse erstellen |
| `new Schueler()` | Objekt erstellen |
| `public` | von außen zugreifbar |
| `{ get; set; }` | Property lesen und ändern |
| `public Schueler(...)` | Konstruktor |
| `objekt.Property` | Eigenschaft verwenden |
| `objekt.Methode()` | Methode aufrufen |
| `List<Schueler>` | Liste von Schueler-Objekten |
| `foreach` | Liste durchlaufen |

---

## 15. Typische Fehler

| Fehler | Beispiel | Korrektur |
|---|---|---|
| Klasse und Objekt verwechseln | `Schueler.Name = "Max";` | zuerst Objekt erstellen: `Schueler s1 = new Schueler();` |
| `new` vergessen | `Schueler s1; s1.Name = "Max";` | `Schueler s1 = new Schueler();` |
| Konstruktor falsch aufrufen | `new Schueler()` trotz Pflichtwerten | `new Schueler("Max", 16)` |
| falscher Listentyp | `List<string>` für Schülerobjekte | `List<Schueler>` |
| Property nicht public | `string Name { get; set; }` | `public string Name { get; set; }` |
| Methode ohne Objekt aufrufen | `ZeigeInfo();` | `spieler.ZeigeInfo();` |