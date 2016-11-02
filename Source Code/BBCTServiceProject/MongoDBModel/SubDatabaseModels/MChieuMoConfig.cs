using MongoDBModel.Implement;

namespace MongoDBModel.SubDatabaseModels
{
    public class MChieuMoConfig : IServerDataModel
    {
        public MQuayTuongGroup quay_tuong;
        public MQuayVatPhamGroup quay_vat_pham;
    }
}
