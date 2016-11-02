using StaticDB.Enum;

namespace MongoDBModel.SubDatabaseModels
{
    public class MVatPham
    {
        public TypeReward type { get; set; }
        public int static_id { get; set; }
        public int quantity { get; set; }
        public double proc { get; set; }
    }
}
