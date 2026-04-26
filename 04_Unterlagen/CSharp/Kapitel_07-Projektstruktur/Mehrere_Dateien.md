[C# Startseite](../CSharp.md)

# Arbeiten mit mehreren Dateien und Namespaces

## Einführung

Mit wachsender Größe eines Programms wird es schnell unübersichtlich, wenn sich der gesamte Code in einer einzigen Datei befindet.

Um den Code besser zu strukturieren, werden Funktionen auf mehrere Dateien aufgeteilt.

---

## Grundidee

Ein Projekt kann aus mehreren Dateien bestehen, die logisch zusammengehören.

Diese Verbindung erfolgt über den Namespace.

---

## Beispiel: Mehrere Dateien im selben Namespace

### Datei: Program.cs

```csharp
using MeinProjekt.Tools;

namespace MeinProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Tools.Begruessung();
            Tools.Verabschiedung();
        }
    }
}
```

- In der Program.cs ( Startdatei ) hat der Namespace in der Regel den Namen des Projektes.

---

### Datei: Tools.cs

```csharp
namespace MeinProjekt.Tools
{
    class Tools
    {
        public static void Begruessung()
        {
            Console.WriteLine("Hallo!");
        }

        public static void Verabschiedung()
        {
            Console.WriteLine("Tschüss!");
        }
    }
}
```

- Der Namespace entspricht in der Regel den Projektname + Ordner in der die Datei liegt.
- Der Klassenname ist in der Regel der Dateiname

---

## Erweiterung: Mehrere Dateien im gleichen Namespace

Jetzt wird es interessant:

Zwei verschiedene Dateien gehören zum gleichen Namespace.

---

### Datei: Ausgaben.cs

```csharp
namespace MeinProjekt.Tools
{
    class Ausgaben
    {
        public static void Begruessung()
        {
            Console.WriteLine("Hallo!");
        }
    }
}
```

---

### Datei: Rechner.cs

```csharp
namespace MeinProjekt.Tools
{
    class Rechner
    {
        public static int Addieren(int a, int b)
        {
            return a + b;
        }
    }
}
```

---

### Verwendung in Program.cs

```csharp
using MeinProjekt.Tools;

namespace MeinProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Ausgaben.Begruessung();

            int ergebnis = Rechner.Addieren(5, 3);
            Console.WriteLine(ergebnis);
        }
    }
}
```

---

## Was zeigt dieses Beispiel?

Beide Dateien:

- Ausgaben.cs
- Rechner.cs

gehören zum gleichen Namespace:

```csharp
namespace MeinProjekt.Tools
```

Dadurch:

- können sie gemeinsam verwendet werden
- wirken sie wie eine Einheit
- sind sie logisch gruppiert

---

## Rolle von using

```csharp
using MeinProjekt.Tools;
```

Ermöglicht den Zugriff auf alle Klassen innerhalb dieses Namespaces:

- Ausgaben
- Rechner

---

## Erkenntnis

Ein Namespace:

- verbindet mehrere Dateien logisch
- bildet eine Struktur im Code
- ist unabhängig von der tatsächlichen Datei

---

## Merksätze

- Mehrere Dateien können zum gleichen Namespace gehören  
- Namespace = logische Gruppierung von Code  
- using ermöglicht den Zugriff auf diese Gruppe  
