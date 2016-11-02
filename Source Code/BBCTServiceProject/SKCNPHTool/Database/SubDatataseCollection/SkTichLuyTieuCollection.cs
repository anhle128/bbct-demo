using KDQHNPHTool.Database.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class SkTichLuyTieuCollection : AbsCollectionController<MSKTichLuyTieuConfig>
    {
        public SkTichLuyTieuCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
