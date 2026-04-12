# Übung 01
# Schreiben Sie eine Visitenkarte ( Abfrage: Name, Alter, Wohnort ; Ausgabe alle 3 Untereinander )
name = input("Name: ")
alter = int(input("Alter: "))
wohnort = input("Wohnort: ")

print("Name:", name, "Alter:", alter, "Wohnort:", wohnort)
print()
print("Name: ", name)
print("Alter:", alter)
print("Wohnort:", wohnort)


# Übung 02
# Schreiben Sie einen kleinen Taschenrechner, der + ; - ; * ; / kann.

value1 = int(input("Value1: "))
value2 = int(input("Value2: "))
art = input("Rechenart ( + , - , * , / ): ")

if art == "+":
    print(value1 + value2)
elif art == "-":
    print(value1 - value2)
elif art == "*":
    print(value1 * value2)
elif art == "/":
    if value2 == 0:
        print("Rechnen durch 0 nicht möglich")
    else:
        print(value1 / value2)
else:
    print("Rechenart nicht gefunden")