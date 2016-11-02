using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Item
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
        [ProtoMember(3)]
        public string description { get; set; }
        [ProtoMember(4)]
        public float sellPrice { get; set; }
        [ProtoMember(5)]
        public float[] attribute { get; set; }
        [ProtoMember(6)]
        public short type { get; set; }
        [ProtoMember(7)]
        public int border { get; set; }
    }
}
