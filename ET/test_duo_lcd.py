import lcddriver
import lcddriver2

lcd = lcddriver.lcd()
lcd2 = lcddriver2.lcd()

lcd.lcd_display_string('Hello',1)
lcd2.lcd_display_string('world',1)