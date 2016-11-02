using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vUserTransaction
    {
        public string username { get; set; }
        public DateTime time { get; set; }
        public int type { get; set; }
        public double money { get; set; }
        public double ruby { get; set; }
        public string nickname { get; set; }
        public int status { get; set; }
        public vUserTransaction() { }
    }
}
