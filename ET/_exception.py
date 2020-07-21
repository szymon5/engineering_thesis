import lcddriver

lcd = lcddriver.lcd()

class _Exception(Exception):
    pass
    

class FingerprintInitializationException(_Exception):
    def InitializationException(self):
        lcd.lcd_display_string('Initialize error',1)

class FingerprintNotMatchException(_Exception):
    def NotMatchException(self,msg1,msg2):
        lcd.lcd_display_string(msg1,1)
        lcd.lcd_display_string(msg2,1)
        