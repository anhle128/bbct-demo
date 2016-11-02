using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBModel.MainDatabaseModels
{
    public class MStaticDB : IMongoModel
    {
        public string version { get; set; }
        public string url { get; set; }
        public string url_language { get; set; }
        public string game_version { get; set; }
    }
}
