using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class UserCharacterCollection : AbsCollectionController<MUserCharacter>
    {
        public UserCharacterCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
