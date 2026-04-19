fehler = False

try:
    input1 = int(input("Zahl: "))
except ValueError:
    print("Bitte um eingabe einer Zahl")
    fehler = True

if not fehler:
    print(input1 , "Ist ne schöne Zahl")

# Aufgabe 2 - Taschenrechner

fehler = False

try:
    num1 = int(input("Zahl 1: "))
    num2 = int(input("Zahl 2: "))
    operator = input("Operator (+,-,*,/): ")
except ValueError:
    print("Bitte um eingabe einer Zahl.")
    fehler = True

if not fehler:
    if operator == "+":
        print(num1 + num2)
    elif operator == "-":
        print(num1 - num2)
    elif operator == "*":
        print(num1 * num2)
    elif operator == "/":
        try:
            print(num1 / num2)
        except ZeroDivisionError:
            print("Division by zero")
    else:
        print("Operator nicht gefunden")
