using GameServer.MainServer.Database.MainDatabaseCollection;
using MongoDB.Driver;

namespace GameServer.MainServer.Database.Controller
{
    public class ServerDbController
    {
        private readonly ServerCollection _server;

        public ServerDbController(IMongoDatabase database)
        {
            _server = new ServerCollection("servers", database);
        }

        public ServerCollection Server
        {
            get { return _server; }
        }
    }
}
