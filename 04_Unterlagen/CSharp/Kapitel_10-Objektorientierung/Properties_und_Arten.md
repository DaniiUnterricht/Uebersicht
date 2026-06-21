# Properties und ihre verschiedenen Arten in C#

## 1. Was ist eine Property?

Eine **Property** ist eine Eigenschaft eines Objekts.

Sie speichert Informationen, die zu einem Objekt gehören.

Beispiel:

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }
}
```

Jedes Objekt der Klasse `Schueler` besitzt dadurch einen eigenen `Name` und ein eigenes `Alter`.

```csharp
Schueler s1 = new Schueler();

s1.Name = "Max";
s1.Alter = 16;

Console.WriteLine(s1.Name);
Console.WriteLine(s1.Alter);
```

Ausgabe:

```text
Max
16
```

Merksatz:

```text
Property = Eigenschaft eines Objekts
```

---

## 2. Unterschied zwischen Feld und Property

### Feld

Ein Feld ist eine Variable direkt in einer Klasse.

```csharp
class Schueler
{
    public string Name;
    public int Alter;
}
```

Das funktioniert zwar, ist aber bei öffentlichen Daten meistens nicht die sauberste Lösung.

Bei einem Feld greift man direkt auf den Speicherplatz zu:

```csharp
s1.Alter = -5;
```

Das wäre erlaubt, obwohl ein negatives Alter keinen Sinn ergibt.

---

### Property

Eine Property verwendet `get` und `set` für den Zugriff.

```csharp
class Schueler
{
    public string Name { get; set; }
    public int Alter { get; set; }
}
```

Von außen sieht die Verwendung fast gleich aus:

```csharp
s1.Name = "Max";
Console.WriteLine(s1.Name);
```

Der Unterschied ist aber:

```text
Bei einer Property kann man später besser kontrollieren,
wie Werte gelesen oder verändert werden dürfen.
```

---

## 3. Aufbau einer Auto-Property

Die häufigste einfache Schreibweise ist die **Auto-Property**.

```csharp
public string Name { get; set; }
```

| Teil | Bedeutung |
|---|---|
| `public` | Die Property ist von außen zugreifbar |
| `string` | Datentyp der Property |
| `Name` | Name der Property |
| `get` | Wert darf gelesen werden |
| `set` | Wert darf verändert werden |

Beispiel:

```csharp
spieler.Name = "Lena";
```

Hier wird `set` verwendet, weil ein Wert gespeichert wird.

```csharp
Console.WriteLine(spieler.Name);
```

Hier wird `get` verwendet, weil der Wert gelesen wird.

---

## 4. Auto-Property

Eine Auto-Property ist die Kurzform einer Property.

```csharp
public string Name { get; set; }
public int Punkte { get; set; }
```

C# erstellt dabei im Hintergrund automatisch ein privates Feld.

Gedanklich kann man sich das ungefähr so vorstellen:

```csharp
private string name;

public string Name
{
    get
    {
        return name;
    }
    set
    {
        name = value;
    }
}
```

Die kurze Schreibweise dafür ist:

```csharp
public string Name { get; set; }
```

Für Anfänger ist diese Schreibweise meistens die wichtigste.

---

## 5. Property mit Startwert

Eine Property kann direkt einen Startwert bekommen.

```csharp
class Spieler
{
    public string Name { get; set; } = "Unbekannt";
    public int Punkte { get; set; } = 0;
}
```

Beispiel:

```csharp
Spieler spieler1 = new Spieler();

Console.WriteLine(spieler1.Name);
Console.WriteLine(spieler1.Punkte);
```

Ausgabe:

```text
Unbekannt
0
```

Das Objekt hat also bereits Werte, obwohl noch nichts manuell gesetzt wurde.

---

## 6. Read-Only Property mit private set

Manchmal soll ein Wert von außen gelesen, aber nicht direkt verändert werden können.

Dafür kann man `private set` verwenden.

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Punkte { get; private set; }
}
```

Das bedeutet:

```text
get ist public  → Der Wert darf von außen gelesen werden.
set ist private → Der Wert darf nur innerhalb der Klasse verändert werden.
```

Von außen erlaubt:

```csharp
Console.WriteLine(spieler.Punkte);
```

Von außen nicht erlaubt:

```csharp
spieler.Punkte = 100;
```

Das würde einen Fehler verursachen.

Stattdessen verändert man den Wert über eine Methode in der Klasse:

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Punkte { get; private set; }

    public void PunkteErhoehen(int wert)
    {
        Punkte += wert;
    }
}
```

Verwendung:

```csharp
Spieler spieler = new Spieler();
spieler.Name = "Lena";

spieler.PunkteErhoehen(10);

Console.WriteLine(spieler.Punkte);
```

Ausgabe:

```text
10
```

Vorteil:

```text
Der Wert kann nicht beliebig von außen geändert werden.
Die Klasse kontrolliert selbst, wie Punkte verändert werden.
```

---

## 7. Property mit eigener Logik

Wenn man prüfen möchte, ob ein Wert gültig ist, verwendet man eine Property mit eigener Logik.

Beispiel:

```csharp
class Schueler
{
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
}
```

Wichtig ist hier das private Feld:

```csharp
private int alter;
```

Dieses Feld speichert den echten Wert.

Die Property kontrolliert den Zugriff darauf:

```csharp
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

`value` ist dabei der Wert, der gerade gesetzt werden soll.

Beispiel:

```csharp
s1.Alter = 16;
```

Dann ist:

```text
value = 16
```

Beispiel:

```csharp
s1.Alter = -5;
```

Dann ist:

```text
value = -5
```

Da `-5` kleiner als `0` ist, wird der Wert nicht gespeichert.

---

## 8. Property mit Fehlermeldung

Man kann bei ungültigen Werten auch eine Fehlermeldung ausgeben.

```csharp
class Schueler
{
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
            else
            {
                Console.WriteLine("Alter darf nicht negativ sein.");
            }
        }
    }
}
```

Verwendung:

```csharp
Schueler s1 = new Schueler();

s1.Alter = -5;
Console.WriteLine(s1.Alter);
```

Ausgabe:

```text
Alter darf nicht negativ sein.
0
```

Warum `0`?

Weil `int` standardmäßig den Startwert `0` besitzt.

---

## 9. Get-only Property

Eine Property kann auch nur einen `get`-Teil besitzen.

Dann kann sie von außen nur gelesen werden.

```csharp
class Kreis
{
    public double Radius { get; set; }

    public double Durchmesser
    {
        get
        {
            return Radius * 2;
        }
    }
}
```

Verwendung:

```csharp
Kreis k = new Kreis();
k.Radius = 5;

Console.WriteLine(k.Durchmesser);
```

Ausgabe:

```text
10
```

`Durchmesser` wird nicht direkt gespeichert, sondern aus dem Radius berechnet.

Kurzschreibweise:

```csharp
public double Durchmesser => Radius * 2;
```

---

## 10. Berechnete Property

Eine berechnete Property gibt einen Wert zurück, der aus anderen Daten berechnet wird.

Beispiel:

```csharp
class Rechteck
{
    public double Breite { get; set; }
    public double Hoehe { get; set; }

    public double Flaeche
    {
        get
        {
            return Breite * Hoehe;
        }
    }
}
```

Verwendung:

```csharp
Rechteck r = new Rechteck();
r.Breite = 4;
r.Hoehe = 3;

Console.WriteLine(r.Flaeche);
```

Ausgabe:

```text
12
```

Die Fläche wird nicht extra gespeichert.
Sie wird immer aus `Breite * Hoehe` berechnet.

---

## 11. Init-Property

Eine `init`-Property kann nur beim Erstellen des Objekts gesetzt werden.

```csharp
class Produkt
{
    public string Name { get; init; }
    public double Preis { get; init; }
}
```

Verwendung:

```csharp
Produkt p = new Produkt
{
    Name = "Tastatur",
    Preis = 49.99
};
```

Danach darf man die Werte nicht mehr ändern:

```csharp
p.Preis = 59.99;
```

Das würde einen Fehler verursachen.

Merksatz:

```text
init = darf beim Erstellen gesetzt werden, danach nicht mehr
```

Für den Einstieg ist `init` noch nicht unbedingt notwendig, aber es ist eine wichtige moderne C#-Schreibweise.

---

## 12. Vergleich der wichtigsten Arten

| Art | Beispiel | Bedeutung |
|---|---|---|
| Feld | `public string Name;` | Direkte Variable in der Klasse |
| Auto-Property | `public string Name { get; set; }` | Standard-Property mit automatischem Speicher |
| Property mit Startwert | `public int Punkte { get; set; } = 0;` | Property hat einen Anfangswert |
| private set | `public int Punkte { get; private set; }` | Von außen lesbar, nur intern veränderbar |
| Property mit Logik | eigener `get`- und `set`-Block | Werte können geprüft werden |
| Get-only Property | `public double Flaeche { get { ... } }` | Wert kann nur gelesen werden |
| Berechnete Property | `return Breite * Hoehe;` | Wert wird aus anderen Werten berechnet |
| Init-Property | `public string Name { get; init; }` | Wert nur beim Erstellen setzbar |

---

## 13. Komplettes Beispiel

```csharp
using System;

class Spieler
{
    private int leben;

    public string Name { get; set; } = "Unbekannt";
    public int Punkte { get; private set; }

    public int Leben
    {
        get
        {
            return leben;
        }
        set
        {
            if (value >= 0 && value <= 100)
            {
                leben = value;
            }
            else
            {
                Console.WriteLine("Leben muss zwischen 0 und 100 liegen.");
            }
        }
    }

    public bool IstAmLeben
    {
        get
        {
            return Leben > 0;
        }
    }

    public void PunkteErhoehen(int wert)
    {
        if (wert > 0)
        {
            Punkte += wert;
        }
    }
}

class Program
{
    static void Main()
    {
        Spieler spieler = new Spieler();

        spieler.Name = "Lena";
        spieler.Leben = 100;
        spieler.PunkteErhoehen(25);

        Console.WriteLine($"Name: {spieler.Name}");
        Console.WriteLine($"Leben: {spieler.Leben}");
        Console.WriteLine($"Punkte: {spieler.Punkte}");
        Console.WriteLine($"Am Leben: {spieler.IstAmLeben}");

        spieler.Leben = -10;
    }
}
```

Mögliche Ausgabe:

```text
Name: Lena
Leben: 100
Punkte: 25
Am Leben: True
Leben muss zwischen 0 und 100 liegen.
```

---

## 14. Merksätze

```text
Ein Feld ist eine direkte Variable in einer Klasse.
```

```text
Eine Auto-Property ist die saubere Standardschreibweise für Eigenschaften.
```

```text
get liest einen Wert.
set verändert einen Wert.
```

```text
private set bedeutet: Von außen lesen erlaubt, von außen ändern verboten.
```

```text
Properties mit eigener Logik können Werte prüfen, bevor sie gespeichert werden.
```

```text
Berechnete Properties speichern keinen eigenen Wert,
sondern berechnen ihn aus anderen Eigenschaften.
```
