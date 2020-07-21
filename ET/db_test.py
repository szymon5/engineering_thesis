import Database

db = Database.DataBase()

db.get_data('select user_name from users where user_id = 5')