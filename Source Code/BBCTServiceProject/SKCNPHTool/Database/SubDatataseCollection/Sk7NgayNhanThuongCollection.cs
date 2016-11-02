using KDQHNPHTool.Database.Core;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class Sk7NgayNhanThuongCollection : AbsCollectionController<MSK7NgayNhanThuongConfig>
    {
        public Sk7NgayNhanThuongCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
