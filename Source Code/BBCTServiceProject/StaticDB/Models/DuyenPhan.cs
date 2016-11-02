using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class DuyenPhan
    {
        [ProtoMember(1)]
        public short category { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
        [ProtoMember(3)]
        public bool isOne { get; set; }
        [ProtoMember(4)]
        public int[] ids { get; set; }
        [ProtoMember(5)]
        public MainAttribute[] attributes { get; set; }
    }
}
