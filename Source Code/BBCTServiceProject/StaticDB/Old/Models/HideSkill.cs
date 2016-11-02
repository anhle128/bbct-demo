using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class HideSkill
    {
        [ProtoMember(1)]
        public int id { get; set; }

        //[ProtoMember(2)]
        //public float[] valueEffect { get; set; }

        //public int target;

        //public int Condition

        //[ProtoMember(3)]
        //public float[] valueCondition { get; set; }

        //[ProtoMember(4)]
        //public List<ReceiptUpLevel> listReceipt { get; set; }

        //[ProtoMember(5)]
        //public int numberPieces { get; set; }

        [ProtoMember(6)]
        public int element { get; set; }

        [ProtoMember(7)]
        public List<Condition> conditions { get; set; }

        //[ProtoMember(8)]
        //public int attribute { get; set; }

        [ProtoMember(9)]
        public int[] levelHideSkill { get; set; }
          
    }
}
