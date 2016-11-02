using ProtoBuf;

namespace StaticDB.Models
{
    [ProtoContract]
    public class VipConfig
    {
        [ProtoMember(1)]
        public int rubyRequire { get; set; }
        [ProtoMember(2)]
        public int arenaTimes { get; set; } // số lần luận kiếm
        [ProtoMember(3)]
        public int challengeTimes { get; set; } // số lần thách đấu
        [ProtoMember(4)]
        public int resetStageTimes { get; set; } // số lần làm mới stage
        [ProtoMember(5)]
        public int moiRuouTimes { get; set; } // số lần mới rượu
        [ProtoMember(6)]
        public int vanTieuTimes { get; set; } // số lần vận tiêu
        [ProtoMember(7)]
        public int cauCaTimes { get; set; } // số lần câu cá
        [ProtoMember(8)]
        public int doPhuongTimes { get; set; } // số lần đổ phường
        [ProtoMember(9)]
        public int cuopTieuTimes { get; set; } // số lần cướp tiêu
        [ProtoMember(10)]
        public int maxSellMarket { get; set; }
        [ProtoMember(11)]
        public int exchangeGoldToSilverTimes { get; set; } // số lần đổi knb ra bạc
        [ProtoMember(12)]
        public int huaNguyenTimes { get; set; } // số lần sử dụng hứa nguyện phù trong ngày
        [ProtoMember(13)]
        public int buyPointSkillTimes { get; set; } // số lần mua điểm tăng skill 

    }
}
