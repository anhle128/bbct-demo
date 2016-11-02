using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.ResponseData
{
    public class ExportEquipmentResponseData : ISerializeData
    {

        public UserEquipPiece user_equip_piece;
        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(1);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize<UserEquipPiece>(user_equip_piece));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            byte[] bData = (byte[])data[1];
            user_equip_piece = ProtoBufSerializerHelper.Handler().Deserialize<UserEquipPiece>(bData);
        }
    }
}
