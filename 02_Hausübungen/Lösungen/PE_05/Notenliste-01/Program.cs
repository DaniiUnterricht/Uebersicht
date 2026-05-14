using System;

Console.WriteLine("Notenliste");
Console.WriteLine("==========");
Console.WriteLine();

// Hier erstellen wir ein int-Array mit 5 Speicherplätzen.
// In diesem Array werden später die 5 Noten gespeichert.
//
// Wichtig:
// Ein Array hat eine feste Größe.
// Diese Größe wird hier mit [5] festgelegt.
int[] noten = new int[5];

// Mit dieser for-Schleife lesen wir die 5 Noten ein.
//
// i startet bei 0.
// Die Schleife läuft so lange, wie i kleiner als noten.Length ist.
// noten.Length gibt die Länge des Arrays zurück.
//
// Bei einem Array mit 5 Elementen sind die gültigen Indizes:
// 0, 1, 2, 3, 4
for (int i = 0; i < noten.Length; i++)
{
    Console.Write($"Note {i + 1} eingeben: ");
    bool isTrue = int.TryParse(Console.ReadLine(), out noten[i]);

    // Wenn die Eingabe keine gültige Ganzzahl war,
    // wird eine Fehlermeldung ausgegeben.
    //
    // Mit i-- sorgen wir dafür,
    // dass derselbe Speicherplatz erneut abgefragt wird.
    if (isTrue == false)
    {
        Console.WriteLine("Ungültige Eingabe! Bitte geben Sie eine ganze Zahl ein.");
        i--;
    }
}

Console.WriteLine();
Console.WriteLine("Noten:");

int summe = 0;

// Die beste und schlechteste Note setzen wir zuerst
// auf die erste eingegebene Note.
//
// Dadurch haben wir einen sinnvollen Startwert,
// mit dem die restlichen Noten verglichen werden können.
int besteNote = noten[0];
int schlechtesteNote = noten[0];

// Mit dieser for-Schleife gehen wir alle gespeicherten Noten durch.
// Dabei geben wir jede Note aus, addieren sie zur Summe
// und prüfen gleichzeitig, ob sie besser oder schlechter ist.
for (int i = 0; i < noten.Length; i++)
{
    Console.WriteLine(noten[i]);

    summe = summe + noten[i];

    // Bei Schulnoten ist die kleinere Zahl die bessere Note.
    // Deshalb ist 1 besser als 2, 3, 4 oder 5.
    if (noten[i] < besteNote)
    {
        besteNote = noten[i];
    }

    // Die schlechteste Note ist die größte Zahl.
    if (noten[i] > schlechtesteNote)
    {
        schlechtesteNote = noten[i];
    }
}

// Für den Durchschnitt verwenden wir double,
// damit auch Kommazahlen möglich sind.
//
// Der Cast auf double ist wichtig,
// weil summe und noten.Length beide int-Werte sind.
// Ohne Cast würde C# eine Ganzzahldivision durchführen.
double durchschnitt = (double)summe / noten.Length;

Console.WriteLine();
Console.WriteLine($"Durchschnitt: {durchschnitt:F1}");
Console.WriteLine($"Beste Note: {besteNote}");
Console.WriteLine($"Schlechteste Note: {schlechtesteNote}");