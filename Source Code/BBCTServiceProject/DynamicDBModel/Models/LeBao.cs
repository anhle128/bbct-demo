using DynamicDBModel.Enum;
using ProtoBuf;
using System.Collections.Generic;

namespace DynamicDBModel.Models
{
    [ProtoContract]
    public class LeBao
    {
        [ProtoMember(1)]
        public string _id;
        [ProtoMember(2)]
        public string name;
        [ProtoMember(3)]
        public int gold;
        [ProtoMember(4)]
        public int realGold;
        [ProtoMember(5)]
        public List<SubRewardItem> rewards;
        [ProtoMember(6)]
        public string start;
        [ProtoMember(7)]
        public string end;
        [ProtoMember(8)]
        public int vip_required;
        [ProtoMember(9)]
        public int totalBuyTimes; // tổng số lần đã mua lễ bao
        [ProtoMember(10)]
        public int max_buy_times; // số lần tối đa được mua lễ bao
        [ProtoMember(11)]
        public TypeLeBaoActivationTime activation;
        [ProtoMember(12)]
        public TypeLeBaoBuyTimes buy_times;
    }
}
