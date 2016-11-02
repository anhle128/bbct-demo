using KDQHNPHTool.Database.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class SkDuaTopServerCollection : AbsCollectionController<MSKDuaTopServerConfig>
    {
        public SkDuaTopServerCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
