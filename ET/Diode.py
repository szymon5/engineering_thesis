import time
import RPi.GPIO as GPIO
import RaspberryPi_GPIO

Raspberry = RaspberryPi_GPIO.RaspberryPi_GPIO()

class Diode():
    def __init__(self):
        Raspberry.GPIO_Init()
    def setGreenDiode_ENTER(self):
        GPIO.output(Raspberry.GreenDiode_ENTER,GPIO.HIGH)
    def setRedDiode_ENTER(self):
        GPIO.output(Raspberry.RedDiode_ENTER,GPIO.HIGH)
    def resetGreenDiode_ENTER(self):
        GPIO.output(Raspberry.GreenDiode_ENTER,GPIO.LOW)
    def resetRedDiode_ENTER(self):
        GPIO.output(Raspberry.RedDiode_ENTER,GPIO.LOW)
    def setGreenDiode_OUT(self):
        GPIO.output(Raspberry.GreenDiode_OUT,GPIO.HIGH)
    def setRedDiode_OUT(self):
        GPIO.output(Raspberry.RedDiode_OUT,GPIO.HIGH)
    def resetGreenDiode_OUT(self):
        GPIO.output(Raspberry.GreenDiode_OUT,GPIO.LOW)
    def resetRedDiode_OUT(self):
        GPIO.output(Raspberry.RedDiode_OUT,GPIO.LOW)
    def blinkRedDiode_ENTER(self):
        for i in range(5):
            GPIO.output(Raspberry.RedDiode_ENTER,GPIO.HIGH)
            time.sleep(0.1)
            GPIO.output(Raspberry.RedDiode_ENTER,GPIO.LOW)
            time.sleep(0.1)
    def blinkRedDiode_OUT(self):
        for i in range(5):
            GPIO.output(Raspberry.RedDiode_OUT,GPIO.HIGH)
            time.sleep(0.1)
            GPIO.output(Raspberry.RedDiode_OUT,GPIO.LOW)
            time.sleep(0.1)
    def setAlarm(self):
        GPIO.output(Raspberry.Alarm,GPIO.HIGH)
    def resetAlarm(self):
        GPIO.output(Raspberry.Alarm,GPIO.LOW)
    def resetAll(self):
        GPIO.output(Raspberry.GreenDiode_ENTER,GPIO.LOW)
        GPIO.output(Raspberry.GreenDiode_OUT,GPIO.LOW)
        GPIO.output(Raspberry.RedDiode_ENTER,GPIO.LOW)
        GPIO.output(Raspberry.RedDiode_OUT,GPIO.LOW)
        GPIO.output(Raspberry.Alarm,GPIO.LOW)