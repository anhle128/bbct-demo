using GameServer.Database.SubDatataseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class ShopDbController
    {
        #region Property
        private readonly ShopItemCollection _item;
        private readonly LeBaoCollection _leBao;
        private readonly LuanKiemShopItemCollection _luanKiem;
        public ShopItemCollection Item
        {
            get { return _item; }
        }
        public LeBaoCollection LeBao
        {
            get { return _leBao; }
        }

        public LuanKiemShopItemCollection LuanKiem
        {
            get { return _luanKiem; }
        }

        #endregion


        public ShopDbController(IMongoDatabase database)
        {
            _item = new ShopItemCollection("shop_items", database);
            _leBao = new LeBaoCollection("le_baos", database);
            _luanKiem = new LuanKiemShopItemCollection("shop_luan_kiem", database);
        }
    }
}
