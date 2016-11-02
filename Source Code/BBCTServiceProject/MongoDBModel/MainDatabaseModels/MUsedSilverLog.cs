using MongoDBModel.Enum;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBModel.MainDatabaseModels
{
    public class MUsedSilverLog : IUserDataModel
    {
        public int silver;
        public TypeUseSilver type;
    }
}
