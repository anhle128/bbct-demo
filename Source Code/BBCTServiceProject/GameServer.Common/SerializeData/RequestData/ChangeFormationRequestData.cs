
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ChangeFormationRequestData : ISerializeData
    {
        public int index_formation;
        public DataFormation data_formation;


        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(data_formation));
            data.Add(2, index_formation);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            data_formation = ProtoBufSerializerHelper.Handler().Deserialize<DataFormation>(data[1] as byte[]);
            index_formation = Convert.ToInt16(data[2].ToString());
        }
    }
}
