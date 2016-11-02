using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vUserInfor
    {
        public bool isBot { get; set; }
        public int avatar { get; set; }
        public double posX { get; set; }
        public double posY { get; set; }
        public string username { get; set; }
        public string nickname { get; set; }
        public int exp { get; set; }
        public int gold { get; set; }
        public int gold_lock { get; set; }
        public int silver { get; set; }
        public int stamina { get; set; }
        public int vip { get; set; }
        public int level { get; set; }
        public int hash_code_login_time { get; set; }
        public bool isLocked { get; set; }
        public DateTime update_at { get; set; }
        public DateTime create_at { get; set; }

        public vUserInfor()
        {

        }
    }
}
