
namespace MongoDBModel.SubDatabaseModels
{
    public class MQuayVatPhamPrice
    {
        public int price;
        public int x10_price;
        public int wait_time_free; // minutes
        public MVatPham[] vat_phams;
    }
}
