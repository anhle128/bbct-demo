using ProtoBuf;
using System;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class UserEquipPiece
    {
        [ProtoMember(1)]
        public string _id   { get; set; }
        [ProtoMember(2)]
        public int equip_id { get; set; }
        [ProtoMember(3)]
        public int quantity { get; set; }
    }
}
