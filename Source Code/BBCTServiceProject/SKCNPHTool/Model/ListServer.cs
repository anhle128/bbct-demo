using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Model
{
    public class ListServer
    {
        public List<Server> GetListServer()
        {
            List<Server> lsServer = new List<Server>();

            foreach (var item in MongoController.DatabaseManager.sub_database)
            {
                Server ser = new Server()
                {
                    id = item.idServer,
                    value = item.nameServer
                };
                lsServer.Add(ser);
            }
            return lsServer;
        }

        public List<InforPhoton> GetListServerPhoton()
        {
            List<InforPhoton> lsServer = new List<InforPhoton>();

            foreach (var item in MongoController.DatabaseManager.sub_database)
            {
                InforPhoton ser = new InforPhoton()
                {
                    idServer = item.idServer,
                    nameServer = item.nameServer,
                    url = item.inforConnectPhoton.url,
                    port = item.inforConnectPhoton.port,
                    appName = item.inforConnectPhoton.app_name
                };
                lsServer.Add(ser);
            }
            return lsServer;
        }

        public MMongoConnection GetConnectSubDB(string idServer)
        {
            var db = MongoController.DatabaseManager.sub_database.Where(x => x.idServer == idServer).FirstOrDefault();
            return db.inforConnectSub;
        }
    }
}
