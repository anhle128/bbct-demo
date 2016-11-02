using DynamicDBModel.Models;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.Enum;
using MongoDBModel.SubDatabaseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameServer.Database.SubDatataseCollection
{
    public class SuKienDuaTopServerConfigCollecion : AbsCollectionController<MSKDuaTopServerConfig>
    {
        public SuKienDuaTopServerConfigCollecion(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexServerData(Collection);
        }

        public MSKDuaTopServerConfig GetData()
        {
            return GetSingleData
            (
                a =>
                    a.status == Status.Activate &&
                    DateTime.Now >= a.start &&
                    DateTime.Now <= a.hide &&
                    a.server_id.Equals(Settings.Instance.server_id)
            );
        }

        public async Task<bool> CheckActivate()
        {
            int count = await CountDataAsync(a =>
                DateTime.Now >= a.start &&
                DateTime.Now <= a.hide &&
                a.server_id.Equals(Settings.Instance.server_id) &&
                a.status == Status.Activate);
            return count > 0;
        }

        public void UpdateTopPlayer(string id, List<TopUser>[] topPlayers)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>();
            dictData.Add("top_level_player", topPlayers[0]);
            dictData.Add("top_power_player", topPlayers[1]);
            dictData.Add("is_send_reward", true);

            UpdateFields(id, dictData);
        }
    }
}
