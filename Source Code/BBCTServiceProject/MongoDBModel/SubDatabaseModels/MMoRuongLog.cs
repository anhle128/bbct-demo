
using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MMoRuongLog : IStaticObj
    {
        public double bonus_proc { get; set; }
        public int total_times_opends { get; set; }
        // số lần tối đa lấy một đồ nguyên
        public int max_times_get_do_nguyen { get; set; }
    }
}
