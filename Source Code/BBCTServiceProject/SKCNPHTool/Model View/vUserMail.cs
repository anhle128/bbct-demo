using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model_View
{
    public class vUserMail
    {
        public int idFake { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public bool readed { get; set; }
        public int typeMail { get; set; }
    }
}
