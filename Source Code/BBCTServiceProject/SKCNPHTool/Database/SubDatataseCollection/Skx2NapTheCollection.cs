using KDQHNPHTool.Database.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class Skx2NapTheCollection : AbsCollectionController<MSKx2NapConfig>
    {
        public Skx2NapTheCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
