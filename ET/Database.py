import pymysql

class DataBase:
    def __init__(self):
        self.connection = pymysql.connect(user = '31582762_authorization',
                            password = 'Mrozinski5.',
                            host = 'serwer1954159.home.pl',
                            database = '31582762_authorization')
    def send_data(self,query):
        cursorObj = self.connection.cursor()
        _query = query
        cursorObj.execute(_query)
        self.connection.commit()
        
    def get_data(self,query):
        cursorObj = self.connection.cursor()
        _query = query
        cursorObj.execute(_query)
        row = cursorObj.fetchall()
        for send in row:
            data = send[0]
            return data