
namespace MongoDBModel.SubDatabaseModels
{
    public class MQuayTuongPrice
    {
        public int price;
        public int x10_price;
        public int wait_time_free; // minutes
        public int max_free_in_day; // gới hạn số lần quoay free mỗi ngày
        public MGroupChar[] group_chars;
    }
}
