# Kinokarte prüfen

## Aufgabenstellung
Schreibe ein Python-Programm für eine einfache Kinokontrolle.

Das Programm soll folgende Daten abfragen:

- den Namen der Person
- das Alter der Person
- ob die Person eine Kinokarte hat

Die Antwort für die Kinokarte soll mit ``ja`` oder ``nein`` eingegeben werden.

### Regeln
Eine Person darf ins Kino, wenn:

- sie mindestens 16 Jahre alt ist
und
- eine Kinokarte hat

### Sonderregel
Wenn der Name „Chef“ ist, darf die Person immer hinein, egal wie alt sie ist und ob sie eine Karte hat.

## Ausgabe
Das Programm soll zuerst den Benutzer begrüßen.

Danach soll eine passende Meldung ausgegeben werden:

- „Eintritt erlaubt“
- „Eintritt nicht erlaubt“

Bsp 1.
```
Name: Lisa
Alter: 17
Kinokarte vorhanden (ja/nein): ja

Hallo Lisa
Eintritt erlaubt
```

Bsp 2.
```
Name: Tom
Alter: 15
Kinokarte vorhanden (ja/nein): ja

Hallo Tom
Eintritt nicht erlaubt
```

Bsp 3.+
```
Name: Chef
Alter: 10
Kinokarte vorhanden (ja/nein): nein

Hallo Chef
Eintritt erlaubt
```

## Hinweise
- Das Alter muss in eine Zahl umgewandelt werden
- Die Eingabe ja oder nein bleibt Text
- Achte darauf, dass du die Bedingungen richtig kombinierst