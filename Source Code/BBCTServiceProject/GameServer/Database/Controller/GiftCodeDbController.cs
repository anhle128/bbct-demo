using GameServer.Database.MainDatabaseCollection;
using MongoDB.Driver;

namespace GameServer.Database.Controller
{
    public class GiftCodeDbController
    {
        private readonly GiftCodeCollection _code;
        private readonly GiftCodeCategoryCollection _category;

        public GiftCodeCollection Code
        {
            get { return _code; }
        }

        public GiftCodeCategoryCollection Category
        {
            get { return _category; }
        }

        public GiftCodeDbController(IMongoDatabase database)
        {
            _code = new GiftCodeCollection("gift_code", database);
            _category = new GiftCodeCategoryCollection("gift_code_category", database);
        }


    }
}
