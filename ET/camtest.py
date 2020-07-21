import picamera
import time
import RPi.GPIO as gpio

camera = picamera.PiCamera()

camera.rotation = 180
camera.resolution = (1440,700)

gpio.setmode(gpio.BCM)
gpio.setwarnings(False)
gpio.setup(17,gpio.IN, pull_up_down = gpio.PUD_DOWN)



#camera.capture('/home/pi/Desktop/camera/cam1.jpg')
camera.start_preview()
camera.start_recording('/home/pi/Desktop/camera/rec1.h264')


def ButtonCallback(channel):
    camera.stop_preview()
    camera.stop_recording()
    gpio.cleanup()
#    camera.close()
gpio.add_event_detect(17,gpio.RISING,callback = ButtonCallback)