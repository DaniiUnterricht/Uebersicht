# PE19.2 – Enums und Zustände

---

## Lernziele

Nach dieser Einheit kannst du:

- erklären, was ein Enum ist,
- ein eigenes Enum erstellen,
- Enum-Werte speichern und vergleichen,
- Enums mit `if` und `switch` verwenden,
- Zustände eines Spiels mit Enums abbilden.

---

## Was ist ein Enum?

Ein Enum enthält eine festgelegte Auswahl benannter Werte.

```csharp
public enum DoorState
{
    Locked,
    Closed,
    Open
}
```

Eine Tür kann dadurch nur einen der vorgegebenen Zustände besitzen.

---

## Enum verwenden

```csharp
DoorState currentState = DoorState.Closed;
```

```csharp
Console.WriteLine(currentState);
```

---

## Enum-Wert verändern

```csharp
currentState = DoorState.Open;
```

---

## Enum vergleichen

```csharp
if (currentState == DoorState.Locked)
{
    Console.WriteLine("Die Tür ist versperrt.");
}
```

---

## Enum mit Switch

```csharp
switch (currentState)
{
    case DoorState.Locked:
        Console.WriteLine("Die Tür ist versperrt.");
        break;

    case DoorState.Closed:
        Console.WriteLine("Die Tür ist geschlossen.");
        break;

    case DoorState.Open:
        Console.WriteLine("Die Tür ist offen.");
        break;
}
```

---

## Enum als Property

```csharp
public class Door
{
    public DoorState State { get; private set; }

    public Door()
    {
        State = DoorState.Closed;
    }
}
```

---

## Zustandswechsel

```csharp
public void Open()
{
    if (State == DoorState.Locked)
    {
        Console.WriteLine("Die Tür ist versperrt.");
        return;
    }

    State = DoorState.Open;
}
```

```csharp
public void Close()
{
    if (State == DoorState.Locked)
    {
        Console.WriteLine("Die Tür ist versperrt.");
        return;
    }
    
    State = DoorState.Closed;
}
```

```csharp
public void Lock()
{
    State = DoorState.Locked;
}
```

---

## Beispiel: Spielzustand

```csharp
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}
```

```csharp
GameState currentState = GameState.MainMenu;
```

```csharp
switch (currentState)
{
    case GameState.MainMenu:
        Console.WriteLine("Hauptmenü");
        break;

    case GameState.Playing:
        Console.WriteLine("Spiel läuft");
        break;

    case GameState.Paused:
        Console.WriteLine("Spiel pausiert");
        break;

    case GameState.GameOver:
        Console.WriteLine("Game Over");
        break;
}
```

---

## Beispiel: Gegenstandskategorie

```csharp
public enum ItemCategory
{
    Key,
    Tool,
    Consumable,
    Document
}
```

```csharp
public class Item
{
    public string Name { get; set; }
    public ItemCategory Category { get; set; }

    public Item(string name, ItemCategory category)
    {
        Name = name;
        Category = category;
    }
}
```

```csharp
Item key = new Item(
    "Kellerschlüssel",
    ItemCategory.Key
);
```

---

## Enum über die Konsole einlesen

```csharp
Console.WriteLine("Zustand eingeben:");

string input = Console.ReadLine() ?? "";
```

```csharp
bool success = Enum.TryParse(
    input,
    true,
    out DoorState state
);
```

```csharp
if (success)
{
    Console.WriteLine($"Gewählter Zustand: {state}");
}
else
{
    Console.WriteLine("Ungültiger Zustand.");
}
```

Der zweite Parameter `true` ignoriert Groß- und Kleinschreibung.

---

## Alle Enum-Werte ausgeben

```csharp
foreach (DoorState state in Enum.GetValues<DoorState>())
{
    Console.WriteLine(state);
}
```

---

## Eigene Zahlenwerte

```csharp
public enum Difficulty
{
    Easy = 1,
    Normal = 2,
    Hard = 3
}
```

```csharp
Difficulty difficulty = Difficulty.Normal;

int value = (int)difficulty;
```

---

## Von Zahl zu Enum

```csharp
if (Enum.IsDefined(typeof(Difficulty), 2))
{
    Difficulty difficulty = (Difficulty)2;
}
```

---

## Enum statt String

Ungünstig:

```csharp
string state = "Open";
```

Mögliche Fehler:

```csharp
state = "open";
state = "Opened";
state = "Oepn";
```

Besser:

```csharp
DoorState state = DoorState.Open;
```

Der Compiler erkennt ungültige Werte.

---

## Typische Enums in Spielen

| Enum | Beispiele |
|---|---|
| `GameState` | Hauptmenü, Spiel, Pause, Game Over |
| `DoorState` | Versperrt, geschlossen, offen |
| `CharacterState` | Idle, Running, Jumping, Dead |
| `ItemCategory` | Schlüssel, Werkzeug, Trank, Dokument |
| `Difficulty` | Einfach, normal, schwer |
| `Direction` | Oben, unten, links, rechts |

---

## Warum ist das für Godot wichtig?

Godot-Spiele bestehen aus vielen Zuständen.

```csharp
public enum PuzzleState
{
    NotStarted,
    InProgress,
    Solved
}
```

```csharp
[Export]
public PuzzleState State { get; set; }
```

Exportierte Enums können später im Godot-Inspector ausgewählt werden.

---

## Merksatz

> Ein Enum wird verwendet, wenn eine Variable nur eine festgelegte Auswahl gültiger Werte besitzen soll.
