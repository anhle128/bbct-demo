using MongoDB.Bson;
using MongoDBModel.MainDatabaseModels;
using BBCTDesignerTool.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BBCTDesignerTool.Database.Core
{
    public interface IDataControlable<T>
    {
        string NameCollection { get; set; }

        void Create(MMongoConnection database, T data);

        void CreateAll(MMongoConnection database, List<T> listData);

        void DeleteAsync(MMongoConnection database, ObjectId id);

        void DeleteAllAsync(MMongoConnection database, Expression<Func<T, bool>> filter);

        void UpdateFieldsAsync(MMongoConnection database, ObjectId id, Dictionary<string, object> dictData);
        void Update(MMongoConnection database, T objectUpdate);
        void FindOneAndUpdateAsync(MMongoConnection database, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData);
        void UpdateAllAsync(MMongoConnection database, Dictionary<string, object> dictFilter, Dictionary<string, object> dictData);
        int CountData(MMongoConnection database, Expression<Func<T, bool>> filter);
        Task<int> CountDataAsync(MMongoConnection database, Expression<Func<T, bool>> filter);
        List<T> GetListData(MMongoConnection database, Expression<Func<T, bool>> filter);
        List<T> GetListData(MMongoConnection database, Expression<Func<T, bool>> filter, int skip, int take);
        T GetSingleData(MMongoConnection database, Expression<Func<T, bool>> filter);

    }
}
