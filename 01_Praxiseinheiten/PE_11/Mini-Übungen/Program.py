# Übung 01
## Machen Sie eine Abfrage, welche eine Zahl abfragt und bei falscher Eingabe wiederholt
while True:
    try:
        inp = int(input("Bitte geben Sie eine Zahl ein: "))
    except:
        print("Ungültige Eingabe.")
    else:
        break

print()
# Übung 02
## Summieren Sie solange die Zahlen, bis 0 eingegeben wird
sum = 0
while True:
    try:
        inp = int(input("Bitte geben Sie eine Zahl ein: "))
    except:
        print("Ungültige Eingabe.")
    else:
        if inp != 0:
            sum += inp
        else:
            break
print(sum)

print()
# Übung 03
## Erstellen Sie eine einfache Multiplikationstabelle

for i in range(1, 5):
    for j in range(1, 5):
        print(f"{i} x {j} = {i * j}")
    print()