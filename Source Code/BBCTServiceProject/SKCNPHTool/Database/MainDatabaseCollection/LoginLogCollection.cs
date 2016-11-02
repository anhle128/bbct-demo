using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.MainDatabaseCollection
{
    public class LoginLogCollection : AbsCollectionController<MLoginLog>
    {
        public LoginLogCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
