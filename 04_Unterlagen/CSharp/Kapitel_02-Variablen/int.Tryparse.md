[C# Startseite](../CSharp.md)
# Int.TryParse

## Definition
`int.TryParse` wird verwendet, um zu prüfen, ob eine Eingabe **in eine ganze Zahl (int)** umgewandelt werden kann.

Im Gegensatz zu `Convert.ToInt32()` oder `int.Parse()` führt `TryParse` **nicht zu einem Programmfehler**, wenn die Eingabe ungültig ist.

Stattdessen gibt die Methode einen **booleschen Wert** zurück:

- `true` → Umwandlung erfolgreich  
- `false` → Eingabe ist keine gültige Zahl  

---

## Grundstruktur

```csharp
int.TryParse(Text, out variable);
```

### Bestandteile

| Element | Bedeutung |
|--------|-----------|
| `Text` | die Eingabe (z. B. von `Console.ReadLine()`) |
| `out variable` | hier wird das Ergebnis gespeichert |
| Rückgabewert | `true` oder `false` |

---

## Einfaches Beispiel

```csharp
int zahl;
bool gültig = int.TryParse(Console.ReadLine(), out zahl);

if (gültig)
{
    Console.WriteLine("Die Zahl ist: " + zahl);
}
else
{
    Console.WriteLine("Ungültige Eingabe");
}
```

Wenn der Benutzer eine **Zahl eingibt**, wird sie gespeichert.  
Wenn **keine Zahl** eingegeben wird, bleibt das Programm trotzdem stabil.

---

## Vergleich: Parse vs TryParse

### Parse (unsicher)

```csharp
int zahl = int.Parse(Console.ReadLine());
```

Problem:

Wenn der Benutzer `"abc"` eingibt → **Programmfehler**

---

### TryParse (sicher)

```csharp
int zahl;

if (int.TryParse(Console.ReadLine(), out zahl))
{
    Console.WriteLine("Gültige Zahl");
}
```

Hier wird zuerst geprüft, ob die Eingabe eine Zahl ist.

---

## Wann ist TryParse sinnvoll?

`TryParse` wird besonders verwendet bei:

- Benutzereingaben
- Menüsystemen
- Eingabeprüfungen
- Programmen ohne Abstürze