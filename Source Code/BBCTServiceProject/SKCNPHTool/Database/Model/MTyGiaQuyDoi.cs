using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.Model
{
    public class MTyGiaQuyDoi : IMongoModel
    {
        public int ruby { get; set; }
        public int vnd { get; set; }
    }
}
