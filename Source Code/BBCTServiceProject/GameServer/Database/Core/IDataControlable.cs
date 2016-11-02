using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GameServer.Database.Core
{
    public interface IDataControlable<T>
    {
        IMongoCollection<T> Collection { get; set; }
        IMongoCollection<BsonDocument> BsonDocumentCollection { get; set; }
        void Create(T data);
        void CreateAll(List<T> listData);
        void Delete(string id);
        void DeleteAll(Expression<Func<T, bool>> filter);
        void Update(T data);
        void UpdateFields(string id, Dictionary<string, object> dictData);
        void UpdateManyFields(string[] filters, Dictionary<string, object>[] dictDatas);
        void FindOneAndUpdate(Dictionary<string, object> dictFilter, Dictionary<string, object> dictData);
        void UpdateAllAsync(Dictionary<string, object> dictFilter, Dictionary<string, object> dictData);
        int CountData(Expression<Func<T, bool>> filter);
        Task<int> CountDataAsync(Expression<Func<T, bool>> filter);
        List<T> GetListData(Expression<Func<T, bool>> filter);
        List<T> GetListData(Expression<Func<T, bool>> filter, int skip, int take);
        List<T> GetRandomListData(Expression<System.Func<T, bool>> filter, int skip, int take);
        List<T> GetListDataDescending(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, int skip, int take);
        List<T> GetListDataAscending(Expression<Func<T, bool>> filter, Expression<Func<T, object>> orderBy, int skip, int take);
        double GetSumData(Expression<Func<T, bool>> filter, Expression<Func<T, double>> sumer);
    }
}
