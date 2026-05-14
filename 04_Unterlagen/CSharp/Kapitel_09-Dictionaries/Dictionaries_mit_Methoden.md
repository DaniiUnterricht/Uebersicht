<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Dictionaries mit Methoden

## Überblick

Dictionaries können wie Arrays und Listen an Methoden übergeben werden.

Das hilft dabei, Programme sauber aufzuteilen.

Statt alles in die `Main()` zu schreiben, kann man eigene Methoden verwenden.

---

## Dictionary an Methode übergeben

```csharp
static void PrintScores(Dictionary<string, int> scores)
{
    foreach (var entry in scores)
    {
        Console.WriteLine(entry.Key + ": " + entry.Value);
    }
}
```

Die Methode bekommt ein Dictionary mit:

```text
string → int
```

Also zum Beispiel:

```text
Name → Punkte
```

---

## Methode aufrufen

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>()
{
    { "Max", 100 },
    { "Anna", 80 },
    { "Lena", 50 }
};

PrintScores(punkte);
```

---

## Methode zum Hinzufügen

```csharp
static void AddScore(Dictionary<string, int> scores, string name, int score)
{
    scores[name] = score;
}
```

Aufruf:

```csharp
AddScore(punkte, "Tom", 120);
```

👉 Wenn `"Tom"` noch nicht existiert, wird er hinzugefügt.

👉 Wenn `"Tom"` bereits existiert, wird sein Wert überschrieben.

---

## Sicheres Auslesen mit Methode

```csharp
static void PrintScore(Dictionary<string, int> scores, string name)
{
    if (scores.ContainsKey(name))
    {
        Console.WriteLine(name + " hat " + scores[name] + " Punkte.");
    }
    else
    {
        Console.WriteLine(name + " wurde nicht gefunden.");
    }
}
```

Aufruf:

```csharp
PrintScore(punkte, "Anna");
```

---

## Methode mit Rückgabewert

Eine Methode kann auch einen Wert aus dem Dictionary zurückgeben.

```csharp
static int GetScore(Dictionary<string, int> scores, string name)
{
    if (scores.ContainsKey(name))
    {
        return scores[name];
    }

    return 0;
}
```

Aufruf:

```csharp
int score = GetScore(punkte, "Max");
Console.WriteLine(score);
```

---

## Wichtig

Wenn ein Dictionary an eine Methode übergeben wird, arbeitet die Methode mit derselben Liste von Daten.

Das bedeutet:

```csharp
static void AddPlayer(Dictionary<string, int> scores)
{
    scores.Add("Sam", 90);
}
```

Wenn diese Methode aufgerufen wird, ist der neue Eintrag auch außerhalb der Methode vorhanden.

---

## Zusammenfassung

Dictionaries mit Methoden sind sinnvoll, weil:

- Programme übersichtlicher werden
- Code wiederverwendet werden kann
- die `Main()` kleiner bleibt
- man Funktionen wie Anzeigen, Hinzufügen oder Suchen auslagern kann
