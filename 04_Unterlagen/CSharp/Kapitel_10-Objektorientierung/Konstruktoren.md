# Konstruktoren in C#

## 1. Was ist ein Konstruktor?

Ein **Konstruktor** ist eine besondere Methode einer Klasse.

Er wird automatisch ausgeführt, wenn ein neues Objekt erstellt wird.

```csharp
Schueler s1 = new Schueler();
```

Bei `new Schueler()` wird der Konstruktor der Klasse `Schueler` aufgerufen.

Man kann sich merken:

```text
Konstruktor = Start-Methode eines Objekts
```

Oder einfacher:

```text
Der Konstruktor bereitet ein neues Objekt vor.
```

---

## 2. Wofür braucht man Konstruktoren?

Konstruktoren verwendet man, um einem Objekt direkt beim Erstellen Startwerte zu geben.

Ohne Konstruktor:

```csharp
Schueler s1 = new Schueler();
s1.Name = "Max";
s1.Alter = 16;
```

Mit Konstruktor:

```csharp
Schueler s1 = new Schueler("Max", 16);
```

Das Objekt bekommt seine wichtigsten Werte also direkt beim Erstellen.

---

## 3. Klasse ohne eigenen Konstruktor

Wenn man keinen Konstruktor schreibt, erstellt C# automatisch einen leeren Konstruktor im Hintergrund.

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }
}
```

Dann kann man ein Objekt so erstellen:

```csharp
Schueler s1 = new Schueler();
```

Gedanklich existiert im Hintergrund ungefähr dieser Konstruktor:

```csharp
public Schueler()
{
}
```

Dieser Konstruktor macht nichts Besonderes, erlaubt aber das Erstellen eines Objekts.

---

## 4. Eigener Konstruktor

Ein Konstruktor hat immer denselben Namen wie die Klasse.

Beispiel:

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }

    public Schueler(string name, int alter)
    {
        Name = name;
        Alter = alter;
    }
}
```

Verwendung:

```csharp
Schueler s1 = new Schueler("Max", 16);

Console.WriteLine(s1.Name);
Console.WriteLine(s1.Alter);
```

Ausgabe:

```text
Max
16
```

---

## 5. Aufbau eines Konstruktors

```csharp
public Schueler(string name, int alter)
{
    Name = name;
    Alter = alter;
}
```

| Teil | Bedeutung |
|---|---|
| `public` | Der Konstruktor ist von außen aufrufbar |
| `Schueler` | Name des Konstruktors, muss gleich heißen wie die Klasse |
| `(string name, int alter)` | Parameter, die beim Erstellen übergeben werden |
| `{ ... }` | Code, der beim Erstellen ausgeführt wird |

Wichtig:

```text
Ein Konstruktor hat keinen Rückgabetyp.
```

Also nicht:

```csharp
public void Schueler(string name, int alter)
{
}
```

Das wäre kein Konstruktor, sondern eine normale Methode.

---

## 6. Parameter und Properties

Im Konstruktor werden oft Parameter an Properties übergeben.

```csharp
public Schueler(string name, int alter)
{
    Name = name;
    Alter = alter;
}
```

Dabei gilt:

```text
name  = Parameter
Name  = Property
alter = Parameter
Alter = Property
```

Man schreibt häufig die Parameter klein und die Properties groß.

```csharp
Name = name;
Alter = alter;
```

Das bedeutet:

```text
Speichere den übergebenen Parameterwert in der Property des Objekts.
```

---

## 7. Konstruktor mit Standardwerten

Ein Konstruktor kann auch feste Startwerte setzen.

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Punkte { get; set; }

    public Spieler(string name)
    {
        Name = name;
        Punkte = 0;
    }
}
```

Verwendung:

```csharp
Spieler spieler1 = new Spieler("Lena");

Console.WriteLine(spieler1.Name);
Console.WriteLine(spieler1.Punkte);
```

Ausgabe:

```text
Lena
0
```

Hier muss man beim Erstellen nur den Namen angeben. Die Punkte starten automatisch bei `0`.

---

## 8. Mehrere Konstruktoren

Eine Klasse kann mehrere Konstruktoren haben.

Das nennt man **Konstruktorüberladung**.

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Punkte { get; set; }

    public Spieler()
    {
        Name = "Unbekannt";
        Punkte = 0;
    }

    public Spieler(string name)
    {
        Name = name;
        Punkte = 0;
    }

    public Spieler(string name, int punkte)
    {
        Name = name;
        Punkte = punkte;
    }
}
```

Verwendung:

```csharp
Spieler s1 = new Spieler();
Spieler s2 = new Spieler("Lena");
Spieler s3 = new Spieler("Max", 100);
```

Die Anzahl und Art der Parameter entscheidet, welcher Konstruktor verwendet wird.

---

## 9. Konstruktor mit `this`

Wenn Parameter und Properties gleich heißen, verwendet man `this`.

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }

    public Schueler(string Name, int Alter)
    {
        this.Name = Name;
        this.Alter = Alter;
    }
}
```

`this` bedeutet:

```text
Dieses aktuelle Objekt
```

Also:

```csharp
this.Name = Name;
```

Bedeutet:

```text
Speichere den Parameter Name in die Property Name dieses Objekts.
```

In einfachen Schulbeispielen ist diese Schreibweise oft übersichtlicher:

```csharp
public Schueler(string name, int alter)
{
    Name = name;
    Alter = alter;
}
```

---

## 10. Konstruktor und Validierung

Ein Konstruktor kann auch prüfen, ob Werte gültig sind.

```csharp
class Produkt
{
    public string Name { get; set; }
    public double Preis { get; set; }

    public Produkt(string name, double preis)
    {
        Name = name;

        if (preis >= 0)
        {
            Preis = preis;
        }
        else
        {
            Preis = 0;
        }
    }
}
```

Verwendung:

```csharp
Produkt p1 = new Produkt("Tastatur", 49.99);
Produkt p2 = new Produkt("Maus", -10);

Console.WriteLine(p1.Preis);
Console.WriteLine(p2.Preis);
```

Ausgabe:

```text
49.99
0
```

Der Konstruktor verhindert hier, dass ein negativer Preis gespeichert wird.

---

## 11. Konstruktor und private set

Properties können so gebaut werden, dass sie von außen gelesen, aber nicht verändert werden dürfen.

```csharp
class Konto
{
    public string Besitzer { get; private set; }
    public double Kontostand { get; private set; }

    public Konto(string besitzer, double startbetrag)
    {
        Besitzer = besitzer;
        Kontostand = startbetrag;
    }
}
```

Verwendung:

```csharp
Konto k1 = new Konto("Max", 100);

Console.WriteLine(k1.Besitzer);
Console.WriteLine(k1.Kontostand);
```

Das geht nicht:

```csharp
k1.Kontostand = 500;
```

Weil `set` privat ist.

Das bedeutet:

```text
Von außen darf der Wert gelesen werden.
Von außen darf der Wert aber nicht direkt verändert werden.
```

Der Startwert wird trotzdem im Konstruktor gesetzt.

---

## 12. Komplette Beispielklasse

```csharp
using System;

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

    public void Ausgabe()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Alter: {Alter}");
        Console.WriteLine($"Klasse: {Klasse}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Schueler s1 = new Schueler("Max", 16, "2AHIT");
        Schueler s2 = new Schueler("Lena", 17, "2AHIT");

        s1.Ausgabe();
        Console.WriteLine();
        s2.Ausgabe();
    }
}
```

Mögliche Ausgabe:

```text
Name: Max
Alter: 16
Klasse: 2AHIT

Name: Lena
Alter: 17
Klasse: 2AHIT
```

---

## 13. Typische Fehler

### Fehler 1: Konstruktor mit Rückgabetyp

Falsch:

```csharp
public void Schueler(string name)
{
    Name = name;
}
```

Richtig:

```csharp
public Schueler(string name)
{
    Name = name;
}
```

---

### Fehler 2: Konstruktor heißt nicht wie die Klasse

Falsch:

```csharp
class Schueler
{
    public Student(string name)
    {
    }
}
```

Richtig:

```csharp
class Schueler
{
    public Schueler(string name)
    {
    }
}
```

---

### Fehler 3: Falsche Anzahl an Parametern

Wenn die Klasse diesen Konstruktor hat:

```csharp
public Schueler(string name, int alter)
{
    Name = name;
    Alter = alter;
}
```

Dann muss man beim Erstellen auch beide Werte übergeben:

```csharp
Schueler s1 = new Schueler("Max", 16);
```

Das wäre falsch:

```csharp
Schueler s1 = new Schueler();
```

Außer man schreibt zusätzlich einen leeren Konstruktor.

---

## 14. Merksätze

```text
Ein Konstruktor wird automatisch beim Erstellen eines Objekts ausgeführt.
```

```text
Der Konstruktor heißt immer genau gleich wie die Klasse.
```

```text
Ein Konstruktor hat keinen Rückgabetyp, auch nicht void.
```

```text
Mit einem Konstruktor gibt man einem Objekt Startwerte.
```

```text
Mehrere Konstruktoren in einer Klasse nennt man Konstruktorüberladung.
```