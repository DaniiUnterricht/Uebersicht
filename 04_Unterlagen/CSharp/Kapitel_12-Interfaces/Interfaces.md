# PE19.1 – Interfaces

---

## Lernziele

Nach dieser Einheit kannst du:

- erklären, was ein Interface ist,
- ein eigenes Interface erstellen,
- ein Interface in einer Klasse implementieren,
- unterschiedliche Klassen über dasselbe Interface verwenden,
- mehrere Interfaces in einer Klasse einsetzen.

---

## Was ist ein Interface?

Ein Interface beschreibt, **was eine Klasse können muss**.

```csharp
public interface IInteractable
{
    void Interact();
}
```

Jede Klasse mit `IInteractable` muss eine Methode `Interact()` besitzen.

---

## Interface erstellen

Interfaces beginnen häufig mit einem großen `I`.

```csharp
public interface IInteractable
{
    void Interact();
}
```

Ein Interface enthält die Methodensignatur, aber normalerweise keinen fertigen Methodeninhalt.

---

## Interface implementieren

```csharp
public class Door : IInteractable
{
    public void Interact()
    {
        Console.WriteLine("Die Tür wird geöffnet.");
    }
}
```

Fehlt eine vorgegebene Methode, entsteht ein Compilerfehler.

---

## Mehrere Klassen mit demselben Interface

```csharp
public class Chest : IInteractable
{
    public void Interact()
    {
        Console.WriteLine("Die Truhe wird geöffnet.");
    }
}
```

```csharp
public class LightSwitch : IInteractable
{
    public void Interact()
    {
        Console.WriteLine("Das Licht wird umgeschaltet.");
    }
}
```

Alle Klassen reagieren unterschiedlich, besitzen aber dieselbe Fähigkeit.

---

## Objekte über das Interface verwenden

```csharp
IInteractable interactable = new Door();

interactable.Interact();
```

Die Variable weiß nur:

> Dieses Objekt kann interagiert werden.

---

## Liste aus Interface-Objekten

```csharp
List<IInteractable> interactables =
    new List<IInteractable>();

interactables.Add(new Door());
interactables.Add(new Chest());
interactables.Add(new LightSwitch());
```

```csharp
foreach (IInteractable interactable in interactables)
{
    interactable.Interact();
}
```

Unterschiedliche Klassen können gleich behandelt werden.

---

## Typprüfung mit Interface

```csharp
object gameObject = new Door();

if (gameObject is IInteractable interactable)
{
    interactable.Interact();
}
```

Es wird geprüft, ob das Objekt eine bestimmte Fähigkeit besitzt.

---

## Spezifische Methoden einer Klasse verwenden

Eine Interface-Variable kennt zunächst nur die Methoden und Eigenschaften des Interfaces.

```csharp
public class Chest : IInteractable
{
    public void Interact()
    {
        Console.WriteLine("Die Truhe wird geöffnet.");
    }

    public void ShowInventory()
    {
        Console.WriteLine("Der Inhalt der Truhe wird angezeigt.");
    }
}
```

```csharp
IInteractable interactable = new Chest();

interactable.Interact();
```

Die klassenspezifische Methode ist über `IInteractable` nicht direkt verfügbar:

```csharp
// Funktioniert nicht:
// interactable.ShowInventory();
```

Dafür muss zuerst geprüft werden, ob das Objekt tatsächlich eine `Chest` ist:

```csharp
if (interactable is Chest chest)
{
    chest.ShowInventory();
}
```

Über das Interface werden alle Objekte einheitlich behandelt. Nach der Typprüfung können trotzdem die speziellen Methoden der konkreten Klasse verwendet werden.

---

## Typprüfung mit `is`

Mit `is` wird geprüft, ob ein Objekt einem bestimmten Typ entspricht.

```csharp
if (gameObject is Door)
{
    Console.WriteLine("Das Objekt ist eine Tür.");
}
```

Mit Pattern Matching kann gleichzeitig eine passende Variable erstellt werden:

```csharp
if (gameObject is Door door)
{
    door.Open();
}
```

Dabei passiert beides:

1. Es wird geprüft, ob `gameObject` eine `Door` ist.
2. Bei erfolgreicher Prüfung wird die Variable `door` erstellt.

Dasselbe funktioniert auch mit Interfaces:

```csharp
if (gameObject is IInteractable interactable)
{
    interactable.Interact();
}
```

Die allgemeine Schreibweise lautet:

```csharp
if (objekt is Typ variable)
{
}
```

---

## Dasselbe Objekt in mehreren Listen

Dasselbe Objekt kann gleichzeitig in mehreren Listen gespeichert werden.

```csharp
Chest chest = new Chest();

List<Chest> chests = new List<Chest>();
List<IInteractable> interactables =
    new List<IInteractable>();

chests.Add(chest);
interactables.Add(chest);
```

Es wurde nur eine `Chest` erstellt. Beide Listen enthalten eine Referenz auf dieselbe Objektinstanz.

```text
chests[0] ───────────────┐
                         ▼
                    Chest-Objekt
                         ▲
interactables[0] ────────┘
```

Eine Änderung über eine Liste ist deshalb auch über die andere Liste sichtbar:

```csharp
chests[0].Gold = 100;

if (interactables[0] is Chest selectedChest)
{
    Console.WriteLine(selectedChest.Gold);
}
```

Ausgabe:

```text
100
```

Wichtig ist, dass dasselbe Objekt hinzugefügt wird:

```csharp
Chest chest = new Chest();

chests.Add(chest);
interactables.Add(chest);
```

Hier entstehen hingegen zwei verschiedene Objekte:

```csharp
chests.Add(new Chest());
interactables.Add(new Chest());
```

Das Entfernen aus einer Liste entfernt nur die Referenz aus dieser Liste:

```csharp
chests.Remove(chest);
```

Das Objekt kann weiterhin über `interactables` erreicht werden.

---

## Mehrere Interfaces

```csharp
public interface IInteractable
{
    void Interact();
}
```

```csharp
public interface ISaveable
{
    string Save();
}
```

```csharp
public class Door : IInteractable, ISaveable
{
    public bool IsOpen { get; set; }

    public void Interact()
    {
        IsOpen = !IsOpen;
    }

    public string Save()
    {
        return IsOpen.ToString();
    }
}
```

Eine Klasse kann mehrere Interfaces implementieren.

---

## Interface mit Properties

```csharp
public interface IDamageable
{
    int Health { get; }

    void TakeDamage(int damage);
}
```

```csharp
public class Player : IDamageable
{
    public int Health { get; private set; } = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
```

---

## Interface mit Parametern und Rückgabewerten

```csharp
public interface ICalculator
{
    int Add(int number1, int number2);
}
```

```csharp
public class Calculator : ICalculator
{
    public int Add(int number1, int number2)
    {
        return number1 + number2;
    }
}
```

Die Umsetzung muss dieselben Methodennamen, Parameter, Datentypen und Rückgabewerte verwenden.

---

## Interface und Vererbung

### Vererbung

Beschreibt häufig, **was ein Objekt ist**.

```csharp
public class Wizard : Player
{
}
```

### Interface

Beschreibt häufig, **was ein Objekt kann**.

```csharp
public class Door : IInteractable
{
    public void Interact()
    {
    }
}
```

| Vererbung | Interface |
|---|---|
| Beschreibt häufig eine Art von Objekt | Beschreibt häufig eine Fähigkeit |
| Eine Basisklasse möglich | Mehrere Interfaces möglich |
| Kann fertigen Code enthalten | Enthält hauptsächlich Vorgaben |
| `Wizard : Player` | `Door : IInteractable` |

---

## Warum ist das für Godot wichtig?

Godot-Skripte erben bereits von einer Godot-Klasse:

```csharp
public partial class Door : Area2D
{
}
```

Ein Interface kann zusätzlich verwendet werden:

```csharp
public partial class Door : Area2D, IInteractable
{
    public void Interact()
    {
        GD.Print("Tür geöffnet");
    }
}
```

```csharp
public partial class Door
    : Area2D, IInteractable, ISaveable
{
}
```

---

## Typische Interfaces in Spielen

| Interface | Bedeutung |
|---|---|
| `IInteractable` | Kann verwendet oder angeklickt werden |
| `IDamageable` | Kann Schaden erhalten |
| `ICollectable` | Kann eingesammelt werden |
| `ISaveable` | Kann gespeichert werden |
| `IActivatable` | Kann aktiviert und deaktiviert werden |

---

## Merksatz

> Ein Interface legt fest, was ein Objekt können muss. Unterschiedliche Klassen können dadurch dieselbe Fähigkeit besitzen und gleich behandelt werden.
