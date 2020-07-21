import time
import lcddriver
import lcddriver2
import Database
import hashlib
import KeyboardInit
import datetime
import RPi.GPIO as GPIO
from pyfingerprint.pyfingerprint import PyFingerprint

lcd = lcddriver.lcd()
lcd2 = lcddriver2.lcd()
database = Database.DataBase()
keyboard = KeyboardInit.keypad()
GPIO.setup(16,GPIO.OUT)
GPIO.output(16,GPIO.LOW)
GPIO.setup(20,GPIO.OUT)
GPIO.output(20,GPIO.LOW)

try:
    finger = PyFingerprint('/dev/ttyUSB0', 57600, 0xFFFFFFFF, 0x00000000)

    if ( finger.verifyPassword() == False ):
        raise ValueError('The given fingerprint sensor password is wrong!')

except Exception as e:
    lcd.lcd_display_string('Error',1)
    print(e)
    exit(1)

digit = None
inserted_password = ''
cnt = 0

user_id = 0

FLAG = True
date_flag = 'active'
code_flag = 'positive'
user_can_be_added = ''
user_can_be_deleted = ''

try:
    while FLAG:
      lcd2.lcd_display_string('insert password: ',1)
      digit = keyboard.getKey()
      if digit is not None:
          inserted_password += str(digit)
          if digit == '#':
              can_be_added = database.get_data("select users.availability from users where users.user_id = (select usercode.user_id from usercode where create_acc_code = '"+inserted_password+"' and users.user_id = usercode.user_id)")
              if inserted_password[0] == 'A':
                  if can_be_added == 1:
                      user_code_quantity = database.get_data("select count(user_id) as quantity from usercode where create_acc_code = '"+inserted_password+"'")
                      if user_code_quantity == 1:
                          expire_date = database.get_data("select expire_date from usercode where create_acc_code = '"+inserted_password+"'")
                          current_date = datetime.datetime.strptime(time.strftime('%Y-%m-%d %H:%M:%S',time.localtime()),'%Y-%m-%d %H:%M:%S')
                          if current_date < expire_date:
                              user_id = database.get_data("select users.user_id from users where users.user_id = (select usercode.user_id from usercode where usercode.create_acc_code = '"+inserted_password+"' and users.user_id = usercode.user_id)")
                              database.send_data("update usercode set create_acc_code = null where create_acc_code = '"+inserted_password+"'")
                              lcd2.lcd_clear()
                              lcd2.lcd_display_string('Code correct!',1)
                              time.sleep(1.5)
                              lcd2.lcd_clear()
                              lcd2.lcd_display_string('Add your',1)
                              lcd2.lcd_display_string('finger pattern',2)
                              date_flag = 'passed'
                              FLAG = False
                          else: date_flag = 'expired'
                      else: code_flag = 'negative'
                  else: user_can_be_added = 'cannot add'
              elif inserted_password[0] == 'D':
                  can_be_deleted = database.get_data("select users.availability from users where users.user_id = (select usercode.user_id from usercode where usercode.delete_acc_code = '"+inserted_password+"' and users.user_id = usercode.user_id)")
                  if can_be_deleted == 0:
                      positionNumber = database.get_data("select users.pattern_position from users where users.user_id = (select usercode.user_id from usercode where usercode.delete_acc_code = '"+inserted_password+"' and users.user_id = usercode.user_id)")
                      user_id = database.get_data("select user_id from users where pattern_position = "+str(positionNumber))
                      if ( finger.deleteTemplate(positionNumber) == True ):
                          user_can_be_deleted = 'positive'
                  else: user_can_be_deleted = 'cannot delete'
                  
              elif inserted_password[0] == 'B':
                  print('inserted_password')
                  
                  
          if digit == 'C':
              index1 = len(inserted_password)-1
              index2 = len(inserted_password)-2
              _char1 = inserted_password[index1]
              _char2 = inserted_password[index2]
              inserted_password = inserted_password.replace(_char1,'',1)
              inserted_password = inserted_password.replace(_char2,'',1)
          if date_flag == 'active':
              lcd2.lcd_clear()
              lcd2.lcd_display_string('insert password',1)
              lcd2.lcd_display_string(inserted_password,2)
          if date_flag == 'expired':
              lcd2.lcd_clear()
              lcd2.lcd_display_string('Code expired!',1)
              inserted_password = ''
              date_flag = 'active'
              digit = None
              time.sleep(2)
              lcd2.lcd_clear()
          if code_flag == 'negative':
              lcd2.lcd_clear()
              lcd2.lcd_display_string('Wrong password',1)
              inserted_password = ''
              code_flag = 'positive'
              digit = None
              time.sleep(2)
          if user_can_be_added == 'cannot add':
              lcd2.lcd_clear()
              lcd2.lcd_display_string('User cannot',1)
              lcd2.lcd_display_string('be added',2)
              inserted_password = ''
              digit = None
              user_can_be_added = ''
              time.sleep(1.5)
              lcd2.lcd_clear()
          if user_can_be_deleted == 'cannot delete':
              lcd2.lcd_clear()
              lcd2.lcd_display_string('User cannot',1)
              lcd2.lcd_display_string('be deleted',2)
              inserted_password = ''
              digit = None
              time.sleep(1.5)
              lcd2.lcd_clear()
          if user_can_be_deleted == 'positive':
              database.send_data("call delete_user("+str(user_id)+")")
              lcd2.lcd_clear()
              lcd2.lcd_display_string('User has been',1)
              lcd2.lcd_display_string('deleted',2)
              time.sleep(1.5)
              lcd2.lcd_clear()
          
except Exception as e:
    print(e)

try:
    lcd.lcd_clear()
    lcd.lcd_display_string('Adding user..',1)
    lcd.lcd_display_string('Place finger..',2)

    while ( finger.readImage() == False ):
        pass

    finger.convertImage(0x01)

    result = finger.searchTemplate()
    positionNumber = result[0]

    if ( positionNumber >= 0 ):
        lcd.lcd_clear()
        lcd.lcd_display_string('Pattern already',1)
        lcd.lcd_display_string('exist',2)
        exit(0)
        
    lcd.lcd_clear()
    lcd.lcd_display_string('Authrization..',1)
    lcd.lcd_display_string('Please wait..',2)
    time.sleep(2)

    while ( finger.readImage() == False ):
        pass

    finger.convertImage(0x02)
    
    if ( finger.compareCharacteristics() == 0 ):
        lcd.lcd_display_string('Finger patterns',1)
        lcd.lcd_display_string('do not match',2)
        exit(0)
    
    
    finger.createTemplate()
    
    positionNumber = finger.storeTemplate()
    
    lcd.lcd_clear()
    lcd.lcd_display_string('Authrization',1)
    lcd.lcd_display_string('Complete',2)
    finger.loadTemplate(positionNumber, 0x01)
    characterics = str(finger.downloadCharacteristics(0x01)).encode('utf-8')
    Char = hashlib.sha256(characterics).hexdigest()
    database.send_data("update users set user_fingerprint = '"+Char+"', pattern_position = "+str(positionNumber)+" where user_id = "+str(user_id))
    time.sleep(1)
    lcd.lcd_clear()
    lcd.lcd_display_string('User added',1)
    lcd.lcd_display_string('Finger enrolled',2)
    time.sleep(1.5)
    lcd.lcd_clear()
    lcd2.lcd_clear()
    

except Exception as e:
    lcd.lcd_clear()
    lcd.lcd_display_string('Error',1)
    print(e)
    exit(1)


