print("Kinokarte prüfen")
print("================")
print()

name = input("Name: ")
alter = int(input("Alter: "))
kinokarte = input("Kinokarte vorhanden (ja/nein): ")

print()
print(f"Hallo {name}")

# Sonderregel:
# Wenn der Name "Chef" ist, darf die Person immer hinein.
# Deshalb prüfen wir diesen Fall zuerst.
#
# Danach prüfen wir die normale Regel:
# Die Person muss mindestens 16 Jahre alt sein
# und eine Kinokarte haben.
if name == "Chef":
    print("Eintritt erlaubt")
elif alter >= 16 and kinokarte == "ja":
    print("Eintritt erlaubt")
else:
    print("Eintritt nicht erlaubt")