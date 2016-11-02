using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Core;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class UserItemCollection : AbsCollectionController<MUserItem>
    {
        public UserItemCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
