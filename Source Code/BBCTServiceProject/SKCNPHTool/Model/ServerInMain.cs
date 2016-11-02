using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    public class ServerInMain
    {
        public string idServer { get; set; }
        public string nameServer { get; set; }
        public int statusServer { get; set; }
        public MMongoConnection inforConnectSub { get; set; }
        public MPhotonConnection inforConnectPhoton { get; set; }

        public ServerInMain()
        {

        }
    }
}
