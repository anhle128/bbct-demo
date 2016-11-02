using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataGuildResponseData : ISerializeData
    {
        public string nameGuild;
        public string notice;
        public int level;
        public string useridMaster;
        public int contribution;
        public int myContribution;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, nameGuild);
            data.Add(2, notice);
            data.Add(3, level);
            data.Add(4, useridMaster);
            data.Add(5, contribution);
            data.Add(6, myContribution);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            nameGuild = data[1].ToString();
            notice = data[2].ToString();
            level = int.Parse(data[3].ToString());
            useridMaster = data[4].ToString();
            contribution = int.Parse(data[5].ToString());
            myContribution = int.Parse(data[6].ToString());
        }
    }
}
