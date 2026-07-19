# Übung 1 – Mitarbeiterverwaltung

## Aufgabenstellung

Erstelle eine kleine Mitarbeiterverwaltung mit Vererbung und Polymorphie.

Die Klassenstruktur soll folgendermaßen aufgebaut sein:

```text
Mitarbeiter
├── Entwickler
├── Designer
└── Projektleiter
```

---

## Allgemeine Vorgaben

- Verwende passende Konstruktoren.
- Verwende bei geeigneten Properties `private set` oder `protected set`.
- Überprüfe ungültige Eingaben.
- Verwende `virtual` und `override`.
- Speichere unterschiedliche Mitarbeiter gemeinsam in einer `List<Mitarbeiter>`.
- Verwende `#region` und `#endregion`, um deine Klassen sinnvoll zu gliedern.
- Gib alle wichtigen Informationen übersichtlich in der Konsole aus.

---

# Klasse `Mitarbeiter`

```csharp
public string Name { get; protected set; }
public decimal Grundgehalt { get; protected set; }
```

Der Name und das Grundgehalt sollen über einen Konstruktor gesetzt werden.

Regeln:

- Der Name darf nicht leer sein.
- Das Grundgehalt darf nicht negativ sein.

## Methoden

```csharp
public virtual decimal BerechneMonatsgehalt()
public virtual void ZeigeInfo()
```

`BerechneMonatsgehalt()` gibt in der Basisklasse zunächst das Grundgehalt zurück.

---

# Klasse `Entwickler`

`Entwickler` erbt von `Mitarbeiter`.

```csharp
public int Ueberstunden { get; private set; }
```

- Überstunden dürfen nicht negativ sein.
- Pro Überstunde werden `25 €` zum Grundgehalt addiert.

```text
Grundgehalt + Ueberstunden × 25 €
```

`BerechneMonatsgehalt()` und `ZeigeInfo()` sollen überschrieben werden.

---

# Klasse `Designer`

`Designer` erbt von `Mitarbeiter`.

```csharp
public decimal Projektbonus { get; private set; }
```

- Der Projektbonus darf nicht negativ sein.

```text
Grundgehalt + Projektbonus
```

`BerechneMonatsgehalt()` und `ZeigeInfo()` sollen überschrieben werden.

---

# Klasse `Projektleiter`

`Projektleiter` erbt von `Mitarbeiter`.

```csharp
public int AnzahlProjekte { get; private set; }
```

- Die Anzahl der Projekte darf nicht negativ sein.
- Pro betreutem Projekt werden `150 €` addiert.

```text
Grundgehalt + AnzahlProjekte × 150 €
```

`BerechneMonatsgehalt()` und `ZeigeInfo()` sollen überschrieben werden.

---

# Programmablauf

1. Erstelle mindestens zwei Entwickler.
2. Erstelle mindestens zwei Designer.
3. Erstelle mindestens einen Projektleiter.
4. Speichere alle Mitarbeiter gemeinsam in:

```csharp
List<Mitarbeiter>
```

5. Gib für jeden Mitarbeiter die Informationen aus.
6. Berechne für jeden Mitarbeiter das Monatsgehalt.
7. Berechne die gesamten Personalkosten des Unternehmens.
8. Ermittle den Mitarbeiter mit dem höchsten Monatsgehalt.
9. Gib nur jene Mitarbeiter aus, deren Monatsgehalt über `3500 €` liegt.

---

## Beispiel für Polymorphie

```csharp
foreach (Mitarbeiter mitarbeiter in mitarbeiterListe)
{
    mitarbeiter.ZeigeInfo();
    Console.WriteLine();
}
```
