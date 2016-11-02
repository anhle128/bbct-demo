using KDQHNPHTool.Database.Core;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.MainDatabaseCollection
{
    public class UserActionGoldLogCollection : AbsCollectionController<MActionGoldLog>
    {
        public UserActionGoldLogCollection(string nameCollection)
            : base(nameCollection)
        {

        }
    }
}
