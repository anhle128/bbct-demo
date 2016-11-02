
using GameServer.Database.Controller;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Implement;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameServer.Database.Core
{
    public class AbsCollectionController<T> where T : IMongoModel
    {
        public IMongoCollection<T> Collection { get; set; }
        public IMongoCollection<BsonDocument> BsonDocumentCollection { get; set; }

        public AbsCollectionController(string nameCollection, IMongoDatabase database)
        {
            Collection = database.GetCollection<T>(nameCollection);
            BsonDocumentCollection = database.GetCollection<BsonDocument>(nameCollection);
        }

        #region Create data
        protected virtual void SetDefaultValue(T data) { return; }

        public void Create(T data)
        {
            SetDefaultValue(data);
            DBHandler.Create(Collection, data);
        }

        public virtual void CreateAll(List<T> listData)
        {
            if (listData.Count == 0)
                return;
            foreach (var data in listData)
            {
                SetDefaultValue(data);
            }
            DBHandler.CreateAll(Collection, listData);
        }

        public virtual void CreateAllImmediately(List<T> listData)
        {
            if (listData.Count == 0)
                return;

            DBHandler.CreateAllImmediately(Collection, listData);
        }
        #endregion

        #region Delete data
        public virtual void Delete(string id)
        {
            DBHandler.Delete(Collection, id);
        }
        public virtual void DeleteAll(Expression<Func<T, bool>> filter)
        {
            DBHandler.DeleteAll(Collection, filter);
        }
        #endregion

        #region Update data

        public void Update(T data)
        {
            //DBHandler.Update(Collection, data);
            DBHandler.Update(Collection, data);
        }

        public virtual void UpdateFields(string id, Dictionary<string, object> dictData)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"_id",id}
            };
            DBHandler.UpdateFields(BsonDocumentCollection, dictFilter, dictData);
        }

        public virtual void UpdateFields(string id, Dictionary<string, string> dictData)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"_id",id}
            };
            DBHandler.UpdateFields(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdateManyFields(string[] filters, Dictionary<string, object>[] dictDatas)
        {
            if (filters.Length == 0)
                return;
            DBHandler.UpdateMany(BsonDocumentCollection, filters, dictDatas);
        }

        public virtual void UpdateFields<T>(string id, Dictionary<string, List<T>> dictData)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"_id",id}
            };
            DBHandler.UpdateFields(BsonDocumentCollection, dictFilter, dictData);
        }

        public void FindOneAndUpdate(Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            DBHandler.FindAndUpdate(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdateQuantity<T>(T data) where T : IStaticObjCountable
        {
            var dictData = new Dictionary<string, object>
            {
                { "quantity", data.quantity }
            };
            UpdateFields(data._id, dictData);
        }

        public void UpdateFields(string id, Dictionary<string, double> dictData)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"_id",id}
            };
            DBHandler.UpdateFields(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdateAllAsync(Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            DBHandler.UpdateAll(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdateAllAsync(Dictionary<string, string> dictFilter, Dictionary<string, object> dictData)
        {
            DBHandler.UpdateAll(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdateAll(Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            DBHandler.UpdateAll(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdateAll(Dictionary<string, string> dictFilter, Dictionary<string, object> dictData)
        {
            DBHandler.UpdateAll(BsonDocumentCollection, dictFilter, dictData);
        }

        public void UpdatesQuantity<T>(List<T> listData) where T : IStaticObjCountable
        {
            string[] filters = new string[listData.Count];
            Dictionary<string, object>[] listUpdates = new Dictionary<string, object>[listData.Count];

            for (int i = 0; i < listData.Count; i++)
            {
                var data = listData[i];

                Dictionary<string, object> dictUpdate = new Dictionary<string, object>()
                {
                    { "quantity", data.quantity }
                };

                filters[i] = data._id;
                listUpdates[i] = dictUpdate;
            }
            UpdateManyFields(filters, listUpdates);
        }

        public virtual void UpdateOneInc(string id, string key, object value)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"_id", id}
            };
            DBHandler.UpdateOneInc(BsonDocumentCollection, dictFilter, key, value);
        }
        #endregion

        #region CoundLogInDay data
        protected virtual int CountData(Expression<System.Func<T, bool>> filter)
        {
            return (int)DBHandler.CountData<T>(Collection, filter);
        }

        protected virtual async Task<int> CountDataAsync(Expression<System.Func<T, bool>> filter)
        {
            long result = await DBHandler.CountDataAsync(Collection, filter);
            return (int)result;
        }
        #endregion

        #region Sum data
        public double GetSumData(Expression<Func<T, bool>> filter, Expression<Func<T, double>> sumer)
        {
            return DBHandler.GetSumData(Collection, filter, sumer);
        }
        #endregion

        #region Get data

        protected List<T> GetListData(Expression<System.Func<T, bool>> filter)
        {
            return DBHandler.GetListData(Collection, filter);
        }

        protected List<T> GetListData(string field, List<string> listDatas)
        {
            return DBHandler.GetListData(Collection, field, listDatas);
        }

        protected List<T> GetRandomListData(Expression<System.Func<T, bool>> filter, int skip, int take)
        {
            return DBHandler.GetRandomListData(Collection, filter, skip, take);
        }

        protected List<T> GetListData(Expression<Func<T, bool>> filter, int skip, int take)
        {
            return DBHandler.GetListData(Collection, filter, skip, take);
        }

        protected List<T> GetListDataDescending(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, int skip, int take)
        {
            return DBHandler.GetListDataOrderByDescending(Collection, filter, orderBy, skip, take);
        }

        protected List<T> GetListDataAscending(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, int skip, int take)
        {
            return DBHandler.GetListDataOrderByAscending(Collection, filter, orderBy, skip, take);
        }

        protected T GetSingleData(Expression<System.Func<T, bool>> filter)
        {
            return DBHandler.GetSingleData(Collection, filter);
        }

        protected T GetLastSingleData(Expression<System.Func<T, bool>> filter, Expression<Func<T, object>> orderBy)
        {
            return DBHandler.GetLastSingleData(Collection, filter, orderBy);
        }

        public T GetDataById(string id)
        {
            return DBHandler.GetSingleData(Collection, a => a._id.Equals(id));
        }

        #endregion
    }
}
