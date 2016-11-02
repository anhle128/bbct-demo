using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vLeBao
    {
        public string id { get; set; }
        public string name { get; set; }
        public int gold { get; set; }
        public int real_gold { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public int vip_require { get; set; }
        public int max_buy_times { get; set; }
        public int buy_times { get; set; }
        public int activation { get; set; }
        public int status { get; set; }
        public int statusLeBao { get; set; }
    }
}
