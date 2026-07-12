<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Kapselung vertiefen und Objekte miteinander verbinden

## Einordnung

In der letzten Einheit wurden bereits die wichtigsten Grundlagen der Objektorientierung behandelt:

- Klassen und Objekte
- Properties
- Konstruktoren
- Methoden
- mehrere Objekte in einer `List<T>`

Außerdem wurde mit `private set` bereits kurz gezeigt, dass nicht jede Property von außen verändert werden muss.

In dieser Einheit wird dieses Prinzip vertieft.

```text
Ein Objekt soll seine eigenen Daten schützen
und selbst kontrollieren, wie diese verändert werden.
```

Danach werden mehrere Objekte miteinander verbunden.

```text
Ein Objekt kann andere Objekte verwenden,
speichern oder an Methoden übergeben bekommen.
```

---

# 1. Wiederholung: öffentliche Properties

Eine einfache Spielerklasse könnte so aussehen:

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; set; }
}
```

Ein Objekt wird erstellt und anschließend verändert:

```csharp
Spieler spieler = new Spieler();

spieler.Name = "Lena";
spieler.Leben = 100;
```

Da `Leben` ein öffentliches `set` besitzt, kann der Wert überall verändert werden:

```csharp
spieler.Leben = -500;
spieler.Leben = 999999;
```

C# erlaubt diese Zuweisungen. Für das Programm ergeben diese Werte aber wahrscheinlich keinen Sinn.

Das Problem ist daher nicht der Datentyp, sondern die fehlende Kontrolle.

---

# 2. Was bedeutet Kapselung?

**Kapselung** bedeutet, dass eine Klasse ihre inneren Daten schützt und nur kontrollierte Zugriffe erlaubt.

```text
Daten werden nicht beliebig von außen verändert.
Die Klasse stellt dafür passende Properties und Methoden bereit.
```

Beispiel aus der echten Welt:

```text
Bei einem Auto verändert man die Geschwindigkeit nicht direkt am Motor.
Man verwendet dafür das Gaspedal und die Bremse.
```

Das Auto kontrolliert intern, was dadurch passiert.

In einem Programm übernimmt die Klasse diese Aufgabe.

---

# 3. `private set` verwenden

Mit `private set` darf eine Property von außen gelesen, aber nicht direkt verändert werden.

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }

    public Spieler(string name)
    {
        Name = name;
        Leben = 100;
    }
}
```

Von außen darf `Leben` gelesen werden:

```csharp
Console.WriteLine(spieler.Leben);
```

Der Wert darf aber nicht direkt gesetzt werden:

```csharp
spieler.Leben = 500; // Fehler
```

Innerhalb der Klasse darf die Property weiterhin verändert werden:

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }

    public Spieler(string name)
    {
        Name = name;
        Leben = 100;
    }

    public void SchadenNehmen(int schaden)
    {
        Leben -= schaden;
    }
}
```

Verwendung:

```csharp
Spieler spieler = new Spieler("Lena");

spieler.SchadenNehmen(20);

Console.WriteLine(spieler.Leben);
```

Ausgabe:

```text
80
```

---

# 4. Werte in Methoden kontrollieren

Die Methode kann überprüfen, ob ein übergebener Wert gültig ist.

```csharp
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
```

Damit wird verhindert, dass:

- negativer Schaden das Leben erhöht
- das Leben unter `0` fällt

```csharp
spieler.SchadenNehmen(-20); // wird ignoriert
spieler.SchadenNehmen(500); // Leben wird höchstens 0
```

Merksatz:

```text
Methoden verändern den Zustand eines Objekts kontrolliert.
```

---

# 5. Heilen mit einem maximalen Wert

Ein Spieler soll geheilt werden können, aber niemals mehr als sein maximales Leben besitzen.

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public int MaxLeben { get; private set; }

    public Spieler(string name, int maxLeben)
    {
        Name = name;
        MaxLeben = maxLeben;
        Leben = maxLeben;
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

    public void Heilen(int heilung)
    {
        if (heilung <= 0)
        {
            return;
        }

        Leben += heilung;

        if (Leben > MaxLeben)
        {
            Leben = MaxLeben;
        }
    }
}
```

Verwendung:

```csharp
Spieler spieler = new Spieler("Lena", 100);

spieler.SchadenNehmen(40);
spieler.Heilen(25);

Console.WriteLine(spieler.Leben);
```

Ausgabe:

```text
85
```

---

# 6. Zustand eines Objekts abfragen

Eine Methode kann nicht nur Werte verändern, sondern auch Informationen über den Zustand zurückgeben.

```csharp
public bool IstBesiegt()
{
    return Leben <= 0;
}
```

Verwendung:

```csharp
if (spieler.IstBesiegt())
{
    Console.WriteLine("Der Spieler wurde besiegt.");
}
else
{
    Console.WriteLine("Der Spieler kann weiterkämpfen.");
}
```

Die Prüfung befindet sich dadurch direkt in der Klasse.

Statt überall zu schreiben:

```csharp
if (spieler.Leben <= 0)
```

kann man die verständlichere Methode verwenden:

```csharp
if (spieler.IstBesiegt())
```

---

# 7. Vollständig private Felder

Daten können auch vollständig als `private` gespeichert werden.

```csharp
class Bankkonto
{
    private decimal kontostand;

    public Bankkonto()
    {
        kontostand = 0;
    }

    public void Einzahlen(decimal betrag)
    {
        if (betrag > 0)
        {
            kontostand += betrag;
        }
    }

    public decimal KontostandAusgeben()
    {
        return kontostand;
    }
}
```

Von außen ist das Feld nicht zugänglich:

```csharp
konto.kontostand = 5000; // Fehler
```

Der Zugriff erfolgt nur über Methoden:

```csharp
konto.Einzahlen(200);
Console.WriteLine(konto.KontostandAusgeben());
```

In vielen Fällen ist eine Property mit `private set` aber angenehmer:

```csharp
public decimal Kontostand { get; private set; }
```

---

# 8. Zugriffsmodifizierer

| Modifizierer | Bedeutung |
|---|---|
| `public` | von überall zugänglich |
| `private` | nur innerhalb der eigenen Klasse zugänglich |

Beispiel:

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }

    private int geheimeNummer;
}
```

```text
Name          → von außen lesbar und veränderbar
Leben         → von außen lesbar, aber nur intern veränderbar
geheimeNummer → nur innerhalb der Klasse zugänglich
```

---

# 9. Objekte als Methodenparameter

Bisher wurden häufig einfache Werte an Methoden übergeben:

```csharp
public void SchadenNehmen(int schaden)
```

Man kann aber auch vollständige Objekte übergeben.

Dazu wird zuerst eine Gegnerklasse erstellt:

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Schaden { get; private set; }

    public Gegner(string name, int schaden)
    {
        Name = name;
        Schaden = schaden;
    }
}
```

Nun erhält die Methode `GreifeAn` ein Spielerobjekt als Parameter:

```csharp
public void GreifeAn(Spieler ziel)
{
    ziel.SchadenNehmen(Schaden);
}
```

Die vollständige Klasse:

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Schaden { get; private set; }

    public Gegner(string name, int schaden)
    {
        Name = name;
        Schaden = schaden;
    }

    public void GreifeAn(Spieler ziel)
    {
        Console.WriteLine(Name + " greift " + ziel.Name + " an.");
        ziel.SchadenNehmen(Schaden);
    }
}
```

Verwendung:

```csharp
Spieler spieler = new Spieler("Lena", 100);
Gegner gegner = new Gegner("Goblin", 20);

gegner.GreifeAn(spieler);

Console.WriteLine(spieler.Leben);
```

Ausgabe:

```text
Goblin greift Lena an.
80
```

Hier arbeiten zwei Objekte miteinander:

```text
Gegnerobjekt → ruft eine Methode des Spielerobjekts auf
```

---

# 10. Was passiert bei der Objektübergabe?

Beim Aufruf

```csharp
gegner.GreifeAn(spieler);
```

wird das vorhandene Spielerobjekt an die Methode übergeben.

Innerhalb der Methode heißt dieses Objekt `ziel`:

```csharp
public void GreifeAn(Spieler ziel)
{
    ziel.SchadenNehmen(Schaden);
}
```

`spieler` und `ziel` beziehen sich während des Methodenaufrufs auf dasselbe Objekt.

Deshalb bleibt die Änderung auch nach der Methode erhalten.

```csharp
Console.WriteLine(spieler.Leben);
```

zeigt den bereits verringerten Wert an.

---

# 11. Mehrere Objektarten miteinander verbinden

Objekte können auch andere Objekte dauerhaft speichern.

Beispiel: Ein Spieler besitzt eine Waffe.

```csharp
class Waffe
{
    public string Name { get; set; }
    public int Schaden { get; private set; }

    public Waffe(string name, int schaden)
    {
        Name = name;
        Schaden = schaden;
    }
}
```

Die Spielerklasse erhält eine Property vom Typ `Waffe`:

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public Waffe AusgeruesteteWaffe { get; private set; }

    public Spieler(string name, int leben, Waffe waffe)
    {
        Name = name;
        Leben = leben;
        AusgeruesteteWaffe = waffe;
    }
}
```

Objekte erstellen:

```csharp
Waffe schwert = new Waffe("Eisenschwert", 25);
Spieler spieler = new Spieler("Lena", 100, schwert);
```

Auf die Waffe kann über den Spieler zugegriffen werden:

```csharp
Console.WriteLine(spieler.AusgeruesteteWaffe.Name);
Console.WriteLine(spieler.AusgeruesteteWaffe.Schaden);
```

Ausgabe:

```text
Eisenschwert
25
```

Diese Beziehung nennt man vereinfacht eine **Hat-ein-Beziehung**:

```text
Ein Spieler hat eine Waffe.
```

Weitere Beispiele:

```text
Ein Auto hat einen Motor.
Eine Bestellung hat Produkte.
Eine Schule hat Schüler.
Ein Team hat Spieler.
```

---

# 12. Eine Liste von Objekten in einem Objekt

Ein Spieler kann nicht nur ein einzelnes Item, sondern mehrere Items besitzen.

```csharp
class Item
{
    public string Name { get; set; }
    public int Wert { get; private set; }

    public Item(string name, int wert)
    {
        Name = name;
        Wert = wert;
    }
}
```

Die Spielerklasse besitzt ein Inventar:

```csharp
class Spieler
{
    public string Name { get; set; }
    public List<Item> Inventar { get; private set; }

    public Spieler(string name)
    {
        Name = name;
        Inventar = new List<Item>();
    }
}
```

Wichtig:

```csharp
Inventar = new List<Item>();
```

Die Liste muss erstellt werden, bevor Elemente hinzugefügt werden können.

---

# 13. Das Inventar kontrolliert verändern

Die Liste könnte von außen direkt verändert werden:

```csharp
spieler.Inventar.Add(item);
```

Sauberer ist es für diese Übung, eine passende Methode anzulegen:

```csharp
public void ItemAufnehmen(Item item)
{
    Inventar.Add(item);
}
```

Zusätzlich kann eine Ausgabemethode erstellt werden:

```csharp
public void InventarAusgeben()
{
    Console.WriteLine("Inventar von " + Name + ":");

    foreach (Item item in Inventar)
    {
        Console.WriteLine("- " + item.Name + " (" + item.Wert + " Gold)");
    }
}
```

Vollständiges Beispiel:

```csharp
class Spieler
{
    public string Name { get; set; }
    public List<Item> Inventar { get; private set; }

    public Spieler(string name)
    {
        Name = name;
        Inventar = new List<Item>();
    }

    public void ItemAufnehmen(Item item)
    {
        Inventar.Add(item);
    }

    public void InventarAusgeben()
    {
        Console.WriteLine("Inventar von " + Name + ":");

        foreach (Item item in Inventar)
        {
            Console.WriteLine("- " + item.Name + " (" + item.Wert + " Gold)");
        }
    }
}
```

Verwendung:

```csharp
Spieler spieler = new Spieler("Lena");

Item trank = new Item("Heiltrank", 15);
Item schluessel = new Item("Alter Schlüssel", 5);

spieler.ItemAufnehmen(trank);
spieler.ItemAufnehmen(schluessel);

spieler.InventarAusgeben();
```

Ausgabe:

```text
Inventar von Lena:
- Heiltrank (15 Gold)
- Alter Schlüssel (5 Gold)
```

---

# 14. Zusammengesetztes Beispiel: Spieler gegen Gegner

## Klasse `Spieler`

```csharp
class Spieler
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public int MaxLeben { get; private set; }
    public int Schaden { get; private set; }
    public int Gold { get; private set; }

    public Spieler(string name, int maxLeben, int schaden)
    {
        Name = name;
        MaxLeben = maxLeben;
        Leben = maxLeben;
        Schaden = schaden;
        Gold = 0;
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

    public void Heilen(int heilung)
    {
        if (heilung <= 0)
        {
            return;
        }

        Leben += heilung;

        if (Leben > MaxLeben)
        {
            Leben = MaxLeben;
        }
    }

    public void GreifeAn(Gegner gegner)
    {
        Console.WriteLine(Name + " greift " + gegner.Name + " an.");
        gegner.SchadenNehmen(Schaden);
    }

    public void GoldHinzufuegen(int betrag)
    {
        if (betrag > 0)
        {
            Gold += betrag;
        }
    }

    public bool IstBesiegt()
    {
        return Leben <= 0;
    }

    public void ZeigeInfo()
    {
        Console.WriteLine(Name + ": " + Leben + "/" + MaxLeben + " Leben, " + Gold + " Gold");
    }
}
```

## Klasse `Gegner`

```csharp
class Gegner
{
    public string Name { get; set; }
    public int Leben { get; private set; }
    public int Schaden { get; private set; }
    public int Belohnung { get; private set; }

    public Gegner(string name, int leben, int schaden, int belohnung)
    {
        Name = name;
        Leben = leben;
        Schaden = schaden;
        Belohnung = belohnung;
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

    public void GreifeAn(Spieler spieler)
    {
        Console.WriteLine(Name + " greift " + spieler.Name + " an.");
        spieler.SchadenNehmen(Schaden);
    }

    public bool IstBesiegt()
    {
        return Leben <= 0;
    }

    public void ZeigeInfo()
    {
        Console.WriteLine(Name + ": " + Leben + " Leben");
    }
}
```

## Hauptprogramm

```csharp
Spieler spieler = new Spieler("Lena", 100, 25);
Gegner gegner = new Gegner("Goblin", 60, 15, 20);

while (!spieler.IstBesiegt() && !gegner.IstBesiegt())
{
    spieler.GreifeAn(gegner);
    gegner.ZeigeInfo();

    if (!gegner.IstBesiegt())
    {
        gegner.GreifeAn(spieler);
        spieler.ZeigeInfo();
    }

    Console.WriteLine();
}

if (gegner.IstBesiegt())
{
    Console.WriteLine(gegner.Name + " wurde besiegt.");
    spieler.GoldHinzufuegen(gegner.Belohnung);
}
else
{
    Console.WriteLine(spieler.Name + " wurde besiegt.");
}

spieler.ZeigeInfo();
```

---

# 15. Warum gehört die Logik in die Klassen?

Ohne passende Methoden würde das Hauptprogramm direkt Werte verändern:

```csharp
gegner.Leben -= spieler.Schaden;
spieler.Leben -= gegner.Schaden;
```

Dadurch müsste das Hauptprogramm selbst auf gültige Werte achten.

Mit Kapselung übernehmen die Objekte diese Verantwortung:

```csharp
spieler.GreifeAn(gegner);
gegner.GreifeAn(spieler);
```

Das Hauptprogramm beschreibt dadurch eher **was passiert**.

Die Klassen bestimmen **wie es passiert**.

```text
Programmlogik: Der Spieler greift den Gegner an.
Klassenlogik: Schaden berechnen und Leben begrenzen.
```

---

# 16. Typische Fehler

## Fehler 1: `private set` verhindert auch interne Änderungen

Falsch gedacht:

```text
Mit private set kann der Wert gar nicht mehr verändert werden.
```

Richtig:

```text
Die Property kann weiterhin innerhalb der eigenen Klasse verändert werden.
```

---

## Fehler 2: Die Liste wurde nicht erstellt

```csharp
public List<Item> Inventar { get; private set; }
```

Alleine reicht diese Property nicht aus.

Im Konstruktor muss eine Liste erstellt werden:

```csharp
Inventar = new List<Item>();
```

Sonst entsteht beim Hinzufügen eines Items ein Fehler.

---

## Fehler 3: Ein neues Objekt statt des vorhandenen Objekts verwenden

```csharp
gegner.GreifeAn(new Spieler("Test", 100, 10));
```

Hier wird ein neuer Spieler angegriffen, nicht das bereits vorhandene Spielerobjekt.

Richtig:

```csharp
gegner.GreifeAn(spieler);
```

---

## Fehler 4: Objekt und Klasse verwechseln

Falsch:

```csharp
Spieler.SchadenNehmen(20);
```

`Spieler` ist der Name der Klasse.

Richtig:

```csharp
spieler.SchadenNehmen(20);
```

`spieler` ist ein konkretes Objekt.

---

## Fehler 5: Ungültige Werte nicht prüfen

```csharp
public void Heilen(int heilung)
{
    Leben += heilung;
}
```

Dadurch könnte auch Folgendes ausgeführt werden:

```csharp
spieler.Heilen(-50);
```

Besser:

```csharp
if (heilung <= 0)
{
    return;
}
```

---

# 17. Zusammenfassung

## Kapselung

```text
Eine Klasse schützt ihre Daten
und kontrolliert Änderungen über Properties und Methoden.
```

Beispiel:

```csharp
public int Leben { get; private set; }
```

Änderungen erfolgen über Methoden:

```csharp
spieler.SchadenNehmen(20);
spieler.Heilen(10);
```

## Objekte miteinander verbinden

Ein Objekt kann an eine Methode übergeben werden:

```csharp
gegner.GreifeAn(spieler);
```

Ein Objekt kann ein anderes Objekt speichern:

```csharp
public Waffe AusgeruesteteWaffe { get; private set; }
```

Ein Objekt kann eine Liste anderer Objekte besitzen:

```csharp
public List<Item> Inventar { get; private set; }
```

## Wichtige Merksätze

```text
Ein Objekt soll selbst kontrollieren, wie seine Daten verändert werden.
```

```text
Methoden beschreiben das Verhalten eines Objekts.
```

```text
Objekte können andere Objekte verwenden und speichern.
```

```text
Das Hauptprogramm sagt, was passiert.
Die Klassen regeln, wie es passiert.
```
