
using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class SubDataPlayer
    {
        [ProtoMember(1)]
        public StringArray[] formation_rows { get; set; }
        [ProtoMember(2)]
        public List<UserCharacter> chars { get; set; }
        [ProtoMember(3)]
        public List<UserEquip> equips { get; set; }
        [ProtoMember(4)]
        public List<int> idAllChars { get; set; }
    }
}
