using BBCTNPHTool.Database.Core;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBCTNPHTool.Database.MainDatabaseCollection
{
    public class StaticDBCollection : AbsCollectionController<MStaticDB>
    {
        public StaticDBCollection(string nameCollection)
            : base(nameCollection)
        {

        }
    }
}
