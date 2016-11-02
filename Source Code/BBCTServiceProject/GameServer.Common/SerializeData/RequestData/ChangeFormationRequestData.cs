
using DynamicDBModel.Models;
using GameServer.Common.Core;
using System.Collections.Generic;

namespace GameServer.Common.SerializeData.RequestData
{
    public class ChangeFormationRequestData : ISerializeData
    {
        public StringArray[] formationRows;
        public List<DuBi> doi_hinh_du_bi;

        public Dictionary<byte, object> Serialize()
        {
            Dictionary<byte, object> data = new Dictionary<byte, object>(2);
            data.Add(1, ProtoBufSerializerHelper.Handler().Serialize(formationRows));
            data.Add(2, ProtoBufSerializerHelper.Handler().Serialize(doi_hinh_du_bi));
            return data;
        }

        public void Deserialize(Dictionary<byte, object> data)
        {
            formationRows = ProtoBufSerializerHelper.Handler().Deserialize<StringArray[]>(data[1] as byte[]);
            doi_hinh_du_bi = ProtoBufSerializerHelper.Handler().Deserialize<List<DuBi>>(data[2] as byte[]);
        }
    }
}
