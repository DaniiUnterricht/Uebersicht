print("Shop-System")
print("===========")
print()

gold = 100

# Die while-Schleife läuft so lange,
# bis der Spieler den Shop mit 0 verlässt.
while True:
    print(f"Gold: {gold}")
    print()
    print("1: Schwert (50 Gold)")
    print("2: Schild (30 Gold)")
    print("3: Heiltrank (10 Gold)")
    print("0: Verlassen")
    print()

    wahl = input("Auswahl: ")

    print()

    # Mit 0 wird die Schleife beendet.
    if wahl == "0":
        print("Shop verlassen.")
        break

    # Je nach Auswahl werden Itemname und Preis gesetzt.
    if wahl == "1":
        item = "Schwert"
        preis = 50
    elif wahl == "2":
        item = "Schild"
        preis = 30
    elif wahl == "3":
        item = "Heiltrank"
        preis = 10
    else:
        print("> Error: Ungültige Auswahl!")
        print()
        continue

    # Hier prüfen wir, ob genug Gold vorhanden ist.
    if gold < preis:
        print("> Error: Nicht genug Gold!")
    else:
        gold -= preis
        print(f"Du hast ein {item} gekauft!")
        print(f"Gold verbleibend: {gold}")

    print()