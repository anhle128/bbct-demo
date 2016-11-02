
using ProtoBuf;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class StringArray
    {
        [ProtoMember(1)]
        public string[] columns;
    }
}
