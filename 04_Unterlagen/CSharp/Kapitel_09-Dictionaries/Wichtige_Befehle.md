<!-- LINKBAR:START -->
[Hauptübersicht](../../../README.md) | [Praxiseinheiten](../../../01_Praxiseinheiten/PE.md) | [Hausübungen](../../../02_Hausübungen/Hausübungen.md) | [Quizes](../../../03_Quizes/Quizes.md) | [C# Unterlagen](../CSharp.md) | [Python Unterlagen](../../Python/Python.md) | [Syppre Unterlagen](../../Syppre/Syppre.md)
<!-- LINKBAR:END -->

# Dictionaries – Wichtige Befehle

## Überblick

Dictionaries besitzen fertige Befehle, mit denen man Einträge hinzufügen, ändern, suchen oder entfernen kann.

Die wichtigsten Befehle sind für den Einstieg völlig ausreichend.

---

## `Add()` – Eintrag hinzufügen

Mit `Add()` wird ein neues Schlüssel-Wert-Paar hinzugefügt.

```csharp
Dictionary<string, int> punkte = new Dictionary<string, int>();

punkte.Add("Max", 100);
punkte.Add("Anna", 80);
```

Wichtig:

👉 Der Schlüssel darf noch nicht existieren.

---

## Zugriff über `[]`

Mit eckigen Klammern kann man einen Wert über den Schlüssel auslesen.

```csharp
Console.WriteLine(punkte["Max"]);
```

Man kann damit auch Werte ändern.

```csharp
punkte["Max"] = 150;
```

---

## Eintrag über `[]` hinzufügen oder ändern

Wenn der Schlüssel noch nicht existiert, wird er neu angelegt.

```csharp
punkte["Lena"] = 50;
```

Wenn der Schlüssel bereits existiert, wird der Wert geändert.

```csharp
punkte["Lena"] = 70;
```

👉 Diese Schreibweise ist praktisch, aber man sollte wissen, ob man gerade hinzufügen oder überschreiben möchte.

---

## `ContainsKey()` – prüfen, ob ein Schlüssel existiert

Mit `ContainsKey()` prüft man, ob ein bestimmter Schlüssel vorhanden ist.

```csharp
if (punkte.ContainsKey("Max"))
{
    Console.WriteLine(punkte["Max"]);
}
```

Das ist wichtig, weil ein Zugriff auf einen nicht vorhandenen Schlüssel einen Fehler verursacht.

---

## `ContainsValue()` – prüfen, ob ein Wert existiert

Mit `ContainsValue()` kann geprüft werden, ob ein bestimmter Wert vorkommt.

```csharp
if (punkte.ContainsValue(100))
{
    Console.WriteLine("Es gibt einen Spieler mit 100 Punkten.");
}
```

👉 In der Praxis verwendet man meistens häufiger `ContainsKey()`.

---

## `Remove()` – Eintrag entfernen

Mit `Remove()` wird ein Eintrag über den Schlüssel entfernt.

```csharp
punkte.Remove("Anna");
```

Danach existiert der Eintrag mit dem Schlüssel `"Anna"` nicht mehr.

---

## `Count` – Anzahl der Einträge

`Count` gibt an, wie viele Schlüssel-Wert-Paare im Dictionary gespeichert sind.

```csharp
Console.WriteLine(punkte.Count);
```

---

## `Clear()` – Dictionary leeren

Mit `Clear()` werden alle Einträge entfernt.

```csharp
punkte.Clear();
```

Danach ist das Dictionary leer.

---

## Übersicht der wichtigsten Befehle

| Befehl | Bedeutung |
|-------|----------|
| `Add(key, value)` | fügt einen neuen Eintrag hinzu |
| `dictionary[key]` | liest einen Wert aus |
| `dictionary[key] = value` | fügt hinzu oder ändert einen Wert |
| `ContainsKey(key)` | prüft, ob ein Schlüssel existiert |
| `ContainsValue(value)` | prüft, ob ein Wert existiert |
| `Remove(key)` | entfernt einen Eintrag über den Schlüssel |
| `Count` | Anzahl der Einträge |
| `Clear()` | entfernt alle Einträge |

---

## Zusammenfassung

Die wichtigsten Dictionary-Befehle sind:

- `Add()` zum Hinzufügen
- `[]` zum Auslesen und Ändern
- `ContainsKey()` zum sicheren Prüfen
- `Remove()` zum Löschen
- `Count` zum Zählen
- `Clear()` zum Leeren
