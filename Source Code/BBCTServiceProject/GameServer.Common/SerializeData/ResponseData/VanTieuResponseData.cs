using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class VanTieuResponseData : ISerializeData
    {
        public int times;
        public CurVehicle current_vehicle;
        public List<Player> cuop_tieu_players;
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> dict = new Dictionary<byte, object>()
           {
               {1,times},
               {2,ProtoBufSerializerHelper.Handler().Serialize<CurVehicle>(current_vehicle)},
               {3,ProtoBufSerializerHelper.Handler().Serialize<List<Player>>(cuop_tieu_players)}
               
           };
            return dict;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            times = (int)data[1];
            byte[] arrByte = data[2] as byte[];
            if (arrByte.Length > 0)
                current_vehicle = ProtoBufSerializerHelper.Handler().Deserialize<CurVehicle>(arrByte);

            cuop_tieu_players = ProtoBufSerializerHelper.Handler().Deserialize<List<Player>>(data[3] as byte[]);
            if (cuop_tieu_players == null)
                cuop_tieu_players = new List<Player>();
        }
    }
}
