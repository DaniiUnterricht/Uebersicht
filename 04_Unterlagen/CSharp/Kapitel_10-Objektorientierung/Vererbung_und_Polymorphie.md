<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Vererbung und Polymorphie

## Einordnung

In den vorherigen Einheiten wurden bereits wichtige Grundlagen der Objektorientierung behandelt:

- Klassen und Objekte
- Properties und Konstruktoren
- Methoden
- Kapselung mit `private set`
- Objekte als Methodenparameter
- Listen von Objekten
- Beziehungen zwischen mehreren Klassen

In dieser Einheit wird behandelt, wie mehrere ähnliche Klassen gemeinsame Eigenschaften und Methoden verwenden können.

Dafür werden zwei wichtige Konzepte benötigt:

```text
Vererbung:
Eine Klasse übernimmt Eigenschaften und Methoden einer anderen Klasse.
```

```text
Polymorphie:
Verschiedene Objekte können über einen gemeinsamen Typ behandelt werden,
führen aber ihre eigene Version einer Methode aus.
```

Als erstes Beispiel wird ein Spiel mit verschiedenen Gegnertypen verwendet:

- Goblin
- Wolf
- Räuber

Alle diese Klassen sind unterschiedliche Gegnertypen, besitzen aber gemeinsame Eigenschaften wie Name, Leben und Schaden.

Anschließend wird das Beispiel um eine gemeinsame Oberklasse `Lebewesen` und einen zweiten Vererbungszweig erweitert:

- Spieler
  - Magier
  - Bogenschütze
  - Schwertkämpfer
- Gegner
  - Goblin
  - Wolf
  - Räuber

Dadurch kann die bereits bekannte Methode `SchadenNehmen()` für Spieler und Gegner gemeinsam wiederverwendet werden.

---

# 1. Das Problem ohne Vererbung

Ohne Vererbung könnte für jeden Gegnertyp eine eigene Klasse erstellt werden.

## Klasse `Goblin`

```csharp
class Goblin
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public int Schaden { get; private set; }

    public Goblin(string name, int leben, int schaden)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
    }

    public void SchadenNehmen(int schaden)
    {
        Leben -= schaden;

        if (Leben < 0)
        {
            Leben = 0;
        }
    }
}
```

## Klasse `Wolf`

```csharp
class Wolf
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public int Schaden { get; private set; }

    public Wolf(string name, int leben, int schaden)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
    }

    public void SchadenNehmen(int schaden)
    {
        Leben -= schaden;

        if (Leben < 0)
        {
            Leben = 0;
        }
    }
}
```

Beide Klassen enthalten fast denselben Code.

Doppelt vorhanden sind beispielsweise:

- `Name`
- `Leben`
- `Schaden`
- Konstruktor
- `SchadenNehmen()`

Würde später noch ein Räuber, Skelett oder Drache dazukommen, müsste derselbe Code erneut geschrieben werden.

```text
Doppelter Code ist schwerer zu warten.
Änderungen müssen an mehreren Stellen durchgeführt werden.
```

---

# 2. Gemeinsame Eigenschaften erkennen

Goblin, Wolf und Räuber sind zwar unterschiedlich, aber alle sind Gegner.

Gemeinsame Eigenschaften:

```text
Jeder Gegner besitzt einen Namen.
Jeder Gegner besitzt Leben.
Jeder Gegner verursacht Schaden.
Jeder Gegner kann Schaden nehmen.
```

Diese Gemeinsamkeiten können in einer gemeinsamen Klasse gesammelt werden.

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Leben { get; protected set; }
    public int Schaden { get; protected set; }
}
```

Die Klasse `Gegner` wird als **Basisklasse** bezeichnet.

Die Klassen `Goblin`, `Wolf` und `Raeuber` werden später als **abgeleitete Klassen** bezeichnet.

---

# 3. Was bedeutet Vererbung?

Bei der Vererbung übernimmt eine Klasse die zugänglichen Bestandteile einer anderen Klasse.

Die Schreibweise erfolgt mit einem Doppelpunkt:

```csharp
class Goblin : Gegner
{
}
```

Das bedeutet:

```text
Goblin erbt von Gegner.
```

Oder:

```text
Ein Goblin ist ein Gegner.
```

Dadurch besitzt ein `Goblin` automatisch die öffentlichen Eigenschaften und Methoden von `Gegner`.

```csharp
Goblin goblin = new Goblin();

goblin.Name = "Grim";
Console.WriteLine(goblin.Name);
```

Obwohl `Name` nicht direkt in der Klasse `Goblin` geschrieben wurde, ist die Property verfügbar, weil sie geerbt wurde.

---

# 4. Basisklasse und abgeleitete Klasse

## Basisklasse

Die Basisklasse enthält gemeinsame Bestandteile.

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Leben { get; protected set; }
    public int Schaden { get; protected set; }
}
```

## Abgeleitete Klasse

Die abgeleitete Klasse übernimmt diese Bestandteile und kann eigene ergänzen.

```csharp
class Goblin : Gegner
{
    public int GestohlenesGold { get; private set; }
}
```

Ein Goblin besitzt dadurch:

- `Name` aus `Gegner`
- `Leben` aus `Gegner`
- `Schaden` aus `Gegner`
- `GestohlenesGold` aus `Goblin`

Merksatz:

```text
Die Basisklasse enthält Gemeinsamkeiten.
Die abgeleitete Klasse ergänzt Besonderheiten.
```

---

# 5. Konstruktoren und `base`

Konstruktoren werden nicht automatisch genauso übernommen wie Properties und Methoden.

Die Basisklasse erhält zunächst einen Konstruktor:

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Leben { get; protected set; }
    public int Schaden { get; protected set; }

    public Gegner(string name, int leben, int schaden)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
    }
}
```

Nun benötigt auch die Klasse `Goblin` einen Konstruktor.

```csharp
class Goblin : Gegner
{
    public int GestohlenesGold { get; private set; }

    public Goblin(
        string name,
        int leben,
        int schaden,
        int gestohlenesGold)
        : base(name, leben, schaden)
    {
        GestohlenesGold = gestohlenesGold;
    }
}
```

Die Schreibweise

```csharp
: base(name, leben, schaden)
```

ruft den Konstruktor der Basisklasse auf.

Dadurch werden die gemeinsamen Properties in `Gegner` gesetzt.

```text
base(...) übergibt Werte an den Konstruktor der Basisklasse.
```

Der Konstruktor der abgeleiteten Klasse kümmert sich anschließend nur noch um die zusätzlichen Werte.

---

# 6. Weitere Gegnertypen erstellen

## Goblin

```csharp
class Goblin : Gegner
{
    public int GestohlenesGold { get; private set; }

    public Goblin(
        string name,
        int leben,
        int schaden,
        int gestohlenesGold)
        : base(name, leben, schaden)
    {
        GestohlenesGold = gestohlenesGold;
    }
}
```

## Wolf

```csharp
class Wolf : Gegner
{
    public int RudelGroesse { get; private set; }

    public Wolf(
        string name,
        int leben,
        int schaden,
        int rudelGroesse)
        : base(name, leben, schaden)
    {
        RudelGroesse = rudelGroesse;
    }
}
```

## Räuber

```csharp
class Raeuber : Gegner
{
    public string Waffe { get; private set; }

    public Raeuber(
        string name,
        int leben,
        int schaden,
        string waffe)
        : base(name, leben, schaden)
    {
        Waffe = waffe;
    }
}
```

Alle drei Klassen besitzen dieselben gemeinsamen Properties aus `Gegner`, aber jeweils eine eigene zusätzliche Property.

---

# 7. Was bedeutet `protected`?

Bisher wurden vor allem `public` und `private` verwendet.

Bei Vererbung ist zusätzlich `protected` wichtig.

```csharp
public int Leben { get; protected set; }
```

Das bedeutet:

```text
public get:
Der Wert darf von außen gelesen werden.

protected set:
Der Wert darf in der eigenen Klasse und in abgeleiteten Klassen verändert werden.
```

Beispiel:

```csharp
class Wolf : Gegner
{
    public void Heulen()
    {
        Schaden += 5;
    }
}
```

Die Klasse `Wolf` darf `Schaden` verändern, weil sie von `Gegner` erbt und der Setter `protected` ist.

Außerhalb der Klassen ist die direkte Änderung nicht erlaubt:

```csharp
Wolf wolf = new Wolf("Fang", 80, 15, 3);

wolf.Schaden = 500; // Fehler
```

## Vergleich

| Zugriffsmodifizierer | Eigene Klasse | Abgeleitete Klasse | Außerhalb der Klasse |
|---|---:|---:|---:|
| `public` | erlaubt | erlaubt | erlaubt |
| `protected` | erlaubt | erlaubt | nicht erlaubt |
| `private` | erlaubt | nicht erlaubt | nicht erlaubt |

Merksatz:

```text
protected ist ähnlich wie private,
erlaubt den Zugriff aber zusätzlich in abgeleiteten Klassen.
```

---

# 8. Gemeinsame Methoden in der Basisklasse

Methoden, die für alle Gegnertypen gleich funktionieren, gehören ebenfalls in die Basisklasse.

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Leben { get; protected set; }
    public int Schaden { get; protected set; }

    public Gegner(string name, int leben, int schaden)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
    }

    public void SchadenNehmen(int schaden)
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

Nun können alle abgeleiteten Klassen diese Methoden verwenden:

```csharp
Goblin goblin = new Goblin("Grim", 50, 10, 20);
Wolf wolf = new Wolf("Fang", 80, 15, 3);
Raeuber raeuber = new Raeuber("Kurt", 100, 20, "Schwert");

goblin.SchadenNehmen(20);
wolf.SchadenNehmen(30);
raeuber.SchadenNehmen(40);
```

Die Methode musste nur einmal geschrieben werden.

---

# 9. Methoden mit `virtual` vorbereiten

Manche Methoden sollen grundsätzlich in der Basisklasse vorhanden sein, aber bei verschiedenen Gegnertypen unterschiedlich funktionieren.

Zum Beispiel soll jeder Gegner angreifen können.

```csharp
public virtual void Angreifen()
{
    Console.WriteLine($"{Name} greift an und verursacht {Schaden} Schaden.");
}
```

Das Schlüsselwort `virtual` bedeutet:

```text
Diese Methode besitzt eine Standardversion,
darf aber in einer abgeleiteten Klasse überschrieben werden.
```

Die vollständige Basisklasse könnte so aussehen:

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Leben { get; protected set; }
    public int Schaden { get; protected set; }

    public Gegner(string name, int leben, int schaden)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
    }

    public void SchadenNehmen(int schaden)
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

    public virtual void Angreifen()
    {
        Console.WriteLine(
            $"{Name} greift an und verursacht {Schaden} Schaden."
        );
    }
}
```

---

# 10. Methoden mit `override` überschreiben

Eine abgeleitete Klasse kann eine virtuelle Methode durch eine eigene Version ersetzen.

Dafür wird `override` verwendet.

## Goblin

```csharp
class Goblin : Gegner
{
    public int GestohlenesGold { get; private set; }

    public Goblin(
        string name,
        int leben,
        int schaden,
        int gestohlenesGold)
        : base(name, leben, schaden)
    {
        GestohlenesGold = gestohlenesGold;
    }

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} sticht mit seinem Dolch zu und verursacht {Schaden} Schaden."
        );
    }
}
```

## Wolf

```csharp
class Wolf : Gegner
{
    public int RudelGroesse { get; private set; }

    public Wolf(
        string name,
        int leben,
        int schaden,
        int rudelGroesse)
        : base(name, leben, schaden)
    {
        RudelGroesse = rudelGroesse;
    }

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} beißt zu und verursacht {Schaden} Schaden."
        );
    }
}
```

## Räuber

```csharp
class Raeuber : Gegner
{
    public string Waffe { get; private set; }

    public Raeuber(
        string name,
        int leben,
        int schaden,
        string waffe)
        : base(name, leben, schaden)
    {
        Waffe = waffe;
    }

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} greift mit {Waffe} an und verursacht {Schaden} Schaden."
        );
    }
}
```

Merksatz:

```text
virtual erlaubt das Überschreiben einer Methode.
override erstellt die neue Version in der abgeleiteten Klasse.
```

---

# 11. Was bedeutet Polymorphie?

**Polymorphie** bedeutet, dass verschiedene Objekte über einen gemeinsamen Typ behandelt werden können.

Ein Goblin ist ein Gegner:

```csharp
Gegner gegner1 = new Goblin("Grim", 50, 10, 20);
```

Ein Wolf ist ebenfalls ein Gegner:

```csharp
Gegner gegner2 = new Wolf("Fang", 80, 15, 3);
```

Ein Räuber ist ebenfalls ein Gegner:

```csharp
Gegner gegner3 = new Raeuber("Kurt", 100, 20, "Schwert");
```

Alle Variablen besitzen den Typ `Gegner`.

In ihnen befinden sich aber unterschiedliche konkrete Objekte.

```text
Variablentyp: Gegner
Tatsächliches Objekt: Goblin, Wolf oder Raeuber
```

Nun wird bei allen dieselbe Methode aufgerufen:

```csharp
gegner1.Angreifen();
gegner2.Angreifen();
gegner3.Angreifen();
```

Ausgabe:

```text
Grim sticht mit seinem Dolch zu und verursacht 10 Schaden.
Fang beißt zu und verursacht 15 Schaden.
Kurt greift mit Schwert an und verursacht 20 Schaden.
```

Obwohl alle Variablen als `Gegner` gespeichert wurden, führt jedes Objekt seine eigene überschriebene Methode aus.

```text
Gleicher Methodenaufruf,
unterschiedliches Verhalten.
```

Das ist Polymorphie.

---

# 12. Polymorphie in einer Liste

Der größte Vorteil wird sichtbar, wenn verschiedene Gegnertypen in einer gemeinsamen Liste gespeichert werden.

```csharp
List<Gegner> gegnerListe = new List<Gegner>
{
    new Goblin("Grim", 50, 10, 20),
    new Wolf("Fang", 80, 15, 3),
    new Raeuber("Kurt", 100, 20, "Schwert"),
    new Goblin("Zik", 45, 8, 12)
};
```

Das ist möglich, weil jeder Eintrag ein `Gegner` ist.

Nun kann eine gemeinsame Schleife verwendet werden:

```csharp
foreach (Gegner gegner in gegnerListe)
{
    gegner.Angreifen();
}
```

Ausgabe:

```text
Grim sticht mit seinem Dolch zu und verursacht 10 Schaden.
Fang beißt zu und verursacht 15 Schaden.
Kurt greift mit Schwert an und verursacht 20 Schaden.
Zik sticht mit seinem Dolch zu und verursacht 8 Schaden.
```

Es ist keine eigene Liste für Goblins, Wölfe und Räuber notwendig.

Es sind auch keine `if`-Abfragen notwendig, um die passende Angriffsmethode auszuwählen.

Jedes Objekt weiß selbst, welche Version von `Angreifen()` ausgeführt werden soll.

---

# 13. Polymorphie ohne viele `if`-Abfragen

Ohne überschriebene Methoden könnte man versuchen, den Typ jedes Objekts manuell zu prüfen:

```csharp
foreach (Gegner gegner in gegnerListe)
{
    if (gegner is Goblin)
    {
        Console.WriteLine("Der Goblin sticht zu.");
    }
    else if (gegner is Wolf)
    {
        Console.WriteLine("Der Wolf beißt zu.");
    }
    else if (gegner is Raeuber)
    {
        Console.WriteLine("Der Räuber greift mit einer Waffe an.");
    }
}
```

Das funktioniert, wird bei vielen Gegnertypen aber schnell unübersichtlich.

Mit Polymorphie reicht:

```csharp
foreach (Gegner gegner in gegnerListe)
{
    gegner.Angreifen();
}
```

Vorteile:

- weniger `if`-Abfragen
- leichter erweiterbar
- übersichtlicher Code
- Verhalten bleibt in der passenden Klasse

Kommt später ein neuer Gegnertyp hinzu, muss die Schleife nicht verändert werden.

```csharp
class Skelett : Gegner
{
    public Skelett(string name, int leben, int schaden)
        : base(name, leben, schaden)
    {
    }

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} schlägt mit einem Knochen zu und verursacht {Schaden} Schaden."
        );
    }
}
```

Danach kann das Skelett einfach zur Liste hinzugefügt werden:

```csharp
gegnerListe.Add(new Skelett("Klapper", 60, 12));
```

Die bestehende Schleife funktioniert weiterhin.

---

# 14. `base` innerhalb einer überschriebenen Methode

Mit `base` kann nicht nur ein Konstruktor aufgerufen werden.

Es ist auch möglich, innerhalb einer überschriebenen Methode zuerst die Version der Basisklasse auszuführen.

Basisklasse:

```csharp
public virtual void ZeigeInfo()
{
    Console.WriteLine($"Name: {Name}");
    Console.WriteLine($"Leben: {Leben}");
    Console.WriteLine($"Schaden: {Schaden}");
}
```

Abgeleitete Klasse:

```csharp
public override void ZeigeInfo()
{
    base.ZeigeInfo();
    Console.WriteLine($"Gestohlenes Gold: {GestohlenesGold}");
}
```

`base.ZeigeInfo()` führt zuerst die Methode aus `Gegner` aus.

Danach ergänzt `Goblin` seine eigene Information.

Ausgabe:

```text
Name: Grim
Leben: 50
Schaden: 10
Gestohlenes Gold: 20
```

Das ist nützlich, wenn die gemeinsame Ausgabe erhalten bleiben und nur erweitert werden soll.

---

# 15. Mehrstufige Vererbung

Bisher wurde eine einfache Vererbung verwendet:

```text
Gegner
  ↓
Goblin
```

Eine Vererbung kann jedoch auch über mehrere Ebenen aufgebaut werden.

```text
Lebewesen
  ├── Spieler
  │     ├── Magier
  │     ├── Bogenschuetze
  │     └── Schwertkaempfer
  │
  └── Gegner
        ├── Goblin
        ├── Wolf
        └── Raeuber
```

Das nennt man **mehrstufige Vererbung**.

Dabei erbt eine Klasse von einer Klasse, die selbst bereits von einer anderen Klasse erbt.

```text
Ein Magier ist ein Spieler.
Ein Spieler ist ein Lebewesen.
Damit ist ein Magier indirekt ebenfalls ein Lebewesen.
```

Dasselbe gilt für die Gegnerseite:

```text
Ein Goblin ist ein Gegner.
Ein Gegner ist ein Lebewesen.
Damit ist ein Goblin indirekt ebenfalls ein Lebewesen.
```

---

## 15.1 Verbindung zur vorherigen Einheit

In der vorherigen Einheit konnten sowohl Spieler als auch Gegner Schaden nehmen.

Ohne eine gemeinsame Oberklasse könnte die Methode doppelt vorkommen:

```csharp
class Spieler
{
    public int Leben { get; private set; }

    public void SchadenNehmen(int schaden)
    {
        Leben -= schaden;

        if (Leben < 0)
        {
            Leben = 0;
        }
    }
}
```

```csharp
class Gegner
{
    public int Leben { get; private set; }

    public void SchadenNehmen(int schaden)
    {
        Leben -= schaden;

        if (Leben < 0)
        {
            Leben = 0;
        }
    }
}
```

Die Methode funktioniert in beiden Klassen gleich.

Darum kann sie in eine gemeinsame Basisklasse verschoben werden:

```text
Spieler und Gegner sind beide Lebewesen.
Jedes Lebewesen besitzt Leben und kann Schaden nehmen.
```

---

## 15.2 Gemeinsame Basisklasse `Lebewesen`

```csharp
class Lebewesen
{
    #region Properties

    public string Name { get; protected set; }
    public int Leben { get; protected set; }

    #endregion

    #region Konstruktor

    public Lebewesen(string name, int leben)
    {
        Name = name;
        Leben = leben;
    }

    #endregion

    #region Methoden

    public void SchadenNehmen(int schaden)
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

    public virtual void ZeigeInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Leben: {Leben}");
    }

    #endregion
}
```

Die Klasse `Lebewesen` enthält nur Bestandteile, die wirklich für Spieler und Gegner gemeinsam sind:

- Name
- Leben
- Schaden nehmen
- überprüfen, ob das Lebewesen besiegt ist
- grundlegende Informationen ausgeben

Der Angriffsschaden gehört noch nicht in `Lebewesen`, da nicht jedes Lebewesen zwingend gleich angreift.

---

## 15.3 Die Klassen `Spieler` und `Gegner`

`Spieler` und `Gegner` erben direkt von `Lebewesen`.

## Klasse `Spieler`

```csharp
class Spieler : Lebewesen
{
    #region Properties

    public int Level { get; protected set; }

    #endregion

    #region Konstruktor

    public Spieler(string name, int leben, int level)
        : base(name, leben)
    {
        Level = level;
    }

    #endregion

    #region Methoden

    public virtual void Angreifen()
    {
        Console.WriteLine($"{Name} greift an.");
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Level: {Level}");
    }

    #endregion
}
```

## Klasse `Gegner`

```csharp
class Gegner : Lebewesen
{
    #region Properties

    public int Schaden { get; protected set; }

    #endregion

    #region Konstruktor

    public Gegner(string name, int leben, int schaden)
        : base(name, leben)
    {
        Schaden = schaden;
    }

    #endregion

    #region Methoden

    public virtual void Angreifen()
    {
        Console.WriteLine(
            $"{Name} greift an und verursacht {Schaden} Schaden."
        );
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Schaden: {Schaden}");
    }

    #endregion
}
```

Beide Klassen erhalten `Name`, `Leben`, `SchadenNehmen()` und `IstBesiegt()` aus `Lebewesen`.

Sie ergänzen danach ihre eigenen Besonderheiten:

```text
Spieler ergänzt beispielsweise Level.
Gegner ergänzt Schaden.
```

---

## 15.4 Weitere Vererbung auf der Spielerseite

Von `Spieler` können nun mehrere konkrete Klassen erben.

## Magier

```csharp
class Magier : Spieler
{
    public int Mana { get; private set; }

    public Magier(
        string name,
        int leben,
        int level,
        int mana)
        : base(name, leben, level)
    {
        Mana = mana;
    }

    public override void Angreifen()
    {
        Console.WriteLine($"{Name} wirkt einen Feuerball.");
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Mana: {Mana}");
    }
}
```

## Bogenschütze

In C# werden Umlaute zwar unterstützt, in Klassennamen wird häufig trotzdem die Schreibweise `Bogenschuetze` verwendet.

```csharp
class Bogenschuetze : Spieler
{
    public int Pfeile { get; private set; }

    public Bogenschuetze(
        string name,
        int leben,
        int level,
        int pfeile)
        : base(name, leben, level)
    {
        Pfeile = pfeile;
    }

    public override void Angreifen()
    {
        if (Pfeile <= 0)
        {
            Console.WriteLine($"{Name} hat keine Pfeile mehr.");
            return;
        }

        Pfeile--;
        Console.WriteLine($"{Name} schießt einen Pfeil ab.");
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Pfeile: {Pfeile}");
    }
}
```

## Schwertkämpfer

```csharp
class Schwertkaempfer : Spieler
{
    public string Schwert { get; private set; }

    public Schwertkaempfer(
        string name,
        int leben,
        int level,
        string schwert)
        : base(name, leben, level)
    {
        Schwert = schwert;
    }

    public override void Angreifen()
    {
        Console.WriteLine($"{Name} greift mit {Schwert} an.");
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Schwert: {Schwert}");
    }
}
```

Die Konstruktoraufrufe verlaufen dabei über mehrere Ebenen.

Beim Erstellen eines Magiers:

```text
Magier-Konstruktor
        ↓
Spieler-Konstruktor
        ↓
Lebewesen-Konstruktor
```

Der Aufruf

```csharp
new Magier("Merlin", 90, 5, 120);
```

führt somit zuerst die benötigten Basiskonstruktoren aus.

---

## 15.5 Weitere Vererbung auf der Gegnerseite

Auch die bereits bekannten Gegnerklassen bleiben erhalten:

```csharp
class Goblin : Gegner
{
    public int GestohlenesGold { get; private set; }

    public Goblin(
        string name,
        int leben,
        int schaden,
        int gestohlenesGold)
        : base(name, leben, schaden)
    {
        GestohlenesGold = gestohlenesGold;
    }

    public override void Angreifen()
    {
        Console.WriteLine($"{Name} sticht mit einem Dolch zu.");
    }
}
```

```csharp
class Wolf : Gegner
{
    public int RudelGroesse { get; private set; }

    public Wolf(
        string name,
        int leben,
        int schaden,
        int rudelGroesse)
        : base(name, leben, schaden)
    {
        RudelGroesse = rudelGroesse;
    }

    public override void Angreifen()
    {
        Console.WriteLine($"{Name} beißt zu.");
    }
}
```

```csharp
class Raeuber : Gegner
{
    public string Waffe { get; private set; }

    public Raeuber(
        string name,
        int leben,
        int schaden,
        string waffe)
        : base(name, leben, schaden)
    {
        Waffe = waffe;
    }

    public override void Angreifen()
    {
        Console.WriteLine($"{Name} greift mit {Waffe} an.");
    }
}
```

Die vollständigen Vererbungswege lauten damit beispielsweise:

```text
Lebewesen → Gegner → Goblin
Lebewesen → Gegner → Wolf
Lebewesen → Gegner → Raeuber
```

---

## 15.6 Gemeinsame Liste aller Lebewesen

Durch die gemeinsame Oberklasse können Spieler und Gegner sogar in derselben Liste gespeichert werden:

```csharp
List<Lebewesen> lebewesen = new List<Lebewesen>
{
    new Magier("Merlin", 90, 5, 120),
    new Bogenschuetze("Lina", 100, 4, 20),
    new Schwertkaempfer("Aron", 140, 6, "Langschwert"),
    new Goblin("Grim", 50, 10, 20),
    new Wolf("Fang", 80, 15, 3),
    new Raeuber("Kurt", 100, 20, "Axt")
};
```

Für alle Objekte stehen die Bestandteile aus `Lebewesen` zur Verfügung:

```csharp
foreach (Lebewesen einLebewesen in lebewesen)
{
    einLebewesen.ZeigeInfo();
    einLebewesen.SchadenNehmen(10);

    Console.WriteLine(
        $"Leben nach dem Schaden: {einLebewesen.Leben}"
    );

    Console.WriteLine("--------------------");
}
```

Der gleiche Aufruf von `SchadenNehmen()` funktioniert für:

- Magier
- Bogenschützen
- Schwertkämpfer
- Goblins
- Wölfe
- Räuber

Die Methode wurde trotzdem nur einmal in `Lebewesen` geschrieben.

Das verbindet mehrere bereits bekannte Konzepte:

- Vererbung
- mehrstufige Vererbung
- Kapselung
- Wiederverwendung von Methoden
- Polymorphie
- Listen von Objekten

---

## 15.7 Direkte und indirekte Vererbung

Bei einem Goblin gilt:

```text
Direkte Basisklasse: Gegner
Indirekte Basisklasse: Lebewesen
```

Bei einem Magier gilt:

```text
Direkte Basisklasse: Spieler
Indirekte Basisklasse: Lebewesen
```

Ein Objekt besitzt dadurch die zugänglichen Bestandteile aus allen Ebenen seiner Vererbungskette.

Beispiel:

```csharp
Magier magier = new Magier("Merlin", 90, 5, 120);

magier.SchadenNehmen(20); // aus Lebewesen
magier.Angreifen();       // überschrieben in Magier
magier.ZeigeInfo();       // überschrieben und erweitert
```

Merksatz:

```text
Bei mehrstufiger Vererbung werden Eigenschaften und Methoden
über mehrere Ebenen weitervererbt.
```

---

## 15.8 Mehrstufige Vererbung ist keine Mehrfachvererbung

Mehrstufige Vererbung ist in C# erlaubt:

```text
Lebewesen → Spieler → Magier
```

Eine Klasse erbt dabei auf jeder Ebene immer nur von genau einer direkten Basisklasse.

Nicht erlaubt wäre eine gleichzeitige Vererbung von mehreren Klassen:

```csharp
class Magier : Spieler, Gegner // Fehler
{
}
```

Merksatz:

```text
Mehrstufige Vererbung:
Mehrere Ebenen hintereinander – erlaubt.

Mehrfachvererbung:
Mehrere direkte Basisklassen gleichzeitig – bei Klassen nicht erlaubt.
```

---


# 16. Vollständiges Beispiel

## Basisklasse `Gegner`

```csharp
class Gegner
{
    #region Properties

    public string Name { get; set; }
    public int Leben { get; protected set; }
    public int Schaden { get; protected set; }

    #endregion

    #region Konstruktor

    public Gegner(string name, int leben, int schaden)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
    }

    #endregion

    #region Methoden

    public void SchadenNehmen(int schaden)
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

    public virtual void Angreifen()
    {
        Console.WriteLine(
            $"{Name} greift an und verursacht {Schaden} Schaden."
        );
    }

    public virtual void ZeigeInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Leben: {Leben}");
        Console.WriteLine($"Schaden: {Schaden}");
    }

    #endregion
}
```

## Klasse `Goblin`

```csharp
class Goblin : Gegner
{
    #region Properties

    public int GestohlenesGold { get; private set; }

    #endregion

    #region Konstruktor

    public Goblin(
        string name,
        int leben,
        int schaden,
        int gestohlenesGold)
        : base(name, leben, schaden)
    {
        GestohlenesGold = gestohlenesGold;
    }

    #endregion

    #region Methoden

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} sticht mit seinem Dolch zu und verursacht {Schaden} Schaden."
        );
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Gestohlenes Gold: {GestohlenesGold}");
    }

    #endregion
}
```

## Klasse `Wolf`

```csharp
class Wolf : Gegner
{
    #region Properties

    public int RudelGroesse { get; private set; }

    #endregion

    #region Konstruktor

    public Wolf(
        string name,
        int leben,
        int schaden,
        int rudelGroesse)
        : base(name, leben, schaden)
    {
        RudelGroesse = rudelGroesse;
    }

    #endregion

    #region Methoden

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} beißt zu und verursacht {Schaden} Schaden."
        );
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Rudelgröße: {RudelGroesse}");
    }

    #endregion
}
```

## Klasse `Raeuber`

```csharp
class Raeuber : Gegner
{
    #region Properties

    public string Waffe { get; private set; }

    #endregion

    #region Konstruktor

    public Raeuber(
        string name,
        int leben,
        int schaden,
        string waffe)
        : base(name, leben, schaden)
    {
        Waffe = waffe;
    }

    #endregion

    #region Methoden

    public override void Angreifen()
    {
        Console.WriteLine(
            $"{Name} greift mit {Waffe} an und verursacht {Schaden} Schaden."
        );
    }

    public override void ZeigeInfo()
    {
        base.ZeigeInfo();
        Console.WriteLine($"Waffe: {Waffe}");
    }

    #endregion
}
```

## Verwendung in `Program.cs`

```csharp
List<Gegner> gegnerListe = new List<Gegner>
{
    new Goblin("Grim", 50, 10, 20),
    new Wolf("Fang", 80, 15, 3),
    new Raeuber("Kurt", 100, 20, "Schwert")
};

foreach (Gegner gegner in gegnerListe)
{
    Console.WriteLine("--------------------");

    gegner.ZeigeInfo();
    gegner.Angreifen();

    gegner.SchadenNehmen(25);

    Console.WriteLine($"Leben danach: {gegner.Leben}");
}
```

Mögliche Ausgabe:

```text
--------------------
Name: Grim
Leben: 50
Schaden: 10
Gestohlenes Gold: 20
Grim sticht mit seinem Dolch zu und verursacht 10 Schaden.
Leben danach: 25

--------------------
Name: Fang
Leben: 80
Schaden: 15
Rudelgröße: 3
Fang beißt zu und verursacht 15 Schaden.
Leben danach: 55

--------------------
Name: Kurt
Leben: 100
Schaden: 20
Waffe: Schwert
Kurt greift mit Schwert an und verursacht 20 Schaden.
Leben danach: 75
```

---

# 17. Welche Bestandteile werden geerbt?

Abgeleitete Klassen können grundsätzlich auf zugängliche Bestandteile der Basisklasse zugreifen.

## Geerbt beziehungsweise verfügbar

- öffentliche Properties
- geschützte Properties
- öffentliche Methoden
- geschützte Methoden

## Nicht direkt zugänglich

- private Felder
- private Properties
- private Methoden

Beispiel:

```csharp
class Gegner
{
    private int interneNummer;
    protected int Schaden { get; set; }
    public string Name { get; set; }
}
```

In einer abgeleiteten Klasse gilt:

```csharp
class Goblin : Gegner
{
    public void Test()
    {
        Name = "Grim";      // erlaubt
        Schaden = 10;       // erlaubt
        interneNummer = 5;  // Fehler
    }
}
```

`interneNummer` ist nur innerhalb der Klasse `Gegner` sichtbar.

---

# 18. Eine Klasse kann nur von einer Klasse erben

In C# kann eine Klasse nur eine direkte Basisklasse besitzen.

Erlaubt:

```csharp
class Goblin : Gegner
{
}
```

Nicht erlaubt:

```csharp
class Goblin : Gegner, Tier
{
}
```

Eine Klasse kann also nicht gleichzeitig von zwei Klassen erben.

Später können Interfaces verwendet werden, um zusätzliche Fähigkeiten zu beschreiben. Interfaces sind jedoch ein eigenes Thema.

---

# 19. Vererbung beschreibt eine „Ist-ein“-Beziehung

Vererbung sollte verwendet werden, wenn eine echte **Ist-ein-Beziehung** besteht.

```text
Ein Goblin ist ein Gegner.
Ein Wolf ist ein Gegner.
Ein Räuber ist ein Gegner.
```

Darum ist Vererbung hier sinnvoll.

Nicht sinnvoll wäre beispielsweise:

```text
Ein Gegner ist eine Waffe.
```

Ein Gegner besitzt vielleicht eine Waffe, ist aber keine Waffe.

Das wäre stattdessen eine **Hat-ein-Beziehung**:

```csharp
class Raeuber : Gegner
{
    public Waffe Waffe { get; private set; }
}
```

Merksatz:

```text
Ist-ein-Beziehung  → häufig Vererbung
Hat-ein-Beziehung  → Objekt als Property oder in einer Liste
```

---

# 20. Typische Fehler

## Fehler 1: `base(...)` vergessen

```csharp
class Goblin : Gegner
{
    public Goblin(string name, int leben, int schaden)
    {
    }
}
```

Wenn `Gegner` keinen parameterlosen Konstruktor besitzt, entsteht ein Fehler.

Richtig:

```csharp
public Goblin(string name, int leben, int schaden)
    : base(name, leben, schaden)
{
}
```

---

## Fehler 2: `override` ohne `virtual`

Basisklasse:

```csharp
public void Angreifen()
{
}
```

Abgeleitete Klasse:

```csharp
public override void Angreifen()
{
}
```

Das funktioniert nicht, weil die Methode in der Basisklasse nicht mit `virtual` vorbereitet wurde.

Richtig:

```csharp
public virtual void Angreifen()
{
}
```

---

## Fehler 3: Unterschiedliche Methodensignatur

Basisklasse:

```csharp
public virtual void Angreifen()
```

Falsch in der abgeleiteten Klasse:

```csharp
public override void Angreifen(int bonusSchaden)
```

Beim Überschreiben muss die Methodensignatur übereinstimmen.

Richtig:

```csharp
public override void Angreifen()
```

---

## Fehler 4: Gemeinsame Bestandteile erneut schreiben

```csharp
class Goblin : Gegner
{
    public string Name { get; set; }
    public int Leben { get; set; }
}
```

Diese Properties existieren bereits in `Gegner` und sollten nicht erneut definiert werden.

---

## Fehler 5: Vererbung nur zum Sparen weniger Zeilen verwenden

Vererbung sollte nicht nur eingesetzt werden, weil zwei Klassen zufällig eine gleich benannte Property besitzen.

Es sollte eine sinnvolle fachliche Beziehung bestehen:

```text
Goblin ist ein Gegner → sinnvoll
Produkt ist ein Gegner → nicht sinnvoll
```

---

# 21. Zusammenfassung

## Vererbung

```text
Eine abgeleitete Klasse übernimmt gemeinsame Eigenschaften und Methoden
aus einer Basisklasse.
```

Schreibweise:

```csharp
class Goblin : Gegner
```

## `base(...)`

```text
Ruft den Konstruktor der Basisklasse auf.
```

```csharp
: base(name, leben, schaden)
```

## `protected`

```text
Innerhalb der Klasse und in abgeleiteten Klassen zugänglich,
aber nicht frei von außen.
```

## `virtual`

```text
Die Methode darf von einer abgeleiteten Klasse überschrieben werden.
```

## `override`

```text
Die abgeleitete Klasse stellt eine eigene Version der Methode bereit.
```

## Polymorphie

```text
Verschiedene Objekte werden über einen gemeinsamen Typ behandelt,
führen aber beim gleichen Methodenaufruf unterschiedliches Verhalten aus.
```

Beispiel:

```csharp
List<Gegner> gegnerListe = new List<Gegner>
{
    new Goblin("Grim", 50, 10, 20),
    new Wolf("Fang", 80, 15, 3),
    new Raeuber("Kurt", 100, 20, "Schwert")
};

foreach (Gegner gegner in gegnerListe)
{
    gegner.Angreifen();
}
```

Merksatz:

```text
Alle sind Gegner,
aber jeder Gegnertyp greift anders an.
```