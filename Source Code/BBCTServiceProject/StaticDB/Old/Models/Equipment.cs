using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Equipment
    {
        public enum Category : int
        {
            Vukhi = 1,
            Mu = 2,
            Ao = 3,
            TrangSuc = 4,
            Giay = 5,
            ThatLung = 6
        };

        [ProtoMember(1)]
        public int id { get; set; }
        [ProtoMember(2)]
        public int category { get; set; }
        [ProtoMember(3)]
        public int promotionLevel { get; set; }
        [ProtoMember(4)]
        public List<Option> options { get; set; }
        [ProtoMember(8)]
        public List<ReceiptEquipment> evolutionReceipts { get; set; }
        [ProtoMember(6)]
        public int kitId { get; set; }
        //[ProtoMember(7)]
        //public List<Receipt> draffReceipts { get; set; }

        public Equipment()
        {

        }
    }
}
