using MongoDBModel.Implement;
using StaticDB.Models;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MChucPhucConfig : IServerDataModel
    {
        public List<Reward> rewards { get; set; }
    }
}
