# Schüler-Steckbrief

## Aufgabenstellung

Erstelle ein C#-Programm mit einer eigenen Klasse `Schueler`.

Die Klasse soll folgende Eigenschaften besitzen:

- `Name`
- `Alter`
- `Klasse`

Danach sollen zwei Schüler-Objekte erstellt und ausgegeben werden.

## Anforderungen

Die Klasse soll mit Properties arbeiten.

```csharp
public string Name { get; set; }
```

Erstelle danach in der `Main()` zwei Objekte.

Beispiel:

```csharp
Schueler s1 = new Schueler();
s1.Name = "Max";
s1.Alter = 16;
s1.Klasse = "2AHIT";
```

## Ausgabe

Das Programm soll beide Schüler übersichtlich ausgeben.

### Beispielausgabe

```text
Schüler 1:
Name: Max
Alter: 16
Klasse: 2AHIT

Schüler 2:
Name: Anna
Alter: 17
Klasse: 2BHIT
```

## Zusatzaufgabe

Erweitere die Klasse um eine weitere Eigenschaft.

Beispiele:

- `Lieblingsfach`
- `Wohnort`
- `Hobby`

## Hinweise

- Die Klasse steht außerhalb der `Program`-Klasse.
- Die Objekte werden mit `new` erstellt.
- Auf Eigenschaften greift man mit dem Punkt zu.
