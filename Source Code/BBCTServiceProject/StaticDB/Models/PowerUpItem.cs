using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class PowerUpItem
    {
        [ProtoMember(1)]
        public int id { get; set; }
         [ProtoMember(2)]
        public string name { get; set; }
         [ProtoMember(3)]
        public string description { get; set; }
        [ProtoMember(4)]
        public int levelRequire { get; set; }
        [ProtoMember(5)]
        public int promotion { get; set; }
        [ProtoMember(6)]
        public MainAttribute[] attributes { get; set; }

        public PowerUpItem()
        {

        }
    }
}
