using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Driver;
using MongoDBModel.SubDatabaseModels;

namespace GameServer.Database.SubDatataseCollection
{
    public class UserBookPieceCollection : AbsCollectionController<MUserBookPiece>
    {
        public UserBookPieceCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexStaticData(Collection);
        }
    }
}
