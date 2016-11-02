
using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class ItemOnMarket
    {
        [ProtoMember(1)]
        public string id;
        [ProtoMember(2)]
        public UserEquip equipment;
        [ProtoMember(3)]
        public int price;
    }
}
