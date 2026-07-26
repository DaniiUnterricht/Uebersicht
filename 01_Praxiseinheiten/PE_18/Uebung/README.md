# PE18 Miniübung – Dateiverarbeitung mit CSV und JSON

## Ziel

Ein neuer Spielstand wird über die Konsole eingegeben. Anschließend werden alle Spielstände über einen eigenen Service:

- als CSV-Datei gespeichert,
- aus der CSV-Datei gelesen und ausgegeben,
- als JSON-Datei gespeichert.

## Projektstruktur

```text
PE18_Miniuebung_Dateiverarbeitung
├── Program.cs
├── Classes
│   └── Spielstand.cs
├── Services
│   └── SpielstandService.cs
└── PE18_Miniuebung_Dateiverarbeitung.csproj
```

## Aufgabe

Bearbeite die sechs Stellen mit einem `TODO`-Kommentar.

Die Aufgaben stehen direkt an der jeweiligen Codezeile. Ein großer Teil des Programms ist bereits vorgegeben.

## Warum ein Service?

`Program.cs` ist für den Programmablauf und die Eingabe zuständig.

`SpielstandService.cs` übernimmt die Dateiverarbeitung. Dadurch kann der Code später leichter wiederverwendet, erweitert und getestet werden.

## Erstellte Dateien

Beim Ausführen werden im Ausgabeordner erstellt:

- `spielstaende.csv`
- `spielstaende.json`

## Projekt starten

```bash
dotnet run
```
