# Godot mit C#: UI-Zustände und Interaktionen

## Voraussetzung

Diese Unterlage baut auf **UI und Signale** auf.

Die Szene besitzt aktuell:

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

---

## Lernziele

Nach dieser Einheit kannst du:

- einen UI-Zustand mit einem Enum abbilden,
- UI-Logik in eigene Methoden auslagern,
- mehrere UI-Elemente abhängig von einem Zustand verändern,
- UI-Bereiche ein- und ausblenden,
- mehrere Events zu einem zusammenhängenden Ablauf verbinden.

---

# 1. Zustände einer Benutzeroberfläche

Eine Benutzeroberfläche kann verschiedene Zustände besitzen.

Beispiel:

```text
Ready
Running
Finished
```

Statt mehrere einzelne `bool`-Variablen zu verwenden, kann dafür ein Enum eingesetzt werden.

```csharp
public enum UiState
{
    Ready,
    Running,
    Finished
}
```

## Umsetzung im Beispiel

Erstelle ein Enum:

```csharp
public enum UiState
{
    Ready,
    Running,
    Finished
}
```

Ergänze in `Main`:

```csharp
private UiState _currentState =
    UiState.Ready;
```

---

# 2. Klickzähler ergänzen

Zusätzlich zum Zustand soll gezählt werden, wie oft der ActionButton gedrückt wurde.

```csharp
private int _clickCount = 0;
```

## Umsetzung im Beispiel

Ändere:

```csharp
OnActionButtonPressed()
```

so, dass der Zähler erhöht wird:

```csharp
private void OnActionButtonPressed()
{
    _clickCount++;
}
```

---

# 3. Logik aus Event-Handlern auslagern

Event-Handler sollten nicht unnötig viel Logik enthalten.

Besser ist:

```csharp
private void OnActionButtonPressed()
{
    _clickCount++;

    UpdateState();
    UpdateUi();
}
```

## Umsetzung im Beispiel

Erstelle:

```csharp
private void UpdateState()
{
}
```

und:

```csharp
private void UpdateUi()
{
}
```

---

# 4. Zustand abhängig vom Zähler setzen

Die UI soll folgende Zustände besitzen:

```text
0 Klicks       → Ready
1 bis 4 Klicks → Running
5 Klicks       → Finished
```

## Umsetzung im Beispiel

Ergänze:

```csharp
private void UpdateState()
{
    if (_clickCount == 0)
    {
        _currentState = UiState.Ready;
    }
    else if (_clickCount >= 5)
    {
        _currentState = UiState.Finished;
    }
    else
    {
        _currentState = UiState.Running;
    }
}
```

---

# 5. UI abhängig vom Zustand aktualisieren

Für die Darstellung eignet sich ein `switch`.

```csharp
private void UpdateUi()
{
    switch (_currentState)
    {
        case UiState.Ready:
            break;

        case UiState.Running:
            break;

        case UiState.Finished:
            break;
    }
}
```

## Umsetzung im Beispiel

Fülle die Fälle:

```csharp
private void UpdateUi()
{
    switch (_currentState)
    {
        case UiState.Ready:
            _statusLabel.Text =
                "Bereit";

            _actionButton.Disabled = false;
            _resetButton.Disabled = true;
            break;

        case UiState.Running:
            _statusLabel.Text =
                $"Klicks: {_clickCount}";

            _actionButton.Disabled = false;
            _resetButton.Disabled = false;
            break;

        case UiState.Finished:
            _statusLabel.Text =
                "Maximale Anzahl erreicht.";

            _actionButton.Disabled = true;
            _resetButton.Disabled = false;
            break;
    }
}
```

---

# 6. Reset über den Zustand

Auch der Reset soll die UI nicht mehr selbst zusammensetzen.

## Umsetzung im Beispiel

Ändere:

```csharp
private void OnResetButtonPressed()
{
    _clickCount = 0;

    UpdateState();
    UpdateUi();
}
```

---

# 7. Ausgangszustand zentral setzen

Auch `_Ready()` soll dieselbe Logik verwenden.

## Umsetzung im Beispiel

Nachdem alle Nodes gefunden und Signale verbunden wurden:

```csharp
_currentState = UiState.Ready;
_clickCount = 0;

UpdateUi();
```

---

# 8. Klare Aufgaben der Methoden

Jetzt besitzt jede Methode eine klare Aufgabe:

```text
OnActionButtonPressed
→ reagiert auf das Event

UpdateState
→ entscheidet über den Zustand

UpdateUi
→ zeigt den Zustand an
```

## Umsetzung im Beispiel

Prüfe, ob in `OnActionButtonPressed()` möglichst keine direkten Änderungen von:

```text
Text
Disabled
Visible
```

mehr notwendig sind.

Diese Änderungen sollen zentral über:

```csharp
UpdateUi()
```

erfolgen.

---

# 9. UI-Bereich hinzufügen

Erweitere die Szene um:

```text
InfoContainer
```

Darin:

```text
InfoLabel
CloseInfoButton
```

Neuer Scene Tree:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── ActionButton
    ├── ResetButton
    ├── InfoButton
    └── InfoContainer
        ├── InfoLabel
        └── CloseInfoButton
```

## Umsetzung im Beispiel

Erstelle Referenzen:

```csharp
private Control _infoContainer = null!;
private Label _infoLabel = null!;
private Button _closeInfoButton = null!;
```

Hole die Nodes in `_Ready()`.

---

# 10. UI-Bereich ausblenden

UI-Nodes besitzen die Property:

```csharp
Visible
```

Ein Container kann versteckt werden:

```csharp
_infoContainer.Visible = false;
```

## Umsetzung im Beispiel

Setze in `_Ready()`:

```csharp
_infoContainer.Visible = false;
```

und:

```csharp
_infoLabel.Text =
    "Dies ist ein zusätzlicher UI-Bereich.";
```

---

# 11. Info-Bereich öffnen

Der bestehende `InfoButton` soll den Container sichtbar machen.

## Umsetzung im Beispiel

Verbinde:

```csharp
_infoButton.Pressed +=
    OnInfoButtonPressed;
```

Erstelle:

```csharp
private void OnInfoButtonPressed()
{
    _infoContainer.Visible = true;
}
```

---

# 12. Info-Bereich schließen

Der neue `CloseInfoButton` soll ihn wieder verstecken.

## Umsetzung im Beispiel

Verbinde:

```csharp
_closeInfoButton.Pressed +=
    OnCloseInfoButtonPressed;
```

Erstelle:

```csharp
private void OnCloseInfoButtonPressed()
{
    _infoContainer.Visible = false;
}
```

Damit ist ein einfaches Fenster entstanden:

```text
InfoButton
→ öffnen

CloseInfoButton
→ schließen
```

---

# 13. Mehrere UI-Elemente arbeiten zusammen

Die Oberfläche besitzt jetzt:

```text
ActionButton
→ verändert Klickzähler und UiState

ResetButton
→ setzt Zustand zurück

InfoButton
→ öffnet InfoContainer

CloseInfoButton
→ schließt InfoContainer
```

## Umsetzung im Beispiel

Teste jede Interaktion einzeln und danach in Kombination.

Prüfe besonders:

- Wird der InfoContainer korrekt geöffnet?
- Wird er korrekt geschlossen?
- Funktioniert der Klickzähler weiterhin?
- Wird der Zustand nach Reset korrekt zurückgesetzt?

---

# 14. Event-Kette

Ein einzelnes Event kann mehrere Programmschritte starten:

```text
Pressed
  ↓
OnActionButtonPressed()
  ↓
_clickCount erhöhen
  ↓
UpdateState()
  ↓
UiState setzen
  ↓
UpdateUi()
  ↓
Labels und Buttons verändern
```

## Umsetzung im Beispiel

Ergänze testweise:

```csharp
GD.Print("1. Event-Handler");
```

in `OnActionButtonPressed()`.

In `UpdateState()`:

```csharp
GD.Print("2. Zustand aktualisieren");
```

In `UpdateUi()`:

```csharp
GD.Print("3. UI aktualisieren");
```

Beobachte die Reihenfolge im Output.

---

# 15. Endgültiger Scene Tree

Am Ende kann die Szene so aussehen:

```text
Main
└── VBoxContainer
    ├── TitleLabel
    ├── DescriptionLabel
    ├── StatusLabel
    ├── ActionButton
    ├── ResetButton
    ├── InfoButton
    └── InfoContainer
        ├── InfoLabel
        └── CloseInfoButton
```

---

# 16. Miniübung

Erweitere das Enum um:

```csharp
Paused
```

```csharp
public enum UiState
{
    Ready,
    Running,
    Paused,
    Finished
}
```

Füge einen Button hinzu:

```text
PauseButton
```

## Aufgabe

Beim Drücken des PauseButtons soll zwischen:

```text
Running
Paused
```

gewechselt werden.

Im Zustand `Paused`:

- ActionButton deaktivieren,
- StatusLabel auf `"Pausiert"` setzen,
- PauseButton-Text auf `"Fortsetzen"` setzen.

Beim Fortsetzen:

- Zustand wieder auf `Running` setzen,
- ActionButton wieder aktivieren,
- PauseButton-Text auf `"Pause"` setzen.

Verwende weiterhin:

```csharp
UpdateUi()
```

für die sichtbaren Änderungen.

---

# 17. Zusatzaufgabe

Wenn:

```csharp
UiState.Finished
```

erreicht wurde, soll der `InfoContainer` automatisch sichtbar werden.

Setze:

```text
Übung abgeschlossen!
```

als Text des `InfoLabel`.

---

# 18. Kontrollfragen

1. Warum ist ein Enum für UI-Zustände sinnvoll?
2. Welche Aufgabe besitzt `UpdateState()`?
3. Welche Aufgabe besitzt `UpdateUi()`?
4. Warum sollte nicht die gesamte Logik direkt im Event-Handler stehen?
5. Was bewirkt `.Visible = false` bei einem Container?
6. Wie können mehrere Buttons dieselbe UI beeinflussen?
7. Was ist eine Event-Kette?
8. Warum ist eine zentrale `UpdateUi()`-Methode nützlich?
9. Welche Aufgabe besitzt der `InfoButton`?
10. Welche Aufgabe besitzt der `CloseInfoButton`?
11. Warum ist die Trennung zwischen Zustand und Darstellung sinnvoll?

---

# Merksätze

> Ein Event-Handler startet häufig nur einen Ablauf.

> Zustände können mit Enums übersichtlich dargestellt werden.

> Eine zentrale `UpdateUi()`-Methode verhindert doppelte UI-Logik.

> Mit `.Visible` können vollständige UI-Bereiche ein- und ausgeblendet werden.

> Mehrere UI-Elemente können gemeinsam denselben Programmzustand beeinflussen.
