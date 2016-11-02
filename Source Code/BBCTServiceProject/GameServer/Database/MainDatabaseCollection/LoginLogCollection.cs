using GameServer.Common;
using GameServer.Database.Controller;
using GameServer.Database.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDBModel.MainDatabaseModels;
using System;
using System.Collections.Generic;

namespace GameServer.Database.MainDatabaseCollection
{
    public class LoginLogCollection : AbsCollectionController<MLoginLog>
    {
        public LoginLogCollection(string nameCollection, IMongoDatabase database)
            : base(nameCollection, database)
        {
            DBHandler.CreateIndexUserData(Collection);
        }

        public MLoginLog GetLastLogin(string userid)
        {
            return GetLastSingleData(a => a.user_id == userid, a => a.login_time);
        }

        public string Login(string userid)
        {
            MLoginLog log = new MLoginLog()
            {
                user_id = userid,
                hash_code_time = CommonFunc.GetHashCodeTime(),
                server_id = Settings.Instance.server_id,
                login_time = DateTime.Now
            };
            Create(log);
            return log._id;
        }

        public void Logout(string loginId)
        {
            Dictionary<string, object> dictData = new Dictionary<string, object>()
            {
                {"logout_time",DateTime.Now}
            };
            UpdateFields(loginId, dictData);
        }


    }
}
