print("Inventar-System")
print("===============")
print()

# Die Anzahl der Items wird so lange abgefragt,
# bis eine gültige Zahl größer als 0 eingegeben wurde.
while True:
    try:
        anzahl = int(input("Wie viele Items wurden gesammelt: "))

        if anzahl <= 0:
            print("> Error: Die Zahl muss größer als 0 sein.")
        else:
            break

    except:
        print("> Error: Ungültige Eingabe!")

print()

gesamtwert = 0

# Die for-Schleife wird verwendet,
# weil vorher bekannt ist, wie viele Items abgefragt werden sollen.
for i in range(anzahl):
    name = input(f"Name von Item {i + 1}: ")

    # Der Wert des aktuellen Items wird so lange abgefragt,
    # bis eine gültige Zahl größer als 0 eingegeben wurde.
    while True:
        try:
            wert = int(input(f"Wert von {name} in Gold: "))

            if wert <= 0:
                print("> Error: Die Zahl muss größer als 0 sein.")
            else:
                break

        except:
            print("> Error: Ungültige Eingabe!")

    # Der Wert des Items wird zum Gesamtwert addiert.
    gesamtwert += wert

    print()

print(f"Der Gesamtwert des Inventars beträgt: {gesamtwert} Gold")