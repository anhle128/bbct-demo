using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vUserCharacter
    {
        public int idCharacter { get; set; }
        public int level { get; set; }
        public int exp { get; set; }
        public int promotion_level { get; set; } // thăng phẩm
        public int powerup_level { get; set; } // cường hóa
        public int star_level { get; set; } // thăng sao
        public int appellation { get; set; } // danh hiệu
        public bool isMain { get; set; }

        public vUserCharacter() { }
    }
}
