using DynamicDBModel.Enum;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MSuKienActivate : IServerDataModel
    {
        public List<TypeSuKien> su_kien_activate;
    }
}
