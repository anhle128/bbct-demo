using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicDBModel.Models;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MChieuMoLog : IUserDataModel
    {
        public TypeChieuMo type { get; set; }
        public int times { get; set; }
        public List<RewardItem> rewards { get; set; } 
    }
}
