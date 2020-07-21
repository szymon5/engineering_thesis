import hashlib
import Database
import lcddriver
import time
import LED
from pyfingerprint.pyfingerprint import PyFingerprint
from threading import Thread

database = Database.DataBase()
lcd = lcddriver.lcd()
led = LED.Diode()


try:
    finger = PyFingerprint('/dev/ttyUSB0', 57600, 0xFFFFFFFF, 0x00000000)

    if ( finger.verifyPassword() == False ):
        raise ValueError('The given fingerprint sensor password is wrong!')

except Exception as e:
    lcd.lcd_display_string('Error',1)
    exit(1)

cnt = 0

try:
    lcd.lcd_clear()
    lcd.lcd_display_string('Authorization..',1)
    lcd.lcd_display_string('Place finger..',2)

    while ( finger.readImage() == False ):
        pass

    finger.convertImage(0x01)

    result = finger.searchTemplate()

    positionNumber = result[0]
    accuracyScore = result[1]

    if ( positionNumber == -1 ):
        lcd.lcd_clear()
        cnt += 1
        if cnt == 1:
            GPIO.output(6,GPIO.HIGH)
        lcd.lcd_display_string('Given pattern',1)
        lcd.lcd_display_string('does not exist!',2)
        exit(0)
    else:
        finger.loadTemplate(positionNumber, 0x01)
        characterics = str(finger.downloadCharacteristics(0x01)).encode('utf-8')
        Char = hashlib.sha256(characterics).hexdigest()
        user_id = database.get_data("select user_id from users where user_fingerprint = '"+Char+"'")
        database.send_data("update usertime set time_in = '"+time.strftime("%Y-%m-%d %H:%M:%S",time.localtime())+"' where user_id = "+str(user_id))
        lcd.lcd_clear()
        GPIO.output(5,GPIO.HIGH)
        lcd.lcd_display_string('Authorization',1)
        lcd.lcd_display_string('Complete',2)
        time.sleep(2)
        GPIO.output(5,GPIO.LOW)
    

except Exception:
    lcd.lcd_clear()
    lcd.lcd_display_string('Operation failed!',1)
    exit(1)

