using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vGuild
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public int contribution { get; set; }
        public string server_id { get; set; }
        public string notice { get; set; }
        public int level { get; set; }
        public vGuild() 
        {

        }
    }
}
