using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;


namespace StaticDB.Models
{
    [ProtoContract]
    public class Sect
    {
        public enum RequiredVariable
        {
            GLORY = 0,
            SILVE = 1,
            GOLD = 2,
            NUMBER_CHARACTERS = 3,
            EVOLUTION_CHARACTER = 4,
            PROMOTION_CHARACTER = 5
        }

        public enum Category
        {
            DOI = 1,
            PHAI = 2,
            BANG = 3,
            THE_LUC=4
        }

        [ProtoMember(1)]
        public int id { get; set; }

        //[ProtoMember(2)]
        //public int category { get; set; }

        [ProtoMember(3)]
        public int level { get; set; }

        [ProtoMember(5)]
        public int exp { get; set; }

        //[ProtoMember(4)]
        //public int[] requipredComponent { get; set; }

    }
}
