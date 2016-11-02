using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vUserEquipment
    {
        public int staicID { get; set; }
        public int level { get; set; } // cường hóa
        public int promotion { get; set; }
        public int star_level { get; set; } // tinh luyện
        public int durability { get; set; } // độ bền
        public vUserEquipment() { }
    }
}
