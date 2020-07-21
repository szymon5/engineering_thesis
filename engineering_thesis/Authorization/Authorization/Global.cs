using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    public static class Global
    {
        #region Variables
        public static bool USER_ADDED;
        public static bool USER_DELETED;
        public static bool ADMINISTRATOR_LOGIN;
        public static bool OWN_SQL_IS_DONE;
        public static string GENERATED_TIME;
        public static string EXPIRE_TIME;
        public static string GENERATED_CODE;
        public static string GENERATED_DELETE_ACC_CODE;
        #endregion

        #region List
        public static List<string> NewUser;
        public static List<string> DeleteUser;
        public static List<string> ADMINISTRATOR;
        #endregion
    }
}
