import RPi.GPIO as GPIO
import tkinter as tk

GPIO.setmode(GPIO.BOARD)
GPIO.setup(23, GPIO.OUT)
GPIO.setup(19, GPIO.OUT)
GPIO.setup(21, GPIO.OUT)

def all_of():
	GPIO.output(23,GPIO.LOW)
	GPIO.output(19,GPIO.LOW)
	GPIO.output(21,GPIO.LOW)


def light_on(pin):
	if GPIO.input(pin) == GPIO.HIGH:
		GPIO.output(pin, GPIO.LOW)
	else:
		GPIO.output(pin,GPIO.HIGH)


window = tk.Tk()
window.title("Control system")

window.geometry("300x200")
window.configure(bg = "black")

chosen = tk.IntVar()


def close():
	GPIO.cleanup()
	window.destroy()


def light_no():
	if chosen.get() == 1:
		light_on(23)
	elif chosen.get() == 2:
		light_on(19)
	elif chosen.get() == 3:
		light_on(21)
		
		
green = tk.Radiobutton(window, text = "GREEN ", variable = chosen, value = 1, command = light_no, bg = "green")
blue = tk.Radiobutton(window, text = "BLUE", variable = chosen, value = 2, command = light_no, bg = "blue")
red = tk.Radiobutton(window, text = "RED", variable = chosen, value = 3, command = light_no, bg = "red")
of = tk.Button(window, text = "OFF ALL", command = all_of, bg = "cyan")

esc = tk.Button(window, text ="EXIT", command = close, bg = "brown")

red.pack()
blue.pack()
green.pack()
of.pack()
esc.pack()


window.mainloop()

GPIO.cleanup()