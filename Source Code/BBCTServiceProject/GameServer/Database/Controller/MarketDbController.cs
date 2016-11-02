using GameServer.Database.SubDatataseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class MarketDbController
    {
        #region Property
        private readonly ItemOnMarketCollection _itemSelling;

        public ItemOnMarketCollection ItemSelling
        {
            get { return _itemSelling; }
        }

        #endregion



        public MarketDbController(IMongoDatabase database)
        {
            _itemSelling = new ItemOnMarketCollection("item_selling_market", database);
        }

    }
}
