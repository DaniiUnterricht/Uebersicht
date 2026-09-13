# PE23 – Godot mit C#: UI Controls & Settings

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

## Lernziele

Nach dieser Einheit kannst du:

- verschiedene UI-Controls in Godot unterscheiden,
- `CheckBox`, `CheckButton`, `HSlider`, `OptionButton` und `LineEdit` verwenden,
- unterschiedliche Signalsignaturen verstehen,
- Werte aus UI-Controls auslesen,
- ein einfaches Settings-Menü aufbauen,
- Einstellungen über einen Apply-Button zusammenfassen.

---

# 1. Neues Beispielprojekt

Für diese Einheit wird ein **neues Beispiel** verwendet.

Das Ziel ist ein kleines Einstellungsmenü.

Geplanter Scene Tree:

```text
Settings
└── VBoxContainer
    ├── TitleLabel
    ├── FullscreenCheckBox
    ├── MusicCheckButton
    ├── VolumeSlider
    ├── VolumeValueLabel
    ├── ResolutionOptionButton
    ├── PlayerNameLineEdit
    ├── ApplyButton
    └── StatusLabel
```

## Umsetzung im Beispiel

Erstelle eine neue Szene mit:

```text
Control
```

als Root Node und benenne ihn:

```text
Settings
```

Füge darunter einen:

```text
VBoxContainer
```

hinzu.

Speichere die Szene als:

```text
Scenes/Settings.tscn
```

---

# 2. `CheckBox`

Eine `CheckBox` eignet sich für Einstellungen mit zwei Zuständen:

```text
aktiv
inaktiv
```

Typische Beispiele:

- Vollbild
- VSync
- Untertitel
- Hinweise anzeigen

Eine `CheckBox` besitzt unter anderem die Property:

```csharp
ButtonPressed
```

Damit kann geprüft werden, ob sie aktiviert ist.

## Umsetzung im Beispiel

Füge hinzu:

```text
FullscreenCheckBox
```

Setze den Text:

```text
Vollbild
```

---

# 3. `Toggled`-Signal

Eine `CheckBox` kann das Signal:

```text
Toggled
```

auslösen.

Dieses Signal übergibt einen `bool`.

```csharp
private void OnFullscreenToggled(
    bool toggledOn)
{
}
```

Dabei gilt:

```text
true  → aktiviert
false → deaktiviert
```

## Umsetzung im Beispiel

Erstelle:

```csharp
private CheckBox _fullscreenCheckBox = null!;
```

Hole den Node:

```csharp
_fullscreenCheckBox =
    GetNode<CheckBox>(
        "VBoxContainer/FullscreenCheckBox"
    );
```

Verbinde:

```csharp
_fullscreenCheckBox.Toggled +=
    OnFullscreenToggled;
```

Erstelle:

```csharp
private void OnFullscreenToggled(
    bool toggledOn)
{
    GD.Print(
        $"Vollbild: {toggledOn}"
    );
}
```

---

# 4. `CheckButton`

Ein `CheckButton` funktioniert ähnlich wie eine `CheckBox`.

Er stellt den Zustand jedoch eher wie einen Ein-/Aus-Schalter dar.

Typische Beispiele:

- Musik an / aus
- Soundeffekte an / aus
- Mikrofon an / aus
- Benachrichtigungen an / aus

## Umsetzung im Beispiel

Füge hinzu:

```text
MusicCheckButton
```

Text:

```text
Musik
```

Erstelle:

```csharp
private CheckButton _musicCheckButton = null!;
```

Hole den Node:

```csharp
_musicCheckButton =
    GetNode<CheckButton>(
        "VBoxContainer/MusicCheckButton"
    );
```

Verbinde:

```csharp
_musicCheckButton.Toggled +=
    OnMusicToggled;
```

Erstelle:

```csharp
private void OnMusicToggled(
    bool toggledOn)
{
    GD.Print(
        $"Musik: {toggledOn}"
    );
}
```

---

# 5. Unterschied `CheckBox` und `CheckButton`

Beide Controls liefern einen `bool`.

Der Unterschied liegt hauptsächlich in der Darstellung.

```text
CheckBox
→ klassisches Kontrollkästchen

CheckButton
→ Schalter
```

## Umsetzung im Beispiel

Teste beide Controls.

Aktiviere und deaktiviere:

```text
FullscreenCheckBox
MusicCheckButton
```

Beobachte die Werte im Output.

---

# 6. `HSlider`

Ein `HSlider` eignet sich für Zahlenwerte innerhalb eines Bereichs.

Typische Beispiele:

- Lautstärke
- Helligkeit
- Mausgeschwindigkeit
- Musiklautstärke
- Zoom

Ein Slider besitzt unter anderem:

```text
Min Value
Max Value
Step
Value
```

## Umsetzung im Beispiel

Füge hinzu:

```text
VolumeSlider
```

Setze:

```text
Min Value: 0
Max Value: 100
Step: 1
Value: 50
```

Füge darunter ein Label hinzu:

```text
VolumeValueLabel
```

Text:

```text
Lautstärke: 50
```

---

# 7. `ValueChanged`-Signal

Ein Slider besitzt das Signal:

```text
ValueChanged
```

Das Signal übergibt bei `Range`-Controls einen:

```csharp
double
```

## Umsetzung im Beispiel

Erstelle:

```csharp
private HSlider _volumeSlider = null!;
private Label _volumeValueLabel = null!;
```

Hole beide Nodes.

Verbinde:

```csharp
_volumeSlider.ValueChanged +=
    OnVolumeChanged;
```

Erstelle:

```csharp
private void OnVolumeChanged(
    double value)
{
    _volumeValueLabel.Text =
        $"Lautstärke: {(int)value}";
}
```

---

# 8. Unterschiedliche Signal-Parameter

Bisher:

```csharp
Pressed
```

ohne Parameter,

```csharp
Toggled
```

mit:

```csharp
bool
```

und:

```csharp
ValueChanged
```

mit:

```csharp
double
```

Die Event-Handler müssen zur Signatur des Signals passen.

## Umsetzung im Beispiel

Vergleiche:

```csharp
private void OnApplyButtonPressed()
{
}
```

```csharp
private void OnMusicToggled(
    bool toggledOn)
{
}
```

```csharp
private void OnVolumeChanged(
    double value)
{
}
```

---

# 9. `OptionButton`

Ein `OptionButton` ermöglicht eine Auswahl aus mehreren Einträgen.

Typische Beispiele:

- Auflösung
- Sprache
- Grafikqualität
- Serverregion
- Schwierigkeit

## Umsetzung im Beispiel

Füge hinzu:

```text
ResolutionOptionButton
```

Erstelle:

```csharp
private OptionButton _resolutionOptionButton = null!;
```

Hole den Node.

---

# 10. Einträge hinzufügen

Einträge können im Editor oder per Code hinzugefügt werden.

Per Code:

```csharp
_resolutionOptionButton.AddItem(
    "1280 x 720"
);

_resolutionOptionButton.AddItem(
    "1920 x 1080"
);

_resolutionOptionButton.AddItem(
    "2560 x 1440"
);
```

## Umsetzung im Beispiel

Füge diese drei Auflösungen in `_Ready()` hinzu.

---

# 11. `ItemSelected`-Signal

Das Signal:

```text
ItemSelected
```

meldet, welcher Eintrag gewählt wurde.

Der Handler erhält einen Index:

```csharp
private void OnResolutionSelected(
    long index)
{
}
```

## Umsetzung im Beispiel

Verbinde:

```csharp
_resolutionOptionButton.ItemSelected +=
    OnResolutionSelected;
```

Erstelle:

```csharp
private void OnResolutionSelected(
    long index)
{
    GD.Print(
        $"Auflösung Index: {index}"
    );
}
```

---

# 12. Text des ausgewählten Eintrags

Über den Index kann der Text gelesen werden:

```csharp
string resolution =
    _resolutionOptionButton
        .GetItemText((int)index);
```

## Umsetzung im Beispiel

Erweitere:

```csharp
private void OnResolutionSelected(
    long index)
{
    string resolution =
        _resolutionOptionButton
            .GetItemText((int)index);

    GD.Print(
        $"Auflösung: {resolution}"
    );
}
```

---

# 13. `LineEdit`

Ein `LineEdit` erlaubt die Eingabe einer einzelnen Textzeile.

Typische Beispiele:

- Spielername
- Serveradresse
- Suchfeld
- Profilname

Die aktuelle Eingabe steht in:

```csharp
Text
```

## Umsetzung im Beispiel

Füge hinzu:

```text
PlayerNameLineEdit
```

Setze als Placeholder:

```text
Spielername
```

Erstelle:

```csharp
private LineEdit _playerNameLineEdit = null!;
```

Hole den Node.

---

# 14. `TextChanged`-Signal

Ein `LineEdit` besitzt:

```text
TextChanged
```

Dieses Signal übergibt einen:

```csharp
string
```

## Umsetzung im Beispiel

Verbinde:

```csharp
_playerNameLineEdit.TextChanged +=
    OnPlayerNameChanged;
```

Erstelle:

```csharp
private void OnPlayerNameChanged(
    string newText)
{
    GD.Print(
        $"Spielername: {newText}"
    );
}
```

---

# 15. `ApplyButton`

Jetzt sollen alle aktuellen Werte gemeinsam ausgewertet werden.

Füge hinzu:

```text
ApplyButton
```

Text:

```text
Übernehmen
```

Erstelle:

```csharp
private Button _applyButton = null!;
```

Hole den Node.

Verbinde:

```csharp
_applyButton.Pressed +=
    OnApplyButtonPressed;
```

---

# 16. Werte aus Controls auslesen

Vollbild:

```csharp
bool fullscreen =
    _fullscreenCheckBox.ButtonPressed;
```

Musik:

```csharp
bool music =
    _musicCheckButton.ButtonPressed;
```

Lautstärke:

```csharp
double volume =
    _volumeSlider.Value;
```

Spielername:

```csharp
string playerName =
    _playerNameLineEdit.Text;
```

Ausgewählte Auflösung:

```csharp
string resolution =
    _resolutionOptionButton.GetItemText(
        _resolutionOptionButton.Selected
    );
```

## Umsetzung im Beispiel

Erstelle:

```csharp
private Label _statusLabel = null!;
```

Hole `StatusLabel`.

Ergänze:

```csharp
private void OnApplyButtonPressed()
{
    bool fullscreen =
        _fullscreenCheckBox.ButtonPressed;

    bool music =
        _musicCheckButton.ButtonPressed;

    int volume =
        (int)_volumeSlider.Value;

    string playerName =
        _playerNameLineEdit.Text;

    string resolution =
        _resolutionOptionButton.GetItemText(
            _resolutionOptionButton.Selected
        );

    _statusLabel.Text =
        $"Name: {playerName}\n" +
        $"Vollbild: {fullscreen}\n" +
        $"Musik: {music}\n" +
        $"Lautstärke: {volume}\n" +
        $"Auflösung: {resolution}";
}
```

---

# 17. Finale Szene

```text
Settings
└── VBoxContainer
    ├── TitleLabel
    ├── FullscreenCheckBox
    ├── MusicCheckButton
    ├── VolumeSlider
    ├── VolumeValueLabel
    ├── ResolutionOptionButton
    ├── PlayerNameLineEdit
    ├── ApplyButton
    └── StatusLabel
```

---

# 18. Unterschiedliche Signalsignaturen

| Signal | Parameter |
|---|---|
| `Pressed` | keine |
| `Toggled` | `bool` |
| `ValueChanged` | `double` |
| `ItemSelected` | `long` |
| `TextChanged` | `string` |

> Ein Event-Handler muss zur Signatur des Signals passen.

---

# 19. Miniübung

Erweitere das Settings-Menü um:

```text
BrightnessSlider
BrightnessValueLabel
```

Der Slider soll verwenden:

```text
Min Value: 0
Max Value: 100
Value: 75
```

Beim Verändern soll erscheinen:

```text
Helligkeit: 75
```

Beim Drücken auf `ApplyButton` soll die Helligkeit ebenfalls im `StatusLabel` erscheinen.

---

# 20. Zusatzaufgabe

Füge hinzu:

```text
LanguageOptionButton
```

Einträge:

```text
Deutsch
English
```

Beim Auswählen soll die gewählte Sprache im Output erscheinen.

Beim Anwenden soll sie ebenfalls im `StatusLabel` stehen.

---

# 21. Kontrollfragen

1. Wofür wird eine `CheckBox` verwendet?
2. Was ist der Unterschied zwischen `CheckBox` und `CheckButton`?
3. Welchen Datentyp liefert `Toggled`?
4. Wofür eignet sich ein `HSlider`?
5. Welchen Datentyp liefert `ValueChanged`?
6. Wofür wird ein `OptionButton` verwendet?
7. Was liefert `ItemSelected`?
8. Wofür wird `GetItemText()` verwendet?
9. Was ist ein `LineEdit`?
10. Welchen Datentyp liefert `TextChanged`?
11. Wie liest man den aktuellen Zustand einer CheckBox aus?
12. Wie liest man den aktuellen Slider-Wert aus?
13. Wie liest man den Text eines LineEdit aus?
14. Warum müssen Event-Handler unterschiedliche Parameter besitzen?
15. Welche Aufgabe besitzt der ApplyButton?

---

# Merksätze

> Unterschiedliche UI-Controls sind für unterschiedliche Eingaben gedacht.

> CheckBox und CheckButton arbeiten mit `bool`.

> Slider arbeiten mit Zahlenwerten.

> OptionButtons arbeiten mit auswählbaren Einträgen.

> LineEdit erlaubt Texteingaben.

> Godot-Signale können unterschiedliche Parameter liefern.

> Der ApplyButton kann die aktuellen Werte aller Controls gemeinsam auslesen.
