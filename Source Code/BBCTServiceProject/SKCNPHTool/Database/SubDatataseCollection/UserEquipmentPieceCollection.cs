using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class UserEquipmentPieceCollection : AbsCollectionController<MUserEquipPiece>
    {
        public UserEquipmentPieceCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
