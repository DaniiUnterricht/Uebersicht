[C# Startseite](../CSharp.md)
# Grundlagen

### C# ist eine Objektorentierte Sprache, über dies Sprechen wir später noch im Detail.

### Womit kann ich Programmieren?
Theoretisch mit jedem Editor ( Notepad++, Windows Texteditor, usw. ) aber hierbei Fehlt dann der compiler.

#### Was ist ein compiler?
Er dient dazu, den geschriebenen Code in 1 und 0 umzuwandeln und somit den Code ausführen zu können, die handesüblichen ( Visual Studio, Visual Studio Code ) haben auch eine Fehlerüberprüfung und die Möglichkeit den Code in einem Konsolenfenster auszuführen.

### Visual Studio benötigt ein Projekt
Diese hat Informationen:
```csharp
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```
Was diese machen, werden wir im späteren Verlauf durchgehen.

#### Program.cs

Diese Datei ist der Start, wie dieser Normalerweise aufgebaut wird, gehen wir im Kapitel "Methoden" dann noch einmal durch.

**Wichtig**: Wir schreiben in die erste Zeile: "using System", durch die können wir die System Befehle von C# verwenden: statt System.Console.WriteLine(); -> Console.WriteLine();

Außerdem schreiben wir hinter jedem abgeschlossenen Befehl ein ";"

### Console.WriteLine();

Wir unterscheiden zwischen Write und WriteLine, der Unterschied: WriteLine macht einen Zeilenumbruch.

Wenn wir nur eine Variable ausgeben wollen, können wir: Console.WriteLine(myVariable); verwenden.

Bei Text können wir: Console.WriteLine("Hello World"); verwenden.

Wollen wir es zusammen verwenden, benötigen wir ein $ vor dem ersten " : Console.WriteLine($"Hallo {name}");

außerdem gibt es Formatierungen, bsp. {name,-15} um den Text Linksbündig mit 15 Zeichen zu haben.

diese werden wir aber später bei einem Beispiel, genauer erläutern.

### Console.ReadLine();

Hiermit kann der User etwas eingeben um so diesen Wert in eine Variable zu speichern:

myVariable = Console.ReadLine();

Um Falschangaben abfangen zu können, brauchen wir das Kapitel "IF Abfragen".

