using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ContributeGuildResponseData : ISerializeData
    {
        public bool isUpLevel;
        public int level;
        public int contribution;
        public int contributionMember;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(0, isUpLevel);
            data.Add(1, level);
            data.Add(2, contribution);
            data.Add(3, contributionMember);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            isUpLevel = bool.Parse(data[0].ToString());
            level = int.Parse(data[1].ToString());
            contribution = int.Parse(data[2].ToString());
            contributionMember = int.Parse(data[3].ToString());
        }
    }
}
