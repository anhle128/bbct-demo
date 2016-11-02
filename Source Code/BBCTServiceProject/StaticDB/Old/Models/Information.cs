using System;
using System.Collections.Generic;
using System.Text;
using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class Information
    {
        // Đã dùng
        // Tỷ lệ x damage khi tấn công vào đối thủ bị khắc bởi mình
        [ProtoMember(1)]
        public float[] modDanhKhacHe { get; set; }

        // Tỷ lệ x damage khi tấn công vào đối thủ mà có hệ mình bị khắc
        [ProtoMember(2)]
        public float[] modDanhBiKhacHe { get; set; }

        // Sô mod x damage khi crit
        [ProtoMember(3)]
        public float modCritDamage { get; set; }


        //Chưa dùng
        [ProtoMember(4)]
        public int priceEvolutionEquipment { get; set; }
        //[ProtoMember(5)]
        //public int[] priceResetCamDia { get; set; }
        [ProtoMember(6)]
        public int priceCraftPromotion { get; set; }
        [ProtoMember(7)]
        public int priceSilverUpEquipment { get; set; }
        [ProtoMember(8)]
        public int priceGoldUpEquipment { get; set; }
        [ProtoMember(9)]
        public int priceLockGoldUpEquipment { get; set; }
        [ProtoMember(10)]
        public int countSoul { get; set; }

        [ProtoMember(11)]
        public int[] draffReceipt { get; set; }

        [ProtoMember(12)]
        public int[] joinReceipt { get; set; }

        [ProtoMember(13)]
        public int resetAttackGold { get; set; }
        //[ProtoMember(14)]
        //public List<Vip> buys { get; set; }

        public Information()
        {

        }
    }
}
