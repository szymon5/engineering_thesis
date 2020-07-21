import time
import lcddriver
import lcddriver2
import Database
import hashlib
import KeyboardInit
import datetime
import Diode
import threading
import RaspberryPi_GPIO
import RPi.GPIO as GPIO
from pyfingerprint.pyfingerprint import PyFingerprint

lcd = lcddriver.lcd()
lcd2 = lcddriver2.lcd()
database = Database.DataBase()
keyboard = KeyboardInit.keypad()
diode = Diode.Diode()
raspberry = RaspberryPi_GPIO.RaspberryPi_GPIO()

raspberry.GPIO_Init()

class User():
    def __init__(self):
        self.finger = None
        self.digit = None
        self.FLAG = True
        self.inserted_password = ''
        self.cnt_ENTER = 0
        self.cnt_OUT = 0
        self.data_flag = 'active'
        self.positive_flag = ''
        self.camera_flag = 'active'
        #self.CamThreadFlag = True
    def ResetButtonCallback(self,channel):
        diode.resetAll()
        self.cnt_ENTER = 0
        self.cnt_OUT = 0
        self.FLAG = True
        self.digit = None
        self.inserted_password = ''
        self.data_flag = 'active'
        self.positive_flag = ''
        lcd.lcd_clear()
        lcd2.lcd_clear()
        #GPIO.cleanup()
    def CameraButtonCallback(self,channel):
        self.camera_flag = 'off'
        self.CamThreadFlag = False
    def fingerprint_init(self):
        
        try:
            self.finger = PyFingerprint('/dev/ttyUSB0', 57600, 0xFFFFFFFF, 0x00000000)

            if ( self.finger.verifyPassword() == False ):
                raise ValueError('The given fingerprint sensor password is wrong!')

        except Exception as e:
            lcd.lcd_display_string('Error',1)
            print(e)
            exit(0)
            
    def add_user_fingerprint(self,user_id):
        try:
            lcd.lcd_clear()
            lcd.lcd_display_string('Adding user..',1)
            lcd.lcd_display_string('Place finger..',2)

            while ( self.finger.readImage() == False ):
                pass

            self.finger.convertImage(0x01)

            result = self.finger.searchTemplate()
            positionNumber = result[0]

            if ( positionNumber >= 0 ):
                lcd.lcd_clear()
                lcd.lcd_display_string('Pattern already',1)
                lcd.lcd_display_string('exist',2)
        
            lcd.lcd_clear()
            lcd.lcd_display_string('Authrization..',1)
            lcd.lcd_display_string('Please wait..',2)
            time.sleep(2)

            while ( self.finger.readImage() == False ):
                pass

            self.finger.convertImage(0x02)
    
            if ( self.finger.compareCharacteristics() == 0 ):
                lcd.lcd_display_string('Finger patterns',1)
                lcd.lcd_display_string('do not match',2)
    
    
            self.finger.createTemplate()
    
            positionNumber = self.finger.storeTemplate()
    
            lcd.lcd_clear()
            lcd.lcd_display_string('Authrization',1)
            lcd.lcd_display_string('Complete',2)
            self.finger.loadTemplate(positionNumber, 0x01)
            characterics = str(self.finger.downloadCharacteristics(0x01)).encode('utf-8')
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
            
    def counter_OUT(self):
        self.cnt_OUT += 1
        if self.cnt_OUT == 1:
            diode.setRedDiode_OUT()
            time.sleep(1.5)
            diode.resetRedDiode_OUT()
        elif self.cnt_OUT == 2:
            diode.blinkRedDiode_OUT()
        elif self.cnt_OUT == 3:
            diode.setAlarm()
            time.sleep(0.1)
            diode.resetAlarm()
            lcd2.lcd_display_string('AUTHORIZATION',1)
            lcd2.lcd_display_string('FAILED !!!',2)
            self.FLAG = False
            
    def counter_ENTER(self):
        self.cnt_ENTER += 1
        if self.cnt_ENTER == 1:
            diode.setRedDiode_OUT()
            time.sleep(1.5)
            diode.resetRedDiode_OUT()
        elif self.cnt_ENTER == 2:
            diode.blinkRedDiode_OUT()
            #time.sleep(1.5)
        elif self.cnt_ENTER == 3:
            diode.setAlarm()
            time.sleep(0.1)
            diode.resetAlarm()
            lcd2.lcd_display_string('AUTHORIZATION',1)
            lcd2.lcd_display_string('FAILED !!!',2)
            self.FLAG = False
    
    def positive(self):
        if self.positive_flag == 'OUT':
            diode.setGreenDiode_OUT()
            diode.resetRedDiode_OUT()
            time.sleep(1.5)
            diode.resetGreenDiode_OUT()
        elif self.positive_flag == 'ENTER':
            diode.setGreenDiode_ENTER()
            diode.resetRedDiode_ENTER()
            time.sleep(1.5)
            diode.resetGreenDiode_ENTER()

    def residence_time(self,user_id):
        time_in = database.get_data("select time_in from usertime where user_id = "+str(user_id))
        time_out = database.get_data("select time_out from usertime where user_id = "+str(user_id))
        if ((time_in is not None) and (time_out is not None)):
            res_time = (time_out - time_in)
            database.send_data("update usertime set residence_time = '"+str(res_time)+"' where user_id = "+str(user_id))

    def add_delete_user(self):
        try:
            while self.FLAG:
                lcd2.lcd_display_string('Insert password:',1)
                self.digit = keyboard.getKey()
                if self.digit is not None:
                    self.inserted_password += str(self.digit)
                    if self.digit == '#':
                        if self.inserted_password[0] == 'A':
                            DoesAddCodeExists = database.get_data("select count(create_acc_code) from usercode where create_acc_code = '"+self.inserted_password+"'")
                            if DoesAddCodeExists == 1:
                                can_be_added = database.get_data("select users.availability from users where users.user_id = (select usercode.user_id from usercode where create_acc_code = '"+self.inserted_password+"' and users.user_id = usercode.user_id)")
                                if can_be_added == 1:
                                    user_code_quantity = database.get_data("select count(user_id) as quantity from usercode where create_acc_code = '"+self.inserted_password+"'")
                                    if user_code_quantity == 1:
                                        expire_date = database.get_data("select expire_date from usercode where create_acc_code = '"+self.inserted_password+"'")
                                        current_date = datetime.datetime.strptime(time.strftime('%Y-%m-%d %H:%M:%S',time.localtime()),'%Y-%m-%d %H:%M:%S')
                                        if current_date < expire_date:
                                            user_id = database.get_data("select users.user_id from users where users.user_id = (select usercode.user_id from usercode where usercode.create_acc_code = '"+self.inserted_password+"' and users.user_id = usercode.user_id)")
                                            database.send_data("update usercode set create_acc_code = null where create_acc_code = '"+self.inserted_password+"'")
                                            lcd2.lcd_clear()
                                            lcd2.lcd_display_string('Code correct!',1)
                                            time.sleep(1.5)
                                            lcd2.lcd_clear()
                                            lcd2.lcd_display_string('Add your',1)
                                            lcd2.lcd_display_string('finger pattern',2)
                                            self.data_flag = 'off'
                                            self.add_user_fingerprint(user_id)
                                            self.FLAG = False
                                        
                                        else:
                                            lcd2.lcd_clear()
                                            lcd2.lcd_display_string('Code expired!',1)
                                            self.inserted_password = ''
                                            self.data_flag = 'active'
                                            self.digit = None
                                            time.sleep(2)
                                            lcd2.lcd_clear()
                                        
                                    else:
                                        lcd2.lcd_clear()
                                        lcd2.lcd_display_string('Wrong password',1)
                                        self.inserted_password = ''
                                        self.digit = None
                                        time.sleep(2)
                                
                                else:
                                    lcd2.lcd_clear()
                                    lcd2.lcd_display_string('User cannot',1)
                                    lcd2.lcd_display_string('be added',2)
                                    self.inserted_password = ''
                                    self.digit = None
                                    time.sleep(1.5)
                                    lcd2.lcd_clear()
                            
                            else:
                                lcd2.lcd_clear()
                                lcd2.lcd_display_string('This password',1)
                                lcd2.lcd_display_string('not exists',2)
                                
                        elif self.inserted_password[0] == 'D':
                            DoesDeleteCodeExists = database.get_data("select count(delete_acc_code) from usercode where delete_acc_code = '"+self.inserted_password+"'")
                            if DoesDeleteCodeExists == 1:
                                getUserID = database.get_data("select user_id from usercode where delete_acc_code = '"+self.inserted_password+"'")
                                can_be_deleted = database.get_data("select availability from users where user_id = "+str(getUserID))
                                if can_be_deleted == 0:
                                    positionNumber = database.get_data("select pattern_position from users where user_id = "+str(getUserID))
                                    if ( self.finger.deleteTemplate(positionNumber) == True ):
                                        database.send_data("call delete_user("+str(getUserID)+")")
                                        lcd2.lcd_clear()
                                        lcd2.lcd_display_string('User has been',1)
                                        lcd2.lcd_display_string('deleted',2)
                                        self.inserted_password = ''
                                        self.digit = None
                                        time.sleep(1.5)
                                        lcd2.lcd_clear()
                                else:
                                    lcd2.lcd_clear()
                                    lcd2.lcd_display_string('User cannot',1)
                                    lcd2.lcd_display_string('be deleted',2)
                                    self.inserted_password = ''
                                    self.digit = None
                                    time.sleep(1.5)
                                    lcd2.lcd_clear()
                                    
                            else:
                                lcd2.lcd_display_string('Password not',1)
                                lcd2.lcd_display_string('recognized',2)
                                
                        elif self.inserted_password[0] == 'B':
                            user_id = database.get_data("select user_id from users where user_exit_password = '"+self.inserted_password+"'")
                            if user_id >= 1:
                                lcd2.lcd_clear()
                                lcd2.lcd_display_string('Password correct',1)
                                time_out_date = datetime.datetime.strptime(time.strftime('%Y-%m-%d %H:%M:%S',time.localtime()),'%Y-%m-%d %H:%M:%S')
                                database.send_data("update usertime set time_out = '"+str(time_out_date)+"' where user_id = "+str(user_id))
                                self.positive_flag = 'OUT'
                                self.positive()
                                self.residence_time(user_id)
                                self.data_flag = 'off'
                                self.FLAG = False
                                    
                            else:
                                lcd2.lcd_clear()
                                lcd2.lcd_display_string('Wrong password',1)
                                self.counter_OUT()
                                time.sleep(1.5)
                                self.digit = None
                                self.inserted_password = ''
                        
                        else:
                            lcd2.lcd_clear()
                            lcd2.lcd_display_string('Password not',1)
                            lcd2.lcd_display_string('recognized',2)
                        
                    if self.digit == 'C':
                        index1 = len(self.inserted_password)-1
                        index2 = len(self.inserted_password)-2
                        _char1 = self.inserted_password[index1]
                        _char2 = self.inserted_password[index2]
                        self.inserted_password = self.inserted_password.replace(_char1,'',1)
                        self.inserted_password = self.inserted_password.replace(_char2,'',1)
                    if self.data_flag == 'active':
                        lcd2.lcd_clear()
                        lcd2.lcd_display_string('insert password',1)
                        lcd2.lcd_display_string(self.inserted_password,2)
            
            
            
        except Exception as e:
            lcd.lcd_clear()
            lcd2.lcd_clear()
            lcd.lcd_display_string('Error occured',1)
            lcd2.lcd_display_string('Error occured',1)
            print(e)
    
    
    
    def check_user(self):
        while True:
            try:
                while ( self.finger.readImage() == False ):
                    pass
            
                lcd.lcd_clear()
                lcd.lcd_display_string('Verifying..',1)
            
                self.finger.convertImage(0x01)

                result = self.finger.searchTemplate()
                positionNumber = result[0]

                if positionNumber == -1:
                    lcd.lcd_clear()
                    lcd.lcd_display_string('Given pattern',1)
                    lcd.lcd_display_string('does not exists',2)
                    self.counter_ENTER()
                    #exit(0)
                else:
                    lcd.lcd_clear()
                    lcd.lcd_display_string('Welcome',1)
                    EnterToRoomDate = datetime.datetime.strptime(time.strftime('%Y-%m-%d %H:%M:%S',time.localtime()),'%Y-%m-%d %H:%M:%S')
                    database.send_data("update usertime set time_in = '"+str(EnterToRoomDate)+"' where user_id = (select user_id from users where pattern_position = "+str(positionNumber)+" and usertime.user_id = users.user_id)")
                    self.positive_flag = 'ENTER'
                    self.positive()
                    lcd.lcd_clear()
                
                
            except Exception as e:
                lcd.lcd_clear()
                lcd.lcd_display_string('Error',1)
                print(e)
                #exit()
            