using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameServer.Database.Controller
{
    public class DBHandler
    {

        #region Base Action to Database

        public static List<T> GetListData<T>(IMongoCollection<T> collection, string fieldData, List<string> listData)
        {
            int count = 0;
            FilterDefinition<T>[] arrfilterDefinition = new FilterDefinition<T>[listData.Count];
            foreach (var data in listData)
            {
                Dictionary<string, object> dictFilter = new Dictionary<string, object>()
                {
                    {fieldData, data},
                };
                FilterDefinition<T> filterDefinition = new BsonDocumentFilterDefinition<T>(new BsonDocument(dictFilter));
                arrfilterDefinition[count] = filterDefinition;
                count++;

            }
            var filter = Builders<T>.Filter.Or(arrfilterDefinition);
            collection.Find(filter).ToList();
            return collection.Find(filter).ToList();
        }

        public static List<T> GetListData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            List<T> listData = collection.Find(filter).ToList();
            return listData;
        }

        public static List<T> GetListData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter, int skip, int take) where T : IMongoModel
        {
            List<T> listData = collection.Find(filter).Skip(skip).Limit(take).ToList();
            return listData;
        }

        public static List<T> GetRandomListData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter, int skip, int take) where T : IMongoModel
        {
            //List<T> listData = collection
            //   .Find(filter)
            //   .SortBy(a => Guid.NewGuid())
            //   .Skip(skip)
            //   .Limit(take)
            //   .ToList();
            List<T> listData =
                collection.AsQueryable().Where(filter).ToList().OrderBy(a => Guid.NewGuid()).Skip(skip).Take(take).ToList();
            return listData;
        }

        public static List<T> GetListDataOrderByDescending<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int skip, int take) where T : IMongoModel
        {
            List<T> listData = collection
               .Find(filter)
               .SortByDescending(order)
               .Skip(skip)
               .Limit(take)
               .ToList();
            return listData;
        }

        public static List<T> GetListDataOrderByAscending<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter, Expression<Func<T, object>> order, int skip, int take) where T : IMongoModel
        {
            List<T> listData = collection
               .Find(filter)
               .SortBy(order)
               .Skip(skip)
               .Limit(take)
               .ToList();
            return listData;
        }

        public static T GetSingleData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            T data = collection.Find(filter).FirstOrDefault();
            return data;
        }

        public static T GetLastSingleData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter, Expression<Func<T, object>> order)
        {
            T data = collection.Find(filter).SortByDescending(order).FirstOrDefault();
            return data;
        }

        public static double GetSumData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter, Expression<Func<T, double>> sumer)
        {
            return collection.AsQueryable().Where(filter).Sum(sumer);
        }

        /// <summary>
        /// Đến số lượng
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static async Task<long> CountDataAsync<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            long countData = await collection.CountAsync(filter);
            return countData;
        }

        public static long CountData<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
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
        public static async Task<long> CountDataAsync<T>(IMongoCollection<T> collection, FilterDefinition<T> filter)
        {
            long countData = await collection.CountAsync(filter);
            return countData;
        }

        /// <summary>
        /// Tạo một object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="objectCreate"></param>
        public static void Create<T>(IMongoCollection<T> collection, T objectCreate) where T : IMongoModel
        {
            DateTime timeNow = DateTime.Now;
            //objectCreate._id = new string();
            objectCreate.updated_at = timeNow;
            objectCreate.created_at = timeNow;
            collection.InsertOne(objectCreate);
        }

        /// <summary>
        /// Tạo nhiều object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="nameCollection"></param>
        /// <param name="listObjCreate"></param>
        public static void CreateAll<T>(IMongoCollection<T> collection, List<T> listObjCreate) where T : IMongoModel
        {
            DateTime timeNow = DateTime.Now;

            foreach (var currentObject in listObjCreate)
            {
                //currentObject._id = new string();
                currentObject.updated_at = timeNow;
                currentObject.created_at = timeNow;
                var model = currentObject as IServerDataModel;
            }
            collection.InsertMany(listObjCreate);
        }

        public static void CreateAllImmediately<T>(IMongoCollection<T> collection, List<T> listObjCreate) where T : IMongoModel
        {
            collection.InsertMany(listObjCreate);
        }

        public static void Update<T>(IMongoCollection<T> collection, T objectUpdate) where T : IMongoModel
        {
            FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", objectUpdate._id);
            objectUpdate.updated_at = DateTime.Now;
            collection.FindOneAndReplace(filter, objectUpdate);
        }

        public static void UpdateAll(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));

            collection.UpdateMany(filter, update);
        }

        public static void UpdateAll(IMongoCollection<BsonDocument> collection, Dictionary<string, string> dictFilter, Dictionary<string, object> dictData)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));

            collection.UpdateMany(filter, update);
        }

        public static void FindAndUpdate(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
            collection.FindOneAndUpdate(filter, update);
        }


        public static void UpdateMany(IMongoCollection<BsonDocument> collection, string[] filters, Dictionary<string, object>[] updates)
        {
            // initialise write model to hold list of our upsert tasks
            var models = new WriteModel<BsonDocument>[filters.Length];

            for (var i = 0; i < filters.Length; i++)
            {
                FilterDefinition<BsonDocument> filter = Builders<BsonDocument>.Filter.Eq("_id", filters[i]);
                UpdateDefinition<BsonDocument> update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
                update = updates[i].Aggregate(update, (current, data) => current.Set(data.Key, data.Value));
                models[i] = new UpdateOneModel<BsonDocument>(filter, update);
            }
            collection.BulkWrite(models);
        }

        public static void UpdateFields(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));

            collection.FindOneAndUpdate(filter, update);
        }

        public static void UpdateFields(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, Dictionary<string, string> dictData)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));

            collection.FindOneAndUpdate(filter, update);
        }

        public static void UpdateFields<T>(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, Dictionary<string, List<T>> dictData)
        {

            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));

            collection.FindOneAndUpdate(filter, update);
        }

        public static void UpdateFields(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, Dictionary<string, double> dictData)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);

            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at");
            update = dictData.Aggregate(update, (current, data) => current.Set(data.Key, data.Value));

            collection.UpdateOneAsync(filter, update);

            var models = new WriteModel<BsonDocument>[1];
            models[0] = new UpdateOneModel<BsonDocument>(filter, update);
            collection.BulkWrite(models);

            //collection.FindOneAndUpdate(filter, update);
        }

        public static void UpdateOneInc(IMongoCollection<BsonDocument> collection, Dictionary<string, object> dictFilter, string key, object value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(dictFilter.First().Key, dictFilter.First().Value);
            var update = Builders<BsonDocument>.Update.CurrentDate("updated_at").Inc(key, value);

            collection.UpdateOne(filter, update);
        }

        /// <summary>
        /// Xóa object
        /// </summary>
        /// <param name="nameCollection"></param>
        /// <param name="_id"></param>
        public static void Delete<T>(IMongoCollection<T> collection, string _id)
        {
            var filter = Builders<T>.Filter.Eq("_id", _id);
            collection.DeleteOne(filter);
        }

        /// <summary>
        /// Xóa nhiều object
        /// </summary>
        /// <param name="nameCollection"></param>
        /// <param name="dataFilter"></param>
        public static void DeleteAll<T>(IMongoCollection<T> collection, Dictionary<string, object> dataFilter)
        {
            if (dataFilter.Count == 0) throw new ArgumentException("Argument is empty collection", "dataFilter");
            var filter = Builders<T>.Filter.Eq(dataFilter.First().Key, dataFilter.First().Value);
            collection.DeleteMany(filter);
        }

        public static void DeleteAll<T>(IMongoCollection<T> collection, Expression<Func<T, bool>> filter)
        {
            collection.DeleteMany<T>(filter);
        }
        #endregion

        #region Indexs

        public static async void CreateIndex<T>(IMongoCollection<T> collection, Dictionary<string, object> dictFields)
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument(dictFields);
            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexServerData<T>(IMongoCollection<T> collection) where T : IServerDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1}
            //};
            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexServerData<T>(IMongoCollection<T> collection, Dictionary<string, object> dictBonusFields) where T : IServerDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1}
            //};

            //document.AddRange(dictBonusFields);

            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexServerTimeData<T>(IMongoCollection<T> collection) where T : IServerTimeDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"hash_code_time",1},
            //};
            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexServerTimeData<T>(IMongoCollection<T> collection, Dictionary<string, object> dictBonusFields) where T : IServerTimeDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"hash_code_time",1},
            //};

            //document.AddRange(dictBonusFields);

            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }


        public static async void CreateIndexUserData<T>(IMongoCollection<T> collection) where T : IUserDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"userid","text"},
            //};
            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexUserData<T>(IMongoCollection<T> collection, Dictionary<string, object> dictBonusFields) where T : IUserDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"userid","text"},
            //};

            //document.AddRange(dictBonusFields);

            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexUserTimeData<T>(IMongoCollection<T> collection) where T : IUserTimeDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"userid","text"},
            //     {"hash_code_time",1},
            //};

            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexUserTimeData<T>(IMongoCollection<T> collection, Dictionary<string, object> dictBonusFields) where T : IUserTimeDataModel
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"userid","text"},
            //     {"hash_code_time",1},
            //};

            //document.AddRange(dictBonusFields);

            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexStaticData<T>(IMongoCollection<T> collection) where T : IStaticObj
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"userid","text"},
            //     {"static_id",1},
            //};
            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }

        public static async void CreateIndexStaticData<T>(IMongoCollection<T> collection, Dictionary<string, object> dictBonusFields) where T : IStaticObj
        {
            //collection.Indexes.DropAll();
            //var document = new BsonDocument
            //{
            //     {"server_id",1},
            //     {"userid","text"},
            //     {"static_id",1},
            //};

            //document.AddRange(dictBonusFields);

            //await collection.Indexes.CreateOneAsync(new BsonDocumentIndexKeysDefinition<T>(document));
        }
        #endregion
    }
}
