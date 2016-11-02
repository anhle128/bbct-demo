using DynamicDBModel.Models;
using GameServer.Common.Core;
using StaticDB.Enum;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class GetVehicleVanTieuResponseData : ISerializeData
    {
        public TypeVehicle type;
        public int user_gold;
        public List<SubRewardItem> rewards;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>(2)
            {
                {1,type},
                {2, user_gold},
                {3,ProtoBufSerializerHelper.Handler().Serialize<List<SubRewardItem>>(rewards)} 
        };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            type = (TypeVehicle)data[1];
            user_gold = (int)data[2];
            rewards = ProtoBufSerializerHelper.Handler().Deserialize<List<SubRewardItem>>(data[3] as byte[]);
        }
    }
}
