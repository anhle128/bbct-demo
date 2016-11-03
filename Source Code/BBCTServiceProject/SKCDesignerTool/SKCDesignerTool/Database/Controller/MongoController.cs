
using LitJson;
using BBCTDesignerTool.Common;
using BBCTDesignerTool.Database.Model;
using BBCTDesignerTool.Database.MainDatabaseCollection;
using System.IO;
using System.Collections.Generic;
using MongoDBModel.MainDatabaseModels;
using BBCTDesignerTool.Models;

namespace BBCTDesignerTool.Database.Controller
{
    public class MongoController
    {
        public static DatabaseManager DatabaseManager;

        /// <summary>
        /// 
        /// </summary>
        private static StaticDBCollection staticDB;

        public static StaticDBCollection StaticDB
        {
            get { return staticDB; }
        }

        public static void LoadStaticDBCollection()
        {
            staticDB = new StaticDBCollection("staticdb_version");
        }

        #region LoadThongTinServer
        public static void LoadThongTinDatabase()
        {
            MMongoConnection conf = new MMongoConnection()
            {
                database = SettingApp.mgDatabase,
                password = SettingApp.mgPassword,
                port = SettingApp.mgPort,
                url = SettingApp.mgUrl,
                username = SettingApp.mgUsername
            };

            DatabaseManager cs = new DatabaseManager()
            {
                main_database = conf
            };

            DatabaseManager = cs;

            //string path = Path.Combine(Directory.GetCurrentDirectory(), "DatabaseInfo.json");

            //string jsonData = CommonFunc.ReadFile(path);
            //DatabaseManager = JsonMapper.ToObject<DatabaseManager>(jsonData);
            //LoadSubDatabase();
        }

        //public static void LoadSubDatabase()
        //{
        //    List<ServerInMain> lsServer = new List<ServerInMain>();
        //    MongoController.LoadServerCollection();
        //    var tmpMongo = MongoController.Server.GetListData(MongoController.DatabaseManager.main_database, a => true);

        //    foreach (var item in tmpMongo)
        //    {
        //        ServerInMain ser = new ServerInMain()
        //        {
        //            idServer = item._id.ToString(),
        //            nameServer = item.name,
        //            inforConnectSub = item.mongo_connection,
        //            inforConnectPhoton = item.photon_connection
        //        };
        //        lsServer.Add(ser);
        //    }
        //    DatabaseManager.sub_database = lsServer;
        //}
        #endregion
    }
}
