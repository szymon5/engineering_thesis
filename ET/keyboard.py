import KeyboardInit
import time
import RPi.GPIO as GPIO

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BCM)
GPIO.setup(16,GPIO.OUT)
GPIO.output(16,GPIO.LOW)
GPIO.setup(20,GPIO.OUT)
GPIO.output(20,GPIO.LOW)

keyboard = KeyboardInit.keypad()
password_test = ""
password = "*159#"
digit = None
 
try:
    print('PROSZE WPISAC HASLO: ')
    while(True):
      digit = keyboard.getKey()
      if digit is not None:
          password_test += str(digit)
          if digit == '#':
              if password_test == password:
                  
                  print(len(password_test))
                  print('HASLO POPRAWNE: ' + password_test)
                  password_test = ""
              else:
                  print('HASLO BLEDNE: ' + password_test)
                  password_test= ""
          if digit == 'C':
              password_test.replace('C','')
          print(digit)
          time.sleep(0.5)
         # kp.cls()
except KeyboardInterrupt:
      GPIO.cleanup()