using DynamicDBModel.Models;
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserNhiemVuChinhTuyen : IUserDataModel
    {
        public List<NhiemVuChinhTuyenData> datas;
    }
}
