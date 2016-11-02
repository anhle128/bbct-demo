using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MHuaNguyenLog : IUserTimeDataModel
    {
        public int count_times { get; set; }
    }
}
