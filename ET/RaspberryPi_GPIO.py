import RPi.GPIO as GPIO

class RaspberryPi_GPIO():
    def __init__(self):
        self.GreenDiode_ENTER = 16
        self.RedDiode_ENTER = 20
        self.Alarm = 21
        self.GreenDiode_OUT = 17
        self.RedDiode_OUT = 18
        self.ResetButton = 27
    def GPIO_Init(self):
        GPIO.setmode(GPIO.BCM)
        GPIO.setwarnings(False)
        GPIO.setup(self.GreenDiode_ENTER,GPIO.OUT,initial = GPIO.LOW)
        GPIO.setup(self.RedDiode_ENTER,GPIO.OUT,initial = GPIO.LOW)
        GPIO.setup(self.GreenDiode_OUT,GPIO.OUT,initial = GPIO.LOW)
        GPIO.setup(self.RedDiode_OUT,GPIO.OUT,initial = GPIO.LOW)
        GPIO.setup(self.Alarm,GPIO.OUT,initial = GPIO.LOW)
        GPIO.setup(self.ResetButton,GPIO.IN, pull_up_down = GPIO.PUD_DOWN)