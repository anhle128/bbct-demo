
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class IndexReceived
    {
        [ProtoMember(1)]
        public int index { get; set; }
        [ProtoMember(2)]
        public int received_times { get; set; }
    }
}
