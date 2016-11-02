using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vUserLogin
    {
        public string idServer { get; set; }
        public string username { get; set; }
        public DateTime login_time { get; set; }
        public DateTime logout_time { get; set; }
        public int count_time_login { get; set; }
        public int hash_code_time { get; set; }
    }
}
