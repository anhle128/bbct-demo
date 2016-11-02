using DynamicDBModel.Enum;
using ProtoBuf;
using System;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class LuanKiemLog
    {
        [ProtoMember(1)]
        public string _id { get; set; }
        [ProtoMember(2)]
        public UserLuanKiem user { get; set; }
        [ProtoMember(3)]
        public UserLuanKiem userOpponent { get; set; }
        [ProtoMember(4)]
        public OutcomeResult ountcome { get; set; }
        [ProtoMember(5)]
        public TypeLuanKiemAttack typeAttack { get; set; }
        [ProtoMember(8)]
        public DateTime time { get; set; }
    }
}
