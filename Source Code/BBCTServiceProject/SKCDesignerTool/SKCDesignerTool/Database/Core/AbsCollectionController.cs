
using MongoDBModel.Implement;
using MongoDBModel.MainDatabaseModels;
using KDQHNPHTool.Database.Controller;
using KDQHNPHTool.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KDQHNPHTool.Database.Core
{
    public class AbsCollectionController<T> : IDataControlable<T> where T : IMongoModel
    {

        Dictionary<MMongoConnection, DBHandler> dictHandler = new Dictionary<MMongoConnection, DBHandler>();
        private DBHandler GetHandler(MMongoConnection database)
        {
            if (dictHandler.ContainsKey(database))
                return dictHandler[database];

            DBHandler handler = new DBHandler(database);
            handler.Connected();

            dictHandler.Add(database, handler);
            return handler;
        }

        public AbsCollectionController(string nameCollection)
        {
            this.NameCollection = nameCollection;
        }

        public string NameCollection { get; set; }

        public virtual void Create(MMongoConnection database, T data)
        {
            SetDefaultValue(data);
            GetHandler(database).Create(NameCollection, data);
        }

        protected virtual void SetDefaultValue(T data) { return; }

        public virtual void CreateAll(MMongoConnection database, List<T> listData)
        {
            Parallel.ForEach(listData, SetDefaultValue);
            GetHandler(database).CreateAll(NameCollection, listData);
        }

        public virtual void DeleteAsync(MMongoConnection database, MongoDB.Bson.ObjectId id)
        {
            GetHandler(database).DeleteAsync(NameCollection, id);
        }
        public virtual void DeleteAllAsync(MMongoConnection database, Expression<System.Func<T, bool>> filter)
        {
            GetHandler(database).DeleteAllAsync(NameCollection, filter);
        }
        public virtual void UpdateFieldsAsync(MMongoConnection database, MongoDB.Bson.ObjectId id, Dictionary<string, object> dictData)
        {
            Dictionary<string, object> dictFilter = new Dictionary<string, object>(1)
            {
                {"_id",id}
            };
            GetHandler(database).UpdateFieldsAsync(NameCollection, dictFilter, dictData);
        }
        public virtual void UpdateAllAsync(MMongoConnection database, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            GetHandler(database).UpdateAllAsync(NameCollection, dictFilter, dictData);
        }
        public virtual void UpdateAll(MMongoConnection database, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            GetHandler(database).UpdateAll(NameCollection, dictFilter, dictData);
        }
        public virtual int CountData(MMongoConnection database, Expression<System.Func<T, bool>> filter)
        {
            return (int)GetHandler(database).CountData<T>(NameCollection, filter);
        }

        public virtual void UpdateQuantity(MMongoConnection database, IStaticObjCountable data)
        {
            var dictData = new Dictionary<string, object> { { "quantity", data.quantity } };
            UpdateFieldsAsync(database, data._id, dictData);
        }
        public virtual async Task<int> CountDataAsync(MMongoConnection database, Expression<System.Func<T, bool>> filter)
        {
            long result = await GetHandler(database).CountDataAsync(NameCollection, filter);
            return (int)result;
        }
        public List<T> GetListData(MMongoConnection database, Expression<System.Func<T, bool>> filter)
        {
            return GetHandler(database).GetListData(NameCollection, filter);
        }

        public List<T> GetListData(MMongoConnection database, Expression<Func<T, bool>> filter, int skip, int take)
        {
            return GetHandler(database).GetListData(NameCollection, filter, skip, take);
        }

        public T GetSingleData(MMongoConnection database, Expression<System.Func<T, bool>> filter)
        {
            return GetHandler(database).GetSingleData(NameCollection, filter);
        }

        public void FindOneAndUpdateAsync(MMongoConnection database, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData)
        {
            GetHandler(database).FindAndUpdateAsync(NameCollection, dictFilter, dictData);
        }


        public void Update(MMongoConnection database, T objectUpdate)
        {
            GetHandler(database).Update(NameCollection, objectUpdate);
        }
    }
}
