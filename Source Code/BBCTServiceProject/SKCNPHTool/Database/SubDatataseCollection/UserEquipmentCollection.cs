using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Core;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class UserEquipmentCollection : AbsCollectionController<MUserEquip>
    {
        public UserEquipmentCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
