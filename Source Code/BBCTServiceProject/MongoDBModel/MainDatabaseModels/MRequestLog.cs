using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MRequestLog : IUserDataModel
    {
        public string request { get; set; }
    }
}
