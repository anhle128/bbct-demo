using MongoDBModel.Enum;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MUsedGoldLog : IUserDataModel
    {
        public int gold;
        public TypeUseGold type;
    }
}
