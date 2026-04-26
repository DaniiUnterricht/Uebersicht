[C# Startseite](../CSharp.md)
# Was sind Variablen in C#?

## Variablen sind dazu da, um Werte speichern zu können.

### Man Unterscheitet zwischen Konstanten und Veränderbaren. ( Später wird es noch eine Weitere Unterscheidung geben, welche für den Anfang nicht Relevant ist )
- Konstante: werden mit 'const' definiert und sind nach der deklaration nicht mehr Veränderbar.
- Die Veränderbaren kann man jederzeit Verändern, der Typ bleibt aber gleich und ist Unveränderbar.

## Variablentypen

### Ganzzahlen
- sbyte - 8 Bit ( -123 bis 127 )
- byte - 8 Bit ( 0 bis 255 )
- short - 16 Bit ( -32 768 bis 32 767 )
- ushort - 16 Bit ( 0 bis 65 535 )
- **int** - 32 Bit ( +/- 2 Milliarden )
- uint - 32 Bit ( 0 bis ~ 4 Milliarden )
- long - 64 Bit ( Sehr große Zahlen )
- ulong - 64 Bit ( Nur positive große Zahlen )

Bsp.:
```csharp
int zahl1;
int zahl2;
int gesamt;

zahl1 = 5;
zahl2 = 10;

//Hierbei kann man dann mit allen Operatoren ( + , - , * , / ) rechnen:
gesamt = zahl1 + zahl2;

Console.WriteLine(gesamt); //Ausgabe: 15
```

#### Gleitkommazahlen
- float - 7 Stellen
- double - 15/16 Stellen
- decimal - Sehr genau bsp. für Finanzen.

### Zeichen und Wahrheitswert
- char -> Ein einzelnes Zeichen ( 'A' )
- bool -> True/False
- string -> Zeichenkette

Bsp.:
```csharp
using System;

string myText1 = "Hello";
string myText2 = "World";
string gesamt;

//Man kann Texte aneiander hängen mit einem +
gesamt = myText1 + " " + myText2;

Console.WriteLine(gesamt); //Ausgabe: Hello World

// In Theorie wäre es möglich mit string zu Rechnen:
int zahl1 = 5;
string zahl2 = "10";
int gesamt = zahl1 + zahl2; // Ergebnis 15, aber sollte man nicht machen!
```

### Arrays

Bei Arrays kann man mehrere Werte in einer Variable ( Array ) speichern, der DatenTyp wird bei der Deklaration angegeben -> int[]
Die Aufzählung fängt hierbei bei 0 an.
Bsp.:

```csharp
//Beim Array muss die Länge deklariert werden.
 int[] myArray = new int[3];
//Man könnte auch zu Anfang die Werte definieren.
int[] myArray2 = {10,20,30};

//Würde man jetzt einen größeren Array benötigen könnte man Theoretisch:
myArray2 = new int[4];
//machen, hierbei würden aber alle Werte gelöscht werden.

//Die stellen werden ab 0 abgefragt/definiert:
 myArray[0] = 10;
 myArray[1] = 5;
 myArray[2] = 6;

 Console.WriteLine($"{myArray[0]} , {myArray[1]} , {myArray[2]}");
 // Ergebnis der WriteLine: 10 , 5 , 6
```
