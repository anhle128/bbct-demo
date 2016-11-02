using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class DataFormation
    {
        [ProtoMember(1)]
        public StringArray[] main { get; set; }
        [ProtoMember(2)]
        public List<string> sub { get; set; }
    }
}
