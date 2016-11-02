using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class DataLuanKiemResponse : ISerializeData
    {
        public int currentRank;
        public double pointLuanKiem;
        public int attackTimes;
        public List<LuanKiemLog> logs;
        public List<LuanKiemLog> top10Logs;
        public List<PlayerLuanKiem> players;
        public double cooldownAttack;

        public Dictionary<byte, object> Serialize()
        {
            return new Dictionary<byte, object>()
            {
                {1, currentRank},
                {2, pointLuanKiem},
                {3, attackTimes},
                {4, ProtoBufSerializerHelper.Handler().Serialize<List<LuanKiemLog>>(logs)},
                {5, ProtoBufSerializerHelper.Handler().Serialize<List<PlayerLuanKiem>>(players)},
                {6, ProtoBufSerializerHelper.Handler().Serialize<List<LuanKiemLog>>(top10Logs)},
                {7, cooldownAttack}
            };
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            currentRank = (int)data[1];

            pointLuanKiem = (double)data[2];

            attackTimes = (int)data[3];

            logs = ProtoBufSerializerHelper.Handler().Deserialize<List<LuanKiemLog>>(data[4] as byte[]);
            if (logs == null)
                logs = new List<LuanKiemLog>();

            players = ProtoBufSerializerHelper.Handler().Deserialize<List<PlayerLuanKiem>>(data[5] as byte[]);

            top10Logs = ProtoBufSerializerHelper.Handler().Deserialize<List<LuanKiemLog>>(data[6] as byte[]);
            if (top10Logs == null)
                top10Logs = new List<LuanKiemLog>();

            cooldownAttack = (double)data[7];

        }
    }
}
