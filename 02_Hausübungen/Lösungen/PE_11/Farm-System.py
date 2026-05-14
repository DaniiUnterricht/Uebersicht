print("Farm-System")
print("===========")
print()

# Die Feldgröße wird so lange abgefragt,
# bis eine gültige Zahl größer als 0 eingegeben wurde.
while True:
    try:
        feld = int(input("Wie groß ist das Feld: "))

        if feld <= 0:
            print("> Error: Die Zahl muss größer als 0 sein.")
        else:
            break

    except:
        print("> Error: Ungültige Eingabe!")

print()

produkt = input("Welches Produkt soll geerntet werden: ")

print()

# Der Ertrag pro Feld wird ebenfalls so lange abgefragt,
# bis eine gültige Zahl größer als 0 eingegeben wurde.
while True:
    try:
        ertrag = int(input("Was ist der Ertrag pro Feld: "))

        if ertrag <= 0:
            print("> Error: Die Zahl muss größer als 0 sein.")
        else:
            break

    except:
        print("> Error: Ungültige Eingabe!")

print()

# Das Feld ist quadratisch.
# Deshalb wird die Fläche mit feld * feld berechnet.
#
# Danach wird die Fläche mit dem Ertrag pro Feld multipliziert.
gesamt = feld * feld * ertrag

print(f"Der Gesamtertrag beträgt: {gesamt}")