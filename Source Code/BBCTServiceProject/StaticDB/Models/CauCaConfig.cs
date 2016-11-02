using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class CauCaConfig
    {
        [ProtoMember(1)]
        public CanCauConfig[] canCauConfigs { get; set; }

        [ProtoMember(2)]
        public int vipRequireToEnd { get; set; }
        [ProtoMember(3)]
        public int goldRequireToEnd { get; set; }
    }
}
