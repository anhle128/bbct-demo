using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDBModel.Implement;

namespace MongoDBModel.MainDatabaseModels
{
    public class MUserReceivedGlodLog : IUserDataModel
    {
        public string[] trans_id { get; set; }
        public int old_ruby { get; set; }
        public int received_ruby { get; set; }
        public int new_ruby { get; set; }
    }
}
