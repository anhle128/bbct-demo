using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Implement;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BBCTDesignerTool.Database.Controller
{
    public class DBHandler
    {
        private IMongoClient _client;
        private IMongoDatabase _database;

        private readonly  MMongoConnection _databaseInfo;


        public DBHandler(MMongoConnection databaseInfo)
        {
            this._databaseInfo = databaseInfo;
            Connected();
        }

        public void Connected()
        {
            _client = new MongoClient(string.Format("mongodb://{0}:{1}@{2}/admin", _databaseInfo.username, _databaseInfo.password, _databaseInfo.url));
            _database = _client.GetDatabase(_databaseInfo.database);
        }

        #region Base Action to Database
        private IMongoCollection<T> GetCollection<T>(string nameCollection)
        {
            IMongoCollection<T> collection = _database.GetCollection<T>(nameCollection);
            return collection;
        }


        public async Task<List<T>> GetListDataAsync<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            List<T> listdata;
            using (var cursor = await collection.FindAsync(filter))
            {
                listdata = await cursor.ToListAsync<T>();
            }
            return listdata;
        }

        public List<T> GetListData<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            List<T> listData = collection.AsQueryable().Where(filter).ToList();
            return listData;
        }

        public List<T> GetListData<T>(string nameCollection, Expression<Func<T, bool>> filter, int skip, int take) where T : IMongoModel
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            List<T> listData = collection.AsQueryable().Where(filter).OrderByDescending(a => a.created_at).Skip(skip).Take(take).ToList();
            return listData;
        }

        public T GetSingleData<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            T data = collection.AsQueryable().FirstOrDefault(filter);
            return data;
        }

        /// <summary>
        /// Lấy về data mới nhất trong collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<T> GetRecentDataAsync<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            List<T> listdata;
            using (var cursor = await collection.FindAsync(filter))
            {
                listdata = await cursor.ToListAsync<T>();
            }
            return listdata.Last();
        }

        /// <summary>
        /// Đến số lượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<long> CountDataAsync<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            long countData = await collection.CountAsync(filter);
            return countData;
        }

        public long CountData<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            long countData = collection.Count(filter);
            return countData;
        }

        /// <summary>
        /// Đếm số lượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<long> CountDataAsync<T>(string nameCollection, FilterDefinition<T> filter)
        {
            IMongoCollection<T> collection = GetCollection<T>(nameCollection);
            long countData = await collection.CountAsync(filter);
            return countData;
        }

        /// <summary>
        /// Tạo một object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="objectCreate"></param>
        public async void CreateAsync<T>(string nameCollection, T objectCreate) where T : IMongoModel
        {
            DateTime timeNow = DateTime.Now;
            //mongoModel._id = new ObjectId(CreateBytePrefixTest(Settings.prefixDB));
            objectCreate.updated_at = timeNow;
            objectCreate.created_at = timeNow;
            var collection = GetCollection<T>(nameCollection);
            await collection.InsertOneAsync(objectCreate);
        }

        /// <summary>
        /// Tạo một object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="objectCreate"></param>
        public void Create<T>(string nameCollection, T objectCreate) where T : IMongoModel
        {
            IStaticObjCountable countableObj = objectCreate as IStaticObjCountable;

            DateTime timeNow = DateTime.Now;
            //mongoModel._id = new ObjectId(CreateBytePrefixTest(Settings.prefixDB));

            objectCreate.updated_at = timeNow;
            objectCreate.created_at = timeNow;

            var collection = GetCollection<T>(nameCollection);

            var staticObj = objectCreate as IStaticObj;

            collection.InsertOne(objectCreate);


        }

        /// <summary>
        /// Tạo nhiều object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="listObjCreate"></param>
        public async void CreateAllAsync<T>(string nameCollection, List<T> listObjCreate) where T : IMongoModel
        {
            DateTime timeNow = DateTime.Now;

            Parallel.ForEach(listObjCreate, (currentObject) =>
            {
                currentObject.updated_at = timeNow;
                currentObject.created_at = timeNow;
            });

            var collection = GetCollection<T>(nameCollection);

            await collection.InsertManyAsync(listObjCreate);
        }

        /// <summary>
        /// Tạo nhiều object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="listObjCreate"></param>
        public void CreateAll<T>(string nameCollection, List<T> listObjCreate) where T : IMongoModel
        {
            DateTime timeNow = DateTime.Now;
            Parallel.ForEach(listObjCreate, (currentObject) =>
            {
                currentObject.updated_at = timeNow;
                currentObject.created_at = timeNow;
            });

            var collection = GetCollection<T>(nameCollection);
            collection.InsertMany(listObjCreate);
        }

        public async void Update<T>(string nameCollection, T objectUpdate) where T : IMongoModel
        {
            var collection = GetCollection<T>(nameCollection);
            var filter = Builders<T>.Filter.Eq("_id", objectUpdate._id);
            await collection.ReplaceOneAsync(filter, objectUpdate);
        }

        public async void UpdateAllAsync(string nameCollection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var collection = GetCollection<BsonDocument>(nameCollection);
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
            await collection.UpdateManyAsync(filter, update);
        }

        public async void UpdateAll(string nameCollection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var collection = GetCollection<BsonDocument>(nameCollection);
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
            collection.UpdateMany(filter, update);
        }

        public async void FindAndUpdateAsync(string nameCollection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var collection = GetCollection<BsonDocument>(nameCollection);
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
            collection.FindOneAndUpdateAsync(filter, update);
        }

        public async void UpdateFieldsAsync(string nameCollection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var collection = GetCollection<BsonDocument>(nameCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);

            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
            await collection.UpdateOneAsync(filter, update);
            //await collection.FindOneAndUpdateAsync(filter, update);
        }

        public async void UpdateFieldsAsync(string nameCollection, Dictionary<string, object> dictFilter, Dictionary<string, double> dictData)
        {
            var collection = GetCollection<BsonDocument>(nameCollection);

            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);

            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
            await collection.UpdateOneAsync(filter, update);
            //await collection.FindOneAndUpdateAsync(filter, update);
        }

        /// <summary>
        /// Xóa object
        /// </summary>
        /// <param name="nameCollection"></param>
        /// <param name="_id"></param>
        public async void DeleteAsync(string nameCollection, ObjectId _id)
        {
            var collection = GetCollection<IMongoModel>(nameCollection);
            var filter = Builders<IMongoModel>.Filter.Eq("_id", _id);
            await collection.DeleteOneAsync(filter);
        }

        /// <summary>
        /// Xóa nhiều object
        /// </summary>
        /// <param name="nameCollection"></param>
        /// <param name="dataFilter"></param>
        public async void DeleteAllAsync(string nameCollection, Dictionary<string, object> dataFilter)
        {
            if (dataFilter.Count == 0) throw new ArgumentException("Argument is empty collection", "dataFilter");
            var collection = GetCollection<IMongoModel>(nameCollection);
            var filter = Builders<IMongoModel>.Filter.Eq(dataFilter.First().Key, dataFilter.First().Value);
            await collection.DeleteManyAsync(filter);
        }

        public async void DeleteAllAsync<T>(string nameCollection, Expression<Func<T, bool>> filter)
        {
            var collection = GetCollection<T>(nameCollection);
            await collection.DeleteManyAsync<T>(filter);
        }
        #endregion
    }
}
