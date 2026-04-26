[C# Startseite](../CSharp.md)

# Aufbau CS Dateien

## Einführung
Mit zunehmender Größe eines Programms wird es notwendig, den Code klar zu strukturieren. 
Eine saubere Struktur erleichtert das Verständnis, die Wartung und die Erweiterung eines Projekts.

### Grundidee
Ein C#-Projekt besteht aus mehreren logisch getrennten Bestandteilen:

- Namespace
- Klassen
- Methoden
- Code

### Grundaufbau

```csharp
namespace MeinProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Welt");
        }
    }
}
```

### Überblick

| Ebene     | Beschreibung                          |
|-----------|--------------------------------------|
| Namespace | organisiert und gruppiert Code       |
| Klasse    | enthält Daten und Methoden           |
| Methode   | enthält ausführbaren Code            |
| Code      | konkrete Anweisungen                 |

### Merksatz
Namespace → Klasse → Methode → Code

## Namespaces

### Definition
Ein Namespace dient zur Organisation von Code. Er gruppiert zusammengehörige Klassen.

```csharp
namespace MeinProjekt
```

### Zweck

- Strukturierung des Projekts
- Vermeidung von Namenskonflikten
- bessere Übersicht bei größeren Anwendungen

### Funktionsweise
Ein Namespace enthält Klassen:

```csharp
namespace MeinProjekt
{
    class Program
    {
    }
}
```

### Vergleich
Ein Namespace kann mit einem Ordner im Dateisystem verglichen werden.

## Klassen und Grundstruktur

### Definition
Eine Klasse ist ein zentraler Bestandteil eines C#-Programms.

Sie dient als Container für Daten und Methoden und beschreibt, was ein Objekt kann und enthält.

```csharp
class Program
{
}
```

### Eigenschaften

- In C# muss sich ausführbarer Code innerhalb einer Klasse befinden
- Eine Klasse bündelt zusammengehörige Funktionalitäten
- In der Praxis befindet sich meist eine Klasse pro Datei

### Beispiel einer Klasse

```csharp
class Program
{
    static void Main(string[] args)
    {
        Begruessung("Dani");
        int zahl = Summe(5,2);
        Console.WriteLine(zahl);
    }

    static void Begruessung(string name)
    {
        Console.WriteLine($"Hallo {name} :3");
    }

    static int Summe(int zahl1, int zahl2)
    {
        return zahl1 + zahl2;
    }
}
```

### Einordnung in die Struktur

Eine Klasse befindet sich innerhalb eines Namespaces und enthält Methoden, in denen Code ausgeführt wird.

## Startpunkt und Methoden

### Startpunkt eines Programms

Der Einstiegspunkt eines C#-Programms ist die Main-Methode.

```csharp
static void Main(string[] args)
{
    Console.WriteLine("Start");
}
```

### Bedeutung der Bestandteile

- static → Methode gehört zur Klasse und kann ohne Objekt verwendet werden
- ohne static → Methode gehört zu einem Objekt und benötigt eine Instanz
- void → kein Rückgabewert
- Main → Startpunkt des Programms
- string[] args → ist ein Array von Texten, das die Argumente enthält, die beim Start des Programms übergeben werden.

### Methoden allgemein

Methoden enthalten ausführbaren Code und definieren das Verhalten eines Programms.

```csharp
void Begruessung()
{
    Console.WriteLine("Hallo");
}
```

### Ablauf

Beim Start eines Programms wird automatisch die Main-Methode ausgeführt.
