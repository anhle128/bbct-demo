using KDQHNPHTool.Database.Core;
using KDQHNPHTool.Database.Model;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.MainDatabaseCollection
{
    public class TyGiaQuyDoiCollection : AbsCollectionController<MTyGiaQuyDoi>
    {
        public TyGiaQuyDoiCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
