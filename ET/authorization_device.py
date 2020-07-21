import time
import lcddriver
import lcddriver2
import Database
import hashlib
import datetime
import Diode
import RPi.GPIO as GPIO
from pyfingerprint.pyfingerprint import PyFingerprint

lcd = lcddriver.lcd()
lcd2 = lcddriver2.lcd()
database = Database.DataBase()
diode = Diode.Diode()

alarmPinout = 21

GPIO.setmode(GPIO.BCM)
GPIO.setwarnings(False)
GPIO.setup(diode.GreenDiode,GPIO.OUT)
GPIO.output(diode.GreenDiode,GPIO.LOW)
GPIO.setup(diode.RedDiode,GPIO.OUT)
GPIO.output(diode.RedDiode,GPIO.LOW)
GPIO.setup(alarmPinout,GPIO.OUT)
GPIO.output(alarmPinout,GPIO.LOW)

try:
    finger = PyFingerprint('/dev/ttyUSB0', 57600, 0xFFFFFFFF, 0x00000000)

    if ( finger.verifyPassword() == False ):
        raise ValueError('The given fingerprint sensor password is wrong!')

except Exception as e:
    lcd2.lcd_display_string('Error',1)
    exit(1)

#digit = None
#inserted_password = ''
cnt = 0

class Authorize():
    
    
    
    
    def add_user(inserted_password):
        try:
            lcd2.lcd_clear()
            lcd2.lcd_display_string('Add your',1)
            lcd2.lcd_display_string('finger pattern',2)

            while ( finger.readImage() == False ):
                pass

            finger.convertImage(0x01)

            result = finger.searchTemplate()
            positionNumber = result[0]

            if ( positionNumber >= 0 ):
                lcd2.lcd_clear()
                lcd.2lcd_display_string('Pattern already',1)
                lcd.2lcd_display_string('exist',2)
                exit(0)
    
            lcd2.lcd_clear()
            lcd2.lcd_display_string('Authrization..',1)
            lcd2.lcd_display_string('Please wait..',2)
            time.sleep(2)

            while ( finger.readImage() == False ):
                pass

            finger.convertImage(0x02)
            
            if ( finger.compareCharacteristics() == 0 ):
                lcd2.lcd_display_string('Finger patterns',1)
                lcd2.lcd_display_string('do not match',2)
                exit(0)

            finger.createTemplate()

            positionNumber = finger.storeTemplate()

            lcd2.lcd_clear()
            lcd2.lcd_display_string('Authrization',1)
            lcd2.lcd_display_string('Complete',2)
            finger.loadTemplate(positionNumber, 0x01)
            characterics = str(finger.downloadCharacteristics(0x01)).encode('utf-8')
            Char = hashlib.sha256(characterics).hexdigest()
            user_id = database.get_data("select user_id from usercode where create_acc_code = '"+inserted_password+"'")
            database.send_data("update users set user_fingerprint = '"+Char+"', pattern_position = "+str(positionNumber)+" where user_id = "+str(user_id))
            time.sleep(1)
            lcd2.lcd_clear()
            lcd2.lcd_display_string('User added',1)
            lcd2.lcd_display_string('Finger enrolled',2)
            time.sleep(1.5)
            lcd.lcd_clear()
            lcd2.lcd_clear()


        except Exception as e:
            lcd2lcd_clear()
            lcd2.lcd_display_string('Error',1)
            exit(1)
                
    def delete_user():
        can_be_deleted = database.get_data("select users.availability from users where users.user_id = (select usercode.user_id from usercode where usercode.delete_acc_code = '"+inserted_password+"' and users.user_id = usercode.user_id)")
        if can_be_deleted == 0:
            positionNumber = database.get_data("select users.pattern_position from users where users.user_id = (select usercode.user_id from usercode where usercode.delete_acc_code = '"+inserted_password+"' and users.user_id = usercode.user_id)")
            ser_id = database.get_data("select user_id from users where pattern_position = "+str(positionNumber))
            if ( finger.deleteTemplate(positionNumber) == True ):
                pass
                
    def check_user():
        try:
            lcd.lcd_clear()
            lcd.lcd_display_string('Place your',1)
            lcd.lcd_display_string('finger...',2)

            while ( f.readImage() == False ):
                pass

            f.convertImage(0x01)

            result = f.searchTemplate()

            positionNumber = result[0]
            accuracyScore = result[1]

            if ( positionNumber == -1 ):
                lcd.lcd_clear()
                lcd.lcd_display_string('Pattern does not',1)
                lcd.lcd_display_string('exist',2)
                cnt += 1
                if cnt == 1:
                    diode.setRedDiode(diode.RedDiode)
                elif cnt == 2:
                    BlinkDiode = Thread(target=diode.blinkRedDiode())
                    BlinkDiode.start()
                    
                exit(0)
            else:
                f.loadTemplate(positionNumber, 0x01)

                characterics = str(f.downloadCharacteristics(0x01)).encode('utf-8')

                Char = hashlib.sha256(characterics).hexdigest()
                
                DoesCharacteristicsExists = database.get_data("select count(user_fingerprint) from users where user_fingerprint = '" + Char + "'")
                if DoesCharacteristicsExists == 1:
                    diode.setGreenDiode(diode.GreenDiode)
                    diode.resetRedDiode(diode.RedDiode)
                    lcd.lcd_clear()
                    lcd.lcd_display_string('Authorization',1)
                    lcd.lcd_display_string('complete',2)
                    diode.

            

        except Exception as e:
            lcd.lcd_clear()
            lcd.lcd_display_string('Error',1)
            exit(1)
                
                
                
                