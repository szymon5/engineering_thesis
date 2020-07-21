import User
import RPi.GPIO as GPIO
import threading
import Camera


user = User.User()
camera = Camera.Camera()

lcd = User.lcd
lcd2 = User.lcd2
database = User.database
keyboard = User.keyboard
raspberry = User.raspberry

user.fingerprint_init()

GPIO.add_event_detect(raspberry.ResetButton,GPIO.RISING,callback = user.ResetButtonCallback, bouncetime = 1000)
GPIO.add_event_detect(raspberry.CameraButton,GPIO.RISING,callback = Camera.recordingCallback, bouncetime = 1000)

CameraThread = threading.Thread(target=camera.recording)
CameraThread.start()

AddDeleteBackUserThread = threading.Thread(target=user.add_delete_user)
#AddDeleteBackUserThread.start()

CheckUserThread = threading.Thread(target=user.check_user)
CheckUserThread.start()

