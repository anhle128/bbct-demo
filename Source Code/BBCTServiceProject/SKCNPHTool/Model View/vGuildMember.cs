using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vGuildMember
    {
        public string _id { get; set; }
        public int contribution { get; set; }
        public string guild_id { get; set; }
        public string server_id { get; set; }
        public string username { get; set; }
        public vGuildMember() { }
    }
}
