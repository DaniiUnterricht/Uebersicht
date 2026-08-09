# PE20.2 – Godot mit C#: Skripte und Nodes ansprechen

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

## Voraussetzung

Für diese Unterlage wird die Szene aus **Grundlagen** verwendet:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── ActionButton
    └── ResetButton
```

Die Szene wurde gespeichert unter:

```text
Scenes/Main.tscn
```

---

## Lernziele

Nach dieser Einheit kannst du:

- ein C#-Skript an einen Godot-Node anhängen,
- den Aufbau einer Godot-C#-Klasse erklären,
- `using Godot` verwenden,
- erklären, warum Godot-Klassen `partial` sind,
- eine Godot-Klasse von einem Node-Typ erben lassen,
- `_Ready()` überschreiben,
- mit `GD.Print()` eine Ausgabe erzeugen,
- Nodes mit `GetNode<T>()` suchen,
- relative Node-Pfade lesen,
- Properties eines Nodes über C# verändern.

---

# 1. Skript an den Root Node anhängen

Wähle im Scene Tree:

```text
Main
```

Danach:

```text
Attach Script
```

Verwende:

```text
Language: C#
Path: Scripts/Main.cs
```

Das Skript kommt auf `Main`, weil dieser Node die gesamte Benutzeroberfläche enthält.

---

# 2. Das erste Godot-C#-Skript

```csharp
using Godot;

public partial class Main : Control
{
}
```

---

# 3. `using Godot`

```csharp
using Godot;
```

Damit können Godot-Klassen verwendet werden:

```csharp
Node
Control
Label
Button
Vector2
Color
```

Ohne `using Godot` müsste beispielsweise geschrieben werden:

```csharp
Godot.Label
```

---

# 4. Aufbau der Klasse

```csharp
public partial class Main : Control
{
}
```

| Bestandteil | Bedeutung |
|---|---|
| `public` | Klasse ist öffentlich erreichbar |
| `partial` | Klasse kann aus mehreren Teilen bestehen |
| `class Main` | Klasse heißt `Main` |
| `: Control` | Klasse erbt von `Control` |

---

# 5. Warum `partial`?

Godot-C#-Skripte werden normalerweise als partielle Klassen geschrieben:

```csharp
public partial class Main : Control
```

Vereinfacht bedeutet das:

> Einen Teil der Klasse schreiben wir selbst. Weitere benötigte Bestandteile können von Godot ergänzt werden.

---

# 6. Vererbung vom Node-Typ

Der Root Node der Szene ist ein:

```text
Control
```

Deshalb erbt das Skript von:

```csharp
Control
```

```csharp
public partial class Main : Control
{
}
```

Weitere Beispiele:

```csharp
public partial class Room : Node2D
{
}
```

```csharp
public partial class Player : CharacterBody2D
{
}
```

```csharp
public partial class MenuButton : Button
{
}
```

---

# 7. Godot erstellt die Nodes

In einem normalen C#-Programm könnte ein Objekt so erstellt werden:

```csharp
Button startButton = new Button();
```

In Godot wurden die Nodes bereits im Editor erstellt und in der Szene gespeichert.

```text
Main
└── VBoxContainer
    └── ActionButton
```

Beim Start der Szene erzeugt Godot diese Node-Instanzen.

Das Skript benötigt daher meist nur eine Referenz auf den vorhandenen Node.

---

# 8. `_Ready()`

```csharp
public override void _Ready()
{
}
```

Godot ruft `_Ready()` automatisch auf, wenn der Node und seine Child Nodes im Scene Tree bereit sind.

Die Methode wird nicht selbst gestartet:

```csharp
// Nicht notwendig:
_Ready();
```

---

## Erstes Beispiel

```csharp
using Godot;

public partial class Main : Control
{
    public override void _Ready()
    {
        GD.Print("Main ist bereit.");
    }
}
```

Im Output erscheint:

```text
Main ist bereit.
```

---

# 9. Warum `override`?

`_Ready()` ist bereits in der Basisklasse `Node` vorhanden.

Mit:

```csharp
override
```

wird die geerbte Methode für unsere Klasse überschrieben.

Das ist ein Anwendungsfall von Vererbung und Polymorphie.

---

# 10. `GD.Print()`

In Konsolenprogrammen wurde verwendet:

```csharp
Console.WriteLine("Hallo");
```

In Godot wird häufig verwendet:

```csharp
GD.Print("Hallo");
```

Die Ausgabe erscheint im Bereich:

```text
Output
```

Beispiele:

```csharp
GD.Print("Szene gestartet.");
```

```csharp
int level = 5;

GD.Print($"Aktuelles Level: {level}");
```

`GD.Print()` verändert nichts sichtbar in der Szene. Es dient hauptsächlich zum Testen und Debuggen.

---

# 11. Node-Referenzen als Felder

Wir möchten auf diese Nodes zugreifen:

```text
TitleLabel
DescriptionLabel
StatusLabel
ActionButton
ResetButton
```

Dafür werden Felder erstellt:

```csharp
private Label _titleLabel = null!;
private Label _descriptionLabel = null!;
private Label _statusLabel = null!;

private Button _actionButton = null!;
private Button _resetButton = null!;
```

Die Referenzen werden als Felder gespeichert, weil sie später in mehreren Methoden benötigt werden.

---

# 12. Was bedeutet `null!`?

Beim Erstellen des `Main`-Objekts sind die Node-Referenzen noch nicht gesetzt.

Die Zuweisung erfolgt erst in `_Ready()`.

```csharp
private Label _statusLabel = null!;
```

`null!` bedeutet:

> Der Wert ist momentan noch nicht vorhanden. Wir versichern dem Compiler, dass er vor der Verwendung gesetzt wird.

Wichtig:

`null!` sucht keinen Node und verhindert keinen Laufzeitfehler.

Die Referenz muss weiterhin korrekt gesetzt werden.

---

# 13. `GetNode<T>()`

Mit `GetNode<T>()` wird ein vorhandener Node im Scene Tree gesucht.

```csharp
_statusLabel =
    GetNode<Label>("VBoxContainer/StatusLabel");
```

Die Methode erstellt keinen neuen Node.

---

## Typ

```csharp
GetNode<Label>
```

Der gefundene Node soll als `Label` verwendet werden.

---

## Pfad

```csharp
"VBoxContainer/StatusLabel"
```

Der Pfad beschreibt den Weg vom aktuellen Node zum gesuchten Node.

---

# 14. Relative Node-Pfade

Das Skript liegt auf:

```text
Main
```

Der gesuchte Node liegt hier:

```text
Main
└── VBoxContainer
    └── StatusLabel
```

Der relative Pfad lautet:

```text
VBoxContainer/StatusLabel
```

Im Code:

```csharp
GetNode<Label>(
    "VBoxContainer/StatusLabel"
);
```

---

## Weitere Pfade

```csharp
GetNode<Label>(
    "VBoxContainer/TitleLabel"
);
```

```csharp
GetNode<Label>(
    "VBoxContainer/DescriptionLabel"
);
```

```csharp
GetNode<Button>(
    "VBoxContainer/ActionButton"
);
```

```csharp
GetNode<Button>(
    "VBoxContainer/ResetButton"
);
```

---

# 15. Node-Typ und Node-Name

```csharp
GetNode<Button>(
    "VBoxContainer/ActionButton"
);
```

Dabei ist:

```text
Button
```

der Typ beziehungsweise die Klasse.

```text
ActionButton
```

ist der Name der konkreten Node-Instanz.

Vergleich:

```csharp
Button actionButton;
```

---

# 16. Alle Nodes holen

```csharp
using Godot;

public partial class Main : Control
{
    private Label _titleLabel = null!;
    private Label _descriptionLabel = null!;
    private Label _statusLabel = null!;

    private Button _actionButton = null!;
    private Button _resetButton = null!;

    public override void _Ready()
    {
        _titleLabel =
            GetNode<Label>(
                "VBoxContainer/TitleLabel"
            );

        _descriptionLabel =
            GetNode<Label>(
                "VBoxContainer/DescriptionLabel"
            );

        _statusLabel =
            GetNode<Label>(
                "VBoxContainer/StatusLabel"
            );

        _actionButton =
            GetNode<Button>(
                "VBoxContainer/ActionButton"
            );

        _resetButton =
            GetNode<Button>(
                "VBoxContainer/ResetButton"
            );

        GD.Print("Alle Nodes wurden gefunden.");
    }
}
```

---

# 17. Node-Properties verändern

Nachdem ein Node gefunden wurde, können seine Properties verändert werden.

## Label-Text

```csharp
_statusLabel.Text =
    "C#-Skript wurde geladen.";
```

## Button-Text

```csharp
_actionButton.Text =
    "Neue Aktion";
```

## Sichtbarkeit

```csharp
_statusLabel.Visible = false;
```

```csharp
_statusLabel.Visible = true;
```

## Button deaktivieren

```csharp
_resetButton.Disabled = true;
```

## Button aktivieren

```csharp
_resetButton.Disabled = false;
```

---

# 18. Gemeinsames Beispiel

```csharp
using Godot;

public partial class Main : Control
{
    private Label _titleLabel = null!;
    private Label _descriptionLabel = null!;
    private Label _statusLabel = null!;

    private Button _actionButton = null!;
    private Button _resetButton = null!;

    public override void _Ready()
    {
        _titleLabel =
            GetNode<Label>(
                "VBoxContainer/TitleLabel"
            );

        _descriptionLabel =
            GetNode<Label>(
                "VBoxContainer/DescriptionLabel"
            );

        _statusLabel =
            GetNode<Label>(
                "VBoxContainer/StatusLabel"
            );

        _actionButton =
            GetNode<Button>(
                "VBoxContainer/ActionButton"
            );

        _resetButton =
            GetNode<Button>(
                "VBoxContainer/ResetButton"
            );

        _titleLabel.Text =
            "Godot mit C# gestartet";

        _descriptionLabel.Text =
            "Nodes wurden über C# gefunden.";

        _statusLabel.Text =
            "Bereit für die nächste Einheit";

        _actionButton.Disabled = false;
        _resetButton.Disabled = true;

        GD.Print(
            "Main-Szene wurde vollständig geladen."
        );
    }
}
```

---

# 19. Was passiert beim Start?

```text
1. Godot lädt Main.tscn.
2. Godot erstellt die gespeicherten Nodes.
3. Main.cs gehört zum Root Node Main.
4. Godot ruft Main._Ready() auf.
5. GetNode<T>() sucht die Child Nodes.
6. Die Referenzen werden in Feldern gespeichert.
7. Die Properties der Nodes werden verändert.
```

---

# 20. Häufige Fehler

## Falscher Pfad

Falsch:

```csharp
GetNode<Label>("StatusLabel");
```

Richtig:

```csharp
GetNode<Label>(
    "VBoxContainer/StatusLabel"
);
```

---

## Falscher Node-Name

```csharp
GetNode<Label>(
    "VBoxContainer/Status"
);
```

Der tatsächliche Name lautet aber:

```text
StatusLabel
```

---

## Falscher Typ

Falsch:

```csharp
GetNode<Button>(
    "VBoxContainer/StatusLabel"
);
```

Richtig:

```csharp
GetNode<Label>(
    "VBoxContainer/StatusLabel"
);
```

---

## Node wurde umbenannt

Wird:

```text
StatusLabel
```

zu:

```text
InfoLabel
```

umbenannt, muss auch der Pfad geändert werden:

```csharp
GetNode<Label>(
    "VBoxContainer/InfoLabel"
);
```

---

## Skript liegt auf dem falschen Node

Das Skript erbt von:

```csharp
Control
```

Es muss daher auf einem passenden `Control`-Node oder einer davon erbenden Klasse liegen.

---

# 21. Alternative mit `[Export]`

Node-Referenzen können später auch über den Inspector zugewiesen werden:

```csharp
[Export]
private Label _statusLabel = null!;
```

Diese Variante wird in einer späteren Einheit genauer behandelt.

In dieser Einheit verwenden wir bewusst:

```csharp
GetNode<T>()
```

Dadurch üben wir:

- Scene Tree,
- Node-Pfade,
- Node-Typen,
- Referenzen.

---

# 22. Übung im Unterricht

Verwende die Szene aus PE20.1.

Erstelle:

```text
Scripts/Main.cs
```

Hänge das Skript an:

```text
Main
```

---

## Aufgabe 1

Erstelle Felder für:

```text
TitleLabel
DescriptionLabel
StatusLabel
ActionButton
ResetButton
```

---

## Aufgabe 2

Hole alle Nodes in `_Ready()` mit:

```csharp
GetNode<T>()
```

---

## Aufgabe 3

Setze beim Start folgende Werte:

```text
TitleLabel:
Godot mit C# gestartet

DescriptionLabel:
Nodes wurden erfolgreich über C# gefunden.

StatusLabel:
Bereit für die nächste Einheit

ActionButton:
aktiv

ResetButton:
deaktiviert
```

---

## Aufgabe 4

Gib im Output aus:

```text
Main-Szene wurde vollständig geladen.
```

---

## Vorgegebene Grundstruktur

```csharp
using Godot;

public partial class Main : Control
{
    // Felder für die Nodes

    public override void _Ready()
    {
        // Nodes mit GetNode<T>() holen

        // Properties verändern

        // Ausgabe mit GD.Print()
    }
}
```

---

# 23. Zusatzaufgabe

Füge im Editor einen weiteren Node hinzu:

```text
InfoLabel
```

Der Scene Tree:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── InfoLabel
    ├── ActionButton
    └── ResetButton
```

Ergänze im Skript:

- ein privates Feld,
- den passenden `GetNode<Label>()`-Aufruf,
- einen neuen Text.

Text:

```text
Nächster Schritt: Button-Events
```

---

# 24. Kontrollfragen

1. Warum wird `using Godot` benötigt?
2. Was bedeutet `partial`?
3. Von welcher Klasse erbt `Main`?
4. Wer ruft `_Ready()` auf?
5. Was bedeutet `override`?
6. Wo erscheint `GD.Print()`?
7. Erstellt `GetNode<T>()` einen neuen Node?
8. Was bedeutet der Typ in `GetNode<Label>()`?
9. Was beschreibt `"VBoxContainer/StatusLabel"`?
10. Warum speichern wir Node-Referenzen als Felder?
11. Was bedeutet `null!`?
12. Was passiert bei einem falschen Node-Pfad?
13. Was ist der Unterschied zwischen `Button` und `ActionButton`?
14. Welche Property verändert den Text eines Labels?
15. Welche Property deaktiviert einen Button?

---

# 25. Kurzüberblick

| Schreibweise | Bedeutung |
|---|---|
| `using Godot;` | Godot-Klassen verwenden |
| `partial class` | Klasse kann aus mehreren Teilen bestehen |
| `: Control` | Von `Control` erben |
| `_Ready()` | Wird von Godot automatisch aufgerufen |
| `override` | Geerbte Methode überschreiben |
| `GD.Print()` | Ausgabe im Godot-Output |
| `GetNode<T>()` | Vorhandenen Node suchen |
| `Label` | Datentyp des Nodes |
| `StatusLabel` | Name der Node-Instanz |
| `.Text` | Sichtbaren Text verändern |
| `.Visible` | Sichtbarkeit verändern |
| `.Disabled` | Button aktivieren oder deaktivieren |
| `null!` | Nullable-Warnung bewusst unterdrücken |

---

# Merksätze

> Ein Godot-C#-Skript ist eine Klasse, die von einem Godot-Node-Typ erbt.

> Godot erstellt die Nodes aus der gespeicherten Szene.

> `_Ready()` wird von Godot automatisch aufgerufen.

> `GetNode<T>()` erstellt keinen neuen Node, sondern sucht einen vorhandenen Node.

> Der Node-Pfad beginnt relativ bei dem Node, auf dem das Skript liegt.

> Über eine gespeicherte Node-Referenz können Properties und Methoden des Nodes verwendet werden.

---

# Ausblick auf Godot UI und Events

In der nächsten Unterlage werden die vorhandenen Buttons mit Events verbunden:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

Danach können Button-Klicks:

- einen Zähler verändern,
- den Text des Status-Labels aktualisieren,
- Buttons aktivieren oder deaktivieren,
- die Oberfläche zurücksetzen.
