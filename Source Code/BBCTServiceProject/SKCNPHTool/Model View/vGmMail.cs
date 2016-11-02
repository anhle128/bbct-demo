using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vGmMail
    {
        public string idMail { get; set; }
        public string server_id { get; set; }
        public string username { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public int status { get; set; }
        public DateTime createTime { get; set; }
    }
}
