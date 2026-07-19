# Übung 2 – Dorfverwaltung in einem Aufbauspiel

## Aufgabenstellung

Erstelle ein Verwaltungssystem für ein Dorf in einem Aufbauspiel.

Dabei sollen Vererbung, Polymorphie und Objektbeziehungen kombiniert werden.

```text
Gebaeude
├── Wohnhaus
├── Bauernhof
└── Werkstatt

Dorfbewohner
```

---

## Allgemeine Vorgaben

- Verwende passende Konstruktoren.
- Verwende bei geeigneten Properties `private set` oder `protected set`.
- Überprüfe ungültige Eingaben.
- Verwende `virtual` und `override`.
- Speichere unterschiedliche Gebäude gemeinsam in einer `List<Gebaeude>`.
- Verbinde Dorfbewohner und Wohnhäuser über echte Objektbeziehungen.
- Verwende `#region` und `#endregion`.

---

# Klasse `Gebaeude`

```csharp
public string Name { get; protected set; }
public int Baukosten { get; protected set; }
public int Stufe { get; protected set; }
public bool IstAktiv { get; protected set; }
```

Beim Erstellen gilt:

- `Stufe` beginnt bei `1`.
- `IstAktiv` beginnt bei `true`.
- Der Name darf nicht leer sein.
- Die Baukosten dürfen nicht negativ sein.

## Methoden

```csharp
public virtual void Verbessern()
public void Deaktivieren()
public void Aktivieren()
public virtual int BerechneProduktion()
public virtual void ZeigeInfo()
```

`BerechneProduktion()` gibt in der Basisklasse zunächst `0` zurück.

---

# Klasse `Wohnhaus`

```csharp
public int MaximaleBewohner { get; private set; }
public List<Dorfbewohner> Bewohner { get; private set; }
```

Die Bewohnerliste soll im Konstruktor leer erstellt werden.

## Methoden

```csharp
public bool HatFreienPlatz()
public bool BewohnerHinzufuegen(Dorfbewohner dorfbewohner)
public bool BewohnerEntfernen(Dorfbewohner dorfbewohner)
public void ZeigeBewohner()
```

Beim Überschreiben von `Verbessern()` soll:

- die Gebäudestufe steigen,
- Platz für zwei zusätzliche Bewohner entstehen.

`ZeigeInfo()` soll zusätzlich maximale und aktuelle Bewohneranzahl ausgeben.

---

# Klasse `Bauernhof`

```csharp
public int Felder { get; private set; }
public int NahrungProFeld { get; private set; }
```

Produktion:

```text
Felder × NahrungProFeld × Stufe
```

Ein deaktivierter Bauernhof produziert `0`.

Beim Verbessern soll:

- die Stufe steigen,
- ein zusätzliches Feld freigeschaltet werden.

---

# Klasse `Werkstatt`

```csharp
public int Arbeiter { get; private set; }
public int ProduktionProArbeiter { get; private set; }
```

Produktion:

```text
Arbeiter × ProduktionProArbeiter × Stufe
```

Eine deaktivierte Werkstatt produziert `0`.

Beim Verbessern soll:

- die Stufe steigen,
- ein zusätzlicher Arbeiterplatz entstehen.

---

# Klasse `Dorfbewohner`

```csharp
public string Name { get; private set; }
public int Alter { get; private set; }
public string Geschlecht { get; private set; }
public string Beruf { get; private set; }
public Wohnhaus? Wohnort { get; private set; }
```

Der Wohnort soll anfangs `null` sein.

Regeln:

- Der Name darf nicht leer sein.
- Das Alter darf nicht negativ sein.
- Das Geschlecht darf nicht leer sein.
- Der Beruf darf nicht leer sein.

## Methoden

```csharp
public bool WohnortZuweisen(Wohnhaus wohnhaus)
public bool WohnortVerlassen()
public void BerufAendern(string neuerBeruf)
public void Geburtstag()
public void ZeigeInfo()
```

Ein Wohnort darf nur zugewiesen werden, wenn:

- das Wohnhaus nicht `null` ist,
- noch Platz vorhanden ist,
- der Dorfbewohner noch keinen Wohnort besitzt.

---

# Programmablauf

1. Erstelle mindestens zwei Wohnhäuser.
2. Erstelle mindestens zwei Bauernhöfe.
3. Erstelle mindestens zwei Werkstätten.
4. Speichere alle Gebäude in einer `List<Gebaeude>`.
5. Erstelle mindestens sechs Dorfbewohner.
6. Weise unterschiedliche Berufe zu.
7. Weise die Dorfbewohner verschiedenen Wohnhäusern zu.
8. Überschreite testweise die Kapazität eines Wohnhauses.
9. Versuche, einen Bewohner zwei Wohnhäusern gleichzeitig zuzuweisen.
10. Gib alle Gebäudeinformationen aus.
11. Gib die Bewohner jedes Wohnhauses aus.
12. Verbessere jedes Gebäude einmal.
13. Deaktiviere mindestens einen Bauernhof und eine Werkstatt.
14. Gib die Produktion aller Gebäude aus.
15. Berechne die gesamte Nahrung aller Bauernhöfe.
16. Berechne die gesamte Produktion aller Werkstätten.
17. Gib nur aktive Gebäude aus.
18. Ändere den Beruf eines Dorfbewohners.
19. Lasse einen Dorfbewohner ausziehen und in ein anderes Haus einziehen.
20. Gib abschließend alle Dorfbewohner mit Wohnort und Beruf aus.

---

## Beispiel für Polymorphie

```csharp
foreach (Gebaeude gebaeude in gebaeudeListe)
{
    gebaeude.ZeigeInfo();
    Console.WriteLine($"Produktion: {gebaeude.BerechneProduktion()}");
}
```
