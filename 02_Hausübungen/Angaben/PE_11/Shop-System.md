# Shop-System 🛒

## 🎯 Lernziel

* Arbeiten mit `while`-Schleifen
* Menüsteuerung umsetzen
* Entscheidungen mit `if` treffen
* Werte verändern (Gold verwalten)

---

## 📝 Angabe

* Der Spieler startet mit **100 Gold**.

* Es gibt folgende Items im Shop:

  * Schwert → 50 Gold
  * Schild → 30 Gold
  * Heiltrank → 10 Gold

* Der Spieler kann:

  * Items kaufen
  * den Shop verlassen

* Nach jedem Kauf:

  * wird das Gold reduziert
  * wird der neue Goldstand angezeigt

* Falls nicht genug Gold vorhanden ist:

  * Fehlermeldung ausgeben

* Das Programm läuft so lange, bis der Spieler den Shop verlässt.

---

## 💻 Ausgabe

```text
Shop-System
===========

Gold: 100

1: Schwert (50 Gold)
2: Schild (30 Gold)
3: Heiltrank (10 Gold)
0: Verlassen

Auswahl: 1
Du hast ein Schwert gekauft!
Gold verbleibend: 50

Auswahl: 2
Du hast ein Schild gekauft!
Gold verbleibend: 20

Auswahl: 1
> Error: Nicht genug Gold!

Auswahl: 0
Shop verlassen.
```

---

## 💡 Tipps

* Verwenden Sie eine `while`-Schleife für das Menü:

```python
while True:
    # Menü anzeigen
```

---

* Verwenden Sie `input()` für die Auswahl:

```python
wahl = input("Auswahl: ")
```

---

* Verwenden Sie `if` zur Auswertung:

```python
if wahl == "1":
    # kaufen
```

---

* Gold reduzieren:

```python
gold -= 50
```

---

* Prüfen, ob genug Gold vorhanden ist:

```python
if gold < preis:
    print("> Error: Nicht genug Gold!")
```

---

* Schleife beenden:

```python
if wahl == "0":
    break
```
