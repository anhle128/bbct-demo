using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.Implement;
using MongoDBModel.Enum;

namespace MongoDBModel.MainDatabaseModels
{
    public class MGMMail : IUserDataModel
    {
        public string title { get; set; }
        public string content { get; set; }
        public int hash_code_time { get; set; }
        public Status status { get; set; }
    }
}
