using DynamicDBModel.Models;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserStage : IUserDataModel
    {
        public UserStage stage_info { get; set; }
    }
}
