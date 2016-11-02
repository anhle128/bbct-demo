using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Map
    {
        [ProtoMember(1)]
        public Stage[] stages { get; set; }

        [ProtoMember(2)]
        public int background { get; set; }

        [ProtoMember(3)]
        public string name { get; set; }

        [ProtoMember(4)]
        public bool isAuto { get; set; }

        public Map()
        {

        }
    }
}
