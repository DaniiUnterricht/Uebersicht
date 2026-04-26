# Farm-System 🎮

## 🎯 Lernziel

* Arbeiten mit der `while`-Schleife zur Eingabevalidierung
* Überprüfen von Benutzereingaben
* Rechnen mit Variablen
* Kombination von Logik und Benutzereingabe

---

## 📝 Angabe

* Der Spieler gibt die **Größe des Feldes** an
  (z. B. 5 → ergibt ein Feld mit 5 × 5)

* Der Spieler gibt das **Produkt** an
  (z. B. Mais, Kartoffel, Weizen)

* Der Spieler gibt den **Ertrag pro Feld** an

* Das Programm berechnet den **Gesamtertrag**

* **Falsche Eingaben sollen abgefangen und wiederholt werden**:

  * keine Zahl → Fehlermeldung
  * negative Zahl oder 0 → Fehlermeldung

---

## 💻 Ausgabe

```
Farm-System
============

Wie groß ist das Feld: 6

Welches Produkt soll geerntet werden: Kartoffel

Was ist der Ertrag pro Feld: 5

Der Gesamtertrag beträgt: 180
```

```
Farm-System
============

Wie groß ist das Feld: a
> Error: Ungültige Eingabe!
Wie groß ist das Feld: 5

Welches Produkt soll geerntet werden: Kartoffel

Was ist der Ertrag pro Feld: -5
> Error: Die Zahl muss größer als 0 sein.
Was ist der Ertrag pro Feld: 5

Der Gesamtertrag beträgt: 125
```

---

## 💡 Tipps

* Verwenden Sie eine `while`-Schleife, um Eingaben so lange zu wiederholen, bis sie korrekt sind.

---

### 🔹 Eingabe überprüfen (Zahl)

```python
try:
    wert = int(input("Eingabe: "))
except:
    print("Error: Ungültige Eingabe!")
```

👉 Falls keine Zahl eingegeben wird, wird ein Fehler abgefangen.

---

### 🔹 Positive Zahl prüfen

```python
if wert <= 0:
    print("Error: Die Zahl muss größer als 0 sein.")
```

---

### 🔹 Schleife für gültige Eingabe

```python
while True:
    try:
        feld = int(input("Wie groß ist das Feld: "))
        
        if feld <= 0:
            print("Error: Die Zahl muss größer als 0 sein.")
        else:
            break
    except:
        print("Error: Ungültige Eingabe!")
```

---

### 🔹 Berechnung des Gesamtertrags

```python
gesamt = feld * feld * ertrag
```

👉 Feld ist quadratisch:
➡️ Fläche = feld × feld

---

## 🧠 Hinweis

* Achten Sie auf saubere Einrückung
* Verwenden Sie sprechende Variablennamen
* Testen Sie Ihr Programm mit falschen Eingaben
