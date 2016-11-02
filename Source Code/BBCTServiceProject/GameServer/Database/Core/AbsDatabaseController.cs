
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.Core
{
    public class AbsDatabaseController
    {
        public static IMongoDatabase GetDatabase(MMongoConnection databaseInfo)
        {
            var credential = MongoCredential.CreateCredential
            (
                databaseName: "admin",
                username: databaseInfo.username,
                password: (databaseInfo.password)
            );

            MongoClientSettings settings = new MongoClientSettings()
            {
                Server = new MongoServerAddress
                (
                    host: databaseInfo.url,
                    port: int.Parse(databaseInfo.port)
                ),

                //MaxConnectionPoolSize = 100,
                //MinConnectionPoolSize = 50,
                //WaitQueueSize = 50,

                Credentials = new MongoCredential[] { credential }
            };

            IMongoClient client = new MongoClient(settings);


            return client.GetDatabase(databaseInfo.database);
        }
    }
}
