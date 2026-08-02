# PE19.3 – Delegates

[Zurück zum Inhaltsverzeichnis](#inhaltsverzeichnis)

---

## Lernziele

Nach dieser Einheit kannst du:

- erklären, was ein Delegate ist,
- Methoden in einer Delegate-Variable speichern,
- Methoden über einen Delegate aufrufen,
- passende und unpassende Methodensignaturen unterscheiden,
- eigene Delegates mit `Action` und `Func` vergleichen,
- mehrere Methoden in einem Multicast Delegate verwalten.

---

# 1. Was ist ein Delegate?

Ein Delegate ist vereinfacht gesagt ein **Datentyp für Methoden**.

Normale Variablen speichern Werte:

```csharp
int zahl = 10;
string text = "Hallo";
```

Eine Delegate-Variable speichert dagegen einen Verweis auf eine Methode:

```csharp
Action aktion = Begruessen;
```

Die Methode wird dabei noch nicht ausgeführt.

Sie wird nur für einen späteren Aufruf gespeichert.

```csharp
aktion();
```

---

## Beispiel

```csharp
static void Begruessen()
{
    Console.WriteLine("Hallo!");
}
```

```csharp
Action aktion = Begruessen;

aktion();
```

Ausgabe:

```text
Hallo!
```

Wichtig:

```csharp
Action aktion = Begruessen;
```

speichert die Methode.

```csharp
Action aktion = Begruessen();
```

würde versuchen, die Methode sofort auszuführen und ihr Ergebnis zu speichern.

Da `Begruessen()` keinen Wert zurückgibt, ist diese Schreibweise ungültig.

---

# 2. Warum verwendet man Delegates?

Delegates sind sinnvoll, wenn einmal festgelegt werden soll, **welche Methode zukünftig verwendet wird**.

Danach kann der restliche Programmcode immer denselben Delegate aufrufen, ohne erneut prüfen zu müssen, welche konkrete Methode ausgeführt werden soll.

---

## Beispiel: Ausgabemethode einmal auswählen

Ein Programm kann Meldungen entweder normal oder als Warnung ausgeben.

```csharp
static void NormaleAusgabe(string text)
{
    Console.WriteLine(text);
}
```

```csharp
static void WarnungsAusgabe(string text)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"WARNUNG: {text}");
    Console.ResetColor();
}
```

Zu Beginn wird einmal ausgewählt, welche Methode zukünftig verwendet werden soll:

```csharp
Console.WriteLine("Ausgabeart wählen:");
Console.WriteLine("1 - Normal");
Console.WriteLine("2 - Warnung");

string auswahl = Console.ReadLine() ?? "";

Action<string> ausgabeMethode;

if (auswahl == "2")
{
    ausgabeMethode = WarnungsAusgabe;
}
else
{
    ausgabeMethode = NormaleAusgabe;
}
```

Danach verwendet das Programm immer dieselbe Delegate-Variable:

```csharp
ausgabeMethode("Programm wurde gestartet.");
ausgabeMethode("Datei wurde geladen.");
ausgabeMethode("Spielstand wurde gespeichert.");
```

Die Auswahl muss nicht bei jeder Ausgabe erneut geprüft werden.

---

## Ohne Delegate

Ohne Delegate müsste die Abfrage bei jeder Ausgabe wiederholt werden:

```csharp
if (auswahl == "2")
{
    WarnungsAusgabe("Programm wurde gestartet.");
}
else
{
    NormaleAusgabe("Programm wurde gestartet.");
}
```

```csharp
if (auswahl == "2")
{
    WarnungsAusgabe("Datei wurde geladen.");
}
else
{
    NormaleAusgabe("Datei wurde geladen.");
}
```

Mit Delegate wird die Methode einmal ausgewählt und anschließend einheitlich verwendet:

```csharp
ausgabeMethode("Programm wurde gestartet.");
ausgabeMethode("Datei wurde geladen.");
```

---

# 3. Eigene Delegates

Ein eigener Delegate legt fest, welche Methodensignatur erlaubt ist.

```csharp
public delegate void MessageHandler(string message);
```

Dieser Delegate erwartet eine Methode mit:

- Rückgabewert `void`
- genau einem Parameter vom Typ `string`

Die erwartete Form ist:

```csharp
void Methode(string message)
```

---

## Passende Methode

```csharp
static void ShowMessage(string message)
{
    Console.WriteLine(message);
}
```

```csharp
MessageHandler handler = ShowMessage;

handler("Hallo!");
```

---

## Weitere passende Methode

```csharp
static void WriteLog(string message)
{
    Console.WriteLine($"LOG: {message}");
}
```

Auch diese Methode passt, weil Parameter und Rückgabewert gleich aufgebaut sind:

```csharp
MessageHandler handler = WriteLog;
```

---

# 4. Unpassende Methoden

Eine Methode kann nur gespeichert werden, wenn ihre Signatur zum Delegate passt.

Dabei müssen übereinstimmen:

- Anzahl der Parameter
- Reihenfolge der Parameter
- Datentypen der Parameter
- Rückgabewert

---

## Falsche Parameter

```csharp
static void ShowNumber(int number)
{
    Console.WriteLine(number);
}
```

```csharp
MessageHandler handler = ShowNumber;
```

Das erzeugt einen **Compilerfehler**, weil `MessageHandler` einen `string` erwartet.

Erwartet:

```csharp
void Methode(string message)
```

Vorhanden:

```csharp
void Methode(int number)
```

---

## Falscher Rückgabewert

```csharp
static string CreateMessage(string message)
{
    return $"Nachricht: {message}";
}
```

```csharp
MessageHandler handler = CreateMessage;
```

Das erzeugt einen **Compilerfehler**, weil `MessageHandler` den Rückgabewert `void` erwartet.

---

## Falsche Anzahl an Parametern

```csharp
static void ShowMessage(
    string title,
    string message)
{
    Console.WriteLine($"{title}: {message}");
}
```

```csharp
MessageHandler handler = ShowMessage;
```

Das erzeugt einen **Compilerfehler**, weil die Methode zwei Parameter besitzt, der Delegate aber nur einen erwartet.

---

## Vollständig unpassende Methode

```csharp
static int Add(int number1, int number2)
{
    return number1 + number2;
}
```

```csharp
MessageHandler handler = Add;
```

Das erzeugt einen **Compilerfehler**, weil weder Parameter noch Rückgabewert passen.

---

## Merksatz

> Ein Delegate akzeptiert nur Methoden mit passender Parameterliste und passendem Rückgabewert.

---

# 5. Eigener Delegate und `Action`

`Action` ist ein bereits vorhandener Delegate-Typ von C#.

`Action` wird für Methoden verwendet, die **keinen Wert zurückgeben**.

---

## Eigener Delegate ohne Parameter

```csharp
public delegate void GameAction();
```

```csharp
static void StartGame()
{
    Console.WriteLine("Spiel gestartet.");
}
```

```csharp
GameAction aktion = StartGame;

aktion();
```

Dasselbe mit `Action`:

```csharp
Action aktion = StartGame;

aktion();
```

---

## Eigener Delegate mit einem Parameter

```csharp
public delegate void MessageHandler(string message);
```

```csharp
MessageHandler handler = ShowMessage;
```

Dasselbe mit `Action`:

```csharp
Action<string> handler = ShowMessage;
```

---

## Eigener Delegate mit mehreren Parametern

```csharp
public delegate void ItemHandler(
    string itemName,
    int amount
);
```

Dasselbe mit `Action`:

```csharp
Action<string, int> itemHandler;
```

Die Datentypen stehen in derselben Reihenfolge wie die Parameter der Methode:

```csharp
static void ShowItem(
    string itemName,
    int amount)
{
}
```

```csharp
Action<string, int> itemHandler = ShowItem;
```

---

## Vergleich

```csharp
public delegate void MessageHandler(string message);
```

entspricht grundsätzlich:

```csharp
Action<string>
```

Beide erwarten:

```csharp
void Methode(string message)
```

---

# 6. Eigener Delegate und `Func`

`Func` ist ein bereits vorhandener Delegate-Typ für Methoden **mit Rückgabewert**.

Beim `Func` ist der **letzte Datentyp immer der Rückgabewert**.

Alle Datentypen davor sind die Parameter.

---

## Eigener Delegate ohne Parameter

```csharp
public delegate int NumberProvider();
```

Passende Methode:

```csharp
static int GetNumber()
{
    return 10;
}
```

Mit eigenem Delegate:

```csharp
NumberProvider provider = GetNumber;
```

Dasselbe mit `Func`:

```csharp
Func<int> provider = GetNumber;
```

Hier ist der einzige Datentyp der Rückgabewert.

---

## Eigener Delegate mit einem Parameter

```csharp
public delegate string TextConverter(string text);
```

Passende Methode:

```csharp
static string ToUpperCase(string text)
{
    return text.ToUpper();
}
```

Mit eigenem Delegate:

```csharp
TextConverter converter = ToUpperCase;
```

Dasselbe mit `Func`:

```csharp
Func<string, string> converter = ToUpperCase;
```

Bedeutung:

```text
erster string  → Parameter
letzter string → Rückgabewert
```

---

## Eigener Delegate mit zwei Parametern

```csharp
public delegate int Calculation(
    int number1,
    int number2
);
```

Passende Methode:

```csharp
static int Add(int number1, int number2)
{
    return number1 + number2;
}
```

Mit eigenem Delegate:

```csharp
Calculation calculation = Add;
```

Dasselbe mit `Func`:

```csharp
Func<int, int, int> calculation = Add;
```

Bedeutung:

```text
erster int  → erster Parameter
zweiter int → zweiter Parameter
letzter int → Rückgabewert
```

---

## Beliebig viele Parameter

Vor dem letzten Datentyp können mehrere Parameterdatentypen stehen:

```csharp
Func<string, int, bool, double>
```

Das entspricht einer Methode mit:

```csharp
double Methode(
    string text,
    int number,
    bool active
)
```

Also:

```text
string → erster Parameter
int    → zweiter Parameter
bool   → dritter Parameter
double → Rückgabewert
```

---

## Merksatz zu `Func`

> Beim `Func` ist der letzte Datentyp immer der Rückgabewert. Alle Datentypen davor sind die Parameter.

---

# 7. Delegate als Methodenparameter

Ein Delegate kann an eine andere Methode übergeben werden.

Dadurch kann die aufgerufene Methode eine Aktion ausführen, ohne die konkrete Methode vorher zu kennen.

```csharp
static void ExecuteThreeTimes(Action action)
{
    action();
    action();
    action();
}
```

```csharp
static void Jump()
{
    Console.WriteLine("Sprung!");
}
```

```csharp
ExecuteThreeTimes(Jump);
```

Ausgabe:

```text
Sprung!
Sprung!
Sprung!
```

Die Methode `ExecuteThreeTimes` weiß nicht, was `action` konkret macht.

Sie weiß nur:

> Ich kann diese Methode ohne Parameter aufrufen.

---

## Delegate mit Parameter weitergeben

```csharp
static void ProcessMessage(
    string message,
    Action<string> output)
{
    output(message);
}
```

```csharp
ProcessMessage(
    "Spiel gespeichert.",
    NormaleAusgabe
);
```

```csharp
ProcessMessage(
    "Spielstand beschädigt.",
    WarnungsAusgabe
);
```

Dieselbe Methode kann dadurch unterschiedliche Ausgabemethoden verwenden.

---

# 8. Multicast Delegates

Ein Delegate kann auf mehrere Methoden gleichzeitig verweisen.

Das nennt man einen **Multicast Delegate**.

```csharp
Action action = FirstMethod;

action += SecondMethod;
action += ThirdMethod;
```

Beim Aufruf werden alle gespeicherten Methoden ausgeführt:

```csharp
action();
```

---

## Reihenfolge

Die Methoden werden grundsätzlich in der Reihenfolge ausgeführt, in der sie hinzugefügt wurden.

```csharp
Action action = FirstMethod;

action += SecondMethod;
action += ThirdMethod;
```

Aufrufreihenfolge:

```text
1. FirstMethod
2. SecondMethod
3. ThirdMethod
```

---

## Beispiel

```csharp
static void FirstMethod()
{
    Console.WriteLine("Erste Methode");
}
```

```csharp
static void SecondMethod()
{
    Console.WriteLine("Zweite Methode");
}
```

```csharp
static void ThirdMethod()
{
    Console.WriteLine("Dritte Methode");
}
```

```csharp
Action action = FirstMethod;

action += SecondMethod;
action += ThirdMethod;

action();
```

Ausgabe:

```text
Erste Methode
Zweite Methode
Dritte Methode
```

---

## Methode entfernen

Mit `-=` wird eine Methode entfernt:

```csharp
action -= SecondMethod;
```

Danach enthält der Delegate:

```text
1. FirstMethod
2. ThirdMethod
```

Ein erneuter Aufruf:

```csharp
action();
```

ergibt:

```text
Erste Methode
Dritte Methode
```

---

## Reihenfolge verändern

Es gibt keinen direkten Befehl wie:

```csharp
action.Move(...)
```

Die Reihenfolge kann verändert werden, indem Methoden entfernt und erneut hinzugefügt werden.

```csharp
action -= FirstMethod;
action += FirstMethod;
```

Dadurch wird `FirstMethod` an das Ende verschoben.

---

## Aufrufliste abfragen

Mit `GetInvocationList()` kann abgefragt werden, welche Methoden im Delegate gespeichert sind.

```csharp
Delegate[] methods = action.GetInvocationList();
```

```csharp
foreach (Delegate method in methods)
{
    Console.WriteLine(method.Method.Name);
}
```

Mögliche Ausgabe:

```text
SecondMethod
ThirdMethod
FirstMethod
```

---

## Einzelne Methoden aus der Aufrufliste ausführen

```csharp
foreach (Delegate method in action.GetInvocationList())
{
    method.DynamicInvoke();
}
```

`DynamicInvoke()` ist möglich, wird im normalen Unterrichtscode aber nur selten benötigt.

Der übliche Aufruf bleibt:

```csharp
action();
```

---

## Doppelt hinzugefügte Methode

Eine Methode kann mehrfach hinzugefügt werden:

```csharp
action += FirstMethod;
action += FirstMethod;
```

Dann wird sie auch mehrfach ausgeführt.

Um einen Eintrag zu entfernen:

```csharp
action -= FirstMethod;
```

Bei mehrfach vorhandenen Einträgen wird grundsätzlich der letzte passende Eintrag aus der Aufrufliste entfernt.

---

## Multicast Delegate mit Rückgabewert

Auch `Func` kann mehrere Methoden enthalten:

```csharp
Func<int> calculation = FirstCalculation;

calculation += SecondCalculation;
```

```csharp
int result = calculation();
```

Alle Methoden werden ausgeführt.

In `result` befindet sich jedoch nur der Rückgabewert der **zuletzt ausgeführten Methode**.

Deshalb werden Multicast Delegates hauptsächlich mit `void` beziehungsweise `Action` verwendet.

---

## Fehler in einer Methode

Wenn eine Methode im Multicast Delegate eine Exception auslöst, wird der normale Aufruf unterbrochen.

Nachfolgende Methoden werden dann nicht mehr ausgeführt, außer der Fehler wird entsprechend behandelt.

```csharp
action();
```

Die Methoden laufen also nicht automatisch unabhängig voneinander.

---

# 9. Wann eigener Delegate, `Action` oder `Func`?

## `Action`

Für Methoden ohne Rückgabewert:

```csharp
Action
Action<string>
Action<string, int>
```

---

## `Func`

Für Methoden mit Rückgabewert:

```csharp
Func<int>
Func<string, bool>
Func<int, int, int>
```

Der letzte Datentyp ist immer der Rückgabewert.

---

## Eigener Delegate

Ein eigener Delegate ist sinnvoll, wenn ein sprechender Name wichtig ist:

```csharp
public delegate void DamageHandler(int damage);
```

Der Name `DamageHandler` zeigt direkt, wofür der Delegate gedacht ist.

Mit `Action` wäre dieselbe Signatur:

```csharp
Action<int>
```

Diese Schreibweise ist kürzer, beschreibt den Zweck aber weniger genau.

---

# 10. Kurzüberblick

```csharp
Action action;
```

Methode ohne Parameter und ohne Rückgabewert.

```csharp
Action<string> action;
```

Methode mit einem `string`-Parameter und ohne Rückgabewert.

```csharp
Func<int> function;
```

Methode ohne Parameter mit Rückgabewert `int`.

```csharp
Func<string, int> function;
```

Methode mit `string`-Parameter und Rückgabewert `int`.

```csharp
Func<int, int, bool> function;
```

Methode mit zwei `int`-Parametern und Rückgabewert `bool`.

---

# Merksätze

> Ein Delegate ist ein Datentyp für Methoden.

> Ein Delegate kann eine Methode speichern und später ausführen.

> Die Methodensignatur muss zum Delegate passen, sonst entsteht ein Compilerfehler.

> `Action` wird für Methoden ohne Rückgabewert verwendet.

> `Func` wird für Methoden mit Rückgabewert verwendet.

> Beim `Func` ist der letzte Datentyp immer der Rückgabewert.

> Ein Multicast Delegate führt mehrere Methoden in der Reihenfolge ihrer Anmeldung aus.
