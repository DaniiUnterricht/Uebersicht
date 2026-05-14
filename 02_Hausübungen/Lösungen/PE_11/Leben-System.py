import random

print("Leben-System")
print("============")
print()

# Der Spieler startet mit zufälligen Leben zwischen 10 und 20.
# randint(10, 20) bedeutet:
# 10 ist möglich
# 20 ist auch möglich
leben = random.randint(10, 20)

# Diese Variable zählt, wie viele Runden der Spieler überlebt.
runden = 0

# Die while-Schleife läuft so lange,
# wie der Spieler noch mehr als 0 Leben hat.
while leben > 0:
    # Der Gegner verursacht zufällig 0 bis 3 Schaden.
    schaden = random.randint(0, 3)

    # Der Schaden wird von den Leben abgezogen.
    leben -= schaden

    # Falls der Schaden höher ist als die restlichen Leben,
    # könnte leben negativ werden.
    # Für die Ausgabe setzen wir leben dann auf 0.
    if leben < 0:
        leben = 0

    # Jede Schleifenrunde zählt als überlebte Runde.
    runden += 1

    print(f"Der Gegner greift mit {schaden} Schaden an! {leben} Leben verbleibend.")

print()
print(f"Der Spieler hat insgesamt {runden} Runden überlebt!")
