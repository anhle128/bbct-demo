using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Point3
    {
        [ProtoMember(1)]
        public float x { get; set; }
        [ProtoMember(2)]
        public float y { get; set; }
        [ProtoMember(3)]
        public float z { get; set; }

        public Point3()
        {

        }
    }
}
