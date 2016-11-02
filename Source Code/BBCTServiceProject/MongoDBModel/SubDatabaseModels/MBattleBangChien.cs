using MongoDB.Bson;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBModel.SubDatabaseModels
{
    public class MBattleBangChien : IMongoModel
    {
        public string id_bangchien;
        public int round;
        public string guild_a;
        public string guild_b;
        public int result;
        public double dmg_top_a;
        public double dmg_mid_a;
        public double dmg_bot_a;
        public double dmg_top_b;
        public double dmg_mid_b;
        public double dmg_bot_b;
    }
}
