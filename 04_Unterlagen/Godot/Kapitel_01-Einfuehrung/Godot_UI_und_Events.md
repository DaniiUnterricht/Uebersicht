# Godot mit C#: UI und Events

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

## Voraussetzung

Für diese Unterlage wird die Szene aus **Grundlagen** und das Skript aus **CSharp Grundlagen in Godot** verwendet.

Scene Tree:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── ActionButton
    └── ResetButton
```

Skript:

```text
Scripts/Main.cs
```

---

## Lernziele

Nach dieser Einheit kannst du:

- ein Godot-Event in C# abonnieren,
- einen Event-Handler schreiben,
- erklären, welcher Node Sender ist,
- erklären, welche Methode auf das Event reagiert,
- einen Klickzähler umsetzen,
- UI-Properties während der Laufzeit verändern,
- einen Zustand zurücksetzen,
- Event-Handler wieder abmelden.

---

# 1. Wiederholung: Events

Ein Event meldet, dass etwas passiert ist.

Beispiel:

```text
Button wurde gedrückt
        ↓
Pressed-Event wird ausgelöst
        ↓
Angemeldete Methode wird ausgeführt
```

In Godot besitzt ein `Button` das Event:

```csharp
Pressed
```

---

# 2. Sender und Event-Handler

Bei dieser Zeile:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

ist:

```text
_actionButton
```

der Sender.

```text
Pressed
```

ist das Event.

```text
OnActionButtonPressed
```

ist der Event-Handler.

```text
+=
```

meldet die Methode beim Event an.

---

## Merksatz

> Ein Objekt reagiert auf ein Event, indem eine passende Methode mit `+=` beim Event angemeldet wird.

---

# 3. Event in `_Ready()` verbinden

Die Buttons wurden bereits mit `GetNode<T>()` gefunden.

Danach werden die Events verbunden:

```csharp
public override void _Ready()
{
    _actionButton =
        GetNode<Button>(
            "VBoxContainer/ActionButton"
        );

    _resetButton =
        GetNode<Button>(
            "VBoxContainer/ResetButton"
        );

    _actionButton.Pressed +=
        OnActionButtonPressed;

    _resetButton.Pressed +=
        OnResetButtonPressed;
}
```

---

# 4. Event-Handler schreiben

Ein `Pressed`-Event besitzt keine Parameter.

Deshalb benötigt der Event-Handler ebenfalls keine Parameter:

```csharp
private void OnActionButtonPressed()
{
}
```

Die Signatur muss zum Event passen.

---

## Unpassende Methode

```csharp
private void OnActionButtonPressed(int number)
{
}
```

Diese Methode kann nicht beim `Pressed`-Event angemeldet werden.

Der Compiler zeigt einen Fehler, weil das Event keine Parameter erwartet.

---

# 5. Klickzähler erstellen

Für den Klickzähler wird ein Feld benötigt:

```csharp
private int _clickCount = 0;
```

Das Feld gehört zur gesamten Klasse und bleibt zwischen mehreren Button-Klicks erhalten.

---

## Klick zählen

```csharp
private void OnActionButtonPressed()
{
    _clickCount++;
}
```

Jeder Klick erhöht den Wert um eins.

---

# 6. Status-Text aktualisieren

```csharp
private void OnActionButtonPressed()
{
    _clickCount++;

    _statusLabel.Text =
        $"Button wurde {_clickCount}-mal gedrückt.";
}
```

Beispielausgabe:

```text
Button wurde 3-mal gedrückt.
```

---

# 7. Button-Zustände verändern

Nach dem ersten Klick soll der Reset-Button aktiv sein.

```csharp
private void OnActionButtonPressed()
{
    _clickCount++;

    _statusLabel.Text =
        $"Button wurde {_clickCount}-mal gedrückt.";

    _resetButton.Disabled = false;
}
```

---

# 8. Reset-Funktion

```csharp
private void OnResetButtonPressed()
{
    _clickCount = 0;

    _statusLabel.Text =
        "Noch keine Aktion ausgeführt.";

    _resetButton.Disabled = true;
}
```

Der Reset-Button:

- setzt den Zähler zurück,
- setzt den Text zurück,
- deaktiviert sich wieder selbst.

---

# 9. Vollständiges Beispiel

```csharp
using Godot;

public partial class Main : Control
{
    private Label _titleLabel = null!;
    private Label _descriptionLabel = null!;
    private Label _statusLabel = null!;

    private Button _actionButton = null!;
    private Button _resetButton = null!;

    private int _clickCount = 0;

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
            "Buttons reagieren auf Events.";

        _statusLabel.Text =
            "Noch keine Aktion ausgeführt.";

        _resetButton.Disabled = true;

        _actionButton.Pressed +=
            OnActionButtonPressed;

        _resetButton.Pressed +=
            OnResetButtonPressed;

        GD.Print(
            "Button-Events wurden verbunden."
        );
    }

    private void OnActionButtonPressed()
    {
        _clickCount++;

        _statusLabel.Text =
            $"Button wurde {_clickCount}-mal gedrückt.";

        _resetButton.Disabled = false;
    }

    private void OnResetButtonPressed()
    {
        _clickCount = 0;

        _statusLabel.Text =
            "Noch keine Aktion ausgeführt.";

        _resetButton.Disabled = true;
    }
}
```

---

# 10. Was passiert beim Klick?

```text
1. Benutzer drückt ActionButton.
2. Godot löst das Pressed-Event aus.
3. OnActionButtonPressed() wird aufgerufen.
4. _clickCount wird erhöht.
5. StatusLabel.Text wird verändert.
6. ResetButton wird aktiviert.
```

---

# 11. Mehrere Methoden beim selben Event

Ein Event kann mehrere Event-Handler besitzen.

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;

_actionButton.Pressed +=
    WriteClickLog;
```

Zusätzliche Methode:

```csharp
private void WriteClickLog()
{
    GD.Print("ActionButton wurde gedrückt.");
}
```

Beim Klick werden beide Methoden ausgeführt.

---

## Reihenfolge

Die Methoden werden grundsätzlich in der Reihenfolge ausgeführt, in der sie angemeldet wurden.

```text
1. OnActionButtonPressed
2. WriteClickLog
```

---

# 12. Event-Handler abmelden

Mit `-=` wird ein Event-Handler wieder entfernt.

```csharp
_actionButton.Pressed -=
    OnActionButtonPressed;
```

Danach reagiert diese Methode nicht mehr auf den Button.

---

## In `_ExitTree()`

```csharp
public override void _ExitTree()
{
    _actionButton.Pressed -=
        OnActionButtonPressed;

    _resetButton.Pressed -=
        OnResetButtonPressed;
}
```

`_ExitTree()` wird aufgerufen, wenn der Node den Scene Tree verlässt.

Das Abmelden verhindert unnötige Event-Verbindungen.

---

# 13. Button nur begrenzt drücken

Der Action-Button soll nach fünf Klicks deaktiviert werden.

```csharp
private void OnActionButtonPressed()
{
    _clickCount++;

    _statusLabel.Text =
        $"Button wurde {_clickCount}-mal gedrückt.";

    _resetButton.Disabled = false;

    if (_clickCount >= 5)
    {
        _actionButton.Disabled = true;

        _statusLabel.Text =
            "Maximale Anzahl erreicht.";
    }
}
```

Beim Reset wird der Action-Button wieder aktiviert:

```csharp
private void OnResetButtonPressed()
{
    _clickCount = 0;

    _statusLabel.Text =
        "Noch keine Aktion ausgeführt.";

    _actionButton.Disabled = false;
    _resetButton.Disabled = true;
}
```

---

# 14. Weitere UI-Properties

## Sichtbarkeit ändern

```csharp
_descriptionLabel.Visible = false;
```

```csharp
_descriptionLabel.Visible = true;
```

---

## Button-Text verändern

```csharp
_actionButton.Text =
    "Erneut ausführen";
```

---

## Label-Farbe verändern

```csharp
_statusLabel.Modulate =
    new Color(0.5f, 1.0f, 0.5f);
```

Zurücksetzen:

```csharp
_statusLabel.Modulate =
    Colors.White;
```

---

# 15. Übung im Unterricht

Erweitere das gemeinsame Beispiel.

---

## Aufgabe 1

Verbinde:

```text
ActionButton.Pressed
```

mit:

```csharp
OnActionButtonPressed
```

---

## Aufgabe 2

Verbinde:

```text
ResetButton.Pressed
```

mit:

```csharp
OnResetButtonPressed
```

---

## Aufgabe 3

Der Action-Button soll:

- den Klickzähler erhöhen,
- den neuen Wert im StatusLabel anzeigen,
- den ResetButton aktivieren.

---

## Aufgabe 4

Der Reset-Button soll:

- den Klickzähler auf `0` setzen,
- den Ausgangstext wiederherstellen,
- den ResetButton deaktivieren,
- den ActionButton wieder aktivieren.

---

## Aufgabe 5

Nach fünf Klicks soll:

```text
Maximale Anzahl erreicht.
```

angezeigt werden.

Der ActionButton soll anschließend deaktiviert sein.

---

# 16. Miniübung

Füge einen dritten Button hinzu:

```text
ColorButton
```

Scene Tree:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── ActionButton
    ├── ResetButton
    └── ColorButton
```

Text:

```text
Farbe ändern
```

---

## Aufgabe

Beim Drücken soll sich die Farbe des StatusLabels ändern.

Benötigte Schritte:

1. Feld für `ColorButton` erstellen.
2. Node mit `GetNode<Button>()` holen.
3. `Pressed`-Event verbinden.
4. Event-Handler schreiben.
5. `StatusLabel.Modulate` verändern.

---

## Mögliche Grundstruktur

```csharp
private Button _colorButton = null!;
```

```csharp
_colorButton =
    GetNode<Button>(
        "VBoxContainer/ColorButton"
    );
```

```csharp
_colorButton.Pressed +=
    OnColorButtonPressed;
```

```csharp
private void OnColorButtonPressed()
{
    // Farbe verändern
}
```

---

# 17. Zusatzaufgabe: Farbe wechseln

Bei jedem Klick soll zwischen zwei Farben gewechselt werden.

Feld:

```csharp
private bool _usesAlternativeColor = false;
```

Event-Handler:

```csharp
private void OnColorButtonPressed()
{
    _usesAlternativeColor =
        !_usesAlternativeColor;

    if (_usesAlternativeColor)
    {
        _statusLabel.Modulate =
            new Color(1.0f, 0.6f, 0.6f);
    }
    else
    {
        _statusLabel.Modulate =
            Colors.White;
    }
}
```

---

# 18. Häufige Fehler

## Event wurde nicht angemeldet

Die Methode existiert:

```csharp
private void OnActionButtonPressed()
{
}
```

aber diese Zeile fehlt:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

Dann wird die Methode beim Klick nicht ausgeführt.

---

## Methode wird direkt aufgerufen

Falsch:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed();
```

Richtig:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

Bei der Anmeldung werden keine Klammern verwendet.

Die Methode soll gespeichert und später vom Event aufgerufen werden.

---

## Falsche Methodensignatur

Falsch:

```csharp
private int OnActionButtonPressed()
{
    return 1;
}
```

Das `Pressed`-Event erwartet eine Methode ohne Rückgabewert.

Richtig:

```csharp
private void OnActionButtonPressed()
{
}
```

---

## Mehrfach angemeldet

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;

_actionButton.Pressed +=
    OnActionButtonPressed;
```

Dann wird der Event-Handler bei einem Klick zweimal ausgeführt.

---

## Falscher Button deaktiviert

```csharp
_actionButton.Disabled = true;
```

und:

```csharp
_resetButton.Disabled = true;
```

betreffen unterschiedliche Node-Instanzen.

Achte auf den richtigen Variablennamen.

---

# 19. Verbindung zur Event-Theorie

Aus der vorherigen C#-Einheit:

```csharp
player.HealthChanged +=
    healthDisplay.UpdateHealth;
```

In Godot:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

Beide folgen demselben Prinzip:

```text
Sender.Event += EventHandler;
```

---

# 20. Kontrollfragen

1. Was ist bei `_actionButton.Pressed` der Sender?
2. Was ist das Event?
3. Was ist der Event-Handler?
4. Wofür wird `+=` verwendet?
5. Warum stehen bei der Anmeldung keine Klammern?
6. Wer ruft `OnActionButtonPressed()` auf?
7. Welche Signatur benötigt ein `Pressed`-Handler?
8. Warum ist `_clickCount` ein Feld?
9. Was bewirkt `.Disabled = true`?
10. Wie wird ein Event-Handler abgemeldet?
11. Was passiert bei doppelter Anmeldung?
12. In welcher Reihenfolge werden mehrere Handler ausgeführt?
13. Was ist der Unterschied zwischen `_Ready()` und einem Button-Handler?
14. Warum sollte ein Reset auch den ActionButton wieder aktivieren?
15. Welche Property verändert die Farbe eines Control-Nodes?

---

# 21. Kurzüberblick

| Schreibweise | Bedeutung |
|---|---|
| `.Pressed` | Event eines Buttons |
| `+=` | Event-Handler anmelden |
| `-=` | Event-Handler abmelden |
| `OnActionButtonPressed` | Event-Handler |
| `_clickCount++` | Klickzähler erhöhen |
| `.Text` | Text verändern |
| `.Disabled` | Button deaktivieren oder aktivieren |
| `.Visible` | Node ein- oder ausblenden |
| `.Modulate` | Farbe eines Nodes verändern |
| `_ExitTree()` | Wird beim Verlassen des Scene Trees aufgerufen |

---

# Merksätze

> Ein Button löst beim Drücken sein `Pressed`-Event aus.

> Eine Methode wird mit `+=` beim Event angemeldet.

> Bei der Anmeldung wird die Methode ohne Klammern angegeben.

> Godot ruft den Event-Handler automatisch auf.

> Mehrere Methoden können auf dasselbe Event reagieren.

> Mit `-=` wird ein Event-Handler wieder abgemeldet.

---

# Abschluss der ersten Godot-PE

- einen Godot-Scene-Tree aufbauen,
- Nodes und Szenen unterscheiden,
- ein C#-Skript an einen Node anhängen,
- `_Ready()` verwenden,
- Nodes mit `GetNode<T>()` ansprechen,
- Node-Properties über C# verändern,
- Button-Events verbinden,
- Event-Handler schreiben,
- eine kleine interaktive Benutzeroberfläche programmieren.
