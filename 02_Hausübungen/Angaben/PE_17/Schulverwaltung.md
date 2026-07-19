# Übung 3 – Schulverwaltung

## Aufgabenstellung

Erstelle ein Verwaltungssystem für Personen an einer Schule.

Dabei sollen mehrstufige Vererbung und Polymorphie verwendet werden.

```text
Person
├── Schueler
│   ├── Tagesschueler
│   └── Abendschueler
└── Lehrkraft
    ├── Fachlehrer
    └── Klassenvorstand
```

---

## Allgemeine Vorgaben

- Verwende passende Konstruktoren.
- Verwende bei geeigneten Properties `private set` oder `protected set`.
- Überprüfe ungültige Eingaben.
- Verwende `virtual` und `override`.
- Verwende mehrstufige Vererbung.
- Speichere unterschiedliche Personen gemeinsam in einer `List<Person>`.
- Verwende `#region` und `#endregion`.

---

# Klasse `Person`

```csharp
public string Vorname { get; protected set; }
public string Nachname { get; protected set; }
public int Alter { get; protected set; }
```

Regeln:

- Vorname und Nachname dürfen nicht leer sein.
- Das Alter darf nicht negativ sein.

## Methoden

```csharp
public void Geburtstag()
public virtual void ZeigeInfo()
```

---

# Klasse `Schueler`

`Schueler` erbt von `Person`.

```csharp
public string Klasse { get; protected set; }
public List<int> Noten { get; protected set; }
```

Die Notenliste soll im Konstruktor leer erstellt werden.

## Methoden

```csharp
public void NoteHinzufuegen(int note)
public double BerechneNotendurchschnitt()
public override void ZeigeInfo()
```

Regeln:

- Es dürfen nur Noten von `1` bis `5` hinzugefügt werden.
- Sind keine Noten vorhanden, soll der Durchschnitt `0` sein.

---

# Klasse `Tagesschueler`

`Tagesschueler` erbt von `Schueler`.

```csharp
public bool BesuchtNachmittagsbetreuung { get; private set; }
```

`ZeigeInfo()` soll zusätzlich anzeigen, ob die Nachmittagsbetreuung besucht wird.

---

# Klasse `Abendschueler`

`Abendschueler` erbt von `Schueler`.

```csharp
public string Beruf { get; private set; }
```

Der Beruf darf nicht leer sein.

`ZeigeInfo()` soll zusätzlich den Beruf ausgeben.

---

# Klasse `Lehrkraft`

`Lehrkraft` erbt von `Person`.

```csharp
public string Personalnummer { get; protected set; }
public int Wochenstunden { get; protected set; }
```

Regeln:

- Die Personalnummer darf nicht leer sein.
- Die Wochenstunden dürfen nicht negativ sein.

## Methoden

```csharp
public virtual int BerechneArbeitsbelastung()
public override void ZeigeInfo()
```

Die Basisklasse gibt zunächst die Wochenstunden zurück.

---

# Klasse `Fachlehrer`

`Fachlehrer` erbt von `Lehrkraft`.

```csharp
public List<string> Faecher { get; private set; }
```

Arbeitsbelastung:

```text
Wochenstunden + Anzahl der Fächer × 2
```

`ZeigeInfo()` soll zusätzlich alle Fächer ausgeben.

---

# Klasse `Klassenvorstand`

`Klassenvorstand` erbt von `Lehrkraft`.

```csharp
public string BetreuteKlasse { get; private set; }
public int AnzahlSchueler { get; private set; }
```

Regeln:

- Die betreute Klasse darf nicht leer sein.
- Die Anzahl der Schüler darf nicht negativ sein.

Arbeitsbelastung:

```text
Wochenstunden + 5 + AnzahlSchueler
```

`ZeigeInfo()` soll zusätzlich die betreute Klasse und die Anzahl der Schüler ausgeben.

---

# Programmablauf

1. Erstelle mindestens zwei Tagesschüler.
2. Erstelle mindestens zwei Abendschüler.
3. Füge jedem Schüler mehrere Noten hinzu.
4. Erstelle mindestens zwei Fachlehrer.
5. Erstelle mindestens einen Klassenvorstand.
6. Speichere alle Personen in einer `List<Person>`.
7. Gib alle Personen über eine Schleife aus.
8. Speichere alle Schüler zusätzlich in einer `List<Schueler>`.
9. Gib den Notendurchschnitt jedes Schülers aus.
10. Ermittle den Schüler mit dem besten Notendurchschnitt.
11. Speichere alle Lehrkräfte in einer `List<Lehrkraft>`.
12. Berechne für jede Lehrkraft die Arbeitsbelastung.
13. Berechne die gesamte Arbeitsbelastung aller Lehrkräfte.
14. Gib nur die Abendschüler aus.
15. Gib nur Personen aus, die mindestens 18 Jahre alt sind.
16. Lasse mindestens eine Person Geburtstag haben.
17. Gib danach die aktualisierten Informationen aus.

---

## Beispiel für Polymorphie

```csharp
foreach (Person person in personen)
{
    person.ZeigeInfo();
    Console.WriteLine();
}
```

## Beispiel für mehrstufige Vererbung

Ein `Abendschueler` erbt direkt von `Schueler` und indirekt von `Person`.
