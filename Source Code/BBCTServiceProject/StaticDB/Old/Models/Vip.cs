using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Text;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Vip
    {
        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public string config { get; set; }
        //public int countHuaNguyen { get; set; }
        //[ProtoMember(3)]
        //public int countDaoKhoBau { get; set; }
        //[ProtoMember(4)]
        //public int countLuanKiem { get; set; }
        //[ProtoMember(5)]
        //public int countDanhBoss { get; set; }
        //[ProtoMember(6)]
        //public int countDoiBac { get; set; }
        //[ProtoMember(7)]
        //public int countMuaLuotDanh { get; set; }
        //[ProtoMember(8)]
        //public int countMoiRuou { get; set; }
        //[ProtoMember(9)]
        //public int countNhanTheCanQuet { get; set; }
        //[ProtoMember(10)]
        //public int countThachDau { get; set; }
        public Vip()
        {

        }
    }
}
