using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    public class UserSession
    {
        private static int idUser;

        public static int IdUser
        {
            get { return UserSession.idUser; }
            set { UserSession.idUser = value; }
        }

        private static string username;

        public static string Username
        {
            get { return UserSession.username; }
            set { UserSession.username = value; }
        }

        private static int typeUser;

        public static int TypeUser
        {
            get { return UserSession.typeUser; }
            set { UserSession.typeUser = value; }
        }

        private static string password;

        public static string Password
        {
            get { return UserSession.password; }
            set { UserSession.password = value; }
        }
    }
}
