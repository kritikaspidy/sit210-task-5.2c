import RPi.GPIO as GPIO
import tkinter as tk

# Initialize GPIO
GPIO.setmode(GPIO.BOARD)
GPIO.setup(23, GPIO.OUT)
GPIO.setup(19, GPIO.OUT)
GPIO.setup(21, GPIO.OUT)

# Function to turn off all LEDs
def all_of():
    GPIO.output(23, GPIO.LOW)
    GPIO.output(19, GPIO.LOW)
    GPIO.output(21, GPIO.LOW)

# Function to toggle the state of an LED
def light_on(pin):
    if GPIO.input(pin) == GPIO.HIGH:
        GPIO.output(pin, GPIO.LOW)
    else:
        GPIO.output(pin, GPIO.HIGH)

# Create the main GUI window
window = tk.Tk()
window.title("Control system")
window.geometry("300x200")
window.configure(bg="black")

# Variable to hold the selected LED option
chosen = tk.IntVar()

# Function to clean up GPIO and close the GUI
def close():
    GPIO.cleanup()
    window.destroy()

# Function to control the LEDs based on user choice
def light_no():
    if chosen.get() == 1:
        light_on(23)
    elif chosen.get() == 2:
        light_on(19)
    elif chosen.get() == 3:
        light_on(21)

# Create RadioButtons to select the LED
green = tk.Radiobutton(window, text="GREEN", variable=chosen, value=1, command=light_no, bg="green")
blue = tk.Radiobutton(window, text="BLUE", variable=chosen, value=2, command=light_no, bg="blue")
red = tk.Radiobutton(window, text="RED", variable=chosen, value=3, command=light_no, bg="red")

# Button to turn off all LEDs
of = tk.Button(window, text="OFF ALL", command=all_of, bg="cyan")

# Button to exit the GUI and clean up GPIO
esc = tk.Button(window, text="EXIT", command=close, bg="brown")

# Pack the widgets (RadioButtons and Buttons) into the GUI window
red.pack()
blue.pack()
green.pack()
of.pack()
esc.pack()

# Start the GUI main loop
window.mainloop()

# Clean up GPIO when the GUI is closed
GPIO.cleanup()
