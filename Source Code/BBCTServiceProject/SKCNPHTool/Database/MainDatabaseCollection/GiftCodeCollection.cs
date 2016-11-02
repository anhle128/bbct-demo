using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.MainDatabaseCollection
{
    public class GiftCodeCollection : AbsCollectionController<MGiftCode>
    {
        public GiftCodeCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
