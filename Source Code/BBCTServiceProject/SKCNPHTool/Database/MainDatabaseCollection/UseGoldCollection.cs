using KDQHNPHTool.Database.Core;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.MainDatabaseCollection
{
    public class UseGoldCollection : AbsCollectionController<MUsedGoldLog>
    {
        public UseGoldCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
