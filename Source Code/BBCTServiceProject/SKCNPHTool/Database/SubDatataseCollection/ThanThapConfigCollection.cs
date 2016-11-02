using KDQHNPHTool.Database.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class ThanThapConfigCollection : AbsCollectionController<MThanThapConfig>
    {
        public ThanThapConfigCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
