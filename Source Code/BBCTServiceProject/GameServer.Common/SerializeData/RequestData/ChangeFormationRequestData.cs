
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ChangeFormationRequestData : ISerializeData
    {
        public int index_formation;
        public StringArray[] main;
        public List<string> sub;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(3);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(main));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(sub));
            data.Add(3, index_formation);
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            main = ProtoBufSerializerHelper.Handler().Deserialize<StringArray[]>(data[1] as byte[]);
            sub = ProtoBufSerializerHelper.Handler().Deserialize<List<string>>(data[2] as byte[]);
            index_formation = Convert.ToInt16(data[3].ToString());
        }
    }
}
