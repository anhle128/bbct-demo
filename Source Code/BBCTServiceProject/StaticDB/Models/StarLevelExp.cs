using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class StarLevelExp
    {
        public int[] exp { get; set; }
    }
}
