using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class GroupCharacter
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string name { get; set; }
        [ProtoMember(3)]
        public string desc { get; set; }
    }
}
