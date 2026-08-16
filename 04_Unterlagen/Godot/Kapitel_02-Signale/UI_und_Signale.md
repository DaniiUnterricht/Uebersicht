# Godot mit C#: UI und Signale


## Voraussetzung

Für diese Unterlage wird auf der bisherigen Szene aufgebaut:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── ActionButton
    └── ResetButton
```

Das Skript `Main.cs` besitzt bereits Referenzen auf die Nodes.

---

## Lernziele

Nach dieser Einheit kannst du:

- Godot-Signale mit C# verbinden,
- Signale im Editor und im Code unterscheiden,
- Sender, Signal und Event-Handler zuordnen,
- mehrere Signale eines Buttons verwenden,
- UI-Properties während der Laufzeit verändern,
- Event-Handler wieder abmelden.

---

# 1. Godot-Signale

Godot verwendet **Signale**, um mitzuteilen, dass etwas passiert ist.

Ein Button kann zum Beispiel melden:

```text
Ich wurde gedrückt.
```

Das passende Signal heißt:

```csharp
Pressed
```

In C# wird dieses Signal wie ein Event verwendet:

```csharp
_actionButton.Pressed += OnActionButtonPressed;
```

Dabei gilt:

```text
_actionButton          = Sender
Pressed                = Signal / Event
OnActionButtonPressed  = Event-Handler
+=                     = Methode anmelden
```

## Umsetzung im Beispiel

Öffne `Main.cs`.

Ergänze in `_Ready()`:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

Erstelle danach:

```csharp
private void OnActionButtonPressed()
{
    GD.Print("Action Button gedrückt.");
}
```

---

# 2. Signale über den Editor verbinden

Signale können auch direkt im Godot-Editor verbunden werden.

Dazu:

1. Node auswählen
2. Zum Bereich **Node** wechseln
3. **Signals** öffnen
4. Gewünschtes Signal auswählen
5. **Connect** verwenden
6. Ziel-Node und Methodenname auswählen

## Umsetzung im Beispiel

Erstelle :

```csharp
private void OnResetButtonPressed()
{
    GD.Print("Reset Button gedrückt");
}
```

Verbinde das `Pressed`-Signal des `ResetButton` über den Editor mit:

```csharp
OnResetButtonPressed
```

Teste anschließend, ob die Methode beim Drücken ausgeführt wird.

---

# 3. Code-Verbindung oder Editor-Verbindung?

Beide Varianten erfüllen denselben Zweck.

Im Code:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;
```

Oder über den Editor:

```text
Node → Signals → Pressed → Connect
```

## Umsetzung im Beispiel

Verwende für:

```text
ActionButton
```

die Verbindung im C#-Code.

Verwende für:

```text
ResetButton
```

die Verbindung über den Editor.

---

# 4. Event-Handler mit Inhalt

Ein Event-Handler ist eine normale Methode.

```csharp
private void OnActionButtonPressed()
{
    _statusLabel.Text =
        "ActionButton wurde gedrückt.";
}
```

## Umsetzung im Beispiel

Ergänze:

```csharp
private void OnActionButtonPressed()
{
    _statusLabel.Text =
        "ActionButton wurde gedrückt.";

    _resetButton.Disabled = false;
}
```

---

# 5. Reset-Event

Der ResetButton soll den Ausgangszustand wiederherstellen.

```csharp
private void OnResetButtonPressed()
{
    _statusLabel.Text =
        "Bereit";

    _resetButton.Disabled = true;
}
```

## Umsetzung im Beispiel

Setze in `_Ready()` zunächst:

```csharp
_statusLabel.Text = "Bereit";
_resetButton.Disabled = true;
```

Danach soll gelten:

```text
ActionButton gedrückt
→ Status verändert
→ ResetButton aktiviert
```

und:

```text
ResetButton gedrückt
→ Status zurückgesetzt
→ ResetButton deaktiviert
```

---

# 6. Weitere Signale eines Buttons

Ein Button besitzt nicht nur `Pressed`.

Weitere nützliche Signale:

```text
ButtonDown
ButtonUp
MouseEntered
MouseExited
```

---

# 7. `ButtonDown`

`ButtonDown` wird ausgelöst, sobald der Button gedrückt wird.

```csharp
_actionButton.ButtonDown +=
    OnActionButtonDown;
```

## Umsetzung im Beispiel

Ergänze:

```csharp
private void OnActionButtonDown()
{
    GD.Print(
        "ActionButton: ButtonDown"
    );
}
```

Teste den Unterschied zu `Pressed`.

---

# 8. `ButtonUp`

`ButtonUp` wird ausgelöst, wenn der gedrückte Button wieder losgelassen wird.

```csharp
_actionButton.ButtonUp +=
    OnActionButtonUp;
```

## Umsetzung im Beispiel

Ergänze:

```csharp
private void OnActionButtonUp()
{
    GD.Print(
        "ActionButton: ButtonUp"
    );
}
```

Beobachte die Reihenfolge im Output.

---

# 9. `MouseEntered`

`Control`-Nodes besitzen das Signal:

```text
MouseEntered
```

## Umsetzung im Beispiel

Verbinde:

```csharp
_actionButton.MouseEntered +=
    OnActionButtonMouseEntered;
```

Erstelle:

```csharp
private void OnActionButtonMouseEntered()
{
    _descriptionLabel.Text =
        "Maus befindet sich über dem ActionButton.";
}
```

---

# 10. `MouseExited`

Passend dazu existiert:

```text
MouseExited
```

## Umsetzung im Beispiel

Verbinde:

```csharp
_actionButton.MouseExited +=
    OnActionButtonMouseExited;
```

Erstelle:

```csharp
private void OnActionButtonMouseExited()
{
    _descriptionLabel.Text =
        "Godot UI und Signale";
}
```

---

# 11. Mehrere Signale am selben Node

Ein Button kann mehrere Signale gleichzeitig verwenden:

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;

_actionButton.ButtonDown +=
    OnActionButtonDown;

_actionButton.ButtonUp +=
    OnActionButtonUp;

_actionButton.MouseEntered +=
    OnActionButtonMouseEntered;

_actionButton.MouseExited +=
    OnActionButtonMouseExited;
```

## Umsetzung im Beispiel

Teste:

1. Maus auf den Button bewegen
2. Maustaste drücken
3. Maustaste loslassen
4. Maus vom Button wegbewegen

Beobachte UI und Output.

---

# 12. UI während der Laufzeit verändern

Beispiele:

```csharp
_statusLabel.Text = "Neuer Text";
```

```csharp
_actionButton.Disabled = true;
```

```csharp
_descriptionLabel.Visible = false;
```

## Umsetzung im Beispiel

Erweitere:

```csharp
private void OnActionButtonPressed()
{
    _statusLabel.Text =
        "Aktion wurde ausgeführt.";

    _actionButton.Disabled = true;
    _resetButton.Disabled = false;
}
```

Beim Reset:

```csharp
private void OnResetButtonPressed()
{
    _statusLabel.Text = "Bereit";

    _actionButton.Disabled = false;
    _resetButton.Disabled = true;
}
```

---

# 13. Mehrere Methoden auf dasselbe Signal

Ein Signal kann mehrere Methoden aufrufen.

```csharp
_actionButton.Pressed +=
    OnActionButtonPressed;

_actionButton.Pressed +=
    WriteActionLog;
```

## Umsetzung im Beispiel

Erstelle:

```csharp
private void WriteActionLog()
{
    GD.Print(
        "ActionButton wurde erfolgreich ausgelöst."
    );
}
```

Ein Klick soll jetzt die UI verändern und zusätzlich eine Ausgabe erzeugen.

---

# 14. Event-Handler wieder abmelden

Mit `-=` wird eine Methode entfernt.

```csharp
_actionButton.Pressed -=
    OnActionButtonPressed;
```

## Umsetzung im Beispiel

Füge die Zeile testweise direkt nach der Anmeldung ein.

Teste den Button und entferne die Zeile danach wieder.

---

# 15. Abmelden in `_ExitTree()`

```csharp
public override void _ExitTree()
{
    _actionButton.Pressed -=
        OnActionButtonPressed;

    _actionButton.ButtonDown -=
        OnActionButtonDown;

    _actionButton.ButtonUp -=
        OnActionButtonUp;

    _actionButton.MouseEntered -=
        OnActionButtonMouseEntered;

    _actionButton.MouseExited -=
        OnActionButtonMouseExited;
}
```

## Umsetzung im Beispiel

Ergänze `_ExitTree()` und melde dort alle per C# verbundenen Signale wieder ab.

---

# 16. Miniübung

Füge einen neuen Button hinzu:

```text
InfoButton
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
    └── InfoButton
```

Der `InfoButton` soll:

- bei `MouseEntered` den Text `"Information anzeigen"` setzen,
- bei `MouseExited` wieder `"Godot UI und Signale"` anzeigen,
- bei `Pressed` den `StatusLabel`-Text auf `"InfoButton gedrückt"` setzen.

---

# 17. Kontrollfragen

1. Was ist ein Godot-Signal?
2. Was ist bei `_actionButton.Pressed` der Sender?
3. Was ist ein Event-Handler?
4. Wofür wird `+=` verwendet?
5. Wofür wird `-=` verwendet?
6. Was ist der Unterschied zwischen `Pressed` und `ButtonDown`?
7. Wann wird `ButtonUp` ausgelöst?
8. Wofür werden `MouseEntered` und `MouseExited` verwendet?
9. Können mehrere Methoden auf dasselbe Signal reagieren?
10. Können Signale sowohl im Editor als auch im Code verbunden werden?
11. Was bewirkt `.Disabled = true`?
12. Warum kann `_ExitTree()` für Event-Verbindungen wichtig sein?

---

# Merksätze

> Godot-Signale melden, dass etwas passiert ist.

> In C# werden Godot-Signale wie Events verwendet.

> `+=` meldet eine Methode an.

> `-=` meldet eine Methode ab.

> Ein Node kann mehrere unterschiedliche Signale besitzen.

> UI-Elemente können während der Laufzeit über ihre Properties verändert werden.
