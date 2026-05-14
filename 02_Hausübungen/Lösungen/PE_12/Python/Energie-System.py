import random

print("Energie-System")
print("==============")
print()

# Der Spieler startet mit 20 Energie.
energie = 20

# Diese Variable zählt,
# wie viele Runden der Spieler durchgehalten hat.
runden = 0

# Die while-Schleife läuft so lange,
# wie der Spieler noch mehr als 0 Energie hat.
while energie > 0:
    # Jede Schleifenrunde zählt als eine neue Runde.
    runden += 1

    # Der Verbrauch wird zufällig zwischen 1 und 5 bestimmt.
    verbrauch = random.randint(1, 5)

    # Der Verbrauch wird von der Energie abgezogen.
    energie -= verbrauch

    # Wenn mehr Energie verbraucht wurde als noch vorhanden war,
    # könnte energie negativ werden.
    #
    # Für die Ausgabe setzen wir energie dann auf 0.
    if energie < 0:
        energie = 0

    print(f"Runde {runden}: Es wurden {verbrauch} Energie verbraucht. {energie} Energie verbleibend.")

print()
print(f"Der Spieler hat insgesamt {runden} Runden durchgehalten!")