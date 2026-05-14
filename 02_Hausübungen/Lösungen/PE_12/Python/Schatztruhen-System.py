print("Schatztruhen-System")
print("===================")
print()

# Die Anzahl der Schatztruhen wird so lange abgefragt,
# bis eine gültige Zahl größer als 0 eingegeben wurde.
while True:
    try:
        anzahl = int(input("Wie viele Schatztruhen sollen geöffnet werden: "))

        if anzahl <= 0:
            print("> Error: Die Zahl muss größer als 0 sein.")
        else:
            break

    except:
        print("> Error: Ungültige Eingabe!")

print()

gesamtwert = 0

# Die for-Schleife wird verwendet,
# weil vorher bekannt ist, wie viele Truhen abgefragt werden sollen.
for i in range(anzahl):
    name = input(f"Name von Truhe {i + 1}: ")

    # Der Goldwert der aktuellen Truhe wird so lange abgefragt,
    # bis eine gültige Zahl größer als 0 eingegeben wurde.
    while True:
        try:
            goldwert = int(input(f"Goldwert von {name}: "))

            if goldwert <= 0:
                print("> Error: Die Zahl muss größer als 0 sein.")
            else:
                break

        except:
            print("> Error: Ungültige Eingabe!")

    # Der Goldwert der aktuellen Truhe
    # wird zum Gesamtwert addiert.
    gesamtwert += goldwert

    print()

print(f"Der Gesamtwert aller Schatztruhen beträgt: {gesamtwert} Gold")