using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class UserMailCollection : AbsCollectionController<MUserMail>
    {
        public UserMailCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
