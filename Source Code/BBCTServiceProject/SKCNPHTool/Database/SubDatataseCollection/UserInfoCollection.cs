using MongoDBModel.SubDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Database.Core;

namespace KDQHNPHTool.Database.SubDatataseCollection
{
    public class UserInfoCollection : AbsCollectionController<MUserInfo>
    {
        public UserInfoCollection(string nameCollection)
            : base(nameCollection)
        {
        }
    }
}
