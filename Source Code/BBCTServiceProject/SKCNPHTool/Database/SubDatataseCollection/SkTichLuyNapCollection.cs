using KDQHNPHTool.Database.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class SkTichLuyNapCollection : AbsCollectionController<MSKTichLuyNapConfig>
    {
        public SkTichLuyNapCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
