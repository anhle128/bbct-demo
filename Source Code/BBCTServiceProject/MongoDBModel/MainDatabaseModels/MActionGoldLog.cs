using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MActionGoldLog : IUserDataModel
    {
        public int old_glod { get; set; }
        public int reward_glod { get; set; }
        public int new_gold { get; set; }
        public ReasonActionGold reason { get; set; }
        public TypeActionGold type { get; set; }
    }
}
