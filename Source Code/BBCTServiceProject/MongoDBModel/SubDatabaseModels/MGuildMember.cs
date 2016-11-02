using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MGuildMember : IUserDataModel
    {
        public string guild_id;
        public string server_id;
        public int contribution;
    }
}
