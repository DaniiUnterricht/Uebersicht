# PE19.4 – Events

## Lernziele

Nach dieser Einheit kannst du:

- erklären, was ein Event ist,
- Sender und Empfänger unterscheiden,
- eine Methode bei einem Event anmelden,
- ein Event auslösen,
- mehrere Objekte auf dasselbe Event reagieren lassen,
- Event-Handler wieder abmelden,
- den Zusammenhang zwischen Events und Godot-Signalen verstehen.

---

# 1. Was ist ein Event?

Ein Event meldet, dass etwas passiert ist.

Beispiele:

- Lebenspunkte wurden verändert,
- ein Charakter ist gestorben,
- ein Gegenstand wurde eingesammelt,
- eine Tür wurde geöffnet,
- ein Rätsel wurde gelöst,
- ein Button wurde gedrückt.

Ein Event führt nicht automatisch irgendeine bestimmte Aktion aus.

Andere Methoden können sich beim Event anmelden und später auf das Ereignis reagieren.

---

## Grundidee

```text
Etwas passiert
      ↓
Event wird ausgelöst
      ↓
Angemeldete Methoden werden ausgeführt
```

Beispiel:

```text
Spieler verliert Leben
        ↓
HealthChanged wird ausgelöst
        ↓
Lebensanzeige wird aktualisiert
Schadenssound wird abgespielt
Spielstand wird gespeichert
```

---

# 2. Sender, Empfänger und Event-Handler

## Sender

Der Sender besitzt das Event und löst es aus.

```csharp
Player
```

Der Sender wird auch als **Publisher** bezeichnet.

---

## Empfänger

Der Empfänger ist ein Objekt, das auf das Event reagieren soll.

Beispiele:

```csharp
HealthDisplay
SoundPlayer
SaveSystem
```

Der Empfänger wird auch als **Subscriber** bezeichnet.

---

## Event-Handler

Der Event-Handler ist die Methode, die beim Event angemeldet wird.

Beispiele:

```csharp
UpdateHealth
PlayDamageSound
SaveHealth
```

Wichtig:

> Technisch reagiert nicht automatisch das gesamte Objekt.  
> Eine Methode dieses Objekts wird beim Event angemeldet und später aufgerufen.

---

# 3. Ein erstes Event

```csharp
public class Player
{
    public event Action? Died;
}
```

Das Event heißt:

```csharp
Died
```

Der Delegate-Typ ist:

```csharp
Action
```

Das bedeutet:

Das Event kann Methoden ohne Parameter und ohne Rückgabewert speichern.

---

# 4. Event auslösen

Ein Event wird mit `Invoke()` ausgelöst.

```csharp
public class Player
{
    public event Action? Died;

    public void Die()
    {
        Console.WriteLine("Spieler ist gestorben.");

        Died?.Invoke();
    }
}
```

---

## Was bedeutet `?.Invoke()`?

```csharp
Died?.Invoke();
```

Bedeutet:

> Wenn mindestens eine Methode beim Event angemeldet ist, führe alle angemeldeten Methoden aus.

Das `?` verhindert einen Fehler, falls noch keine Methode angemeldet wurde.

---

# 5. Eine Methode beim Event anmelden

```csharp
static void ShowGameOver()
{
    Console.WriteLine("Game Over");
}
```

```csharp
Player player = new Player();

player.Died += ShowGameOver;
```

Mit `+=` wird die Methode beim Event angemeldet.

---

## Event auslösen

```csharp
player.Die();
```

Ablauf:

```text
player.Die()
    ↓
Died?.Invoke()
    ↓
ShowGameOver()
```

Ausgabe:

```text
Spieler ist gestorben.
Game Over
```

---

# 6. Was bedeutet „ein Objekt reagiert“?

Angenommen, es gibt ein eigenes Objekt für die Lebensanzeige:

```csharp
public class HealthDisplay
{
    public void UpdateHealth(int health)
    {
        Console.WriteLine($"Lebensanzeige: {health}");
    }
}
```

Objekt erstellen:

```csharp
HealthDisplay healthDisplay =
    new HealthDisplay();
```

Die Methode dieses Objekts wird beim Event angemeldet:

```csharp
player.HealthChanged += healthDisplay.UpdateHealth;
```

Der wichtige Teil ist:

```csharp
healthDisplay.UpdateHealth
```

Das ist eine konkrete Methode des konkreten Objekts `healthDisplay`.

Wenn das Event ausgelöst wird, wird genau diese Methode auf diesem Objekt ausgeführt.

---

## Genauer Merksatz

> Ein Objekt reagiert auf ein Event, indem eine passende Methode dieses Objekts mit `+=` beim Event angemeldet wird.

---

# 7. Event mit Parameter

Ein Event kann Werte an die angemeldeten Methoden übergeben.

```csharp
public class Player
{
    public event Action<int>? HealthChanged;

    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        HealthChanged?.Invoke(Health);
    }
}
```

Das Event verwendet:

```csharp
Action<int>
```

Daher müssen angemeldete Methoden diese Form besitzen:

```csharp
void Methode(int wert)
```

---

## Passende Empfänger-Methode

```csharp
public class HealthDisplay
{
    public void UpdateHealth(int health)
    {
        Console.WriteLine($"Lebensanzeige: {health}");
    }
}
```

Anmeldung:

```csharp
Player player = new Player();

HealthDisplay healthDisplay =
    new HealthDisplay();

player.HealthChanged += healthDisplay.UpdateHealth;
```

Event auslösen:

```csharp
player.TakeDamage(20);
```

Ablauf:

```text
player.TakeDamage(20)
        ↓
Health wird auf 80 gesetzt
        ↓
HealthChanged?.Invoke(80)
        ↓
healthDisplay.UpdateHealth(80)
```

Ausgabe:

```text
Lebensanzeige: 80
```

---

# 8. Mehrere Objekte reagieren auf dasselbe Event

Zusätzlich zur Lebensanzeige soll ein Sound abgespielt werden.

```csharp
public class SoundPlayer
{
    public void PlayDamageSound(int health)
    {
        Console.WriteLine("Schadenssound wird abgespielt.");
    }
}
```

Außerdem sollen die Lebenspunkte gespeichert werden.

```csharp
public class SaveSystem
{
    public void SaveHealth(int health)
    {
        Console.WriteLine(
            $"Lebenspunkte {health} gespeichert."
        );
    }
}
```

Objekte erstellen:

```csharp
Player player = new Player();

HealthDisplay healthDisplay =
    new HealthDisplay();

SoundPlayer soundPlayer =
    new SoundPlayer();

SaveSystem saveSystem =
    new SaveSystem();
```

Methoden anmelden:

```csharp
player.HealthChanged += healthDisplay.UpdateHealth;
player.HealthChanged += soundPlayer.PlayDamageSound;
player.HealthChanged += saveSystem.SaveHealth;
```

Wenn das Event ausgelöst wird, werden alle drei Methoden ausgeführt.

---

## Ablauf

```text
Player
  │
  │ HealthChanged auslösen
  ▼
Event
  ├── healthDisplay.UpdateHealth()
  ├── soundPlayer.PlayDamageSound()
  └── saveSystem.SaveHealth()
```

Der `Player` muss die drei Empfänger nicht direkt kennen.

Er meldet nur:

> Meine Lebenspunkte haben sich verändert.

---

# 9. Warum nicht direkt andere Objekte aufrufen?

Ohne Event könnte der `Player` alle anderen Systeme direkt aufrufen:

```csharp
public class Player
{
    private HealthDisplay _healthDisplay;
    private SoundPlayer _soundPlayer;
    private SaveSystem _saveSystem;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        _healthDisplay.UpdateHealth(Health);
        _soundPlayer.PlayDamageSound(Health);
        _saveSystem.SaveHealth(Health);
    }
}
```

Problem:

Der `Player` muss alle anderen Klassen kennen.

Wenn später ein weiteres System reagieren soll, muss die Klasse `Player` verändert werden.

---

## Mit Event

```csharp
HealthChanged?.Invoke(Health);
```

Der `Player` meldet nur das Ereignis.

Andere Objekte entscheiden selbst, ob sie darauf reagieren möchten.

Dadurch bleiben die Klassen unabhängiger voneinander.

---

# 10. Wer meldet die Methoden an?

Die Anmeldung passiert dort, wo die Objekte miteinander verbunden werden.

In einem Konsolenprogramm kann das in `Program.cs` passieren:

```csharp
Player player = new Player();
HealthDisplay display = new HealthDisplay();

player.HealthChanged += display.UpdateHealth;
```

In Godot geschieht das später häufig in `_Ready()`:

```csharp
public override void _Ready()
{
    _player.HealthChanged += UpdateHealth;
}
```

---

# 11. Event-Handler abmelden

Mit `-=` wird eine Methode wieder vom Event entfernt.

```csharp
player.HealthChanged -= healthDisplay.UpdateHealth;
```

Danach wird diese Methode beim nächsten Auslösen nicht mehr aufgerufen.

---

## Warum ist das wichtig?

Ein Objekt soll nur reagieren, solange es aktiv oder vorhanden ist.

Beispiele:

- ein Menü wurde geschlossen,
- eine Szene wurde gewechselt,
- ein UI-Element wurde entfernt,
- ein Objekt wird nicht mehr benötigt.

In Godot könnte später in `_ExitTree()` abgemeldet werden:

```csharp
public override void _ExitTree()
{
    _player.HealthChanged -= UpdateHealth;
}
```

---

# 12. Mehrfach anmelden

Eine Methode kann versehentlich mehrfach angemeldet werden:

```csharp
player.HealthChanged += healthDisplay.UpdateHealth;
player.HealthChanged += healthDisplay.UpdateHealth;
```

Dann wird sie beim Event auch zweimal ausgeführt.

Einmaliges Abmelden entfernt nur eine Anmeldung:

```csharp
player.HealthChanged -= healthDisplay.UpdateHealth;
```

---

# 13. Reihenfolge der Event-Handler

Die Methoden werden grundsätzlich in der Reihenfolge ausgeführt, in der sie angemeldet wurden.

```csharp
player.HealthChanged += healthDisplay.UpdateHealth;
player.HealthChanged += soundPlayer.PlayDamageSound;
player.HealthChanged += saveSystem.SaveHealth;
```

Aufrufreihenfolge:

```text
1. healthDisplay.UpdateHealth
2. soundPlayer.PlayDamageSound
3. saveSystem.SaveHealth
```

Trotzdem sollte wichtiger Programmcode nicht unnötig davon abhängig gemacht werden, dass Event-Handler in einer bestimmten Reihenfolge laufen.

---

# 14. Statische Methoden als Event-Handler

Auch eine statische Methode kann angemeldet werden:

```csharp
static void WriteHealthLog(int health)
{
    Console.WriteLine($"LOG: {health}");
}
```

```csharp
player.HealthChanged += WriteHealthLog;
```

Hier gibt es kein konkretes Empfängerobjekt.

Bei objektorientierten Programmen werden jedoch oft Methoden konkreter Objekte angemeldet:

```csharp
player.HealthChanged += healthDisplay.UpdateHealth;
```

---

# 15. Event mit eigenem Delegate

Statt `Action<int>` kann auch ein eigener Delegate verwendet werden.

```csharp
public delegate void HealthChangedEventHandler(
    int health
);
```

```csharp
public class Player
{
    public event HealthChangedEventHandler?
        HealthChanged;
}
```

Auslösen:

```csharp
HealthChanged?.Invoke(Health);
```

Anmelden:

```csharp
player.HealthChanged +=
    healthDisplay.UpdateHealth;
```

Ein eigener Delegate besitzt einen sprechenden Namen und beschreibt den Zweck des Events genauer.

---

# 16. Event mit mehreren Parametern

```csharp
public event Action<string, int>? ItemCollected;
```

Auslösen:

```csharp
ItemCollected?.Invoke(itemName, amount);
```

Passende Methode:

```csharp
public void ShowCollectedItem(
    string itemName,
    int amount)
{
    Console.WriteLine(
        $"{amount}x {itemName} eingesammelt."
    );
}
```

Anmelden:

```csharp
inventory.ItemCollected +=
    display.ShowCollectedItem;
```

---

# 17. Event darf nur vom Besitzer ausgelöst werden

```csharp
public event Action? Died;
```

Code außerhalb der Klasse darf:

```csharp
player.Died += ShowGameOver;
player.Died -= ShowGameOver;
```

Code außerhalb der Klasse darf das Event normalerweise nicht selbst auslösen:

```csharp
player.Died?.Invoke();
```

Das Event darf nur innerhalb der Klasse ausgelöst werden, der es gehört.

Dadurch entscheidet nur der `Player`, wann er wirklich gestorben ist.

---

# 18. Warum nicht einfach ein öffentliches Delegate?

Ungünstig:

```csharp
public Action? Died;
```

Dann könnte anderer Code:

```csharp
player.Died = AndereMethode;
```

Dadurch würden bisher angemeldete Methoden überschrieben.

Außerdem könnte anderer Code versuchen, das Delegate selbst auszulösen.

Besser:

```csharp
public event Action? Died;
```

Mit `event` darf externer Code normalerweise nur:

```csharp
+=
-=
```

verwenden.

---

# 19. Typische Events in Spielen

```csharp
HealthChanged
```

Lebenspunkte wurden verändert.

```csharp
Died
```

Charakter ist gestorben.

```csharp
ItemCollected
```

Gegenstand wurde eingesammelt.

```csharp
DoorOpened
```

Tür wurde geöffnet.

```csharp
PuzzleSolved
```

Rätsel wurde gelöst.

```csharp
ScoreChanged
```

Punktestand wurde verändert.

```csharp
GamePaused
```

Spiel wurde pausiert.

---

# 20. Vorbereitung auf Godot

Godot verwendet Signale für dieselbe Grundidee:

```text
Etwas passiert
    ↓
Signal wird ausgelöst
    ↓
Andere Nodes reagieren
```

Ein Godot-Button besitzt beispielsweise ein Event:

```csharp
button.Pressed += OnButtonPressed;
```

Die Methode wird angemeldet:

```csharp
private void OnButtonPressed()
{
    GD.Print("Button gedrückt");
}
```

Das reagierende Objekt ist die Node-Instanz, zu der `OnButtonPressed()` gehört.

Eigene Godot-Signale werden später ebenfalls über Delegates beschrieben:

```csharp
[Signal]
public delegate void HealthChangedEventHandler(
    int health
);
```

Die genaue Godot-Schreibweise wird in einer zukünftigen Einheit behandelt.

---

# Kurzüberblick

Event erstellen:

```csharp
public event Action? Died;
```

Methode anmelden:

```csharp
player.Died += ShowGameOver;
```

Event auslösen:

```csharp
Died?.Invoke();
```

Methode abmelden:

```csharp
player.Died -= ShowGameOver;
```

Event mit Parameter:

```csharp
public event Action<int>? HealthChanged;
```

Auslösen mit Wert:

```csharp
HealthChanged?.Invoke(Health);
```

Methode eines Objekts anmelden:

```csharp
player.HealthChanged +=
    healthDisplay.UpdateHealth;
```

---

# Merksätze

> Ein Event meldet, dass etwas passiert ist.

> Der Sender besitzt das Event und löst es aus.

> Ein Empfänger reagiert, indem eine passende Methode dieses Objekts mit `+=` beim Event angemeldet wird.

> Die angemeldete Methode wird als Event-Handler bezeichnet.

> Mit `-=` wird ein Event-Handler wieder abgemeldet.

> Der Sender muss die reagierenden Objekte nicht direkt kennen.
