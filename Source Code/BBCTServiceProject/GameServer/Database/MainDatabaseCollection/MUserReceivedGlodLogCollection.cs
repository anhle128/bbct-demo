using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;

namespace GameServer.Database.MainDatabaseCollection
{
    public class MUserReceivedGlodLogCollection : AbsCollectionController<MUserReceivedGlodLog>
    {
        public MUserReceivedGlodLogCollection(string nameCollection, IMongoDatabase database) : 
            base(nameCollection, database)
        {
        }

        
    }
}
