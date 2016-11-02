using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class BattleDialog
    {
        [ProtoMember(1)]
        public int idCharacter { get; set; }
        [ProtoMember(2)]
        public string keyQuotes { get; set; }

        [ProtoMember(3)]
        public bool isLeft { get; set; }
        public BattleDialog()
        {

        }
    }
}
