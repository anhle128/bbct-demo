
using MongoDBModel.Implement;
using System.Collections.Generic;

namespace MongoDBModel.SubDatabaseModels
{
    public class MUserCuopTieu : IUserTimeDataModel
    {
        public List<MCuopTieuData> cuop_tieu_datas { get; set; }
    }
}
