using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserVanTieu : IUserTimeDataModel
    {
        public string nickname { get; set; }
        public int level { get; set; }
        public int vip { get; set; }
        public MVehicle current_vehicle { get; set; }
        public bool end { get; set; }
        public bool start { get; set; }
        public List<SubRewardItem> rewards { get; set; }
        public List<string> users_cuop_tieu { get; set; }

        public string server_id { get; set; }
    }
}
