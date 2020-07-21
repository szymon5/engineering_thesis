import test1

#t1 = test1.ta
#t1.show()

class X():
    def __init__(self):
        self.a = "write 'stop' to close recording\n"
    def display(self):
        true = True
        while true:
            x = input(self.a)
            if x == 'stop':
#                print('stop')
                true = False
        
x = X()
x.display()