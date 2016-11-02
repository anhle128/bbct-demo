using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameConsoleClient.Models
{
    public class AccountManager
    {
        DateTime lastTimeLogin;
        int numberAccountLogin;
        List<Account> listAccount;

        public DateTime LastTimeLogin
        {
            get
            {
                return lastTimeLogin;
            }

            set
            {
                lastTimeLogin = value;
            }
        }

        public int NumberAccountLogin
        {
            get
            {
                return numberAccountLogin;
            }

            set
            {
                numberAccountLogin = value;
            }
        }

        public List<Account> ListAccount
        {
            get
            {
                return listAccount;
            }

            set
            {
                listAccount = value;
            }
        }
    }
}
