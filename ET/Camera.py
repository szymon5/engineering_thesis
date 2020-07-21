import picamera
import RPi.GPIO as gpio
import time
import datetime

camera = picamera.PiCamera()

class Camera():
    cnt = 0
    def recordingCallback(self,channel):
        state = (X.cnt % 2)
        X.cnt += 1
        if X.cnt == 10:
            X.cnt = 0
        if state == 0:
            camera.rotation = 180
            camera.resolution = (1440,700)
            camera.start_preview()
            current_time = datetime.datetime.strptime(time.strftime('%Y-%m-%d %H:%M:%S',
                                                                    time.localtime()),
                                                                    '%Y-%m-%d %H:%M:%S')
            camera.start_recording('/home/pi/Desktop/ET/Records/'+str(current_time)+'.h264')
        if state > 0:
            camera.stop_preview()
            camera.stop_recording()