using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetDataBossGuildResponseData : ISerializeData
    {
        public int countAttackTimes;
        public double dmg;
        public double totalDmg;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>();
            data.Add(1, countAttackTimes);
            data.Add(2, dmg);
            data.Add(3, totalDmg);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            countAttackTimes = int.Parse(data[1].ToString());
            dmg = double.Parse(data[2].ToString());
            totalDmg = double.Parse(data[3].ToString());
        }
    }
}
