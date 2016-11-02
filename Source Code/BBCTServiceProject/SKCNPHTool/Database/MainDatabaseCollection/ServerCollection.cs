using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.MainDatabaseCollection
{
    public class ServerCollection : AbsCollectionController<MServer>
    {
        public ServerCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
